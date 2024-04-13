using fdassembly.Models;
using Microsoft.EntityFrameworkCore;

namespace fdassembly.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Registros> Registros { get; set; }
    }
}
