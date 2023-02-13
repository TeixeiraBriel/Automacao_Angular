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

                string[] opcoes = retorno.Output.opcoes;
                List<dynamic> newOpcoes = new List<dynamic>();
                foreach (var opcao in opcoes)
                {
                    dynamic saida = new { Nome = opcao.Split('|')[0], Id = opcao.Split('|')[1] };
                    newOpcoes.Add(saida);
                }

                return StatusCode(200, newOpcoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[JwtAuthorize]
        [HttpGet, Route("Id/{Id}")]
        public IActionResult BuscaPorId([FromRoute] string Id)
        {
            ResultadoExecucao retorno = null;
            try
            {
                retorno = _Executor.AlbionExecutaComRetorno("BuscaDadosJogador", new { Id = Id }.ToExpando());

                return StatusCode(200, retorno.Output.dadosJogador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
