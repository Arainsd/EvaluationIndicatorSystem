using System;
using System.Collections.Generic;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace EvaluationIndicatorSystem
{
    public static class ExcelHelper
    {
        private static List<IndicatorOne> indicators = new List<IndicatorOne>();
        public static List<IndicatorOne> Indicators { get => indicators; set => indicators = value; }

        public static void ReadIndicator()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "/维修质量竞争力指标0729B.xls";
                string sheetName = "完善";
                if (!File.Exists(path)) return;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = null;
                if (Path.GetExtension(path).Equals(".xls"))
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else if (Path.GetExtension(path).Equals(".xlsx"))
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else
                {
                    return;
                }

                if (workbook == null) return;
                ISheet sheet = workbook.GetSheet(sheetName);
                if (sheet == null) return;
                int rowCount = sheet.LastRowNum;

                for (int i = 2; i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    for (int j = 1; j <= 4; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (string.IsNullOrEmpty(cell.StringCellValue)) continue;
                        switch (j)
                        {
                            case 1:
                                IndicatorOne one = new IndicatorOne();
                                one.name = cell.StringCellValue;
                                one.indicatorTwos = new List<IndicatorTwo>();
                                indicators.Add(one);
                                break;
                            case 2:
                                IndicatorTwo two = new IndicatorTwo();
                                two.name = cell.StringCellValue;
                                two.indicatorThrees = new List<IndicatorThree>();
                                indicators.Last().indicatorTwos.Add(two);
                                break;
                            case 3:
                                IndicatorThree three = new IndicatorThree();
                                three.name = cell.StringCellValue;
                                three.indicatorFours = new List<IndicatorFour>();
                                indicators.Last().indicatorTwos.Last().indicatorThrees.Add(three);
                                break;
                            case 4:
                                IndicatorFour four = new IndicatorFour();
                                four.name = cell.StringCellValue;
                                indicators.Last().indicatorTwos.Last().indicatorThrees.Last().indicatorFours.Add(four);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                indicators = null;
            }
        }
    }//end of class
}
