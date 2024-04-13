using fdassembly.Interfaces;
using fdassembly.Models;
using FFmpeg.NET;
using Microsoft.AspNetCore.Mvc;

namespace fdassembly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase

    {
        private readonly Engine engine;

        public FileController(Engine engine)
        {
            this.engine = engine;
        }

        [HttpPost]
        public async Task<ActionResult> GetThumbnail(IFormFile file, int timeSeconds)
        {
            try
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string tempPath = Path.GetTempPath();

                string filePath = Path.Combine(tempPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var inputFile = new InputFile(filePath);

                string fileOutput = Path.Combine(tempPath, $"{Guid.NewGuid().ToString()}_output.jpg");

                var outputFile = new OutputFile(fileOutput);

                string pathFile = AppDomain.CurrentDomain.BaseDirectory;
                var ffmpeg = new Engine($"{pathFile}ffmpeg.exe");

                var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(timeSeconds) };
                await ffmpeg.GetThumbnailAsync(inputFile, outputFile, options);

                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(fileOutput);

                string base64String = Convert.ToBase64String(fileBytes);

                return Ok(new { base64String });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }
    }
}
