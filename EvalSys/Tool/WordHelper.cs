using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NPOI.XWPF.UserModel;
using System.Windows.Forms;

namespace EvalSys
{
    public static class WordHelper
    {
        public static void ExportData(TimeCycleModule timeCycle, List<EvalutationDataModule> data, Dictionary<int, BasicDataModule> basicModules, Dictionary<int, BasicFourModule> fourModules)
        {
            XWPFDocument doc = null;
            FileStream fs = null;
            try
            {
                doc = CreateCover(timeCycle); 
                
                //边距失效，重设
                doc.Document.body.sectPr.pgBorders.top.space = 70;
                doc.Document.body.sectPr.pgBorders.bottom.space = 70;
                doc.Document.body.sectPr.pgBorders.left.space = 80;
                doc.Document.body.sectPr.pgBorders.right.space = 80;
                
                CreateData(doc, data, basicModules, fourModules);                    

                using (fs = File.OpenWrite($"{timeCycle.UserName}-{timeCycle.Name}.docx"))
                {                             
                    doc.Write(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static XWPFDocument CreateCover(TimeCycleModule timeCycle)
        {
            XWPFDocument doc1 = null;
            using (FileStream stream = File.OpenRead("封面.docx"))
            {
                doc1 = new XWPFDocument(stream);
                CreateConverText(doc1.Tables[0].Rows[0].GetCell(1), timeCycle.UserName, 14);
                CreateConverText(doc1.Tables[0].Rows[1].GetCell(1), timeCycle.Name, 14);
                CreateConverText(doc1.Tables[0].Rows[2].GetCell(1), timeCycle.LatestCommitTime.ToString("yyyy-MM-dd"), 14);
                CreateConverText(doc1.Tables[1].Rows[0].GetCell(0), DateTime.Now.ToString("yyyy年MM月dd日"), 22);
            }
            return doc1;
        }

        private static void CreateData(XWPFDocument doc, List<EvalutationDataModule> data, Dictionary<int, BasicDataModule> basicModules, Dictionary<int, BasicFourModule> fourModules)
        {
            int[] currentNum = new int[] { 0, 0, 0 };
            int[] ids = new int[] { -1, -1, -1 };
            int preParentId = -1;
            for (int i = 0; i < data.Count; i++)
            {                
                int parentId = data[i].ParentId;
                if (parentId == preParentId) continue;
                preParentId = parentId;
                List<EvalutationDataModule> currentData = new List<EvalutationDataModule>(data.Where(p => p.ParentId == parentId));
                BasicDataModule three = basicModules[parentId];
                BasicDataModule two = basicModules[three.ParentId];
                BasicDataModule one = basicModules[two.ParentId];
                if (ids[0] != one.ID)
                {
                    ids[0] = one.ID;
                    ids[1] = two.ID;
                    ids[2] = three.ID;
                    currentNum[0]++;
                    currentNum[1] = 1;
                    currentNum[2] = 1;
                    CreateTitle(doc, $"{currentNum[0]} {one.Name}", 1);
                    CreateTitle(doc, $"{currentNum[0]}.{currentNum[1]} {two.Name}", 2);
                    CreateTitle(doc, $"{currentNum[0]}.{currentNum[1]}.{currentNum[2]} {three.Name}", 2);
                }
                else if(ids[1] != two.ID)
                {
                    ids[1] = two.ID;
                    ids[2] = three.ID;
                    currentNum[1]++;
                    currentNum[2] = 1;
                    CreateTitle(doc, $"{currentNum[0]}.{currentNum[1]} {two.Name}", 2);
                    CreateTitle(doc, $"{currentNum[0]}.{currentNum[1]}.{currentNum[2]} {three.Name}", 2);
                } else if(ids[2] != three.ID)
                {
                    ids[2] = three.ID;
                    currentNum[2]++;
                    CreateTitle(doc, $"{currentNum[0]}.{currentNum[1]}.{currentNum[2]} {three.Name}", 2);
                }                
                CreateTable(doc, currentData, fourModules);                               
            }
            doc.Paragraphs.Last().IsPageBreak = false;//分页符最后空白页问题
        }

        private static void CreateTitle(XWPFDocument doc, string title, int titleNum)
        {            
            XWPFParagraph paragraph = null;
            if (doc.Paragraphs.Last().IsPageBreak)//分页符空行问题
            {
                paragraph = doc.Paragraphs.Last();
            }
            else
            {
                paragraph = doc.CreateParagraph();
            }
            //XWPFParagraph paragraph = doc.CreateParagraph();
            paragraph.Alignment = ParagraphAlignment.LEFT;            
            XWPFRun run = paragraph.CreateRun();
            run.SetText(title);
            run.SetFontFamily("宋体", FontCharRange.None);
            run.IsBold = true;
            switch (titleNum)
            {
                case 1:
                    run.FontSize = 22;
                    paragraph.SpacingBefore = 24 * 20;
                    paragraph.SpacingAfter = 24 * 20;                    
                    break;
                case 2:
                    run.FontSize = 18;
                    paragraph.SpacingBefore = 24 * 17;
                    paragraph.SpacingAfter = 24 * 17;
                    break;
                case 3:
                    run.FontSize = 14;
                    paragraph.SpacingBefore = 24 * 15;
                    paragraph.SpacingAfter = 24 * 15;
                    break;
                default:
                    break;
            }
        }

        private static void CreateTable(XWPFDocument doc, List<EvalutationDataModule> data, Dictionary<int, BasicFourModule> fourModules)
        {
            XWPFTable table = doc.CreateTable(data.Count + 1, 5);
            table.SetCellMargins(50, 50, 50, 50);           
            table.SetColumnWidth(0, 256 * 10);
            table.SetColumnWidth(1, 256 * 4);
            table.SetColumnWidth(2, 256 * 10);
            table.SetColumnWidth(3, 256 * 4);
            table.SetColumnWidth(4, 256 * 4);
            CreateText(table.GetRow(0).GetCell(0), "评价内容", true);
            CreateText(table.GetRow(0).GetCell(1), "标准分值", true);
            CreateText(table.GetRow(0).GetCell(2), "评价依据", true);
            CreateText(table.GetRow(0).GetCell(3), "得分", true);
            CreateText(table.GetRow(0).GetCell(4), "附件", true);

            for (int i = 0; i < data.Count; i++)
            {
                CreateText(table.GetRow(i + 1).GetCell(0), fourModules[data[i].IndicatorFour].Name, false);
                CreateText(table.GetRow(i + 1).GetCell(1), fourModules[data[i].IndicatorFour].BasicScore.ToString(), false);
                CreateText(table.GetRow(i + 1).GetCell(2), data[i].Description, false);
                CreateText(table.GetRow(i + 1).GetCell(3), data[i].Grade.ToString(), false);
                string source = string.Join("\r\n", data[i].DataSource);
                if(string.IsNullOrEmpty(source))
                {
                    source = " ";//乱码
                }
                CreateText(table.GetRow(i + 1).GetCell(4), source, false);                
            }

            XWPFParagraph paragraph = doc.CreateParagraph();
            paragraph.IsPageBreak = true;//分页符
        }

        private static void CreateText(XWPFTableCell cell, string text, bool isBold)
        {
            cell.RemoveParagraph(0);
            XWPFParagraph paragraph = cell.AddParagraph();
            paragraph.Alignment = ParagraphAlignment.LEFT;
            XWPFRun run = paragraph.CreateRun();
            run.SetText(text);
            run.SetFontFamily("宋体", FontCharRange.None);
            if (isBold) run.IsBold = true;
            run.FontSize = 11;
        }
        
        private static void CreateConverText(XWPFTableCell cell, string text, int fontSize)
        {
            cell.RemoveParagraph(0);
            XWPFParagraph paragraph = cell.AddParagraph();
            paragraph.Alignment = ParagraphAlignment.CENTER;
            XWPFRun run = paragraph.CreateRun();
            run.SetText(text);
            run.SetFontFamily("黑体", FontCharRange.None);
            run.FontSize = fontSize;
        }
    }//end of class
}
