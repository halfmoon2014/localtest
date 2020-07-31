using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Printer.tools
{
    public class HttpWebRequestTools
    {
        public static string PostFunctionjson(string url, string postJson)
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
            //Console.WriteLine(Result);
            return Result;

        }
    }
}
