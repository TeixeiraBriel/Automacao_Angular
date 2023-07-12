using Dominio.Entidades;
using Dominio.Entidades.SerafinsHub;
using Dominio.Interfaces.Repositorio;
using Infraestrutura.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class SerafinsHubRepositorio : ISerafinsHubRepositorio
    {
        private IConfiguration _configuration;
        public SerafinsHubRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Publicacoes>> ObterTodasPublicacoes()
        {
            using (SerafinsHubContext _context = ContextFactory.SerafinsHubOpenContext(_configuration))
            {
                Task<List<Publicacoes>> list = _context.Publicacoes.ToListAsync();
                return await list;
            }
        }
        public async Task<Publicacoes> ObterPublicacoesPorId(int Id)
        {
            using (SerafinsHubContext _context = ContextFactory.SerafinsHubOpenContext(_configuration))
            {
                return await _context.Publicacoes.FirstOrDefaultAsync(x => x.idpublicacoes == Id);
            }
        }
        public async Task CriarPublicacoes(Publicacoes newPublicacoes)
        {
            using (SerafinsHubContext _context = ContextFactory.SerafinsHubOpenContext(_configuration))
            {
                _context.Publicacoes.Add(newPublicacoes);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdatePublicacoes(Publicacoes newPublicacoes)
        {
            using (SerafinsHubContext _context = ContextFactory.SerafinsHubOpenContext(_configuration))
            {
                _context.Publicacoes.Where(x => x.idpublicacoes == newPublicacoes.idpublicacoes).First().text = newPublicacoes.text;
                await _context.SaveChangesAsync();
            }
        }
    }
}
