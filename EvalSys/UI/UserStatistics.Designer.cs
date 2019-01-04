namespace EvalSys
{
    partial class UserStatistics
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.combo_three = new System.Windows.Forms.ComboBox();
            this.combo_two = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_indicator = new System.Windows.Forms.Label();
            this.combo_user = new System.Windows.Forms.ComboBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.combo_one = new System.Windows.Forms.ComboBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_three
            // 
            this.combo_three.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_three.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_three.FormattingEnabled = true;
            this.combo_three.Location = new System.Drawing.Point(530, 74);
            this.combo_three.Name = "combo_three";
            this.combo_three.Size = new System.Drawing.Size(200, 31);
            this.combo_three.TabIndex = 4;
            this.combo_three.SelectedIndexChanged += new System.EventHandler(this.combo_three_SelectedIndexChanged);
            // 
            // combo_two
            // 
            this.combo_two.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_two.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_two.FormattingEnabled = true;
            this.combo_two.Location = new System.Drawing.Point(305, 74);
            this.combo_two.Name = "combo_two";
            this.combo_two.Size = new System.Drawing.Size(200, 31);
            this.combo_two.TabIndex = 3;
            this.combo_two.SelectedIndexChanged += new System.EventHandler(this.combo_two_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_indicator);
            this.panel1.Controls.Add(this.combo_user);
            this.panel1.Controls.Add(this.lbl_user);
            this.panel1.Controls.Add(this.combo_three);
            this.panel1.Controls.Add(this.combo_two);
            this.panel1.Controls.Add(this.combo_one);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 120);
            this.panel1.TabIndex = 0;
            // 
            // lbl_indicator
            // 
            this.lbl_indicator.AutoSize = true;
            this.lbl_indicator.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_indicator.Location = new System.Drawing.Point(5, 80);
            this.lbl_indicator.Name = "lbl_indicator";
            this.lbl_indicator.Size = new System.Drawing.Size(76, 20);
            this.lbl_indicator.TabIndex = 9;
            this.lbl_indicator.Text = "评价指标 : ";
            // 
            // combo_user
            // 
            this.combo_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_user.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_user.FormattingEnabled = true;
            this.combo_user.Location = new System.Drawing.Point(85, 19);
            this.combo_user.Name = "combo_user";
            this.combo_user.Size = new System.Drawing.Size(200, 31);
            this.combo_user.TabIndex = 5;
            this.combo_user.SelectedIndexChanged += new System.EventHandler(this.combo_user_SelectedIndexChanged);
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_user.Location = new System.Drawing.Point(5, 25);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(76, 20);
            this.lbl_user.TabIndex = 2;
            this.lbl_user.Text = "单位名称 : ";
            // 
            // combo_one
            // 
            this.combo_one.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_one.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_one.FormattingEnabled = true;
            this.combo_one.Location = new System.Drawing.Point(85, 74);
            this.combo_one.Name = "combo_one";
            this.combo_one.Size = new System.Drawing.Size(200, 31);
            this.combo_one.TabIndex = 2;
            this.combo_one.SelectedIndexChanged += new System.EventHandler(this.combo_one_SelectedIndexChanged);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_title.Location = new System.Drawing.Point(10, 10);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(139, 20);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "数据统计 > 用户统计";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(192)))), ((int)(((byte)(211)))));
            this.splitContainer1.Panel1.Controls.Add(this.lbl_title);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(960, 640);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 130);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 439);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(932, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "柱状图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend_user";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(926, 401);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(932, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "表格";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.TimeName,
            this.Column6});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(926, 427);
            this.dataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "FourName";
            this.Column1.HeaderText = "评价内容";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // TimeName
            // 
            this.TimeName.DataPropertyName = "TimeName";
            this.TimeName.HeaderText = "评价阶段";
            this.TimeName.Name = "TimeName";
            this.TimeName.ReadOnly = true;
            this.TimeName.Width = 200;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Grade";
            this.Column6.HeaderText = "得分";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // UserStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserStatistics";
            this.Size = new System.Drawing.Size(960, 640);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_three;
        private System.Windows.Forms.ComboBox combo_two;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combo_one;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.ComboBox combo_user;
        private System.Windows.Forms.Label lbl_indicator;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
