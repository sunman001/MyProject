using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    /// <summary>
    /// 操作系统 n也可能会很多 、品牌m也会很多 版本号个数 L
    /// m*n*L
    ///怎么实现少量的信息 实现此功能
    /// </summary>
    public class LumialAndroid : BasePhone
    {
        public override void Call()
        {
            throw new NotImplementedException();
        }

        public override string System()
        {
            throw new NotImplementedException();
        }

        public override void Text()
        {
            throw new NotImplementedException();
        }

        public override string Version()
        {
            throw new NotImplementedException();
        }
    }
}
