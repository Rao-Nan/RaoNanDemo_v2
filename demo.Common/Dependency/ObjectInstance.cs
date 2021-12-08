using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Common.Dependency
{
    public class ObjectInstance<T>where T:class,new()
    {
        public static T Instance { get; } = new T();
    }
}
