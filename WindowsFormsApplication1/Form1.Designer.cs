namespace PlanTODO
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labSize = new System.Windows.Forms.Label();
            this.labState = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpSound = new System.Windows.Forms.Button();
            this.txtSoundPath = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labSize
            // 
            this.labSize.AutoSize = true;
            this.labSize.Location = new System.Drawing.Point(297, 231);
            this.labSize.Name = "labSize";
            this.labSize.Size = new System.Drawing.Size(82, 15);
            this.labSize.TabIndex = 17;
            this.labSize.Text = "上传大小：";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(138, 231);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(82, 15);
            this.labState.TabIndex = 16;
            this.labState.Text = "上传状态：";
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Location = new System.Drawing.Point(297, 194);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(82, 15);
            this.labSpeed.TabIndex = 15;
            this.labSpeed.Text = "平均速度：";
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(138, 194);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(82, 15);
            this.labTime.TabIndex = 14;
            this.labTime.Text = "已用时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "选择文件：";
            // 
            // btnUpSound
            // 
            this.btnUpSound.Location = new System.Drawing.Point(341, 93);
            this.btnUpSound.Name = "btnUpSound";
            this.btnUpSound.Size = new System.Drawing.Size(84, 37);
            this.btnUpSound.TabIndex = 12;
            this.btnUpSound.Text = "上传文件";
            this.btnUpSound.UseVisualStyleBackColor = true;
            this.btnUpSound.Click += new System.EventHandler(this.btnUpSound_Click);
            // 
            // txtSoundPath
            // 
            this.txtSoundPath.Location = new System.Drawing.Point(124, 50);
            this.txtSoundPath.Name = "txtSoundPath";
            this.txtSoundPath.Size = new System.Drawing.Size(202, 25);
            this.txtSoundPath.TabIndex = 11;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(124, 161);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(255, 21);
            this.progressBar1.TabIndex = 10;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(341, 44);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(84, 31);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "上传进度：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 287);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labSize);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpSound);
            this.Controls.Add(this.txtSoundPath);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSelect);
            this.Name = "Form1";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labSize;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpSound;
        private System.Windows.Forms.TextBox txtSoundPath;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label2;
    }
}

