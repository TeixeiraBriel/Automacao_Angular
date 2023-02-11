using Dominio.Configuration;
using Dominio.Interfaces.Executor;
using Infraestrutura.Executor;
using InjecaoDependecia.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InjecaoDependecia
{
    public class Bootstrapper
    {
        public Bootstrapper(IServiceCollection services, IConfiguration configuration)
        {
            //Entity
            services.AddConfiguration<AppSettings>(configuration);

            //Services
            services.AddScoped<ILogger<string>, Logger<string>>();
            services.AddScoped<IExecutor, Executor>();

            //Repositories
        }
    }
}