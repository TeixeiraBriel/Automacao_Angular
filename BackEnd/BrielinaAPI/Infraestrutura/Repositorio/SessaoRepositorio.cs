using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Infraestrutura.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infraestrutura.Repositorio
{
    public class SessaoRepositorio : ISessaoRepositorio
    {
        private IConfiguration _configuration;

        public SessaoRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Sessao> ObterSessaoPorRefreshToken(string refreshToken)
        {
            using (Context _context = ContextFactory.OpenContext(_configuration))
            {
                return await _context.Sessoes.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            }
        }

        public async Task CriarSessao(Sessao newSessao)
        {
            using (Context _context = ContextFactory.OpenContext(_configuration))
            {
                _context.Sessoes.Add(newSessao);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateSessao(Sessao newSessao)
        {
            using (Context _context = ContextFactory.OpenContext(_configuration))
            {
                _context.Sessoes.Where(x => x.Id == newSessao.Id).First().AccessToken = newSessao.AccessToken;
                _context.Sessoes.Where(x => x.Id == newSessao.Id).First().DataCriacao = newSessao.DataCriacao;
                _context.Sessoes.Where(x => x.Id == newSessao.Id).First().DataExpiracao = newSessao.DataExpiracao;
                _context.Sessoes.Where(x => x.Id == newSessao.Id).First().RefreshToken = newSessao.RefreshToken;
                await _context.SaveChangesAsync();
            }
        }
    }
}