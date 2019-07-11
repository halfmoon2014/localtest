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
            this.btndel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtcreator = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtrelor = new System.Windows.Forms.TextBox();
            this.cbstatus = new System.Windows.Forms.ComboBox();
            this.cbsearchstatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcompor = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.cbprocessor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbsearchprocessor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txthour = new System.Windows.Forms.TextBox();
            this.txtcontent = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbtip = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadpc = new System.Windows.Forms.ToolStripStatusLabel();
            this.planlist = new ListViewEx();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsearch
            // 
            this.btnsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsearch.Location = new System.Drawing.Point(1088, 14);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 10;
            this.btnsearch.Text = "Search(&F)";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtsearchbegin
            // 
            this.dtsearchbegin.Location = new System.Drawing.Point(71, 17);
            this.dtsearchbegin.Name = "dtsearchbegin";
            this.dtsearchbegin.Size = new System.Drawing.Size(105, 21);
            this.dtsearchbegin.TabIndex = 1;
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
            this.label1.Location = new System.Drawing.Point(689, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
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
            this.ContentRTB.Size = new System.Drawing.Size(1401, 526);
            this.ContentRTB.TabIndex = 34;
            this.ContentRTB.Text = "";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(1250, 200);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 32;
            this.btnsave.Text = "Save(&S)";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.button2_Click);
            // 
            // txttitle
            // 
            this.txttitle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txttitle.Location = new System.Drawing.Point(467, 200);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(100, 21);
            this.txttitle.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "Remark";
            // 
            // txtremark
            // 
            this.txtremark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtremark.Location = new System.Drawing.Point(320, 224);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(570, 21);
            this.txtremark.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "FileName";
            // 
            // txtfilename
            // 
            this.txtfilename.Location = new System.Drawing.Point(71, 224);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.Size = new System.Drawing.Size(196, 21);
            this.txtfilename.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "ID";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(71, 200);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(55, 21);
            this.txtid.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "开始日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "结束日期";
            // 
            // btndel
            // 
            this.btndel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndel.Location = new System.Drawing.Point(1331, 200);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 23);
            this.btndel.TabIndex = 33;
            this.btndel.Text = "Del(&D)";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1169, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "New(&N)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtcreator
            // 
            this.txtcreator.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtcreator.Location = new System.Drawing.Point(398, 16);
            this.txtcreator.Name = "txtcreator";
            this.txtcreator.Size = new System.Drawing.Size(83, 21);
            this.txtcreator.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "Creator";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1331, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
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
            this.label10.TabIndex = 16;
            this.label10.Text = "业务";
            // 
            // txtrelor
            // 
            this.txtrelor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtrelor.Location = new System.Drawing.Point(167, 200);
            this.txtrelor.Name = "txtrelor";
            this.txtrelor.Size = new System.Drawing.Size(100, 21);
            this.txtrelor.TabIndex = 17;
            // 
            // cbstatus
            // 
            this.cbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbstatus.FormattingEnabled = true;
            this.cbstatus.Location = new System.Drawing.Point(620, 200);
            this.cbstatus.Name = "cbstatus";
            this.cbstatus.Size = new System.Drawing.Size(100, 20);
            this.cbstatus.TabIndex = 23;
            // 
            // cbsearchstatus
            // 
            this.cbsearchstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchstatus.FormattingEnabled = true;
            this.cbsearchstatus.Location = new System.Drawing.Point(736, 16);
            this.cbsearchstatus.Name = "cbsearchstatus";
            this.cbsearchstatus.Size = new System.Drawing.Size(100, 20);
            this.cbsearchstatus.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "完结人";
            // 
            // txtcompor
            // 
            this.txtcompor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtcompor.Location = new System.Drawing.Point(320, 200);
            this.txtcompor.Name = "txtcompor";
            this.txtcompor.Size = new System.Drawing.Size(100, 21);
            this.txtcompor.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1250, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "流程分享";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbprocessor
            // 
            this.cbprocessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbprocessor.FormattingEnabled = true;
            this.cbprocessor.Location = new System.Drawing.Point(790, 199);
            this.cbprocessor.Name = "cbprocessor";
            this.cbprocessor.Size = new System.Drawing.Size(100, 20);
            this.cbprocessor.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(731, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "处理人员";
            // 
            // cbsearchprocessor
            // 
            this.cbsearchprocessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsearchprocessor.FormattingEnabled = true;
            this.cbsearchprocessor.Location = new System.Drawing.Point(901, 16);
            this.cbsearchprocessor.Name = "cbsearchprocessor";
            this.cbsearchprocessor.Size = new System.Drawing.Size(100, 20);
            this.cbsearchprocessor.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(842, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "处理人员";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(899, 204);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 26;
            this.label14.Text = "Time";
            // 
            // txthour
            // 
            this.txthour.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txthour.Location = new System.Drawing.Point(934, 201);
            this.txthour.Name = "txthour";
            this.txthour.Size = new System.Drawing.Size(46, 21);
            this.txthour.TabIndex = 27;
            // 
            // txtcontent
            // 
            this.txtcontent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtcontent.Location = new System.Drawing.Point(546, 16);
            this.txtcontent.Name = "txtcontent";
            this.txtcontent.Size = new System.Drawing.Size(137, 21);
            this.txtcontent.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(499, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 37;
            this.label15.Text = "Content";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbtip,
            this.toolStripStatusLabel2,
            this.progressBar1,
            this.loadpc});
            this.statusStrip1.Location = new System.Drawing.Point(0, 780);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1425, 22);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "提示信息:";
            // 
            // lbtip
            // 
            this.lbtip.Name = "lbtip";
            this.lbtip.Size = new System.Drawing.Size(56, 17);
            this.lbtip.Text = "【你好】";
            this.lbtip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Margin = new System.Windows.Forms.Padding(10, 3, 1, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            this.progressBar1.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1295, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // loadpc
            // 
            this.loadpc.Image = global::PlanTODO.Properties.Resources.loading;
            this.loadpc.Name = "loadpc";
            this.loadpc.Size = new System.Drawing.Size(16, 17);
            this.loadpc.Visible = false;
            // 
            // planlist
            // 
            this.planlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.planlist.Location = new System.Drawing.Point(12, 47);
            this.planlist.Name = "planlist";
            this.planlist.Size = new System.Drawing.Size(1401, 147);
            this.planlist.TabIndex = 0;
            this.planlist.UseCompatibleStateImageBehavior = false;
            this.planlist.DoubleClick += new System.EventHandler(this.planlist_DoubleClick);
            // 
            // Pasn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 802);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtcontent);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txthour);
            this.Controls.Add(this.cbsearchprocessor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbprocessor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button4);
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
            this.Name = "Pasn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "pasn";
            this.Load += new System.EventHandler(this.Pasn_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbprocessor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbsearchprocessor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txthour;
        private System.Windows.Forms.TextBox txtcontent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbtip;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel loadpc;
    }
}