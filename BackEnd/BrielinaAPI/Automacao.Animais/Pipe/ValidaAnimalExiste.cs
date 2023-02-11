using Dominio.Entidades;
using Newtonsoft.Json;
using PipeliningLibrary;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Automacao.Animais.Pipe
{
    public class ValidaAnimalExiste : IPipe
    {
        public object Run (dynamic input)
        {
            List<Animal> Animais = input.Animais;
            string nomeAnimal = input.novoAnimal.Nome;

            Animal animalSelecionado = Animais.FirstOrDefault(x => x.Nome.ToLower() == nomeAnimal.ToLower());

            if (animalSelecionado != null)
            {
                input.message = "Esse animal ja existe!";
                return new PipelineEnd(input);
            }

            return input;
        }
    }
}
