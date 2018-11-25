namespace EvaluationIndicatorSystem
{
    partial class ChangeIndicatorThree
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_grade = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_grade = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbl_name_msg = new System.Windows.Forms.Label();
            this.lbl_grade_msg = new System.Windows.Forms.Label();
            this.lbl_one = new System.Windows.Forms.Label();
            this.comb_one = new System.Windows.Forms.ComboBox();
            this.combo_two = new System.Windows.Forms.ComboBox();
            this.lbl_two = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(45, 145);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(76, 20);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "指标名称 : ";
            // 
            // lbl_grade
            // 
            this.lbl_grade.AutoSize = true;
            this.lbl_grade.Location = new System.Drawing.Point(45, 235);
            this.lbl_grade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_grade.Name = "lbl_grade";
            this.lbl_grade.Size = new System.Drawing.Size(76, 20);
            this.lbl_grade.TabIndex = 1;
            this.lbl_grade.Text = "权重分数 : ";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_name.Location = new System.Drawing.Point(145, 139);
            this.txt_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_name.Multiline = true;
            this.txt_name.Name = "txt_name";
            this.txt_name.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_name.Size = new System.Drawing.Size(220, 60);
            this.txt_name.TabIndex = 3;
            // 
            // txt_grade
            // 
            this.txt_grade.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_grade.Location = new System.Drawing.Point(145, 229);
            this.txt_grade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_grade.Name = "txt_grade";
            this.txt_grade.Size = new System.Drawing.Size(220, 30);
            this.txt_grade.TabIndex = 4;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(285, 290);
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
            this.btn_ok.Location = new System.Drawing.Point(50, 290);
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
            this.lbl_name_msg.Location = new System.Drawing.Point(30, 170);
            this.lbl_name_msg.Name = "lbl_name_msg";
            this.lbl_name_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_name_msg.TabIndex = 15;
            // 
            // lbl_grade_msg
            // 
            this.lbl_grade_msg.AutoSize = true;
            this.lbl_grade_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_grade_msg.Location = new System.Drawing.Point(30, 260);
            this.lbl_grade_msg.Name = "lbl_grade_msg";
            this.lbl_grade_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_grade_msg.TabIndex = 16;
            // 
            // lbl_one
            // 
            this.lbl_one.AutoSize = true;
            this.lbl_one.Location = new System.Drawing.Point(45, 30);
            this.lbl_one.Name = "lbl_one";
            this.lbl_one.Size = new System.Drawing.Size(76, 20);
            this.lbl_one.TabIndex = 17;
            this.lbl_one.Text = "一级指标 : ";
            // 
            // comb_one
            // 
            this.comb_one.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.comb_one.FormattingEnabled = true;
            this.comb_one.Location = new System.Drawing.Point(145, 24);
            this.comb_one.Name = "comb_one";
            this.comb_one.Size = new System.Drawing.Size(220, 31);
            this.comb_one.TabIndex = 18;
            this.comb_one.SelectedIndexChanged += new System.EventHandler(this.comb_one_SelectedIndexChanged);
            // 
            // combo_two
            // 
            this.combo_two.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_two.FormattingEnabled = true;
            this.combo_two.Location = new System.Drawing.Point(145, 79);
            this.combo_two.Name = "combo_two";
            this.combo_two.Size = new System.Drawing.Size(220, 31);
            this.combo_two.TabIndex = 20;
            // 
            // lbl_two
            // 
            this.lbl_two.AutoSize = true;
            this.lbl_two.Location = new System.Drawing.Point(45, 85);
            this.lbl_two.Name = "lbl_two";
            this.lbl_two.Size = new System.Drawing.Size(76, 20);
            this.lbl_two.TabIndex = 19;
            this.lbl_two.Text = "二级指标 : ";
            // 
            // ChangeIndicatorThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(419, 352);
            this.Controls.Add(this.combo_two);
            this.Controls.Add(this.lbl_two);
            this.Controls.Add(this.comb_one);
            this.Controls.Add(this.lbl_one);
            this.Controls.Add(this.lbl_grade_msg);
            this.Controls.Add(this.lbl_name_msg);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_grade);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_grade);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChangeIndicatorThree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增/修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_grade;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_grade;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbl_name_msg;
        private System.Windows.Forms.Label lbl_grade_msg;
        private System.Windows.Forms.Label lbl_one;
        private System.Windows.Forms.ComboBox comb_one;
        private System.Windows.Forms.ComboBox combo_two;
        private System.Windows.Forms.Label lbl_two;
    }
}