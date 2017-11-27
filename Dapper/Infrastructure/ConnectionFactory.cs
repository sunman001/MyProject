using System;
using System.Configuration;
using System.Data;
using System.Data.Common;


namespace Dapper.Infrastructure
{
    public  class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                if (conn == null)
                {
                    throw new Exception("数据库连接失败"); 
                }
                conn.ConnectionString = _connectionString;
                return conn;
            }
        }

        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {

            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
