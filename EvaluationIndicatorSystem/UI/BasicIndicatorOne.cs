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

        Dictionary<int, BasicDataModule> modules = null;

        private void Init()
        {
            modules = new Dictionary<int, BasicDataModule>();
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
                    int count = modules.Count;
                    modules.Add(count++, item);
                    IndicatorControl control = new IndicatorControl();
                    control.IndicatorName = item.Name;
                    control.UpdateClick += Control_UpdateClick;
                    control.DeleteClick += Control_DeleteClick;
                    tableLayoutPanel1.Controls.Add(control);
                }
            }
        }

        private void Control_UpdateClick(object sender, EventArgs e)
        {
            
        }

        private void Control_DeleteClick(object sender, EventArgs e)
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
