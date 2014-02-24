using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class TypeExtensions
    {

        public static bool HasParameterlessConstructor(this Type type)
        {

            return type.GetConstructor(Type.EmptyTypes) != null;
        
        }

    }
}
