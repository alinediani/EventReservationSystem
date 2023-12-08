using Microsoft.EntityFrameworkCore;

namespace EventReservationSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Evento> Eventos { get; set; }
        public DbSet<Models.Reserva> Reservas { get; set; }
        public DbSet<Models.Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
