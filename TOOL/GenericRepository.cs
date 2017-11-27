using DB.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TOOL
{
    /// <summary>
    /// 泛型获取类的属性并实现添加方法
    /// </summary>
    public static class GenericRepository
    {

        /// <summary>
        /// 获取此泛型对象的属性（约束：必须是public）
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertyInfos(this Type t)
        {
            if (t == null)
            {
                throw new NullReferenceException("泛型对象为空");
            }
            return t.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
        }

        /// <summary>
        /// 获取自增字段
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetIncrementColumnName(this Type type)
        {
            var props = type.GetPropertyInfos();
            var columnName = "";
            foreach (var prop in props)
            {
                var attr = (DxColumnAttribute)prop.GetCustomAttribute(typeof(DxColumnAttribute), false);
                if (attr == null || !attr.AutoIncrement)
                    continue;
                columnName = prop.Name;
                break;
            }
            return columnName;
        }

        /// <summary>
        /// 泛型方法实现插入语句
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GenerateInsertSqlString(this Type type)
        {
            if (type != null)
            {
                throw new NullReferenceException("泛型实体不能为空！");
            }
            var atuoIncrementColumnName = type.GetIncrementColumnName();
            var props = type.GetMappedPropertyNameList().Where(x => x != atuoIncrementColumnName).ToList();
            if (props == null || props.Count <= 0)
            {
                throw new ArgumentNullException(string.Format("对象[{0}]没有可用的映射属性", type.Name));
            }
            var insert = string.Format(" INSERT INTO {0} ({1}) VALUES ({2});SELECT @@IDENTITY", type.Name, string.Join(",", props), string.Join(",", props.Select(x => "@" + x)));
            return insert;

        }
        /// <summary>
        /// 获取要添加的属性
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<string> GetMappedPropertyNameList(this Type t)
        {
            if (t == null)
            {
                throw new NullReferenceException();
            }
            var props = t.GetPropertyInfos();
            var list = (from prop in props let attr = (DxColumnAttribute)prop.GetCustomAttribute(typeof(DxColumnAttribute), false) where attr == null || !attr.Ignore select prop.Name).ToList();
            return list;
        }

        public static int Insert<T>(T entity)
        {
            var type = typeof(T);
            var sql = type.GenerateInsertSqlString();
            var obj = DBHelperSQL.GetSingle(sql,AdoUtil.GetParameters(entity) );
            return obj == null ? 0 : Convert.ToInt32(obj);
        }
       
      

    }
}
