using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
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
        static Thread loginThread;
        //Sunisoft.IrisSkin.SkinEngine s;

        private void LoginInit() {           
            ShowInfo = new MsgInfoDelegate(MessageShowSub);
            SetStatic = new SetStaticDelegate(SetStaticSub);
            Bitmap bmp = (Bitmap)Bitmap.FromFile(Application.StartupPath + "//ico//Book.png");
            Icon ic = Icon.FromHandle(bmp.GetHicon());
            Icon = ic;
            loadpc.Location = new System.Drawing.Point((Width - loadpc.Width) / 2, (Height - loadpc.Height) / 2);
            //loadpc.Location = new System.Drawing.Point(0, 0);
            //loadpc.Width = Width;
            //loadpc.Height = Height;             
            loadpc.BringToFront();
            
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            loadpc.Visible = true;
        }
        public Login()
        {
            InitializeComponent();
            BackColor = SystemColors.Control;
            LoginInit();
        }
        public Login(string name, string password)
        {
            InitializeComponent();
            LoginInit();
            txtname.Text = name;
            txtpassword.Text = password;
            
            Btnlogin_Click(null,null);

        }
        private void SetStaticSub(bool enabled)
        {
            btnlogin.Enabled = enabled;
        }
        private void MessageShowSub(string info, bool isShow)
        {
            lblInfo.Text = info;
            if (isShow)
            {
                MessageBoxEx.Show(this, info);
            }
        }
        private void Btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                btnlogin.Enabled = false;
                loadpc.Visible = true;
                if (loginThread != null) loginThread.Abort();
                loginThread = new Thread(() => LoginWord());
                Console.WriteLine("LoginWord/" + DateTime.Now.ToString() + "/" + loginThread.ManagedThreadId.ToString());
                loginThread.Start();


                //Action act = new Action(LoginWord);
                //act.BeginInvoke(callBack, null);

            }
            catch (SystemException ex) {
                MessageShowSub(ex.Message, true);                
            }
        }
        //AsyncCallback callBack = new AsyncCallback(s =>
        //{
        //    Console.WriteLine("执行完毕,开始回调");
        //});
        private void LoginWord()
        {
            //Invoke(new Action(() =>
            //{
            //    btnlogin.Enabled = false;
            //    loadpc.Visible = true;
            //}));
            string name = txtname.Text;
            string pwd = txtpassword.Text;
            DataSet ds = MySqlHelper.ExecuteSQL("select * from users where userid='" + name + "' and pwd='" + EncryptUtil.Md532(pwd) + "' ");         
               
            if (ds.Tables[0].Rows.Count == 1)
            {                
                Invoke(new Action(() =>
                {
                   

                    pasn = new Pasn(name, ds.Tables[0].Rows[0]["username"].ToString());
                    Hide();
                    pasn.ShowDialog();
                    Application.ExitThread();
                }));
                
            }
            else
            {
                
                Invoke(new Action(() =>
                {
                    btnlogin.Enabled = true;
                    loadpc.Visible = false;
                    MessageShowSub("用户名密码错误", true);
                }));
            }
          
            

        }

        private void Login_Load(object sender, EventArgs e)
        {
            //s = new Sunisoft.IrisSkin.SkinEngine();
            ////s.SkinFile = Application.StartupPath + "//Skins//Page.ssk";
            //s.SkinFile = Application.StartupPath + "//Skins//EmeraldColor3.ssk";
            //s.SkinAllForm = true;
            //if (!s.Active)
            //    s.Active = true;
            Init();
        }
        public void Init()
        {       
            Thread t1 = new Thread(DownLoad);
            t1.Start();
            Console.WriteLine("DownLoad/" + DateTime.Now.ToString() + "/" + t1.ManagedThreadId.ToString());
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
                    p.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\autoup.exe";
                    p.StartInfo.Arguments = remoteVer + " " + url + " " + System.Windows.Forms.Application.StartupPath+"\\plantodo.exe";
                    p.Start();
                   
                    Process.GetCurrentProcess().Kill();
                }
                Invoke(new Action(() =>
                {
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                    loadpc.Visible = false;
                }));
                this.Invoke(ShowInfo, "", false);
                this.Invoke(SetStatic, true);
            }
            catch (SystemException ex)
            {
                MessageShowSub(ex.Message, true);
            }

        }

        private void Txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                Btnlogin_Click(sender, e);//触发button事件  
            }
        }

        private void Txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
