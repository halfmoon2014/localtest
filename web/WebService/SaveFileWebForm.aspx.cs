﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class WebService_SaveFileWebForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Files.Count > 0)
        {
            try
            {
                //得到客户端上传的文件
                HttpPostedFile file = Request.Files[0];
                Encoding gb = Encoding.GetEncoding("utf-8");
                byte[] bytes = gb.GetBytes(file.FileName);

                //服务器端要保存的路径
                string filePath = "d:\\web_tlerp\\MyUpload\\file\\" + System.Web.HttpUtility.UrlDecode(file.FileName, System.Text.Encoding.UTF8) + ".rtf";
                file.SaveAs(filePath);
                //返回结果
                Response.Write("Success");
            }
            catch
            {
                Response.Write("Error");
            }
        }
        else
        {
            Response.Write("Error1");
        }
    }
}