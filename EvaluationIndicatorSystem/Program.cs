using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.Run(new BasicParameterSettings());
            //SqliteHelper.InitDBFile();
            //using (FormLogin dialog = new FormLogin())
            //{
            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new MainForm());
            //    }
            //    else
            //    {
            //        SqliteHelper.CloseDBFile();
            //        return;
            //    }
            //}
            //SqliteHelper.CloseDBFile();
        }
    }//end of class
}
