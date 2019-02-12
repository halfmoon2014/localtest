using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
namespace AutoUp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main(string [] args)
        {   

            //string ApplicationExecutablePath = Assembly.GetExecutingAssembly().GetName().CodeBase;
            //string directory = Path.GetDirectoryName(ApplicationExecutablePath) + "\\MaterialPacking.exe" ;
            //string[] args = new string[1] { directory };

            Application.Run(new UpdateForm(args));

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            
            //if (args.Length > 0)
            //{
            //    Application.Run(new UpdateForm(args));
            //} 
        }
    }
}