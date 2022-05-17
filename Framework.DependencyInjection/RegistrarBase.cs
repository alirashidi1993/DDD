using Framework.ApplicationService;
using Framework.AssemblyHelper;
using Framework.Core.ApplicationService;
using Framework.Core.AssemblyHelper;
using Framework.Core.DependencyInjection;
using Framework.Core.Domain;
using Framework.Core.Facade;
using Framework.Core.Persistence;
using HR.EmployeeContext.Domain.Employees.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Framework.DependencyInjection
{
    public abstract class RegistrarBase<TRegistrar> : IRegistrar
    {
        private IServiceCollection _services;
        private IAssemblyDiscovery _assemblyDiscovery;
        private readonly string _namespace;
        public RegistrarBase()
        {
            _namespace =
                typeof(TRegistrar).Namespace?.Split('.')?[0] + "."
              + typeof(TRegistrar).Namespace?.Split('.')?[1];
        }
        public void Register(IServiceCollection services, IAssemblyDiscovery assemblyDiscovery)
        {

            _services = services;
            _assemblyDiscovery = assemblyDiscovery;

            RegisterFramework();
            RegisterTransient<IEntityMapping>();
            RegisterTransient<IRepository>();
            RegisterTransient<ICommandFacade>();
            RegisterTransient<IDomainService>();
            RegisterTransient<IHandler>();

        }

        private void RegisterTransient<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces().Last();
                _services.AddTransient(baseInterface, type);
            }

        }

        private void RegisterFramework()
        {
            _services.AddScoped<IAssemblyDiscovery, AssemblyDiscovery>(imp => new AssemblyDiscovery("HR*.dll"));
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            _services.AddScoped<IDiContainer, DiContainer>();
            _services.AddScoped<ICommandBus, CommandBus>();
        }
    }
}
