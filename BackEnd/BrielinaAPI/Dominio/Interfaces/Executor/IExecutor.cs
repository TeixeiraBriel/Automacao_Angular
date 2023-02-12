using Dominio.ObjetoValor.Pipelines;

namespace Dominio.Interfaces.Executor
{
    public  interface IExecutor
    {
        public ResultadoExecucao AnimaisExecutaComRetorno(string pipeline, dynamic input);
        public ResultadoExecucao AlbionExecutaComRetorno(string pipeline, dynamic input);
    }
}
