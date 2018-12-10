using System;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class UserLogin : Form
    {
        public UserLogin(bool isChange)
        {
            InitializeComponent(); 
            if(isChange)
            {
                linkLabel1.Visible = false;
            }
        }

        private UserModule user = null;
        public UserModule User { get => user; set => user = value; }

        /// <summary>
        /// button log in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_login_Click(object sender, EventArgs e)
        {
            lbl_name_msg.Text = string.Empty;
            lbl_password_msg.Text = string.Empty;
            string userName = txt_name.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                lbl_name_msg.Text = "请输入用户名";
                return;
            }
            string passWord = txt_password.Text.Trim();            
            if (string.IsNullOrEmpty(passWord))
            {
                lbl_password_msg.Text = "请输入密码";
                return;
            }
            if(!SqliteHelper.ValidUser(userName, passWord))
            {
                lbl_password_msg.Text = "密码错误";
                return;
            }
            user = new UserModule();
            user.UserName = userName;
            user.PassWord = passWord;
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (UserRegister dialog = new UserRegister())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }//end of class
}
