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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        BasicParameterSettings basicDialog = null;
        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            basicDialog = new BasicParameterSettings();
        }

        private void btn_basicPara_Click(object sender, EventArgs e)
        {
            basicDialog.ShowDialog();
            
        }
    }//end of class
}
