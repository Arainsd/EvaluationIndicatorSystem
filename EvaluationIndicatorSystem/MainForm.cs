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
        //评价结果
        EvaluationResult evaluationResult = null;
        //数据导出
        DataExport dataExport = null;
        //账号管理
        UserManagement userManagement = null;

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
            lbl_user.Text = currentUser.UserName;

            leftMenu = new LeftMenu();
            leftMenu.Dock = DockStyle.Fill;
            leftMenu.MenuClick += LeftMenu_MenuClick;
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
            evaluationResult = new EvaluationResult();
            tabDictionary.Add(TabName.EvaluationResult, evaluationResult);
            dataExport = new DataExport();
            tabDictionary.Add(TabName.DataExport, dataExport);
            userManagement = new UserManagement();
            tabDictionary.Add(TabName.UserManagement, userManagement);
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
        }
    }//end of class
}
