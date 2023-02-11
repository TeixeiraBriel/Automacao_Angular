using Dominio.Configuration;
using Dominio.Entidades;
using Dominio.Interfaces.Executor;
using Dominio.ObjetoValor.Pipelines;
using Microsoft.AspNetCore.Mvc;
using XpandoLibrary;

namespace Host.Controllers
{
    public class AnimalController : MainController
    {
        #region Variaveis

        public AppSettings _appSettings { get; set; }

        private IExecutor _executorAnimais;

        #endregion

        #region Construtor
        public AnimalController(AppSettings appSettings, IExecutor executorAnimais)
        {
            _appSettings = appSettings;
            _executorAnimais = executorAnimais;
        }

        #endregion

        #region Requisições

        //[JwtAuthorize]
        [HttpGet, Route("Todos")]
        public IActionResult Animais()
        {
            ResultadoExecucao retorno = null;
            try
            {
                retorno = _executorAnimais.ExecutaComRetorno("BuscaTodosAnimais", new { }.ToExpando());

                return StatusCode(200, retorno.Output.Animais);
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
            ResultadoExecucao retorno = null;
            try
            {
                retorno = _executorAnimais.ExecutaComRetorno("BuscaAnimalEspecifico", new { nomeAnimal = NomeAnimal, message = "Sucesso" }.ToExpando());

                if (retorno.Output.message == "Sucesso")
                    return StatusCode(200, retorno.Output.Animal);
                else
                    return StatusCode(200, retorno.Output.message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[JwtAuthorize]
        [HttpPost, Route("novo")]
        public IActionResult novoAnimal([FromBody] Animal novoAnimal)
        {
            ResultadoExecucao retorno = null;
            try
            {
                retorno = _executorAnimais.ExecutaComRetorno("CriaNovoAnimal", new { Animal = novoAnimal }.ToExpando());

                return StatusCode(200, "Sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[JwtAuthorize]
        [HttpPost, Route("remover/{NomeAnimal}")]
        public IActionResult RemoverAnimal([FromRoute] string NomeAnimal)
        {
            ResultadoExecucao retorno = null;
            try
            {
                retorno = _executorAnimais.ExecutaComRetorno("RemoverAnimal", new { nomeAnimal = NomeAnimal, message = "Sucesso" }.ToExpando());

                if (retorno.Output.message == "Sucesso")
                    return StatusCode(200, $"Você Excluiu {NomeAnimal}");
                else
                    return StatusCode(200, retorno.Output.message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion
    }
}
