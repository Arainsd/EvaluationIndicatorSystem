using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace EvalSys
{
    public partial class SingleStatistics : UserControl
    {
        public SingleStatistics(UserModule user)
        {
            InitializeComponent();
            currentUser = user;
            Init();
        }

        UserModule currentUser = null;
        DataHelper dataHelper = null;
        List<TimeCycleModule> timeModules = null;
        Dictionary<int, BasicDataModule> basicModules = null;
        List<EvalutationDataModule> evalutationDatas = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            dataHelper = new DataHelper();
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
            evalutationDatas = new List<EvalutationDataModule>();
        }        

        /// <summary>
        /// 刷新评价阶段
        /// </summary>
        public void TimeCycleRefresh()
        {
            combo_timeCycle.Items.Clear();
            combo_timeCycle.Text = string.Empty;
            this.lbl_timePeriods.Text = string.Empty;

            timeModules = ((List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, (int)TimeCycleState.Commit)).Where(p => p.UserName == currentUser.UserName).ToList();
            if (timeModules.Count == 0)
            {
                this.combo_one.Items.Clear();
                combo_one.Text = string.Empty;
                this.combo_two.Items.Clear();
                combo_two.Text = string.Empty;
                this.combo_three.Items.Clear();
                combo_three.Text = string.Empty;
                ClearChart();
                basicModules.Clear();
                return;
            }

            basicModules = ((List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData)).ToDictionary(key => key.ID, basicModule => basicModule);
            for (int i = 0; i < timeModules.Count; i++)
            {
                bool isSame = false;
                for(int j = i + 1; j < timeModules.Count; j++)
                {
                    if (timeModules[i].Name == timeModules[j].Name && timeModules[i].StartTime == timeModules[j].StartTime && timeModules[i].EndTime == timeModules[j].EndTime)
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame)
                {
                    combo_timeCycle.Items.Add(timeModules[i].Name);
                }
            }
            combo_timeCycle.SelectedIndex = 0;
        }

        TimeCycleModule currentTime = null;
        /// <summary>
        /// 评价阶段改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_timeCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbl_timePeriods.Text = string.Empty;           

            currentTime = timeModules[((ComboBox)sender).SelectedIndex];
            lbl_timePeriods.Text = currentTime.StartTime.ToString("yyyy-MM-dd") + " / " + currentTime.EndTime.ToString("yyyy-MM-dd");
            evalutationDatas = (List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, currentTime.ID);

            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
        {
            this.combo_one.Items.Clear();
            combo_one.Text = string.Empty;

            if (basicModules.Count == 0)
            {                
                this.combo_two.Items.Clear();
                combo_two.Text = string.Empty;
                this.combo_three.Items.Clear();
                combo_three.Text = string.Empty;
                ClearChart();
                return;
            }
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
            
            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1)
            {
                combo_three.Items.Clear();
                combo_three.Text = string.Empty;
                ClearChart();
                return;
            }
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
            ClearChart();
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
            ClearChart();
            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            if (evalutationDatas == null || evalutationDatas.Count == 0) return;
            List<EvalutationDataModule> evalutationData = evalutationDatas.Where(p => p.ParentId == id).ToList();
            ChartRefresh(evalutationData);           
        }

        /// <summary>
        /// 清理图数据
        /// </summary>
        private void ClearChart()
        {
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart1.Series.Clear();
        }

        /// <summary>
        /// 刷新图数据
        /// </summary>
        /// <param name="data"></param>
        private void ChartRefresh(List<EvalutationDataModule> data)
        {
            ClearChart();
            bool isFirst = true;
            int maxY = 100;
            Series basicSeries = new Series("基础分值");
            List<int> basicGrades = new List<int>();
            Series series = new Series(currentUser.UserName);
            List<int> grades = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                if (isFirst)
                {
                    CustomLabel label = new CustomLabel();
                    label.Text = data[i].Name;
                    label.ToPosition = 2D * (i + 1);
                    if (i % 2 == 0)
                    {
                        label.RowIndex = 0;
                    }
                    else
                    {
                        label.RowIndex = 1;
                    }
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 9f, FontStyle.Regular);
                }
                basicGrades.Add(data[i].BasicScore);
                if (data[i].BasicScore > maxY)
                {
                    maxY = data[i].BasicScore;
                }
                grades.Add(data[i].Grade);
                if (data[i].Grade > maxY)
                {
                    maxY = data[i].Grade;
                }
            }
            if (maxY % 100 != 0) maxY = (maxY / 100 + 1) * 100;
            chart1.ChartAreas[0].AxisY.Maximum = maxY;
            basicSeries.Points.DataBind(basicGrades, "", "", "");
            chart1.Series.Add(basicSeries);
            series.Points.DataBind(grades, "", "", "");
            chart1.Series.Add(series);
            isFirst = false;

            dataGridView1.DataSource = data;
        }
    }//end of class
}
