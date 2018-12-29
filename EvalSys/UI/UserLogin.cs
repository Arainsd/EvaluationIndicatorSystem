using System;
using System.Collections.Generic;
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
            Init();
        }

        private UserModule user = null;
        public UserModule User { get => user; set => user = value; }

        private void Init()
        {
            List<SysRoleModule> sysRoles = (List<SysRoleModule>)SqliteHelper.Select(TableName.SysRole);
            if (sysRoles != null && sysRoles.Count > 0)
            {
                foreach (var item in sysRoles)
                {
                    combo_role.Items.Add(item.RoleName);
                }
                combo_role.SelectedIndex = 0;
            }
        }

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
            List<UserModule> users = (List<UserModule>)SqliteHelper.Select(TableName.User, userName);
            user = users[0];
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
