using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface INarrativaRepositorio
    {
        Task<List<Narrativa>> ObterTodasNarrativas();
        Task<Narrativa> ObterNarrativaPorId(int Id);
        Task CriarNarrativa(Narrativa newNarrativa);
        Task DeleteNarrativa(int Id);
    }
}
