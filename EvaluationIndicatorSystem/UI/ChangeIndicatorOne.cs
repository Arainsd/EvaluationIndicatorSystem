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
    public partial class ChangeIndicatorOne : Form
    {
        public ChangeIndicatorOne()
        {
            InitializeComponent();
        }

        public string ChangeTitle { set => this.Text = value; }        

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string indicator = txt_name.Text.Trim();
            string grade = txt_grade.Text.Trim();
            if(string.IsNullOrEmpty(indicator))
            {
                lbl_name_msg.Text = "请输入指标名称";
                return;
            }
            if(string.IsNullOrEmpty(grade))
            {
                lbl_grade_msg.Text = "请输入权重分数";
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }//end of class
}
