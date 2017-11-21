<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        //在应用程序启动时运行的代码
        //在新会话启动时运行的代码
        //workSpace.work myWork = new workSpace.work();

        //System.Threading.Thread thread = new System.Threading.Thread(myWork.doworkempty);
        //thread.Start(a);

        //System.Threading.Thread t = new System.Threading.Thread(() =>
        //{
        //    myWork.dowork("hello");
        //});
        //t.IsBackground = true;
        //t.Start();         

        //while (true)
        //{
        //    thread.Start();
        //}


    }
    void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;

        string requestPath = context.Request.Path.ToLower();
        if (requestPath.Contains("multiplepage.aspx"))
        {

        }
    }

    void Application_endrequest(object sender, EventArgs e)
    {
         HttpContext context = ((HttpApplication)sender).Context;

        string requestPath = context.Request.Path.ToLower();
    }

    void Application_End(object sender, EventArgs e)
    {
        //在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {


    }

    void Session_End(object sender, EventArgs e)
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }

</script>
