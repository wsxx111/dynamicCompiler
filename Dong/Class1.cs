using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong
{
    public delegate void MyDel(int ss, int dd);
    class Class1
    {
        public MyDel del;

        public void add(int ss, int ff)
        {
            Console.WriteLine("sdds");
        }

        public void add2(int ss, int ff)
        {
            Console.WriteLine("sadwqasasadas");
        }
    }
}
