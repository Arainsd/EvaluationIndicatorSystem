using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class ChangeIndicatorTwo : Form
    {
        public ChangeIndicatorTwo(Dictionary<int, BasicDataModule> data, params BasicDataModule[] module)
        {
            InitializeComponent();
            modules = new Dictionary<int, BasicDataModule>();
            foreach (var item in data)
            {
                if (item.Value.Level != 1) continue;
                modules.Add(item.Key, item.Value);
                comb_one.Items.Add(item.Value.Name);
            }
            comb_one.SelectedIndex = 0;
            if (module.Length > 0)
            {
                this.comb_one.SelectedItem = modules[module[0].ParentId].Name;
                this.txt_name.Text = module[0].Name;
                this.txt_grade.Text = module[0].Grade.ToString();
            }
        }

        public string ChangeTitle { set => this.Text = value; }
        Dictionary<int, BasicDataModule> modules = null;
        BasicDataModule module = null;
        public BasicDataModule GetModule { get => module; set => module = value; }

        private void btn_ok_Click(object sender, EventArgs e)
        {
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
                if(item.Value.Name == comb_one.SelectedItem.ToString())
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
