using System;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class TimeCycleChange : Form
    {
        public TimeCycleChange(params TimeCycleModule[] para)
        {
            InitializeComponent();
            if(para.Length > 0)
            {
                this.txt_name.Text = para[0].Name;
                this.dtp_startTime.Value = para[0].StartTime;
                this.dtp_endTime.Value = para[0].EndTime;
            }
        }

        public string ChangeTitle { set => this.Text = value; }
        TimeCycleModule module = null;
        public TimeCycleModule GetModule { get => module; set => module = value; }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            lbl_name_msg.Text = string.Empty;
            lbl_time_msg.Text = string.Empty;

            if (string.IsNullOrEmpty(this.txt_name.Text.Trim()))
            {
                this.lbl_name_msg.Text = "请输入评价周期";
                return;
            }

            if(dtp_startTime.Value.Date > dtp_endTime.Value.Date)
            {
                lbl_time_msg.Text = "开始时间不能大于截止时间";
                return;
            }

            module = new TimeCycleModule();
            module.Name = this.txt_name.Text.Trim();
            module.StartTime = this.dtp_startTime.Value.Date;
            module.EndTime = this.dtp_endTime.Value.Date;
            module.CreateTime = DateTime.Now.Date;
            module.LatestCommitTime = module.CreateTime;
            module.State = (int)TimeCycleState.Local;
            this.DialogResult = DialogResult.OK;
        }
    }//end of class
}
