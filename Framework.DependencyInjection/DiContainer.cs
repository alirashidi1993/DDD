using Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Framework.DependencyInjection
{
    public class DiContainer : IDiContainer
    {
        private readonly IServiceProvider serviceProvider;

        public DiContainer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public T Resolve<T>()
        {
            return serviceProvider.GetRequiredService<T>(); 
        }
    }
}
