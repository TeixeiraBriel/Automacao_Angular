using Dominio.Configuration;
using Dominio.Interfaces.Executor;
using Dominio.ObjetoValor.Pipelines;
using Microsoft.AspNetCore.Mvc;
using XpandoLibrary;

namespace Host.Controllers
{
    public class AlbionController : MainController
    {
        #region Variaveis

        public AppSettings _appSettings { get; set; }

        private IExecutor _Executor;

        #endregion

        #region Construtor
        public AlbionController(AppSettings appSettings, IExecutor Executor)
        {
            _appSettings = appSettings;
            _Executor = Executor;
        }

        #endregion

        #region Requisições

        //[JwtAuthorize]
        [HttpGet, Route("{nome}")]
        public IActionResult BuscaPorNickname([FromRoute] string nome)
        {
            ResultadoExecucao retorno = null;
            try
            {
                retorno = _Executor.AlbionExecutaComRetorno("BuscaNicknames", new { nickname = nome }.ToExpando());

                return StatusCode(200, retorno.Output.opcoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
