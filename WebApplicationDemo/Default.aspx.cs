using System;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Structs;

namespace WebApplication1
{
    public class RequestBody
    {
        public string d1;
        public string d2;
        public string d3;
        public string d4;
        public string d5;
        public string d6;
        public string s01;
        public string s02;
        public string s03;
        public string s04;
        public string s05;
        public string s06;
        public string s07;
        public string s08;
        public string s09;
        public string s10;
    }
    public class RequestHead
    {
        public string appKey;
        public string secretKey;
        public string method;
        public string askSerialNo;
        public string sendTime;
    }
    public class RequestBody2
    {
        public string reportNO;
    }
    public class RequestData
    {
        public RequestData() { }
        // 请求头对象
        public RequestHead head { get; set; }

        // 请求体对象
        public RequestBody2 body { get; set; }
    }

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getRep();
            return;
            RequestHead head = new RequestHead();
            head.appKey = "lilang";
            head.askSerialNo = Guid.NewGuid().ToString();
            head.method = "APIgetreportsLilang";
            head.secretKey = "96B94FF9-EC8A-4E73-8394-B97029C72DC8";
            head.sendTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            RequestBody body = new RequestBody();
            body.s01 = "009393";

            // 请求对象
            RequestData RequestBean = new RequestData();            
            RequestBean.head = head;
            //RequestBean.body = body;

            // 返回对象
            ReportsListResponseStructBean ResponseBean = new ReportsListResponseStructBean();


            // 请求功能URL
            string url = "http://data.cnttts.com:58080/dmz/v1/M0001";
            url = "http://data.cnttts.com:58080/dmz/v1/T0001";
            string postJson = JsonConvert.SerializeObject(RequestBean, Newtonsoft.Json.Formatting.None);

            // 请求后台
            string retmp = PostFunction(url, postJson);

            ResponseBean = JsonConvert.DeserializeObject<ReportsListResponseStructBean>(retmp);

        }

        public void getRep()
        {
            RequestHead head = new RequestHead();
            head.appKey = "lilang";
            head.askSerialNo = Guid.NewGuid().ToString();
            head.method = "APIgetreportsLilang";
            head.secretKey = "96B94FF9-EC8A-4E73-8394-B97029C72DC8";
            head.sendTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            RequestBody2 body = new RequestBody2();
            body.reportNO = "cttt-qz17006793";
            // 请求对象
            RequestData RequestBean = new RequestData();
            RequestBean.head = head;
            RequestBean.body = body;

            // 返回对象
            ReportsListResponseStructBean ResponseBean = new ReportsListResponseStructBean();
            // 请求功能URL
            string url ;
            url = "http://data.cnttts.com:58080/dmz/v1/M0001";
            string postJson = JsonConvert.SerializeObject(RequestBean, Newtonsoft.Json.Formatting.None);

            // 请求后台
            string retmp = PostFunction(url, postJson);

            ResponseBean = JsonConvert.DeserializeObject<ReportsListResponseStructBean>(retmp);
        }
       
        public string PostFunction(string url, string postJson)
        {
            string Result = "";
            string serviceAddress = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/json";
            string strContent = postJson;
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            // Encoding.GetEncoding(encoding)
            StreamReader reader = new StreamReader(response.GetResponseStream());
            Result = reader.ReadToEnd();
            Console.WriteLine(Result);
            return Result;

        }

    }
}