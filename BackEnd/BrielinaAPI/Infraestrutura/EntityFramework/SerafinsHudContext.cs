﻿using Dominio.Entidades;
using Infraestrutura.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infraestrutura.EntityFramework
{
    public class SerafinsHudContext : DbContext
    {
        private IConfiguration _configuration;

        public SerafinsHudContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connetionString = _configuration.GetConnectionString("AulasConnection");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior= DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new AulaMapping());
            modelBuilder.ApplyConfiguration(new NarrativaMapping());
        }

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Narrativa> Narrativas { get; set; }
    }
}
