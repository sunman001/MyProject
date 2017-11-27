using LogManger.EnumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManger.Logger
{
    public class AdministratorLogger : AbstractLogModel,ILogger
    {
        public AdministratorLogger ()
        {

        }
        protected override void SetClient()
        {
            base.userlog.platformId = (int)DxClient.Administrator;
            base.userlog.platformName = DxClient.Administrator.GetDescription();

        }
    }
}
