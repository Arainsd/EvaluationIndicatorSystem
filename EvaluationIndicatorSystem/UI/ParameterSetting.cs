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
    public partial class ParameterSetting : UserControl
    {
        public ParameterSetting()
        {
            InitializeComponent();
            Init();
        }

        //set groubox2 Text
        public string SetGrp2Text { set => this.groupBox2.Text = value; }
        //all indicators
        private List<IndicatorOne> indicatorOnes = null;
        public List<IndicatorOne> IndicatorOnes { get => indicatorOnes; set => indicatorOnes = value; }

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            if (JsonHelper.Indicators == null)
            {
                JsonHelper.ReadIndicator();
            }
            IndicatorOnes = JsonHelper.Indicators;
            LoadIndicators();
        }

        /// <summary>
        /// load indicators
        /// </summary>
        private void LoadIndicators()
        {
            if (IndicatorOnes == null) return;
            foreach (var one in IndicatorOnes)
            {
                comb_one.Items.Add(one.name);
            }
            comb_one.SelectedIndex = 0;
        }

        /// <summary>
        /// indicator one change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comb_one_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb_two.Items.Clear();
            foreach (var two in IndicatorOnes[comb_one.SelectedIndex].indicatorTwos)
            {
                comb_two.Items.Add(two.name);
            }
            comb_two.SelectedIndex = 0;
        }

        /// <summary>
        /// indicator two change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comb_two_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb_three.Items.Clear();
            foreach (var three in IndicatorOnes[comb_one.SelectedIndex].indicatorTwos[comb_two.SelectedIndex].indicatorThrees)
            {
                comb_three.Items.Add(three.name);
            }
            comb_three.SelectedIndex = 0;
        }

        /// <summary>
        /// indicator three change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comb_three_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<IndicatorFour> four = IndicatorOnes[comb_one.SelectedIndex].indicatorTwos[comb_two.SelectedIndex].indicatorThrees[comb_three.SelectedIndex].indicatorFours;
            dataGridView1.DataSource = four;
            dataGridView1.Refresh();
        }               
    }//end of class
}
