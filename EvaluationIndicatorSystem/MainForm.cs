using System;
using System.Collections.Generic;
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
        }

        //当前用户
        UserModule currentUser = null;
        //菜单栏
        LeftMenu leftMenu = null;
        //工作面板
        //基本参数
        BasicIndicatorOne basicIndicatorOne = null;
        BasicIndicatorTwo basicIndicatorTwo = null;
        BasicIndicatorThree basicIndicatorThree = null;
        BasicIndicatorFour basicIndicatorFour = null;
        //指标数据
        EvalutationData evalutationData = null;
        //往期评价
        HistoryEvalutation historyEvalutation = null;

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
            AddTabs();
        }

        //用户控件字典
        Dictionary<TabName, UserControl> tabDictionary = null;

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            leftMenu = new LeftMenu();
            leftMenu.Dock = DockStyle.Fill;
            leftMenu.MenuClick += LeftMenu_MenuClick;
            leftMenu.ChangePasswordClick += LeftMenu_ChangePasswordClick;
            leftMenu.LblUserName = currentUser.UserName;
            splitContainer1.Panel1.Controls.Add(leftMenu);

            tabDictionary = new Dictionary<TabName, UserControl>();

            basicIndicatorOne = new BasicIndicatorOne();
            tabDictionary.Add(TabName.BasicIndicatorOne, basicIndicatorOne);
            basicIndicatorTwo = new BasicIndicatorTwo();
            tabDictionary.Add(TabName.BasicIndicatorTwo, basicIndicatorTwo);
            basicIndicatorThree = new BasicIndicatorThree();
            tabDictionary.Add(TabName.BasicIndicatorThree, basicIndicatorThree);
            basicIndicatorFour = new BasicIndicatorFour();
            tabDictionary.Add(TabName.BasicIndicatorFour, basicIndicatorFour);
            evalutationData = new EvalutationData(currentUser);
            tabDictionary.Add(TabName.EvalutationData, evalutationData);
            historyEvalutation = new HistoryEvalutation();
            tabDictionary.Add(TabName.HistoryEvalutation, historyEvalutation);
        }

        private void LeftMenu_ChangePasswordClick(object sender, EventArgs e)
        {
            using (ChangePassword dialog = new ChangePassword(currentUser))
            {                
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    this.Hide();
                    using (UserLogin dialog2 = new UserLogin(true))
                    {
                        if (dialog2.ShowDialog() == DialogResult.OK)
                        {
                            this.Show();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void LeftMenu_MenuClick(object sender, EventArgs e)
        {
            SetActiveTab((TabName)sender);
        }

        /// <summary>
        /// 添加tab页
        /// </summary>
        private void AddTabs()
        {
            foreach(var item in tabDictionary)
            {
                TabPage page = new TabPage();                
                item.Value.Dock = DockStyle.Fill;
                page.Controls.Add(item.Value);
                page.Name = item.Key.ToString();                
                tabControl1.Controls.Add(page);
            }
        }

        /// <summary>
        /// 设置活动tab页
        /// </summary>
        /// <param name="tabName"></param>
        public void SetActiveTab(TabName tabName)
        {
            Control[] controls = tabControl1.Controls.Find(tabName.ToString(), false);
            tabControl1.SelectedIndex = controls[0].TabIndex;
            switch(tabName)
            {
                case TabName.BasicIndicatorOne:
                    basicIndicatorOne.DataRefresh();
                    break;
                case TabName.BasicIndicatorTwo:
                    basicIndicatorTwo.DataRefresh();
                    break;
                case TabName.BasicIndicatorThree:
                    basicIndicatorThree.DataRefresh();
                    break;
                case TabName.BasicIndicatorFour:
                    basicIndicatorFour.DataRefresh();
                    break;
                case TabName.EvalutationData:                    
                    break;
                case TabName.HistoryEvalutation:
                    historyEvalutation.UserRefresh();
                    break;
            }
        }
    }//end of class
}
