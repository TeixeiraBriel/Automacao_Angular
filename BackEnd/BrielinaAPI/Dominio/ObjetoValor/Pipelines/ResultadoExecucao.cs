using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ObjetoValor.Pipelines
{
    public class ResultadoExecucao
    {
        public bool Sucesso { get; set; }
        public Exception Exception { get; set; }
        public dynamic Output { get; set; }
    }
}
