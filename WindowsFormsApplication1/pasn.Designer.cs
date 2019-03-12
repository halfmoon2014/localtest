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
            this.ContentRTB = new System.Windows.Forms.RichTextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.txtcreator = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtrelor = new System.Windows.Forms.TextBox();
            this.cbstatus = new System.Windows.Forms.ComboBox();
            this.cbsearchstatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcompor = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.planlist = new ListViewEx();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.loadpc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsearch
            // 
            this.btnsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsearch.Location = new System.Drawing.Point(846, 14);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = "Search(&F)";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtsearchbegin
            // 
            this.dtsearchbegin.Location = new System.Drawing.Point(71, 17);
            this.dtsearchbegin.Name = "dtsearchbegin";
            this.dtsearchbegin.Size = new System.Drawing.Size(105, 21);
            this.dtsearchbegin.TabIndex = 2;
            // 
            // dtsearchend
            // 
            this.dtsearchend.Location = new System.Drawing.Point(241, 16);
            this.dtsearchend.Name = "dtsearchend";
            this.dtsearchend.Size = new System.Drawing.Size(104, 21);
            this.dtsearchend.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status";
            // 
            // ContentRTB
            // 
            this.ContentRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentRTB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ContentRTB.Location = new System.Drawing.Point(12, 251);
            this.ContentRTB.Name = "ContentRTB";
            this.ContentRTB.Size = new System.Drawing.Size(1159, 373);
            this.ContentRTB.TabIndex = 6;
            this.ContentRTB.Text = "";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(927, 200);
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
            this.txttitle.Location = new System.Drawing.Point(467, 201);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(100, 21);
            this.txttitle.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Remark";
            // 
            // txtremark
            // 
            this.txtremark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtremark.Location = new System.Drawing.Point(320, 224);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(400, 21);
            this.txtremark.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "FileName";
            this.label5.Visible = false;
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(71, 224);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(196, 21);
            this.txtfilename.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "ID";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(71, 200);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(55, 21);
            this.txtid.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "开始日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "结束日期";
            // 
            // lbtip
            // 
            this.lbtip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btndel.Location = new System.Drawing.Point(1089, 200);
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
            this.button1.Location = new System.Drawing.Point(927, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "New(&N)";
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
            // txtcreator
            // 
            this.txtcreator.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtcreator.Location = new System.Drawing.Point(398, 16);
            this.txtcreator.Name = "txtcreator";
            this.txtcreator.Size = new System.Drawing.Size(83, 21);
            this.txtcreator.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "制单人";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "业务";
            // 
            // txtrelor
            // 
            this.txtrelor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtrelor.Location = new System.Drawing.Point(167, 200);
            this.txtrelor.Name = "txtrelor";
            this.txtrelor.Size = new System.Drawing.Size(100, 21);
            this.txtrelor.TabIndex = 28;
            // 
            // cbstatus
            // 
            this.cbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbstatus.FormattingEnabled = true;
            this.cbstatus.Location = new System.Drawing.Point(620, 200);
            this.cbstatus.Name = "cbstatus";
            this.cbstatus.Size = new System.Drawing.Size(100, 20);
            this.cbstatus.TabIndex = 30;
            // 
            // cbsearchstatus
            // 
            this.cbsearchstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchstatus.FormattingEnabled = true;
            this.cbsearchstatus.Location = new System.Drawing.Point(534, 16);
            this.cbsearchstatus.Name = "cbsearchstatus";
            this.cbsearchstatus.Size = new System.Drawing.Size(100, 20);
            this.cbsearchstatus.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "完结人";
            // 
            // txtcompor
            // 
            this.txtcompor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtcompor.Location = new System.Drawing.Point(320, 200);
            this.txtcompor.Name = "txtcompor";
            this.txtcompor.Size = new System.Drawing.Size(100, 21);
            this.txtcompor.TabIndex = 32;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1008, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 34;
            this.button3.Text = "完结";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1008, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 35;
            this.button4.Text = "流程分享";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // planlist
            // 
            this.planlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.planlist.Location = new System.Drawing.Point(12, 47);
            this.planlist.Name = "planlist";
            this.planlist.Size = new System.Drawing.Size(1159, 147);
            this.planlist.TabIndex = 0;
            this.planlist.UseCompatibleStateImageBehavior = false;
            this.planlist.DoubleClick += new System.EventHandler(this.planlist_DoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(732, 625);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(439, 23);
            this.progressBar1.TabIndex = 36;
            this.progressBar1.Visible = false;
            // 
            // Pasn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 649);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtcompor);
            this.Controls.Add(this.cbsearchstatus);
            this.Controls.Add(this.cbstatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtrelor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtcreator);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.loadpc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtfilename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.ContentRTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtsearchend);
            this.Controls.Add(this.dtsearchbegin);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.planlist);
            this.Controls.Add(this.lbtip);
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
        private System.Windows.Forms.RichTextBox ContentRTB;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.TextBox txtcreator;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtrelor;
        private System.Windows.Forms.ComboBox cbstatus;
        private System.Windows.Forms.ComboBox cbsearchstatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcompor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}