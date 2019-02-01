using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jint;
public partial class JintTest : System.Web.UI.Page
{
    public delegate string JintDelegate(string s);
    protected void Page_Load(object sender, EventArgs e)
    {
        //var add3 = new Engine()
        //    .Execute("function add2(a, b) { return a + b; }")
        //    .GetValue("add2")
        //    ;
        //string o = (add3.Invoke(1, 2)).ToString(); // -> 3
        //Response.Write(o);
        JintDelegate dataMethod = new JintDelegate(DataMethod);

        string data = Request.QueryString["data"];
        string method = Request.QueryString["method"];//RESTful

        if (!string.IsNullOrEmpty(method))
        {
            string jsCode = "function fun1(s){return '方法:fun1</br>参数:'+s;}; ";

            jsCode += "function fun2(s){ ";
            jsCode += "  if(s.length>0){  ";
            jsCode += "     s=s+';length:'+s.length;  ";
            jsCode += "     return  '方法:fun2</br>参数:'+s+'</br>后台方法：'+dataMethod(s);";
            jsCode += "  }";
            jsCode += "  else{return '参数为空'};";
            jsCode += "};";

            jsCode += "function fun3(){ ";
            jsCode += " return '无参函数';";
            jsCode += "};";
            var engine = new Engine()
                .SetValue("dataMethod", dataMethod)
                .Execute(jsCode)
                ;
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    data = "";
                }
                var r = engine.Invoke(method, data);
                Response.Write(r);
            }
            catch (SystemException ex)
            {
                Response.Write("参数异常</br>");
                Response.Write(ex.Message);
            }
        }
        else
        {
            Response.Write("no method");
        }

    }
    public string DataMethod(string str)
    {
        //数据库操作
        return ("数据库操作成功.</br>参数：" + str);
    }

}