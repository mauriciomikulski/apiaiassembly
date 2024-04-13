using fdassembly.Models;

namespace fdassembly.Interfaces
{
    public interface IUnidadeRepository
    {
        Task<List<Unidade>> GetAll();
        Task<Unidade> Save(Unidade unidade);
    }
}
