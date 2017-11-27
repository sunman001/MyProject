using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOL
{
   public  class AdoClass
    {
        public AdoClass ()
        {

        }

        public void Get()
        {
            DataSet ds = ExecteQuery("select * from CoAgent");
            foreach (DataRow rows in ds.Tables["ds"].Rows)
            {
                Console.WriteLine("{0} from {1}",rows[0],rows[1]);
            }
        }
        private static SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource= "192.168.1.242",
            InitialCatalog= "dx_base",
            UserID= "sa",
            Password= "jm@123456",
        };
        public static int ExecuteSql(string sql)
        {
            using (SqlConnection con =new SqlConnection (connectionStringBuilder.ToString()))
            {
                using (SqlCommand command = new SqlCommand(sql,con))
                {
                    try
                    {
                        con.Open();
                        int rows = command.ExecuteNonQuery();
                        return rows;
                    }
                    catch (Exception e)
                    {
                        con.Close();
                       
                        throw new Exception();
                    }
                    return 0;

                }
            }

        }

        public static  object   GetSingle(string sql)
        {
            using (SqlConnection con=new SqlConnection (connectionStringBuilder.ToString()))
            {
                using (SqlCommand com=new SqlCommand (sql,con))
                {
                    try
                    {
                        con.Open();
                        object resulteObj = com.ExecuteScalar();//取出某一行的某一列
                        if((object.Equals(resulteObj,null)) || (object.Equals(resulteObj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                         return resulteObj;
                        }
                      
                    }
                    catch(Exception e)
                    {
                        throw new Exception(e.Message);
                        con.Close();
                    }
                    return null;
               

                }
            }
        }
        public static object ExecteReader(string sql)
        {
            SqlConnection con=new SqlConnection (connectionStringBuilder.ToString());
            SqlCommand com = new SqlCommand(sql,con );
            try
            {
                con.Open();
                SqlDataReader ReustReader= com.ExecuteReader();
                return ReustReader;
            }
            catch
            {
                con.Close();
            }
            return default(SqlDataReader);
            
        }


        public static DataSet  ExecteQuery(string sql )
        {
            using (SqlConnection con =new SqlConnection (connectionStringBuilder.ToString()))
            {
                try
                {
                 DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
                adapter.Fill(ds,"ds");
                return ds;
                }
                catch(Exception e)
                {
                    con.Close();
                    throw new Exception(e.Message);
                }
               
            }
        }
    }
}
