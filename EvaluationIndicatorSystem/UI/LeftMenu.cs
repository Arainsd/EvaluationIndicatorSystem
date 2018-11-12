using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class LeftMenu : UserControl
    {
        public LeftMenu()
        {
            InitializeComponent();
        }

        int secondMenu = 40;
        Color hoverColor = Color.FromArgb(63, 81, 112);
        Color defaultColor = Color.FromArgb(51, 66, 91);

        private void LeftMenu_Load(object sender, EventArgs e)
        {
            BasicMenuControl(false);
            ControlCollection panels = this.splitContainer1.Panel2.Controls;
            foreach(Panel item in panels)
            {
                item.MouseHover += panel_MouseHover;
                item.MouseLeave += panel_MouseLeave;
            }
        }

        void panel_MouseHover(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = hoverColor;
        }

        void panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = defaultColor;
        }

        private void BasicMenuControl(bool isShow)
        {
            int changeValue = 0;
            int mainValue = 0;
            if (isShow)
            {
                changeValue = secondMenu;
                mainValue = 4 * secondMenu;
            }
            else
            {
                changeValue = 0;
                mainValue = -4 * secondMenu;
            }
            this.panel_basic_one.Height = changeValue;
            this.panel_basic_two.Height = changeValue;
            this.panel_basic_three.Height = changeValue;
            this.panel_basic_four.Height = changeValue;
            this.panel_basicPara.Height += mainValue;  
        }
    }//end of class
}
