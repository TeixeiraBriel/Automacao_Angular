using Dominio.Entidades;
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
    public class AulaRepositorio : IAulaRepositorio
    {
        private IConfiguration _configuration;
        public AulaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Aula>> ObterTodasAulas()
        {
            using (Context _context = ContextFactory.OpenContext(_configuration))
            {
                Task<List<Aula>> list = _context.Aulas.ToListAsync();
                return await list;
            }
        }
        public async Task<Aula> ObterAulaPorId(int Id)
        {
            using (Context _context = ContextFactory.OpenContext(_configuration))
            {
                return await _context.Aulas.FirstOrDefaultAsync(x => x.IdAulas == Id);
            }
        }
        public async Task CriarAula(Aula newAula)
        {
            using (Context _context = ContextFactory.OpenContext(_configuration))
            {
                _context.Aulas.Add(newAula);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAula(Aula newAula)
        {
            using (Context _context = ContextFactory.OpenContext(_configuration))
            {
                _context.Aulas.Where(x => x.IdAulas == newAula.IdAulas).First().Ministracao = newAula.Ministracao;
                await _context.SaveChangesAsync();
            }
        }
    }
}
