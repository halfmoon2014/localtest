namespace PlanGo
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.btnexit = new Sunny.UI.UIButton();
            this.txtname = new Sunny.UI.UITextBox();
            this.txtpassword = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btnlogin = new Sunny.UI.UIButton();
            this.loadpc = new Sunny.UI.UIProgressIndicator();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.office2010BlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.office2010SilverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.office2010BlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightOrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightRedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightPurpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(139, 103);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Name";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnexit
            // 
            this.btnexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnexit.Location = new System.Drawing.Point(139, 246);
            this.btnexit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(100, 35);
            this.btnexit.TabIndex = 1;
            this.btnexit.Text = "Exit(&E)";
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // txtname
            // 
            this.txtname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtname.FillColor = System.Drawing.Color.White;
            this.txtname.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtname.Location = new System.Drawing.Point(246, 97);
            this.txtname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtname.Maximum = 2147483647D;
            this.txtname.Minimum = -2147483648D;
            this.txtname.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(150, 29);
            this.txtname.TabIndex = 2;
            this.txtname.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtpassword
            // 
            this.txtpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpassword.FillColor = System.Drawing.Color.White;
            this.txtpassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtpassword.Location = new System.Drawing.Point(246, 142);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpassword.Maximum = 2147483647D;
            this.txtpassword.Minimum = -2147483648D;
            this.txtpassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '#';
            this.txtpassword.Size = new System.Drawing.Size(150, 29);
            this.txtpassword.TabIndex = 4;
            this.txtpassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(139, 142);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 3;
            this.uiLabel2.Text = "PassWord";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnlogin
            // 
            this.btnlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogin.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnlogin.Location = new System.Drawing.Point(307, 246);
            this.btnlogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(100, 35);
            this.btnlogin.TabIndex = 5;
            this.btnlogin.Text = "Login(&L)";
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // loadpc
            // 
            this.loadpc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.loadpc.Location = new System.Drawing.Point(48, 88);
            this.loadpc.MinimumSize = new System.Drawing.Size(1, 1);
            this.loadpc.Name = "loadpc";
            this.loadpc.Size = new System.Drawing.Size(100, 100);
            this.loadpc.TabIndex = 7;
            this.loadpc.Text = "uiProgressIndicator1";
            this.loadpc.Visible = false;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(113, 56);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.orangeToolStripMenuItem,
            this.redToolStripMenuItem,
            this.grayToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.darkBlueToolStripMenuItem,
            this.blackToolStripMenuItem,
            this.purpleToolStripMenuItem,
            this.office2010BlueToolStripMenuItem,
            this.office2010SilverToolStripMenuItem,
            this.office2010BlackToolStripMenuItem,
            this.lightBlueToolStripMenuItem,
            this.lightGreenToolStripMenuItem,
            this.lightOrangeToolStripMenuItem,
            this.lightRedToolStripMenuItem,
            this.lightGrayToolStripMenuItem,
            this.lightPurpleToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.关于ToolStripMenuItem.Text = "主题";
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // orangeToolStripMenuItem
            // 
            this.orangeToolStripMenuItem.Name = "orangeToolStripMenuItem";
            this.orangeToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.orangeToolStripMenuItem.Text = "Orange";
            this.orangeToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.grayToolStripMenuItem.Text = "Gray";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // darkBlueToolStripMenuItem
            // 
            this.darkBlueToolStripMenuItem.Name = "darkBlueToolStripMenuItem";
            this.darkBlueToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.darkBlueToolStripMenuItem.Text = "DarkBlue";
            this.darkBlueToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.blackToolStripMenuItem.Text = "Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // purpleToolStripMenuItem
            // 
            this.purpleToolStripMenuItem.Name = "purpleToolStripMenuItem";
            this.purpleToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.purpleToolStripMenuItem.Text = "Purple";
            this.purpleToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // office2010BlueToolStripMenuItem
            // 
            this.office2010BlueToolStripMenuItem.Name = "office2010BlueToolStripMenuItem";
            this.office2010BlueToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.office2010BlueToolStripMenuItem.Text = "Office2010Blue";
            this.office2010BlueToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // office2010SilverToolStripMenuItem
            // 
            this.office2010SilverToolStripMenuItem.Name = "office2010SilverToolStripMenuItem";
            this.office2010SilverToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.office2010SilverToolStripMenuItem.Text = "Office2010Silver";
            this.office2010SilverToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // office2010BlackToolStripMenuItem
            // 
            this.office2010BlackToolStripMenuItem.Name = "office2010BlackToolStripMenuItem";
            this.office2010BlackToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.office2010BlackToolStripMenuItem.Text = "Office2010Black";
            this.office2010BlackToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // lightBlueToolStripMenuItem
            // 
            this.lightBlueToolStripMenuItem.Name = "lightBlueToolStripMenuItem";
            this.lightBlueToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.lightBlueToolStripMenuItem.Text = "LightBlue";
            this.lightBlueToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // lightGreenToolStripMenuItem
            // 
            this.lightGreenToolStripMenuItem.Name = "lightGreenToolStripMenuItem";
            this.lightGreenToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.lightGreenToolStripMenuItem.Text = "LightGreen";
            this.lightGreenToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // lightOrangeToolStripMenuItem
            // 
            this.lightOrangeToolStripMenuItem.Name = "lightOrangeToolStripMenuItem";
            this.lightOrangeToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.lightOrangeToolStripMenuItem.Text = "LightOrange";
            this.lightOrangeToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // lightRedToolStripMenuItem
            // 
            this.lightRedToolStripMenuItem.Name = "lightRedToolStripMenuItem";
            this.lightRedToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.lightRedToolStripMenuItem.Text = "LightRed";
            this.lightRedToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // lightGrayToolStripMenuItem
            // 
            this.lightGrayToolStripMenuItem.Name = "lightGrayToolStripMenuItem";
            this.lightGrayToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.lightGrayToolStripMenuItem.Text = "LightGray";
            this.lightGrayToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // lightPurpleToolStripMenuItem
            // 
            this.lightPurpleToolStripMenuItem.Name = "lightPurpleToolStripMenuItem";
            this.lightPurpleToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.lightPurpleToolStripMenuItem.Text = "LightPurple";
            this.lightPurpleToolStripMenuItem.Click += new System.EventHandler(this.VoidToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(112, 26);
            this.关于ToolStripMenuItem1.Text = "关于";
            this.关于ToolStripMenuItem1.Click += new System.EventHandler(this.关于ToolStripMenuItem1_Click);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(545, 334);
            this.Controls.Add(this.loadpc);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.uiLabel1);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowIcon = true;
            this.ShowRadius = false;
            this.Text = "Login";
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton btnexit;
        private Sunny.UI.UITextBox txtname;
        private Sunny.UI.UITextBox txtpassword;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton btnlogin;
        private Sunny.UI.UIProgressIndicator loadpc;
        private Sunny.UI.UIStyleManager uiStyleManager1;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem office2010BlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem office2010SilverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem office2010BlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightOrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightRedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightPurpleToolStripMenuItem;
    }
}

