namespace PlanTODO
{
    partial class Pasn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pasn));
            this.btnsearch = new System.Windows.Forms.Button();
            this.dtsearchbegin = new System.Windows.Forms.DateTimePicker();
            this.dtsearchend = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearchstatus = new System.Windows.Forms.TextBox();
            this.ContentRTB = new System.Windows.Forms.RichTextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfilename = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbtip = new System.Windows.Forms.Label();
            this.btndel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.loadpc = new System.Windows.Forms.PictureBox();
            this.txtzdr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.planlist = new ListViewEx();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loadpc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsearch
            // 
            this.btnsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsearch.Location = new System.Drawing.Point(765, 14);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = "Search(&F)";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtsearchbegin
            // 
            this.dtsearchbegin.Location = new System.Drawing.Point(101, 17);
            this.dtsearchbegin.Name = "dtsearchbegin";
            this.dtsearchbegin.Size = new System.Drawing.Size(105, 21);
            this.dtsearchbegin.TabIndex = 2;
            // 
            // dtsearchend
            // 
            this.dtsearchend.Location = new System.Drawing.Point(285, 17);
            this.dtsearchend.Name = "dtsearchend";
            this.dtsearchend.Size = new System.Drawing.Size(104, 21);
            this.dtsearchend.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status";
            // 
            // txtsearchstatus
            // 
            this.txtsearchstatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtsearchstatus.Location = new System.Drawing.Point(589, 16);
            this.txtsearchstatus.Name = "txtsearchstatus";
            this.txtsearchstatus.Size = new System.Drawing.Size(100, 21);
            this.txtsearchstatus.TabIndex = 5;
            // 
            // ContentRTB
            // 
            this.ContentRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentRTB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ContentRTB.Location = new System.Drawing.Point(26, 254);
            this.ContentRTB.Name = "ContentRTB";
            this.ContentRTB.Size = new System.Drawing.Size(1145, 370);
            this.ContentRTB.TabIndex = 6;
            this.ContentRTB.Text = "";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(927, 14);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "Save(&S)";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.button2_Click);
            // 
            // txttitle
            // 
            this.txttitle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txttitle.Location = new System.Drawing.Point(430, 202);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(100, 21);
            this.txttitle.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Remark";
            // 
            // txtremark
            // 
            this.txtremark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtremark.Location = new System.Drawing.Point(83, 229);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(606, 21);
            this.txtremark.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(542, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Status";
            // 
            // txtstatus
            // 
            this.txtstatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtstatus.Location = new System.Drawing.Point(589, 202);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(100, 21);
            this.txtstatus.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "FileName";
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(264, 202);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.ReadOnly = true;
            this.txtfilename.Size = new System.Drawing.Size(100, 21);
            this.txtfilename.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "ID";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(83, 202);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(100, 21);
            this.txtid.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "开始日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "结束日期";
            // 
            // lbtip
            // 
            this.lbtip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbtip.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbtip.Location = new System.Drawing.Point(24, 628);
            this.lbtip.Name = "lbtip";
            this.lbtip.Size = new System.Drawing.Size(1147, 12);
            this.lbtip.TabIndex = 22;
            this.lbtip.Text = "tip";
            // 
            // btndel
            // 
            this.btndel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndel.Location = new System.Drawing.Point(1008, 14);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 23);
            this.btndel.TabIndex = 23;
            this.btndel.Text = "Del(&D)";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(846, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // loadpc
            // 
            this.loadpc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadpc.Image = ((System.Drawing.Image)(resources.GetObject("loadpc.Image")));
            this.loadpc.Location = new System.Drawing.Point(1039, 505);
            this.loadpc.Name = "loadpc";
            this.loadpc.Size = new System.Drawing.Size(132, 132);
            this.loadpc.TabIndex = 18;
            this.loadpc.TabStop = false;
            // 
            // txtzdr
            // 
            this.txtzdr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtzdr.Location = new System.Drawing.Point(447, 16);
            this.txtzdr.Name = "txtzdr";
            this.txtzdr.Size = new System.Drawing.Size(83, 21);
            this.txtzdr.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(400, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "制单人";
            // 
            // planlist
            // 
            this.planlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.planlist.Location = new System.Drawing.Point(26, 47);
            this.planlist.Name = "planlist";
            this.planlist.Size = new System.Drawing.Size(1145, 147);
            this.planlist.TabIndex = 0;
            this.planlist.UseCompatibleStateImageBehavior = false;
            this.planlist.DoubleClick += new System.EventHandler(this.planlist_DoubleClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1089, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Close(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Pasn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 649);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtzdr);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.lbtip);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.loadpc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.ContentRTB);
            this.Controls.Add(this.txtsearchstatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtsearchend);
            this.Controls.Add(this.dtsearchbegin);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.planlist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pasn";
            this.Text = "pasn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pasn_Load);
            this.ResizeEnd += new System.EventHandler(this.Pasn_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.loadpc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ListView planlist;
        private ListViewEx planlist;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.DateTimePicker dtsearchbegin;
        private System.Windows.Forms.DateTimePicker dtsearchend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsearchstatus;
        private System.Windows.Forms.RichTextBox ContentRTB;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtstatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfilename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.PictureBox loadpc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbtip;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtzdr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
    }
}