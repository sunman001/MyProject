using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOL
{
  public static  class IEnumerableExtensions
    {
       /// <summary>
       /// IEnumerable 集合转换为DataTable
       /// </summary>
       /// <typeparam name="T">泛型T</typeparam>
       /// <param name="data">集合</param>
       /// <returns></returns>
     public static DataTable AsDataTable<T>(this IEnumerable<T> data)
        {

            //var type = typeof(T);
            // var table = new DataTable();
            //foreach (var prop in type.GetProperties())
            //{
            //    table.Columns.Add(prop.Name,Nullable.GetUnderlyingType(prop.PropertyType)??prop.PropertyType);
            //}
            //foreach (T item in data)
            //{
            //    DataRow row = table.NewRow();
            //    foreach (var prop in type.GetProperties())
            //    {
            //        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            //    }
            //    table.Rows.Add(row);
            //}
            //return table;
            //得到集合属性
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            //获得Table的属性
            foreach (PropertyDescriptor prop in properties)
            {

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            //赋值
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }
            return table;
        }
    }
}
