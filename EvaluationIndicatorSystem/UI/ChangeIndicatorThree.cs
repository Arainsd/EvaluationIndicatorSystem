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
    public partial class ChangeIndicatorThree : Form
    {
        public ChangeIndicatorThree(Dictionary<string, BasicDataModule> data, params BasicDataModule[] module)
        {
            InitializeComponent();
            modules = new Dictionary<string, BasicDataModule>();
            foreach (var item in data)
            {
                if (item.Value.Level == 1)
                {
                    modules.Add(item.Key, item.Value);
                    comb_one.Items.Add(item.Value.Name);
                } else if(item.Value.Level == 2)
                {
                    modules.Add(item.Key, item.Value);
                    combo_two.Items.Add(item.Value.Name);
                }
            }
            comb_one.SelectedIndex = 0;               
            if (module.Length > 0)
            {
                this.comb_one.SelectedItem = modules[modules[module[0].ParentId.ToString()].ParentId.ToString()].Name;
                this.combo_two.SelectedItem = modules[module[0].ParentId.ToString()].Name;
                this.txt_name.Text = module[0].Name;
                this.txt_grade.Text = module[0].Grade.ToString();
            }
        }

        public string ChangeTitle { set => this.Text = value; }
        Dictionary<string, BasicDataModule> modules = null;
        BasicDataModule module = null;
        public BasicDataModule GetModule { get => module; set => module = value; }

        private void comb_one_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_two.Items.Clear();
            combo_two.Text = string.Empty;
            int id = -1;
            foreach (var item in modules)
            {
                if (((ComboBox)sender).SelectedItem.Equals(item.Value.Name))
                {
                    id = item.Value.ID;
                    break;
                }
            }
            if (id == -1) return;
            foreach (var item in modules)
            {
                if (item.Value.ParentId == id)
                {
                    combo_two.Items.Add(item.Value.Name);
                }
            }
            if (combo_two.Items.Count > 0)
            {
                combo_two.SelectedIndex = 0;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(combo_two.SelectedIndex == -1)
            {
                MessageBox.Show("请选择二级指标", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string indicator = txt_name.Text.Trim();
            int.TryParse(txt_grade.Text.Trim(), out int grade);
            if(string.IsNullOrEmpty(indicator))
            {
                lbl_name_msg.Text = "请输入指标名称";
                return;
            }
            if (grade <= 0)
            {
                lbl_grade_msg.Text = "请输入正整数";
                return;
            }

            int parentId = -1;
            foreach (var item in modules)
            {
                if(item.Value.Name == combo_two.SelectedItem.ToString())
                {
                    parentId = item.Value.ID;
                }
            }

            module = new BasicDataModule();
            module.Name = indicator;
            module.Level = 2;
            module.Grade = grade;
            module.ParentId = parentId;

            this.DialogResult = DialogResult.OK;
        }
    }//end of class
}
