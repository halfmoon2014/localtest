using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace PlanTODO
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [Obsolete]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Sunisoft.IrisSkin.SkinEngine s;
            //s = new Sunisoft.IrisSkin.SkinEngine
            //{
            //    //s.SkinFile = Application.StartupPath + "//Skins//Page.ssk";
            //    SkinFile = Application.StartupPath + "//Skins//EmeraldColor3.ssk",
            //    SkinAllForm = true
            //};
            //if (!s.Active)
            //    s.Active = true;
            IPAddress ipAddr = Dns.Resolve(Dns.GetHostName()).AddressList[0];//获得当前IP地址
            string ip = ipAddr.ToString();
        
            if (ip.Equals("192.168.37.35"))
                Application.Run(new Pasn("zhmh", "123"));
            else
                Application.Run(new Login());

            //Application.Run(new Pasn("zhmh","张"));
            //Application.Run(new Form1());
        }
    }
}
