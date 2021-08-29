using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanGo.Tools
{
    public partial class CommForm : UIForm
    {
        public CommForm()
        {
            InitializeComponent();            
        }

        public void Init(UIStyleManager uiStyleManager1)
        {        
            //初始化用户设置
            String style=LocalConfig.GetConfigValue("style");
            UIStyle t = (UIStyle)Enum.Parse(typeof(UIStyle), style);
            uiStyleManager1.Style = t;
        }
    }
}
