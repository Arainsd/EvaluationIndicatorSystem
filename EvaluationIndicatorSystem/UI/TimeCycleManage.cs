using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class TimeCycleManage : Form
    {
        public TimeCycleManage()
        {
            InitializeComponent();
            Init();
        }

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
            cycleModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, 0);
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
                    SqliteHelper.Insert(TableName.TimeCycle, module, out string msg);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<TimeCycleModule> timeModule = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, 0, module.Name);
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
            List<BasicDataModule> ones = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData, 1);
            List<BasicDataModule> twos = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData, 2);
            List<BasicDataModule> threes = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData, 3);
            List<BasicFourModule> fours = (List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour);
            if (ones.Count == 0 || twos.Count == 0 || threes.Count == 0 || fours.Count == 0)
                return;
            List<EvalutationDataModule> datas = new List<EvalutationDataModule>();
            foreach (var one in ones)
            {
                foreach (var two in twos)
                {
                    if (two.ParentId == one.ID)
                    {
                        foreach (var three in threes)
                        {
                            if (three.ParentId == two.ID)
                            {
                                EvalutationDataModule data = new EvalutationDataModule();
                                data.TimeCycle = id;
                                data.IndicatorOne = one.ID;
                                data.IndicatorTwo = two.ID;
                                data.IndicatorThree = three.ID;
                                data.EvalutationDataObj = new List<EvalutationFourModule>();                                    
                                foreach (var four in fours)
                                {
                                    if (four.ParentId == three.ID)
                                    {
                                        EvalutationFourModule fourModule = new EvalutationFourModule();
                                        fourModule.ID = four.ID;
                                        fourModule.DataSource = null;
                                        fourModule.Remark = string.Empty;
                                        data.EvalutationDataObj.Add(fourModule);
                                    }
                                }                                
                                datas.Add(data);
                            }
                        }
                    }
                }
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
                DataRefresh();
            }
        }
    }//end of class
}
