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
        public MainForm(UserModule user)
        {
            if (user == null)
                return;
            else
                currentUser = user;
            InitializeComponent();
            Init();
        }

        UserModule currentUser = null;
        LeftMenu leftMenu = null;

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            lbl_user.Text = currentUser.UserName;

            leftMenu = new LeftMenu();
            leftMenu.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(leftMenu);
        }
    }//end of class
}
