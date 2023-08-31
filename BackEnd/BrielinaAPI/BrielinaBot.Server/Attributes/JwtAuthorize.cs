using Microsoft.AspNetCore.Mvc;

namespace Host.Attributes
{
    public class JwtAuthorize : TypeFilterAttribute
    {
        public JwtAuthorize() : base(typeof(AuthorizeActionFilterAttribute))
        {
        }
    }
}
