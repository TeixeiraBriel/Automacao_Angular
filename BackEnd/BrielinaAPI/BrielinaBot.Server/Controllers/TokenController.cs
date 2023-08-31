using Dominio.Entidades;
using Dominio.Entidades.Security;
using Host.Configuration.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    public class TokenController : MainController
    {
        [AllowAnonymous]
        [HttpPost, Route("")]
        public async Task<object> Post([FromBody] AccessCredentials credenciais, [FromServices] AccessManager accessManager)
        {
            if (credenciais != null && !String.IsNullOrWhiteSpace(credenciais.UserID))
            {
                if (credenciais.GrantType == "password")
                {
                    if (await accessManager.ValidateCredentialsPassword(credenciais))
                        return accessManager.GenerateToken(credenciais);

                }
                else if (credenciais.GrantType == "refresh_token")
                {
                    Sessao sessaoModificar = await accessManager.ValidateCredentialsRefreshToken(credenciais);
                    if (sessaoModificar != null)
                        return accessManager.GenerateToken(credenciais, true, sessaoModificar);
                }
            }

            return Unauthorized("Usuário não autenticado");
        }
    }
}
