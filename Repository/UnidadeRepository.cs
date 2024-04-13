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

        public async Task<List<Unidade>> GetAllRegisters()
        {
            List<Unidade> response = await _context.Unidade.Include(r => r.Registros).ToListAsync();

            return response;
        }

        public async Task<List<UnidadeDetails>> GetAllDetails()
        {
            var response = await GetAllRegisters();
            List<UnidadeDetails> detailsList = new List<UnidadeDetails>();

            foreach(Unidade register in response)
            {
                detailsList.Add(new UnidadeDetails()
                {
                    Id = register.Id,
                    LiveCamURL = register.LiveCamURL,
                    Nome = register.Nome,
                    MaxLimit = register.MaxLimit,
                    MinLimit = register.MinLimit,
                    Locate = register.Locate,
                    Ocupation = register.Registros.Any() ? ((register.Registros.LastOrDefault().Faces * register.MaxLimit) / 100) : 0,
                    LastUpdate = register.Registros.Any() ? (DateTime.UtcNow - register.Registros.LastOrDefault().DataHora).TotalMinutes : 0,
                    Registros = register.Registros,
                });
            }

            return detailsList;
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
