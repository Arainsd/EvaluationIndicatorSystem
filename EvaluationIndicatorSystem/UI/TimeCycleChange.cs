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
    public partial class TimeCycleChange : Form
    {
        public TimeCycleChange(params string[] para)
        {
            InitializeComponent();
            if(para.Length > 0)
            {
                this.txt_name.Text = para[0];
            }
        }

        public string ChangeTitle { set => this.Text = value; }
        TimeCycleModule module = null;
        public TimeCycleModule GetModule { get => module; set => module = value; }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.lbl_name_msg.Visible = false;
            if (string.IsNullOrEmpty(this.txt_name.Text.Trim()))
            {
                this.lbl_name_msg.Visible = true;
                return;
            }
            module = new TimeCycleModule();
            module.Name = this.txt_name.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }//end of class
}
