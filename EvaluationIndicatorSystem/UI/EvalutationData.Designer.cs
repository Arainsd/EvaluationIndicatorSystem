namespace EvaluationIndicatorSystem
{
    partial class EvalutationData
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
            this.combo_three = new System.Windows.Forms.ComboBox();
            this.combo_two = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_commit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_timePeriods = new System.Windows.Forms.Label();
            this.btn_timeCycleMange = new System.Windows.Forms.Button();
            this.lbl_indicator = new System.Windows.Forms.Label();
            this.lbl_timePeriod = new System.Windows.Forms.Label();
            this.combo_timeCycle = new System.Windows.Forms.ComboBox();
            this.lbl_timeCycle = new System.Windows.Forms.Label();
            this.combo_one = new System.Windows.Forms.ComboBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndicatorFour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_three
            // 
            this.combo_three.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_three.FormattingEnabled = true;
            this.combo_three.Location = new System.Drawing.Point(545, 74);
            this.combo_three.Name = "combo_three";
            this.combo_three.Size = new System.Drawing.Size(200, 31);
            this.combo_three.TabIndex = 4;
            this.combo_three.SelectedIndexChanged += new System.EventHandler(this.combo_three_SelectedIndexChanged);
            // 
            // combo_two
            // 
            this.combo_two.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_two.FormattingEnabled = true;
            this.combo_two.Location = new System.Drawing.Point(325, 74);
            this.combo_two.Name = "combo_two";
            this.combo_two.Size = new System.Drawing.Size(200, 31);
            this.combo_two.TabIndex = 3;
            this.combo_two.SelectedIndexChanged += new System.EventHandler(this.combo_two_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_commit);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.lbl_timePeriods);
            this.panel1.Controls.Add(this.btn_timeCycleMange);
            this.panel1.Controls.Add(this.lbl_indicator);
            this.panel1.Controls.Add(this.lbl_timePeriod);
            this.panel1.Controls.Add(this.combo_timeCycle);
            this.panel1.Controls.Add(this.lbl_timeCycle);
            this.panel1.Controls.Add(this.combo_three);
            this.panel1.Controls.Add(this.combo_two);
            this.panel1.Controls.Add(this.combo_one);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 120);
            this.panel1.TabIndex = 0;
            // 
            // btn_commit
            // 
            this.btn_commit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_commit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_commit.FlatAppearance.BorderSize = 0;
            this.btn_commit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_commit.ForeColor = System.Drawing.Color.White;
            this.btn_commit.Location = new System.Drawing.Point(860, 72);
            this.btn_commit.Name = "btn_commit";
            this.btn_commit.Size = new System.Drawing.Size(75, 35);
            this.btn_commit.TabIndex = 16;
            this.btn_commit.Text = "提交";
            this.btn_commit.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(768, 72);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 35);
            this.btn_save.TabIndex = 15;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // lbl_timePeriods
            // 
            this.lbl_timePeriods.AutoSize = true;
            this.lbl_timePeriods.Location = new System.Drawing.Point(389, 23);
            this.lbl_timePeriods.Name = "lbl_timePeriods";
            this.lbl_timePeriods.Size = new System.Drawing.Size(183, 20);
            this.lbl_timePeriods.TabIndex = 14;
            this.lbl_timePeriods.Text = "2018-11-26  -  2018-11-26";
            // 
            // btn_timeCycleMange
            // 
            this.btn_timeCycleMange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_timeCycleMange.FlatAppearance.BorderSize = 0;
            this.btn_timeCycleMange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_timeCycleMange.ForeColor = System.Drawing.Color.White;
            this.btn_timeCycleMange.Location = new System.Drawing.Point(599, 15);
            this.btn_timeCycleMange.Name = "btn_timeCycleMange";
            this.btn_timeCycleMange.Size = new System.Drawing.Size(75, 35);
            this.btn_timeCycleMange.TabIndex = 10;
            this.btn_timeCycleMange.Text = "周期管理";
            this.btn_timeCycleMange.UseVisualStyleBackColor = false;
            this.btn_timeCycleMange.Click += new System.EventHandler(this.btn_timeCycleMange_Click);
            // 
            // lbl_indicator
            // 
            this.lbl_indicator.AutoSize = true;
            this.lbl_indicator.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_indicator.Location = new System.Drawing.Point(20, 80);
            this.lbl_indicator.Name = "lbl_indicator";
            this.lbl_indicator.Size = new System.Drawing.Size(76, 20);
            this.lbl_indicator.TabIndex = 9;
            this.lbl_indicator.Text = "评价指标 : ";
            // 
            // lbl_timePeriod
            // 
            this.lbl_timePeriod.AutoSize = true;
            this.lbl_timePeriod.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_timePeriod.Location = new System.Drawing.Point(321, 21);
            this.lbl_timePeriod.Name = "lbl_timePeriod";
            this.lbl_timePeriod.Size = new System.Drawing.Size(62, 20);
            this.lbl_timePeriod.TabIndex = 6;
            this.lbl_timePeriod.Text = "时间段 : ";
            // 
            // combo_timeCycle
            // 
            this.combo_timeCycle.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_timeCycle.FormattingEnabled = true;
            this.combo_timeCycle.Location = new System.Drawing.Point(105, 17);
            this.combo_timeCycle.Name = "combo_timeCycle";
            this.combo_timeCycle.Size = new System.Drawing.Size(200, 31);
            this.combo_timeCycle.TabIndex = 5;
            this.combo_timeCycle.SelectedIndexChanged += new System.EventHandler(this.combo_timeCycle_SelectedIndexChanged);
            // 
            // lbl_timeCycle
            // 
            this.lbl_timeCycle.AutoSize = true;
            this.lbl_timeCycle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_timeCycle.Location = new System.Drawing.Point(20, 23);
            this.lbl_timeCycle.Name = "lbl_timeCycle";
            this.lbl_timeCycle.Size = new System.Drawing.Size(76, 20);
            this.lbl_timeCycle.TabIndex = 2;
            this.lbl_timeCycle.Text = "评级周期 : ";
            // 
            // combo_one
            // 
            this.combo_one.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_one.FormattingEnabled = true;
            this.combo_one.Location = new System.Drawing.Point(105, 74);
            this.combo_one.Name = "combo_one";
            this.combo_one.Size = new System.Drawing.Size(200, 31);
            this.combo_one.TabIndex = 2;
            this.combo_one.SelectedIndexChanged += new System.EventHandler(this.combo_one_SelectedIndexChanged);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_title.Location = new System.Drawing.Point(15, 17);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(65, 20);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "指标数据";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(960, 640);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(960, 459);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TimeCycle,
            this.IndicatorFour,
            this.DataSource,
            this.Remark,
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(940, 439);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // TimeCycle
            // 
            this.TimeCycle.HeaderText = "TimeCycle";
            this.TimeCycle.Name = "TimeCycle";
            this.TimeCycle.Visible = false;
            // 
            // IndicatorFour
            // 
            this.IndicatorFour.HeaderText = "IndicatorFour";
            this.IndicatorFour.Name = "IndicatorFour";
            this.IndicatorFour.Visible = false;
            // 
            // DataSource
            // 
            this.DataSource.HeaderText = "DataSource";
            this.DataSource.Name = "DataSource";
            this.DataSource.Visible = false;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "修改";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EvalutationData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EvalutationData";
            this.Size = new System.Drawing.Size(960, 640);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbl_timeCycle;
        private System.Windows.Forms.ComboBox combo_timeCycle;
        private System.Windows.Forms.Label lbl_timePeriod;
        private System.Windows.Forms.Label lbl_indicator;
        private System.Windows.Forms.Button btn_timeCycleMange;
        private System.Windows.Forms.Label lbl_timePeriods;
        private System.Windows.Forms.Button btn_commit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndicatorFour;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
    }
}
