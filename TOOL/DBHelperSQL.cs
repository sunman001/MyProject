using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TOOL
{
    public class DBHelperSQL
    {
        public static string connectionString = PubConstant.ConnectionString;
        public DBHelperSQL ()
        {

        }
        /// <summary>
        /// 批量导入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">表名</param>
        /// <param name="list">list集合</param>
        /// <param name="batchSize">每一批导入的最大行数</param>
        /// <returns></returns>
        public static int BulkInsert<T>(string tableName,IEnumerable<T> list,int batchSize=5000)
        {
            using (var connection =new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var tran = connection.BeginTransaction();
                    using (var bulkCopy=new SqlBulkCopy(connection,SqlBulkCopyOptions.Default,tran))
                    {
                        bulkCopy.BatchSize = batchSize;
                        bulkCopy.DestinationTableName = tableName;
                        try
                        {
                            bulkCopy.WriteToServer(list.AsDataTable());
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            connection.Close();
                            throw  ex;
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return 1;
        }

        public static object GetSingle(string SQLString,params SqlParameter[]cmdParms)
        {
            using (SqlConnection connection=new SqlConnection (connectionString))
            {
                
                    using (SqlCommand cmd=new SqlCommand ())
                    {

                    try
                    {
                        PrepareCommand(cmd,connection,null,SQLString ,cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if(Object.Equals(obj,null)||(Object.Equals(obj,System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    }
                
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        /// <summary>
        /// 数据库调用处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="fuc">func也是一种委托 可以传入方法（sqlcommand的执行方法）</param>
        /// <returns></returns>
        public static T Execute<T>(string sql,Func<SqlCommand ,T> fuc)
        {
            using (var connection=new SqlConnection (connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql,connection);
                //SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    command.Transaction = connection.BeginTransaction();
                    T t = fuc(command);
                    command.Transaction.Commit();
                    return t;
                }
                catch(Exception ex)
                {
                    command.Transaction.Rollback();
                    throw ex;
                }
            }
           
        }
         /// <summary>
         /// Command方法
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="command"></param>
         /// <returns></returns>
        public T Command<T> (SqlCommand command) where T:new()
        {
            var t = new T();
            return t;
        }


        /// <summary>
        /// 添加数据 并调用《数据库调用处理》
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int insert(string sql) 
        {
            var result = Execute(sql, Command =>
             {
                 var obj = Command.ExecuteNonQuery();
                 return Convert.ToInt32(obj);
             });
            return result;
        }
      
    }
}
