using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class BasicParameterSettings : Form
    {
        public BasicParameterSettings()
        {
            InitializeComponent();
            Init();
        }

        //choose indicator usercontrol
        private ParameterSetting parameterSetting = null;
        //all indicators
        private List<IndicatorOne> indicatorOnes = null;
        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            parameterSetting = new ParameterSetting();
            parameterSetting.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(parameterSetting);
            parameterSetting.SetGrp2Text = "四级指标参数设置";
            indicatorOnes = parameterSetting.IndicatorOnes;
        }
    }//end of class
}
