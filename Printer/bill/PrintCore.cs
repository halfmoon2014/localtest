using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Net;
using System.Text.RegularExpressions;
using GenCode128;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Printer.Properties;
using Printer.tools;
using ThoughtWorks.QRCode.Codec;

namespace Printer.bill {
	// Token: 0x02000012 RID: 18
	public class PrintCore {
		// Token: 0x060000A7 RID: 167 RVA: 0x00006698 File Offset: 0x00004898
		public void Done(Print _print) {
			try {
				this.print = _print;
				this.print.setStatusCallback("下载中数据中...");
				string result = HttpWebRequestTools.PostFunctionjson(LocalConfig.GetConfigValue("gateway") + LocalConfig.GetConfigValue("labelListUrl"), "{\"djlx\":\"12610\",\"zt\":\"0\"}");
				Dictionary<string, object> dc = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
				bool flag = dc["errcode"].ToString() == "0";
				if(flag) {
					JArray jArr = ( JArray )dc["data"];
					List<string> printListGroup = new List<string>();
					List<object> idlist = new List<object>();
					for(int i = 0; i < jArr.Count; i++) {
						string spid = jArr[i]["spid"].ToString().Trim();
						string labelInfo = HttpWebRequestTools.PostFunctionjson(LocalConfig.GetConfigValue("gateway") + LocalConfig.GetConfigValue("labelInfoUrl"), "{\"spid\":\"" + spid + "\"}");
						printListGroup.Add(labelInfo);
						bool flag2 = ( i + 1 ) % 6 == 0;
						if(flag2) {
							this.PrintList.Add(printListGroup);
							printListGroup = new List<string>();
						}
						Dictionary<string, int> idmap = new Dictionary<string, int>();
						string id = jArr[i]["id"].ToString().Trim();
						idmap.Add("id", int.Parse(id));
						idlist.Add(idmap);
					}
					bool flag3 = jArr.Count < 6;
					if(flag3) {
						this.PrintList.Add(printListGroup);
					}
					string idjsonstr = JsonConvert.SerializeObject(new Dictionary<string, object>
					{
						{
							"zdr",
							"system"
						},
						{
							"idList",
							idlist
						}
					});
					string upresult = HttpWebRequestTools.PostFunctionjson(LocalConfig.GetConfigValue("gateway") + LocalConfig.GetConfigValue("labelUpUrl"), idjsonstr);
					bool flag4 = jArr.Count == 0;
					if(flag4) {
						this.print.setStatusCallback("没有待打印数据...");
					} else {
						this.DrawContent();
					}
				}
			} catch(Exception ex) {
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000068E0 File Offset: 0x00004AE0
		private void DrawContent() {
			this.PrintDoc.PrintPage += this.PrintPage;
			this.print.setStatusCallback("打印中...");
			this.PrintDoc.Print();
			this.print.setStatusCallback("打印完成...");
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006940 File Offset: 0x00004B40
		private void PrintPage(object sender, PrintPageEventArgs e) {
			e.Graphics.PageUnit = GraphicsUnit.Millimeter;
			int top = 7;
			int left = 5;
			int topMagin = 1;
			int leftMagin = 1;
			int downMagin = 3;
			int rightMagin = 8;
			int drawWidth = 134;
			int drawHeight = 56;
			List<string> printListGroup = ( List<string> )this.PrintList[this.CurrentPageNo];
			for(int i = 0; i < printListGroup.Count; i++) {
				bool flag = i <= 2;
				int topx;
				if(flag) {
					topx = left + leftMagin;
				} else {
					topx = left + drawWidth + leftMagin + rightMagin;
				}
				int topy = top + topMagin + i % 3 * drawHeight + i % 3 * downMagin;
				this.Tag_Draw(topx, topy, e.Graphics, printListGroup[i]);
			}
			this.CurrentPageNo++;
			bool flag2 = this.CurrentPageNo == this.PrintList.Count;
			if(flag2) {
				e.HasMorePages = false;
			} else {
				e.HasMorePages = true;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00006A38 File Offset: 0x00004C38
		private void Tag_Draw(int topx, int topy, Graphics grap, string content) {
			Dictionary<string, object> dc = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
			bool flag = dc["errcode"].ToString() != "0";
			if(!flag) {
				JArray jArr = ( JArray )dc["data"];
				bool flag2 = jArr.Count == 0;
				if(!flag2) {
					grap.FillRectangle(this.brush, new Rectangle(topx - 1, topy - 1, 96, 14));
					grap.FillRectangle(this.brush, new Rectangle(topx - 1, topy + 56 - 1, 96, 2));
					grap.FillRectangle(this.brush, new Rectangle(topx - 1, topy - 1, 2, 58));
					grap.FillRectangle(this.brush, new Rectangle(topx + 95 - 2, topy - 1, 2, 58));
					int currenttopx = topx + 5;
					int currenttopy = topy + 8;
					string imgPath = "http://webt.lilang.com:9001";
					Bitmap bitQR = new QRCodeEncoder {
						QRCodeScale = 1,
						QRCodeVersion = 4
					}.Encode(this.getItemInfo(jArr, "二维码"));
					Ean13 _ean13 = new Ean13(this.getItemInfo(jArr, "国标码"));
					_ean13.Scale = 0.8f;
					Image ImgCode128 = Code128Rendering.MakeBarcodeImage(this.getItemInfo(jArr, "唯一码"), 1, false);
					Bitmap bitCode128 = new Bitmap(ImgCode128);
					WebRequest webRequest = WebRequest.Create(new Uri(imgPath + "/tl_yf/sxtb/lilanz-ku-white.png"));
					WebResponse webResponse = webRequest.GetResponse();
					Bitmap ico = new Bitmap(webResponse.GetResponseStream());
					grap.DrawImage(ico, new Rectangle(currenttopx, currenttopy - 6, 23, 4), 0, 0, ico.Width, ico.Height, GraphicsUnit.Pixel);
					grap.DrawString("品名 :", this.font, this.brushWhite, new Point(currenttopx, currenttopy));
					grap.DrawString(this.getItemInfo(jArr, "品名"), this.font, this.brushWhite, new Point(currenttopx + 7, currenttopy));
					grap.DrawString("统一零售价 :", this.font8Reg, this.brushWhite, new Point(currenttopx + 50, currenttopy - 4));
					grap.DrawString("¥" + this.getItemInfo(jArr, "零售价"), this.font14, this.brushWhite, new Point(currenttopx + 67, currenttopy - 5));
					currenttopy += 6;
					this.DrawItem(grap, "尺码 :", this.getItemInfo(jArr, "鞋码"), currenttopx, currenttopy);
					currenttopy += 4;
					this.DrawItem(grap, "鞋型 :", this.getItemInfo(jArr, "鞋型"), currenttopx, currenttopy);
					currenttopy += 4;
					this.DrawItem(grap, "等级 :", this.getItemInfo(jArr, "等级"), currenttopx, currenttopy);
					currenttopy += 5;
					grap.DrawString("货号 :", this.font10, this.brush, new Point(currenttopx, currenttopy - 1));
					grap.DrawString(this.getItemInfo(jArr, "货号"), this.font10, this.brush, new Point(currenttopx + 9, currenttopy - 1));
					grap.DrawLine(this.penBlack, new Point(currenttopx + 28, currenttopy + 6), new Point(currenttopx + 28, currenttopy + 26));
					currenttopy += 5;
					grap.FillRectangle(this.brushred, new Rectangle(currenttopx + 1, currenttopy, 22, 22));
					Font Fontcm = new Font("微软雅黑", 36f, FontStyle.Bold);
					grap.DrawString(Regex.Replace(this.getItemInfo(jArr, "鞋码"), "(.*\\()(.*)(\\).*)", "$2"), Fontcm, this.brush, new Point(currenttopx + 2, currenttopy + 2));
					currenttopx += 33;
					currenttopy -= 18;
					List<Dictionary<string, string>> mariList = this.MarifList(this.getItemInfo(jArr, "纤维含量"));
					for(int i = 0; i < mariList.Count; i++) {
						bool flag3 = i == 0;
						if(flag3) {
							this.DrawItem(grap, "材质 :", mariList[i]["sz"], currenttopx, currenttopy);
						} else {
							this.DrawItem(grap, "材质 :", mariList[i]["sz"], currenttopx + 7, currenttopy);
							currenttopy += 3;
						}
					}
					currenttopy += 15;
					this.DrawItem(grap, "检验 :", "", currenttopx, currenttopy);
					webRequest = WebRequest.Create(new Uri(imgPath + "/tl_yf/sxtb/不干胶合格.png"));
					webResponse = webRequest.GetResponse();
					ico = new Bitmap(webResponse.GetResponseStream());
					grap.DrawImage(ico, new Rectangle(currenttopx + 8, currenttopy - 4, 9, 7), 0, 0, ico.Width, ico.Height, GraphicsUnit.Pixel);
					currenttopy += 6;
					this.DrawItem(grap, "执行标准 :", this.getItemInfo(jArr, "执行标准"), currenttopx, currenttopy);
					currenttopy += 6;
					grap.DrawImage(bitQR, new Rectangle(currenttopx, currenttopy - 2, 15, 14), 0, 0, bitQR.Width, bitQR.Height, GraphicsUnit.Pixel);
					Uri myUri = new Uri(imgPath + "/" + this.getItemInfo(jArr, "图片"));
					webRequest = WebRequest.Create(myUri);
					webResponse = webRequest.GetResponse();
					ico = new Bitmap(webResponse.GetResponseStream());
					grap.DrawImage(ico, new Rectangle(topx + 62, topy + 14, 26, 13), 0, 0, ico.Width, ico.Height, GraphicsUnit.Pixel);
					this.DrawItem4(grap, "颜色 :", this.getItemInfo(jArr, "商品档案名称").Split(new char[]
					{
						'-'
					})[1], currenttopx + 35, currenttopy - 11);
					currenttopx += 22;
					currenttopy -= 2;
					_ean13.DrawEan13Barcode(grap, new Point(currenttopx, currenttopy));
					currenttopx--;
					currenttopy += 7;
					grap.DrawImage(bitCode128, new Rectangle(currenttopx, currenttopy, 30, 3), 0, 0, bitCode128.Width, bitCode128.Height, GraphicsUnit.Pixel);
					currenttopx++;
					currenttopy += 3;
					grap.DrawString(this.getItemInfo(jArr, "唯一码"), this.FontCode128, this.brush, new Point(currenttopx, currenttopy));
					currenttopx += 7;
					currenttopy += 4;
					grap.DrawString("(仅供内部使用)", this.font4, this.brush, new Point(currenttopx, currenttopy - 1));
					currenttopx += 34;
					currenttopy -= 48;
					this.DrawItem(grap, "品名 :", this.getItemInfo(jArr, "品名"), currenttopx, currenttopy);
					currenttopy += 4;
					this.DrawItem(grap, "货号 :", this.getItemInfo(jArr, "货号"), currenttopx, currenttopy);
					currenttopy += 4;
					this.DrawItem(grap, "尺码 :", this.getItemInfo(jArr, "鞋码"), currenttopx, currenttopy);
					currenttopy += 4;
					this.DrawItem3(grap, "鞋型 :", this.getItemInfo(jArr, "鞋型"), currenttopx, currenttopy);
					currenttopy += 3;
					for(int j = 0; j < mariList.Count; j++) {
						bool flag4 = j == 0;
						if(flag4) {
							this.DrawItem3(grap, "材质 :", mariList[j]["sz"], currenttopx, currenttopy);
						} else {
							this.DrawItem3(grap, "材质 :", mariList[j]["sz"], currenttopx + 6, currenttopy);
							currenttopy += 3;
						}
					}
					currenttopy += 3;
					this.DrawItem3(grap, "颜色 :", this.getItemInfo(jArr, "商品档案名称").Split(new char[]
					{
						'-'
					})[1], currenttopx, currenttopy);
					currenttopy += 3;
					this.DrawItem3(grap, "等级 :", this.getItemInfo(jArr, "等级"), currenttopx, currenttopy);
					currenttopy += 3;
					this.DrawItem3(grap, "执行标准 :", this.getItemInfo(jArr, "执行标准"), currenttopx, currenttopy);
					currenttopy += 3;
					this.DrawItem3(grap, "检验 :", this.getItemInfo(jArr, "检验"), currenttopx, currenttopy);
					currenttopy += 4;
					this.DrawItem3(grap, "统一零售价 :", this.getItemInfo(jArr, "零售价"), currenttopx, currenttopy);
					currenttopx--;
					currenttopy += 3;
					_ean13.DrawEan13Barcode(grap, new Point(currenttopx, currenttopy));
					currenttopx--;
					currenttopy += 8;
					grap.DrawImage(bitCode128, new Rectangle(currenttopx, currenttopy, 30, 3), 0, 0, bitCode128.Width, bitCode128.Height, GraphicsUnit.Pixel);
					currenttopx++;
					currenttopy += 3;
					grap.DrawString(this.getItemInfo(jArr, "唯一码"), this.FontCode128, this.brush, new Point(currenttopx, currenttopy));
					currenttopx += 7;
					currenttopy += 3;
					grap.DrawString("(仅供内部使用)", this.font4, this.brush, new Point(currenttopx, currenttopy));
				}
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000072B8 File Offset: 0x000054B8
		private string getItemInfo(JArray jArr, string key) {
			string r = null;
			for(int i = 0; i < jArr.Count; i++) {
				foreach(JToken jt in ( ( IEnumerable<JToken> )jArr[i] )) {
					bool flag = jt.Type == JTokenType.Array;
					if(flag) {
						for(int j = 0; j < ( ( JArray )jt ).Count; j++) {
							JToken jtTM = ( ( JArray )jt )[j];
							bool flag2 = jtTM.Type == JTokenType.Array;
							if(flag2) {
								for(int z = 0; z < ( ( JArray )jtTM ).Count; z++) {
									JToken jtSPID = ( ( JArray )jtTM )[z];
									bool flag3 = jtSPID["name"].ToString().Trim() == key;
									if(flag3) {
										r = jtSPID["value"].ToString().Trim();
										break;
									}
									bool flag4 = jtSPID["name"].ToString().Trim() == "spid";
									if(flag4) {
										for(int x = 0; x < ( ( JArray )jtSPID["value"] ).Count; x++) {
											JToken jtWeiYiMa = ( ( JArray )jtSPID["value"] )[x];
											for(int y = 0; y < ( ( JArray )jtWeiYiMa ).Count; y++) {
												JToken jtOver = ( ( JArray )jtWeiYiMa )[y];
												bool flag5 = jtOver["name"].ToString().Trim() == key;
												if(flag5) {
													r = jtOver["value"].ToString().Trim();
													break;
												}
											}
										}
									}
								}
							}
						}
					} else {
						bool flag6 = jt["name"].ToString().Trim() == key;
						if(flag6) {
							r = jt["value"].ToString().Trim();
							break;
						}
					}
				}
			}
			return r;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00007540 File Offset: 0x00005740
		private List<Dictionary<string, string>> MarifList(string jsonStr) {
			JArray arr = ( JArray )JsonConvert.DeserializeObject(jsonStr);
			List<Dictionary<string, string>> retList = new List<Dictionary<string, string>>();
			for(int i = 0; i < arr.Count; i++) {
				JToken jt = arr[i];
				retList.Add(new Dictionary<string, string>
				{
					{
						"sz",
						jt["sz"].ToString()
					}
				});
			}
			return retList;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000075B8 File Offset: 0x000057B8
		private void DrawItem(Graphics g, string name, string value, int left, int top) {
			float FontWidth = g.MeasureString(name, this.font).Width;
			g.DrawString(name, this.font, this.brush, new Point(left, top));
			g.DrawString(value, this.font, this.brush, new Point(left + ( int )FontWidth, top));
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00007624 File Offset: 0x00005824
		private void DrawItem2(Graphics g, string name, string value, int left, int top) {
			value = value.TrimEnd(Array.Empty<char>());
			float FontWidth = g.MeasureString(name, this.FontName).Width;
			g.DrawString(name, this.FontName, this.brush, new Point(left, top));
			bool flag = value.IndexOf(' ') < 0;
			if(flag) {
				g.DrawString(value, this.font10, this.brush, new Point(left + ( int )FontWidth, top));
			} else {
				g.DrawString(value.Split(new char[]
				{
					' '
				})[0], this.font10, this.brush, new Point(left + ( int )FontWidth, this.currY));
				this.currY += 3;
				g.DrawString(value.Split(new char[]
				{
					' '
				})[1], this.font10, this.brush, new Point(left + ( int )FontWidth, this.currY));
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00007738 File Offset: 0x00005938
		private void DrawItem3(Graphics g, string name, string value, int left, int top) {
			float FontWidth = g.MeasureString(name, this.font5Reg).Width;
			g.DrawString(name, this.font5Reg, this.brush, new Point(left, top));
			g.DrawString(value, this.font5Reg, this.brush, new Point(left + ( int )FontWidth, top));
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000077A4 File Offset: 0x000059A4
		private void DrawItem4(Graphics g, string name, string value, int left, int top) {
			float FontWidth = g.MeasureString(name, this.font5).Width;
			g.DrawString(name, this.font5, this.brush, new Point(left, top));
			g.DrawString(value, this.font5, this.brush, new Point(left + ( int )FontWidth, top));
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00007810 File Offset: 0x00005A10
		public string findPrt() {
			string PrinterName = Settings.Default.PrtName;
			bool isFind = false;
			foreach(object obj in PrinterSettings.InstalledPrinters) {
				string pName = ( string )obj;
				bool flag = PrinterName.Trim().ToUpper() == pName.Trim().ToUpper();
				if(flag) {
					this.PrintDoc.PrinterSettings.PrinterName = PrinterName;
					isFind = true;
					break;
				}
			}
			bool flag2 = !isFind;
			string result;
			if(flag2) {
				result = "查不到名称:" + PrinterName + "打印机";
			} else {
				result = "名称:" + PrinterName + "已找到";
			}
			return result;
		}

		// Token: 0x04000042 RID: 66
		private PrintDocument PrintDoc = new PrintDocument();

		// Token: 0x04000043 RID: 67
		private List<object> PrintList = new List<object>();

		// Token: 0x04000044 RID: 68
		private int CurrentPageNo = 0;

		// Token: 0x04000045 RID: 69
		private Print print;

		// Token: 0x04000046 RID: 70
		private Font font = new Font("微软雅黑", 6f, FontStyle.Regular);

		// Token: 0x04000047 RID: 71
		private Font font5Reg = new Font("微软雅黑", 5f, FontStyle.Regular);

		// Token: 0x04000048 RID: 72
		private Font font4 = new Font("微软雅黑", 4f, FontStyle.Regular);

		// Token: 0x04000049 RID: 73
		private Font font8Reg = new Font("微软雅黑", 8f, FontStyle.Regular);

		// Token: 0x0400004A RID: 74
		private Font font9Reg = new Font("微软雅黑", 9f, FontStyle.Regular);

		// Token: 0x0400004B RID: 75
		private Font font7 = new Font("微软雅黑", 7f, FontStyle.Bold);

		// Token: 0x0400004C RID: 76
		private Font font9 = new Font("微软雅黑", 9f, FontStyle.Bold);

		// Token: 0x0400004D RID: 77
		private Font font8 = new Font("微软雅黑", 8f, FontStyle.Bold);

		// Token: 0x0400004E RID: 78
		private Font font5 = new Font("微软雅黑", 5f, FontStyle.Bold);

		// Token: 0x0400004F RID: 79
		private Font font14 = new Font("微软雅黑", 14f, FontStyle.Bold);

		// Token: 0x04000050 RID: 80
		private Font font10 = new Font("微软雅黑", 10f, FontStyle.Bold);

		// Token: 0x04000051 RID: 81
		private Font FontTitle = new Font("微软雅黑", 6f, FontStyle.Bold);

		// Token: 0x04000052 RID: 82
		private Font FontName = new Font("微软雅黑", 6f, FontStyle.Bold);

		// Token: 0x04000053 RID: 83
		private Brush brush = new SolidBrush(Color.Black);

		// Token: 0x04000054 RID: 84
		private Brush brushred = new SolidBrush(Color.Red);

		// Token: 0x04000055 RID: 85
		private Brush brushWhite = new SolidBrush(Color.White);

		// Token: 0x04000056 RID: 86
		private Pen pen = new Pen(Color.Gray, 0.1f);

		private Pen penBlack = new Pen(Color.Black, 0.1f);

		private Pen penWhite = new Pen(Color.White, 0.1f);

		private Font FontCode128 = new Font("微软雅黑", 7f, FontStyle.Regular);

		private int curr = 0;

		private int currY = 0;
	}
}
