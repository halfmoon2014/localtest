
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
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
        /// 上传服务器的地址（web服务）
        /// </summary>
        private static string UpFileAdrees = @"http://192.168.35.231/MYUPLOAD/SaveFileWebForm.aspx";
        private static string FileUrl = @"http://192.168.35.231/MYUPLOAD/file/";
        /// <summary>
        /// 列表头信息
        /// </summary>
        List<ListColumn> PlanListColumn = new List<ListColumn>();
        private string name;
        public Pasn(string name)
        {
            InitializeComponent();
            this.name = name;
            this.txtcreator.Text = name;
        }
        private void Pasn_Load(object sender, EventArgs e)
        {
            Init();
            //CheckForIllegalCrossThreadCalls = false;
            Bitmap bmp = (Bitmap)Bitmap.FromFile(Application.StartupPath + "//ico//main.ico");
            Icon ic = Icon.FromHandle(bmp.GetHicon());
            this.Icon = ic;
        }
        public void Init()
        {
            this.loadpc.Visible = false;
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            dtsearchbegin.Format = DateTimePickerFormat.Custom;
            dtsearchbegin.CustomFormat = "yyyy-MM-dd";
            DateTime dt = DateTime.Now;
            dtsearchbegin.Text = dt.AddMonths(-1).ToShortDateString();
            dtsearchend.Format = DateTimePickerFormat.Custom;
            dtsearchend.CustomFormat = "yyyy-MM-dd";

            DataTable dtstatus = new DataTable();
            dtstatus.Columns.Add("Text");
            dtstatus.Columns.Add("Value");
            DataRow dr1 = dtstatus.NewRow();
            DataRow dr2 = dtstatus.NewRow();
            DataRow dr3 = dtstatus.NewRow();
            dr1["Text"] = "进行中";
            dr1["Value"] = "0";
            dr2["Text"] = "完成";
            dr2["Value"] = "1";
            dr3["Text"] = "取消";
            dr3["Value"] = "4";

            dtstatus.Rows.Add(dr1);
            dtstatus.Rows.Add(dr2);
            dtstatus.Rows.Add(dr3);
            this.cbstatus.DataSource = dtstatus;
            this.cbstatus.DisplayMember = "Text";
            this.cbstatus.ValueMember = "Value";
            this.cbstatus.SelectedValue = "0";

            DataTable dtsearstatus = new DataTable();
            dtsearstatus.Columns.Add("Text");
            dtsearstatus.Columns.Add("Value");
            DataRow drr4 = dtsearstatus.NewRow();
            DataRow drr1 = dtsearstatus.NewRow();
            DataRow drr2 = dtsearstatus.NewRow();
            DataRow drr3 = dtsearstatus.NewRow();
            drr1["Text"] = "进行中";
            drr1["Value"] = "0";
            drr2["Text"] = "完成";
            drr2["Value"] = "1";
            drr3["Text"] = "取消";
            drr3["Value"] = "4";
            drr4["Text"] = "全部";
            drr4["Value"] = "-1";
            dtsearstatus.Rows.Add(drr4);
            dtsearstatus.Rows.Add(drr1);
            dtsearstatus.Rows.Add(drr2);
            dtsearstatus.Rows.Add(drr3);
            this.cbsearchstatus.DataSource = dtsearstatus;
            this.cbsearchstatus.DisplayMember = "Text";
            this.cbsearchstatus.ValueMember = "Value";
            this.cbsearchstatus.SelectedValue = "-1";

            loadpc.Location = new System.Drawing.Point((this.Width - loadpc.Width) / 2, (this.Height - loadpc.Height) / 2);
            loadpc.Visible = false;
            loadpc.BringToFront();
            planlist.View = View.Details;
            planlist.CheckBoxes = true;
            planlist.FullRowSelect = true;
            PlanListColumn.Add(new ListColumn("日期", 135, "BizDate"));
            PlanListColumn.Add(new ListColumn("标题", 120, "title"));
            PlanListColumn.Add(new ListColumn("人员", 100, "relor"));
            PlanListColumn.Add(new ListColumn("制单人", 100, "creator"));
            PlanListColumn.Add(new ListColumn("备注", 200, "remark"));
            PlanListColumn.Add(new ListColumn("状态", 100, "Status"));
            PlanListColumn.Add(new ListColumn("内容", 200, "Content"));
            PlanListColumn.Add(new ListColumn("完结人", 120, "compor"));
            PlanListColumn.Add(new ListColumn("完结日期", 120, "compDate"));
            PlanListColumn.Add(new ListColumn("修改人", 120, "modior"));
            PlanListColumn.Add(new ListColumn("修改日期", 120, "modidate"));
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
            string creator = txtcreator.Text;
            string status = "";
            this.Invoke(new Action(() =>
            {
                this.loadpc.Visible = true;
                btnsearch.Enabled = false;
                status = cbsearchstatus.SelectedValue.ToString();
                //Console.WriteLine(this.loadpc.Visible);
            }));
            //Thread.Sleep(500);//看效果用的，可注释
            string statusReq = "";
            if (status != "-1")
                statusReq = "and status like '%" + status + "%'";
            ds = MySqlHelper.ExecuteSQL("select * from pasn where Date(BizDate)  BETWEEN '" + begin + "' and '" + end + "' " + statusReq + " and creator like '%" + creator + "%' order by id desc ");
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
            thread = new Thread(() => SaveWork());
            thread.Start();
        }
        private void SaveWork()
        {
            string content = null;
            string status = "";
            this.Invoke(new Action(() =>
            {
                this.loadpc.Visible = true;
                content = ContentRTB.Text.Replace("\'", "\\\'");
                btnsave.Enabled = false;
                status = cbstatus.SelectedValue.ToString();
            }));
            //Thread.Sleep(500);//看LOADING效果用的
            string filename = txtfilename.Text;
            string title = txttitle.Text;
            string remark = txtremark.Text;
            string id = txtid.Text;
            string relor = txtrelor.Text;

            if (string.IsNullOrEmpty(id))
                filename = NewFileName(filename, relor, title, remark);

            this.Invoke(new Action(() =>
            {
                ContentRTB.SaveFile(FilePath + "\\" + filename + ".rtf", RichTextBoxStreamType.RichText);
                txtfilename.Text = filename;
            }));

            //上传文件到服务器
            try
            {
                int count = UpSound_Request(UpFileAdrees, FilePath + "\\" + filename + ".rtf", filename);
                if (count == 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBoxEx.Show(this, "上传文件服务器失败！，文件只保存在本地");
                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBoxEx.Show(this, "" + ex.GetBaseException());
                }));

            }
            //上传文件到服务器end

            //string content = ContentRTB.Text;

            FileInfo fi = new FileInfo(FilePath + "\\" + filename + ".rtf");
            DateTime dt = fi.LastWriteTime;

            string sql = "";
            if (string.IsNullOrEmpty(id))
            {
                sql = @"insert pasn(title,BizDate,CreateDate,Creator,relor,Remark,Status,Content,filename,lastwritetime) 
                    values('" + title + "',now(),now(),'" + this.name + "','" + relor + "','" + remark + "','" + status + "','" + content + "','" + filename + "','" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "');  select @@IDENTITY; ";
            }
            else
            {
                sql = @"update pasn set relor='" + relor + "',modiDate=now(),modior='" + this.name + "', title='" + title + "',Remark='" + remark + "',Status='" + status + "',Content='" + content + "',lastwritetime='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "'  where id=" + id + ";select " + id + "; ";
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

        public int UpSound_Request(string address, string fileNamePath, string saveName)
        {
            int returnValue = 0;
            //要上传的文件
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            //二进制对象
            BinaryReader r = new BinaryReader(fs);
            //时间戳
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");
            //请求的头部信息
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);
            sb.Append("\";");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sb.ToString());
            // 根据uri创建HttpWebRequest对象   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address));
            httpReq.Method = "POST";
            //对发送的数据不使用缓存   
            httpReq.AllowWriteStreamBuffering = false;
            //设置获得响应的超时时间（300秒）   
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            try
            {
                //每次上传4k  
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength]; //已上传的字节数   
                long offset = 0;
                //开始上传时间   
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();         //发送请求头部消息   
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;
                    this.Invoke(new Action(() =>
                    {
                        lbtip.Text = "已用时：" + second.ToString("F2") + "秒";
                        if (second > 0.001)
                            lbtip.Text += " 平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                        else
                            lbtip.Text += "  正在连接…";
                        lbtip.Text += "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                        lbtip.Text += (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    }));
                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳   
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();
                //获取服务器端的响应   
                WebResponse webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                //读取服务器端返回的消息  
                StreamReader sr = new StreamReader(s);
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString == "Success")
                    returnValue = 1;
                else if (sReturnString == "Error")
                    returnValue = 0;

            }
            catch (SystemException ex)
            {
                returnValue = 0;
            }
            finally
            {
                fs.Close();
                r.Close();
            }
            return returnValue;
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
                cbstatus.SelectedIndex = int.Parse(item["status"].ToString());

                txtremark.Text = item["remark"].ToString();
                txtrelor.Text = item["relor"].ToString();
                if (System.IO.File.Exists(FilePath + "\\" + item["filename"].ToString() + ".rtf"))
                {
                    FileInfo fi = new FileInfo(FilePath + "\\" + item["filename"].ToString() + ".rtf");
                    DateTime dt = fi.LastWriteTime;
                    DataSet ds = MySqlHelper.ExecuteSQL("select * from pasn where id=  " + txtid.Text);
                    DateTime dt1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["lastwritetime"]);
                    TimeSpan span = dt.Subtract(dt1);
                    //如果服务器较新，用服务器的文件，第二次再打开的时候，因为从服务器下载了，所以本地文件会更新
                    if (span.Seconds < 0)
                    {
                        var r = DownLoadFile(FileUrl + item["filename"].ToString() + ".rtf", FilePath + "\\" + item["filename"].ToString() + ".rtf", progressBar1);
                        if (r)
                            ContentRTB.LoadFile(FilePath + "\\" + item["filename"].ToString() + ".rtf", RichTextBoxStreamType.RichText);
                        else
                        {
                            MessageBoxEx.Show(this, "下载文件失败");
                            ContentRTB.Clear();
                        }
                    }else
                    {
                        ContentRTB.LoadFile(FilePath + "\\" + item["filename"].ToString() + ".rtf", RichTextBoxStreamType.RichText);
                    }
                }
                else
                {
                    var r = DownLoadFile(FileUrl + item["filename"].ToString() + ".rtf", FilePath + "\\" + item["filename"].ToString() + ".rtf", progressBar1);
                    if (r)
                        ContentRTB.LoadFile(FilePath + "\\" + item["filename"].ToString() + ".rtf", RichTextBoxStreamType.RichText);
                    else
                    {
                        MessageBoxEx.Show(this, "下载文件失败");
                        ContentRTB.Clear();
                    }
                }
                this.loadpc.Visible = false;
            }));
        }

        /// <summary>
        /// 下载带进度条代码（普通进度条）
        /// </summary>
        /// <param name="URL">网址</param>
        /// <param name="Filename">文件名</param>
        /// <param name="Prog">普通进度条ProgressBar</param>
        /// <returns>True/False是否下载成功</returns>
        public bool DownLoadFile(string URL, string Filename, ProgressBar Prog)
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL); //从URL地址得到一个WEB请求   
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse(); //从WEB请求得到WEB响应   
                long totalBytes = myrp.ContentLength; //从WEB响应得到总字节数   
                Prog.Visible = true;
                Prog.Maximum = (int)totalBytes; //从总字节数得到进度条的最大值   
                System.IO.Stream st = myrp.GetResponseStream(); //从WEB请求创建流（读）   
                System.IO.Stream so = new System.IO.FileStream(Filename, System.IO.FileMode.Create); //创建文件流（写）   
                long totalDownloadedByte = 0; //下载文件大小   
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length); //读流   
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte; //更新文件大小   
                    Application.DoEvents();
                    so.Write(by, 0, osize); //写流   
                    Prog.Value = (int)totalDownloadedByte; //更新进度条   
                    osize = st.Read(by, 0, (int)by.Length); //读流   
                }
                so.Close(); //关闭流
                st.Close(); //关闭流
                Prog.Visible = false;
                return true;
            }
            catch
            {
                return false;
            }
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

            DialogResult result2 = MessageBoxEx.Show(this, "Are you sure to delete", "warn", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
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
                ClearDetail();
                this.loadpc.Visible = false;
                btndel.Enabled = true;
                lbtip.Text = "delete success";
                MessageBoxEx.Show(this, "delete success");
            }));
        }
        private void ClearDetail()
        {
            this.Invoke(new Action(() =>
            {
                ContentRTB.Clear();
                txtfilename.Text = "";
                txttitle.Text = "";
                txtremark.Text = "";
                cbstatus.SelectedIndex = 0;
                txtid.Text = "";
                txtfilename.Text = "";
                txtrelor.Text = "";
                txtcompor.Text = "";
            }));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearDetail();
            lbtip.Text = "new  status ";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Thread thread;
            thread = new Thread(() => SaveComp());
            thread.Start();
        }

        /// <summary>
        /// 完结事件
        /// </summary>
        private void SaveComp()
        {
            string content = null;
            string status = "";
            string compor = txtcompor.Text;
            if (compor.Length == 0)
                compor = this.name;

            this.Invoke(new Action(() =>
            {
                this.loadpc.Visible = true;
                content = ContentRTB.Text.Replace("\'", "\\\'");
                btnsave.Enabled = false;
                //status = cbstatus.SelectedValue.ToString();
                status = "1"; //完成
            }));
            //Thread.Sleep(500);//看LOADING效果用的
            string filename = txtfilename.Text;
            string title = txttitle.Text;
            string remark = txtremark.Text;
            string id = txtid.Text;
            string relor = txtrelor.Text;
            if (string.IsNullOrEmpty(id))
                filename = NewFileName(filename, relor, title, remark);

            this.Invoke(new Action(() =>
            {
                ContentRTB.SaveFile(FilePath + "\\" + filename + ".rtf", RichTextBoxStreamType.RichText);
                txtfilename.Text = filename;
            }));

            string sql = "";
            if (string.IsNullOrEmpty(id))
                sql = @"insert pasn(title,BizDate,CreateDate,Creator,relor,Remark,Status,Content,filename,compor,compDate,lastwritetime) 
                    values('" + title + "',now(),now(),'" + this.name + "','" + relor + "','" + remark + "','" + status + "','" + content + "','" + filename + "','" + compor + "',now(),now());  select @@IDENTITY; ";
            else
                sql = @"update pasn set relor='" + relor + "',modiDate=now(),modior='" + this.name + "', title='" + title + "',Remark='" + remark + "',Status='" + status + "',Content='" + content + "',compor='" + compor + "',compDate=now(),lastwritetime=now()  where id=" + id + ";select " + id + "; ";

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

        private void button4_Click(object sender, EventArgs e)
        {
            Shar shar = new Shar(name);
            shar.Show();
        }

        public string NewFileName(string filename, string relor, string title, string remark)
        {
            if (filename.Length == 0)
            {
                filename = this.name + "_" + relor + "_" + title + "_" + remark;
                filename = filename.Substring(1, 60);//限定最大文件长度
            }
            else
            {
                if (filename.IndexOf(this.name + "_") < 0)
                    filename = this.name + "_" + filename;
            }
            return filename;
        }

    }

}
