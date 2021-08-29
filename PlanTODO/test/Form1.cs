using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                InsertTable(richTextBox1, 5, 4, false);
                InsertTable(richTextBox51,5, 4, false);
        }

        /// <summary>
        /// 插入表格
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="col">行</param>
        /// <param name="row">列</param>
        /// <param name="AutoSize">=TRUE:自动设置每个单元格的大小</param>
        private void InsertTable(RichTextBox richTextBox,int col, int row,bool AutoSize)
        {
            StringBuilder rtf = new StringBuilder();
            rtf.Append(@"{\rtf1 ");

            //int cellWidth = 1000;//col.1 width =1000
            int cellWidth = 1000; 

            if (AutoSize)
                //滚动条出现时 (richTextBox.ClientSize.Width - 滚动条的宽 /列的个数)*15
                cellWidth = (richTextBox.ClientSize.Width / row) * 15; //15 当ROW值越大 结果差距越大 
 
            Text =  cellWidth.ToString() ;
            for (int i = 0; i < col; i++)
            {
                rtf.Append(@"\trowd");
                for (int j = 1; j <= row; j++)
                    rtf.Append(@"\cellx" + (j * cellWidth).ToString());
                rtf.Append(@"\intbl \cell \row"); //create row
            }
            rtf.Append(@"\pard");
            rtf.Append(@"}");
            richTextBox.SelectedRtf = rtf.ToString();
        }
 
 
    }
}
