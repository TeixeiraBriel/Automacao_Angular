using Dominio.Entidades;
using Dominio.Entidades.SerafinsHub;
using Infraestrutura.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infraestrutura.EntityFramework
{
    public class SerafinsHubContext : DbContext
    {
        private IConfiguration _configuration;

        public SerafinsHubContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connetionString = _configuration.GetConnectionString("SerafinsHubConnection");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior= DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new PublicacoesMapping());
            modelBuilder.ApplyConfiguration(new ComentarioMapping());
        }

        public DbSet<Publicacoes> Publicacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
