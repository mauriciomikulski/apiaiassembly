using fdassembly.Models;
namespace fdassembly.Interfaces
{
    public interface IRegistrosRepository
    {
        Task<List<Registros>> GetAll();
        Task<Registros> Save(Registros registros);
    }
}
