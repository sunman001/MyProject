

using BridgePattern.BridgePattern;

namespace BridgePattern
{
    /// <summary>
    /// 抽象父类
    /// 结构型设计模式 描述 类与类之间的关系 继承 和组合的方式
    /// 变化封装
    /// 把抽象方法变为属性 底层不固定什么系统和版本号交给上方
    /// </summary>
    public abstract class BasePhoneBridge
    {
        public int Price { get; set; }

        public Isystem System { get; set; }

        public Iversion Version { get; set; }


        ///// <summary>
        ///// 操作系统
        ///// </summary>
        ///// <returns></returns>
        //public abstract string System();

        ///// <summary>
        ///// 系统版本
        ///// </summary>
        ///// <returns></returns>
        //public abstract string Version();

        /// <summary>
        /// 打电话
        /// </summary>
        public abstract void Call();
        /// <summary>
        /// 发短信
        /// </summary>
        public abstract void Text();


    }
}
