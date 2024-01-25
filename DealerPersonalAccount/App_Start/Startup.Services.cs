using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Extensions.Configuration;
using DealerPersonalAccount.Models.App;

[assembly: OwinStartup(typeof(DealerPersonalAccount.App_Start.Startup))]

namespace DealerPersonalAccount.App_Start
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();

            builder
                .AddJsonFile("Configuration\\appsettings.json", optional: false, reloadOnChange: true);

            ConfigurationRoot = builder.Build();

            services.AddOptions();
            services.Configure<AppSettings>(ConfigurationRoot.GetSection(nameof(AppSettings)));
        }
    }
}
