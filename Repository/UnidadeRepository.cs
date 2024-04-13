using fdassembly.Interfaces;
using fdassembly.Models;
using Microsoft.EntityFrameworkCore;
namespace fdassembly.Repository
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly AppDbContext _context;
        public UnidadeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Unidade>> GetAll()
        {
            return await _context.Unidade.ToListAsync();
        }
        public async Task<Unidade> Save(Unidade unidade)
        {
            if (unidade.Id == Guid.Empty)
            {
                unidade.Id = Guid.NewGuid();
                _context.Unidade.Add(unidade);
            }
            else
            {
                _context.Unidade.Update(unidade);
            }
            await _context.SaveChangesAsync();
            return unidade;
        }
    }
}
