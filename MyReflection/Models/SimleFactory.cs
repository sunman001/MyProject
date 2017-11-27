using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using DB.Interface;

namespace MyReflection.Models
{
    public class SimleFactory
    {
        //封装 
        public static IDBHelper CreateFactory()
        {
            string name = ConfigurationManager.AppSettings["name"];//从配置文件动态获取
            string[] nameArray = name.Split(',');
            Assembly assembly = Assembly.Load(nameArray[1]);//反射的入口 动态的加载dll
            Type dbHelperType = assembly.GetType(nameArray[0]);//基于类的完整名称 找出类型
            object oDBHelper = Activator.CreateInstance(dbHelperType);//根据类型，创建对象 编译器能识别的静态类型是object
            IDBHelper iDbHelper = (IDBHelper) oDBHelper;//强制转换
            return iDbHelper;
        }
    }
}