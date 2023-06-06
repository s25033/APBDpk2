using APBDpk2.Entities.Configs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APBDpk2.Entities
{
    public class MuzykaDbContext : DbContext
    {

        public virtual DbSet<Muzyk> Muzycy { get; set; }

        public virtual DbSet<WykonawcaUtworu> Wykonawcy { get; set; }   

        public virtual DbSet<Utwor> Utwory { get; set; }

        public virtual DbSet<Album> Albumy { get; set; }

        public virtual DbSet<Wytwornia> Wywornie { get; set; }

        public MuzykaDbContext()
        {

        }

        public MuzykaDbContext(DbContextOptions<MuzykaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WykonawcaUtworuEfConfiguration).Assembly);
           
        }
    }
}
