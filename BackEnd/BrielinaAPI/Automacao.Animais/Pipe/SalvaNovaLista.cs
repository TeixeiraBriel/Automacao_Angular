using Dominio.Entidades;
using Newtonsoft.Json;
using PipeliningLibrary;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Automacao.Animais.Pipe
{
    public class SalvaNovaLista : IPipe
    {
        public object Run (dynamic input)
        {
            List<Animal> Animais = input.Animais;
            string texto = JsonConvert.SerializeObject(Animais);
            File.WriteAllText(@"./Dados/banco.json",texto);

            return input;
        }
    }
}
