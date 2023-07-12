using Dominio.Entidades;
using Dominio.Entidades.SerafinsHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface ISerafinsHubRepositorio
    {
        Task<List<Publicacoes>> ObterTodasPublicacoes();
        Task<Publicacoes> ObterPublicacoesPorId(int Id);
        Task CriarPublicacoes(Publicacoes newAula);
        Task UpdatePublicacoes(Publicacoes newAula);    
    }
}
