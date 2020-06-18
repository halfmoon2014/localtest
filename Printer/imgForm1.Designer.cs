namespace Printer
{
    partial class imgForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnserch = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.loadpc = new System.Windows.Forms.PictureBox();
            this.ksrq = new System.Windows.Forms.DateTimePicker();
            this.jsrq = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadpc)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "至";
            // 
            // btnserch
            // 
            this.btnserch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnserch.Location = new System.Drawing.Point(701, 30);
            this.btnserch.Name = "btnserch";
            this.btnserch.Size = new System.Drawing.Size(75, 23);
            this.btnserch.TabIndex = 19;
            this.btnserch.Text = "下载";
            this.btnserch.UseVisualStyleBackColor = true;
            this.btnserch.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(25, 421);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(232, 20);
            this.lblInfo.TabIndex = 23;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loadpc
            // 
            this.loadpc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadpc.Location = new System.Drawing.Point(412, 178);
            this.loadpc.Name = "loadpc";
            this.loadpc.Size = new System.Drawing.Size(68, 51);
            this.loadpc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadpc.TabIndex = 24;
            this.loadpc.TabStop = false;
            // 
            // ksrq
            // 
            this.ksrq.Location = new System.Drawing.Point(55, 32);
            this.ksrq.Name = "ksrq";
            this.ksrq.Size = new System.Drawing.Size(123, 21);
            this.ksrq.TabIndex = 25;
            // 
            // jsrq
            // 
            this.jsrq.Location = new System.Drawing.Point(207, 32);
            this.jsrq.Name = "jsrq";
            this.jsrq.Size = new System.Drawing.Size(123, 21);
            this.jsrq.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 59);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 385);
            this.textBox1.TabIndex = 27;
            // 
            // imgForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.jsrq);
            this.Controls.Add(this.ksrq);
            this.Controls.Add(this.loadpc);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnserch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "imgForm1";
            this.Text = "imgForm1";
            ((System.ComponentModel.ISupportInitialize)(this.loadpc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnserch;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox loadpc;
        private System.Windows.Forms.DateTimePicker ksrq;
        private System.Windows.Forms.DateTimePicker jsrq;
        private System.Windows.Forms.TextBox textBox1;
    }
}