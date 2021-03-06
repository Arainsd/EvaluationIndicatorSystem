﻿namespace EvalSys
{
    partial class UserRegister
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_password2 = new System.Windows.Forms.TextBox();
            this.lbl_password2 = new System.Windows.Forms.Label();
            this.lbl_name_msg = new System.Windows.Forms.Label();
            this.lbl_pw_msg = new System.Windows.Forms.Label();
            this.lbl_pw_msg2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(328, 216);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 35);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "重置";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_ok.FlatAppearance.BorderSize = 0;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(87, 216);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 35);
            this.btn_ok.TabIndex = 11;
            this.btn_ok.Text = "注册";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_password.Location = new System.Drawing.Point(188, 94);
            this.txt_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(220, 30);
            this.txt_password.TabIndex = 10;
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_name.Location = new System.Drawing.Point(188, 34);
            this.txt_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(220, 30);
            this.txt_name.TabIndex = 9;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_password.Location = new System.Drawing.Point(83, 100);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(48, 20);
            this.lbl_password.TabIndex = 8;
            this.lbl_password.Text = "密码 : ";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_name.Location = new System.Drawing.Point(83, 40);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(62, 20);
            this.lbl_name.TabIndex = 7;
            this.lbl_name.Text = "用户名 : ";
            // 
            // txt_password2
            // 
            this.txt_password2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_password2.Location = new System.Drawing.Point(188, 154);
            this.txt_password2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_password2.Name = "txt_password2";
            this.txt_password2.PasswordChar = '*';
            this.txt_password2.Size = new System.Drawing.Size(220, 30);
            this.txt_password2.TabIndex = 14;
            // 
            // lbl_password2
            // 
            this.lbl_password2.AutoSize = true;
            this.lbl_password2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_password2.Location = new System.Drawing.Point(83, 160);
            this.lbl_password2.Name = "lbl_password2";
            this.lbl_password2.Size = new System.Drawing.Size(48, 20);
            this.lbl_password2.TabIndex = 13;
            this.lbl_password2.Text = "密码 : ";
            // 
            // lbl_name_msg
            // 
            this.lbl_name_msg.AutoSize = true;
            this.lbl_name_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_name_msg.Location = new System.Drawing.Point(73, 60);
            this.lbl_name_msg.Name = "lbl_name_msg";
            this.lbl_name_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_name_msg.TabIndex = 15;
            // 
            // lbl_pw_msg
            // 
            this.lbl_pw_msg.AutoSize = true;
            this.lbl_pw_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_pw_msg.Location = new System.Drawing.Point(73, 120);
            this.lbl_pw_msg.Name = "lbl_pw_msg";
            this.lbl_pw_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_pw_msg.TabIndex = 16;
            // 
            // lbl_pw_msg2
            // 
            this.lbl_pw_msg2.AutoSize = true;
            this.lbl_pw_msg2.ForeColor = System.Drawing.Color.Red;
            this.lbl_pw_msg2.Location = new System.Drawing.Point(73, 180);
            this.lbl_pw_msg2.Name = "lbl_pw_msg2";
            this.lbl_pw_msg2.Size = new System.Drawing.Size(0, 20);
            this.lbl_pw_msg2.TabIndex = 17;
            // 
            // UserRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 286);
            this.Controls.Add(this.lbl_pw_msg2);
            this.Controls.Add(this.lbl_pw_msg);
            this.Controls.Add(this.lbl_name_msg);
            this.Controls.Add(this.txt_password2);
            this.Controls.Add(this.lbl_password2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_password2;
        private System.Windows.Forms.Label lbl_password2;
        private System.Windows.Forms.Label lbl_name_msg;
        private System.Windows.Forms.Label lbl_pw_msg;
        private System.Windows.Forms.Label lbl_pw_msg2;
    }
}