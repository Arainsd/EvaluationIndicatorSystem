namespace EvalSys
{
    partial class CompanyChange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbl_name_msg = new System.Windows.Forms.Label();
            this.label_role = new System.Windows.Forms.Label();
            this.combo_role = new System.Windows.Forms.ComboBox();
            this.lbl_person_msg = new System.Windows.Forms.Label();
            this.label_person = new System.Windows.Forms.Label();
            this.txt_person = new System.Windows.Forms.TextBox();
            this.lbl_phone_msg = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.lbl_address_msg = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_name.Location = new System.Drawing.Point(140, 34);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(450, 30);
            this.txt_name.TabIndex = 0;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(40, 40);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(62, 20);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "用户名 : ";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(510, 380);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 35);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_ok.FlatAppearance.BorderSize = 0;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(45, 380);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 35);
            this.btn_ok.TabIndex = 13;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_name_msg
            // 
            this.lbl_name_msg.AutoSize = true;
            this.lbl_name_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_name_msg.Location = new System.Drawing.Point(5, 65);
            this.lbl_name_msg.Name = "lbl_name_msg";
            this.lbl_name_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_name_msg.TabIndex = 15;
            this.lbl_name_msg.Visible = false;
            // 
            // label_role
            // 
            this.label_role.AutoSize = true;
            this.label_role.Location = new System.Drawing.Point(40, 100);
            this.label_role.Name = "label_role";
            this.label_role.Size = new System.Drawing.Size(76, 20);
            this.label_role.TabIndex = 16;
            this.label_role.Text = "用户角色 : ";
            // 
            // combo_role
            // 
            this.combo_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_role.FormattingEnabled = true;
            this.combo_role.Location = new System.Drawing.Point(140, 97);
            this.combo_role.Name = "combo_role";
            this.combo_role.Size = new System.Drawing.Size(450, 27);
            this.combo_role.TabIndex = 18;
            // 
            // lbl_person_msg
            // 
            this.lbl_person_msg.AutoSize = true;
            this.lbl_person_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_person_msg.Location = new System.Drawing.Point(5, 190);
            this.lbl_person_msg.Name = "lbl_person_msg";
            this.lbl_person_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_person_msg.TabIndex = 21;
            this.lbl_person_msg.Visible = false;
            // 
            // label_person
            // 
            this.label_person.AutoSize = true;
            this.label_person.Location = new System.Drawing.Point(40, 165);
            this.label_person.Name = "label_person";
            this.label_person.Size = new System.Drawing.Size(62, 20);
            this.label_person.TabIndex = 20;
            this.label_person.Text = "联系人 : ";
            // 
            // txt_person
            // 
            this.txt_person.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_person.Location = new System.Drawing.Point(140, 159);
            this.txt_person.Name = "txt_person";
            this.txt_person.Size = new System.Drawing.Size(450, 30);
            this.txt_person.TabIndex = 19;
            // 
            // lbl_phone_msg
            // 
            this.lbl_phone_msg.AutoSize = true;
            this.lbl_phone_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_phone_msg.Location = new System.Drawing.Point(5, 252);
            this.lbl_phone_msg.Name = "lbl_phone_msg";
            this.lbl_phone_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_phone_msg.TabIndex = 24;
            this.lbl_phone_msg.Visible = false;
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Location = new System.Drawing.Point(40, 227);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(76, 20);
            this.lbl_phone.TabIndex = 23;
            this.lbl_phone.Text = "联系电话 : ";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_phone.Location = new System.Drawing.Point(140, 221);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(450, 30);
            this.txt_phone.TabIndex = 22;
            // 
            // lbl_address_msg
            // 
            this.lbl_address_msg.AutoSize = true;
            this.lbl_address_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_address_msg.Location = new System.Drawing.Point(5, 316);
            this.lbl_address_msg.Name = "lbl_address_msg";
            this.lbl_address_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_address_msg.TabIndex = 27;
            this.lbl_address_msg.Visible = false;
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Location = new System.Drawing.Point(40, 291);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(48, 20);
            this.lbl_address.TabIndex = 26;
            this.lbl_address.Text = "地址 : ";
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_address.Location = new System.Drawing.Point(140, 285);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(450, 30);
            this.txt_address.TabIndex = 25;
            // 
            // CompanyChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 441);
            this.Controls.Add(this.lbl_address_msg);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.lbl_phone_msg);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.lbl_person_msg);
            this.Controls.Add(this.label_person);
            this.Controls.Add(this.txt_person);
            this.Controls.Add(this.combo_role);
            this.Controls.Add(this.label_role);
            this.Controls.Add(this.lbl_name_msg);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txt_name);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增评价阶段";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbl_name_msg;
        private System.Windows.Forms.Label label_role;
        private System.Windows.Forms.ComboBox combo_role;
        private System.Windows.Forms.Label lbl_person_msg;
        private System.Windows.Forms.Label label_person;
        private System.Windows.Forms.TextBox txt_person;
        private System.Windows.Forms.Label lbl_phone_msg;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label lbl_address_msg;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.TextBox txt_address;
    }
}