using DB.Model;
using LogManger.EnumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManger.Logger
{
    public abstract class AbstractLogModel : ILogger
    {

        public AbstractLogModel()
        {
            userlog = new UserLog();
            Init();
        }
        protected ILogWrite LogWrite = new LogWrite();
       // protected UserLog userlog = new UserLog();
        protected UserLog userlog { get; set; }
        protected void Init()
        {
            SetClient();
        }
        protected  abstract void SetClient();
        public void Logger(LogType Type, string summary, string message)
        {
            userlog.CreateOn = DateTime.Now;
            userlog.LogType =(int )Type;
            userlog.Summary = summary;
            userlog.Message = message;
            LogWrite.write(userlog);

           // throw new NotImplementedException();
        }
    }
}
