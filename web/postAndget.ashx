<%@ WebHandler Language="C#" Class="postAndget" %>

using System;
using System.Web;

public class postAndget : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int i = context.Request.Form.AllKeys.Length;
        int i2 = context.Request.QueryString.AllKeys.Length;
        System.IO.Stream s = context.Request.InputStream;
        byte[] byts = new byte[context.Request.InputStream.Length];
        context.Request.InputStream.Read(byts, 0, byts.Length);
        string req = System.Text.Encoding.Default.GetString(byts);
        req = context.Server.UrlDecode(req);
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}