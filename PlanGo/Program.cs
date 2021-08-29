using PlanGo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace PlanGo
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

            IPAddress ipAddr = Dns.Resolve(Dns.GetHostName()).AddressList[0];//获得当前IP地址
            //string ip = ipAddr.ToString();
            string name = LocalConfig.GetConfigValue("name");
            string pwd = LocalConfig.GetConfigValue("pwd");
            string username = LocalConfig.GetConfigValue("username");

            if (name.Length>0 && pwd.Length > 0 && username.Length > 0)
                Application.Run(new Plan(new DTO.LoginDto(name,pwd,username)));
            else
                Application.Run(new Login());
        }
    }
}
