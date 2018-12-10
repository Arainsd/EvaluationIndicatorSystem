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

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            dataHelper = new DataHelper();
            users = new List<string>();
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
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
            
            timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, (int)TimeCycleState.Commit);
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
        /// 评价周期改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_timeCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbl_timePeriods.Text = string.Empty;           

            currentTime = timeModules[((ComboBox)sender).SelectedIndex];
            lbl_timePeriods.Text = currentTime.StartTime.ToString("yyyy-MM-dd") + " / " + currentTime.EndTime.ToString("yyyy-MM-dd");
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
            List<EvalutationDataModule> evalutationDatas = (List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, -1, id, currentTime);
            if (evalutationDatas == null || evalutationDatas.Count == 0) return;
            ChartRefresh(evalutationDatas);           
        }

        /// <summary>
        /// 初始化图例
        /// </summary>
        private void InitChartLegend()
        {
            foreach (var item in users)
            {
                Series series_user = new Series();
                series_user.ChartArea = "ChartArea1";
                series_user.Legend = "Legend_user";
                series_user.Name = item;
                series_user.XValueType = ChartValueType.String;//设置X轴类型为字符串
                series_user.ChartType = SeriesChartType.Column;  //设置Y轴为柱状图
                this.chart1.Series.Add(series_user);
            }            
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
            List<TimeCycleModule> times = timeModules.Where(p => p.Name == currentTime.Name && p.StartTime == currentTime.StartTime && p.EndTime == currentTime.EndTime).ToList();
            bool isFirst = true;
            int maxY = 100;
            foreach (var item in times)
            {
                Series series = new Series(item.UserName);
                List<int> grades = new List<int>();
                for (int i = 0; i < data.Count; i++)
                {
                    if (item.ID == data[i].TimeCycle)
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
                        grades.Add(data[i].Grade);
                        if (data[i].Grade > maxY)
                        {
                            maxY = data[i].Grade;
                        }
                    }
                }
                if (maxY % 100 != 0) maxY = (maxY / 100 + 1) * 100;
                chart1.ChartAreas[0].AxisY.Maximum = maxY;
                series.Points.DataBind(grades, "", "", "");
                chart1.Series.Add(series);
                isFirst = false;
            }
        }
    }//end of class
}
