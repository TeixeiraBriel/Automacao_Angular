using Dominio.Entidades;
using Dominio.Entidades.Security;
using Dominio.Interfaces.Repositorio;
using Host.Configuration.Jwt;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Host.Configuration.JWT
{
    public class AccessManager
    {
        private SigningConfigurations signingConfigurations;
        private TokenConfigurations tokenConfigurations;
        public IConfiguration configuration { get; }
        private readonly ILogger<string> _logger;
        private ISessaoRepositorio _SessaoRepositorio;

        public AccessManager(SigningConfigurations SigningConfigurations,
               TokenConfigurations TokenConfigurations,
               IConfiguration Configuration,
               ILogger<string> logger,
               ISessaoRepositorio SessaoRepositorio)
        {
            signingConfigurations = SigningConfigurations;
            tokenConfigurations = TokenConfigurations;
            configuration = Configuration;
            _logger = logger;
            _SessaoRepositorio = SessaoRepositorio;
        }

        public async Task<bool> ValidateCredentialsPassword(AccessCredentials credenciais)
        {
            try
            {
                _logger.LogInformation($"Iniciando autenticação do usuário: {credenciais.UserID}");
                // Autenticar usuario no Autentica API e atualizar internal id com o código do usuario.
                /*
                var autenticaResposta = await _autenticaAPIService.Autentica(credenciais.UserID, credenciais.Password);

                if (autenticaResposta != null && autenticaResposta.Status == StatusAutenticacaoEnum.Autenticado)
                {
                }
                */
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

            return false;
        }

        public async Task<Sessao> ValidateCredentialsRefreshToken(AccessCredentials credenciais)
        {
            try
            {
                _logger.LogInformation("Processa refresh token...");
                if (!String.IsNullOrWhiteSpace(credenciais.RefreshToken))
                {
                    Sessao refreshTokenBase = await _SessaoRepositorio.ObterSessaoPorRefreshToken(credenciais.RefreshToken);

                    if (refreshTokenBase != null && credenciais.UserID == refreshTokenBase.IdUsuario.ToString() && credenciais.RefreshToken == refreshTokenBase.RefreshToken)
                    {
                        return refreshTokenBase;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

            return null;
        }

        public Token GenerateToken(AccessCredentials credenciais, bool update = false, Sessao sessaoModificar = null)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(credenciais.InternalUserID.ToString(), "id"),
                                                                new[] {
                                                                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                                                                        new Claim(ClaimTypes.Role, credenciais.TipoPerfil.ToString())}
            );

            DateTime dataCriacao = DateTime.UtcNow.AddHours(-3);
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            Dictionary<string, object> claims = new Dictionary<string, object>();
            claims.Add("IdUsuario", new { Value = credenciais.UserID });
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao,
                Claims = claims
            });
            var token = handler.WriteToken(securityToken);

            Token resultado = null;
            resultado = new Token()
            {
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                RefreshToken = Guid.NewGuid().ToString().Replace("-", String.Empty)
            };

            // Armazena o refresh token no banco 
            var refreshTokenData = new RefreshTokenData();
            refreshTokenData.RefreshToken = resultado.RefreshToken;
            refreshTokenData.UserID = credenciais.UserID;

            if (update)
            {
                sessaoModificar.AccessToken = resultado.AccessToken;
                sessaoModificar.DataCriacao = dataCriacao;
                sessaoModificar.DataExpiracao = dataExpiracao;
                sessaoModificar.RefreshToken = refreshTokenData.RefreshToken;
                _SessaoRepositorio.UpdateSessao(sessaoModificar);
            }
            else
            {
                _SessaoRepositorio.CriarSessao(new Sessao
                {
                    AccessToken = resultado.AccessToken,
                    DataCriacao = dataCriacao,
                    DataExpiracao = dataExpiracao,
                    RefreshToken = refreshTokenData.RefreshToken,
                    IdUsuario = refreshTokenData.UserID
                });
            }

            return resultado;
        }
    }
}
