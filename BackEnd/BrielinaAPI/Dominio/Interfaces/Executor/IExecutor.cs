using Dominio.ObjetoValor.Pipelines;

namespace Dominio.Interfaces.Executor
{
    public  interface IExecutor
    {
        public ResultadoExecucao ExecutaComRetorno(string pipeline, dynamic input);
    }
}
