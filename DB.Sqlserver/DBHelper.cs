using DB.Interface;
using MyAttribute;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Sqlserver
{
    public class DBHelper : IDBHelper
    {
        private static string ConnectionStringDB = ConfigurationManager.AppSettings["ConnectionString"];

        public T FindBy<T>(int id)
        {
            Type type = typeof(T);
           // string columns = string.Join(",", type.GetProperties().Select(p => string.Format("[{0}]",p.Name)));//获取所有的属性依逗号隔开
            string columns = string.Join(",", type.GetProperties().Select(p=>$"[{p.Name}]"));
            T obj =(T)Activator.CreateInstance(type);//创建对象
            //var tType = obj.GetType();//获取当前实列的类型
            var PrimaryKey = AttributeExtention.GetPirkey<T>();//用特性和反射的方法获取主键
            string sql =string.Format("SELECT {0} FROM {1} WHERE {3}={2}",columns,type.Name,id,PrimaryKey);
            using (SqlConnection conn=new SqlConnection (ConnectionStringDB))
            {
                SqlCommand command = new SqlCommand(sql,conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if(reader.Read())
                {
                    foreach (var prop in type.GetProperties())//循环所有的属性
                    {

                        var propertyInfo = type.GetProperty(prop.Name);//获取指定名称的公共属性
                        var rowValue = reader[prop.Name];//获取当前属性的值
                        if (propertyInfo == null) continue;//如果公共属性信息为空跳出
                        var t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;//获取此属性的类型
                        var safeValue = (rowValue == null || DBNull.Value.Equals(rowValue) ? null : Convert.ChangeType(rowValue, t));//如果此属性不为空转换此属性的类型
                         propertyInfo.SetValue(obj,safeValue,null);//赋值
                       //  prop.SetValue(t,reader[prop.Name]);//通过反射循环属性赋值
                      
                        
                    }
                    return obj;
                }
            }
                return default(T);
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);

        }

        public void Query(string name)
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);

        }

        public void Query(int id)
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }

        public void Query(int id, string name)
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }

        public void  Query1(int id)
        {
            Console.WriteLine("这里是{0}的Query1", this.GetType().FullName);
        }
    }
}
