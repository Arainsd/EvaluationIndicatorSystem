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
    public partial class UserStatistics : UserControl
    {
        public UserStatistics()
        {
            InitializeComponent();
            Init();
        }

        DataHelper dataHelper = null;
        List<UserModule> users = null;
        List<TimeCycleModule> timeModules = null;
        List<TimeCycleModule> userTimeModules = null;
        Dictionary<int, BasicDataModule> basicModules = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            dataHelper = new DataHelper();
            users = new List<UserModule>();
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
        }        

        /// <summary>
        /// 刷新评价阶段
        /// </summary>
        public void TimeCycleRefresh()
        {
            users.Clear();
            combo_user.Items.Clear();
            combo_user.Text = string.Empty;
            basicModules.Clear();                               
            this.combo_one.Items.Clear();
            combo_one.Text = string.Empty;
            this.combo_two.Items.Clear();
            combo_two.Text = string.Empty;
            this.combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            ClearChart();

            basicModules = ((List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData)).ToDictionary(key => key.ID, basicModule => basicModule);
            timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, (int)TimeCycleState.Commit);
            users = (List<UserModule>)SqliteHelper.Select(TableName.User);
            foreach(var item in users)
            {
                combo_user.Items.Add(item.UserName);
            }
            combo_user.SelectedIndex = 0;           
        }

        /// <summary>
        /// 用户改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            userTimeModules = timeModules.Where(p => p.UserName == ((ComboBox)sender).SelectedItem.ToString()).ToList();
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
        {
            this.combo_one.Items.Clear();
            combo_one.Text = string.Empty;

            if (basicModules == null || basicModules.Count == 0)
            {                
                this.combo_two.Items.Clear();
                combo_two.Text = string.Empty;
                this.combo_three.Items.Clear();
                combo_three.Text = string.Empty;
                ClearChart();
                return;
            }

            if (basicModules != null && basicModules.Count > 0)
            {
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

            Dictionary<TimeCycleModule, List<EvalutationDataModule>> evalutationDatas = new Dictionary<TimeCycleModule, List<EvalutationDataModule>>();
            foreach (TimeCycleModule item in userTimeModules)
            {
                List<EvalutationDataModule> evalutationData = (List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, -2, id, item.ID);
                if (evalutationData == null || evalutationData.Count == 0) continue;
                evalutationDatas.Add(item, evalutationData);
            }
            if (evalutationDatas.Count == 0) return;
            ChartRefresh(evalutationDatas);           
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
        /// <param name="datas"></param>
        private void ChartRefresh(Dictionary<TimeCycleModule, List<EvalutationDataModule>> datas)
        {
            List<UserTableData> tableDatas = new List<UserTableData>();
            bool isFirst = true;
            int maxY = 100;
            foreach (var item in datas)
            {
                Series series = new Series(item.Key.Name);
                List<int> grades = new List<int>();

                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (isFirst)
                    {
                        CustomLabel label = new CustomLabel();
                        label.Text = item.Value[i].Name;
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

                    UserTableData tableData = new UserTableData();
                    tableData.FourName = item.Value[i].Name;
                    tableData.TimeName = item.Key.Name;
                    tableData.Grade = item.Value[i].Grade;
                    tableDatas.Add(tableData);

                    grades.Add(item.Value[i].Grade);
                    if (item.Value[i].Grade > maxY)
                    {
                        maxY = item.Value[i].Grade;
                    }
                }
                series.Points.DataBind(grades, "", "", "");
                chart1.Series.Add(series);
                isFirst = false;
            }
            if (maxY % 100 != 0) maxY = (maxY / 100 + 1) * 100;
            chart1.ChartAreas[0].AxisY.Maximum = maxY;

            dataGridView1.DataSource = tableDatas.OrderBy(p => p.FourName).ToList();
        }
    }//end of class
    class UserTableData
    {
        public string FourName { get; set; }
        public string TimeName { get; set; }
        public int Grade { get; set; }
    }//end of class
}
