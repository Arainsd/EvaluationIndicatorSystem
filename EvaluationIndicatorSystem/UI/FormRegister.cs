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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            lbl_name_msg.Text = string.Empty;
            lbl_pw_msg.Text = string.Empty;
            lbl_pw_msg2.Text = string.Empty;

            string name = txt_name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                lbl_name_msg.Text = "请输入用户名";
                return;
            }
            string password = txt_password.Text.Trim();
            if (string.IsNullOrEmpty(password))
            {
                lbl_pw_msg.Text = "请输入密码";
                return;
            }
            string password2 = txt_password2.Text.Trim();
            if (string.IsNullOrEmpty(password2))
            {
                lbl_pw_msg2.Text = "请确认密码";
                return;
            }
            else if (!string.Equals(password, password2))
            {
                lbl_pw_msg2.Text = "密码不一致";
                return;
            }

            bool result = SqliteHelper.Insert(TableName.User, new UserModule { UserName = name, PassWord = password }, out string msg);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lbl_name_msg.Text = msg;
                return;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }//end of class
}
