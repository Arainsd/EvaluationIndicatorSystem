﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class BasicIndicatorFour : UserControl
    {
        public BasicIndicatorFour()
        {
            InitializeComponent();
            Init();
        }

        Dictionary<int, BasicDataModule> modules = null;
        List<BasicFourModule> fourModules = null;
        DataHelper dataHelper = null;
        string[] calModule = { "开关型", "单一比较型", "多重比较型", "分段计数型", "单一比例比较型" };

        private void Init()
        {
            dataHelper = new DataHelper();
            modules = new Dictionary<int, BasicDataModule>();
            fourModules = new List<BasicFourModule>();
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void DataRefresh()
        {
            modules.Clear();
            combo_one.Items.Clear();
            combo_two.Items.Clear();
            combo_three.Items.Clear();
            dataGridView1.DataSource = new List<BasicFourModule>();
            fourModules = (List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour);
            List<BasicDataModule> obj = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData);
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {                         
                    modules.Add(item.ID, item);
                    if (item.Level == 1)
                    {
                        combo_one.Items.Add(item.Name);
                    }
                }
                if(combo_one.Items.Count > 0)
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
            combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            dataGridView1.DataSource = new List<BasicFourModule>();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            dataHelper.SetComboItem(modules, combo_two, id);
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
            dataGridView1.DataSource = new List<BasicFourModule>();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            dataHelper.SetComboItem(modules, combo_three, id);
        }

        /// <summary>
        /// 三级指标改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_three_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<BasicFourModule>();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            List<BasicFourModule> currentModule = new List<BasicFourModule>();
            for(int i  = 0;i < fourModules.Count;i ++)
            {
                if (fourModules[i].ParentId == id)
                {
                    currentModule.Add(fourModules[i]);
                }
            }
            dataGridView1.DataSource = currentModule;
            dataGridView1.Refresh();
            RefreshRemark(currentModule[0]);
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (combo_one.Items.Count == 0)
            {
                MessageBox.Show("请先添加一级指标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (combo_two.Items.Count == 0)
            {
                MessageBox.Show("请先添加二级指标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (combo_three.Items.Count == 0)
            {
                MessageBox.Show("请先添加三级指标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (ChangeIndicatorFour dialog = new ChangeIndicatorFour())
            {
                dialog.ChangeTitle = $"新增 四级指标 : {combo_one.SelectedItem} > {combo_two.SelectedItem} > {combo_three.SelectedItem}";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BasicFourModule fourModule = dialog.GetModule;
                    fourModule.ParentId = dataHelper.GetCurrentId(modules, combo_three.SelectedItem.ToString());
                    SqliteHelper.Insert(TableName.BasicFour, fourModule, out string msg);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRefresh();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (((DataGridView)sender).CurrentCell.Value.ToString() == "修改")
            {
                RowUpdateClick(sender, e);
            }
            else if (((DataGridView)sender).CurrentCell.Value.ToString() == "删除")
            {
                RowDeleteClick(sender, e);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowUpdateClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)((DataGridView)sender).CurrentRow.Cells["ID"].Value;
            BasicFourModule preModule = null;
            foreach(var item in fourModules)
            {
                if(item.ID == id)
                {
                    preModule = item;
                    break;
                }
            }
            if (preModule == null)
                return;
            RefreshRemark(preModule);
            using (ChangeIndicatorFour dialog = new ChangeIndicatorFour(preModule))
            {
                dialog.ChangeTitle = "修改 四级级指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BasicFourModule currentModule = dialog.GetModule;
                    SqliteHelper.Update(TableName.BasicFour, preModule.ID, currentModule, out string msg);
                    if (string.IsNullOrEmpty(msg))
                    {
                        DataRefresh();
                    }
                    else
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)((DataGridView)sender).CurrentRow.Cells["ID"].Value;
            if (MessageBox.Show("可能会影响指标数据及评价结果的显示，确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqliteHelper.Delete(TableName.BasicFour, id);
                DataRefresh();
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
            if (e.RowIndex == -1) return;
            int currentRow = ((DataGridView)sender).CurrentRow.Index;
            if (preIndex == currentRow) return;
            preIndex = currentRow;
            int currentId = (int)((DataGridView)sender).CurrentRow.Cells["ID"].Value;
            foreach (var item in fourModules)
            {
                if (item.ID == currentId)
                {
                    RefreshRemark(item);
                    break;
                }
            }            
        }

        /// <summary>
        /// 更新备注展示内容
        /// </summary>
        /// <param name="data"></param>
        private void RefreshRemark(BasicFourModule data)
        {
            lbl_tblNameData.Text = data.Name;
            lbl_tblBasicData.Text = data.BasicRule;
            lbl_tblScoreData.Text = data.BasicScore.ToString();
            lbl_tblSubData.Text = data.BasicSub;
            lbl_tblAddData.Text = data.BasicAdd;
            lbl_tblCalModuleData.Text = data.StrCalModules;
        }
    }//end of class
}

