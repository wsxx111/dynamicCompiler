using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongCompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.txtCode.Text = @"
                      using System; 
                      using System.IO;
                      public class MyClass{
                        public static string PrintConsole(string message){ 
                             return message; 
                         } 
                     }";
        }

        private void btnCompiler_Click(object sender, EventArgs e)
        {
            string code = this.txtCode.Text;
            StringBuilder str = new StringBuilder();          
            Microsoft.CSharp.CSharpCodeProvider codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
            System.CodeDom.Compiler.CompilerParameters comparameters = new System.CodeDom.Compiler.CompilerParameters();
            comparameters.ReferencedAssemblies.Add("System.dll");
            comparameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            comparameters.GenerateInMemory = true;
            System.CodeDom.Compiler.CompilerResults res = codeProvider.CompileAssemblyFromSource(comparameters, code);
            if (res.Errors.HasErrors)
            {
                Console.WriteLine("编译错误：");
                foreach (System.CodeDom.Compiler.CompilerError err in res.Errors)
                {
                    str.AppendLine(@"/r/nLine:"+                              
                                err.ErrorText);
                   // str.AppendLine(err.ErrorText);
                   // Console.WriteLine(err.ErrorText);
                }
            }
            else
            {
                object myClass = res.CompiledAssembly.CreateInstance("MyClass");
               var result= myClass.GetType().GetMethod("PrintConsole").Invoke(myClass, new object[] { "Hello World" });
                str.AppendLine(result.ToString());
            }
            this.txtResult.Text = str.ToString();
            //Console.Read();        
        }
    }
}
