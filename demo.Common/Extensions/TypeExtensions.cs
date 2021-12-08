using demo.Common.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsInherit(this Type self, Type target) {
            return target.IsAssignableFrom(self);
        }

        public static bool IsInherit<TTarget>(this Type self)
        {
            return typeof(TTarget).IsAssignableFrom(self);
        }

        public static IEnumerable<Type> GetRegisterTypes(this Type self)
        {
            var list = new List<Type>();
            list.Add(self);
            list.AddRange(self.GetInterfaces().Where(x => !x.IsInherit<IDependency>()));
            return list;
        }
    }
}
