using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using TOOL;

namespace LogManger
{
    public class LogWrite : ILogWrite
    {
        //public void write(UserLog userlog)
        //{
        //    //写添加方法
        //    throw new NotImplementedException();
        //}

        public void write<T>(T userlog) where T : class
        {
            //泛型方法实现添加
            GenericRepository.Insert(userlog);
        }
    }
}
