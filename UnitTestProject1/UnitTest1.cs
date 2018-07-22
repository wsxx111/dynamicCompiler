using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            test();

            log("Main：调用test后");

            Thread.Sleep(Timeout.Infinite);

        }

        //Main方法不允许加async，所以我们用这个方法使用await

        static async void test()
        {
            log("test: await之前");

            await doo();

            log("test: await之后");
        }



        //返回Task的async方法

        static async Task doo()
        {
            log("doo: Task结果：" + await Task.Run(() => { Thread.Sleep(1000); log("Task"); return 1; }));

            log("doo: Task结果：" + await Task.Run(() => { Thread.Sleep(1000); log("Task"); return 2; }));

            log("doo: Task结果：" + await Task.Run(() => { Thread.Sleep(1000); log("Task"); return 3; }));

            Thread.Sleep(1000);
            Console.WriteLine("doo中在Task外的Thread.Sleep执行完毕");
        }



        //输出方法：显示当前线程的ManagedThreadId

        static void log(string msg)
        {
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }



    }
}
