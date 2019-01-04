using System;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class StatisticsDetails : Form
    {
        public StatisticsDetails(EvalutationDataModule module, string user, string time)
        {
            InitializeComponent();
            Init(module, user, time);
        }

        private void Init(EvalutationDataModule module, string user, string time)
        {
            lbl_user_data.Text = user;
            lbl_time_data.Text = time;
            lbl_four_data.Text = module.Name;
            lbl_basicRule_data.Text = module.BasicRule;
            lbl_add_data.Text = module.BasicAdd;
            lbl_sub_data.Text = module.BasicSub;
            lbl_strCalModules_data.Text = module.StrCalModules;
            lbl_description_data.Text = module.Description;
            lbl_grade_data.Text = module.Grade.ToString();
        }        
    }//end of class
}
