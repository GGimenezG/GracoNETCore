using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ObjetosConfiguration : IEntityTypeConfiguration<Objetos>
    {
        public void Configure(EntityTypeBuilder<Objetos> builder){
            
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
                .Property(x => x.tipo)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(p => p.valor).IsRequired();

            builder
                .ToTable("Objeto");
        }
    }
}