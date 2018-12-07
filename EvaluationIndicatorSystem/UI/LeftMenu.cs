using System;
using System.Drawing;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public partial class LeftMenu : UserControl
    {
        public LeftMenu()
        {
            InitializeComponent();
        }
        
        Color hoverColor = Color.FromArgb(63, 81, 112);
        Color defaultColor = Color.FromArgb(51, 66, 91); 
        //用户名
        public string LblUserName { get => lbl_name.Text; set => lbl_name.Text = value; }

        private void LeftMenu_Load(object sender, EventArgs e)
        {            
            AddMenuEvent();
            MenuOneClick(this.splitContainer2.Panel1);
        }

        /// <summary>
        /// 添加菜单事件（悬停、点击）
        /// </summary>
        private void AddMenuEvent()
        {
            ControlCollection panels = this.splitContainer1.Panel2.Controls;
            foreach (Panel item in panels)
            {
                AddMouseHover(item);
                if (item.Controls[0] is SplitContainer)
                {
                    SplitContainer container = (SplitContainer)item.Controls[0];
                    AddMouseHover(container.Panel1);
                    ControlCollection panels2 = container.Panel2.Controls;
                    foreach (Panel item2 in panels2)
                    {
                        AddMouseHover(item2);
                        AddMouseClick(item2);
                    }
                    container.Panel1.Click += Panel_One_Click;
                    container.Panel1.Controls[0].Click += Label_One_Click;
                }
                else
                {
                    AddMouseClick(item);
                }
            }
        }

        #region menu one click
        void Label_One_Click(object sender, EventArgs e)
        {
            MenuOneClick(((Label)sender).Parent);            
        }

        void Panel_One_Click(object sender, EventArgs e)
        {
            MenuOneClick(sender);            
        }

        /// <summary>
        /// 一级菜单单击事件
        /// </summary>
        /// <param name="sender"></param>
        private void MenuOneClick(object sender)
        {
            Panel panel1 = (Panel)sender;
            SplitContainer control2 = (SplitContainer)panel1.GetContainerControl();
            ControlCollection panels = control2.Panel2.Controls;
            int height = 0;
            if (panels[0].Height == 0)
            {
                height = 40;
            }
            else
            {
                height = -40;
            }
            foreach (Panel item in panels)
            {
                item.Height += height;
            }
            control2.Parent.Height += 4 * height;
        }
        #endregion

        /// <summary>
        /// 菜单点击事件handler
        /// </summary>
        public event EventHandler MenuClick;
        #region menu event
        /// <summary>
        /// 菜单添加鼠标悬停事件
        /// </summary>
        /// <param name="item"></param>
        private void AddMouseHover(Panel item)
        {
            item.MouseHover += Panel_MouseHover;
            item.MouseLeave += Panel_MouseLeave;
            if (item.Controls[0] is Label)
            {
                item.Controls[0].MouseHover += Label_MouseHover;
                item.Controls[0].MouseLeave += Label_MouseLeave;
            }
        }

        void Label_MouseHover(object sender, EventArgs e)
        {
            Label label = (Label)sender;            
            label.Parent.BackColor = hoverColor;          
        }

        void Label_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Parent.BackColor = defaultColor;
        }

        void Panel_MouseHover(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = hoverColor;           
        }

        void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = defaultColor;            
        }

        /// <summary>
        /// 菜单添加鼠标点击事件
        /// </summary>
        /// <param name="item"></param>
        private void AddMouseClick(Panel item)
        {
            item.Click += Panel_Click;
            if (item.Controls[0] is Label)
            {
                item.Controls[0].Click += Label_Click;
            }
        }

        void Label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            MenuClickEvent((Panel)label.Parent, e);
        }

        void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            MenuClickEvent(panel, e);
        }

        private void MenuClickEvent(Panel panel, EventArgs e)
        {
            object sender = null;
            switch (panel.Name)
            {
                case "panel_basic_one":
                    sender = TabName.BasicIndicatorOne;
                    break;
                case "panel_basic_two":
                    sender = TabName.BasicIndicatorTwo;
                    break;
                case "panel_basic_three":
                    sender = TabName.BasicIndicatorThree;
                    break;
                case "panel_basic_four":
                    sender = TabName.BasicIndicatorFour;
                    break;
                case "panel_evalutationData":
                    sender = TabName.EvalutationData;
                    break;
                case "panel_historyEvalutation":
                    sender = TabName.HistoryEvalutation;
                    break;
                case "panel_dataStatistics":
                    sender = TabName.DataStatistics;
                    break;
            }
            if (sender == null)
                return;
            MenuClick?.Invoke(sender, e);
        }
        #endregion

        public event EventHandler ChangePasswordClick;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ChangePasswordClick?.Invoke(sender, e);
        }
    }//end of class
}
