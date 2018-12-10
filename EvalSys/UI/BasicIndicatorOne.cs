using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class BasicIndicatorOne : UserControl
    {
        public BasicIndicatorOne()
        {
            InitializeComponent();
            Init();
        }

        Dictionary<int, BasicDataModule> modules = null;

        private void Init()
        {
            modules = new Dictionary<int, BasicDataModule>();
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void DataRefresh()
        {
            modules.Clear();
            tableLayoutPanel1.Controls.Clear();
            List<BasicDataModule> obj = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData);            
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    if (item.Level != 1)
                        continue;
                    modules.Add(item.ID, item);
                    IndicatorControl control = new IndicatorControl();
                    control.IndicatorName = item.Name;
                    control.IndicatorGrade = item.Grade.ToString();
                    control.UpdateClick += Control_UpdateClick;
                    control.DeleteClick += Control_DeleteClick;
                    control.Name = item.ID.ToString();
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
            using (ChangeIndicatorOne dialog = new ChangeIndicatorOne())
            {
                dialog.ChangeTitle = "新增 一级指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BasicDataModule module = dialog.GetModule;
                    SqliteHelper.Insert(TableName.BasicData, module, out string msg);
                    if(!string.IsNullOrEmpty(msg))
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
            using (ChangeIndicatorOne dialog = new ChangeIndicatorOne(module))
            {
                dialog.ChangeTitle = "修改 一级指标";
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
            foreach (var item2 in basicModules)
            {
                if(item2.ParentId == id)
                {
                    data.Add(item2.ID);
                    foreach(var item3 in basicModules)
                    {
                        if(item3.ParentId == item2.ID)
                        {
                            data.Add(item3.ID);
                            foreach(var item4 in fourModules)
                            {
                                if(item4.ParentId == item3.ID)
                                {
                                    fourId.Add(item4.ID);
                                }
                            }
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
