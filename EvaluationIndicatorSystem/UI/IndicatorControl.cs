using System;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class IndicatorControl : UserControl
    {
        public IndicatorControl()
        {
            InitializeComponent();
        }

        //指标名称
        public string IndicatorName { get => lbl_name.Text; set => lbl_name.Text = value; }
        public string IndicatorGrade { get => lbl_grade.Text; set => lbl_grade.Text = value; }

        public event EventHandler<int> UpdateClick;
        private void btn_update_Click(object sender, EventArgs e)
        {
            UpdateClick?.Invoke(sender, int.Parse(this.Name));
        }

        public event EventHandler<int> DeleteClick;
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteClick?.Invoke(sender, int.Parse(this.Name));
        }

    }//end of class
}
