
using Core.Entidades;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Personaje> Personajes {get;set;}
        public DbSet<Enemigo> Enemigos {get;set;}
        public DbSet<Objetos> Objetos {get;set;}
        public DbSet<Recompensa> Recompensas {get;set;}
        public DbSet<TipoPersonaje> TipoPersonajes {get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonajeConfiguration());
            builder.ApplyConfiguration(new EnemigoConfiguration());
            builder.ApplyConfiguration(new ObjetosConfiguration());
            builder.ApplyConfiguration(new RecompensaConfiguration());
            builder.ApplyConfiguration(new TipoPersonajeConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }
}