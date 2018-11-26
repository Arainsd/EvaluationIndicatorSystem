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
    public partial class EvalutationData : UserControl
    {
        public EvalutationData()
        {
            InitializeComponent();
            Init();
        }

        List<TimeCycleModule> timeModules = null;

        private void Init()
        {
            timeModules = new List<TimeCycleModule>();
            TimeCycleRefresh();
        }

        private void TimeCycleRefresh()
        {
            timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle);
            if (timeModules.Count == 0)
                return;
            combo_timeCycle.Items.Clear();
            foreach (var item in timeModules)
            {
                combo_timeCycle.Items.Add(item.Name);
            }
            combo_timeCycle.SelectedIndex = 0;
        }

        private void btn_timeCycleMange_Click(object sender, EventArgs e)
        {
            using (TimeCycleManage dialog = new TimeCycleManage())
            {
                if(dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }//end of class
}
