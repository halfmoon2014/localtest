using System;
 
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace PlanTODO.tools
{
    /// <summary>
    /// SQL执行
    /// </summary>
    class FileUploadUtilEvent
    {
        /// <summary>
        /// 查询完回调
        /// </summary>
        public event EventHandler<RunWorkerCompletedEventArgs> OnRunWorkerCompleted; //定义一个委托类型的事件 ,查询完回调

        /// <summary>
        /// 定义一个委托类型的事件 ,报告进度更新
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;
        /// <summary>
        /// 入参
        /// </summary>
        private FileUploadItem receive;

        private BackgroundWorker worker;
        public FileUploadUtilEvent(FileUploadItem receive)
        {
            this.receive = receive;
        }
        public void Run() {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            //当事件处理完毕后执行的方法   
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((object sender, RunWorkerCompletedEventArgs e) => {

                OnRunWorkerCompleted(this, e);
            });
            worker.ProgressChanged += new ProgressChangedEventHandler((object sender, ProgressChangedEventArgs e) => {
                OnProgressChanged(this, e);
            });
            worker.WorkerReportsProgress = true;//支持报告进度更新   
            worker.WorkerSupportsCancellation = false;//不支持异步取消   
            worker.RunWorkerAsync(this.receive);//启动执行  
        }
  

        //开始启动工作时执行的事件处理方法   
        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileUploadItem receive = e.Argument as FileUploadItem;
            e.Result=UpSound_Request(receive);

        }

        public int UpSound_Request(FileUploadItem receive)
        {
            string address = receive.Address;
            string fileNamePath = receive.FileNamePath;
            string saveName = receive.SaveName;
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
            sb.Append(HttpUtility.UrlEncode(saveName, Encoding.UTF8));
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
            FileUploadUtilChange fileUploadUtilChange = new FileUploadUtilChange();
            fileUploadUtilChange.FileLength = fileLength;
            fileUploadUtilChange.Length = length;
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
                    
                    fileUploadUtilChange.Second = second;                    
                    fileUploadUtilChange.Offset = offset;
                    worker.ReportProgress((int)(offset * 100.0 / length), fileUploadUtilChange);
                    System.Console.WriteLine((offset * 100.0 / length));
                    //this.Invoke(new Action(() =>
                    //{
                    //    lbtip.Text = "已用时：" + second.ToString("F2") + "秒";
                    //    if (second > 0.001)
                    //        lbtip.Text += " 平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                    //    else
                    //        lbtip.Text += "  正在连接…";
                    //    lbtip.Text += "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                    //    lbtip.Text += (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    //}));
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
                Console.WriteLine(ex.Message);
                returnValue = 0;
            }
            finally
            {
                fs.Close();
                r.Close();
            }
            return returnValue;
        }
    }
}
