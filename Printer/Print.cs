using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Printer
{
    public partial class Print : Form
    {
        
        System.Timers.Timer timerRunner = new System.Timers.Timer();
        double timerRunnerInterval = 5000;
        delegate void SetTextCallback(object obj,string text);
        public delegate void SetStatusCallback(string text);
        SetTextCallback setTextCallback;
        public SetStatusCallback setStatusCallback;
       
        public Print()
        {
            InitializeComponent();
            BtnQuery.Visible = false;
            btnOrderInfo.Visible = false;
        }
        private void SetText(object obj, string text)
        {
            Type t = obj.GetType();
            if (t.Name == "TextBox")
            {
                ((TextBox)obj).Text = text;
            }          
        }

        private void SetStatus(string text)
        {
            toolStripStatusLabel1.Text = text;            
        }
        private void Print_Load(object sender, EventArgs e)
        {
            setTextCallback = new SetTextCallback(SetText);
            setStatusCallback = new SetStatusCallback(SetStatus);

            timerRunner.AutoReset = false; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）            
            timerRunner.Interval = timerRunnerInterval;// 设置时间间隔  
            timerRunner.Elapsed += new System.Timers.ElapsedEventHandler(InvokeMsg); 
            
            Printer.bill.PrintCore printCore = new bill.PrintCore();
            string text = printCore.findPrt();
            this.Invoke(setStatusCallback, new object[] {text });
            if (text.IndexOf("查不到名称") < 0)
            {   
                timerRunner.Start();
                toolStripBtnStatus.Text = "服务已开始";
            }
            else
            {                
                toolStripBtnStatus.Text = "服务已停止";
            }            
        }
        public void InvokeMsg(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerRunner.Stop();          
            Printer.bill.PrintCore printCore = new bill.PrintCore();
            printCore.Done(this);
            timerRunner.Start();
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            Set frm = new Set();
            frm.ShowDialog();
        }

        private void refPrt_Click(object sender, EventArgs e)
        {
            Printer.bill.PrintCore printCore = new bill.PrintCore();
            string text = printCore.findPrt();
            this.Invoke(setStatusCallback, new object[] { text });
            if (text.IndexOf("查不到名称") < 0)
            {
                timerRunner.Start();
                toolStripBtnStatus.Text = "服务已开始";
            }
            else
            {
                MessageBoxEx.Show("没有打印机");
                toolStripBtnStatus.Text = "服务已停止";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            imgForm1 frm = new imgForm1();
            frm.ShowDialog();
        }

        private void toolStripBtnStatus_Click(object sender, EventArgs e)
        {
            if (timerRunner.Enabled)
            {
                timerRunner.Stop();
                toolStripBtnStatus.Text = "服务已停止";
            }
            else
            {
                timerRunner.Start();
                toolStripBtnStatus.Text = "服务已开始";
            }
        }
    }
}