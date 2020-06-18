using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Printer
{
    public partial class Print : Form
    {
        PrintDocument PrintDoc = new PrintDocument();
        //LoadFace loading;
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {
            findPrt();
            //bool isFind = false;
            //foreach (string pName in PrinterSettings.InstalledPrinters)
            //{
            //    if (PrinterName.Trim().ToUpper() == pName.Trim().ToUpper())
            //    {
            //        PrintDoc.PrinterSettings.PrinterName = PrinterName;
            //        isFind = true;
            //        break;
            //    }
            //}
            //if (isFind)
            //{
            //    setPrint();

            //}
        }

        public void getData() {

            //loading.show();
            Thread thread = new Thread(getDataTH);
            thread.IsBackground = true;
            thread.Start();
        }
        private void getDataTH()
        {
            try
            {

                //WebService.LabelPrint serv = new WebService.LabelPrint();
                ////WebReference.LabelPrint serv = new WebReference.LabelPrint();
                //string code = txtBarCode.Text;
                //string rel = serv.BarCodeOrderId(code);
                //List<OrderLabelInfo> Labels = Serializer.XmlDeSerialize<List<OrderLabelInfo>>(rel);
                //if (Labels.Count == 0)
                //{
                //    MessageBox.Show("找不到该条码");
                //    return;
                //}
                //foreach (OrderLabelInfo lable in Labels)
                //{
                //    if (!dictLable.ContainsKey(lable.Sphh))
                //        dictLable.Add(lable.Sphh, lable);
                //}
                ///*条码明细*/
                //rel = serv.BarCodeDetail(code);
                //Form1.log.InfoFormat("单个条码返回：{0}", rel);
                //OrderLabelDetail detail = Serializer.XmlDeSerialize<OrderLabelDetail>(rel);
                //ListViewItem lvi = new ListViewItem(new string[] { detail.Spid, detail.Tm, detail.Qrcode, detail.Hx, detail.Lsdj, detail.Epc });
                //DetailList.Add(detail);

                //listView1.Items.Add(lvi);
                //txtBarCode.Text = "";
            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel1.Text = ex.Message;
            }
            //loading.hide();
        }
        /// <summary>
        /// 刷新打印机的状态
        /// </summary>
        public void findPrt()
        {
            string PrinterName = Properties.Settings.Default.PrtName;
            bool isFind = false;
            foreach (string pName in PrinterSettings.InstalledPrinters)
            {
                if (PrinterName.Trim().ToUpper() == pName.Trim().ToUpper())
                {
                    PrintDoc.PrinterSettings.PrinterName = PrinterName;
                    isFind = true;
                    break;
                }
            }
            if (!isFind)
                this.toolStripStatusLabel1.Text = "查不到名称:" + PrinterName + "打印机";
            else
                this.toolStripStatusLabel1.Text = "名称:"+PrinterName + "已找到";
        }
        public void setPrint()
        {
            PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc2_PrintPage);
        }
        private void PrintDoc2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Millimeter; //单位为毫米 
            Tag_Draw(0, 0, e.Graphics);
        }

        private void Tag_Draw(int topx, int topy, Graphics grap)
        {
            Font FontName = new Font("微软雅黑", 6, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            grap.DrawString("品名", FontName, brush, new Point(10, 10));
        }
        public void print()
        {
            //LeftMargin = (Properties.Settings.Default.PageWeigth - LabelWidth * (PageLableCount / 2)) / 2;
            //topMargin = (Properties.Settings.Default.PageHeigth - (LabelTotalHeigth * 2 + 6)) / 2;
            //PageLabelRowCount = PageLableCount / 2;
            //pagelabel = new PageLabelinfo(PageLableCount);
            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = PrintDoc;

            //if (MyPrintDg.ShowDialog() == DialogResult.OK)
            //{
            try
            {
                PrintDoc.Print();
            }
            catch (Exception ex)
            {   //停止打印
                MessageBox.Show(ex.ToString());
                PrintDoc.PrintController.OnEndPrint(PrintDoc, new System.Drawing.Printing.PrintEventArgs());
            }
            //}
        }


        private void BtnSet_Click(object sender, EventArgs e)
        {
            Set frm = new Set();
            frm.ShowDialog();
        }

        private void refPrt_Click(object sender, EventArgs e)
        {
            findPrt();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            imgForm1 frm = new imgForm1();
            frm.ShowDialog();
        }
    }
}