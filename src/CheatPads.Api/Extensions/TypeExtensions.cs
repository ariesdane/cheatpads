using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;

namespace CheatPads.Api
{
    public static class TypeExtensions
    {      
        public static bool Implements<TInterface>(this Type type)
        {
            return type.GetInterfaces().Any(t => t == typeof(TInterface));
        }

        public static T Clone<T>(this T item)
        {
            var literal = JsonConvert.SerializeObject(item);
            return JsonConvert.DeserializeObject<T>(literal);
        }

        public static IDictionary<string, object> ToDictionary(this object instance)
        {
            var bindings = BindingFlags.Public | BindingFlags.Instance;
            var dict = new Dictionary<string, object>();
            foreach (var property in instance.GetType().GetProperties(bindings))
            {
                if (property.CanRead)
                {
                    dict.Add(property.Name, property.GetValue(instance, null));
                }
            }
            return dict;
        }

        public static T SetValues<T>(this T item, object from)
        {
            var bindings = BindingFlags.Public | BindingFlags.Instance;
            var properties = item.GetType().GetProperties(bindings);

            foreach (var sourceProperty in from.GetType().GetProperties(bindings))
            {
                var targetProperty = properties.FirstOrDefault(x => 
                    x.Name == sourceProperty.Name && x.CanWrite == true && sourceProperty.CanRead == true
                );
                targetProperty?.SetValue(item, sourceProperty.GetValue(from, null));
            }
            return item;
        }

    }


}