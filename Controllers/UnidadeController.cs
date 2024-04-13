using fdassembly.Interfaces;
using fdassembly.Models;
using Microsoft.AspNetCore.Mvc;



namespace fdassembly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase

    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeController(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Unidade>>> Get()
        {
            return await _unidadeRepository.GetAll();
        }

        [HttpGet("GetRegisters")]
        public async Task<ActionResult<List<Unidade>>> GetRegisters()
        {
            return await _unidadeRepository.GetAllRegisters();
        }

        [HttpGet("GetDetails")]
        public async Task<ActionResult<List<UnidadeDetails>>> GetDetails()
        {
            return await _unidadeRepository.GetAllDetails();
        }

        [HttpPost]
        public async Task<ActionResult<Unidade>> Post([FromBody] Unidade unidade)
        {
            return await _unidadeRepository.Save(unidade);
        }
    }
}
