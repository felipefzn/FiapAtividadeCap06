using Fiap_AtividadeCap07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap_AtividadeCap07.Data
{
    public class CityTrafficDbContext : DbContext
    {
        public CityTrafficDbContext(DbContextOptions<CityTrafficDbContext> options)
            : base(options)
        {
        }

        public DbSet<Acidente> Acidentes { get; set; }
        public DbSet<Semaforo> Semaforos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Acidente>().HasKey(a => a.Id);
            modelBuilder.Entity<Semaforo>().HasKey(s => s.Id);
        }
    }
}
