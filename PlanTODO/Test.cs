using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanTODO
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            //sql();
            //sqlThred();
            //sqlThred2();
            sqlThred3();
        }
        private void sqlThred3() {
            string sql = "select * from yx_t_spdmb a inner join pasn b on b.id<15 ;";
            SQLUtilEvent2 sQLUtilSaveEvent = new SQLUtilEvent2(sql);
            sQLUtilSaveEvent.OnInput += new EventHandler<RunWorkerCompletedEventArgs>((object sendObj, RunWorkerCompletedEventArgs arg) => {
                DataSet dataSave = (DataSet)arg.Result;
                textBox1.Text = dataSave.Tables[0].Rows.Count.ToString();
            });
            sQLUtilSaveEvent.Run();
        }
        private void sqlThred2()
        {
            Thread th;
            th = new Thread(() => {
               DataSet ds= sql3();
               System.Console.WriteLine("sql");
                //报错
               textBox1.Text = ds.Tables[0].Rows.Count.ToString();
            });
            th.Start();
        }
        private DataSet sql3()
        {
            string sql = "select * from yx_t_spdmb a inner join pasn b on b.id<15 ;";
            return  MySqlHelper.ExecuteSQL(sql);
             
        }
        private void sqlThred() {
            Thread th;
            th = new Thread(() => {
                sql2();
            });
            th.Start();
        }
        private void sql2()
        {
            string sql = "select * from yx_t_spdmb a inner join pasn b on b.id<15 ;";
            DataSet ds = MySqlHelper.ExecuteSQL(sql);
            System.Console.WriteLine("sql");
            //使用线程就会报错,
            //textBox1.Text = ds.Tables[0].Rows.Count.ToString();
        }

        /// <summary>
        /// 直接主线程调用
        /// </summary>
        private void sql() {
          string  sql = "select * from yx_t_spdmb a inner join pasn b on b.id<15 ;";
          DataSet ds= MySqlHelper.ExecuteSQL(sql);
          System.Console.WriteLine("sql");
        }
    }

    class SQLUtilEvent2
    {
        /// <summary>
        /// 查询完回调
        /// </summary>
        public event EventHandler<RunWorkerCompletedEventArgs> OnInput; //定义一个委托类型的事件 ,查询完回调
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged; //定义一个委托类型的事件 ,查询完回调
        private string sql;
        private BackgroundWorker worker;
        public SQLUtilEvent2(string sql)
        {
            this.sql = sql;
        }
        public void Run()
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            //当事件处理完毕后执行的方法   
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((object sender, RunWorkerCompletedEventArgs e) => {

                OnInput(this, e);
            });
            worker.ProgressChanged += new ProgressChangedEventHandler((object sender, ProgressChangedEventArgs e)=> {
                OnProgressChanged(this,e);
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
