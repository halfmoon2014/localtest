using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ThoughtWorks.QRCode.Codec;
using GenCode128;
using System.Text.RegularExpressions;
using System.Net;

namespace Printer.bill
{
    public class PrintCore
    {
        PrintDocument PrintDoc = new PrintDocument();
        List<object> PrintList = new List<object>();
        int CurrentPageNo = 0;
        Print print;
        Font font = new Font("微软雅黑", 6, FontStyle.Regular);
        Font font5Reg = new Font("微软雅黑", 5, FontStyle.Regular);
        Font font4 = new Font("微软雅黑", 4, FontStyle.Regular);
        Font font8Reg = new Font("微软雅黑", 8, FontStyle.Regular);
        Font font9Reg = new Font("微软雅黑", 9, FontStyle.Regular);
        Font font7 = new Font("微软雅黑", 7, FontStyle.Bold);
        Font font9 = new Font("微软雅黑", 9, FontStyle.Bold);
        Font font8 = new Font("微软雅黑", 8, FontStyle.Bold);
        Font font5 = new Font("微软雅黑", 5, FontStyle.Bold);

        Font font10 = new Font("微软雅黑", 10, FontStyle.Bold);

        Font FontTitle = new Font("微软雅黑", 6, FontStyle.Bold);
        Font FontName = new Font("微软雅黑", 6, FontStyle.Bold);
        Brush brush = new SolidBrush(Color.Black);
        Brush brushred = new SolidBrush(Color.Red);
        Brush brushWhite = new SolidBrush(Color.White);
        Pen pen = new Pen(Color.Gray, 0.1f);
        Pen penBlack = new Pen(Color.Black, 0.1f);
        Pen penWhite = new Pen(Color.White, 0.1f);
        Font FontCode128 = new Font("微软雅黑", 7, FontStyle.Regular);

