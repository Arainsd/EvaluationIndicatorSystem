using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EvaluationIndicatorSystem
{
    public partial class HistoryEvalutation : UserControl
    {
        public HistoryEvalutation()
        {
            InitializeComponent();
            Init();
        }

        DataHelper dataHelper = null;
        List<TimeCycleModule> timeModules = null;
        Dictionary<int, BasicDataModule> basicModules = null;
        Dictionary<int, EvalutationDataModule> evalutationModules = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            dataHelper = new DataHelper();
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
            evalutationModules = new Dictionary<int, EvalutationDataModule>();
            TimeCycleRefresh();
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
            dataGridView1.DataSource = new List<EvalutationDataModule>();
            listBox_remark.Items.Clear();
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
            dataGridView1.DataSource = new List<EvalutationDataModule>();
            listBox_remark.Items.Clear();
            evalutationModules?.Clear();

            foreach (var item in timeModules)
            {
                if(item.Name == ((ComboBox)sender).SelectedItem.ToString())
                {
                    lbl_timePeriods.Text = item.StartTime.ToString("yyyy-MM-dd") + " - " + item.EndTime.ToString("yyyy-MM-dd");
                    DataRefresh(item.ID);
                    break;
                }
            }
        }

        /// <summary>
        /// 评价周期管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_timeCycleMange_Click(object sender, EventArgs e)
        {
            using (TimeCycleManage dialog = new TimeCycleManage())
            {
                dialog.ShowDialog();
                TimeCycleRefresh();
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh(int id)
        {
            if (basicModules.Count == 0) return;
            evalutationModules = ((List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, id)).ToDictionary(key => key.ID, data => data);
            foreach(var item in basicModules)
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
            dataGridView1.DataSource = new List<EvalutationDataModule>();
            listBox_remark.Items.Clear();
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
            dataGridView1.DataSource = new List<EvalutationDataModule>();
            listBox_remark.Items.Clear();
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
            dataGridView1.DataSource = new List<EvalutationDataModule>();
            listBox_remark.Items.Clear();
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
                dataGridView1.DataSource = currentTableData;
                dataGridView1.Refresh();
                RefreshRemark(currentTableData[0]);
            }            
        }

        int preIndex = -1;
        /// <summary>
        /// 行点击事件，更新备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = ((DataGridView)sender).CurrentRow.Index;
            if (preIndex == currentRow) return;
            preIndex = currentRow;            
            int currentId = (int)((DataGridView)sender).CurrentRow.Cells["ID"].Value;
            RefreshRemark(evalutationModules[currentId]);
        }

        /// <summary>
        /// 更新备注展示内容
        /// </summary>
        /// <param name="evalutationData"></param>
        private void RefreshRemark(EvalutationDataModule evalutationData)
        {
            listBox_remark.Items.Clear();
            listBox_remark.Items.Add("数据源：");
            foreach (var item in evalutationData.DataSource)
            {
                listBox_remark.Items.Add(item);
            }
            listBox_remark.Items.Add("备注：");
            listBox_remark.Items.Add(evalutationData.Remark);
        }

        /// <summary>
        /// 打开选中的数据源文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_remark_DoubleClick(object sender, EventArgs e)
        {
            string file  = ((ListBox)sender).SelectedItem.ToString();
            if (File.Exists(file))
            {
                System.Diagnostics.Process.Start(file);
            }
        }

        /// <summary>
        /// 导出当前周期数据为EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            TimeCycleModule currentTimeCycle = null;
            foreach (var item in timeModules)
            {
                if (item.Name == combo_timeCycle.SelectedItem.ToString())
                {
                    currentTimeCycle = item;
                    break;
                }
            }
            if (currentTimeCycle == null || evalutationModules == null || evalutationModules.Count == 0) return;
            ExcelHelper.ExportData(currentTimeCycle, evalutationModules.Values.ToList());
        }
    }//end of class
}
