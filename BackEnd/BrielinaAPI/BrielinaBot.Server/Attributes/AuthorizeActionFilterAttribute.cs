namespace Host.Attributes
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.IdentityModel.Tokens;

    public class AuthorizeActionFilterAttribute : IAuthorizationFilter
    {
        public AuthorizeActionFilterAttribute()
        {
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthorized = false;
            var isAuthenticated = false;

            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.HttpContext.Request.Headers["Authorization"][0];
                if (ValidaToken(token))
                {
                    isAuthenticated = true;
                    isAuthorized = true;
                }
            }

            if (!isAuthenticated)
            {
                context.Result = new UnauthorizedResult();
            }
            else if (!isAuthorized)
            {
                context.Result = new ForbidResult();
            }
        }

        public static int RetornaIdDoUsuario(string token)
        {
            try
            {
                var stream = token.Split(" ").LastOrDefault();
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
                var unique_name = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
                return Convert.ToInt32(unique_name ?? "0");
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int ObterId(AuthorizationFilterContext context)
        {
            int id = 0;
            if (context.HttpContext.User.Identity.Name == null)
                id = AuthorizeActionFilterAttribute.RetornaIdDoUsuario(context.HttpContext.Request.Headers.FirstOrDefault(h => h.Key.Equals("Authorization")).Value.ToString());
            else
                id = Convert.ToInt32(context.HttpContext.User.Identity.Name);
            return id;
        }

        private bool ValidaToken(string authorization)
        {
            var token = authorization.Split(" ").LastOrDefault();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) =>
                    {
                        if (notBefore != null && expires != null)
                        {
                            return DateTime.UtcNow.AddHours(-3) > notBefore.Value.ToUniversalTime()
                                && DateTime.UtcNow.AddHours(-3) < expires.Value.ToUniversalTime();
                        }

                        return false;
                    },
                    ValidateIssuerSigningKey = false,
                    SignatureValidator = (string token, TokenValidationParameters parameters) =>
                    {
                        return new JwtSecurityToken(token);
                    },
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

