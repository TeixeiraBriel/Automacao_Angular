using Automacao.Animais.Pipe;
using PipeliningLibrary;

namespace Automacao.Animais
{
    public class Pipelines : PipelineGroup
    {
        public Pipelines()
        {
            Pipeline("BuscaTodosAnimais")
                .Pipe<AcessaJson>();

            Pipeline("BuscaAnimalEspecifico")
                .Pipe<AcessaJson>()
                .Pipe<BuscaAnimal>();

            Pipeline("CriaNovoAnimal")
                .Pipe<AcessaJson>()
                .Pipe<ValidaAnimalExiste>()
                .Pipe<GravaAnimal>()
                .Pipe<SalvaNovaLista>();

            Pipeline("RemoverAnimal")
                .Pipe<AcessaJson>()
                .Pipe<BuscaAnimal>()
                .Pipe<RemoveAnimal>()
                .Pipe<SalvaNovaLista>();

        }
    }
}