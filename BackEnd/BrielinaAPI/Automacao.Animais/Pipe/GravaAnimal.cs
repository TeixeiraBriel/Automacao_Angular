using Dominio.Entidades;
using Newtonsoft.Json;
using PipeliningLibrary;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Automacao.Animais.Pipe
{
    public class GravaAnimal : IPipe
    {
        public object Run (dynamic input)
        {
            List<Animal> Animais = input.Animais;
            Animal animal = input.novoAnimal;
            Animais.Add(animal);

            return input;
        }
    }
}
