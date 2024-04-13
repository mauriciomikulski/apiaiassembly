using fdassembly.Models;

namespace fdassembly.Interfaces
{
    public interface IUnidadeRepository
    {
        Task<List<Unidade>> GetAll();
        Task<List<Unidade>> GetAllRegisters();
        Task<List<UnidadeDetails>> GetAllDetails();
        Task<Unidade> Save(Unidade unidade);
    }
}
