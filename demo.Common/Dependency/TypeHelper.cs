using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace demo.Common.Dependency
{
    public class TypeHelper:ObjectInstance<TypeHelper>
    {
        public AssemblyHelper AssemblyHelper { get; }
        public IEnumerable<TypeInfo> DefinedTypes { get; }

        public TypeHelper() {
            AssemblyHelper = AssemblyHelper.Instance;
            DefinedTypes=AssemblyHelper.Assemblies.SelectMany(x => x.DefinedTypes);
        }
        public IEnumerable<Type> FindInheritTypes(Type type) {
            return DefinedTypes.Where(x => type.IsAssignableFrom(x)).Where(x=>x!=type);
        }
        public IEnumerable<Type> FindInheritTypes<T>()
        {
            return FindInheritTypes(typeof(T));
        }
        public IEnumerable<Type> FindInheritTypes<T>(Func<Type, bool> predicate)
        {
            return FindInheritTypes(typeof(T)).Where(predicate);
        }
    }
}
