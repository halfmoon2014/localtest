using PlanGo.DTO;
using PlanGo.SqlServerService;
using PlanGo.Tools;
using Sunny.UI;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PlanGo
{
    public partial class Login : CommForm
    {
        private delegate void MsgInfoDelegate(string strInfo, bool isShow);
        private MsgInfoDelegate ShowInfo;
        private delegate void SetStaticDelegate(bool enabled);
        private SetStaticDelegate SetStatic;


        private delegate void ProcessDelegate();
        private ProcessDelegate ShowProcess;

        private Thread ProcessBarThread ;
        public Login()
        {
            InitializeComponent();
            Init(uiStyleManager1);
        
            ShowInfo = new MsgInfoDelegate(MessageShowSub);
            SetStatic = new SetStaticDelegate(SetStaticSub);
            ShowProcess = new ProcessDelegate(ProcessBarRun);
        }
        private void MessageShowSub(string info, bool isShow)
        {
            lblInfo.Text = info;
            lblInfo.ForeColor = Color.Red;            
            if (isShow)
            {
                ShowMessageDialog(info);
            }
        }
        private void SetStaticSub(bool enabled)
        {
            btnlogin.Enabled = enabled;
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                btnlogin.Enabled = false;
                ProcessBarStart();
             
                LoginWord();            

            }
            catch (SystemException ex)
            {
                UIMessageDialog.ShowMessageDialog(ex.Message, UILocalize.InfoTitle, false, Style);             
            }
        }
        private void LoginWord()
        {
            LoginDto loginDto = new LoginDto(txtname.Text, txtpassword.Text);
            SQLUtilEvent sQLUtilEvent = new SQLUtilEvent(new LoginDto(txtname.Text, txtpassword.Text));
            sQLUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object sender, RunWorkerCompletedEventArgs e) =>
            {
                DataSet ds = (DataSet)e.Result;
                if (ds.Tables[0].Rows.Count == 1)
                {
                    LocalConfig.SetConfigValue("name", txtname.Text);
                    LocalConfig.SetConfigValue("pwd", EncryptUtil.Md532(txtpassword.Text));
                    LocalConfig.SetConfigValue("username", ds.Tables[0].Rows[0]["username"].ToString());
                    loginDto.Username = ds.Tables[0].Rows[0]["username"].ToString();
                    Plan plan = new Plan(loginDto);
                    Hide();
                    plan.ShowDialog();
                    ProcessBarThread.Abort();
                    Application.ExitThread();
                }
                else
                {
                    btnlogin.Enabled = true;
            
                    ProcessBarStop();
                    ShowMessageDialog("用户名密码错误");

                }
            });
            sQLUtilEvent.Run("login");
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show("v0.1", "关于", Style, UIMessageBoxButtons.OK, false);
        }

        private void VoidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIStyle t = (UIStyle)Enum.Parse(typeof(UIStyle), sender.ToString());
            LocalConfig.SetConfigValue("style", sender.ToString());
            uiStyleManager1.Style = t;

        }

        private void Login_Load(object sender, EventArgs e)
        {
            ProcessBarStart();
     
            Thread t1 = new Thread(DownLoad);
            t1.Start();
            Console.WriteLine("DownLoad/" + DateTime.Now.ToString() + "/" + t1.ManagedThreadId.ToString());
        }

        private void DownLoad()
        {
            try
            {
                this.Invoke(ShowInfo, "正在下载更新列表...", false);
                this.Invoke(SetStatic, false);

                DataSet ds = MySqlHelper.ExecuteSQL(" select ver,url from cl_V_pda_ver a where type='ab2' order by ver desc ");
                DataTable dtZXD = ds.Tables[0];

                string remoteVer = dtZXD.Rows[0]["ver"].ToString();
                string url = dtZXD.Rows[0]["url"].ToString();
                if (remoteVer != LocalConfig.GetConfigValue("ver"))
                {
                    ProcessBarThread.Abort();
                    Process p = new Process();
                    p.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\autoup.exe";
                    p.StartInfo.Arguments = remoteVer + " " + url + " " + System.Windows.Forms.Application.StartupPath + "\\PlanGo.exe";
                    p.Start();

                    Process.GetCurrentProcess().Kill();
                }
                Invoke(new Action(() =>
                {
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                    ProcessBarStop();
                 
                }));
                this.Invoke(ShowInfo, "", false);
                this.Invoke(SetStatic, true);
            }
            catch (SystemException ex)
            {
                ShowMessageDialog(ex.Message);
            }

        }
        private void ProcessBarStart() {
            uiProcessBar2.Visible = true;
            uiProcessBar2.Value = 0;
            if(ProcessBarThread != null) ProcessBarThread.Abort();
            ProcessBarThread = new Thread(()=> {
                while (true)
                {
                    ShowProcess();
                    Thread.Sleep(10);
                }
            });
            ProcessBarThread.Start(); 
        }

        private void ProcessBarRun()
        {
            if (uiProcessBar2.Value >= 100) uiProcessBar2.Value = 0;
            uiProcessBar2.Value += 1;
        }

        private void ProcessBarStop()
        {
            uiProcessBar2.Visible = false;
            uiProcessBar2.Value = 0;
            ProcessBarThread.Abort();          
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessBarThread.Abort();
            ProcessBarThread = null;
        }
    }
}
