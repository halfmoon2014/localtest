using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using ICSharpCode.SharpZipLib.Zip;
namespace AutoUp
{
    public partial class UpdateForm : Form
    {
        public UpdateForm(string[] args)
        {
            InitializeComponent();
           
            //this.ver = "1";
            //this.url = "http://192.168.35.231/autoupdate/1.zip";
            //this.startPath = "E:\\gitrepos\\localtest\\WindowsFormsApplication1\\bin\\Debug\\plantodo.exe";
            this.ver = args[0];
            this.url = args[1];
            this.startPath = args[2];
            localLog.WriteInfo(url);
            //string ApplicationExecutablePath = Assembly.GetExecutingAssembly().GetName().CodeBase;
            this.directory = System.Windows.Forms.Application.StartupPath + "\\" + Guid.NewGuid().ToString() + "\\";
        }
        private delegate void UpdateProcessDelegate(long percent);
        /// <summary>
        /// 版本号
        /// </summary>
        private string ver = string.Empty;
        /// <summary>
        /// 更新包地址
        /// </summary>
        private string url = string.Empty;


        private long contentLength = 0;
        private long currentLength = 0;

        /// <summary>
        /// 更新完成后重新打开应用
        /// </summary>
        private string startPath = string.Empty;
        //private List<string> others = null;

        private string directory = string.Empty;
        private bool isDownLoading = false;

        private void btn_Update_Click(object sender, EventArgs e)
        {
            this.btn_Update.Enabled = false;
            this.isDownLoading = true;
            this.lbl_Status.Visible = true;
            this.lbl_Status.Text = "正在下载...";
            Thread thread = new Thread(DownLoad);
            thread.IsBackground = true;
            thread.Name = "Update";
            thread.Start();
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.startPath))
            {
                Process p = new Process();
                p.StartInfo.FileName = this.startPath;
                p.Start();
            }

            this.Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            contentLength = Convert.ToInt64(response.Headers["Content-Length"]);
            string size = string.Empty;
            if (contentLength > 1024 * 1024)
            {
                size = contentLength / (1024 * 1024) + "MB";
            }
            else if (contentLength > 1024)
            {
                size = contentLength / 1024 + "KB";
            }
            else
            {
                size = contentLength + "B";
            }

            this.lbl_Percent.Text = "0%";
            this.lbl_Size.Text = size;
        }
        private void DownLoad()
        {
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string fileName = url.Substring(url.LastIndexOf('/') + 1, url.Length - url.LastIndexOf('/') - 1);
                FileStream fs = new FileStream(directory + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();

                byte[] mybyte = new byte[128 * 200];//128byte = 1kb 200kb/s
                int count = stream.Read(mybyte, 0, mybyte.Length);
                currentLength += count;
                fs.Seek(0, SeekOrigin.Begin);

                while (count > 0)
                {
                    fs.Write(mybyte, 0, count);
                    count = stream.Read(mybyte, 0, mybyte.Length);
                    currentLength += count;
                    Thread.Sleep(1);
                    UpdateProcessDelegate d = new UpdateProcessDelegate(UpdateStatus);
                    this.BeginInvoke(d, new object[] { 100 * currentLength / contentLength });
                }
                stream.Close();
                fs.Close();

                this.BeginInvoke((ThreadStart)delegate ()
                {
                    this.lbl_Status.Text = "下载完成";
                    Thread.Sleep(500);
                    this.lbl_Status.Text = "正在解压...";
                });

                if (Path.GetExtension(fileName).Equals(".zip"))
                {
                    this.UnZipFile(directory + fileName);
                    File.Delete(directory + fileName);
                    Directory.Delete(directory, true);
                }

                Thread.Sleep(500);

                this.isDownLoading = false;
                this.BeginInvoke((ThreadStart)delegate ()
                {
                    LocalConfig.SetConfigValue("ver", ver);
                    this.lbl_Status.Text = "完成更新";
                    this.btn_Complete.Enabled = true;
                    this.btn_Update.Enabled = true;
                });
                //MessageBox.Show("更新完成！");     
            }
            catch (Exception ex)
            {
                this.isDownLoading = false;
                this.BeginInvoke((ThreadStart)delegate ()
                {
                    this.lbl_Status.Text = "更新失败";
                    this.btn_Complete.Enabled = true;
                });
                MessageBox.Show(ex.Message, "提示信息");
                this.Close();
            }
        }

        private void UpdateStatus(long percent)
        {
            this.progressBar1.Value = Convert.ToInt32(percent);
            this.lbl_Percent.Text = percent + "%";
            string size = string.Empty;
            if (currentLength > 1024 * 1024)
            {
                size = currentLength / (1024 * 1024) + "MB";
            }
            else if (currentLength > 1024)
            {
                size = currentLength / 1024 + "KB";
            }
            else
            {
                size = currentLength + "B";
            }
            this.lbl_CurrentSize.Text = size;
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isDownLoading)
            {
                e.Cancel = true;
            }
        }

        private void UnZipFile(string zipFilePath)
        {
            if (!File.Exists(zipFilePath))
            {
                Console.WriteLine("Cannot find file '{0}'", zipFilePath);
                return;
            }

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
            {
                ZipEntry theEntry;
                //string ApplicationExecutablePath = Assembly.GetExecutingAssembly().GetName().CodeBase;
                string mbDirectory = System.Windows.Forms.Application.StartupPath;

                while ((theEntry = s.GetNextEntry()) != null)
                {

                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (fileName != String.Empty)
                    {
                        try
                        {
                            using (FileStream streamWriter = File.Create(mbDirectory + "\\" + theEntry.Name))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
