﻿namespace EvaluationIndicatorSystem
{
    partial class HistoryEvalutation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.combo_three = new System.Windows.Forms.ComboBox();
            this.combo_two = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_user = new System.Windows.Forms.Label();
            this.combo_user = new System.Windows.Forms.ComboBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.lbl_timePeriods = new System.Windows.Forms.Label();
            this.lbl_indicator = new System.Windows.Forms.Label();
            this.lbl_timePeriod = new System.Windows.Forms.Label();
            this.combo_timeCycle = new System.Windows.Forms.ComboBox();
            this.lbl_timeCycle = new System.Windows.Forms.Label();
            this.combo_one = new System.Windows.Forms.ComboBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listBox_remark = new System.Windows.Forms.ListBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_three
            // 
            this.combo_three.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_three.FormattingEnabled = true;
            this.combo_three.Location = new System.Drawing.Point(535, 74);
            this.combo_three.Name = "combo_three";
            this.combo_three.Size = new System.Drawing.Size(200, 31);
            this.combo_three.TabIndex = 4;
            this.combo_three.SelectedIndexChanged += new System.EventHandler(this.combo_three_SelectedIndexChanged);
            // 
            // combo_two
            // 
            this.combo_two.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_two.FormattingEnabled = true;
            this.combo_two.Location = new System.Drawing.Point(310, 74);
            this.combo_two.Name = "combo_two";
            this.combo_two.Size = new System.Drawing.Size(200, 31);
            this.combo_two.TabIndex = 3;
            this.combo_two.SelectedIndexChanged += new System.EventHandler(this.combo_two_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.lbl_user);
            this.panel1.Controls.Add(this.combo_user);
            this.panel1.Controls.Add(this.btn_import);
            this.panel1.Controls.Add(this.btn_export);
            this.panel1.Controls.Add(this.lbl_timePeriods);
            this.panel1.Controls.Add(this.lbl_indicator);
            this.panel1.Controls.Add(this.lbl_timePeriod);
            this.panel1.Controls.Add(this.combo_timeCycle);
            this.panel1.Controls.Add(this.lbl_timeCycle);
            this.panel1.Controls.Add(this.combo_three);
            this.panel1.Controls.Add(this.combo_two);
            this.panel1.Controls.Add(this.combo_one);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 120);
            this.panel1.TabIndex = 0;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_user.Location = new System.Drawing.Point(5, 25);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(48, 20);
            this.lbl_user.TabIndex = 18;
            this.lbl_user.Text = "用户 : ";
            // 
            // combo_user
            // 
            this.combo_user.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_user.FormattingEnabled = true;
            this.combo_user.Location = new System.Drawing.Point(87, 19);
            this.combo_user.Name = "combo_user";
            this.combo_user.Size = new System.Drawing.Size(200, 31);
            this.combo_user.TabIndex = 17;
            this.combo_user.SelectedIndexChanged += new System.EventHandler(this.combo_user_SelectedIndexChanged);
            // 
            // btn_import
            // 
            this.btn_import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_import.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_import.FlatAppearance.BorderSize = 0;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.ForeColor = System.Drawing.Color.White;
            this.btn_import.Location = new System.Drawing.Point(755, 72);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 35);
            this.btn_import.TabIndex = 16;
            this.btn_import.Text = "导入";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_export.FlatAppearance.BorderSize = 0;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.ForeColor = System.Drawing.Color.White;
            this.btn_export.Location = new System.Drawing.Point(850, 72);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 35);
            this.btn_export.TabIndex = 15;
            this.btn_export.Text = "导出";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // lbl_timePeriods
            // 
            this.lbl_timePeriods.AutoSize = true;
            this.lbl_timePeriods.Location = new System.Drawing.Point(668, 25);
            this.lbl_timePeriods.Name = "lbl_timePeriods";
            this.lbl_timePeriods.Size = new System.Drawing.Size(0, 20);
            this.lbl_timePeriods.TabIndex = 14;
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
            // lbl_timePeriod
            // 
            this.lbl_timePeriod.AutoSize = true;
            this.lbl_timePeriod.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_timePeriod.Location = new System.Drawing.Point(600, 25);
            this.lbl_timePeriod.Name = "lbl_timePeriod";
            this.lbl_timePeriod.Size = new System.Drawing.Size(62, 20);
            this.lbl_timePeriod.TabIndex = 6;
            this.lbl_timePeriod.Text = "时间段 : ";
            // 
            // combo_timeCycle
            // 
            this.combo_timeCycle.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_timeCycle.FormattingEnabled = true;
            this.combo_timeCycle.Location = new System.Drawing.Point(387, 19);
            this.combo_timeCycle.Name = "combo_timeCycle";
            this.combo_timeCycle.Size = new System.Drawing.Size(200, 31);
            this.combo_timeCycle.TabIndex = 5;
            this.combo_timeCycle.SelectedIndexChanged += new System.EventHandler(this.combo_timeCycle_SelectedIndexChanged);
            // 
            // lbl_timeCycle
            // 
            this.lbl_timeCycle.AutoSize = true;
            this.lbl_timeCycle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbl_timeCycle.Location = new System.Drawing.Point(305, 25);
            this.lbl_timeCycle.Name = "lbl_timeCycle";
            this.lbl_timeCycle.Size = new System.Drawing.Size(76, 20);
            this.lbl_timeCycle.TabIndex = 2;
            this.lbl_timeCycle.Text = "评级周期 : ";
            // 
            // combo_one
            // 
            this.combo_one.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.combo_one.FormattingEnabled = true;
            this.combo_one.Location = new System.Drawing.Point(87, 74);
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
            this.lbl_title.Text = "往期评价";
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
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(960, 640);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.ID,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Operate});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 130);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(940, 339);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "评价准则内容";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BasicRule";
            this.Column2.HeaderText = "基础分值";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BasicSub";
            this.Column3.HeaderText = "扣分";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BasicAdd";
            this.Column4.HeaderText = "加分";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "StrCalModules";
            this.Column5.HeaderText = "计算模型";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Grade";
            this.Column6.HeaderText = "得分";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TimeCycle";
            this.Column8.HeaderText = "TimeCycle";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "IndicatorFour";
            this.Column9.HeaderText = "IndicatorFour";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "DataSource";
            this.Column10.HeaderText = "DataSource";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Remark";
            this.Column11.HeaderText = "Remark";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "ParentId";
            this.Column12.HeaderText = "ParentId";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "CalModules";
            this.Column13.HeaderText = "CalModules";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // Operate
            // 
            this.Operate.DataPropertyName = "Operate";
            this.Operate.HeaderText = "附件";
            this.Operate.Name = "Operate";
            this.Operate.ReadOnly = true;
            this.Operate.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listBox_remark);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 469);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(940, 100);
            this.panel3.TabIndex = 2;
            // 
            // listBox_remark
            // 
            this.listBox_remark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_remark.FormattingEnabled = true;
            this.listBox_remark.ItemHeight = 19;
            this.listBox_remark.Location = new System.Drawing.Point(0, 0);
            this.listBox_remark.Name = "listBox_remark";
            this.listBox_remark.Size = new System.Drawing.Size(940, 100);
            this.listBox_remark.TabIndex = 0;
            this.listBox_remark.DoubleClick += new System.EventHandler(this.listBox_remark_DoubleClick);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(850, 17);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 35);
            this.btn_delete.TabIndex = 19;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // HistoryEvalutation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HistoryEvalutation";
            this.Size = new System.Drawing.Size(960, 640);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbl_timePeriods;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.ComboBox combo_user;
        private System.Windows.Forms.Button btn_delete;
    }
}