﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class IndicatorControl : UserControl
    {
        public IndicatorControl()
        {
            InitializeComponent();
        }

        //指标名称
        public string IndicatorName { get => lbl_indicatorName.Text; set => lbl_indicatorName.Text = value; }       

        public event EventHandler<string> UpdateClick;
        private void btn_update_Click(object sender, EventArgs e)
        {
            UpdateClick?.Invoke(sender, this.Name);
        }

        public event EventHandler<string> DeleteClick;
        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteClick?.Invoke(sender, this.Name);
        }

    }//end of class
}
