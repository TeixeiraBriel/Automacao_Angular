using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.SerafinsHub
{
    public class Comentario
    {
        public int idcomentarios { get; set; }
        public int idpublicacoes { get; set; }
        public string text { get; set; }
        public DateTime data { get; set; }
    }
}
