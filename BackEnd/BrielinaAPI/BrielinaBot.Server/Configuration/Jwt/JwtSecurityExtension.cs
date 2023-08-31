using Dominio.Entidades.Security;
using Host.Configuration.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Host.Configuration.JWT
{
    public static class JwtSecurityExtension
    {
        public static IServiceCollection AddJwtSecurity(this IServiceCollection services, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.FromMinutes(5);

                // Evento para validar o token full state do tipo operador
                bearerOptions.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = context =>
                    {
                        var accessToken = context.SecurityToken as JwtSecurityToken;
                        if (accessToken != null)
                        {
                            ClaimsIdentity? identity = context.Principal.Identity as ClaimsIdentity;
                            if (identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == (1).ToString()) //Id do tipo do usuário
                            {
                                //var sessaoService = services.BuildServiceProvider().GetService<ISessaoService>();

                                //O Agente em Casa não tem tabela de sessão.
                                //var dataAtualizacao = sessaoService.ObterUltimaSessao(Convert.ToInt32(identity.Name));
                                //if (dataAtualizacao != null && DatetimeExtension.GetBrasilianDatetime().Subtract((DateTime)dataAtualizacao).TotalMinutes > 10)
                                //{
                                //    context.NoResult();
                                //    context.Response.StatusCode = 403;
                                //    context.Response.ContentType = "text/plain";
                                //    context.Response.WriteAsync("").Wait();
                                //    return Task.CompletedTask;
                                //}
                            }
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            // Ativa o uso do token como forma de autorizar o acesso a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            return services;
        }
    }
}
