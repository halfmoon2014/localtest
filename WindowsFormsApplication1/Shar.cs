using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanTODO
{
    public partial class Shar : Form
    {
        private string name;
        public Shar(string name)
        {
            InitializeComponent();
            this.name = name;
        }
    }
}
