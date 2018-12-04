namespace EvaluationIndicatorSystem
{
    partial class TimeCycleChange
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
            this.lbl_endTime = new System.Windows.Forms.Label();
            this.lbl_startTime = new System.Windows.Forms.Label();
            this.dtp_startTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_endTime = new System.Windows.Forms.DateTimePicker();
            this.lbl_time_msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.txt_name.Location = new System.Drawing.Point(140, 34);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(300, 30);
            this.txt_name.TabIndex = 0;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(40, 40);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(76, 20);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "评价周期 : ";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(360, 245);
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
            this.btn_ok.Location = new System.Drawing.Point(45, 245);
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
            // lbl_endTime
            // 
            this.lbl_endTime.AutoSize = true;
            this.lbl_endTime.Location = new System.Drawing.Point(40, 170);
            this.lbl_endTime.Name = "lbl_endTime";
            this.lbl_endTime.Size = new System.Drawing.Size(76, 20);
            this.lbl_endTime.TabIndex = 16;
            this.lbl_endTime.Text = "截止时间 : ";
            // 
            // lbl_startTime
            // 
            this.lbl_startTime.AutoSize = true;
            this.lbl_startTime.Location = new System.Drawing.Point(40, 105);
            this.lbl_startTime.Name = "lbl_startTime";
            this.lbl_startTime.Size = new System.Drawing.Size(76, 20);
            this.lbl_startTime.TabIndex = 17;
            this.lbl_startTime.Text = "开始时间 : ";
            // 
            // dtp_startTime
            // 
            this.dtp_startTime.CustomFormat = "yyyy-MM-dd";
            this.dtp_startTime.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.dtp_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_startTime.Location = new System.Drawing.Point(140, 100);
            this.dtp_startTime.Name = "dtp_startTime";
            this.dtp_startTime.Size = new System.Drawing.Size(300, 30);
            this.dtp_startTime.TabIndex = 18;
            // 
            // dtp_endTime
            // 
            this.dtp_endTime.CustomFormat = "yyyy-MM-dd";
            this.dtp_endTime.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.dtp_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_endTime.Location = new System.Drawing.Point(140, 161);
            this.dtp_endTime.Name = "dtp_endTime";
            this.dtp_endTime.Size = new System.Drawing.Size(300, 30);
            this.dtp_endTime.TabIndex = 19;
            // 
            // lbl_time_msg
            // 
            this.lbl_time_msg.AutoSize = true;
            this.lbl_time_msg.ForeColor = System.Drawing.Color.Red;
            this.lbl_time_msg.Location = new System.Drawing.Point(5, 135);
            this.lbl_time_msg.Name = "lbl_time_msg";
            this.lbl_time_msg.Size = new System.Drawing.Size(0, 20);
            this.lbl_time_msg.TabIndex = 20;
            // 
            // TimeCycleChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 316);
            this.Controls.Add(this.lbl_time_msg);
            this.Controls.Add(this.dtp_endTime);
            this.Controls.Add(this.dtp_startTime);
            this.Controls.Add(this.lbl_startTime);
            this.Controls.Add(this.lbl_endTime);
            this.Controls.Add(this.lbl_name_msg);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txt_name);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TimeCycleChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增评价周期";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbl_name_msg;
        private System.Windows.Forms.Label lbl_endTime;
        private System.Windows.Forms.Label lbl_startTime;
        private System.Windows.Forms.DateTimePicker dtp_startTime;
        private System.Windows.Forms.DateTimePicker dtp_endTime;
        private System.Windows.Forms.Label lbl_time_msg;
    }
}