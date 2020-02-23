namespace AutoUp
{
    partial class UpdateForm
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
            this.lbl_CurrentSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Size = new System.Windows.Forms.Label();
            this.lbl_Size_Title = new System.Windows.Forms.Label();
            this.lbl_Percent = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_Complete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lbl_CurrentSize
            // 
            this.lbl_CurrentSize.Location = new System.Drawing.Point(76, 70);
            this.lbl_CurrentSize.Name = "lbl_CurrentSize";
            this.lbl_CurrentSize.Size = new System.Drawing.Size(36, 20);
            this.lbl_CurrentSize.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "已下载";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Size
            // 
            this.lbl_Size.Location = new System.Drawing.Point(76, 46);
            this.lbl_Size.Name = "lbl_Size";
            this.lbl_Size.Size = new System.Drawing.Size(36, 20);
            this.lbl_Size.TabIndex = 10;
            this.lbl_Size.Text = "label1";
            // 
            // lbl_Size_Title
            // 
            this.lbl_Size_Title.Location = new System.Drawing.Point(11, 46);
            this.lbl_Size_Title.Name = "lbl_Size_Title";
            this.lbl_Size_Title.Size = new System.Drawing.Size(67, 20);
            this.lbl_Size_Title.TabIndex = 12;
            this.lbl_Size_Title.Text = "文件大小";
            // 
            // lbl_Percent
            // 
            this.lbl_Percent.Location = new System.Drawing.Point(132, 46);
            this.lbl_Percent.Name = "lbl_Percent";
            this.lbl_Percent.Size = new System.Drawing.Size(100, 20);
            this.lbl_Percent.TabIndex = 13;
            this.lbl_Percent.Text = "百分比";
            // 
            // lbl_Status
            // 
            this.lbl_Status.Location = new System.Drawing.Point(26, 90);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(147, 20);
            this.lbl_Status.TabIndex = 14;
            // 
            // btn_Complete
            // 
            this.btn_Complete.Enabled = false;
            this.btn_Complete.Location = new System.Drawing.Point(118, 131);
            this.btn_Complete.Name = "btn_Complete";
            this.btn_Complete.Size = new System.Drawing.Size(72, 20);
            this.btn_Complete.TabIndex = 11;
            this.btn_Complete.Text = "完成";
            this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(26, 131);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(72, 20);
            this.btn_Update.TabIndex = 9;
            this.btn_Update.Text = "更新";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(164, 20);
            this.progressBar1.TabIndex = 15;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 181);
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
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateForm_FormClosing);
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_CurrentSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Size;
        private System.Windows.Forms.Label lbl_Size_Title;
        private System.Windows.Forms.Label lbl_Percent;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Button btn_Complete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

