using Dominio.Entidades;
using Newtonsoft.Json;
using PipeliningLibrary;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Automacao.Animais.Pipe
{
    public class BuscaAnimal : IPipe
    {
        public object Run (dynamic input)
        {
            List<Animal> Animais = input.Animais;
            string nomeAnimal = input.nomeAnimal;

            Animal animalSelecionado = Animais.FirstOrDefault(x => x.Nome.ToLower() == nomeAnimal.ToLower());

            if (animalSelecionado == null)
            {
                input.message = "Não existe esse animal!";
                return new PipelineEnd(input);
            }

            input.Animal = animalSelecionado;
            return input;
        }
    }
}
