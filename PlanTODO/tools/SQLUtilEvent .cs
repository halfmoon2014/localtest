using System;
 
using System.ComponentModel;
 

namespace PlanTODO.tools
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
        private string sql;
        private BackgroundWorker worker;
        public SQLUtilEvent(string sql)
        {
            this.sql = sql;
        }
        public void Run() {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            //当事件处理完毕后执行的方法   
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((object sender, RunWorkerCompletedEventArgs e) => {

                OnRunWorkerCompleted(this, e);
            });
            worker.ProgressChanged += new ProgressChangedEventHandler((object sender, ProgressChangedEventArgs e) => {
                OnProgressChanged(this, e);
            });
            worker.WorkerReportsProgress = true;//支持报告进度更新   
            worker.WorkerSupportsCancellation = false;//不支持异步取消   
            worker.RunWorkerAsync(sql);//启动执行  
        }
  

        //开始启动工作时执行的事件处理方法   
        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var receive = e.Argument as object;
            e.Result = MySqlHelper.ExecuteSQL((string)receive);             
        }
    }
}
