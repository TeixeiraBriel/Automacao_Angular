using Microsoft.Extensions.DependencyInjection;

namespace InjecaoDependecia
{
    public class Bootstrapper
    {
        IServiceCollection _services;
        public Bootstrapper(IServiceCollection services)
        {
            _services = services;
        }
    }
}