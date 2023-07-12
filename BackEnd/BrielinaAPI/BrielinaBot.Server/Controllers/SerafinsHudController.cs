using Dominio.Configuration;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class SerafinsHudController : MainController
    {
        #region Variaveis

        public AppSettings _appSettings { get; set; }
        public ISerafinsHudRepositorio _serafinsRepositorio { get; set; }

        #endregion

        #region Construtor
        public SerafinsHudController(AppSettings appSettings, ISerafinsHudRepositorio aulaRepositorio)
        {
            _appSettings = appSettings;
            _serafinsRepositorio= aulaRepositorio;
        }

        #endregion

        #region Requisições

        [HttpGet, Route("Todos")]
        public async Task<IActionResult> BuscaTodasAulas()
        {
            try
            {
                var retorne = await _serafinsRepositorio.ObterTodasAulas();
                return StatusCode(200, retorne);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscaAulaPorId([FromRoute]int Id)
        {
            try
            {
                var retorne = await _serafinsRepositorio.ObterAulaPorId(Id);
                return StatusCode(200, retorne);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("Nova")]
        public async Task<IActionResult> CriarAula([FromBody] Aula newAula)
        {
            try
            {
                Aula _aula = new Aula()
                {
                    Professor = newAula.Professor,
                    Tema = newAula.Tema,
                    ResumoAula = newAula.ResumoAula,
                    DataAula = DateTime.Now.ToString(),
                    Ministracao = "Pendente...",
                    QtdAlunos = "0",
                    QtdBiblias = "0",
                    QtdVisitantes= "0"
                };

                await _serafinsRepositorio.CriarAula(_aula);
                return StatusCode(200, _aula);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut, Route("Editar")]
        public async Task<IActionResult> EditarAula([FromBody] Aula editAula)
        {
            try
            {
                await _serafinsRepositorio.UpdateAula(editAula);
                return StatusCode(200, "Sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion

    }
}
