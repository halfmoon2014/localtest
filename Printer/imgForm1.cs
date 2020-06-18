using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Printer.tools;
namespace Printer
{

    public partial class imgForm1 : Form
    {
        private delegate void MsgInfoDelegate(string strInfo, bool isShow);

        private MsgInfoDelegate ShowInfo;
        public imgForm1()
        {
            InitializeComponent();
            ShowInfo = new MsgInfoDelegate(MessageShowSub);
            if (!Directory.Exists("temp"))//如果不存在就创建 dir 文件夹  
                Directory.CreateDirectory("temp");
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread;
                thread = new Thread(() => login());
                thread.Start();
            }
            catch (SystemException ex)
            {
                MessageShowSub(ex.Message, true);
            }
        }
        private void MessageShowSub(string info, bool isShow)
        {
            this.lblInfo.Text = info;
            if (isShow)
            {
                MessageBoxEx.Show(this, info);
            }
        }

        private void login()
        {
            this.Invoke(new Action(() =>
            {
                btnserch.Enabled = false;
                loadpc.Visible = true;
            }));
            String ksrq = this.ksrq.Value.ToString("d");
            String jsrq = this.jsrq.Value.ToString("d");
            string sql = @"
                    SELECT DISTINCT sp.sphh
                    INTO #XZ
                    FROM yx_t_spidlog A
                         INNER JOIN dbo.YX_T_Spidb B ON A.spid=B.spid
                         INNER JOIN YX_T_Tmb tm ON tm.tm=B.tm
                         INNER JOIN dbo.YX_T_Spdmb sp ON sp.sphh=tm.sphh
                    WHERE 1=1 AND A.djlx='3909' AND A.zdrq>='{0}' AND A.zdrq<DATEADD(DAY, 1, '{1}');
                    SELECT distinct  REPLACE(pic.urladdress,'../','http://webt.lilang.com:9001/') AS urladdress, b.sphh
                    FROM yx_v_spdmb b
                         INNER JOIN #XZ xz ON xz.sphh=b.sphh
                         INNER JOIN(SELECT x2.sphh, MIN(ISNULL(x1.URLAddress, '')) urladdress
                                    FROM t_uploadfile x1
                                         INNER JOIN(SELECT y1.zlmxid, sp.sphh
                                                    FROM YX_T_Ypdmb y1
                                                         INNER JOIN YX_T_Spdmb sp ON y1.yphh=sp.yphh) x2 ON x1.TableID=x2.zlmxid AND x1.GroupID=1003
                                    WHERE ISNULL(x1.URLAddress, '')<>''
                                    GROUP BY x2.sphh) pic ON pic.sphh=b.sphh;";
            DataSet ds = SqlServerHelper.ExecuteDataSet(CommandType.Text, string.Format(sql,ksrq,jsrq));
            this.Invoke(new Action(() =>
            {
                btnserch.Enabled = true;
                loadpc.Visible = false;
                this.Invoke(ShowInfo, "正在下载...", false);
                this.textBox1.Text = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string url = dr["urladdress"].ToString();
                    DownLoadFile(url, dr["sphh"].ToString());
                    

                }
                this.Invoke(ShowInfo, "完成...", false);
            }));
        }

        public bool DownLoadFile(string URL, string Filename)
        {
            try
            {
                string extension = Path.GetExtension(URL);//扩展名 ".aspx"
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL); //从URL地址得到一个WEB请求   
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse(); //从WEB请求得到WEB响应   
                long totalBytes = myrp.ContentLength; //从WEB响应得到总字节数   
   
                System.IO.Stream st = myrp.GetResponseStream(); //从WEB请求创建流（读）   
                System.IO.Stream so = new System.IO.FileStream("temp//"+Filename+ extension, System.IO.FileMode.Create); //创建文件流（写）   
                long totalDownloadedByte = 0; //下载文件大小   
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length); //读流   
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte; //更新文件大小   
                    Application.DoEvents();
                    so.Write(by, 0, osize); //写流   
                   
                    osize = st.Read(by, 0, (int)by.Length); //读流   
                }
                so.Close(); //关闭流
                st.Close(); //关闭流
                this.textBox1.Text += Filename+Environment.NewLine;
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
