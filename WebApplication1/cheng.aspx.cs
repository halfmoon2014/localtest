using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace WebApplication_cheng
{
    public partial class cheng : System.Web.UI.Page
    {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        protected void Page_Load(object sender, EventArgs e)
        {
            Task<string> task = new Task<string>(() => test());
            task.Start();
            string a=task.Result;
        }
        public string test()
        {
            string apiKey = @"N1iWv9cqnB0kM5gJKmBYu2NtmCC1HSLkmm8JByRSD4E";
            string apiSecret = @"2CGCU3DvYvXxlUz4slvJfvPOQpDO0GtBkDw3aNzug7s";
            
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
            var result =  PostFunction(baseUrl + url, req);
            //PostDataToWX(baseUrl + url, req);
            //Request_WebClient(baseUrl + url, req);   
            return "";            
            
        }
        public async Task<string> PostFunction(string url, RequestData req)
        {           
            
            string serviceAddress = url;
            HttpWebRequest request = null;
            if (serviceAddress.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(serviceAddress) as HttpWebRequest;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request.ProtocolVersion = HttpVersion.Version10;
                request.UserAgent = DefaultUserAgent;
                // 这里设置了协议类型。
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;// SecurityProtocolType.Tls1.2; 
                request.KeepAlive = false;
                ServicePointManager.CheckCertificateRevocationList = true;
                ServicePointManager.DefaultConnectionLimit = 100;
                ServicePointManager.Expect100Continue = false;
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            }
            
            //string user = "mrzhangmh";
            //string pwd = "Hello123456!";
            //string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(user + ":" + pwd));
            //request.Headers.Add("Authorization", auth);

            // authentication
             //var cache = new CredentialCache();
             //cache.Add(new Uri(url), "Basic", new NetworkCredential("user", "secret"));
             //request.Credentials = cache;

            //request.Credentials= new NetworkCredential(user, pwd); 
            //request.Headers.Add("X-BFX-APIKEY", req.head.apiKey);
            //request.Headers.Add("X-BFX-PAYLOAD", req.head.payload);
            //request.Headers.Add("X-BFX-SIGNATURE", req.head.signature);

            request.Headers.Add($"X-BFX-APIKEY: {req.head.apiKey}");
            request.Headers.Add($"X-BFX-PAYLOAD: {req.head.payload}");
            request.Headers.Add($"X-BFX-SIGNATURE: {req.head.signature}");

            request.Method = "POST";
            request.ContentType = "application/json";         
            //request.Accept= "application/json";

            string strContent = JsonConvert.SerializeObject(req.body, Newtonsoft.Json.Formatting.None);
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
                dataStream.Close();
            }

            
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //string encoding = response.ContentEncoding;
            //if (encoding == null || encoding.Length < 1)
            //{
            //    encoding = "UTF-8"; //默认编码  
            //}
            //// Encoding.GetEncoding(encoding)
            //StreamReader reader = new StreamReader(response.GetResponseStream());
            //Result = reader.ReadToEnd();            
            return await GetResponse(request);
                  

        }

        public async Task<string> GetResponse(HttpWebRequest request)
        {
            string returnedData = "";
            var response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                returnedData = await reader.ReadToEndAsync();
                return (returnedData);
            }

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

        public static string GetTimeStamp(System.DateTime time)
        {
            long ts = ConvertDateTimeToInt(time);
            return ts.ToString();
        }
        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
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
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        /// <summary>
        /// POST一段信息给微信服务器
        /// </summary>
        /// <param name="url">目标方法的API的URL</param>
        /// <param name="postData">POS数据</param>
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


        /// <summary>
        /// 通过WebClient类Post数据到远程地址，需要Basic认证；
        /// 调用端自己处理异常
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="paramStr">name=张三&age=20</param>
        /// <param name="encoding">请先确认目标网页的编码方式</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Request_WebClient(string uri, RequestData req)
        {
            // string paramStr, Encoding encoding, string username, string password
            string username="mrzhangmh";
            string password="Hello123456!";
            string paramStr = JsonConvert.SerializeObject(req.body, Newtonsoft.Json.Formatting.None); 
            Encoding encoding = Encoding.UTF8;

            string result = string.Empty;

            WebClient wc = new WebClient();

            // 采取POST方式必须加的Header
            //wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            wc.Headers.Add("Content-Type", "application/json");
            byte[] postData = encoding.GetBytes(paramStr);

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                wc.Credentials = GetCredentialCache(uri, username, password);
                wc.Headers.Add("Authorization", GetAuthorization(username, password));
            }
            wc.Headers.Add("X-BFX-APIKEY", req.head.apiKey);
            wc.Headers.Add("X-BFX-PAYLOAD", req.head.payload);
            wc.Headers.Add("X-BFX-SIGNATURE", req.head.signature);
            byte[] responseData = wc.UploadData(uri, "POST", postData); // 得到返回字符流
            return encoding.GetString(responseData);// 解码                  
        }
        #region # 生成 Http Basic 访问凭证 #

        private static CredentialCache GetCredentialCache(string uri, string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            CredentialCache credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Basic", new NetworkCredential(username, password));

            return credCache;
        }

        private static string GetAuthorization(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }

        #endregion



    }


}