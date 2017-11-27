using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    /// <summary>
    /// 序列化深克隆
    /// </summary>
  public   class SerializeHelper
    {
        /// <summary>
        /// 序列化成字符串
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Serializable(object target)
        {
            using (MemoryStream stream =new MemoryStream( ))
            {
                new BinaryFormatter().Serialize(stream, target);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        /// <summary>
        /// 反序列化对象 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T Derializble<T>(string  target)
        {
            byte[] targetArray = Convert.FromBase64String(target);
            using (MemoryStream stream =new MemoryStream(targetArray))
            {
               return (T) (new BinaryFormatter().Deserialize(stream));
            }
        }

        public static T DeepClone<T>(T t)
        {
            return Derializble<T>(Serializable(t));
        }
    }
}
