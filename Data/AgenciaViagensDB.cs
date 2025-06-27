using AT_C__2.Models;
using Microsoft.EntityFrameworkCore;

namespace AT_C__2.Data
{
    public class AgenciaViagensDB : DbContext
    {
        public AgenciaViagensDB(DbContextOptions<AgenciaViagensDB> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PacoteTuristico>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");
        }
    }
}
