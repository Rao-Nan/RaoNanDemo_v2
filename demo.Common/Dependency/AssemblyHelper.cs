using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace demo.Common.Dependency
{
    public class AssemblyHelper:ObjectInstance<AssemblyHelper>
    {
        public Assembly MainAssembly { get; }
        public string MainAssemblyName => MainAssembly.GetName().Name;
        public Assembly[] Assemblies { get; }

        public AssemblyHelper() {
            MainAssembly=Assembly.GetEntryAssembly();
            Assemblies=AppDomain.CurrentDomain.GetAssemblies();
            Assemblies=DependencyContext.Default.RuntimeLibraries.Where(x=>string.IsNullOrWhiteSpace(x.Path)&&!x.Serviceable).Select(o => Assembly.Load(new AssemblyName(o.Name))).ToArray();
        }
    }
}
