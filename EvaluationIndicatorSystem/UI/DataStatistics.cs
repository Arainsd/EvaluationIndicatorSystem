using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace EvaluationIndicatorSystem
{
    public partial class DataStatistics : UserControl
    {
        public DataStatistics()
        {
            InitializeComponent();
            Init();
        }

        DataHelper dataHelper = null;
        List<string> users = null;
        List<TimeCycleModule> timeModules = null;
        Dictionary<int, BasicDataModule> basicModules = null;
        Dictionary<int, EvalutationDataModule> evalutationModules = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            dataHelper = new DataHelper();
            users = new List<string>();
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
            evalutationModules = new Dictionary<int, EvalutationDataModule>();
            InitChartLegend();
        }        

        /// <summary>
        /// 刷新评价周期
        /// </summary>
        public void TimeCycleRefresh()
        {
            combo_timeCycle.Items.Clear();
            combo_timeCycle.Text = string.Empty;
            this.lbl_timePeriods.Text = string.Empty;
            this.combo_one.Items.Clear();
            combo_one.Text = string.Empty;
            this.combo_two.Items.Clear();
            combo_two.Text = string.Empty;
            this.combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            //dataGridView1.DataSource = new List<EvalutationDataModule>();
            basicModules.Clear();
            evalutationModules?.Clear();
            
            timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, (int)TimeCycleState.Commit);           
            if (timeModules.Count == 0) return;
            
            basicModules = ((List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData)).ToDictionary(key => key.ID, basicModule => basicModule);

            foreach (var item in timeModules)
            {
                combo_timeCycle.Items.Add(item.Name);
            }
            combo_timeCycle.SelectedIndex = 0;
        }

        /// <summary>
        /// 评价周期改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_timeCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbl_timePeriods.Text = string.Empty;
            this.combo_one.Items.Clear();
            combo_one.Text = string.Empty;
            this.combo_two.Items.Clear();
            combo_two.Text = string.Empty;
            this.combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            //dataGridView1.DataSource = new List<EvalutationDataModule>();
            evalutationModules?.Clear();

            TimeCycleModule currentTime = timeModules[((ComboBox)sender).SelectedIndex];
            lbl_timePeriods.Text = currentTime.StartTime.ToString("yyyy-MM-dd") + " / " + currentTime.EndTime.ToString("yyyy-MM-dd");
            DataRefresh(currentTime.ID);
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh(int id)
        {
            if (basicModules.Count == 0) return;
            evalutationModules = ((List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, id)).ToDictionary(key => key.ID, data => data);
            foreach (var item in basicModules)
            {
                if (item.Value.Level == 1)
                {
                    combo_one.Items.Add(item.Value.Name);
                }
            }
            if (combo_one.Items.Count > 0)
            {
                combo_one.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 一级指标改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_one_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_two.Items.Clear();
            combo_two.Text = string.Empty;
            combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            //dataGridView1.DataSource = new List<EvalutationDataModule>();
            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            dataHelper.SetComboItem(basicModules, combo_two, id);
        }

        /// <summary>
        /// 二级指标改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_two_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            //dataGridView1.DataSource = new List<EvalutationDataModule>();
            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            dataHelper.SetComboItem(basicModules, combo_three, id);
        }

        /// <summary>
        /// 三级指标改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_three_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = new List<EvalutationDataModule>();
            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            var data = evalutationModules.Where(p => p.Value.ParentId == id).ToArray();
            if (data != null && data.Length > 0)
            {
                List<EvalutationDataModule> currentTableData = new List<EvalutationDataModule>();
                foreach (var item in data)
                {
                    currentTableData.Add(item.Value);
                }
                //dataGridView1.DataSource = currentTableData;
                //dataGridView1.Refresh();
            }            
        }

        private void InitChartLegend()
        {
            foreach (var item in users)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series_user = new System.Windows.Forms.DataVisualization.Charting.Series();
                series_user.ChartArea = "ChartArea1";
                series_user.Legend = "Legend_user";
                series_user.Name = item;
                this.chart1.Series.Add(series_user);
            }            
        }
    }//end of class
}
