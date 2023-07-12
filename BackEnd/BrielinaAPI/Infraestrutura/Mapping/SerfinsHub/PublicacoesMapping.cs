using Dominio.Entidades;
using Dominio.Entidades.SerafinsHub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mapping
{
    public class PublicacoesMapping : IEntityTypeConfiguration<Publicacoes>
    {
        public void Configure(EntityTypeBuilder<Publicacoes> builder)
        {
            builder.ToTable("publicacoes");

            builder.HasKey(p => p.idpublicacoes);
            builder.Property(p => p.idpublicacoes).IsRequired().ValueGeneratedOnAdd();

            builder.Property(p => p.text).IsRequired()  .HasDefaultValue("");
            builder.Property(p => p.data).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
