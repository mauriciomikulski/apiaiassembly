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

        //public async Task<List<UnidadeDetails>> GetAllDetails()
        //{
        //    var response = await _context.Registros.Include(r => r.Unidade).ToListAsync();

        //    List<UnidadeDetails> unidadeDetails = new List<UnidadeDetails>();

        //    response.ForEach(r =>
        //    {
        //        unidadeDetails.Add(new UnidadeDetails()
        //        {
        //            Id = r.Id,
        //            Nome = r.Unidade.Nome,
        //            LiveCamURL = r.Unidade.LiveCamURL,
        //            Locate = r.Unidade.Locate,
        //            MaxLimit = r.Unidade.MaxLimit,
        //            MinLimit = r.Unidade.MinLimit,
        //            FaceDetecteds = r.Faces,
        //            DataHora = r.DataHora
        //        });
        //    });

        //    return unidadeDetails;
        // }

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
