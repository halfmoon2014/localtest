using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SupApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static string name = "码农";
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            //TODO  your code
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);

            //TODO  your code
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            //TODO  your code
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //注册Application_Error
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            //TODO  your code
        }
        //异常处理逻辑
        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("谁tmd惹祸了:" + e.Exception.Message);
            //处理完后，我们需要将Handler=true表示已此异常已处理过
            e.Handled = true;
        }
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);

            //TODO  your code
        }
    }
}
