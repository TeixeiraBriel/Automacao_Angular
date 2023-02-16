using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mapping
{
    public class AulaMapping : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("aulas");

            builder.HasKey(p => p.IdAulas);
            builder.Property(p => p.IdAulas).IsRequired().ValueGeneratedOnAdd();

            builder.Property(p => p.Professor).HasDefaultValue("");
            builder.Property(p => p.Tema).HasDefaultValue("");
            builder.Property(p => p.ResumoAula).HasDefaultValue("");
            builder.Property(p => p.Ministracao).HasDefaultValue("");
            builder.Property(p => p.QtdAlunos).HasDefaultValue(0);
            builder.Property(p => p.QtdBiblias).HasDefaultValue(0);
            builder.Property(p => p.QtdVisitantes).HasDefaultValue(0);
            builder.Property(p => p.DataAula).HasDefaultValue("");
        }
    }
}
