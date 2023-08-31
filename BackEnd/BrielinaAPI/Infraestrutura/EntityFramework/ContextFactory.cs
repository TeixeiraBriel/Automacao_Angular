using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.EntityFramework
{
    public class ContextFactory
    {
        public static SerafinsHubContext SerafinsHubOpenContext( IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SerafinsHubContext>();
            optionsBuilder
                .EnableSensitiveDataLogging()
                .EnableServiceProviderCaching();

            return new SerafinsHubContext(optionsBuilder.Options, configuration);
        }

        public static AulasContext AulasOpenContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AulasContext>();
            optionsBuilder
                .EnableSensitiveDataLogging()
                .EnableServiceProviderCaching();

            return new AulasContext(optionsBuilder.Options, configuration);
        }

        public static Context OpenContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder
                .EnableSensitiveDataLogging()
                .EnableServiceProviderCaching();

            return new Context(optionsBuilder.Options, configuration);
        }
    }
}
