using System;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class ChangeIndicatorOne : Form
    {
        public ChangeIndicatorOne(params BasicDataModule[] module)
        {
            InitializeComponent();
            if (module.Length > 0)
            {
                this.txt_name.Text = module[0].Name;
                this.txt_grade.Text = module[0].Grade.ToString();
            }
        }

        public string ChangeTitle { set => this.Text = value; }

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

            module = new BasicDataModule();
            module.Name = indicator;
            module.Level = 1;
            module.Grade = grade;
            module.ParentId = 0;

            this.DialogResult = DialogResult.OK;
        }
    }//end of class
}
