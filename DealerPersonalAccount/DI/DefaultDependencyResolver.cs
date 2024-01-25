using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DealerPersonalAccount.DI
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        private IServiceProvider _servicesProvider { get; }

        public DefaultDependencyResolver(IServiceProvider servicesProvider)
        {
            _servicesProvider = servicesProvider;
        }

        public object GetService(Type serviceType)
        {
            return _servicesProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _servicesProvider.GetServices(serviceType);
        }
    }
}