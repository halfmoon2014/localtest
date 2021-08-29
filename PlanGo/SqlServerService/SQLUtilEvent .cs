using PlanGo.DTO;
using System;
 
using System.ComponentModel;
 

namespace PlanGo.SqlServerService
{
    /// <summary>
    /// SQL执行
    /// </summary>
    class SQLUtilEvent
    {
        /// <summary>
        /// 查询完回调
        /// </summary>
        public event EventHandler<RunWorkerCompletedEventArgs> OnRunWorkerCompleted; //定义一个委托类型的事件 ,查询完回调
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged; //定义一个委托类型的事件 ,查询完回调
        private readonly Object args;
        private BackgroundWorker worker;
        public SQLUtilEvent(Object args)
        {
            this.args = args;
        }
        public void Run(string action) {
            worker = new BackgroundWorker();
            if(action=="login")
                worker.DoWork += new DoWorkEventHandler(WorkerLogin);
            else if (action=="sql")
                worker.DoWork += new DoWorkEventHandler(WorkerList);

            //当事件处理完毕后执行的方法   
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((object sender, RunWorkerCompletedEventArgs e) => {
                OnRunWorkerCompleted(this, e);
            });
            worker.ProgressChanged += new ProgressChangedEventHandler((object sender, ProgressChangedEventArgs e) => {
                OnProgressChanged(this, e);
            });
            worker.WorkerReportsProgress = true;//支持报告进度更新   
            worker.WorkerSupportsCancellation = false;//不支持异步取消   
            worker.RunWorkerAsync(args);//启动执行  
        }

        void WorkerList(object sender, DoWorkEventArgs e)
        {
            var receive = e.Argument as object;
            e.Result = MySqlHelper.ExecuteSQL((string)receive);
        }
        //登陆 
        void WorkerLogin(object sender, DoWorkEventArgs e)
        {
            var receive = e.Argument as LoginDto;
            e.Result = SqlServerDo.Login(receive);
        }
    }
}
