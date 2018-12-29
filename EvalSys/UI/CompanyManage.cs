using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class CompanyManage : UserControl
    {
        public CompanyManage()
        {
            InitializeComponent();
            Init();
        }

        List<UserModule> users = null;

        private void Init()
        {
            DataRefresh();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void DataRefresh()
        {
            dataGridView1.DataSource = new List<UserModule>();
            users = (List<UserModule>)SqliteHelper.Select(TableName.User);            
            if (users != null && users.Count > 0)
            {
                dataGridView1.DataSource = users;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            using (CompanyChange dialog = new CompanyChange())
            {
                dialog.ChangeTitle = "新增单位";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UserModule module = dialog.GetModule;
                    module.PassWord = "admin";
                    SqliteHelper.Insert(TableName.User, module, out string msg);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                   
                    DataRefresh();
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (((DataGridView)sender).CurrentCell.Value.ToString() == "修改")
            {
                RowUpdateClick(sender, e);
            }
            else if (((DataGridView)sender).CurrentCell.Value.ToString() == "删除")
            {
                RowDeleteClick(sender, e);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowUpdateClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = ((DataGridView)sender).CurrentRow.Cells["UserName"].Value.ToString();
            UserModule preModule = null;
            foreach (var item in users)
            {
                if (item.UserName == name)
                {
                    preModule = item;
                    break;
                }
            }
            if (preModule == null)
                return;
            using (CompanyChange dialog = new CompanyChange(preModule))
            {
                dialog.ChangeTitle = "修改单位信息";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UserModule currentUser = dialog.GetModule;
                    currentUser.PassWord = preModule.PassWord;
                    SqliteHelper.Update(TableName.User, 0, currentUser, out string msg);
                    if (string.IsNullOrEmpty(msg))
                    {
                        DataRefresh();
                    }
                    else
                    {
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = ((DataGridView)sender).CurrentRow.Cells["UserName"].Value.ToString();
            if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqliteHelper.Delete(TableName.User, name);
                DataRefresh();
            }
        }
    }//end of class
}
