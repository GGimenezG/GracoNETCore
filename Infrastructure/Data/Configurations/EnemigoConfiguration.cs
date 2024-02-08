using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EnemigoConfiguration : IEntityTypeConfiguration<Enemigo>
    {
        public void Configure(EntityTypeBuilder<Enemigo> builder){
            
            builder.Property(p => p.recompensaId).IsRequired();

            /*builder
                .HasOne(x => x.tipo)
                .WithMany(y => y.Enemigos)
                .HasForeignKey(x => x.tipoId);*/

             builder
                .HasOne(x => x.Recompensa)
                .WithMany(y => y.enemigos)
                .HasForeignKey(x => x.recompensaId).IsRequired(false);

            builder
                .ToTable("EnemigoGG");
        }
    }
}