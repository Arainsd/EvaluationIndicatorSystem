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
    public partial class BasicIndicatorOne : UserControl
    {
        public BasicIndicatorOne()
        {
            InitializeComponent();
            Init();
        }

        Dictionary<string, BasicDataModule> modules = null;

        private void Init()
        {
            modules = new Dictionary<string, BasicDataModule>();
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh()
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
                    modules.Add(item.ID.ToString(), item);
                    IndicatorControl control = new IndicatorControl();
                    control.IndicatorName = item.Name;
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
        private void Control_UpdateClick(object sender, string e)
        {
            BasicDataModule module = modules[e];
            using (ChangeIndicatorOne dialog = new ChangeIndicatorOne(module))
            {
                dialog.ChangeTitle = "修改 一级指标";
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
