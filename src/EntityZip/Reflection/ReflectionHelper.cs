using EntityZip.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EntityZip.Reflection
{
    public static class ReflectionHelper
    {
        public static IEnumerable<string> GetHeader<T>(T entity)
        {
            foreach (var prop in GetProperties(entity))
            {
                yield return prop.Name;
            }            
        }

        public static IEnumerable<IEnumerable<string>> GetValues<T>(IEnumerable<T> srcEntities)
        {
            foreach (var item in srcEntities)
            {
                yield return GetValues(item);
            }
        }

        public static IEnumerable<string> GetValues<T> (T entity)
        {
            foreach (var prop in GetProperties(entity))
            {
                yield return prop.GetValue(entity, null)?.ToString() ?? string.Empty;
            }
        }

        public static IEnumerable<PropertyInfo> GetProperties<T>(T entity)
        {
            // You could also create an attribute to return all properties OR even create an IgnoreAttribute an return all except this IgnoreAttribute. 
            return entity.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(ExportProperty), false));            
        }
    }
}
