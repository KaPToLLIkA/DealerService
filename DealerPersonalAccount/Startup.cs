using DealerPersonalAccount.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(DealerPersonalAccount.App_Start.Startup))]

namespace DealerPersonalAccount.App_Start
{
    public partial class Startup
    {
        private IConfigurationRoot ConfigurationRoot { get; set; }

        public void Configuration(IAppBuilder app)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            ConfigureAuth(app);

            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());

            DependencyResolver.SetResolver(resolver);
        }
    }
}
