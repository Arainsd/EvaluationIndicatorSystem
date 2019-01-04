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
        List<TimeCycleModule> timeModules = null;
        Dictionary<int, BasicDataModule> basicModules = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            dataHelper = new DataHelper();
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
        }        

        /// <summary>
        /// 刷新评价阶段
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
                ClearData();
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
                ClearData();
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
                ClearData();
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
            ClearData();
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
            ClearData();
            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            List<EvalutationDataModule> evalutationDatas = (List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, -1, id, currentTime);
            if (evalutationDatas == null || evalutationDatas.Count == 0) return;
            ChartRefresh(evalutationDatas);           
        }

        /// <summary>
        /// 清理图数据
        /// </summary>
        private void ClearData()
        {
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart1.Series.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        /// <summary>
        /// 刷新图数据
        /// </summary>
        /// <param name="data"></param>
        private void ChartRefresh(List<EvalutationDataModule> data)
        {
            ClearData();
            List<TimeCycleModule> times = timeModules.Where(p => p.Name == currentTime.Name && p.StartTime == currentTime.StartTime && p.EndTime == currentTime.EndTime).ToList();
            //List<TableData> tableDatas = new List<TableData>();
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

                        //TableData tableData = new TableData();
                        //tableData.UserName = item.UserName;
                        //tableData.FourName = data[i].Name;
                        //tableData.Description = data[i].Description;
                        //tableData.Grade = data[i].Grade;
                        //tableDatas.Add(tableData);

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

            //dataGridView1.DataSource = tableDatas.OrderBy(p => p.FourName).ToList();
            TableRefresh(data, times);
        }

        /// <summary>
        /// 刷新表格
        /// </summary>
        /// <param name="data"></param>
        /// <param name="times"></param>
        private void TableRefresh(List<EvalutationDataModule> data, List<TimeCycleModule> times)
        {
            AddHeader(times);
            AddRow(data, times);
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        /// <param name="times"></param>
        private void AddHeader(List<TimeCycleModule> times)
        {
            for (int i = -1; i < times.Count; i++)
            {
                string name = string.Empty;
                string text = string.Empty;
                if (i == -1)
                {
                    name = "four";
                    text = "";
                }
                else
                {
                    name = times[i].ID.ToString();
                    text = times[i].UserName;
                }                
                CreateColumn(name, text);
                if (i == times.Count - 1)
                {
                    CreateColumn("avg", "平均值");
                    CreateColumn("stdev", "均方差");
                }
            }
        }

        /// <summary>
        /// 创建表头
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        private void CreateColumn(string name, string text)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.HeaderText = text;
            column.Name = name;
            column.ReadOnly = true;
            dataGridView1.Columns.AddRange(column);
        }

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="data"></param>
        /// <param name="times"></param>
        private void AddRow(List<EvalutationDataModule> data, List<TimeCycleModule> times)
        {            
            string[] rowHeader = data.Select(p => p.Name).Distinct().ToArray();
            for (int i = 0; i < rowHeader.Length; i++)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = rowHeader[i];

                int k = 1;
                int[] grade = new int[times.Count];
                for (int j = 0; j < times.Count; j++)
                {                    
                    foreach (var item in data)
                    {
                        if (times[j].ID == item.TimeCycle && rowHeader[i] == item.Name)
                        {                            
                            grade[k - 1] = item.Grade;
                            DataGridViewLinkCell cell = new DataGridViewLinkCell();
                            cell.Value = item.Grade;
                            cell.Tag = item;
                            dataGridView1.Rows[rowIndex].Cells[k] = cell;
                            //dataGridView1.Rows[rowIndex].Cells[k].Value = item.Grade;
                            //dataGridView1.Rows[rowIndex].Cells[k].Tag = item;                           
                            if (k == times.Count)
                            {
                                double avg = grade.Average();
                                dataGridView1.Rows[rowIndex].Cells[k + 1].Value = avg;                                                             
                                double sum = grade.Sum(p => Math.Pow(p - avg, 2));                                
                                dataGridView1.Rows[rowIndex].Cells[k + 2].Value = Math.Sqrt(sum / grade.Count());
                            }
                            k++;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 单元格点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;            
            int columnIndex = ((DataGridView)sender).CurrentCell.ColumnIndex;
            int count = ((DataGridView)sender).ColumnCount;
            if (columnIndex == 0 || columnIndex >= count - 2) return;//排除行头和最后两行
            EvalutationDataModule currentData = (EvalutationDataModule)((DataGridView)sender).CurrentCell.Tag;
            using (StatisticsDetails dialog = new StatisticsDetails(currentData, dataGridView1.Columns[columnIndex].HeaderText, currentTime.Name))
            {
                dialog.ShowDialog();
            }
        }
    }//end of class
    class TableData
    {
        public string UserName { get; set; }
        public string FourName { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }
    }//end of class
}
