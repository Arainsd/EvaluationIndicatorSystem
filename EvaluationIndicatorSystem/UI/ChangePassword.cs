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
    public partial class ChangePassword : Form
    {
        public ChangePassword(UserModule user)
        {
            InitializeComponent();
            currentUser = user;
            txt_name.Text = user.UserName;
        }

        UserModule currentUser = null;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            lbl_prePassword_msg.Text = string.Empty;
            lbl_pw_msg.Text = string.Empty;
            lbl_pw_msg2.Text = string.Empty;

            string prePassword = txt_prePassword.Text.Trim();
            if(string.IsNullOrEmpty(prePassword))
            {
                lbl_prePassword_msg.Text = "请输入原密码";
                return;
            } else if(!prePassword.Equals(currentUser.PassWord))
            {
                lbl_prePassword_msg.Text = "密码错误";
                return;
            }
            string password = txt_password.Text.Trim();
            if (string.IsNullOrEmpty(password))
            {
                lbl_pw_msg.Text = "请输入新密码";
                return;
            }
            string password2 = txt_password2.Text.Trim();
            if (string.IsNullOrEmpty(password2))
            {
                lbl_pw_msg2.Text = "请确认新密码";
                return;
            }
            else if (!string.Equals(password, password2))
            {
                lbl_pw_msg2.Text = "密码不一致";
                return;
            }

            currentUser.PassWord = password;
            bool result = SqliteHelper.Update(TableName.User, 0, currentUser);
            if (result)
            {
                MessageBox.Show("修改密码成功，请重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("修改密码失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }//end of class
}
