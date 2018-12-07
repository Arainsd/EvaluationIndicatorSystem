using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace EvaluationIndicatorSystem
{
    public partial class EvalutationData : UserControl
    {
        public EvalutationData(UserModule user)
        {
            InitializeComponent();
            currentUser = user;
            Init();
        }
        
        UserModule currentUser = null;
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

            timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, (int)TimeCycleState.Local, null, currentUser.UserName);
            if (timeModules.Count == 0)
            {                                
                this.combo_one.Items.Clear();
                combo_one.Text = string.Empty;
                this.combo_two.Items.Clear();
                combo_two.Text = string.Empty;
                this.combo_three.Items.Clear();
                combo_three.Text = string.Empty;
                dataGridView1.DataSource = new List<EvalutationDataModule>();
                ClearLabels();
                basicModules.Clear();
                evalutationModules?.Clear();
                return;
            }
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

            TimeCycleModule currentTime = timeModules[((ComboBox)sender).SelectedIndex];
            lbl_timePeriods.Text = currentTime.StartTime.ToString("yyyy-MM-dd") + " / " + currentTime.EndTime.ToString("yyyy-MM-dd");
            DataRefresh(currentTime.ID);
        }

        /// <summary>
        /// 评价周期管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_timeCycleMange_Click(object sender, EventArgs e)
        {
            using (TimeCycleManage dialog = new TimeCycleManage(currentUser))
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
            this.combo_one.Items.Clear();
            combo_one.Text = string.Empty;

            if (basicModules.Count == 0)
            {                
                this.combo_two.Items.Clear();
                combo_two.Text = string.Empty;
                this.combo_three.Items.Clear();
                combo_three.Text = string.Empty;
                dataGridView1.DataSource = new List<EvalutationDataModule>();
                ClearLabels();
                evalutationModules?.Clear();
                return;
            }

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

            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1)
            {
                combo_three.Items.Clear();
                combo_three.Text = string.Empty;
                dataGridView1.DataSource = new List<EvalutationDataModule>();
                ClearLabels();
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

            int id = dataHelper.GetCurrentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1)
            {               
                dataGridView1.DataSource = new List<EvalutationDataModule>();
                ClearLabels();
                return;
            }
            combo_three.Items.Clear();
            combo_three.Text = string.Empty;
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
            ClearLabels();
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
            ClearLabels();
            lbl_tblNameData.Text = evalutationData.Name;
            lbl_tblBasicData.Text = evalutationData.BasicRule;
            lbl_tblSubData.Text = evalutationData.BasicSub;
            lbl_tblAddData.Text = evalutationData.BasicAdd;
            lbl_tblGradeData.Text = evalutationData.Grade.ToString();
            lbl_tblRemarkData.Text = evalutationData.Remark;
            CreateLabelLink(evalutationData.DataSource);
        }

        /// <summary>
        /// 清理数据源链接
        /// </summary>
        private void ClearLabels()
        {
            lbl_tblNameData.Text = string.Empty;
            lbl_tblBasicData.Text = string.Empty;
            lbl_tblSubData.Text = string.Empty;
            lbl_tblAddData.Text = string.Empty;
            lbl_tblGradeData.Text = string.Empty;
            lbl_tblRemarkData.Text = string.Empty;

            List<LinkLabel> linkLabels = new List<LinkLabel>();
            foreach (var item in splitContainer2.Panel2.Controls)
            {
                if (item is LinkLabel)
                {
                    linkLabels.Add((LinkLabel)item);                                                         
                }
            }
            foreach(var ite in linkLabels)
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
        /// 备注按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "Operate")
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
                TimeCycleModule currentTime = timeModules[combo_timeCycle.SelectedIndex];
                currentTime.State = 1;
                SqliteHelper.Update(TableName.TimeCycle, currentTime.ID, currentTime, out string msg);
                if (string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show("提交成功，请在 往期评价 中查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimeCycleRefresh();
                }
                else
                {
                    MessageBox.Show("周期提交失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tx = e.Control as TextBox;
            tx.KeyPress -= new KeyPressEventHandler(tx_KeyPress);
            tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
        }

        private void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }
    }//end of class
}
