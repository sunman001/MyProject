using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SimpleFactory
{
    /// <summary>
    /// 简单工厂
    /// 缺点 代码增加、修改的时候还要修改工厂,工厂内不稳定
    /// 严重违背单一职责
    /// </summary>
  public   class Factory
    {
        public static IRace CreateFactory(RaceType raceType)
        {
          switch (raceType)
            {
                case RaceType.Human:
                    return new Human();
                case RaceType.Orc:
                    return new Orc();
                default:
                    throw new Exception("now thow");
            }

        }
        //web.cong中获取
        private static string RaceTypeConfig = ConfigurationManager.AppSettings["RaceTypeConfig"];
        public static IRace CreateFactoryConfig()
        {
         switch (  (RaceType)Enum.Parse(typeof(RaceType),RaceTypeConfig))
            {
                case RaceType.Human:
                    return new Human();
                case RaceType.Orc:
                    return new Orc();
                default:
                    throw new Exception("now thow");
            }
        }
        private static string RaceTypeReflect = ConfigurationManager.AppSettings["RaceTypeReflect"];
        //反射获取
        public static IRace CreateInstance()
        {
            string assemblyName = RaceTypeReflect.Split(',')[0];
            string type = RaceTypeReflect.Split(',')[1];
            return (IRace)Activator.CreateInstance(assemblyName, type).Unwrap();

        }

       public enum RaceType
        {
            Human,
            Orc,
            Umdead,
            Ne
        }
    }
}
