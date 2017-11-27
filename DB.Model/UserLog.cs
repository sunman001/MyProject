using DB.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
   public  class UserLog
    {
        [DxColumn(AutoIncrement=true,PrimaryKey=true)]
        public int Id { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 日志类别： 1登录 2 操作 3 错误日志  4 访问日志 
        /// </summary>
        public int LogType { get; set; }

        public string  Ip { get; set; }

        public string Location { get; set; }

        public string Summary { get; set; }
        public string Message { get; set; }

        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 1管理平台 2 开发者平台 3 商务平台 4 代理商平台
        /// </summary>
        public int platformId { get; set; }

        public string platformName { get; set; }
    }
}
