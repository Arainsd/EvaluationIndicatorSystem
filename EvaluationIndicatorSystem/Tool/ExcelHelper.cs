using System;
using System.Collections.Generic;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.Util;

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
            catch (Exception ex)
            {
                indicators = null;
            }
        }

        public static void ExportData(TimeCycleModule timeCycle, List<EvalutationDataModule> data)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            try
            {
                workbook = new HSSFWorkbook();
                sheet = workbook.CreateSheet("sheet1");
                ICellStyle titleStyle = SetTitleStyle(workbook);

                CreateTimeRows(timeCycle, sheet, workbook, titleStyle);
                CreateDataTitleRows(sheet, workbook, titleStyle);
                CreateDataRows(sheet, data);

                sheet.SetColumnWidth(0, 35 * 256);
                sheet.SetColumnWidth(1, 35 * 256);
                sheet.SetColumnWidth(2, 35 * 256);
                sheet.SetColumnWidth(3, 35 * 256);
                sheet.SetColumnWidth(4, 35 * 256);
                sheet.SetColumnWidth(5, 35 * 256);
                sheet.SetColumnWidth(6, 35 * 256);
                sheet.SetColumnWidth(7, 35 * 256);
                sheet.SetColumnWidth(8, 35 * 256);
                sheet.SetColumnWidth(9, 35 * 256);

                using (fs = File.OpenWrite($"{timeCycle.Name}.xls"))
                {
                    workbook.Write(fs);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static void CreateTimeRows(TimeCycleModule timeCycle, ISheet sheet, IWorkbook workbook, ICellStyle titleStyle)
        {
            ICellStyle cellStyle = SetDateStyle(workbook);

            IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(0);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("评价周期");
            cell = row.CreateCell(1);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("开始时间");
            cell = row.CreateCell(2);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("截止时间");
            cell = row.CreateCell(3);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("创建时间");
            cell = row.CreateCell(4);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("最近提交时间");

            row = sheet.CreateRow(1);
            cell = row.CreateCell(0);
            cell.SetCellValue(timeCycle.Name);
            cell = row.CreateCell(1);
            cell.CellStyle = cellStyle;
            cell.SetCellValue(timeCycle.StartTime);
            cell = row.CreateCell(2);
            cell.CellStyle = cellStyle;
            cell.SetCellValue(timeCycle.EndTime);
            cell = row.CreateCell(3);
            cell.CellStyle = cellStyle;
            cell.SetCellValue(timeCycle.CreateTime);
            cell = row.CreateCell(4);
            cell.CellStyle = cellStyle;
            cell.SetCellValue(timeCycle.LatestCommitTime);

            row = null;
            cell = null;
            cellStyle = null;
        }

        private static ICellStyle SetDateStyle(IWorkbook workbook)
        {
            ICellStyle cellStyle = workbook.CreateCellStyle();
            IDataFormat dataFormat = workbook.CreateDataFormat();
            cellStyle.DataFormat = dataFormat.GetFormat("yyyy-MM-dd");
            return cellStyle;
        }

        private static void CreateDataTitleRows(ISheet sheet, IWorkbook workbook, ICellStyle titleStyle)
        {
            IRow row = sheet.CreateRow(3);
            ICell cell = null;

            cell = row.CreateCell(0);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("一级指标");
            cell = row.CreateCell(1);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("二级指标");
            cell = row.CreateCell(2);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("三级指标");
            cell = row.CreateCell(3);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("四级指标/评价准则内容");
            cell = row.CreateCell(4);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("评价方式");
            cell = row.CreateCell(5);
            cell.CellStyle = titleStyle;
            cell = row.CreateCell(6);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 3, 4, 6));
            cell = row.CreateCell(7);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("数据来源");
            cell = row.CreateCell(8);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("备注");
            cell = row.CreateCell(9);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("得分");

            row = sheet.CreateRow(4);
            cell = row.CreateCell(0);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 0, 0));
            cell = row.CreateCell(1);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 1, 1));
            cell = row.CreateCell(2);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 2, 2));
            cell = row.CreateCell(3);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 3, 3));
            cell = row.CreateCell(4);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("基础分值");
            cell = row.CreateCell(5);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("扣分");
            cell = row.CreateCell(6);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("加分");
            cell = row.CreateCell(7);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 7, 7));
            cell = row.CreateCell(8);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 8, 8));
            cell = row.CreateCell(9);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 9, 9));

            row = null;
            cell = null;
        }

        private static ICellStyle SetTitleStyle(IWorkbook workbook)
        {
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)FontBoldWeight.Bold;
            style.SetFont(font);
            return style;
        }

        private static void CreateDataRows(ISheet sheet, List<EvalutationDataModule> data)
        {
            IRow row = null;
            ICell cell = null;

            for (int i = 0; i < data.Count; i++)
            {                
                row = sheet.CreateRow(i + 4);
                for (int j = 0; j < 9; j++)
                {
                    cell = row.CreateCell(i);
                    switch (j)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:                            
                            break;
                        case 4:
                            cell.SetCellValue(data[i].BasicRule);
                            break;
                        case 5:
                            cell.SetCellValue(data[i].BasicSub);
                            break;
                        case 6:
                            cell.SetCellValue(data[i].BasicAdd);
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;

                    }
                }
            }
        }
    }//end of class
}
