using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TipoPersonajeConfiguration: IEntityTypeConfiguration<TipoPersonaje>
    {
        public void Configure(EntityTypeBuilder<TipoPersonaje> builder){
            
            builder
                .HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .UseIdentityColumn();

            builder
                .Property(x => x.nombre)
                .IsRequired()
                .HasMaxLength(270);

            //builder.Property(x=>x.fuerteContra).IsRequired();
            //builder.Property(x=>x.debilContra).IsRequired();
            
            /*builder
                .HasOne(x => x.fuerte)
                .WithMany()
                .HasForeignKey(x=>x.fuerteContra).IsRequired();*/

           /* builder
                .HasOne(x => x.debil)
                .WithMany()
                .HasForeignKey(x=>x.debilContra).IsRequired();*/

            /*builder
                .HasMany(x => x.Personajes)
                .WithOne(x => x.tipo).HasForeignKey(x=>x.tipoId);*/

            builder
                .ToTable("TipoPersonajeGG");
        }
    }
}