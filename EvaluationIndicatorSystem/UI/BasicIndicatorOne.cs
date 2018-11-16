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

        private void DataRefresh()
        {
            modules.Clear();
            tableLayoutPanel1.Controls.Clear();
            List<BasicDataModule> obj = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData);            
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
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
                        MessageBox.Show("更新失败", "修改提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRefresh();
                }
            }
        }

        private void Control_DeleteClick(object sender, string e)
        {
            
        }

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
                        MessageBox.Show(msg, "新增提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataRefresh();
                }
            }
        }
    }//end of class
}
