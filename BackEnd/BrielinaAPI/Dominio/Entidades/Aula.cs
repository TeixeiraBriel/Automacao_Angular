using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Aula
    {
        public int IdAulas { get; set; }
        public string Professor { get; set; }
        public string Tema { get; set; }
        public string ResumoAula { get; set; }
        public string Ministracao { get; set; }
        public string DataAula { get; set; }
        public string QtdAlunos { get; set; }
        public string QtdBiblias { get; set; }
        public string QtdVisitantes { get; set; }
    }
}
