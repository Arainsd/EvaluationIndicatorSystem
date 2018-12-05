using System;
using System.Collections.Generic;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.Util;
using System.Windows.Forms;

namespace EvaluationIndicatorSystem
{
    public static class ExcelHelper
    {
        public static void ImportData(string path, out string msg)
        {
            msg = "导入成功";
            try
            {
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
                    msg = "错误的文件类型";
                    return;
                }

                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet == null)
                {
                    msg = "无可用工作簿";
                    return;
                }

                int rowCount = sheet.LastRowNum;
                for (int i = 0; i < rowCount; i++)
                {
                    if (i == 0)//用户名
                    {
                    }
                    else if (i == 3)//评价周期
                    {
                    }
                    else if (i > 6)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "导入失败";
            }
        }

        public static void ExportData(TimeCycleModule timeCycle, List<EvalutationDataModule> data, Dictionary<int, BasicDataModule> basicModules, Dictionary<int, BasicFourModule> fourModules)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            try
            {
                workbook = new HSSFWorkbook();
                sheet = workbook.CreateSheet("sheet1");
                ICellStyle titleStyle = SetTitleStyle(workbook);                

                IRow row = sheet.CreateRow(0);
                ICell cell = row.CreateCell(0);
                cell.CellStyle = titleStyle;
                cell.SetCellValue("用户");
                cell = row.CreateCell(1);
                cell.CellStyle = SetDataStyle(workbook);
                cell.SetCellValue(timeCycle.UserName);

                CreateTimeRows(timeCycle, sheet, workbook, titleStyle);
                CreateDataTitleRows(sheet, workbook, titleStyle);
                CreateDataRows(workbook,sheet, data, basicModules, fourModules);

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

                using (fs = File.OpenWrite($"{timeCycle.UserName}-{timeCycle.Name}.xls"))
                {
                    workbook.Write(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CreateTimeRows(TimeCycleModule timeCycle, ISheet sheet, IWorkbook workbook, ICellStyle titleStyle)
        {
            ICellStyle cellStyle = SetDateStyle(workbook);

            IRow row = sheet.CreateRow(2);
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

            row = sheet.CreateRow(3);
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

        private static ICellStyle SetTitleStyle(IWorkbook workbook)
        {
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.Boldweight = (short)FontBoldWeight.Bold;
            style.SetFont(font);
            return style;
        }

        private static ICellStyle SetDateStyle(IWorkbook workbook)
        {
            ICellStyle cellStyle = workbook.CreateCellStyle();
            IDataFormat dataFormat = workbook.CreateDataFormat();
            cellStyle.DataFormat = dataFormat.GetFormat("yyyy-MM-dd");
            return cellStyle;
        }

        private static ICellStyle SetDataStyle(IWorkbook workbook)
        {
            ICellStyle cellStyle = workbook.CreateCellStyle();
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.WrapText = true;
            return cellStyle;
        }

        private static void CreateDataTitleRows(ISheet sheet, IWorkbook workbook, ICellStyle titleStyle)
        {
            IRow row = sheet.CreateRow(5);
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
            sheet.AddMergedRegion(new CellRangeAddress(5, 5, 4, 6));
            cell = row.CreateCell(7);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("数据来源");
            cell = row.CreateCell(8);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("备注");
            cell = row.CreateCell(9);
            cell.CellStyle = titleStyle;
            cell.SetCellValue("得分");

            row = sheet.CreateRow(6);
            cell = row.CreateCell(0);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(5, 6, 0, 0));
            cell = row.CreateCell(1);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(5, 6, 1, 1));
            cell = row.CreateCell(2);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(5, 6, 2, 2));
            cell = row.CreateCell(3);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(5, 6, 3, 3));
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
            sheet.AddMergedRegion(new CellRangeAddress(5, 6, 7, 7));
            cell = row.CreateCell(8);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(5, 6, 8, 8));
            cell = row.CreateCell(9);
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(5, 6, 9, 9));

            row = null;
            cell = null;
        }

        private static void CreateDataRows(IWorkbook workbook, ISheet sheet, List<EvalutationDataModule> data, Dictionary<int, BasicDataModule> basicModules, Dictionary<int, BasicFourModule> fourModules)
        {
            IRow row = null;
            ICell cell = null;
            ICellStyle cellStyle = SetDataStyle(workbook);

            int[] rowIndex = new int[] { 7, 7, 7 };//one first row, two first row, three first row
            int[] ids = new int[] { -1, -1, -1 ,-1};//current one id, current two id, current three id, current four id;

            for (int i = 0; i < data.Count; i++)
            {                
                row = sheet.CreateRow(i + 7);
                
                ids[3] = data[i].IndicatorFour;
                if (ids[2] != -1 && ids[2] != fourModules[ids[3]].ParentId)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex[2], i + 6, 2, 2));
                    rowIndex[2] = i + 7;
                }
                ids[2] = fourModules[ids[3]].ParentId;
                if (ids[1] != -1 && ids[1] != basicModules[ids[2]].ParentId)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex[1], i + 6, 1, 1));
                    rowIndex[1] = i + 7;
                }
                ids[1] = basicModules[ids[2]].ParentId;
                if (ids[0] != -1 && ids[0] != basicModules[ids[1]].ParentId)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex[0], i + 6, 0, 0));
                    rowIndex[0] = i + 7;
                }
                ids[0] = basicModules[ids[1]].ParentId;

                for (int j = 0; j < 10; j++)
                {
                    cell = row.CreateCell(j);
                    cell.CellStyle = cellStyle;
                    switch (j)
                    {
                        case 0:
                            if(i == data.Count -1) sheet.AddMergedRegion(new CellRangeAddress(rowIndex[0], i + 7, 0, 0));
                            cell.SetCellValue($"{basicModules[ids[0]].Name}({basicModules[ids[0]].Grade})");
                            break;
                        case 1:
                            if(i == data.Count -1) sheet.AddMergedRegion(new CellRangeAddress(rowIndex[1], i + 7, 1, 1));
                            cell.SetCellValue($"{basicModules[ids[1]].Name}({basicModules[ids[1]].Grade})");
                            break;
                        case 2:
                            if(i == data.Count -1) sheet.AddMergedRegion(new CellRangeAddress(rowIndex[2], i + 7, 2, 2));
                            cell.SetCellValue($"{basicModules[ids[2]].Name}({basicModules[ids[2]].Grade})");
                            break;
                        case 3:                            
                            cell.SetCellValue(fourModules[data[i].IndicatorFour].Name);
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
                            cell.SetCellValue(string.Join("\r\n", data[i].DataSource));
                            break;
                        case 8:
                            cell.SetCellValue(data[i].Remark);
                            break;
                        case 9:
                            cell.SetCellValue(data[i].Grade);
                            break;
                        default:
                            cell.SetCellValue("");
                            break;
                    }
                }
            }
        }
    }//end of class
}
