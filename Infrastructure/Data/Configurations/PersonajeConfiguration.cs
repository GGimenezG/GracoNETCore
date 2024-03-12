
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
                .HasMaxLength(270);
            
            builder
                .Property(x => x.tipoId)
                .IsRequired();
            
            builder.Property(p => p.estamina).IsRequired();

            builder.Property(p => p.inteligencia).IsRequired();
            builder.Property(p => p.fuerza);
            builder.Property(p => p.resistencia).IsRequired();
            builder.Property(p => p.defensa).IsRequired();
            builder.Property(p => p.experiencia).IsRequired();
            builder.Property(p => p.nivel).IsRequired();
            builder.Property(p => p.HP).IsRequired();
            builder.Property(p => p.MP).IsRequired();

            builder
                .HasOne(x => x.tipo)
                .WithMany()
                .HasForeignKey(x => x.tipoId);

            builder
                .ToTable("PersonajeGG");
        }
        
    }
}