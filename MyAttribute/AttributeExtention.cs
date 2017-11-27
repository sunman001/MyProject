using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    public class AttributeExtention
    {
        public static string GetPirkey<T>()
        {
            Type type = typeof(T);
            var props = type.GetProperties();
            var primarykey = "";
            if (props.Length > 0 && props != null)
            {
                foreach (var prop in props)
                {
                    var attr = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), false);
                    if (attr == null && !attr.PrimaryKey)
                        continue;
                    primarykey = prop.Name;
                    return primarykey;
                }
            }
            return primarykey;
        }
    }
}
