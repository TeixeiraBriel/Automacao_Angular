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
    public class NarrativaRepositorio : INarrativaRepositorio
    {
        private IConfiguration _configuration;
        public NarrativaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Narrativa>> ObterTodasNarrativas()
        {
            using (SerafinsHudContext _context = ContextFactory.SerafinsHudOpenContext(_configuration))
            {
                Task<List<Narrativa>> list = _context.Narrativas.ToListAsync();
                return await list;
            }
        }
        public async Task<Narrativa> ObterNarrativaPorId(int Id)
        {
            using (SerafinsHudContext _context = ContextFactory.SerafinsHudOpenContext(_configuration))
            {
                return await _context.Narrativas.FirstOrDefaultAsync(x => x.IdNarrativas == Id);
            }
        }
        public async Task CriarNarrativa(Narrativa newNarrativa)
        {
            using (SerafinsHudContext _context = ContextFactory.SerafinsHudOpenContext(_configuration))
            {
                _context.Narrativas.Add(newNarrativa);
                var teste = await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteNarrativa(int Id)
        {
            using (SerafinsHudContext _context = ContextFactory.SerafinsHudOpenContext(_configuration))
            {
                Narrativa remove = await _context.Narrativas.FirstOrDefaultAsync(x => x.IdNarrativas == Id);;
                _context.Narrativas.Remove(remove);
                var teste = await _context.SaveChangesAsync();
            }
        }
    }
}
