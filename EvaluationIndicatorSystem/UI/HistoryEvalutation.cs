using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            UserRefresh();
        }

        public void UserRefresh()
        {
            users.Clear();
            combo_user.Items.Clear();
            users = (List<string>)SqliteHelper.Select(TableName.User);
            if (users == null || users.Count == 0) return;
            combo_user.Items.Add("全部");
            foreach (var item in users)
            {
                combo_user.Items.Add(item);
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
            TimeCycleRefresh(((ComboBox)sender).SelectedItem.ToString());
        }

        /// <summary>
        /// 刷新评价周期
        /// </summary>
        private void TimeCycleRefresh(string userName)
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
            ClearLabelLink();
            basicModules.Clear();
            evalutationModules?.Clear();
            
            if (userName == "全部")
            {
                timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, (int)TimeCycleState.Commit);
            }
            else
            {                
                timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, (int)TimeCycleState.Commit, null, userName);
            }

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
            ClearLabelLink();
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
            dataGridView1.DataSource = new List<EvalutationDataModule>();
            ClearLabelLink();
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
            ClearLabelLink();
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
            ClearLabelLink();
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
            lbl_tblNameData.Text = evalutationData.Name;
            lbl_tblBasicData.Text = evalutationData.BasicRule;
            lbl_tblSubData.Text = evalutationData.BasicSub;
            lbl_tblAddData.Text = evalutationData.BasicAdd;
            lbl_tblGradeData.Text = evalutationData.Grade.ToString();
            lbl_tblRemarkData.Text = evalutationData.Remark;
            ClearLabelLink();
            CreateLabelLink(evalutationData.DataSource);
        }

        /// <summary>
        /// 清理数据源链接
        /// </summary>
        private void ClearLabelLink()
        {
            List<LinkLabel> linkLabels = new List<LinkLabel>();
            foreach (var item in splitContainer2.Panel2.Controls)
            {
                if (item is LinkLabel)
                {
                    linkLabels.Add((LinkLabel)item);
                }
            }
            foreach (var ite in linkLabels)
            {
                splitContainer2.Panel2.Controls.Remove(ite);
            }
        }

        /// <summary>
        /// 创建数据源链接
        /// </summary>
        /// <param name="value"></param>
        private void CreateLabelLink(string[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                LinkLabel linkItem = new LinkLabel();
                splitContainer2.Panel2.Controls.Add(linkItem);
                linkItem.AutoSize = true;
                linkItem.Location = new System.Drawing.Point(5, 210 + i * 30);
                linkItem.Name = "linkLabel" + i;
                linkItem.Size = new System.Drawing.Size(78, 20);
                linkItem.TabIndex = 7;
                linkItem.TabStop = true;
                linkItem.Text = value[i];
                linkItem.Click += LinkItem_Click;
            }
        }

        /// <summary>
        /// 数据源点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkItem_Click(object sender, EventArgs e)
        {
            string file = ((LinkLabel)sender).Text;
            if (File.Exists(file))
            {
                System.Diagnostics.Process.Start(file);
            }
            else
            {
                MessageBox.Show("文件不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 删除当前周期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {          
            if(timeModules.Count == 0)
            {
                MessageBox.Show("没有可以删除的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("删除后，关于此周期的数据将一并删除，确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                TimeCycleModule currentTime = timeModules[combo_timeCycle.SelectedIndex];
                SqliteHelper.Delete(TableName.TimeCycle, currentTime.ID);
                SqliteHelper.Delete(TableName.EvalutationData, currentTime.ID);
                UserRefresh();
            }
        }

        /// <summary>
        /// 导出当前周期数据为EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            TimeCycleModule currentTime = timeModules[combo_timeCycle.SelectedIndex];            
            if (currentTime == null || evalutationModules == null || evalutationModules.Count == 0) return;
            Dictionary<int, BasicFourModule> fourModules = ((List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour)).ToDictionary(key => key.ID, fourModule => fourModule);
            ExcelHelper.ExportData(currentTime, evalutationModules.Values.ToList(), basicModules, fourModules);
            MessageBox.Show("导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 导入指定数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "excel | *.xls; *.xlsx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelHelper.ImportData(dialog.FileName, out string msg);
                    if (string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show("导入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserRefresh();
                    }
                    else
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }//end of class
}
