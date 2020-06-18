using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Printer
{
    public partial class Set : Form
    {
        public Set()
        {
            InitializeComponent();
        }

        private void Set_Load(object sender, EventArgs e)
        {
            this.txtprtname.Text= Properties.Settings.Default.PrtName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrtName = this.txtprtname.Text;
        }
    }
}
