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
    public partial class BasicIndicatorOne : UserControl
    {
        public BasicIndicatorOne()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (ChangeIndicatorOne dialog = new ChangeIndicatorOne())
            {
                dialog.ChangeTitle = "新增 一级指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    IndicatorControl control = new IndicatorControl();
                    control.IndicatorName = "hh";
                    tableLayoutPanel1.Controls.Add(control);
                }
            }
        }
    }//end of class
}
