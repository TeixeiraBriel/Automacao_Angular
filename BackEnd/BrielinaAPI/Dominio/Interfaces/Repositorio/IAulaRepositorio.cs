using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositorio
{
    public interface IAulaRepositorio
    {
        Task<List<Aula>> ObterTodasAulas();
        Task<Aula> ObterAulaPorId(int Id);
        Task CriarAula(Aula newAula);
        Task UpdateAula(Aula newAula);    
    }
}
