namespace EvaluationIndicatorSystem
{
    partial class ChangeIndicatorFour
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
            this.txt_basicRule = new System.Windows.Forms.TextBox();
            this.lbl_basicGrade = new System.Windows.Forms.Label();
            this.txt_sub = new System.Windows.Forms.TextBox();
            this.lbl_sub = new System.Windows.Forms.Label();
            this.txt_add = new System.Windows.Forms.TextBox();
            this.lbl_add = new System.Windows.Forms.Label();
            this.lbl_name_msg = new System.Windows.Forms.Label();
            this.lbl_calModule = new System.Windows.Forms.Label();
            this.clb_calModule = new System.Windows.Forms.CheckedListBox();
            this.lbl_calModule_msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(170, 37);
            this.txt_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_name.Multiline = true;
            this.txt_name.Name = "txt_name";
            this.txt_name.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_name.Size = new System.Drawing.Size(300, 50);
            this.txt_name.TabIndex = 5;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(45, 40);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(104, 20);
            this.lbl_name.TabIndex = 4;
            this.lbl_name.Text = "评价准则内容 : ";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(390, 388);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 35);
            this.btn_cancel.TabIndex = 16;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_ok.FlatAppearance.BorderSize = 0;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(49, 388);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 35);
            this.btn_ok.TabIndex = 15;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_basicRule
            // 
            this.txt_basicRule.Location = new System.Drawing.Point(170, 107);
            this.txt_basicRule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_basicRule.Multiline = true;
            this.txt_basicRule.Name = "txt_basicRule";
            this.txt_basicRule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_basicRule.Size = new System.Drawing.Size(300, 50);
            this.txt_basicRule.TabIndex = 18;
            // 
            // lbl_basicGrade
            // 
            this.lbl_basicGrade.AutoSize = true;
            this.lbl_basicGrade.Location = new System.Drawing.Point(45, 110);
            this.lbl_basicGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_basicGrade.Name = "lbl_basicGrade";
            this.lbl_basicGrade.Size = new System.Drawing.Size(76, 20);
            this.lbl_basicGrade.TabIndex = 17;
            this.lbl_basicGrade.Text = "基础分值 : ";
            // 
            // txt_sub
            // 
            this.txt_sub.Location = new System.Drawing.Point(170, 177);
            this.txt_sub.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_sub.Multiline = true;
            this.txt_sub.Name = "txt_sub";
            this.txt_sub.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_sub.Size = new System.Drawing.Size(300, 50);
            this.txt_sub.TabIndex = 20;
            // 
            // lbl_sub
            // 
            this.lbl_sub.AutoSize = true;
            this.lbl_sub.Location = new System.Drawing.Point(45, 180);
            this.lbl_sub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sub.Name = "lbl_sub";
            this.lbl_sub.Size = new System.Drawing.Size(48, 20);
            this.lbl_sub.TabIndex = 19;
            this.lbl_sub.Text = "扣分 : ";
            // 
            // txt_add
            // 
            this.txt_add.Location = new System.Drawing.Point(170, 246);
            this.txt_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_add.Multiline = true;
            this.txt_add.Name = "txt_add";
            this.txt_add.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_add.Size = new System.Drawing.Size(300, 50);
            this.txt_add.TabIndex = 22;
            // 
            // lbl_add
            // 
            this.lbl_add.AutoSize = true;
            this.lbl_add.Location = new System.Drawing.Point(45, 249);
            this.lbl_add.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_add.Name = "lbl_add";
            this.lbl_add.Size = new System.Drawing.Size(48, 20);
            this.lbl_add.TabIndex = 21;
            this.lbl_add.Text = "加分 : ";
            // 
            // lbl_name_msg
            // 
            this.lbl_name_msg.AutoSize = true;
            this.lbl_name_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_name_msg.Location = new System.Drawing.Point(30, 65);
            this.lbl_name_msg.Name = "lbl_name_msg";
            this.lbl_name_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_name_msg.TabIndex = 23;
            // 
            // lbl_calModule
            // 
            this.lbl_calModule.AutoSize = true;
            this.lbl_calModule.Location = new System.Drawing.Point(45, 319);
            this.lbl_calModule.Name = "lbl_calModule";
            this.lbl_calModule.Size = new System.Drawing.Size(76, 20);
            this.lbl_calModule.TabIndex = 24;
            this.lbl_calModule.Text = "计算模型 : ";
            // 
            // clb_calModule
            // 
            this.clb_calModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clb_calModule.ColumnWidth = 150;
            this.clb_calModule.FormattingEnabled = true;
            this.clb_calModule.Location = new System.Drawing.Point(170, 319);
            this.clb_calModule.MultiColumn = true;
            this.clb_calModule.Name = "clb_calModule";
            this.clb_calModule.Size = new System.Drawing.Size(300, 60);
            this.clb_calModule.TabIndex = 25;
            // 
            // lbl_calModule_msg
            // 
            this.lbl_calModule_msg.AutoSize = true;
            this.lbl_calModule_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_calModule_msg.Location = new System.Drawing.Point(30, 340);
            this.lbl_calModule_msg.Name = "lbl_calModule_msg";
            this.lbl_calModule_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_calModule_msg.TabIndex = 26;
            // 
            // ChangeIndicatorFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 437);
            this.Controls.Add(this.lbl_calModule_msg);
            this.Controls.Add(this.clb_calModule);
            this.Controls.Add(this.lbl_calModule);
            this.Controls.Add(this.lbl_name_msg);
            this.Controls.Add(this.txt_add);
            this.Controls.Add(this.lbl_add);
            this.Controls.Add(this.txt_sub);
            this.Controls.Add(this.lbl_sub);
            this.Controls.Add(this.txt_basicRule);
            this.Controls.Add(this.lbl_basicGrade);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "ChangeIndicatorFour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增/修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_basicRule;
        private System.Windows.Forms.Label lbl_basicGrade;
        private System.Windows.Forms.TextBox txt_sub;
        private System.Windows.Forms.Label lbl_sub;
        private System.Windows.Forms.TextBox txt_add;
        private System.Windows.Forms.Label lbl_add;
        private System.Windows.Forms.Label lbl_name_msg;
        private System.Windows.Forms.Label lbl_calModule;
        private System.Windows.Forms.CheckedListBox clb_calModule;
        private System.Windows.Forms.Label lbl_calModule_msg;
    }
}