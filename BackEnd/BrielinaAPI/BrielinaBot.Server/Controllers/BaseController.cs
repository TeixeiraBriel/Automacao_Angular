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

        #endregion
    }
}
