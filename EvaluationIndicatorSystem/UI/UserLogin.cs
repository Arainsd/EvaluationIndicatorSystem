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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();            
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
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FormRegister dialog = new FormRegister())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("注册成功", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }//end of class
}
