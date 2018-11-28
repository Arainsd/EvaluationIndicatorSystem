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

        Dictionary<int, BasicDataModule> modules = null;
        DataHelper dataHelper = null;

        private void Init()
        {
            dataHelper = new DataHelper();
            modules = new Dictionary<int, BasicDataModule>();
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
            tableLayoutPanel1.Controls.Clear();
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
            tableLayoutPanel1.Controls.Clear();
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
            tableLayoutPanel1.Controls.Clear();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            foreach (var module in modules)
            {
                if (module.Value.ParentId == id)
                {
                    IndicatorControl control = new IndicatorControl();
                    control.IndicatorName = module.Value.Name;
                    control.IndicatorGrade = module.Value.Grade.ToString();
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
            string message = dataHelper.CheckComboItem(modules, 2);
            if (!string.IsNullOrEmpty(message))
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
        private void Control_UpdateClick(object sender, int e)
        {
            BasicDataModule module = modules[e];
            using (ChangeIndicatorThree dialog = new ChangeIndicatorThree(modules, module))
            {
                dialog.ChangeTitle = "修改 三级指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BasicDataModule module1 = dialog.GetModule;
                    SqliteHelper.Update(TableName.BasicData, module.ID, module1, out string msg);
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

        private List<int> GetAllChildren(int id)
        {
            List<BasicFourModule> fourModules = (List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour);
            List<int> fourId = new List<int>();
            foreach (var item4 in fourModules)
            {
                if (item4.ParentId == id)
                {
                    fourId.Add(item4.ID);
                }
            }
            return fourId;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_DeleteClick(object sender, int e)
        {
            if (MessageBox.Show("将删除此指标下的所有子指标，确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                List<int> fourIds = GetAllChildren(e);
                SqliteHelper.Delete(TableName.BasicData, e);
                SqliteHelper.Delete(TableName.BasicFour, fourIds);
                DataRefresh();
            }
        }
    }//end of class
}

