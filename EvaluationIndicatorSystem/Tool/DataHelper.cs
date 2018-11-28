using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public class DataHelper
    {
        public void SetComboItem(Dictionary<int, BasicDataModule> modules, ComboBox combo, int id)
        {
            foreach (var item in modules)
            {
                if (item.Value.ParentId == id)
                {
                    combo.Items.Add(item.Value.Name);
                }
            }
            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }

        public int GetCurrentId(Dictionary<int, BasicDataModule> modules, string parentName)
        {
            int result = -1;
            foreach (var item in modules)
            {
                if (parentName.Equals(item.Value.Name))
                {
                    result = item.Value.ID;
                    break;
                }
            }
            return result;
        }

        public string CheckComboItem(Dictionary<int, BasicDataModule> modules, int level)
        {
            string msg = string.Empty;
            bool hasLevel = false;
            foreach (var item in modules)
            {
                if (item.Value.Level == level)
                {
                    hasLevel = true;
                    break;
                }
            }
            if(!hasLevel)
            {
                switch (level)
                {
                    case 2:
                        msg = "请先添加二级指标";
                        break;
                    case 3:
                        msg = "请先添加三级指标";
                        break;
                }
            }
            return msg;
        }
    }//end of class
}
