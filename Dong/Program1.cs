
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong
{
    class Program
    {
        static void Main(string[] args)
        {
            var dd = new Class1();
          

            //dd.del = new MyDel(dd.add);
            //dd.del += new MyDel(dd.add);
            //dd.del += new MyDel(dd.add);
            //dd.del += new MyDel(dd.add);
            dd.del = (MyDel)Delegate.Combine(new MyDel(dd.add2), new MyDel(dd.add), new MyDel(dd.add2));
            dd.del = (MyDel)Delegate.Remove(dd.del, new MyDel(dd.add2));
            dd.del(3, 4);
            dd.del.Invoke(4, 6);
            Console.Read();
        }
    }
}
