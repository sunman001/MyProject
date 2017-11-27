using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManger.EnumHelper
{
  public static   class EnumExtensions
    {
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <typeparam name="T">泛型枚举</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T:struct
        {
            //获取类型
            // var type = typeof(T);//根据泛型获取类型
            var type = value.GetType();//根据枚举值或者类型
            //判断是否是枚举
            if(!type.IsEnum)
            {
                throw new ArgumentException("不是可用的枚举类型");
            }
            //根据枚举的值获取枚举的成员
            var memberInfo = type.GetMember(value.ToString());
            if(memberInfo.Length>0)
            {
                //获取枚举的特性信息
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);    
                if(attrs.Length>0)
                {
                    //获取枚举的特性描述信息
                    return ((DescriptionAttribute)attrs[0]).Description;     
                }            
            }
            return value.ToString();
            
        }
    }
}
