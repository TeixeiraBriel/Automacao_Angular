using Dominio.Entidades;
using Newtonsoft.Json;
using PipeliningLibrary;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Automacao.Animais.Pipe
{
    public class RemoveAnimal : IPipe
    {
        public object Run (dynamic input)
        {
            List<Animal> Animais = input.Animais;
            Animal animalSelecionado = input.Animal;

            Animais.Remove(animalSelecionado);

            input.Animais = Animais;
            return input;
        }
    }
}
