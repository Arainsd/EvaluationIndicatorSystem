using System;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqliteHelper.InitDBFile(out string msg);
            if(!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (UserLogin dialog = new UserLogin(false))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(dialog.User));
                }
                else
                {
                    SqliteHelper.CloseDBFile();
                    return;
                }
            }
            SqliteHelper.CloseDBFile();
        }
    }//end of class
}
