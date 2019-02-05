using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Pasn : Form
    {
        public Pasn()
        {
            InitializeComponent();
        }
        public void setContent()
        {            
            ContentRTB.Paste();
            Clipboard.Clear();
        }

        private void Pasn_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void ContentRTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.V)
            {
                //setContent();
            }
        }

        /// <summary>
        /// 新增、保存内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "RTF文件(*.rtf)|*.rtf";
            saveFileDialog1.DefaultExt = "rtf";//默认的文件扩展名
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                ContentRTB.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);

        }
    }
}
