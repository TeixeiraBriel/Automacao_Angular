using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Mapping
{
    public class SessaoMapping : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("Sessao");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(p => p.AccessToken).IsRequired();
            builder.Property(p => p.IdUsuario).IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnType("datetime").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.DataExpiracao).HasColumnType("datetime").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.RefreshToken).IsRequired();
        }
    }
}