using Automacao.Albion.Pipe;
using PipeliningLibrary;

namespace Automacao.Albion
{
    public class Pipelines : PipelineGroup
    {
        public Pipelines()
        {
            Pipeline("BuscaNicknames")
                .Pipe<BuscaNomes>();

        }
    }
}