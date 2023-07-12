using Dominio.Configuration;
using Dominio.Entidades;
using Dominio.Entidades.SerafinsHub;
using Dominio.Interfaces.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class SerafinsHubController : MainController
    {
        #region Variaveis

        public AppSettings _appSettings { get; set; }
        public ISerafinsHubRepositorio _serafinsRepositorio { get; set; }

        #endregion

        #region Construtor
        public SerafinsHubController(AppSettings appSettings, ISerafinsHubRepositorio aulaRepositorio)
        {
            _appSettings = appSettings;
            _serafinsRepositorio= aulaRepositorio;
        }

        #endregion

        #region Requisições

        [HttpGet, Route("Todos")]
        public async Task<IActionResult> BuscaTodasPublicacoes()
        {
            try
            {
                var retorne = await _serafinsRepositorio.ObterTodasPublicacoes();
                return StatusCode(200, retorne);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> BuscaPublicacoesPorId([FromRoute]int Id)
        {
            try
            {
                var retorne = await _serafinsRepositorio.ObterPublicacoesPorId(Id);
                return StatusCode(200, retorne);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("Nova")]
        public async Task<IActionResult> CriarPublicacoes([FromBody] Publicacoes newPublicacoes)
        {
            try
            {
                Publicacoes _Publicacoes = new Publicacoes()
                {
                    text = newPublicacoes.text,
                    data = newPublicacoes.data
                };

                await _serafinsRepositorio.CriarPublicacoes(_Publicacoes);
                return StatusCode(200, _Publicacoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut, Route("Editar")]
        public async Task<IActionResult> EditarPublicacoes([FromBody] Publicacoes editPublicacoes)
        {
            try
            {
                await _serafinsRepositorio.UpdatePublicacoes(editPublicacoes);
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
