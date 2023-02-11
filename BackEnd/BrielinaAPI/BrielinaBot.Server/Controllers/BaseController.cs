using Dominio.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class BaseController : MainController
    {
        #region Variaveis

        public AppSettings _appSettings { get; set; }

        #endregion

        #region Construtor
        public BaseController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        #endregion

        #region Requisições

        //[JwtAuthorize]
        [HttpGet, Route("Version")]
        public IActionResult Version()
        {
            return StatusCode(200, _appSettings.Version);
        }

        //[JwtAuthorize]
        [HttpGet, Route("Animais")]
        public IActionResult Animais()
        {
            string json = "[{ \"Nome\": \"Vaca\", \"Idade\": \"15\", \"Cor\": \"Azul\", \"Sexo\": \"Femea\", \"Peso\": \"80kg\" },{ \"Nome\": \"Urso\", \"Idade\": \"5\", \"Cor\": \"Vermelho\", \"Sexo\": \"Macho\", \"Peso\": \"10kg\" },{ \"Nome\": \"Pato\", \"Idade\": \"1\", \"Cor\": \"Rosa\", \"Sexo\": \"Macho\", \"Peso\": \"20kg\" }]";

            return StatusCode(200, json);
        }

        //[JwtAuthorize]
        [HttpGet, Route("Animais/{NomeAnimal}")]
        public IActionResult Animais([FromRoute] string NomeAnimal)
        {
            return StatusCode(200, $"Você chamou {NomeAnimal}");
        }

        #endregion
    }
}
