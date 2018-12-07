using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class DataStatistics : UserControl
    {
        public DataStatistics()
        {
            InitializeComponent();
            Init();
        }

        Dictionary<int, BasicDataModule> modules = null;
        List<BasicFourModule> fourModules = null;
        DataHelper dataHelper = null;
        string[] calModule = { "开关型", "单一比较型", "多重比较型", "分段计数型", "单一比例比较型" };

        private void Init()
        {
            dataHelper = new DataHelper();
            modules = new Dictionary<int, BasicDataModule>();
            fourModules = new List<BasicFourModule>();
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void DataRefresh()
        {
            modules.Clear();
            combo_one.Items.Clear();
            combo_two.Items.Clear();
            combo_three.Items.Clear();
            //dataGridView1.DataSource = new List<BasicFourModule>();
            fourModules = (List<BasicFourModule>)SqliteHelper.Select(TableName.BasicFour);
            List<BasicDataModule> obj = (List<BasicDataModule>)SqliteHelper.Select(TableName.BasicData);
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {                         
                    modules.Add(item.ID, item);
                    if (item.Level == 1)
                    {
                        combo_one.Items.Add(item.Name);
                    }
                }
                if(combo_one.Items.Count > 0)
                {
                    combo_one.SelectedIndex = 0;
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
            //dataGridView1.DataSource = new List<BasicFourModule>();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            dataHelper.SetComboItem(modules, combo_two, id);
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
            //dataGridView1.DataSource = new List<BasicFourModule>();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            dataHelper.SetComboItem(modules, combo_three, id);
        }

        /// <summary>
        /// 三级指标改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_three_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = new List<BasicFourModule>();
            int id = -1;
            id = dataHelper.GetCurrentId(modules, ((ComboBox)sender).SelectedItem.ToString());
            if (id == -1) return;
            List<BasicFourModule> currentModule = new List<BasicFourModule>();
            for(int i  = 0;i < fourModules.Count;i ++)
            {
                if (fourModules[i].ParentId == id)
                {
                    currentModule.Add(fourModules[i]);
                }
            }
            //dataGridView1.DataSource = currentModule;
            //dataGridView1.Refresh();
        }
    }//end of class
}

