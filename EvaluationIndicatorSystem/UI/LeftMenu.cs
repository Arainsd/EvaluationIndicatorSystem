using System;
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
    public partial class LeftMenu : UserControl
    {
        public LeftMenu()
        {
            InitializeComponent();
        }
        
        Color hoverColor = Color.FromArgb(63, 81, 112);
        Color defaultColor = Color.FromArgb(51, 66, 91);

        private void LeftMenu_Load(object sender, EventArgs e)
        {            
            AddMenuEvent();
            AddMenuClick(this.splitContainer2.Panel1);
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
                    }
                    container.Panel1.Click += Panel_Click;
                    container.Panel1.Controls[0].Click += Label_Click;
                }
            }
        }

        #region menu click
        void Label_Click(object sender, EventArgs e)
        {
            AddMenuClick(((Label)sender).Parent);
        }

        void Panel_Click(object sender, EventArgs e)
        {
            AddMenuClick(sender);
        }

        private void AddMenuClick(object sender)
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

        #region menu hover
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
        #endregion

        /// <summary>
        /// 工作面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_workSurface_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 一级指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_basic_one_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 二级指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_basic_two_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 三级指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_basic_three_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 四级指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_basic_four_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 数据指标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_indicatorData_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 评价结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_result_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_export_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 账号管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_manage_Click(object sender, EventArgs e)
        {

        }
    }//end of class
}
