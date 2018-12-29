using System;
using System.Windows.Forms;

namespace EvalSys
{
    public partial class RemarkEdit : Form
    {
        public RemarkEdit(EvalutationDataModule module)
        {
            InitializeComponent();
            CurrentModule = module;
            Init();
        }

        EvalutationDataModule currentModule = null;
        public EvalutationDataModule CurrentModule { get => currentModule; set => currentModule = value; }

        private void Init()
        {
            this.txt_description.Text = CurrentModule.Description;
            foreach(var item in CurrentModule.DataSource)
            {
                this.listBox_dataSource.Items.Add(item);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            CurrentModule.Description = this.txt_description.Text.Trim();
            currentModule.DataSource = new string[listBox_dataSource.Items.Count];
            for(int i = 0;i < listBox_dataSource.Items.Count;i++)
            {
                currentModule.DataSource[i] = listBox_dataSource.Items[i].ToString();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    string[] fullPath = dialog.FileNames;
                    foreach(var item in fullPath)
                    {
                        if (!this.listBox_dataSource.Items.Contains(item))
                        {
                            this.listBox_dataSource.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int index = this.listBox_dataSource.SelectedIndex;
            if (index == -1) return;
            this.listBox_dataSource.Items.Remove(this.listBox_dataSource.SelectedItem);
        }
    }//end of class
}
