using PlanGo.DTO;
using PlanGo.SqlServerService;
using PlanGo.Tools;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PlanGo
{
    public partial class Plan : CommForm
    {
        static Thread WathchThread;
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        /// <summary>
        /// 文件路径
        /// </summary>
        private static readonly string FilePath = string.Concat(System.Windows.Forms.Application.StartupPath, "\\file");
        /// <summary>
        /// 上传服务器的地址（web服务）
        /// </summary>
        private static readonly string UpFileAdrees = @"http://192.168.35.231/MYUPLOAD/SaveFileWebForm.aspx";
        private static readonly string FileUrl = @"http://192.168.35.231/MYUPLOAD/file/";
        private static readonly int FilenameMaxLen = 60;
        List<Record> Records = new List<Record>();
        private static readonly List<User> Users = new List<User>();
        /// <summary>
        /// 列表头信息
        /// </summary>
        //List<ListColumn> PlanListColumn = new List<ListColumn>();
    
        private Dictionary<string, string> StatusDataList;
        /// <summary>
        /// 登陆线程
        /// </summary>
        //static Thread loginThread;
        private readonly LoginDto Login;
        public Plan()
        {
            InitializeComponent();
            Init(uiStyleManager1);
            loadpc.Location = new System.Drawing.Point((Width - loadpc.Width) / 2, (Height - loadpc.Height) / 2);
           
        }
        public Plan(LoginDto loginDto) : this()
        {
            this.Login = loginDto;
        }

        public void FormInit()
        {

            SQLUtilEvent sQLUtilEvent = new SQLUtilEvent("select * from users");
            sQLUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object senders, RunWorkerCompletedEventArgs es) =>
            {
                DataSet ds = (DataSet)es.Result;
             
                ArrayList processor = new ArrayList();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    User u = new User();
                    u.Id = int.Parse(dr["id"].ToString());
                    u.UserId = dr["UserId"].ToString();
                    u.UserName = dr["UserName"].ToString();
                    u.Ty = int.Parse(dr["ty"].ToString());
                    if (u.Ty == 0) processor.Add(u.UserName);
                    Users.Add(u);
                    
                }

                SetComBoxDataSource(cbprocessor,(string[])processor.ToArray(typeof(string)), Login.Username);
                processor.Add("全部");
                SetComBoxDataSource(cbsearchprocessor, (string[])processor.ToArray(typeof(string)), "全部");


            });
            sQLUtilEvent.Run("sql");

            Console.WriteLine("Init");
            loadpc.Visible = false;
         
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
       
                     //dtsearchbegin.Format = DateTimePickerFormat.Custom;
                     //dtsearchbegin.CustomFormat = "yyyy-MM-dd";
                     DateTime dt = DateTime.Now;
            dtsearchbegin.Text = dt.AddMonths(-1).ToString("yyy-MM-dd");
            dtsearchend.Text = dt.ToString("yyy-MM-dd");
            estimateDate.Text = dt.ToString("yyy-MM-dd");
            //dtsearchend.Format = DateTimePickerFormat.Custom;
            //dtsearchend.CustomFormat = "yyyy-MM-dd";
            //estimateDate.Format = DateTimePickerFormat.Custom;
            //estimateDate.CustomFormat = "yyyy-MM-dd";
            StatusDataList = new Dictionary<string, string>() { { "0", "进行中" }, { "1", "完成" }, { "4", "取消" } };
            SetComBoxDataSource(cbstatus, StatusDataList, "0");
            //SetCB(cbprocessor, new string[] { "张茂洪", "高嘉富", "林自强", "钟少杰" }, loginDto.Username);
            //SetCB(cbsearchprocessor, new string[] { "张茂洪", "高嘉富", "林自强", "钟少杰", "全部" }, "全部");
            SetComBoxDataSource(cbsearchstatus, new Dictionary<string, string>() { { "0", "进行中" }, { "1", "完成" }, { "4", "取消" }, { "-1", "全部" } }, "-1");


            //planlist.View = View.Details;
            //planlist.CheckBoxes = false;
            //planlist.FullRowSelect = true;
            //PlanListColumn.Add(new ListColumn("日期", 135, "BizDate"));
            //PlanListColumn.Add(new ListColumn("标题", 120, "title"));
            //PlanListColumn.Add(new ListColumn("业务", 100, "relor"));

            //PlanListColumn.Add(new ListColumn("预计完成", 100, "estimate"));
            //PlanListColumn.Add(new ListColumn("状态", 100, "Status"));
            //PlanListColumn.Add(new ListColumn("内容", 200, "Content"));
            //PlanListColumn.Add(new ListColumn("完结人", 120, "compor"));
            //PlanListColumn.Add(new ListColumn("完结日期", 120, "compDate"));
            //PlanListColumn.Add(new ListColumn("修改人", 120, "modior"));
            //PlanListColumn.Add(new ListColumn("修改日期", 120, "modidate"));
            //PlanListColumn.Add(new ListColumn("文件名", 120, "filename"));
            //PlanListColumn.Add(new ListColumn("制单人", 100, "creator"));
            //PlanListColumn.Add(new ListColumn("备注", 200, "remark"));
            //PlanListColumn.Add(new ListColumn("id", 0, "id"));
            //foreach (ListColumn l in PlanListColumn)
            //{
            //    ColumnHeader ch = new ColumnHeader();
            //    ch.Text = l.Text;
            //    ch.Width = l.Width;
            //    ch.TextAlign = l.M;
            //    planlist.Columns.Add(ch);    //将列头添加到ListView控件。
            //}
            uiDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uiDataGridView1.AutoGenerateColumns = false;
            
            //uiDataGridView1.AddColumn("日期", "BizDate", 135);
            //uiDataGridView1.AddColumn("标题", "title", 120);
            //uiDataGridView1.AddColumn("业务", "relor", 100);
            //uiDataGridView1.AddColumn("预计完成", "estimate", 100);
            //uiDataGridView1.AddColumn("状态", "Status", 100);
            //uiDataGridView1.AddColumn("内容", "Content", 200);
            //uiDataGridView1.AddColumn("完结人", "Compor", 120);
            //uiDataGridView1.AddColumn("完结日期", "compDate", 120);
            //uiDataGridView1.AddColumn("修改人", "modior", 120);
            //uiDataGridView1.AddColumn("修改日期", "modidate", 120);
            //uiDataGridView1.AddColumn("文件名", "filename", 120);
            //uiDataGridView1.AddColumn("制单人", "creator", 100);
            //uiDataGridView1.AddColumn("备注", "remark", 200);
            uiDataGridView1.ReadOnly = true;
            uiDataGridView1.CellFormatting +=
            (object sen, DataGridViewCellFormattingEventArgs ev) =>
            {
                DataGridView dgv = (DataGridView)sen;
                //得到当前要进行格式化设置的列  
                DataGridViewColumn column = uiDataGridView1.Columns[ev.ColumnIndex];
                if (ev.Value == null) return;
                
                if (column.Name.EqualsIgnoreCase("Status"))      
                {
                    ev.Value = (ev.Value.ToString() == "0" ? "" : "√");
                }else if (column.Name.EqualsIgnoreCase("modior")  || column.Name.EqualsIgnoreCase("creator"))
                {
                    for (int i = 0; i < Users.Count; i++)
                    {
                        if (Users[i].UserId.EqualsIgnoreCase(ev.Value.ToString()))
                        {
                            ev.Value= Users[i].UserName;
                        }
                    }
                }
               
            };

            for (int j = 0; j < uiDataGridView1.Columns.Count; j++)
            {
                string colName = uiDataGridView1.Columns[j].DataPropertyName;
                 
                if (colName.EqualsIgnoreCase("Status"))
                {
                    uiDataGridView1.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    uiDataGridView1.Columns[j].Width = 50;
                }
                else if (colName.EqualsIgnoreCase("BizDate") || colName.EqualsIgnoreCase("estimate") || colName.EqualsIgnoreCase("compDate") || colName.EqualsIgnoreCase("modidate"))
                {
                    uiDataGridView1.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    uiDataGridView1.Columns[j].Width = 100;
                }
                else if (colName.EqualsIgnoreCase("relor") || colName.EqualsIgnoreCase("Compor") || colName.EqualsIgnoreCase("modior") || colName.EqualsIgnoreCase("creator"))
                {
                    uiDataGridView1.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    uiDataGridView1.Columns[j].Width = 70;
                }
            }

        }
        int panel1NormalHeight;
        int uiDataGridView1NormalHeight;
        int uiDataGridView1MaxHeight=500;
        System.Drawing.Point panel1Point;
        protected override void WndProc(ref Message m)
        {
            FormWindowState preState = this.WindowState;
            base.WndProc(ref m);
            FormWindowState currentState = this.WindowState;
            if(preState != currentState && currentState == FormWindowState.Maximized)
            {
                //ContentRTB.Height = ContentRTB.Height - (uiDataGridView1MaxHeight - uiDataGridView1.Height);
                panel1.Height = panel1.Height - (uiDataGridView1MaxHeight - uiDataGridView1.Height);
                panel1.Location = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y + (uiDataGridView1MaxHeight - uiDataGridView1.Height));             
                uiDataGridView1.Height = uiDataGridView1MaxHeight;                
            }

            if(this.WindowState== FormWindowState.Normal && uiDataGridView1NormalHeight==0)
            {//初始化
                uiDataGridView1NormalHeight = uiDataGridView1.Height;
                panel1NormalHeight = panel1.Height;
                panel1Point = panel1.Location;
                Console.WriteLine(uiDataGridView1NormalHeight);
            }
            if (currentState == FormWindowState.Normal)
            {//缩到正常大小               
                if (preState != currentState && uiDataGridView1NormalHeight>0)
                {
                    uiDataGridView1.Height = uiDataGridView1NormalHeight;
                    panel1.Height = panel1NormalHeight;
                    panel1.Location = panel1Point;
                }
            }

        }

        /// <summary>
        /// 初始comb
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="selectedValue"></param>
        private void SetComBoxDataSource(UIComboBox cb, string[] dataSource, string selectedValue)
        {
            Dictionary<string, string> ds = new Dictionary<string, string>();
            foreach (string s in dataSource)
                ds.Add(s, s);
            SetComBoxDataSource(cb, ds, selectedValue);
        }
        /// <summary>
        /// 初始comb2
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="selectedValue"></param>
        private void SetComBoxDataSource(UIComboBox cb, Dictionary<string, string> dataSource, string selectedValue)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Text");
            //dt.Columns.Add("Value");
            //foreach (string key in dataSource.Keys)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["Text"] = dataSource[key];
            //    dr["Value"] = key;
            //    dt.Rows.Add(dr);
            //}
            //cb.DataSource = dt;
            //cb.DisplayMember = "Text";
            //cb.ValueMember = "Value";
            //cb.SelectedValue = selectedValue;

            IList<Info> infoList = new List<Info>();

            foreach (string key in dataSource.Keys)
            {
                Info info1 = new Info() { Id = key, Name = dataSource[key] };
                infoList.Add(info1);
            }
            cb.ValueMember = "Id";
            cb.DisplayMember = "Name";
            cb.DataSource = infoList;
            cb.SelectedValue = selectedValue;

        }

   

        private void Plan_Load(object sender, EventArgs e)
        {
            FormInit();
        }
         

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            SQLUtilEvent sQLUtilEvent = new SQLUtilEvent(GetPlanListData());
            sQLUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object senders, RunWorkerCompletedEventArgs es) =>
            {
                DataSet ds = (DataSet)es.Result;
                CreateListView(ds.Tables[0]);
                listStatus.Text = "总记录数：" + ds.Tables[0].Rows.Count;
                BtnNew_Click(null, EventArgs.Empty);
                loadpc.Visible = false;
                btnsearch.Enabled = true;
                lbtip.Text = "refresh success";
            });
            sQLUtilEvent.Run("sql");
        }
        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearDetail();
            lbtip.Text = "new  status ";
        }
     

        /// <summary>
        /// 清除详情区
        /// </summary>
        private void ClearDetail()
        {
            this.Invoke(new Action(() =>
            {
                //ContentRTB.Clear();
                ContentRTB.Text = "";
                txtfilename.Text = "";
                txttitle.Text = "";
                txthour.Text = "";
                txtremark.Text = "";
                cbstatus.SelectedIndex = 0;
                cbprocessor.SelectedIndex = 0;
                txtid.Text = "";
                txtrelor.Text = "";
                txtcompor.Text = "";
                uiDataGridView1.ClearSelection();
                uiDataGridView1.CurrentCell = null;
            }));
        }

        private void FileEdit_Click(object sender, EventArgs e)
        {
            if (File.Exists(FilePath + "\\" + txtfilename.Text + ".rtf"))
            {
                DataFileView(FilePath + "\\" + txtfilename.Text + ".rtf");
                try
                {
                    FileInfo fi = new FileInfo(FilePath + "\\" + txtfilename.Text + ".rtf");

                    if (WathchThread != null) WathchThread.Abort();
                    WathchThread = new Thread(() => WacthFile(txtfilename.Text, fi.LastWriteTime));
                    WathchThread.Start();
                }
                catch (SystemException ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        ShowMessageDialog(ex.Message);
                    }));
                }
            }
            else
            {
                ShowMessageDialog("请先打开一个任务");                
            }
        }

        /// <summary>
        /// 监视文件
        /// </summary>
        private void WacthFile(string filePath, DateTime oldDt)
        {

            if (!txtfilename.Text.Equals(filePath)) return;

            FileInfo fi = new FileInfo(FilePath + "\\" + filePath + ".rtf");
            DateTime dt = fi.LastWriteTime;
            TimeSpan span = oldDt.Subtract(dt);
            if (span.Seconds < 0)
            {
                this.Invoke(new Action(() =>
                {

                    IntPtr vHandle = _lopen(FilePath + "\\" + filePath + ".rtf", OF_READWRITE | OF_SHARE_DENY_NONE);
                    if (vHandle == HFILE_ERROR)
                    {
                        return;
                    }
                    else
                    {
                        CloseHandle(vHandle);     //判断之后一定要关闭！！！
                        oldDt = dt;
                        System.Console.WriteLine(dt);
                        ContentRTB.LoadFile(FilePath + "\\" + filePath + ".rtf", RichTextBoxStreamType.RichText);
                    }
                }));

            }
            Console.WriteLine("WacthFile" + DateTime.Now.ToString());
            fi = null;
            Thread.Sleep(1000);
            //如果当前编辑的文件和当前处理的文件一致的时候            
            WacthFile(filePath, oldDt);
        }

        private void DataFileView(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = filePath;
            psi.UseShellExecute = true;

            Process.Start(psi);
        }

        private string GetPlanListData()
        {
            string begin = dtsearchbegin.Text, end = dtsearchend.Text;
            string creator = txtcreator.Text.Trim();
            string status = cbsearchstatus.SelectedValue.ToString();
            string processor = cbsearchprocessor.SelectedValue.ToString();
            string content = txtcontent.Text.Trim();

            loadpc.Visible = true;
            btnsearch.Enabled = false;

            //Console.WriteLine(this.loadpc.Visible);
            //}));
            //Thread.Sleep(500);//看效果用的，可注释
            string statusReq = "";
            if (status != "-1")
                statusReq += "and status like '%" + status + "%'";
            if (processor != "全部")
                statusReq += "and processor like '%" + processor + "%'";
            if (content != "")
                statusReq += "and CONCAT(remark,content,title,relor) like '%" + content + "%'";

            return "select * from pasn where Date(BizDate)  BETWEEN '" + begin + "' and '" + end + "' " + statusReq + " and creator like '%" + creator + "%' order by BizDate desc ";


        }

        /// <summary>
        /// 加载列表
        /// </summary>
        /// <param name="ds"></param>
        private void CreateListView(DataTable dt)
        {
            //planlist.BeginUpdate();//防listview闪烁开始
            //planlist.Items.Clear();
            //List<string> list = new List<string>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    list.Clear();
            //    foreach (ListColumn l in PlanListColumn)
            //    {
            //        if (l.Key.Equals("Status"))
            //        {
            //            string val = "";
            //            foreach (string k in cbStatusList.Keys)
            //            {
            //                if (k.Equals(dr[l.Key].ToString()))
            //                    val = cbStatusList[k];
            //            }
            //            list.Add(val);
            //        }
            //        else list.Add(dr[l.Key].ToString());
            //    }

            //    ListViewItem lvi = new ListViewItem(list.ToArray());
            //    lvi.Tag = dr;
            //    planlist.Items.Add(lvi);
            //}
            //planlist.EndUpdate();//防listview闪烁结束
            //uiDataGridView1.ClearAll();
            uiDataGridView1.DataSource = null;
            ToDatas(dt);
            uiDataGridView1.DataSource = Records;

        }

        private void ToDatas(DataTable dt) {
            Records.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                Record data = new Record();
                data.BizDate = strToDateTime(dr["BizDate"].ToString());
                data.Title = dr["title"].ToString();
                data.Relor = dr["relor"].ToString();
                data.Estimate = strToDateTime(dr["estimate"].ToString());
                data.Status = dr["Status"].ToString();
                data.Content = dr["Content"].ToString();
                data.Compor = dr["compor"].ToString();
                data.CompDate = strToDateTime(dr["compDate"].ToString());
                data.Modior = dr["modior"].ToString();
                data.Modidate = strToDateTime(dr["modidate"].ToString());
                data.Filename = dr["filename"].ToString();
                data.Creator = dr["creator"].ToString();
                data.Remark = dr["remark"].ToString();
                data.Id = int.Parse(dr["id"].ToString());
                data.Hour = decimal.Parse(dr["hour"].ToString());
                data.Processor = dr["processor"].ToString();

                Records.Add(data);
            }
        }
  
      
        private void Planlist_DoubleClick(object sender, EventArgs e)
        {
           

            if (sender.GetType().Name == "UIDataGridView")
            {
                UIDataGridView t=(UIDataGridView)sender;
                Thread thread;
                thread = new Thread(() => Planlist_DoubleClickWork2(Records[t.SelectedIndex], e));
                thread.Start();
            }

        }

        private void Planlist_DoubleClickWork2(Record item, EventArgs e)
        {

            this.Invoke(new Action(() =>
            {
               
                loadpc.Visible = true;
                txtcompor.Text = item.Compor.ToLower();
                txtid.Text = item.Id.ToString();
                txtfilename.Text = item.Filename.ToString();
                txttitle.Text = item.Title.ToString();
                txthour.Text = item.Hour.ToString();
                
                cbstatus.SelectedIndex = int.Parse((item.Status.ToString()==""?"0": item.Status.ToString()) );
                cbprocessor.SelectedValue = item.Processor.ToString();

                txtremark.Text = item.Remark.ToString();
                estimateDate.Text = item.Estimate.ToString();
                txtrelor.Text = item.Relor.ToString();
                if (File.Exists(FilePath + "\\" + item.Filename.ToString() + ".rtf"))
                {

                    IntPtr vHandle = _lopen(FilePath + "\\" + item.Filename.ToString() + ".rtf", OF_READWRITE | OF_SHARE_DENY_NONE);
                    if (vHandle == HFILE_ERROR)
                    {
                        ShowMessageDialog("文件被占用");
                        ContentRTB.Text = "";
                        return;
                    }
                    CloseHandle(vHandle);     //判断之后一定要关闭！！！

                    FileInfo fi = new FileInfo(FilePath + "\\" + item.Filename.ToString() + ".rtf");
                    DateTime dt = fi.LastWriteTime;
                    DataSet ds = MySqlHelper.ExecuteSQL("select * from pasn where id=  " + txtid.Text);
                    DateTime dt1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["lastwritetime"]);
                    TimeSpan span = dt.Subtract(dt1);
                    //如果服务器较新，用服务器的文件，第二次再打开的时候，因为从服务器下载了，所以本地文件会更新
                    if (span.Seconds < 0)
                    {
                        var r = DownLoadFile(FileUrl + item.Filename.ToString() + ".rtf", FilePath + "\\" + item.Filename.ToString() + ".rtf", progressBar1);
                        if (r)
                            ContentRTB.LoadFile(FilePath + "\\" + item.Filename.ToString() + ".rtf", RichTextBoxStreamType.RichText);
                        else
                        {
                            ShowMessageDialog("下载文件失败");
                            ContentRTB.Text = "";
                        }
                    }
                    else
                    {
                        ContentRTB.LoadFile(FilePath + "\\" + item.Filename.ToString() + ".rtf", RichTextBoxStreamType.RichText);
                    }
                }
                else
                {
                    var r = DownLoadFile(FileUrl + item.Filename.ToString() + ".rtf", FilePath + "\\" + item.Filename.ToString() + ".rtf", progressBar1);
                    if (r)
                        ContentRTB.LoadFile(FilePath + "\\" + item.Filename.ToString() + ".rtf", RichTextBoxStreamType.RichText);
                    else
                    {

                        ShowMessageDialog("下载文件失败");
                        ContentRTB.Text = "";
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
        public bool DownLoadFile(string URL, string Filename, ToolStripProgressBar Prog)
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

        private void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveWork();
            }
            catch (SystemException ex)
            {
                ShowMessageDialog(ex.Message);                
            }
        }

        /// </summary>
        private void SaveWork()
        {
            string content = null;
            string status = "";
            string processor = "";
            string compor = "";
            string estimate = "";

            loadpc.Visible = true;
            content = ContentRTB.Text.Replace("\'", "\\\'");
            estimate = estimateDate.Text;
            btnsave.Enabled = false;
            status = cbstatus.SelectedValue.ToString();
            processor = cbprocessor.SelectedValue.ToString();
            compor = txtcompor.Text.ToString();

            string filename = txtfilename.Text;
            string title = txttitle.Text;
            string hour = txthour.Text.ToString();
            if (hour.Length == 0) hour = "0";
            string remark = txtremark.Text;
            string id = txtid.Text;
            string relor = txtrelor.Text;

            if (string.IsNullOrEmpty(id))
                filename = NewFileName(filename, relor, title, remark);


            ContentRTB.SaveFile(FilePath + "\\" + filename + ".rtf", RichTextBoxStreamType.RichText);
            txtfilename.Text = filename;

            //上传文件到服务器
            try
            {
                FileUploadItem receive = new FileUploadItem();
                receive.Address = UpFileAdrees;
                receive.FileNamePath = FilePath + "\\" + filename + ".rtf";
                receive.SaveName = filename;
                FileUploadUtilEvent fileUploadUtilEvent = new FileUploadUtilEvent(receive);
                fileUploadUtilEvent.OnProgressChanged += new EventHandler<ProgressChangedEventArgs>((object sender, ProgressChangedEventArgs e) => {
                    FileUploadUtilChange message = (FileUploadUtilChange)e.UserState;
                    lbtip.Text = "已用时：" + message.Second.ToString("F2") + "秒";
                    if (message.Second > 0.001)
                        lbtip.Text += " 平均速度：" + (message.Offset / 1024 / message.Second).ToString("0.00") + "KB/秒";
                    else
                        lbtip.Text += "  正在连接…";
                    lbtip.Text += "已上传：" + (message.Offset * 100.0 / message.Length).ToString("F2") + "%";
                    lbtip.Text += (message.Offset / 1048576.0).ToString("F2") + "M/" + (message.FileLength / 1048576.0).ToString("F2") + "M";
                });
                fileUploadUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object sender, RunWorkerCompletedEventArgs e) =>
                {
                    int count = (int)e.Result;
                    
                    if (count == 0) ShowMessageDialog("上传文件服务器失败！，文件只保存在本地");


                    FileInfo fi = new FileInfo(FilePath + "\\" + filename + ".rtf");
                    DateTime dt = fi.LastWriteTime;
                    string sql = "  ";
                    if (string.IsNullOrEmpty(id))
                    {
                        sql += @"insert pasn(title,BizDate,CreateDate,Creator,relor,Remark,Status,Content,filename,lastwritetime,processor,compor,hour,estimate) 
                    values('" + title + "',now(),now(),'" + Login.Name + "','" + relor + "','" + remark + "','" + status + "','" + content + "','" + filename + "','" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + processor + "','" + compor + "','" + hour + "','" + estimate + "');  set @id=@@IDENTITY;  ";
                    }
                    else
                    {
                        sql += @"update pasn set relor='" + relor + "',estimate='" + estimate + "',modiDate=now(),modior='" + Login.Name + "', title='" + title + "',Remark='" + remark + "',Status='" + status + "'," + (status == "1" ? "compDate=now()," : "") + "Content='" + content + "',lastwritetime='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' ,processor='" + processor + "',compor='" + compor + "',hour='" + hour + "' where id=" + id + "; ";
                        sql += "set @id=" + id + ";";
                    }
                    sql += "select * from pasn where id=@id;";
                    try
                    {

                        //新增单据的时候，列表刷新一下。但少了一个选中怎么办
                        SQLUtilEvent sQLUtilSaveEvent = new SQLUtilEvent(sql);
                        sQLUtilSaveEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object sendObj, RunWorkerCompletedEventArgs arg) =>
                        {
                            DataSet dataSave = (DataSet)arg.Result;
                            txtid.Text = dataSave.Tables[0].Rows[0]["id"].ToString();
                            //前端新增一行
                            if (string.IsNullOrEmpty(id))
                            {
                                //新增单据的时候，列表刷新一下。但少了一个选中怎么办
                                SQLUtilEvent sQLUtilEvent = new SQLUtilEvent(GetPlanListData());
                                sQLUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object senders, RunWorkerCompletedEventArgs es) =>
                                {
                                    DataSet dataSet = (DataSet)es.Result;
                                    CreateListView(dataSet.Tables[0]);
                                    listStatus.Text = "总记录数：" + dataSet.Tables[0].Rows.Count;
                                    foreach(Record dr in Records)
                                    {
                                        if (dr.Id== int.Parse(txtid.Text)){
                                            uiDataGridView1.ClearSelection();
                                            uiDataGridView1.CurrentCell = uiDataGridView1.Rows[Records.IndexOf(dr)].Cells[0];
                                            uiDataGridView1.SelectedIndex = Records.IndexOf(dr);
                                           
                                        }
                                    }

                                    //for (int i = 0; i < planlist.Items.Count; i++)
                                    //{
                                    //    DataRow dr = (DataRow)planlist.Items[i].Tag;
                                    //    if (dr["id"].ToString() == txtid.Text)
                                    //    {
                                    //        planlist.Items[i].Selected = true;//选中
                                    //        planlist.Items[i].Focused = true; //焦点
                                    //        planlist.Items[i].EnsureVisible();//滚动显示
                                    //    }
                                    //}
                                    
                                    loadpc.Visible = false;
                                    btnsearch.Enabled = true;
                                    lbtip.Text = "refresh success";
                                    //前端新增一行end 
                                    btnsave.Enabled = true;
                                    ShowMessageDialog("save success");
                                    
                                });
                                sQLUtilEvent.Run("sql");

                            }
                            else
                            {
                                //DataRow item = (DataRow)(planlist.SelectedItems[0]).Tag;
                                //planlist.SelectedItems[0].Tag = dataSave.Tables[0].Rows[0];
                                //foreach (ListColumn l in PlanListColumn)
                                //{
                                //    planlist.SelectedItems[0].SubItems[PlanListColumn.IndexOf(l)].Text = dataSave.Tables[0].Rows[0][l.Key].ToString();
                                //}
                                Record data = new Record();
                                DataRow dr = dataSave.Tables[0].Rows[0];
                                data.BizDate = strToDateTime(dr["BizDate"].ToString());
                                data.Title = dr["title"].ToString();
                                data.Relor = dr["relor"].ToString();
                                data.Estimate = strToDateTime(dr["estimate"].ToString());
                                data.Status = dr["Status"].ToString();
                                data.Content = dr["Content"].ToString();
                                data.Compor = dr["compor"].ToString();
                                data.CompDate = strToDateTime(dr["compDate"].ToString());
                                data.Modior = dr["modior"].ToString();
                                data.Modidate = strToDateTime(dr["modidate"].ToString());
                                data.Filename = dr["filename"].ToString();
                                data.Creator = dr["creator"].ToString();
                                data.Remark = dr["remark"].ToString();
                                data.Id = int.Parse(dr["id"].ToString());
                                data.Hour = decimal.Parse(dr["hour"].ToString());
                                data.Processor = dr["processor"].ToString();
                                Records.Add(data);
                                
                                for (int j = 0; j < uiDataGridView1.Columns.Count; j++)
                                {
                                    string colName = uiDataGridView1.Columns[j].DataPropertyName;
                                    uiDataGridView1.SelectedRows[0].Cells[colName].Value = data.GetType().GetProperty(colName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance).GetValue(data, null);
                                }
                                    
                             
                                
                                //前端新增一行end 
                                this.loadpc.Visible = false;
                                btnsave.Enabled = true;
                                lbtip.Text = "save success";
                                ShowMessageDialog("save success");                               
                            }

                        });
                        sQLUtilSaveEvent.Run("sql");


                    }
                    catch (Exception ex)
                    {
                        loadpc.Visible = false;
                        btnsave.Enabled = true;
                        lbtip.Text = "erroe";
                        ShowMessageDialog(ex.GetBaseException().ToString());        
                    }

                });
                fileUploadUtilEvent.Run();
            }
            catch (Exception ex)
            {
                ShowMessageDialog(ex.GetBaseException().ToString());                
            }
            //上传文件到服务器end

        }
        public string NewFileName(string filename, string relor, string title, string remark)
        {
            if (filename.Length == 0)
            {
                string uuid = Guid.NewGuid().ToString("N");
                filename = Login.Name + "_" + relor + "_" + title + "_" + remark + "_" + uuid;
                if (filename.Length > FilenameMaxLen)
                    filename = filename.Substring(1, 60);//限定最大文件长度                 
            }
            else
            {
                if (filename.IndexOf(Login.Name + "_") < 0)
                    filename = Login.Name + "_" + filename;
            }
            return filename;
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                uiDataGridView1.Height += this.panel1.Height;
                toolStripSplitButton1.Text = "显示";
            }
            else
            {
                panel1.Visible = true;
                uiDataGridView1.Height -= this.panel1.Height;
                toolStripSplitButton1.Text = "隐藏";
            }

        }
        private bool ShowMessageDialog(string msg)
        {
           return UIMessageDialog.ShowMessageDialog(msg, UILocalize.InfoTitle, false, Style);
        }
        private string strToDateTime(string str)
        {
            if (str.Length == 0)
            {
                return "";
            }
            else
            {
                return DateTime.Parse(str).ToString("yyy-MM-dd");
            }

        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void VoidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIStyle t = (UIStyle)Enum.Parse(typeof(UIStyle), sender.ToString());
            uiStyleManager1.Style = t;
            LocalConfig.SetConfigValue("style", sender.ToString());
        }


        public class User
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public string UserName { get; set; }
            public int Ty { get; set; }
        }
        public class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        public class Record
        {
            public string BizDate { get; set; }

            public string Title { get; set; }

            public string Relor { get; set; }//ListUsers

            public string Estimate { get; set; }


            private string status;
            public string Status
            {
                //get { return (status == "0" ? "" : "√"); }
                get { return status; }
                set { status = value; }
            }

            public string Content { get; set; }
            public string Compor { get; set; }
            public string CompDate { get; set; }          


            private string modior;
            public string Modior
            {
                //get { 
                //    for(int i=0;i< ListUsers.Count; i++)
                //    {
                //        if (ListUsers[i].UserId.EqualsIgnoreCase(modior))
                //        {
                //            return ListUsers[i].UserName;
                //        }
                //    }
                //    return modior;
                //}
                get { return modior; }
                set { modior = value; }
            }


            public string Modidate { get; set; }
            public string Filename { get; set; }
            

            private string creator;
            public string Creator
            {
                //get
                //{
                //    for (int i = 0; i < ListUsers.Count; i++)
                //    {
                //        if (ListUsers[i].UserId.EqualsIgnoreCase(creator))
                //        {
                //            return ListUsers[i].UserName;
                //        }
                //    }
                //    return creator;
                //}
                get { return creator; }
                set { creator = value; }
            }


            public string Remark { get; set; }
            public int Id { get; set; }
            public decimal Hour { get; set; }
            public string Processor { get; set; }
        }

        private void Btndel_Click(object sender, EventArgs e)
        {
            if (ShowMessageDialog("Are you sure to delete"))  BtndelClickWork();            
        } 

        private void BtndelClickWork()
        {

            loadpc.Visible = true;
            btndel.Enabled = false;

            string filename = txtfilename.Text;

            if (File.Exists(FilePath + "\\" + filename + ".rtf"))
                File.Delete(FilePath + "\\" + filename + ".rtf");

            string id = txtid.Text;
            string sql = "";
            if (!string.IsNullOrEmpty(id))
            {
                sql = @"delete from  pasn   where id=" + id + ";select " + id + "; ";
            }


            SQLUtilEvent sQLUtilEvent = new SQLUtilEvent(sql + GetPlanListData());
            sQLUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object senders, RunWorkerCompletedEventArgs es) =>
            {
                DataSet result = (DataSet)es.Result;
                ClearDetail();
                CreateListView(result.Tables[1]);
                listStatus.Text = "总记录数：" + result.Tables[1].Rows.Count;
                BtnNew_Click(null, EventArgs.Empty);
                loadpc.Visible = false;
                btnsearch.Enabled = true;

                loadpc.Visible = false;
                btndel.Enabled = true;
                lbtip.Text = "delete success";
                ShowMessageDialog("delete success");
            });
            sQLUtilEvent.Run("sql");
        }

       
    }
}
