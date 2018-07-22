using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Other
{
    class Program
    {
        private static readonly object root = new object();
        public static int num=0;
        static void Main(string[] args)
        {
            Task t = null;
            for (int i = 0; i < 10000; i++)
            {
                 t = Task.Factory.StartNew(() =>
                {
                    Interlocked.Increment(ref num);
                    //num++;    
                    //lock (root)
                    //{
                    //    num++;
                    //  //  Interlocked.Increment(ref num);
                    //}
                });
            }
            Task.WaitAll(t);
            Console.WriteLine(num);
            Console.Read();
           
        }
    }
}
