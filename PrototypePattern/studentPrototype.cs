using System;
using System.Threading;


namespace PrototypePattern
{
    /// <summary>
    /// 原型模式（通过内存的copy 创建不同的对象,但只调用一次构造函数）
    /// </summary>
    [Serializable]
    public class StudentPrototype
    {
        private StudentPrototype()
        {
            Thread.Sleep(2000);
            long lResult = 0;
            for (int i = 0; i < 100000; i++)
            {
                lResult += i;
            }
            Console.WriteLine("{0}被构造", this.GetType().Name);

        }

        private static StudentPrototype _studentPrototype = null;

        static StudentPrototype()
        {
            _studentPrototype = new StudentPrototype()
            {
                Id = 1,
                Name = "test",
                Class = new Class()
                {
                    ClassId = 1,
                    ClassName = "高级班"
                }
            };
        }

        public static StudentPrototype CreateTance()
        {
            StudentPrototype student = (StudentPrototype)_studentPrototype.MemberwiseClone();//克隆一个全新的对象返回出去
            //student.Class = new Class()//克隆之后再实列化一下Class《深克隆》
            //{
            //    ClassId = 1,
            //    ClassName = "高级班"
            //};
            return student;
        }

        /// <summary>
        /// 序列化和反序列化克隆
        /// </summary>
        /// <returns></returns>
        public static StudentPrototype CreateInstanceSerialize()
        {
           return SerializeHelper.DeepClone<StudentPrototype>(_studentPrototype);
        }

        public int Id { get; set; }
        public string Name { get; set; }//string  是引用类型 
        public Class Class { get; set; }



    }
    [Serializable]
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
