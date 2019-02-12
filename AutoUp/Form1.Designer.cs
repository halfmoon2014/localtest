namespace AutoUp
{
    partial class UpdateForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Complete = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lbl_Percent = new System.Windows.Forms.Label();
            this.lbl_Size_Title = new System.Windows.Forms.Label();
            this.lbl_Size = new System.Windows.Forms.Label();
            this.lbl_CurrentSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 24);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(164, 20);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(35, 143);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(72, 20);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "更新";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Complete
            // 
            this.btn_Complete.Enabled = false;
            this.btn_Complete.Location = new System.Drawing.Point(127, 143);
            this.btn_Complete.Name = "btn_Complete";
            this.btn_Complete.Size = new System.Drawing.Size(72, 20);
            this.btn_Complete.TabIndex = 2;
            this.btn_Complete.Text = "完成";
            this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.Location = new System.Drawing.Point(35, 102);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(147, 20);
            // 
            // lbl_Percent
            // 
            this.lbl_Percent.Location = new System.Drawing.Point(141, 58);
            this.lbl_Percent.Name = "lbl_Percent";
            this.lbl_Percent.Size = new System.Drawing.Size(100, 20);
            this.lbl_Percent.Text = "百分比";
            // 
            // lbl_Size_Title
            // 
            this.lbl_Size_Title.Location = new System.Drawing.Point(20, 58);
            this.lbl_Size_Title.Name = "lbl_Size_Title";
            this.lbl_Size_Title.Size = new System.Drawing.Size(67, 20);
            this.lbl_Size_Title.Text = "文件大小";
            // 
            // lbl_Size
            // 
            this.lbl_Size.Location = new System.Drawing.Point(85, 58);
            this.lbl_Size.Name = "lbl_Size";
            this.lbl_Size.Size = new System.Drawing.Size(36, 20);
            this.lbl_Size.Text = "label1";
            // 
            // lbl_CurrentSize
            // 
            this.lbl_CurrentSize.Location = new System.Drawing.Point(85, 82);
            this.lbl_CurrentSize.Name = "lbl_CurrentSize";
            this.lbl_CurrentSize.Size = new System.Drawing.Size(36, 20);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "已下载";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.lbl_CurrentSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Size);
            this.Controls.Add(this.lbl_Size_Title);
            this.Controls.Add(this.lbl_Percent);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.btn_Complete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.progressBar1);
            this.Name = "UpdateForm";
            this.Text = "更新";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.UpdateForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Complete;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lbl_Percent;
        private System.Windows.Forms.Label lbl_Size_Title;
        private System.Windows.Forms.Label lbl_Size;
        private System.Windows.Forms.Label lbl_CurrentSize;
        private System.Windows.Forms.Label label2;
    }
}

