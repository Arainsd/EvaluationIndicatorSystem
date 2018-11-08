using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class BasicParameterSettings : Form
    {
        public BasicParameterSettings()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            JosnHelper.ReadIndicator();
        }

        private void comb_one_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb_two.Items.Clear();
            comb_two.SelectedIndex = 0;
            comb_three.Items.Clear();
            comb_three.SelectedIndex = 0;
        }

        private void comb_two_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb_three.Items.Clear();
            comb_three.SelectedIndex = 0;
        }
        
    }//end of class
}
