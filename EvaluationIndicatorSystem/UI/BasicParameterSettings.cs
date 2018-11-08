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
            if (JsonHelper.Indicators == null)
            {
                JsonHelper.ReadIndicator();
            }
            LoadIndicators();
        }

        private void LoadIndicators()
        {
            if (JsonHelper.Indicators == null) return;
            foreach(var one in JsonHelper.Indicators)
            {
                comb_one.Items.Add(one.name);
            }
            comb_one.SelectedIndex = 0;            
        }

        private void comb_one_SelectedIndexChanged(object sender, EventArgs e)
        {            
            comb_two.Items.Clear();
            foreach (var two in JsonHelper.Indicators[comb_one.SelectedIndex].indicatorTwos)
            {
                comb_two.Items.Add(two.name);
            }            
            comb_two.SelectedIndex = 0;                        
        }

        private void comb_two_SelectedIndexChanged(object sender, EventArgs e)
        {            
            comb_three.Items.Clear();
            foreach (var three in JsonHelper.Indicators[comb_one.SelectedIndex].indicatorTwos[comb_two.SelectedIndex].indicatorThrees)
            {
                comb_three.Items.Add(three.name);
            }
            comb_three.SelectedIndex = 0;
        }

        private void comb_three_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<IndicatorFour> fours = JsonHelper.Indicators[comb_one.SelectedIndex].indicatorTwos[comb_two.SelectedIndex].indicatorThrees[comb_three.SelectedIndex].indicatorFours;
            dataGridView1.DataSource = fours;
            dataGridView1.Refresh();
        }
    }//end of class
}
