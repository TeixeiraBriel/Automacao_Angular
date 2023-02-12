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

        private IExecutor _ExecutorAnimaisAnimais;

        #endregion

        #region Construtor
        public AnimalController(AppSettings appSettings, IExecutor ExecutorAnimaisAnimais)
        {
            _appSettings = appSettings;
            _ExecutorAnimaisAnimais = ExecutorAnimaisAnimais;
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
                retorno = _ExecutorAnimaisAnimais.AnimaisExecutaComRetorno("BuscaTodosAnimais", new { }.ToExpando());

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
                retorno = _ExecutorAnimaisAnimais.AnimaisExecutaComRetorno("BuscaAnimalEspecifico", new { nomeAnimal = NomeAnimal, message = "Sucesso" }.ToExpando());

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
                retorno = _ExecutorAnimaisAnimais.AnimaisExecutaComRetorno("CriaNovoAnimal", new { novoAnimal = novoAnimal }.ToExpando());

                return StatusCode(200, novoAnimal);
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
                retorno = _ExecutorAnimaisAnimais.AnimaisExecutaComRetorno("RemoverAnimal", new { nomeAnimal = NomeAnimal, message = "Sucesso" }.ToExpando());

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

        //[JwtAuthorize]
        [HttpPost, Route("editar")]
        public IActionResult editarAnimal([FromBody] Animal novoAnimal)
        {
            ResultadoExecucao retorno = null;
            try
            {
                retorno = _ExecutorAnimaisAnimais.AnimaisExecutaComRetorno("EditarAnimal", new { novoAnimal = novoAnimal, nomeAnimal = novoAnimal.Nome, message = "Sucesso" }.ToExpando());

                if (retorno.Output.message == "Sucesso")
                    return StatusCode(200, $"Você editou {novoAnimal.Nome}");
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
