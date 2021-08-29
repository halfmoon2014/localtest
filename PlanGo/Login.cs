using PlanGo.DTO;
using PlanGo.SqlServerService;
using PlanGo.Tools;
using Sunny.UI;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PlanGo
{
    public partial class Login : CommForm
    {
        /// <summary>
        /// 登陆线程
        /// </summary>
        //static Thread loginThread;
        public Login()
        {
            InitializeComponent();
            Init(uiStyleManager1);
            loadpc.Location = new System.Drawing.Point((Width - loadpc.Width) / 2, (Height - loadpc.Height) / 2);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                btnlogin.Enabled = false;
                loadpc.Visible = true;
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
                    loginDto.Username = ds.Tables[0].Rows[0]["username"].ToString();
                    Plan plan = new Plan(loginDto);
                    Hide();
                    plan.ShowDialog();
                    Application.ExitThread();
                }
                else
                {
                    btnlogin.Enabled = true;
                    loadpc.Visible = false;
                    UIMessageDialog.ShowMessageDialog("用户名密码错误", UILocalize.InfoTitle, false, Style);

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
    }
}
