using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Statistics.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsClassAssignableFrom<T>(this Type type)
        {
            return type.IsClass && !type.IsAbstract && typeof(T).IsAssignableFrom(type);
        }

        public static T GetUninitializedObject<T>(this Type type)
        {
            return (T)FormatterServices.GetUninitializedObject(type);
        }
    }
}
