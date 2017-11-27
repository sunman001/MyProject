using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    public static  class RemarExtention
    {
        public static string GetReark(this Enum enumValue)
        {
            //通过反射 获取类型
            var type = enumValue.GetType();
            if(!type.IsEnum)
            {
                throw new ArgumentException("不是可用的枚举类型");
            }
            var memberInfo = type.GetMember(enumValue.ToString());//找到此类型的公共成员
            //如果成员不为空
            if(memberInfo!=null && memberInfo.Length>0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(RemarkAttribute), false);//找到此成员的RemarkAttribute特性
                if (attrs.Length>0)
                {
                    return ((RemarkAttribute)attrs[0]).GetDescription();//找到此特性的GetDescription
                }
            }
            //返回描述
            return enumValue.ToString();
        }

        /// <summary>
        /// 通过泛型获取枚举类型的描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescript<T>(this T value) where T:struct
        {
            Type type = typeof(T);//获取此T的类型
            if(!type.IsEnum)
            {
                throw new ArgumentException("不是可用的枚举类型");
            }
            var memberInfo = type.GetMember(value.ToString());
            if(memberInfo.Length>0)
            {
                var attr = memberInfo[0].GetCustomAttributes(typeof(RemarkAttribute), false);
                if(attr.Length>0)
                {
                    return ((RemarkAttribute)attr[0]).GetDescription();
                }
            }
            return value.ToString();

        }
    }
    //枚举特性类
    public class RemarkAttribute:Attribute
    {
        private string Desription = "";//字段都是私有
        public RemarkAttribute(string desription)
        {
            this.Desription = desription;
        }
        public string GetDescription()
        {
            return this.Desription;
        }
    }
    //枚举类
    public enum UserState
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        [Remark("正常状态")]
        Normal = 0,
        /// <summary>
        /// 冻结状态
        /// </summary>
        [Remark("冻结状态")]
        Frozen = 1,
        /// <summary>
        /// 删除状态
        /// </summary>
        [Remark("删除状态")]
        Delete = 2

    }
}
