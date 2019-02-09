
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace PlanTODO
{
    public partial class Pasn : Form
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        private static string FilePath = string.Concat(System.Windows.Forms.Application.StartupPath, "\\file");

        /// <summary>
        /// 列表头信息
        /// </summary>
        List<ListColumn> PlanListColumn = new List<ListColumn>();

        public Pasn()
        {
            InitializeComponent();
        }
        private void Pasn_Load(object sender, EventArgs e)
        {
            Init();
            //CheckForIllegalCrossThreadCalls = false;
        }
        public void Init()
        {
            this.loadpc.Visible = false;
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            dtsearchbegin.Format = DateTimePickerFormat.Custom;
            dtsearchbegin.CustomFormat = "yyyy-MM-dd";
            dtsearchend.Format = DateTimePickerFormat.Custom;
            dtsearchend.CustomFormat = "yyyy-MM-dd";

            loadpc.Location = new System.Drawing.Point((this.Width - loadpc.Width) / 2, (this.Height - loadpc.Height) / 2);
            loadpc.Visible = false;
            loadpc.BringToFront();
            planlist.View = View.Details;
            planlist.CheckBoxes = true;
            planlist.FullRowSelect = true;
            PlanListColumn.Add(new ListColumn("日期", 135, "BizDate"));
            PlanListColumn.Add(new ListColumn("标题", 120, "title"));
            PlanListColumn.Add(new ListColumn("制单人", 100, "creator"));
            PlanListColumn.Add(new ListColumn("备注", 200, "remark"));
            PlanListColumn.Add(new ListColumn("状态", 100, "Status"));
            PlanListColumn.Add(new ListColumn("内容", 200, "Content"));
            PlanListColumn.Add(new ListColumn("文件名", 120, "filename"));
            PlanListColumn.Add(new ListColumn("id", 0, "id"));
            foreach (ListColumn l in PlanListColumn)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = l.Text;
                ch.Width = l.Width;
                ch.TextAlign = l.M;
                planlist.Columns.Add(ch);    //将列头添加到ListView控件。
            }

            //LoadingHelper.ShowLoading("有朋自远方来，不亦乐乎。", this, o =>
            //{
            //    //这里写处理耗时的代码，代码处理完成则自动关闭该窗口
            //});
            //this.loadpc.Visible = true;
            Thread thread;
            thread = new Thread(() => GetPlanListData());
            thread.Start();
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        private void GetPlanListData()
        {
            DataSet ds = null;
            string begin = null, end = null;
            begin = dtsearchbegin.Text;
            end = dtsearchend.Text;
            string status = txtsearchstatus.Text;
            this.Invoke(new Action(() =>
            {
                this.loadpc.Visible = true;
                btnsearch.Enabled = false;
                //Console.WriteLine(this.loadpc.Visible);
            }));
            //Thread.Sleep(500);//看效果用的，可注释
            ds = MySqlHelper.ExecuteSQL("select * from pasn where Date(BizDate)  BETWEEN '" + begin + "' and '" + end + "' and status like '%"+status+"%' order by id desc ");
            this.Invoke(new Action(() =>
            {
                CreateListView(ds);
                this.loadpc.Visible = false;
                btnsearch.Enabled = true;
                lbtip.Text = "refresh success";
                //Console.WriteLine(this.loadpc.Visible);
            }));

        }
        /// <summary>
        /// 加载列表
        /// </summary>
        /// <param name="ds"></param>
        private void CreateListView(DataSet ds)
        {
            planlist.BeginUpdate();//防listview闪烁开始
            planlist.Items.Clear();
            List<string> list = new List<string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Clear();
                foreach (ListColumn l in PlanListColumn)
                    list.Add(dr[l.Key].ToString());

                ListViewItem lvi = new ListViewItem(list.ToArray());
                lvi.Tag = dr;
                planlist.Items.Add(lvi);
            }
            planlist.EndUpdate();//防listview闪烁结束            
        }



        /// <summary>
        /// 新增、保存内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread;
            thread = new Thread(() => saveWork());
            thread.Start();
        }
        private void saveWork()
        {
            string content = null;
            this.Invoke(new Action(() =>
            {
                this.loadpc.Visible = true;
                content = ContentRTB.Text;
                btnsave.Enabled = false;
            }));
            //Thread.Sleep(500);//看LOADING效果用的
            string filename = txtfilename.Text;
            string title = txttitle.Text;
            string remark = txtremark.Text;
            string status = txtstatus.Text;
            string id = txtid.Text;
            if (string.IsNullOrEmpty(id))
                filename = Guid.NewGuid().ToString("N");

            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "RTF文件(*.rtf)|*.rtf";
            //saveFileDialog1.DefaultExt = "rtf";//默认的文件扩展名
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            this.Invoke(new Action(() =>
            {
                ContentRTB.SaveFile(FilePath + "\\" + filename + ".rtf", RichTextBoxStreamType.RichText);
                txtfilename.Text = filename;
            }));

            //string content = ContentRTB.Text;

            string sql = "";
            if (string.IsNullOrEmpty(id))
            {
                sql = @"insert pasn(title,BizDate,CreateDate,Creator,Remark,Status,Content,filename) 
                    values('" + title + "',now(),now(),'sys','" + remark + "','" + status + "','" + content + "','" + filename + "');  select @@IDENTITY; ";
            }
            else
            {
                sql = @"update pasn set title='" + title + "',Remark='" + remark + "',Status='" + status + "',Content='" + content + "'  where id=" + id + ";select " + id + "; ";
            }
            DataSet ds = MySqlHelper.ExecuteSQL(sql);
            this.Invoke(new Action(() =>
            {
                txtid.Text = ds.Tables[0].Rows[0][0].ToString();
                this.loadpc.Visible = false;
                btnsave.Enabled = true;
                lbtip.Text = "save success";
                MessageBoxEx.Show(this, "save success");
            }));

        }

        private void planlist_DoubleClick(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "ListViewEx")
            {
                Thread thread;
                thread = new Thread(() => planlist_DoubleClickWork((ListView)sender, e));
                thread.Start();
            }
        }
        private void planlist_DoubleClickWork(ListView l, EventArgs e)
        {

            this.Invoke(new Action(() =>
            {
                DataRow item = null;
                this.loadpc.Visible = true;
                item = (DataRow)(l.SelectedItems[0]).Tag;
                txtid.Text = item["id"].ToString();
                txtfilename.Text = item["filename"].ToString();
                txttitle.Text = item["title"].ToString();
                txtstatus.Text = item["status"].ToString();
                txtremark.Text = item["remark"].ToString();
                if (System.IO.File.Exists(FilePath + "\\" + item["filename"].ToString() + ".rtf"))
                    ContentRTB.LoadFile(FilePath + "\\" + item["filename"].ToString() + ".rtf", RichTextBoxStreamType.RichText);
                else
                    ContentRTB.Clear();
                this.loadpc.Visible = false;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread;
            thread = new Thread(() => GetPlanListData());
            thread.Start();
        }

        private void Pasn_ResizeEnd(object sender, EventArgs e)
        {
            loadpc.Location = new System.Drawing.Point((this.Width - loadpc.Width) / 2, (this.Height - loadpc.Height) / 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadpc.Visible = true;
            //MessageBox.Show(loadpc.Visible.ToString());
        }

        private void btndel_Click(object sender, EventArgs e)
        {  

            DialogResult result2 =MessageBoxEx.Show(this, "Are you sure to delete", "warn", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            //MessageBoxEx.Show(this,result.ToString());
            if (result2 == DialogResult.OK)
            {
                Thread thread;
                thread = new Thread(() => btndel_ClickWork(sender, e));
                thread.Start();
            }
        }
        private void btndel_ClickWork(object sender, EventArgs e)
        {
            
            this.Invoke(new Action(() =>
            {
                this.loadpc.Visible = true;                
                btndel.Enabled = false;
            }));          
            string filename = txtfilename.Text;            
            this.Invoke(new Action(() =>
            {
                if (File.Exists(FilePath + "\\" + filename + ".rtf"))
                    File.Delete(FilePath + "\\" + filename + ".rtf");                
            }));
            string id = txtid.Text;
            string sql = "";
            if (!string.IsNullOrEmpty(id))            
            {
                sql = @"delete from  pasn   where id=" + id + ";select " + id + "; ";
            }
            DataSet ds = MySqlHelper.ExecuteSQL(sql);
            this.Invoke(new Action(() =>
            {
                clearDetail();
                this.loadpc.Visible = false;
                btndel.Enabled = true;
                lbtip.Text = "delete success";
                MessageBoxEx.Show(this, "delete success");
            }));
        }
        private void clearDetail()
        {
            this.Invoke(new Action(() =>
            {
                ContentRTB.Clear();
                txtfilename.Text = "";
                txttitle.Text = "";
                txtremark.Text = "";
                txtstatus.Text = "";
                txtid.Text = "";
                txtfilename.Text = "";

            }));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clearDetail();
            lbtip.Text = "new  status ";
        }
    }

}
