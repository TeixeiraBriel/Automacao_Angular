using Dominio.Entidades;
using Infraestrutura.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infraestrutura.EntityFramework
{
    public class Context : DbContext
    {
        private IConfiguration _configuration;

        public Context(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connetionString = _configuration.GetConnectionString("DefaultConnection");
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySQL("server=localhost;database=aulas;user=admin;password=admin");
            optionsBuilder.UseMySql("server=localhost;database=serafinsjuniores;user=admin;password=admin", ServerVersion.AutoDetect("server=localhost;database=serafinsjuniores;user=admin;password=admin"));
            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior= DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new AulaMapping());
        }

        public DbSet<Aula> Aulas { get; set; }
    }
}
