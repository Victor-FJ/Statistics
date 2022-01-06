using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Statistics.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Assembly> GetInheritedAssemblies(this Assembly assembly)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return assemblies
                      .Where(i => i.GetReferencedAssemblies()
                      .Any(a => a.FullName.Equals(assembly.FullName)));
        }
    }
}
