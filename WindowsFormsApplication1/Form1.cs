using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class RequestHead
        {
            public string apiKey;
            public string signature;
            public string payload;
        }

        public class RequestData
        {
            public RequestData() { }
            // 请求头对象
            public RequestHead head { get; set; }

            // 请求体对象
            public RequestBody body { get; set; }
        }
        public class RequestBody
        {
            public string request;
            public string nonce;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string apiKey = @"cndYoNyd8Tp2g1rAslKFPCcuxYklO3PEprVrlTYMT5l";
            string apiSecret = @"ms0cM9Hd1FgEkR6p9TZYVWfw9yDiO3OXg7o2mMhvvx8";

            RequestBody reqBody = new RequestBody();

            string baseUrl = @"https://api.bitfinex.com";
            string url = @"/v1/account_infos";
            reqBody.request = url;
            //DateTime d = new DateTime(2017,11,22);
            reqBody.nonce = TimeHelp.GetTimeStamp(DateTime.Now);
            //reqBody.nonce = "1511318188781";

            string payload = Base64Encode(Encoding.UTF8, JsonConvert.SerializeObject(reqBody, Newtonsoft.Json.Formatting.None));
            string signature = EncryptUtil.HmacSha384(payload, apiSecret);

            RequestHead reqHead = new RequestHead();

            reqHead.apiKey = apiKey;
            reqHead.payload = payload;
            reqHead.signature = signature;
            RequestData req = new RequestData();
            req.body = reqBody;
            req.head = reqHead;
            //string postJson = JsonConvert.SerializeObject(req, Newtonsoft.Json.Formatting.None);
            string retmp=PostFunction(baseUrl + url, req);
            //PostDataToWX(baseUrl + url, req);
        }
        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }
        public string PostFunction(string url, RequestData req)
        {
            string Result = "";
            string serviceAddress = url;
            HttpWebRequest request = null;
            //if (serviceAddress.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            //{
            //    request = WebRequest.Create(serviceAddress) as HttpWebRequest;
            //    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            //    request.ProtocolVersion = HttpVersion.Version11;
            //    // 这里设置了协议类型。
            //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
            //    request.KeepAlive = false;
            //    ServicePointManager.CheckCertificateRevocationList = true;
            //    ServicePointManager.DefaultConnectionLimit = 100;
            //    ServicePointManager.Expect100Continue = false;
            //}
            //else
            //{
                request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            //}
            //request.Credentials = CredentialCache.DefaultCredentials;

            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("mrzhangmh:Hello123456!"));
            request.Credentials = new NetworkCredential("mrzhangmh", "Hello123456!");
            //request.PreAuthenticate = true;

            //request.UseDefaultCredentials = true;
            //request.UseDefaultCredentials = true; request.PreAuthenticate = true;
            // authentication
            //var cache = new CredentialCache();
            //cache.Add(new Uri(url), "Basic", new NetworkCredential("mrzhangmh", "Hello123456!"));
            //request.Credentials = cache;

            //request.Credentials= new NetworkCredential("min", "tel15159519510"); 
            request.Headers.Add("X-BFX-APIKEY", req.head.apiKey);
            request.Headers.Add("X-BFX-PAYLOAD", req.head.payload);
            request.Headers.Add("X-BFX-SIGNATURE", req.head.signature);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            string strContent = JsonConvert.SerializeObject(req.body, Newtonsoft.Json.Formatting.None);
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
        private void PostDataToWX(string url, RequestData req)
        {
            string postData = JsonConvert.SerializeObject(req.body, Newtonsoft.Json.Formatting.None);
            //postData = "";
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Headers.Add("X-BFX-APIKEY", req.head.apiKey);
                request.Headers.Add("X-BFX-PAYLOAD", req.head.payload);
                request.Headers.Add("X-BFX-SIGNATURE", req.head.signature);
                //request.Headers.Add("X-BFX-APIKEY", "N1iWv9cqnB0kM5gJKmBYu2NtmCC1HSLkmm8JByRSD4E");
                //request.Headers.Add("X-BFX-PAYLOAD", "eyJyZXF1ZXN0IjoiL3YxL2FjY291bnRfaW5mb3MiLCJub25jZSI6IjE1MTEzMTgxODg3ODEifQ==");
                //request.Headers.Add("X-BFX-SIGNATURE", "dfdffa4f1b4584ed0e153353f6236857e0ec9a2a2afbca96585b05bc4826e97b0a784c2f46d22ae1c77f03bdc2c1d326");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();


            }
            catch (Exception ex)
            {

            }

        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
    }
}
