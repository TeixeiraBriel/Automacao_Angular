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
    public class BuscaNomes : IPipe
    {
        public object Run(dynamic input)
        {
            string nomeJogador = input.nickname;
            var client = new RestClient($"https://gameinfo.albiononline.com/api/gameinfo/search?q={nomeJogador}");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            dynamic jogadores = (JsonConvert.DeserializeObject<ExpandoObject>(response.Content) as dynamic).players;

            List<string> opcoes = new List<string>(); 
            foreach (var jogador in jogadores)
            {
                opcoes.Add($"{jogador.Name}|{jogador.Id}");
            }

            input.opcoes = opcoes;
            return input;
        }
    }
}
