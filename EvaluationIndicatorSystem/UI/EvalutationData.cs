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

        DataHelper dataHelper = null;
        List<TimeCycleModule> timeModules = null;
        Dictionary<int, BasicDataModule> basicModules = null;
        Dictionary<int, BasicFourModule> fourModules = null;
        List<EvalutationDataModule> evalutationDatas = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            dataHelper = new DataHelper();
            timeModules = new List<TimeCycleModule>();
            basicModules = new Dictionary<int, BasicDataModule>();
            fourModules = new Dictionary<int, BasicFourModule>();
            evalutationDatas = new List<EvalutationDataModule>();
            TimeCycleRefresh();
        }

        /// <summary>
        /// 刷新评价周期
        /// </summary>
        private void TimeCycleRefresh()
        {
            combo_timeCycle.Items.Clear();
            combo_timeCycle.Text = string.Empty;
            basicModules.Clear();
            fourModules.Clear();
            evalutationDatas.Clear();
            this.lbl_timePeriods.Text = string.Empty;
            this.combo_one.Items.Clear();
            combo_one.Text = string.Empty;
            this.combo_two.Items.Clear();
            combo_two.Text = string.Empty;
            this.combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            
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

        /// <summary>
        /// 评价周期改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_timeCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var item in timeModules)
            {
                if(item.Name == ((ComboBox)sender).SelectedItem.ToString())
                {
                    lbl_timePeriods.Text = item.StartTime.ToString("yyyy-MM-dd") + " - " + item.EndTime.ToString("yyyy-MM-dd");
                    this.combo_one.Items.Clear();
                    combo_one.Text = string.Empty;
                    this.combo_two.Items.Clear();
                    combo_two.Text = string.Empty;
                    this.combo_three.Items.Clear();
                    combo_three.Text = string.Empty;
                    DataRefresh(item.ID);
                    break;
                }
            }
        }

        /// <summary>
        /// 评价周期管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            evalutationDatas = (List<EvalutationDataModule>)SqliteHelper.Select(TableName.EvalutationData, id);
            int[] oneIds = evalutationDatas.Select(p => p.IndicatorOne).Distinct().ToArray();
            SetComboItems(oneIds, combo_one);
        }

        private void SetComboItems(int[] ids, ComboBox combo)
        {
            if (ids != null || ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    combo.Items.Add(basicModules[ids[i]]?.Name);
                }
                if (combo.Items.Count > 0)
                {
                    combo.SelectedIndex = 0;
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
            combo_two.Items.Clear();
            combo_two.Text = string.Empty;
            combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            int id = dataHelper.GetParentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            int[] twoIds = evalutationDatas.Where(p => p.IndicatorOne == id).Select(p => p.IndicatorTwo).Distinct().ToArray();
            SetComboItems(twoIds, combo_two);
        }

        /// <summary>
        /// 二级指标改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_two_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_three.Items.Clear();
            combo_three.Text = string.Empty;
            int id = dataHelper.GetParentId(basicModules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            int[] threeIds = evalutationDatas.Where(p => p.IndicatorTwo == id).Select(p => p.IndicatorThree).Distinct().ToArray();
            SetComboItems(threeIds, combo_three);
        }

        /// <summary>
        /// 三级指标改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_three_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }//end of class
}
