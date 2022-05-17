using Framework.Core.AssemblyHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Framework.AssemblyHelper
{
    public class AssemblyDiscovery : IAssemblyDiscovery
    {
        private static List<Assembly> _loadedAssemblies;
        private readonly string _assemblySearchPattern;
        public AssemblyDiscovery(string assemblySearchPattern)
        {
            _assemblySearchPattern = assemblySearchPattern;

            LoadAssembliesOfAppRootFolder(assemblySearchPattern);
        }

        private static void LoadAssembliesOfAppRootFolder(string assemblySearchPattern)
        {
            if (_loadedAssemblies == null)
            {
                var directory = AppDomain.CurrentDomain.BaseDirectory;
                _loadedAssemblies = Directory.GetFiles(directory, assemblySearchPattern)
                    .Select(Assembly.LoadFrom)
                    .ToList();

            }
        }

        public IEnumerable<T> DiscoverInstances<T>(string searchNamespace)
        {
            var res = _loadedAssemblies.Where(i => i.FullName.StartsWith(searchNamespace))
                .SelectMany(i => i.GetTypes())
                .Where(i => i.IsClass && !i.IsAbstract)
                .Where(i => i.GetInterface(typeof(T).Name) != null)
                .Select(Activator.CreateInstance)
                .OfType<T>();
            return res;
        }

        public IEnumerable<Type> DiscoverTypes<TInterface>(string searchNamespace)
        {
            var res = _loadedAssemblies
                .Where(i => i.FullName.StartsWith(searchNamespace))
                .SelectMany(i => i.GetTypes())
                .Where(i => i.IsClass && !i.IsAbstract)
                .Where(i => i.GetInterface(typeof(TInterface).Name) != null)
                .Select(i => i);
            return res;
        }
    }
}
