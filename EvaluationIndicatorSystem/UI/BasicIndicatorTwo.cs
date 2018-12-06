using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class BasicIndicatorTwo : UserControl
    {
        public BasicIndicatorTwo()
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
            tableLayoutPanel1.Controls.Clear();
            List<BasicDataModule> obj = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData);
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    if (item.Level == 1)
                    {
                        modules.Add(item.ID, item);
                        combo_one.Items.Add(item.Name);
                    } else if(item.Level == 2)
                    {
                        modules.Add(item.ID, item);
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
            tableLayoutPanel1.Controls.Clear();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            foreach (var item in modules)
            {
                if (item.Value.ParentId == id)
                {
                    IndicatorControl control = new IndicatorControl();
                    control.IndicatorName = item.Value.Name;
                    control.IndicatorGrade = item.Value.Grade.ToString();
                    control.UpdateClick += Control_UpdateClick;
                    control.DeleteClick += Control_DeleteClick;
                    control.Name = item.Value.ID.ToString();
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
            using (ChangeIndicatorTwo dialog = new ChangeIndicatorTwo(modules))
            {
                dialog.ChangeTitle = "新增 二级指标";
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
            using (ChangeIndicatorTwo dialog = new ChangeIndicatorTwo(modules, module))
            {
                dialog.ChangeTitle = "修改 二级指标";
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

        private List<int> GetAllChildren(List<int> data, int id)
        {
            List<BasicDataModule> basicModules = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData);
            List<BasicFourModule> fourModules = (List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour);
            List<int> fourId = new List<int>();
            foreach (var item3 in basicModules)
            {
                if (item3.ParentId == id)
                {
                    data.Add(item3.ID);
                    foreach (var item4 in fourModules)
                    {
                        if (item4.ParentId == item3.ID)
                        {
                            fourId.Add(item4.ID);
                        }
                    }
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
            if (MessageBox.Show("将删除此指标下的所有子指标，且可能会影响指标数据及评价结果的显示，确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                List<int> allID = new List<int>();
                allID.Add(e);
                List<int> fourIds = GetAllChildren(allID, e);
                SqliteHelper.Delete(TableName.BasicData, allID);
                SqliteHelper.Delete(TableName.BasicFour, fourIds);
                //SqliteHelper.Delete(TableName.BasicData, int.Parse(e));
                DataRefresh();
            }
        }
    }//end of class
}

