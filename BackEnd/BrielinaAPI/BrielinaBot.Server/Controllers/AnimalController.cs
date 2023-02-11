using Dominio.Configuration;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class AnimalController : MainController
    {
        #region Variaveis

        public AppSettings _appSettings { get; set; }

        #endregion

        #region Construtor
        public AnimalController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        #endregion

        #region Requisições

        //[JwtAuthorize]
        [HttpGet, Route("Todos")]
        public IActionResult Animais()
        {
            try
            {
                string json = "[{ \"Nome\": \"Vaca\", \"Idade\": \"15\", \"Cor\": \"Azul\", \"Sexo\": \"Femea\", \"Peso\": \"80kg\" },{ \"Nome\": \"Urso\", \"Idade\": \"5\", \"Cor\": \"Vermelho\", \"Sexo\": \"Macho\", \"Peso\": \"10kg\" },{ \"Nome\": \"Pato\", \"Idade\": \"1\", \"Cor\": \"Rosa\", \"Sexo\": \"Macho\", \"Peso\": \"20kg\" }]";

                return StatusCode(200, json);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[JwtAuthorize]
        [HttpGet, Route("{NomeAnimal}")]
        public IActionResult Animais([FromRoute] string NomeAnimal)
        {
            try
            {
                return StatusCode(200, $"Você chamou {NomeAnimal}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[JwtAuthorize]
        [HttpPost, Route("novo")]
        public IActionResult novoAnimal([FromBody] Animal NomeAnimal)
        {
            try
            {
                return StatusCode(200, NomeAnimal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion
    }
}
