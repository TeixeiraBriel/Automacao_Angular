using PipeliningLibrary;
using System.Text.Json;
using System;
using System.Dynamic;
using System.Text.RegularExpressions;
using Dominio.Entidades;

namespace Automacao.Animais.Pipe
{
    public class AcessaJson : IPipe
    {
        public object Run (dynamic input)
        {
            string text = File.ReadAllText(@"./Dados/banco.json");
            text = string.Join(" ", Regex.Split(text, @"(?:\r\n|\n|\r)"));

            List<Animal> Animais = JsonSerializer.Deserialize<List<Animal>>(text);
            input.Animais = Animais;

            return input;
        }
    }
}
