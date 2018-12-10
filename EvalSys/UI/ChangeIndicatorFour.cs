using System;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class ChangeIndicatorFour : Form
    {        
        string[] calModule = { "开关型", "单一比较型", "多重比较型", "分段计数型", "单一比例比较型" };
        public ChangeIndicatorFour(params BasicFourModule[] module)
        {
            InitializeComponent();
            for (var i = 0; i < calModule.Length; i++)
            {
                clb_calModule.Items.Add(calModule[i]);
            }
            if (module.Length > 0)
            {
                this.txt_name.Text = module[0].Name;
                this.txt_basicRule.Text = module[0].BasicRule;
                this.txt_sub.Text = module[0].BasicSub;
                this.txt_add.Text = module[0].BasicAdd;
                CalModule[] cals = module[0].CalModules;
                foreach (var item in cals)
                {
                    clb_calModule.SetItemChecked((int)item - 1, true);
                }
            }
        }

        public string ChangeTitle { set => this.Text = value; }
        BasicFourModule fourModule = null;
        public BasicFourModule GetModule { get => fourModule; set => fourModule = value; }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string indicator = txt_name.Text.Trim();
            if (string.IsNullOrEmpty(indicator))
            {
                lbl_name_msg.Text = "请输入评价准则内容";
                return;
            }
            var selectedCalModule = clb_calModule.CheckedIndices;
            if (selectedCalModule.Count == 0)
            {
                lbl_calModule_msg.Text = "请选择计算模型";
                return;
            }

            fourModule = new BasicFourModule();
            fourModule.Name = indicator;
            fourModule.Level = 4;
            fourModule.BasicRule = txt_basicRule.Text.Trim();
            fourModule.BasicSub = txt_sub.Text.Trim();
            fourModule.BasicAdd = txt_add.Text.Trim();
            fourModule.CalModules = new CalModule[selectedCalModule.Count];
            for(var i = 0;i < selectedCalModule.Count;i++)
            {
                fourModule.CalModules[i] = (CalModule)(selectedCalModule[i] + 1);
            }

            this.DialogResult = DialogResult.OK;
        }
    }//end of class
}
