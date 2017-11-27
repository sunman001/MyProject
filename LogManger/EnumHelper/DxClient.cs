using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManger.EnumHelper
{
  public enum  DxClient
    {
        /// <summary>
        /// 运营平台
        /// </summary>
        [Description("运营平台")]
        Administrator = 0,
        /// <summary>
        /// 开发者平台
        /// </summary>
        [Description("开发者平台")]
        Developer = 1,
        /// <summary>
        /// 商务平台
        /// </summary>
        [Description("商务平台")]
        BusinessPersonnel = 2,
        /// <summary>
        /// 代理商平台
        /// </summary>
        [Description("代理商平台")]
        Agent = 3
    }
}
