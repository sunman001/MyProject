

using System.Configuration;

namespace TOOL
{
   public  class PubConstant
    {
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string ConStringEncryt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if(ConStringEncryt=="true")
                {
                   _connectionString= DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
    }
}
