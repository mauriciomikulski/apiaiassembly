using fdassembly.Interfaces;
using fdassembly.Models;
using Microsoft.AspNetCore.Mvc;


namespace fdassembly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly IRegistrosRepository _registrosRepository;

        public RegistrosController(IRegistrosRepository registrosRepository)
        {
            _registrosRepository = registrosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Registros>>> Get()
        {
            return await _registrosRepository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Registros>> Post([FromBody] Registros registros)
        {
            return await _registrosRepository.Save(registros);
        }
    }
}
