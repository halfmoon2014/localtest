using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Printer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool noRun;
            //判断是否已经有需要运行一个实例，如果系统没有，则运行一个
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out noRun))
            {
                if (noRun)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Print());
                     
                }
                else
                {
                    MessageBox.Show("目前已有一个程序在运行，请勿重复运行程序", "提示");
                }
            }
            
        }
    }
}
