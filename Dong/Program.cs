
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong
{
    class Programs
    {
        static void Msains(string[] args)
        {
            string code = "using System; " +
                      "using System.IO; " +
                      "public class MyClass{ " +
                      "   public static void PrintConsole(string message){ " +
                      "       Console.WriteLine(message); " +
                      "   } " +
                      "} ";

            Microsoft.CSharp.CSharpCodeProvider codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
            System.CodeDom.Compiler.CompilerParameters comparameters = new System.CodeDom.Compiler.CompilerParameters();

            System.CodeDom.Compiler.CompilerResults res = codeProvider.CompileAssemblyFromSource(comparameters, code);
            if (res.Errors.HasErrors)
            {
                Console.WriteLine("编译错误：");
                foreach (System.CodeDom.Compiler.CompilerError err in res.Errors)
                {
                    Console.WriteLine(err.ErrorText);
                }
            }
            else
            {
                object myClass = res.CompiledAssembly.CreateInstance("MyClass");
                myClass.GetType().GetMethod("PrintConsole").Invoke(myClass, new object[] { "Hello World" });
            }
            Console.Read();
        }
    }
}
