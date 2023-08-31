using Dominio.Entidades;

namespace Dominio.Interfaces.Repositorio
{
    public interface ISessaoRepositorio
    {
        Task<Sessao> ObterSessaoPorRefreshToken(string refreshToken);
        Task UpdateSessao(Sessao newSessao);
        Task CriarSessao(Sessao newSessao);
    }
}

