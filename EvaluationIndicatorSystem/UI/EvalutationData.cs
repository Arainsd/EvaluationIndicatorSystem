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
    public partial class EvalutationData : UserControl
    {
        public EvalutationData()
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
        private void TimeCycleRefresh()
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

            timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, 0);
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
        /// 备注按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.Value.ToString() == "备注")
            {
                int id = (int)((DataGridView)sender).CurrentRow.Cells["ID"].Value;
                EvalutationDataModule preModule = evalutationModules[id];
                using (RemarkEdit dialog = new RemarkEdit(preModule))
                {
                    if(dialog.ShowDialog() == DialogResult.OK)
                    {
                        evalutationModules[id] = dialog.CurrentModule;
                        RefreshRemark(dialog.CurrentModule);
                    }
                }
            }
        }

        /// <summary>
        /// 更新当前周期所有数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (evalutationModules == null || evalutationModules.Count == 0) return;
            SqliteHelper.Update(TableName.EvalutationData, evalutationModules);
            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 提交当前周期所有数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_commit_Click(object sender, EventArgs e)
        {
            if (evalutationModules == null || evalutationModules.Count == 0) return;
            if (MessageBox.Show("提交后，改评价周期将不能修改，确认提交？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqliteHelper.Update(TableName.EvalutationData, evalutationModules);
                foreach (var item in timeModules)
                {
                    if (item.Name == combo_timeCycle.SelectedItem.ToString())
                    {
                        item.State = 1;
                        SqliteHelper.Update(TableName.TimeCycle, item.ID, item, out string msg);
                        if (string.IsNullOrEmpty(msg))
                        {
                            MessageBox.Show("提交成功，请在评价结果中查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TimeCycleRefresh();
                        }
                        else
                        {
                            MessageBox.Show("周期提交失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                }
            }
        }
    }//end of class
}
