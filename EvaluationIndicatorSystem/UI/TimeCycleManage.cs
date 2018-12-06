using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class TimeCycleManage : Form
    {
        public TimeCycleManage(UserModule user)
        {
            InitializeComponent();
            currentUser = user;
            Init();
        }

        UserModule currentUser = null;
        List<TimeCycleModule> cycleModules = null;

        private void Init()
        {
            List<TimeCycleModule> cycleModules = new List<TimeCycleModule>();
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void DataRefresh()
        {
            cycleModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, TimeCycleState.Local);
            dataGridView1.DataSource = cycleModules;
            dataGridView1.Refresh();
        }

        /// <summary>
        /// add time cycle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            using (TimeCycleChange dialog = new TimeCycleChange())
            {
                dialog.ChangeTitle = "新增评价周期";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TimeCycleModule module = dialog.GetModule;
                    module.UserName = currentUser.UserName;
                    SqliteHelper.Insert(TableName.TimeCycle, module, out string msg);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<TimeCycleModule> timeModule = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, TimeCycleState.Local, module.Name);
                    if (timeModule.Count > 0)
                    {
                        InitEvalutationData(timeModule[0].ID);
                    }
                    DataRefresh();
                }
            }
        }

        /// <summary>
        /// initialize evalutation data
        /// </summary>
        /// <param name="id">time cycle id</param>
        private void InitEvalutationData(int id)
        {
            List<BasicFourModule> fours = (List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour);
            if (fours.Count == 0)
                return;
            List<EvalutationDataModule> datas = new List<EvalutationDataModule>();
            foreach (var four in fours)
            {
                EvalutationDataModule dataModule = new EvalutationDataModule();
                dataModule.TimeCycle = id;
                dataModule.IndicatorFour = four.ID;
                dataModule.DataSource = null;
                dataModule.Remark = string.Empty;
                dataModule.Grade = 0;
                datas.Add(dataModule);
            }
            if(datas.Count > 0)
            {
                SqliteHelper.Insert(TableName.EvalutationData, datas, out string msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// update time cycle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("请选择一行数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id = (int)row.Cells["ID"].Value;
            TimeCycleModule preModule = null;
            foreach (var item in cycleModules)
            {
                if (item.ID == id)
                {
                    preModule = item;
                    break;
                }
            }
            if (preModule == null)
                return;
            using (TimeCycleChange dialog = new TimeCycleChange(preModule))
            {
                dialog.ChangeTitle = "修改评价指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TimeCycleModule module = dialog.GetModule;
                    SqliteHelper.Update(TableName.TimeCycle, preModule.ID, module, out string msg);
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("请选择一行数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int id = (int)row.Cells["ID"].Value;
            if (MessageBox.Show("删除后，关于此周期的数据将一并删除，确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqliteHelper.Delete(TableName.TimeCycle, id);
                SqliteHelper.Delete(TableName.EvalutationData, id);
                DataRefresh();
            }
        }
    }//end of class
}
