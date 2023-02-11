using Dominio.Interfaces.Executor;
using Dominio.ObjetoValor.Pipelines;
using PipeliningLibrary;
using XpandoLibrary;

namespace Infraestrutura.Executor
{
    public class Executor : IExecutor
    {
        private readonly Automacao.Animais.Pipelines _AnimaisPipelines;
        public Executor()
        {
            _AnimaisPipelines = new Automacao.Animais.Pipelines();
        }

        public ResultadoExecucao ExecutaComRetorno(string pipeline, dynamic input)
        {
            PipelineResult retorno = default;

            try
            {
                retorno = _AnimaisPipelines[pipeline].RunDetailed(input);

                if (!retorno.Success)
                    throw retorno.Exception();
            }
            finally
            {
                dynamic output = retorno.Output.ToExpando();
            }

            return new ResultadoExecucao()
            {
                Sucesso = retorno.Success,
                Exception = retorno.Exception(),
                Output = retorno.Output.ToExpando()
            };
        }
    }
}
