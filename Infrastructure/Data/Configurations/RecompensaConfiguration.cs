using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RecompensaConfiguration : IEntityTypeConfiguration<Recompensa>
    {
        public void Configure(EntityTypeBuilder<Recompensa> builder){
            
            builder
                .HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .UseIdentityColumn();

            builder
                .Property(x => x.experiencia)
                .IsRequired();
            
            builder
                .Property(x => x.monedas)
                .IsRequired();
            
           /* builder
                .HasMany(x => x.objetos)
                .WithMany(y => y.Recompensas);*/

            builder
                .ToTable("RecompensaGG");
        }
    }
}