        int curr = 0;
        int currY = 0;
        public void Done(Print _print)
        {
            try
            {
                print = _print;
                print.setStatusCallback("下载中数据中...");
                string result = tools.HttpWebRequestTools.PostFunctionjson(LocalConfig.GetConfigValue("gateway") + LocalConfig.GetConfigValue("labelListUrl"), "");
                Dictionary<string, object> dc = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                if (dc["errcode"].ToString() == "0")
                {

                    JArray jArr = (JArray)dc["data"];
                    List<string> printListGroup = new List<string>();
                    for (int i = 0; i < jArr.Count; i++)
                    {
                        string spid = jArr[i]["spid"].ToString().Trim();
                        string labelInfo = tools.HttpWebRequestTools.PostFunctionjson(LocalConfig.GetConfigValue("gateway") + LocalConfig.GetConfigValue("labelInfoUrl"), "{\"spid\":\"" + spid + "\"}");
                        printListGroup.Add(labelInfo);
                        if ((i + 1) % 6 == 0)
                        {
                            PrintList.Add(printListGroup);
                            printListGroup = new List<string>();
                        }
                        if (PrintList.Count == 2)//测试代码
                        {
                            break;
                        }
                    }
                    DrawContent();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //this.toolStripStatusLabel1.Text = ex.Message;
            }

        }
        private void DrawContent()
        {
            PrintDoc.PrintPage += new PrintPageEventHandler(this.PrintPage);
            print.setStatusCallback("打印中...");
            PrintDoc.Print();
            print.setStatusCallback("打印完成...");
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter; //单位为毫米 PrintList
            int top = 6;//顶部留白
            int left = 1;//左边边留白
            int topMagin = 1;//上边距离
            int leftMagin = 1; //左边距离
            int downMagin = 3;//下边距离
            int rightMagin = 7; //右边距离
            int drawWidth = 134;//内容宽
            int drawHeight = 56;//内容高

            List<string> printListGroup = (List<string>)PrintList[CurrentPageNo];
            //                 Tag_Draw(left + leftMagin, top + topMagin, e.Graphics, printListGroup[3]);
            //                    return;
            for (int j = 0; j < printListGroup.Count; j++)//6个一组，按竖着打印，
            /* 1 4
             * 2 5
             * 3 6
             */
            {
                int topx = 0;
                if (j <= 2)
                    topx = left + leftMagin;
                else
                    topx = left + drawWidth + leftMagin + rightMagin;

                int topy = top + topMagin + (j % 3) * drawHeight + (j % 3) * downMagin;
                Tag_Draw(topx, topy, e.Graphics, printListGroup[j]);
            }
            CurrentPageNo += 1;
            if (CurrentPageNo == PrintList.Count)
                e.HasMorePages = false;
            else
                e.HasMorePages = true;


        }
        private void Tag_Draw(int topx, int topy, Graphics grap, string content)
        {
            Dictionary<string, object> dc = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
            if (dc["errcode"].ToString() != "0")
            {
                return;
            }
            JArray jArr = (JArray)dc["data"];
            if (jArr.Count == 0)
            {
                return;
            }

            //排版开始
            int currenttopx = topx + 5;
            int currenttopy = topy + 8;
            string imgPath = @"http://webt.lilang.com:9001";
            QRCodeEncoder qrcode = new QRCodeEncoder();
            qrcode.QRCodeScale = 1;
            qrcode.QRCodeVersion = 4;
            Bitmap bitQR = qrcode.Encode(getItemInfo(jArr, "二维码"));
            //国标码
            Ean13 _ean13 = new Ean13(getItemInfo(jArr, "国标码"));
            _ean13.Scale = 0.8f;
            //唯一码
            Image ImgCode128 = Code128Rendering.MakeBarcodeImage(getItemInfo(jArr, "唯一码"), 1, false);
            Bitmap bitCode128 = new Bitmap(ImgCode128);
            //标题
            //log       
            WebRequest webRequest = WebRequest.Create(new Uri((string)(imgPath + "/" + "tl_yf/sxtb/lilanz-ku-white.png")));
            WebResponse webResponse = webRequest.GetResponse();
            Bitmap ico = new Bitmap(webResponse.GetResponseStream());
            grap.DrawImage(ico, new Rectangle(currenttopx, currenttopy - 6, 23, 4), 0, 0, ico.Width, ico.Height, GraphicsUnit.Pixel);

            DrawItem2(grap, "品名 :", getItemInfo(jArr, "品名"), currenttopx, currenttopy);
            grap.DrawString("统一零售价 :", font8Reg, brush, new Point(currenttopx + 50, currenttopy - 4));
            grap.DrawString("¥" + getItemInfo(jArr, "零售价"), font9, brush, new Point(currenttopx + 67, currenttopy - 5));
            //第一列  
            currenttopy += 6;
            DrawItem(grap, "尺码 ", getItemInfo(jArr, "鞋码"), currenttopx, currenttopy);
            currenttopy += 4;
            DrawItem(grap, "鞋型：", getItemInfo(jArr, "鞋型"), currenttopx, currenttopy);
            currenttopy += 4;
            DrawItem(grap, "等级：", getItemInfo(jArr, "等级"), currenttopx, currenttopy);
            currenttopy += 5;
            DrawItem2(grap, "货号：", getItemInfo(jArr, "货号"), currenttopx, currenttopy);
            currenttopy += 5;
            grap.FillRectangle(brushred, new Rectangle(currenttopx + 1, currenttopy, 22, 22));
            Font Fontcm = new Font("微软雅黑", 36, FontStyle.Bold);
            grap.DrawString(Regex.Replace(getItemInfo(jArr, "鞋码"), @"(.*\()(.*)(\).*)", "$2"), Fontcm, brush, new Point(currenttopx + 2, currenttopy + 1));
            //grap.DrawImage(bitQR, new Rectangle(currenttopx + 1, currenttopy, 22, 22), 0, 0, bitQR.Width, bitQR.Height, GraphicsUnit.Pixel);
            //第二列
            currenttopx += 33;
            currenttopy -= 18;
            List<Dictionary<string, string>> mariList = MarifList(getItemInfo(jArr, "纤维含量"));
            for (int i = 0; i < mariList.Count; i++)
            {
                if (i == 0)
                    DrawItem(grap, "材质 ：", mariList[i]["sz"], currenttopx, currenttopy);
                else
                {
                    DrawItem(grap, "材质 ：", mariList[i]["sz"], currenttopx + 7, currenttopy);
                    currenttopy += 3;
                }
            }
            currenttopy += 15;

            DrawItem(grap, "检验：", "", currenttopx, currenttopy);

            webRequest = WebRequest.Create(new Uri((string)(imgPath + "/" + "tl_yf/sxtb/不干胶合格.png")));
            webResponse = webRequest.GetResponse();
            ico = new Bitmap(webResponse.GetResponseStream());
            grap.DrawImage(ico, new Rectangle(currenttopx + 8, currenttopy - 4, 9, 7), 0, 0, ico.Width, ico.Height, GraphicsUnit.Pixel);

            currenttopy += 6;
            DrawItem(grap, "执行标准：", getItemInfo(jArr, "执行标准"), currenttopx, currenttopy);
            currenttopy += 6;
            grap.DrawImage(bitQR, new Rectangle(currenttopx, currenttopy, 15, 14), 0, 0, bitQR.Width, bitQR.Height, GraphicsUnit.Pixel);
            //第三列           

            Uri myUri = new Uri((string)(imgPath + "/" + getItemInfo(jArr, "图片")));
            webRequest = WebRequest.Create(myUri);
            webResponse = webRequest.GetResponse();
            ico = new Bitmap(webResponse.GetResponseStream());
            grap.DrawImage(ico, new Rectangle(topx + 62, topy + 17, 25, 10), 0, 0, ico.Width, ico.Height, GraphicsUnit.Pixel);
            DrawItem4(grap, "颜色：", getItemInfo(jArr, "商品档案名称").Split('-')[1], currenttopx + 35, currenttopy - 11);
            currenttopx += 22;
            currenttopy -= 2;
            _ean13.DrawEan13Barcode(grap, new Point(currenttopx, currenttopy));//ean 13
            currenttopx -= 1;
            currenttopy += 7;
            grap.DrawImage(bitCode128, new Rectangle(currenttopx, currenttopy, 30, 3), 0, 0,
                bitCode128.Width, bitCode128.Height, GraphicsUnit.Pixel);
            currenttopx += 1;
            currenttopy += 3;
            grap.DrawString(getItemInfo(jArr, "唯一码"), FontCode128, brush, new Point(currenttopx, currenttopy));
            currenttopx += 7;
            currenttopy += 4;
            grap.DrawString("(仅供内部使用)", font4, brush, new Point(currenttopx, currenttopy));
            //第四列
            currenttopx += 34;
            currenttopy -= 48;
            DrawItem(grap, "品名 ：", getItemInfo(jArr, "品名"), currenttopx, currenttopy);
            currenttopy += 4;
            DrawItem(grap, "货号：", getItemInfo(jArr, "货号"), currenttopx, currenttopy);
            currenttopy += 4;
            DrawItem(grap, "尺码：", getItemInfo(jArr, "鞋码"), currenttopx, currenttopy);
            currenttopy += 4;
            DrawItem3(grap, "鞋型：", getItemInfo(jArr, "鞋型"), currenttopx, currenttopy);
            currenttopy += 3;
            for (int i = 0; i < mariList.Count; i++)
            {
                if (i == 0)
                    DrawItem3(grap, "材质：", mariList[i]["sz"], currenttopx, currenttopy);
                else
                {
                    DrawItem3(grap, "材质：", mariList[i]["sz"], currenttopx + 6, currenttopy);
                    currenttopy += 3;
                }

            }
            currenttopy += 3;
            DrawItem3(grap, "颜色：", getItemInfo(jArr, "商品档案名称").Split('-')[1], currenttopx, currenttopy);
            currenttopy += 3;
            DrawItem3(grap, "等级：", getItemInfo(jArr, "等级"), currenttopx, currenttopy);
            currenttopy += 3;
            DrawItem3(grap, "执行标准：", getItemInfo(jArr, "执行标准"), currenttopx, currenttopy);
            currenttopy += 3;
            DrawItem3(grap, "检验：", getItemInfo(jArr, "检验"), currenttopx, currenttopy);
            currenttopy += 4;
            DrawItem3(grap, "统一零售价：", getItemInfo(jArr, "零售价"), currenttopx, currenttopy);
            currenttopx -= 1;
            currenttopy += 3;
            // _ean13.Scale = 0.9f;
            _ean13.DrawEan13Barcode(grap, new Point(currenttopx, currenttopy));//ean 13
            currenttopx -= 1;
            currenttopy += 8;
            grap.DrawImage(bitCode128, new Rectangle(currenttopx, currenttopy, 30, 3), 0, 0,
                bitCode128.Width, bitCode128.Height, GraphicsUnit.Pixel);
            currenttopx += 1;
            currenttopy += 3;
            grap.DrawString(getItemInfo(jArr, "唯一码"), FontCode128, brush, new Point(currenttopx, currenttopy));
            currenttopx += 7;
            currenttopy += 3;
            grap.DrawString("(仅供内部使用)", font4, brush, new Point(currenttopx, currenttopy));
        }
        private string getItemInfo(JArray jArr, string key)
        {
            string r = null;
            for (int i = 0; i < jArr.Count; i++)
            {
                foreach (JToken jt in jArr[i])
                {
                    if (jt.Type == JTokenType.Array)
                    {
                        for (int j = 0; j < ((JArray)jt).Count; j++)
                        {
                            JToken jtTM = ((JArray)jt)[j];
                            if (jtTM.Type == JTokenType.Array)
                            {
                                for (int z = 0; z < ((JArray)jtTM).Count; z++)
                                {
                                    JToken jtSPID = ((JArray)jtTM)[z];

                                    if (jtSPID["name"].ToString().Trim() == key)
                                    {
                                        r = jtSPID["value"].ToString().Trim(); break;
                                    }
                                    if (jtSPID["name"].ToString().Trim() == "spid")
                                    {
                                        for (int x = 0; x < ((JArray)(jtSPID["value"])).Count; x++)
                                        {
                                            JToken jtWeiYiMa = ((JArray)(jtSPID["value"]))[x];
                                            for (int y = 0; y < ((JArray)(jtWeiYiMa)).Count; y++)
                                            {
                                                JToken jtOver = ((JArray)(jtWeiYiMa))[y];
                                                if (jtOver["name"].ToString().Trim() == key)
                                                {
                                                    r = jtOver["value"].ToString().Trim(); break;
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                            else
                            {
                                //没这样的数据
                            }
                        }
                    }
                    else
                    {
                        if (jt["name"].ToString().Trim() == key)
                        {
                            r = jt["value"].ToString().Trim(); break;
                        }
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// 成份取值
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        private List<Dictionary<string, string>> MarifList(string jsonStr)
        {
            JArray arr = (JArray)JsonConvert.DeserializeObject(jsonStr);
            List<Dictionary<string, string>> retList = new List<Dictionary<string, string>>();
            for (int i = 0; i < arr.Count; i++)
            {
                JToken jt = arr[i];
                Dictionary<string, string> item = new Dictionary<string, string>();
                //         item.Add("pdjg", jt["pdjg"].ToString());
                item.Add("sz", jt["sz"].ToString());
                retList.Add(item);
            }
            return retList;
        }
        private void DrawItem(Graphics g, string name, string value, int left, int top)
        {
            float FontWidth = g.MeasureString(name, font).Width;
            g.DrawString(name, font, brush, new Point(left, top));
            g.DrawString(value, font, brush, new Point(left + (int)FontWidth, top));
        }
        //加粗
        private void DrawItem2(Graphics g, string name, string value, int left, int top)
        {
            value = value.TrimEnd();

            float FontWidth = g.MeasureString(name, FontName).Width;
            g.DrawString(name, FontName, brush, new Point(left, top));
            if (value.IndexOf(' ') < 0)
                g.DrawString(value, font7, brush, new Point(left + (int)FontWidth, top));
            else
            {
                g.DrawString(value.Split(' ')[0], font7, brush, new Point(left + (int)FontWidth, currY));
                currY = currY + 3;
                g.DrawString(value.Split(' ')[1], font7, brush, new Point(left + (int)FontWidth, currY));
            }
        }
        //小
        private void DrawItem3(Graphics g, string name, string value, int left, int top)
        {
            float FontWidth = g.MeasureString(name, font5Reg).Width;
            g.DrawString(name, font5Reg, brush, new Point(left, top));
            g.DrawString(value, font5Reg, brush, new Point(left + (int)FontWidth, top));
        }

        //小黑
        private void DrawItem4(Graphics g, string name, string value, int left, int top)
        {
            float FontWidth = g.MeasureString(name, font5).Width;
            g.DrawString(name, font5, brush, new Point(left, top));
            g.DrawString(value, font5, brush, new Point(left + (int)FontWidth, top));
        }

        /// <summary>
        /// 刷新打印机的状态
        /// </summary>
        public string findPrt()
        {
            string PrinterName = Properties.Settings.Default.PrtName;
            bool isFind = false;
            foreach (string pName in PrinterSettings.InstalledPrinters)
            {
                if (PrinterName.Trim().ToUpper() == pName.Trim().ToUpper())
                {
                    PrintDoc.PrinterSettings.PrinterName = PrinterName;
                    isFind = true;
                    break;
                }
            }
            if (!isFind)
                return "查不到名称:" + PrinterName + "打印机";
            else
                return "名称:" + PrinterName + "已找到";
        }
    }
}
