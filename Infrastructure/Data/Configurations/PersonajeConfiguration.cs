
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PersonajeConfiguration : IEntityTypeConfiguration<Personaje>
    {
        public void Configure(EntityTypeBuilder<Personaje> builder){
            
            builder
                .HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .UseIdentityColumn();

            builder
                .Property(x => x.nombre)
                .IsRequired()
                .HasMaxLength(255);
            
            builder
                .Property(x => x.tipo)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(p => p.estamina).IsRequired();

            builder.Property(p => p.inteligencia).IsRequired();
            builder.Property(p => p.fuerza).IsRequired();
            builder.Property(p => p.resistencia).IsRequired();
            builder.Property(p => p.defensa).IsRequired();
            builder.Property(p => p.experiencia).IsRequired();


            builder
                .ToTable("Personaje");
        }
        
    }
}