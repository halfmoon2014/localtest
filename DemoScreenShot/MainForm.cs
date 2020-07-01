using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoScreenShot
{
    public partial class MainForm : Form
    {
        private ScreenForm sf = new ScreenForm();

        private Bitmap curBitmap;

        public MainForm()
        {
            InitializeComponent();
            string tag = "123--";
            tag = tag.Split(new char[]
            {
                '-'
            })[0];
            string a = tag;
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            sf.ScreenShotOk += new EventHandler(ScreenShotOk_Click);
            sf.ScreenShotEsc += new EventHandler(ScreenShotEsc);
        }
        private void ScreenShotEsc(object sender, EventArgs e) {
            this.Show();
        }
        private void ScreenShotOk_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Math.Abs(sf.End.X - sf.Start.X), Math.Abs(sf.End.Y - sf.Start.Y));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int w = Math.Abs(sf.End.X - sf.Start.X);
                int h = Math.Abs(sf.End.Y - sf.Start.Y);
                Rectangle destRect = new Rectangle(0, 0, w + 1, h + 1);//在画布上要显示的区域（记得像素加1）
                int startX = sf.Start.X; int startY = sf.Start.Y;
                if (sf.Start.X > sf.End.X) startX = sf.End.X;
                if (sf.Start.Y > sf.End.Y) startY = sf.End.Y;
                int deX = 0;//15
                Rectangle srcRect = new Rectangle(startX, startY - deX  , w + 1, h + 1);//图像上要截取的区域
                g.DrawImage(curBitmap, destRect, srcRect, GraphicsUnit.Pixel);//加图像绘制到画布上
            }
            this.pictureBox1.Image = bmp;
            this.Show();
        }

        public Bitmap GetScreen()
        {
            //获取整个屏幕图像,不包括任务栏
            Rectangle ScreenArea = Screen.GetBounds(this);
            Bitmap bmp = new Bitmap(ScreenArea.Width, ScreenArea.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(ScreenArea.Width,ScreenArea.Height));
            }
            return bmp;
        }

        #region 菜单栏事件

        /// <summary>
        /// 菜单栏 新建截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiNew_Click(object sender, EventArgs e)
        {
            tsbNew_Click(sender, e);
        }

        /// <summary>
        /// 菜单栏 另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiSaveOther_Click(object sender, EventArgs e)
        {
            tsbSave_Click(sender, e);
        }

        /// <summary>
        /// 菜单栏 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiSend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能尚未实现！");
        }

        /// <summary>
        /// 菜单栏，退出功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit ?","Info",MessageBoxButtons.OKCancel) == DialogResult.OK) {
                this.Close();
            }
        }

        /// <summary>
        /// 菜单栏 复制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiCopy_Click(object sender, EventArgs e)
        {
            tsbCopy_Click(sender, e);
        }

        private void smiPen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("使用此功能，请点击工具栏按钮！");
        }

        private void smiLightPen_Click(object sender, EventArgs e)
        {
            tsbLightPen_Click(sender, e);
        }

        private void smiEraser_Click(object sender, EventArgs e)
        {
            tsbEraser_Click(sender, e);
        }

        private void smiOperation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能尚未实现！");
        }

        private void smiHelp1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能尚未实现！");
        }

        /// <summary>
        /// About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        #endregion

        #region 鼠标事件

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.pictureBox1.StartDraw == true)
            {
                this.pictureBox1.OnMouseDown(e.Location);
            }
        }

        /// <summary>
        /// 鼠标弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.pictureBox1.StartDraw == true)
            {
                this.pictureBox1.OnMouseUp(e.Location);
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.pictureBox1.StartDraw == true)
            {
                this.pictureBox1.SetPointAndRefresh(e.Location);
            }
        }

        #endregion

        #region 工具栏事件
        
        /// <summary>
        /// 新建截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.Hide();//隐藏当前

            DelayDo(300, () => {
                this.pictureBox1.LineHistory.Clear();//清除绘制的历史线条
                this.pictureBox1.RectHistory.Clear();
                this.curBitmap = GetScreen();
                sf.BackgroundImage = this.curBitmap;
                sf.StartPosition = FormStartPosition.Manual;//起始位置
                sf.ShowDialog();
            });            

        }

        /// <summary>
        /// 保存功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {

            try
            {
                Thread thread;
                thread = new Thread(() => SaveWork());
                thread.Start();
            }
            catch (SystemException ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBoxEx.Show(this, ex.Message);
                }));
            }

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.AddExtension = true;
            //sfd.DefaultExt = "png";
            //sfd.Filter = "PNG图片|*.png|JPG图片|*.jpg";
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //if (sfd.ShowDialog() == DialogResult.OK) {
            //    string fileName = sfd.FileName;
            //    Image image = this.pictureBox1.Image;
            //    using (Graphics g = Graphics.FromImage(image)) { 
            //        this.pictureBox1.DrawHistory(g);
            //    }
            //    image.Save(fileName);
            //}
        }

        /// <summary>
        ///  /// <summary>
        /// 保存
        /// </summary>
        private void SaveWork()
        {
            //string content = null;
            //string status = "";
            //string processor = "";
            //string compor = "";
            //this.Invoke(new Action(() =>
            //{
            //    this.loadpc.Visible = true;
            //    content = ContentRTB.Text.Replace("\'", "\\\'");
            //    btnsave.Enabled = false;
            //    status = cbstatus.SelectedValue.ToString();
            //    processor = cbprocessor.SelectedValue.ToString();
            //    compor = txtcompor.Text.ToString();
            //}));
            ////Thread.Sleep(500);//看LOADING效果用的
            //string filename = txtfilename.Text;
            //string title = txttitle.Text;
            //string hour = txthour.Text.ToString();
            //if (hour.Length == 0)
            //    hour = "0";
            //string remark = txtremark.Text;
            //string id = txtid.Text;
            //string relor = txtrelor.Text;

            //if (string.IsNullOrEmpty(id))
            //    filename = NewFileName(filename, relor, title, remark);

            //this.Invoke(new Action(() =>
            //{
            //    ContentRTB.SaveFile(FilePath + "\\" + filename + ".rtf", RichTextBoxStreamType.RichText);
            //    txtfilename.Text = filename;
            //}));

            ////上传文件到服务器
            //try
            //{
            //    int count = UpSound_Request(UpFileAdrees, FilePath + "\\" + filename + ".rtf", filename);
            //    if (count == 0)
            //    {
            //        this.Invoke(new Action(() =>
            //        {
            //            MessageBoxEx.Show(this, "上传文件服务器失败！，文件只保存在本地");
            //        }));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.Invoke(new Action(() =>
            //    {
            //        MessageBoxEx.Show(this, "" + ex.GetBaseException());
            //    }));

            //}
            ////上传文件到服务器end

            ////string content = ContentRTB.Text;
            //FileInfo fi = new FileInfo(FilePath + "\\" + filename + ".rtf");
            //DateTime dt = fi.LastWriteTime;
            //string sql = "  ";
            //if (string.IsNullOrEmpty(id))
            //{
            //    sql += @"insert pasn(title,BizDate,CreateDate,Creator,relor,Remark,Status,Content,filename,lastwritetime,processor,compor,hour) 
            //        values('" + title + "',now(),now(),'" + this.name + "','" + relor + "','" + remark + "','" + status + "','" + content + "','" + filename + "','" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + processor + "','" + compor + "','" + hour + "');  set @id=@@IDENTITY;  ";
            //}
            //else
            //{
            //    sql += @"update pasn set relor='" + relor + "',modiDate=now(),modior='" + this.name + "', title='" + title + "',Remark='" + remark + "',Status='" + status + "'," + (status == "1" ? "compDate=now()," : "") + "Content='" + content + "',lastwritetime='" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "' ,processor='" + processor + "',compor='" + compor + "',hour='" + hour + "' where id=" + id + "; ";
            //    sql += "set @id=" + id + ";";
            //}
            //sql += "select * from pasn where id=@id;";
            //try
            //{
            //    DataSet ds = MySqlHelper.ExecuteSQL(sql);
            //    this.Invoke(new Action(() =>
            //    {
            //        txtid.Text = ds.Tables[0].Rows[0]["id"].ToString();
            //        //前端新增一行
            //        if (string.IsNullOrEmpty(id))
            //        {
            //            //新增单据的时候，列表刷新一下。但少了一个选中怎么办
            //            Thread thread;
            //            thread = new Thread(() => GetPlanListData(txtid.Text));
            //            thread.Start();
            //        }
            //        else
            //        {
            //            DataRow item = (DataRow)(planlist.SelectedItems[0]).Tag;
            //            planlist.SelectedItems[0].Tag = ds.Tables[0].Rows[0];
                     
            //            foreach (ListColumn l in PlanListColumn)
            //            {                                                 
            //                planlist.SelectedItems[0].SubItems[PlanListColumn.IndexOf(l)].Text = ds.Tables[0].Rows[0][l.Key].ToString();
            //            }                    
            //        }
            //        //前端新增一行end 
            //        this.loadpc.Visible = false;
            //        btnsave.Enabled = true;
            //        lbtip.Text = "save success";
            //        MessageBoxEx.Show(this, "save success");
            //    }));
            //}
            //catch (Exception ex)
            //{
            //    this.Invoke(new Action(() =>
            //    {
            //        this.loadpc.Visible = false;
            //        btnsave.Enabled = true;
            //        lbtip.Text = "erroe";
            //        MessageBoxEx.Show(this, "" + ex.GetBaseException());
            //    }));
            //}

        }

        /// 复制功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image != null)
            {
                Clipboard.SetDataObject(this.pictureBox1.Image);
                MessageBox.Show("已复制到剪贴板！");
            }
        }

        private void tsddbPen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem;
            if (item.Selected)
            {
                Color color = Color.FromName(item.Tag.ToString());
                this.tsddbPen.BackColor = color;
                this.pictureBox1.SetPen(color);
            }
        }

        /// <summary>
        /// 荧光笔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbLightPen_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetLightPen();
        }

        /// <summary>
        /// 用图片生成指针样式
        /// </summary>
        /// <param name="cursor"></param>
        /// <param name="hotPoint"></param>
        public void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
            cursor.Height);
            this.Cursor = new Cursor(myNewCursor.GetHicon());

            g.Dispose();
            myNewCursor.Dispose();
        }

        private void tsbDefault_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetDefault();
        }
        
        /// <summary>
        /// 橡皮擦功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEraser_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetEarser();
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRectangle_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetRectangle();
        }

        #endregion

        private delegate void DelegateVoid();
        public void DelayDo(int delayms, Action action)
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(delayms);
                this.BeginInvoke(new DelegateVoid(action));
                Thread.CurrentThread.Join();
                Thread.CurrentThread.Abort();
            });
            thread.Start();
        }
    }
}
