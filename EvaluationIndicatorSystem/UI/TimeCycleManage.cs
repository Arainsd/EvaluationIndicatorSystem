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
            cycleModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle);
            dataGridView1.DataSource = cycleModules;
            dataGridView1.Refresh();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (TimeCycleChange dialog = new TimeCycleChange())
            {
                dialog.ChangeTitle = "新增评价指标";
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    TimeCycleModule module = dialog.GetModule;
                    SqliteHelper.Insert(TableName.TimeCycle, module, out string msg);
                    if(!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRefresh();
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if(row == null)
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
            using (TimeCycleChange dialog = new TimeCycleChange(preModule.Name))
            {
                dialog.ChangeTitle = "修改评价指标";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TimeCycleModule module = dialog.GetModule;
                    bool result = SqliteHelper.Update(TableName.TimeCycle, preModule.ID, module, out string msg);
                    if (!result)
                    {
                        if (string.IsNullOrEmpty(msg))
                        {
                            MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                    DataRefresh();
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
