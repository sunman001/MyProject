using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
   public  class ColumnAttribute:Attribute
    {
        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool PrimaryKey { get; set; }
        /// <summary>
        /// 是否为自增
        /// </summary>
        public bool AutoIncrement { get; set; }

        /// <summary>
        /// 是否为自增
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }

         /// <summary>
         /// 字段描述
         /// </summary>
        public string Description { get; set; }

    }
}
