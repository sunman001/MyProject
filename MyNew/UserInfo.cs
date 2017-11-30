using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNew
{
   public  class UserInfo
   {
       private int age = -1;
       private char level = 'A';
   }

    public class User
    {
        private int Id;
        private UserInfo user;
    }

    public class VipUser : User
    {
        public bool IsVip;

        public bool IsVipUser()
        {
            return IsVip;
        }
    }

    public class GetUser
    {

        public void GetUserInfo()
        {
            //将声明一个引用类型变量aUser
            VipUser auser;//它仅是一个引用指针，保存在线程的堆栈上，占用4Byte 的内存空间，将用于保存VIPUser对象的有效地址，此时aUser未指向任何有限的实列，因此被自行初始化Null,师徒对aUser的任何操作将抛出NullReferenceException异常
            //通过New操作执行对象创建
            auser = new VipUser();//执行newobj指令
            auser.IsVip = true;

        }
    }
}
