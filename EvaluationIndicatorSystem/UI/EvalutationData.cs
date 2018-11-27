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
        Dictionary<int, BasicDataModule> basicModules = null;
        Dictionary<int, BasicFourModule> fourModules = null;

        private void Init()
        {
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
            fourModules = new Dictionary<int, BasicFourModule>();
            TimeCycleRefresh();
        }

        private void TimeCycleRefresh()
        {
            combo_timeCycle.Items.Clear();
            basicModules.Clear();
            fourModules.Clear();
            this.lbl_timePeriods.Text = string.Empty;
            this.combo_one.Items.Clear();
            this.combo_two.Items.Clear();
            this.combo_three.Items.Clear();
            
            timeModules = (List<TimeCycleModule>)SqliteHelper.Select(TableName.TimeCycle, 0);
            if (timeModules.Count == 0) return;
            basicModules = ((List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData)).ToDictionary(key => key.ID, basicModule => basicModule);
            fourModules = ((List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour)).ToDictionary(key => key.ID, fourModule => fourModule);

            foreach (var item in timeModules)
            {
                combo_timeCycle.Items.Add(item.Name);
            }
            combo_timeCycle.SelectedIndex = 0;
        }

        private void combo_timeCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var item in timeModules)
            {
                if(item.Name == ((ComboBox)sender).SelectedItem.ToString())
                {
                    lbl_timePeriods.Text = item.StartTime.ToString("yyyy-MM-dd") + " - " + item.EndTime.ToString("yyyy-MM-dd");
                    DataRefresh(item.ID);
                    break;
                }
            }
        }

        private void btn_timeCycleMange_Click(object sender, EventArgs e)
        {
            using (TimeCycleManage dialog = new TimeCycleManage())
            {
                dialog.ShowDialog();
                TimeCycleRefresh();
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void DataRefresh(int id)
        {
            if (basicModules.Count == 0 || fourModules.Count == 0) return;
            List<EvalutationDataModule> evalutationDatas = (List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, id);

        }        
    }//end of class
}
