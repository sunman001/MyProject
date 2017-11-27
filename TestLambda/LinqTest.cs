using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TestLambda
{
    public class LinqTest
    {
        public void Methods()
        {

            var intlist = new List<int>() { 1, 2, 3, 4, 6, 77, 88, 99, 908, 9999, 777, 444 };
            var list = intlist.Where(x => x > 100);
            var list1 = Enumerable.Where(intlist, (x => x > 100));

            var listResut = new List<int>();
            foreach (var lst in intlist)
            {

                if (lst>100)
                {
                    listResut.Add(lst);  
                }
              
            }
            var list2 = EnumerableEleven.ElevenWhere(intlist, x => x > 100);

        }

        public static class EnumerableEleven
        {
            public static IEnumerable<TSource> ElevenWhere<TSource>(IEnumerable<TSource> source,  Func<TSource, bool> predicate)
            {
                List<TSource> resultList = new List<TSource>();
                foreach (var item in source)
                {
                    if (predicate.Invoke(item))
                    {
                        resultList.Add(item);
                    }
                }
                return resultList;

            }
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        public  void Sort()
        {

            int[] arr = new int[] {9,6,4,5,2,6 };
            ArrayList arraylist = new ArrayList();
            int temp = 0;
            for (int i=0;i<arr.Length-1;i++)
            {
                for (int j=i+1;j<arr.Length;j++ )
                {
                    if (arr[i]>arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                       
                    }
                }
              
            }
            Console.WriteLine(arr);
        }






    }
}
