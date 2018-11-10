using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.Util;

namespace EvaluationIndicatorSystem
{
    public static class ExcelHelper
    {
        private static List<IndicatorOne> indicators = null;
        public static List<IndicatorOne> Indicators { get => indicators; set => indicators = value; }

        public static List<IndicatorOne> ReadIndicator()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/维修质量竞争力指标0729B.xls";
            string sheetName = "完善";
            if (!File.Exists(path)) return null;            
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            IWorkbook workbook = null;
            if(Path.GetExtension(path).Equals(".xls"))
            {
                workbook = new HSSFWorkbook(fs);
            } else if(Path.GetExtension(path).Equals(".xlsx"))
            {
                workbook = new XSSFWorkbook(fs);
            }
            else
            {
                return null;
            }

            if (workbook == null) return null;
            ISheet sheet = workbook.GetSheet(sheetName);
            if (sheet == null) return null;
            int rowCount = sheet.LastRowNum;
            int regionsCount = sheet.NumMergedRegions;

            //CellRangeAddress[] cras = new CellRangeAddress[regionsCount];
            //for(int k = 0; k < regionsCount; k++)
            //{
            //    CellRangeAddress cra = sheet.GetMergedRegion(k);
            //    cras[k] = cra;
            //}
            //var cras1 = cras.OrderBy(p => p.FirstRow).ToList();           

            for (int i = 2; i <= rowCount; i++)
            {                                      
                IRow row = sheet.GetRow(i);                           
                if (row == null) continue;                
                for (int j = 1; j <= 4; j++)
                {                    
                    ICell cell = row.GetCell(j);
                    if (cell == null) continue;  
                    switch(j)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            IndicatorFour four = new IndicatorFour();
                            four.name = cell.StringCellValue;
                            break;
                        default:
                            break;
                    }
                }
            }

            return indicators;
        }
    }//end of class
}
