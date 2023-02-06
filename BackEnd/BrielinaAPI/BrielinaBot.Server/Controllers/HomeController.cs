using Dominio.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class HomeController : Controller
    {
        #region Variaveis

        public AppSettings _appSettings { get; set; }

        #endregion

        #region Construtor
        public HomeController(AppSettings appSettings)
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

        #endregion
    }
}
