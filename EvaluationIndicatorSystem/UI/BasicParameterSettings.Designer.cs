namespace EvaluationIndicatorSystem
{
    partial class BasicParameterSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_one = new System.Windows.Forms.Label();
            this.lbl_two = new System.Windows.Forms.Label();
            this.lbl_three = new System.Windows.Forms.Label();
            this.comb_one = new System.Windows.Forms.ComboBox();
            this.comb_two = new System.Windows.Forms.ComboBox();
            this.comb_three = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comb_three);
            this.groupBox1.Controls.Add(this.comb_two);
            this.groupBox1.Controls.Add(this.comb_one);
            this.groupBox1.Controls.Add(this.lbl_three);
            this.groupBox1.Controls.Add(this.lbl_two);
            this.groupBox1.Controls.Add(this.lbl_one);
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(750, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指标选择";
            // 
            // lbl_one
            // 
            this.lbl_one.AutoSize = true;
            this.lbl_one.Location = new System.Drawing.Point(16, 49);
            this.lbl_one.Name = "lbl_one";
            this.lbl_one.Size = new System.Drawing.Size(76, 20);
            this.lbl_one.TabIndex = 0;
            this.lbl_one.Text = "一级指标 : ";
            // 
            // lbl_two
            // 
            this.lbl_two.AutoSize = true;
            this.lbl_two.Location = new System.Drawing.Point(343, 53);
            this.lbl_two.Name = "lbl_two";
            this.lbl_two.Size = new System.Drawing.Size(76, 20);
            this.lbl_two.TabIndex = 1;
            this.lbl_two.Text = "二级指标 : ";
            // 
            // lbl_three
            // 
            this.lbl_three.AutoSize = true;
            this.lbl_three.Location = new System.Drawing.Point(16, 108);
            this.lbl_three.Name = "lbl_three";
            this.lbl_three.Size = new System.Drawing.Size(76, 20);
            this.lbl_three.TabIndex = 2;
            this.lbl_three.Text = "三级指标 : ";
            // 
            // comb_one
            // 
            this.comb_one.FormattingEnabled = true;
            this.comb_one.Location = new System.Drawing.Point(121, 46);
            this.comb_one.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comb_one.Name = "comb_one";
            this.comb_one.Size = new System.Drawing.Size(159, 27);
            this.comb_one.TabIndex = 3;
            this.comb_one.SelectedIndexChanged += new System.EventHandler(this.comb_one_SelectedIndexChanged);
            // 
            // comb_two
            // 
            this.comb_two.FormattingEnabled = true;
            this.comb_two.Location = new System.Drawing.Point(446, 42);
            this.comb_two.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comb_two.Name = "comb_two";
            this.comb_two.Size = new System.Drawing.Size(159, 27);
            this.comb_two.TabIndex = 4;
            this.comb_two.SelectedIndexChanged += new System.EventHandler(this.comb_two_SelectedIndexChanged);
            // 
            // comb_three
            // 
            this.comb_three.FormattingEnabled = true;
            this.comb_three.Location = new System.Drawing.Point(121, 101);
            this.comb_three.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comb_three.Name = "comb_three";
            this.comb_three.Size = new System.Drawing.Size(159, 27);
            this.comb_three.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(16, 198);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(750, 159);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "四级指标参数设置";
            // 
            // BasicParameterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 396);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BasicParameterSettings";
            this.Text = "基础参数设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_one;
        private System.Windows.Forms.Label lbl_three;
        private System.Windows.Forms.Label lbl_two;
        private System.Windows.Forms.ComboBox comb_one;
        private System.Windows.Forms.ComboBox comb_three;
        private System.Windows.Forms.ComboBox comb_two;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}