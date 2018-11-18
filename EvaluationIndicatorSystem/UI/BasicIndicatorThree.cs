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
    public partial class BasicIndicatorThree : UserControl
    {
        public BasicIndicatorThree()
        {
            InitializeComponent();
            Init();
        }

        Dictionary<string, BasicDataModule> modules = null;
        DataHelper dataHelper = null;

        private void Init()
        {
            dataHelper = new DataHelper();
            modules = new Dictionary<string, BasicDataModule>();
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
        {
            modules.Clear();
            combo_one.Items.Clear();
            combo_two.Items.Clear();
            tableLayoutPanel1.Controls.Clear();
            List<BasicDataModule> obj = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData);
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    if (item.Level == 1)
                    {
                        modules.Add(item.ID.ToString(), item);
                        combo_one.Items.Add(item.Name);
                    }
                    else if (item.Level == 2 || item.Level == 3)
                    {
                        modules.Add(item.ID.ToString(), item);
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
            tableLayoutPanel1.Controls.Clear();
            int id = -1;
            id = dataHelper.GetParentId(modules, ((ComboBox)sender).SelectedItem.ToString());
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
            tableLayoutPanel1.Controls.Clear();
            int id = -1;
            id = dataHelper.GetParentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            foreach (var module in modules)
            {
                if (module.Value.ParentId == id)
                {
                    IndicatorControl control = new IndicatorControl();
                    control.IndicatorName = module.Value.Name;
                    control.UpdateClick += Control_UpdateClick;
                    control.DeleteClick += Control_DeleteClick;
                    control.Name = module.Value.ID.ToString();
                    tableLayoutPanel1.Controls.Add(control);
                }
            }
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
            string msg = dataHelper.CheckComboItem(modules, 2);
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("请先添加二级指标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (ChangeIndicatorThree dialog = new ChangeIndicatorThree(modules))
            {
                dialog.ChangeTitle = "新增 三级指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BasicDataModule module = dialog.GetModule;
                    SqliteHelper.Insert(TableName.BasicData, module, out string msg);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRefresh();
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_UpdateClick(object sender, string e)
        {
            BasicDataModule module = modules[e];
            using (ChangeIndicatorThree dialog = new ChangeIndicatorThree(modules, module))
            {
                dialog.ChangeTitle = "修改 三级指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BasicDataModule module1 = dialog.GetModule;
                    bool result = SqliteHelper.Update(TableName.BasicData, module.ID, module1);
                    if (!result)
                    {
                        MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRefresh();
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_DeleteClick(object sender, string e)
        {
            if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqliteHelper.Delete(TableName.BasicData, int.Parse(e));
                DataRefresh();
            }
        }
    }//end of class
}

