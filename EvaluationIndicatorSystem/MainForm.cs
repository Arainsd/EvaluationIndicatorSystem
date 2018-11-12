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

        LeftMenu leftMenu = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            leftMenu = new LeftMenu();
            leftMenu.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(leftMenu);
        }
    }//end of class
}
