using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class CompanyChange : Form
    {
        public CompanyChange(params UserModule[] para)
        {
            InitializeComponent();
            sysRoles = (List<SysRoleModule>)SqliteHelper.Select(TableName.SysRole);
            if (sysRoles != null && sysRoles.Count > 0)
            {
                foreach (var item in sysRoles)
                {
                    this.combo_role.Items.Add(item.RoleName);
                }
                this.combo_role.SelectedIndex = 0;
            }
            if (para.Length > 0)
            {
                this.txt_name.Enabled = false;
                this.txt_name.Text = para[0].UserName;
                this.combo_role.SelectedItem = para[0].RoleName;
                this.txt_person.Text = para[0].ContractPerson;
                this.txt_phone.Text = para[0].ContractTelPhone;
                this.txt_address.Text = para[0].CompanyAddress;
            }
        }

        List<SysRoleModule> sysRoles = null;
        public string ChangeTitle { set => this.Text = value; }
        UserModule user = null;
        public UserModule GetModule { get => user; set => user = value; }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            lbl_name_msg.Text = string.Empty;

            if (string.IsNullOrEmpty(this.txt_name.Text.Trim()))
            {
                this.lbl_name_msg.Text = "请输入用户名";
                return;
            }
            
            user = new UserModule();
            user.UserName = this.txt_name.Text.Trim();
            foreach(var item in sysRoles)
            {
                if(item.RoleName == this.combo_role.SelectedItem.ToString())
                {
                    user.RoleId = item.RoleId;
                }
            }
            user.ContractPerson = this.txt_person.Text.Trim();
            user.ContractTelPhone = this.txt_phone.Text.Trim();
            user.CompanyAddress = this.txt_address.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }//end of class
}
