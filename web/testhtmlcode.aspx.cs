using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testhtmlcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string v = "2aaa\aa\\\"aaa";

        ////string aa = "<input type=\"text\" id=\"abc\" value=\"" + v.Replace("\"", "&quot;") + "\" />";
        //ggs.InnerHtml = v.Replace("\"", "&quot;");
        //Div1.InnerHtml = v;
        //NormalClass c1 = new NormalClass();
        //NormalClass c21 = new NormalClass();
        //Singleton a1 = Singleton.GetInstance();
        //Singleton a21 = Singleton.GetInstance();
        //string ma = chatManager.a;
        //chatManager d1 = new chatManager();
        //chatManager d21 = new chatManager();
        //TestWeb.Singleton s1 = TestWeb.Singleton.GetInstance();
        //TestWeb.Singleton s2 = TestWeb.Singleton.GetInstance();
        //bool r = object.Equals(s1, s2);

        //TestWeb.SingletonMultiThread c1 = TestWeb.SingletonMultiThread.GetInstance();
        //TestWeb.SingletonMultiThread c2 = TestWeb.SingletonMultiThread.GetInstance();
        //bool r2 = object.Equals(c1, c2);
        //TestWeb.Singleton2 d1 = TestWeb.Singleton2.GetInstance();
        //TestWeb.Singleton2 d2 = TestWeb.Singleton2.GetInstance();
        //bool r3 = object.Equals(d1, d2);
        //classr cr = new classr("abc");
        //classr cr2 = new classr("abc2");
        string abc2="hel lo";
        abc.Value = abc2.Replace(" ","&nbsp;");
        ggs.InnerHtml = "<input style=\" width:265px;  ; \"  type=\"text\" id=\"bz\"   value=\"&lt;&nbsp;&gt;&amp;&quot;;\" />";
        
    }
 
}

 

public class classr
{
    const string a = "a";
    readonly string b = "b";
    public classr(string bv)
    {
        b = bv;
    }
    //public void edit(string bv){
    //    b = bv;
    //}
}

public class chatManager
{
    public static string a="dddd";
    public string b;
    static chatManager()
        {
            StartCheckState();
        }
    public static void  StartCheckState(){}
}
public class NormalClass
{
    public NormalClass()
    {
    }
}
public class Singleton{
    private static Singleton instance;
    private Singleton()
    {
    }
    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }
}
