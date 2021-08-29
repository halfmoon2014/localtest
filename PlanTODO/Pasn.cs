
using PlanTODO.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace PlanTODO
{
    public partial class Pasn : Form
    {
        static Thread wathchThread;
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
        private static string FilePath = string.Concat(System.Windows.Forms.Application.StartupPath, "\\file");
        /// <summary>
        /// 上传服务器的地址（web服务）
        /// </summary>
        private static readonly string UpFileAdrees = @"http://192.168.35.231/MYUPLOAD/SaveFileWebForm.aspx";
        private static readonly string FileUrl = @"http://192.168.35.231/MYUPLOAD/file/";
        private static readonly int filenameMaxLen = 60;
        /// <summary>
        /// 列表头信息
        /// </summary>
        List<ListColumn> PlanListColumn = new List<ListColumn>();
        private readonly string name;
        private readonly string username;
        private Dictionary<string, string> cbStatusList;    
       
        public Pasn(string name, string username)
        {
            InitializeComponent();               

            this.name = name;
            this.username = username;
            txtcreator.Text = name;
            planlist.HideSelection = false;
            Shown += new EventHandler((object sender, EventArgs e) => {
                Console.WriteLine("show");            
              
            });
            
            //loadpcForm.Location = new System.Drawing.Point(0, -100);
            //loadpcForm.Width = Width;
            //loadpcForm.Height = Height;
            //loadpcForm.BringToFront();
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //loadpcForm.Visible = true;
            //System.Console.WriteLine(this.label7.Location);
            //System.Console.WriteLine(this.label7.GetContainerControl());
            //System.Console.WriteLine(this.loadpcForm.Location);
            //System.Console.WriteLine((this.loadpcForm.GetContainerControl()));
        }
      
        private void Pasn_Load(object sender, EventArgs e)
        {
            Init();
            //CheckForIllegalCrossThreadCalls = false;
            Bitmap bmp = (Bitmap)Bitmap.FromFile(Application.StartupPath + "//ico//Book.png");
            Icon ic = Icon.FromHandle(bmp.GetHicon());
            Icon = ic;
        }
        /// <summary>
        /// 自定义初始
        /// </summary>
        public void Init()
        {
            Console.WriteLine("Init");
            loadpc.Visible = false;
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            dtsearchbegin.Format = DateTimePickerFormat.Custom;
            dtsearchbegin.CustomFormat = "yyyy-MM-dd";
            DateTime dt = DateTime.Now;
            dtsearchbegin.Text = dt.AddMonths(-1).ToShortDateString();
            dtsearchend.Format = DateTimePickerFormat.Custom;
            dtsearchend.CustomFormat = "yyyy-MM-dd";
            estimateDate.Format = DateTimePickerFormat.Custom;
            estimateDate.CustomFormat = "yyyy-MM-dd";
            cbStatusList = new Dictionary<string, string>() { { "0", "进行中" }, { "1", "完成" }, { "4", "取消" } };
            SetCB(cbstatus, cbStatusList, "0");

            SetCB(cbprocessor, new string[] { "张茂洪", "高嘉富", "林自强", "钟少杰" }, username);
            SetCB(cbsearchprocessor, new string[] { "张茂洪", "高嘉富", "林自强", "钟少杰", "all" }, "all");
            SetCB(cbsearchstatus, new Dictionary<string, string>() { { "0", "进行中" }, { "1", "完成" }, { "4", "取消" }, { "-1", "全部" } }, "-1");

            //loadpc.Location = new System.Drawing.Point((this.Width - loadpc.Width) / 2, (this.Height - loadpc.Height) / 2);
            //loadpc.Visible = false;
            //loadpc.BringToFront();
            planlist.View = View.Details;
            planlist.CheckBoxes = false;
            planlist.FullRowSelect = true;
            PlanListColumn.Add(new ListColumn("日期", 135, "BizDate"));
            PlanListColumn.Add(new ListColumn("标题", 120, "title"));
            PlanListColumn.Add(new ListColumn("业务", 100, "relor"));

            PlanListColumn.Add(new ListColumn("预计完成", 100, "estimate"));
            PlanListColumn.Add(new ListColumn("状态", 100, "Status"));
            PlanListColumn.Add(new ListColumn("内容", 200, "Content"));
            PlanListColumn.Add(new ListColumn("完结人", 120, "compor"));
            PlanListColumn.Add(new ListColumn("完结日期", 120, "compDate"));
            PlanListColumn.Add(new ListColumn("修改人", 120, "modior"));
            PlanListColumn.Add(new ListColumn("修改日期", 120, "modidate"));
            PlanListColumn.Add(new ListColumn("文件名", 120, "filename"));
            PlanListColumn.Add(new ListColumn("制单人", 100, "creator"));
            PlanListColumn.Add(new ListColumn("备注", 200, "remark"));
            PlanListColumn.Add(new ListColumn("id", 0, "id"));
            foreach (ListColumn l in PlanListColumn)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = l.Text;
                ch.Width = l.Width;
                ch.TextAlign = l.M;
                planlist.Columns.Add(ch);    //将列头添加到ListView控件。
            }

            //SQLUtilEvent sQLUtilEvent = new SQLUtilEvent(GetPlanListData());
            //sQLUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object sender, RunWorkerCompletedEventArgs e) =>
            //{
            //    DataSet ds = (DataSet)e.Result;
            //    CreateListView(ds.Tables[0]);
            //    listStatus.Text = "总记录数：" + ds.Tables[0].Rows.Count;
            //    Button1_Click_1(null, EventArgs.Empty);
            //    loadpc.Visible = false;
            //    btnsearch.Enabled = true;
            //    lbtip.Text = "refresh success";
            //});
            //sQLUtilEvent.Run();
        }
        /// <summary>
        /// 初始comb
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="selectedValue"></param>
        private void SetCB(ComboBox cb, string[] dataSource, string selectedValue)
        {
            Dictionary<string, string> ds = new Dictionary<string, string>();
            foreach (string s in dataSource)
                ds.Add(s, s);
            SetCB(cb, ds, selectedValue);
        }
        /// <summary>
        /// 初始comb2
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="dataSource"></param>
        /// <param name="selectedValue"></param>
        private void SetCB(ComboBox cb, Dictionary<string, string> dataSource, string selectedValue)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            foreach (string key in dataSource.Keys)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = dataSource[key];
                dr["Value"] = key;
                dt.Rows.Add(dr);
            }
            cb.DataSource = dt;
            cb.DisplayMember = "Text";
            cb.ValueMember = "Value";
            cb.SelectedValue = selectedValue;
        }
        //private BackgroundWorker worker;
        /// <summary>
        /// 初始化列表
        /// </summary>
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
            if (processor != "all")
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
            planlist.BeginUpdate();//防listview闪烁开始
            planlist.Items.Clear();
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Clear();
                foreach (ListColumn l in PlanListColumn)
                {
                    if (l.Key.Equals("Status"))
                    {
                        string val = "";
                        foreach (string k in cbStatusList.Keys)
                        {
                            if (k.Equals(dr[l.Key].ToString()))
                                val = cbStatusList[k];
                        }
                        list.Add(val);
                    }
                    else list.Add(dr[l.Key].ToString());
                }

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
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {                
                SaveWork();
            }
            catch (SystemException ex)
            {
                MessageBoxEx.Show(this, ex.Message);
            }
        }
        /// <summary>
        /// 保存
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
            if (hour.Length == 0)   hour = "0";
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
                fileUploadUtilEvent.OnProgressChanged+= new EventHandler<ProgressChangedEventArgs>((object sender, ProgressChangedEventArgs e) => {
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
                    if (count == 0)  MessageBoxEx.Show(this, "上传文件服务器失败！，文件只保存在本地");


                    FileInfo fi = new FileInfo(FilePath + "\\" + filename + ".rtf");
                    DateTime dt = fi.LastWriteTime;
                    string sql = "  ";
                    if (string.IsNullOrEmpty(id))
                    {
                        sql += @"insert pasn(title,BizDate,CreateDate,Creator,relor,Remark,Status,Content,filename,lastwritetime,processor,compor,hour,estimate) 
                    values('" + title + "',now(),now(),'" + name + "','" + relor + "','" + remark + "','" + status + "','" + content + "','" + filename + "','" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + processor + "','" + compor + "','" + hour + "','" + estimate + "');  set @id=@@IDENTITY;  ";
                    }
                    else
                    {
                        sql += @"update pasn set relor='" + relor + "',estimate='" + estimate + "',modiDate=now(),modior='" + name + "', title='" + title + "',Remark='" + remark + "',Status='" + status + "'," + (status == "1" ? "compDate=now()," : "") + "Content='" + content + "',lastwritetime='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' ,processor='" + processor + "',compor='" + compor + "',hour='" + hour + "' where id=" + id + "; ";
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

                                    for (int i = 0; i < planlist.Items.Count; i++)
                                    {
                                        DataRow dr = (DataRow)planlist.Items[i].Tag;
                                        if (dr["id"].ToString() == txtid.Text)
                                        {
                                            planlist.Items[i].Selected = true;//选中
                                            planlist.Items[i].Focused = true; //焦点
                                            planlist.Items[i].EnsureVisible();//滚动显示
                                        }
                                    }

                                    loadpc.Visible = false;
                                    btnsearch.Enabled = true;
                                    lbtip.Text = "refresh success";
                                    //前端新增一行end 
                                    btnsave.Enabled = true;

                                    MessageBoxEx.Show(this, "save success");
                                });
                                sQLUtilEvent.Run();

                            }
                            else
                            {
                                DataRow item = (DataRow)(planlist.SelectedItems[0]).Tag;
                                planlist.SelectedItems[0].Tag = dataSave.Tables[0].Rows[0];
                                foreach (ListColumn l in PlanListColumn)
                                {
                                    planlist.SelectedItems[0].SubItems[PlanListColumn.IndexOf(l)].Text = dataSave.Tables[0].Rows[0][l.Key].ToString();
                                }
                                //前端新增一行end 
                                this.loadpc.Visible = false;
                                btnsave.Enabled = true;
                                lbtip.Text = "save success";
                                MessageBoxEx.Show(this, "save success");
                            }

                        });
                        sQLUtilSaveEvent.Run();


                    }
                    catch (Exception ex)
                    {

                        loadpc.Visible = false;
                        btnsave.Enabled = true;
                        lbtip.Text = "erroe";
                        MessageBoxEx.Show(this, "" + ex.GetBaseException());

                    }

                });
                fileUploadUtilEvent.Run();             
            }
            catch (Exception ex)
            {         
                MessageBoxEx.Show(this, "" + ex.GetBaseException());     
            }
            //上传文件到服务器end

        }

        /// <summary>
        /// 文件的保存
        /// </summary>
        /// <param name="address"></param>
        /// <param name="fileNamePath"></param>
        /// <param name="saveName"></param>
        /// <returns></returns>
       

        /// <summary>
        /// 双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Planlist_DoubleClick(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "ListViewEx")
            {
                Thread thread;
                thread = new Thread(() => Planlist_DoubleClickWork((ListView)sender, e));
                thread.Start();
            }
        }
        private void Planlist_DoubleClickWork(ListView l, EventArgs e)
        {

            this.Invoke(new Action(() =>
            {
                DataRow item = null;
                loadpc.Visible = true;
                item = (DataRow)(l.SelectedItems[0]).Tag;
                txtid.Text = item["id"].ToString();
                txtfilename.Text = item["filename"].ToString();
                txttitle.Text = item["title"].ToString();
                txthour.Text = item["hour"].ToString();
                cbstatus.SelectedIndex = int.Parse(item["status"].ToString());
                cbprocessor.SelectedValue = item["processor"].ToString();

                txtremark.Text = item["remark"].ToString();
                estimateDate.Text = item["estimate"].ToString();
                txtrelor.Text = item["relor"].ToString();
                if (File.Exists(FilePath + "\\" + item["filename"].ToString() + ".rtf"))
                {

                    IntPtr vHandle = _lopen(FilePath + "\\" + item["filename"].ToString() + ".rtf", OF_READWRITE | OF_SHARE_DENY_NONE);
                    if (vHandle == HFILE_ERROR)
                    {
                        MessageBoxEx.Show(this, "文件被占用");
                        ContentRTB.Clear();
                        return;
                    }
                    CloseHandle(vHandle);     //判断之后一定要关闭！！！

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
                    }
                    else
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

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            SQLUtilEvent sQLUtilEvent = new SQLUtilEvent(GetPlanListData());
            sQLUtilEvent.OnRunWorkerCompleted += new EventHandler<RunWorkerCompletedEventArgs>((object senders, RunWorkerCompletedEventArgs es) =>
            {
                DataSet ds = (DataSet)es.Result;
                CreateListView(ds.Tables[0]);
                listStatus.Text = "总记录数：" + ds.Tables[0].Rows.Count;
                Button1_Click_1(null, EventArgs.Empty);
                loadpc.Visible = false;
                btnsearch.Enabled = true;
                lbtip.Text = "refresh success";
            });
            sQLUtilEvent.Run();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btndel_Click(object sender, EventArgs e)
        {

            DialogResult result2 = MessageBoxEx.Show(this, "Are you sure to delete", "warn", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            if (result2 == DialogResult.OK)
            {
                BtndelClickWork();
            }
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
                Button1_Click_1(null, EventArgs.Empty);
                loadpc.Visible = false;
                btnsearch.Enabled = true;

                loadpc.Visible = false;
                btndel.Enabled = true;
                lbtip.Text = "delete success";
                MessageBoxEx.Show(this, "delete success");
            });
            sQLUtilEvent.Run();


            //}));
        }
        /// <summary>
        /// 清除详情区
        /// </summary>
        private void ClearDetail()
        {
            this.Invoke(new Action(() =>
            {
                ContentRTB.Clear();
                txtfilename.Text = "";
                txttitle.Text = "";
                txthour.Text = "";
                txtremark.Text = "";
                cbstatus.SelectedIndex = 0;
                cbprocessor.SelectedIndex = 0;
                txtid.Text = "";

                txtrelor.Text = "";
                txtcompor.Text = "";
            }));
        }
        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click_1(object sender, EventArgs e)
        {
            ClearDetail();
            lbtip.Text = "new  status ";
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 流程分享
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            Shar shar = new Shar(name);
            shar.Show();
        }

        /// <summary>
        /// 文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="relor"></param>
        /// <param name="title"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public string NewFileName(string filename, string relor, string title, string remark)
        {
            if (filename.Length == 0)
            {
                string uuid = Guid.NewGuid().ToString("N");
                filename = this.name + "_" + relor + "_" + title + "_" + remark + "_" + uuid;
                if (filename.Length > filenameMaxLen)
                    filename = filename.Substring(1, 60);//限定最大文件长度                 
            }
            else
            {
                if (filename.IndexOf(this.name + "_") < 0)
                    filename = this.name + "_" + filename;
            }
            return filename;
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            if (this.panel1.Visible)
            {
                this.panel1.Visible = false;
                this.planlist.Height += this.panel1.Height;
                this.toolStripSplitButton1.Text = "显示";
            }
            else
            {
                this.panel1.Visible = true;
                this.planlist.Height -= this.panel1.Height;
                this.toolStripSplitButton1.Text = "隐藏";
            }
        }

        private void FileEdit_Click(object sender, EventArgs e)
        {
            if (File.Exists(FilePath + "\\" + txtfilename.Text + ".rtf"))
            {
                DataFileView(FilePath + "\\" + txtfilename.Text + ".rtf");
                try
                {
                    FileInfo fi = new FileInfo(FilePath + "\\" + txtfilename.Text + ".rtf");

                    if (wathchThread != null) wathchThread.Abort();
                    wathchThread = new Thread(() => WacthFile(txtfilename.Text, fi.LastWriteTime));
                    wathchThread.Start();
                }
                catch (SystemException ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBoxEx.Show(this, ex.Message);
                    }));
                }
            }
            else
            {
                MessageBoxEx.Show(this, "请先打开一个任务");
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
        /// <summary>
        /// 
        /// 打开文件
        /// </summary>
        /// <param name="filePath"></param>
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
    }

}
