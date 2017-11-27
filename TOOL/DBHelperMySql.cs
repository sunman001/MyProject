using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOL
{
   public  class DBHelperMySql
    {
        public static string connectionString = PubConstant.ConnectionString;
        public DBHelperMySql()
        {

        }
        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="BatchSize"></param>
        public static void BatchUpdate<T>(IEnumerable<T> list,int BatchSize=5000)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandTimeout = 30;
            command.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            MySqlCommandBuilder commandBulider = new MySqlCommandBuilder(adapter);
            commandBulider.ConflictOption = ConflictOption.OverwriteChanges;
            MySqlTransaction tran = null;
            try
            {
                connection.Open();
                tran = connection.BeginTransaction();
                adapter.UpdateBatchSize = BatchSize;
                adapter.SelectCommand.Transaction = tran;
                if(list.AsDataTable().ExtendedProperties["SQL"]!=null)
                {
                    adapter.SelectCommand.CommandText = list.AsDataTable().ExtendedProperties["SQL"].ToString();
                }
                adapter.Update(list.AsDataTable());
                tran.Commit();


            }
            catch(MySqlException ex)
            {
                if (tran != null) tran.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

        }
        /// <summary>
        /// 批量导入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">表名</param>
        /// <param name="list">list集合</param>
        /// <param name="batchSize">每一批导入的最大行数</param>
        /// <returns></returns>
        public static int BulkInsert<T>(string tableName, IEnumerable<T> list)
        {
            string tmpPath = Path.GetTempFileName();
            string scv = DataTableToCsv(list.AsDataTable());
            File.WriteAllText(tmpPath,scv);
            int insertCount = 0;
            using (MySqlConnection con=new MySqlConnection (connectionString))
            {
                MySqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    MySqlBulkLoader bulk = new MySqlBulkLoader(con)
                    {
                        FieldTerminator = ",",
                        FieldQuotationCharacter = '"',
                        EscapeCharacter = '"',
                        LineTerminator = "\r\n",
                        FileName = tmpPath,
                        NumberOfLinesToSkip = 0,
                        TableName = tableName
                    };
                    bulk.Columns.AddRange(list.AsDataTable().Columns.Cast<DataColumn>().Select(colum=>colum.ColumnName).ToList());
                    insertCount = bulk.Load();
                    tran.Commit();
                }
                catch(MySqlException ex)
                {
                    if(tran!=null)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
            }
            File.Delete(tmpPath);
            return insertCount;

        }
        /// <summary>
        ///将DataTable转换为标准的CSV
        /// </summary>
        /// <param name="table">数据表</param>
        /// <returns>返回标准的CSV</returns>
        private static string DataTableToCsv(DataTable table)
        {
            //以半角逗号（即,）作分隔符，列为空也要表达其存在。
            //列内容如存在半角逗号（即,）则用半角引号（即""）将该字段值包含起来。
            //列内容如存在半角引号（即"）则应替换成半角双引号（""）转义，并用半角引号（即""）将该字段值包含起来。
            StringBuilder sb = new StringBuilder();
            DataColumn colum;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    colum = table.Columns[i];
                    if (i != 0) sb.Append(",");
                    if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                    {
                        sb.Append("\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                    }
                    else sb.Append(row[colum].ToString());
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
