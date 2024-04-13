using fdassembly.Interfaces;
using fdassembly.Models;
using Microsoft.EntityFrameworkCore;

namespace fdassembly.Repository
{
    public class RegistroRepository : IRegistrosRepository
    {
        private readonly AppDbContext _context;
        public RegistroRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Registros>> GetAll()
        {
            return await _context.Registros.ToListAsync();
        }
        public async Task<Registros> Save(Registros registros)
        {
            if (registros.Id == Guid.Empty)
            {
                registros.Id = Guid.NewGuid();
                _context.Registros.Add(registros);
            }
            else
            {
                _context.Registros.Update(registros);
            }
            await _context.SaveChangesAsync();
            return registros;
        }
    }
}
