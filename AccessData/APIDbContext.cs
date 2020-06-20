using Microsoft.EntityFrameworkCore;
using Domain.Entities;


namespace AccessData {

    public class APIDbContext : DbContext {

        public APIDbContext(DbContextOptions<APIDbContext> options): base(options) { }

        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

    }

}