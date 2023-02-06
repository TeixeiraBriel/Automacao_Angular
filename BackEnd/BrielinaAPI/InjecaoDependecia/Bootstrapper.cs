using Dominio.Configuration;
using InjecaoDependecia.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InjecaoDependecia
{
    public class Bootstrapper
    {
        public Bootstrapper(IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfiguration<AppSettings>(configuration);

            //services.AddScoped<Iteste, Teste>();
        }
    }
}