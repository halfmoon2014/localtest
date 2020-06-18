using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Printer
{
    class LoadFace
    {
        private Panel PanelLoad = new Panel();
        private Label label2;
        public LoadFace(Form frm)
        {
            PanelLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            PanelLoad.Location = new System.Drawing.Point((frm.Width - 250) / 2, (frm.Height - 60) / 2);
            PanelLoad.Name = "PanelLoad";
            PanelLoad.Size = new System.Drawing.Size(250, 60);

            label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(44, 21);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 12);
            label2.TabIndex = 0;
            label2.Text = "数据加载中... ...";
            PanelLoad.Controls.Add(label2);

            frm.Controls.Add(PanelLoad);
        }
        public void show()
        {
            PanelLoad.Visible = true;
            PanelLoad.BringToFront();
        }
        public void hide()
        {
            PanelLoad.Visible = false;

        }
    }
}
