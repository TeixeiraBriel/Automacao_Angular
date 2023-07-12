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
        public static SerafinsHudContext SerafinsHudOpenContext( IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SerafinsHudContext>();
            optionsBuilder
                .EnableSensitiveDataLogging()
                .EnableServiceProviderCaching();

            return new SerafinsHudContext(optionsBuilder.Options, configuration);
        }

        public static AulasContext AulasOpenContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AulasContext>();
            optionsBuilder
                .EnableSensitiveDataLogging()
                .EnableServiceProviderCaching();

            return new AulasContext(optionsBuilder.Options, configuration);
        }
    }
}
