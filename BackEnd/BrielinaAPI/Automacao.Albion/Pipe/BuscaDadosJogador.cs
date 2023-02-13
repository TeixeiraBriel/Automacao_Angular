using PipeliningLibrary;
using System.Text.Json;
using System;
using System.Dynamic;
using System.Text.RegularExpressions;
using Dominio.Entidades;
using RestSharp;
using Newtonsoft.Json;

namespace Automacao.Albion.Pipe
{
    public class BuscaDadosJogador : IPipe
    {
        public object Run(dynamic input)
        {

            string idJogador = input.Id;

            var client = new RestClient($"https://gameinfo.albiononline.com/api/gameinfo/players/{idJogador}");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            dynamic jogador = (JsonConvert.DeserializeObject<ExpandoObject>(response.Content) as dynamic);

            input.dadosJogador = jogador;
            return input;
        }
    }
}
