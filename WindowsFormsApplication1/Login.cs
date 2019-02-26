using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;

namespace PlanTODO
{
    public partial class Login : Form
    {
        
       
        private delegate void MsgInfoDelegate(string strInfo, bool isShow);
        private MsgInfoDelegate ShowInfo;
        private delegate void SetStaticDelegate(bool enabled);
        private SetStaticDelegate SetStatic;
        private Pasn pasn;
        Sunisoft.IrisSkin.SkinEngine s;
        public Login()
        {
            InitializeComponent();
            ShowInfo = new MsgInfoDelegate(MessageShowSub);
            SetStatic = new SetStaticDelegate(SetStaticSub);
            //this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //this.skinEngine1.SkinFile = Application.StartupPath + "//Page.ssk";     
            s = new Sunisoft.IrisSkin.SkinEngine();
            //s.SkinDialogs = false;
            s.SkinFile = Application.StartupPath + "//Skins//Page.ssk";
            Bitmap bmp = (Bitmap)Bitmap.FromFile(Application.StartupPath + "//ico//main.ico");
            Icon ic = Icon.FromHandle(bmp.GetHicon());
            this.Icon = ic;

        }
        private void SetStaticSub(bool enabled)
        {
            this.btnlogin.Enabled = enabled;
        }
        private void MessageShowSub(string info, bool isShow)
        {
            this.lblInfo.Text = info;
            if (isShow)
            {
                MessageBox.Show(info, "系统提示");
            }
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {            
            Thread thread;
            thread = new Thread(() => login());
            thread.Start();
        }

        private void login()
        {
            this.Invoke(new Action(() =>
            {
                btnlogin.Enabled = false;
                loadpc.Visible = true;
            }));
            string name = txtname.Text;
            string pwd = txtpassword.Text;
            DataSet ds = MySqlHelper.ExecuteSQL("select * from users where userid='" + name + "' and pwd='" + EncryptUtil.Md532(pwd) + "' ");
            this.Invoke(new Action(() =>
            {
                btnlogin.Enabled = true;
                loadpc.Visible = false;
                if (ds.Tables[0].Rows.Count == 1)
                {
                    pasn = new Pasn(name);
                    this.Hide();
                    pasn.ShowDialog();
                    Application.ExitThread();
                }
                else
                {
                    MessageBoxEx.Show(this, "用户名密码错误");
                }
            }));
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Init();
        }
        public void Init()
        {
            this.loadpc.Visible = false;
            loadpc.Location = new System.Drawing.Point((this.Width - loadpc.Width) / 2, (this.Height - loadpc.Height) / 2);
            loadpc.Visible = false;
            loadpc.BringToFront();
            Thread t1 = new Thread(DownLoad);
            t1.Start();
        }

        //下载更新列表
        private void DownLoad()
        {
            try
            {
                this.Invoke(ShowInfo, "正在下载更新列表...", false);
                this.Invoke(SetStatic, false);

                DataSet ds = MySqlHelper.ExecuteSQL(" select ver,url from cl_V_pda_ver a where type='ab' order by ver desc ");
                DataTable dtZXD = ds.Tables[0];



                string remoteVer = dtZXD.Rows[0]["ver"].ToString();
                string url = dtZXD.Rows[0]["url"].ToString();
                if (remoteVer != LocalConfig.GetConfigValue("ver"))
                {
                    Process p = new Process();
                    //CE下需绝对路径，没有工作目录概念
                    p.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\autoup.exe";
                    p.StartInfo.Arguments = remoteVer + " " + url + " " + System.Windows.Forms.Application.StartupPath+"\\plantodo.exe";
                    p.Start();

                    Process.GetCurrentProcess().Kill();
                }

                this.Invoke(ShowInfo, "", false);
                this.Invoke(SetStatic, true);
            }
            catch (SystemException ex)
            {

            }

        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                btnlogin_Click(sender, e);//触发button事件  
            }
        }
        
    }
}
