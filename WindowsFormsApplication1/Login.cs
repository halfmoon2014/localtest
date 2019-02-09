
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
    public partial class Login : Form
    {
        private Pasn pasn;
        public Login()
        {
            InitializeComponent();
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
                    pasn = new Pasn();
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
        }
    }
}
