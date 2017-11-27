using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Dapper.Infrastructure
{
    /// <summary>
    /// 连接字符串工厂
    /// </summary>
   public  interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
