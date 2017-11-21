using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace workSpace
{
    public class work : System.Web.HttpRequestBase
    {
        public void dowork(string text)
        {
            lock (this)
            {
                dowork2(text);
                //while (true)
                //{
                //    dowork2();
                //    System.Threading.Thread.Sleep(100);
                //}
            }
        }
        public void doworkempty( ){
        }
        public void dowork2(string text)
        {
            System.IO.StreamWriter sr = null;
            try
            {

                string filename = System.Web.Hosting.HostingEnvironment.MapPath("~") + "\\log.txt";


                if (!System.IO.File.Exists(filename))
                {
                    sr = System.IO.File.CreateText(filename);
                }
                else
                {
                    sr = System.IO.File.AppendText(filename);
                }
                for (int i = 0; i < 99999; i++)
                {
                    //sr.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH-mm-ss] "));
                    sr.WriteLine(text+"tag:" + i.ToString());
                }
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }


        }
    }

}
