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
    public class ComentarioMapping : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("comentarios");

            builder.HasKey(p => p.idcomentarios);
            builder.Property(p => p.idcomentarios).IsRequired().ValueGeneratedOnAdd();

            builder.Property(p => p.idpublicacoes).IsRequired();
            builder.Property(p => p.text).IsRequired().HasDefaultValue("");
            builder.Property(p => p.data).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
