using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helper.Common
{
     public class ExcelHelper
    {
        public enum ExcelStyle
        {
            Office2003 = 0,
            Office2007AndAbove = 1
        }

        #region 从datatable中将数据导出到excel
        /// <summary>
        /// 导出DataTable到流，此方法包含所有格式。
        /// 2003 最大行数为65535，2007及以上为1048576
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText"></param>
        /// <param name="excellStyle"></param>
        /// <returns></returns>
        public static MemoryStream ExportDt(DataTable dtSource, string strHeaderText, ExcelStyle excellStyle = ExcelStyle.Office2007AndAbove)
        {
            IWorkbook workbook = new XSSFWorkbook();
            if (excellStyle == ExcelStyle.Office2003)
                workbook = new HSSFWorkbook();
            //
            var sheet = workbook.CreateSheet();
            //
            //
            var dateStyle = workbook.CreateCellStyle();
            var format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            //取得列宽
            var arrColWidths = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidths[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName).Length;
            }
            for (var i = 0; i < dtSource.Rows.Count; i++)
            {
                for (var j = 0; j < dtSource.Columns.Count; j++)
                {
                    var intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidths[j])
                    {
                        arrColWidths[j] = intTemp;
                    }
                }
            }
            var rowIndex = 0;
            var maxRows = excellStyle == ExcelStyle.Office2003 ? 65535 : 1048576;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == maxRows || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式

                    {
                        var headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        var headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        var font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;

                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        //headerRow.Dispose();
                    }

                    #endregion


                    #region 列头及样式

                    {
                        var headerRow = sheet.CreateRow(1);


                        var headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        var font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidths[column.Ordinal] + 1) * 256);

                        }
                        //headerRow.Dispose();
                    }

                    #endregion

                    rowIndex = 2;
                }

                #endregion

                #region 填充内容

                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    var newCell = dataRow.CreateCell(column.Ordinal);

                    var drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (IsNumeric(drValue, out result))
                            {

                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            newCell.SetCellValue(drValue);
                            break;

                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle; //格式化显示
                            break;
                        case "System.Boolean": //布尔型
                            bool boolV;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }

                #endregion

                rowIndex++;
            }
            using (var ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                //ms.Position = 0;


                //sheet.Dispose();
                //workbook.Dispose();

                return ms;
            }
        }
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void ExportDTtoExcel2003(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (var ms = ExportDt(dtSource, strHeaderText, ExcelStyle.Office2003))
            {
                using (var fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    var data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }
        /// <summary>
        /// DataTable导出到Excel文件,格式为2007及以上格式
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void ExportDtToExcel(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (var ms = ExportDt(dtSource, strHeaderText))
            {
                using (var fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    var data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }
        #endregion

        #region 从excel中将数据导出到datatable
        /// <summary>读取excel
        /// 默认第一行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName)
        {
            IWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                workbook = WorkbookFactory.Create(file);
            var sheet = workbook.GetSheetAt(0);
            var dt = ImportDt(sheet, 0, true);
            return dt;
        }

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheetName">需要导出的sheet</param>
        /// <param name="headerRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, string sheetName, int headerRowIndex)
        {
            IWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                workbook = WorkbookFactory.Create(file);
            var sheet = workbook.GetSheet(sheetName);
            var table = ImportDt(sheet, headerRowIndex, true);
            return table;
        }

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheetIndex">需要导出的sheet序号</param>
        /// <param name="headerRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, int sheetIndex, int headerRowIndex)
        {
            IWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                workbook = WorkbookFactory.Create(file);
            ISheet sheet = workbook.GetSheetAt(sheetIndex);
            var table = ImportDt(sheet, headerRowIndex, true);
            return table;
        }

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheetName">需要导出的sheet</param>
        /// <param name="headerRowIndex">列头所在行号，-1表示没有列头</param>
        /// <param name="needHeader"></param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, string sheetName, int headerRowIndex, bool needHeader)
        {
            IWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                workbook = WorkbookFactory.Create(file);
            var sheet = workbook.GetSheet(sheetName);
            var table = ImportDt(sheet, headerRowIndex, needHeader);
            return table;
        }

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheetIndex">需要导出的sheet序号</param>
        /// <param name="headerRowIndex">列头所在行号，-1表示没有列头</param>
        /// <param name="needHeader"></param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, int sheetIndex, int headerRowIndex, bool needHeader)
        {
            IWorkbook workbook;
            using (var file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                workbook = WorkbookFactory.Create(file);
            var sheet = workbook.GetSheetAt(sheetIndex);
            var table = ImportDt(sheet, headerRowIndex, needHeader);
            return table;
        }

        /// <summary>
        /// 将指定sheet中的数据导出到datatable中
        /// </summary>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="headerRowIndex">列头所在行号，-1表示没有列头</param>
        /// <param name="needHeader"></param>
        /// <returns></returns>
       public  static DataTable ImportDt(ISheet sheet, int headerRowIndex, bool needHeader)
        {
            var table = new DataTable();
            IRow headerRow;
            int cellCount;
            try
            {
                if (headerRowIndex < 0 || !needHeader)
                {
                    headerRow = sheet.GetRow(0);
                    cellCount = headerRow.LastCellNum;

                    for (int i = headerRow.FirstCellNum; i <= cellCount; i++)
                    {
                        var column = new DataColumn(Convert.ToString(i));
                        table.Columns.Add(column);
                    }
                }
                else
                {
                    headerRow = sheet.GetRow(headerRowIndex);
                    cellCount = headerRow.LastCellNum;

                    for (int i = headerRow.FirstCellNum; i <= cellCount; i++)
                    {
                        if (headerRow.GetCell(i) == null)
                        {
                            if (table.Columns.IndexOf(Convert.ToString(i)) > 0)
                            {
                                var column = new DataColumn(Convert.ToString("重复列名" + i));
                                table.Columns.Add(column);
                            }
                            else
                            {
                                var column = new DataColumn(Convert.ToString(i));
                                table.Columns.Add(column);
                            }

                        }
                        else if (table.Columns.IndexOf(headerRow.GetCell(i).ToString()) > 0)
                        {
                            var column = new DataColumn(Convert.ToString("重复列名" + i));
                            table.Columns.Add(column);
                        }
                        else
                        {
                            var column = new DataColumn(headerRow.GetCell(i).ToString());
                            table.Columns.Add(column);
                        }
                    }
                }
                //var rowCount = sheet.LastRowNum;
                for (var i = (headerRowIndex + 1); i <= sheet.LastRowNum; i++)
                {
                    try
                    {
                        IRow row;
                        row = sheet.GetRow(i) ?? sheet.CreateRow(i);

                        var dataRow = table.NewRow();

                        for (int j = row.FirstCellNum; j <= cellCount; j++)
                        {
                            try
                            {
                                if (row.GetCell(j) != null)
                                {
                                    switch (row.GetCell(j).CellType)
                                    {
                                        case CellType.String:
                                            var str = row.GetCell(j).StringCellValue;
                                            dataRow[j] = !string.IsNullOrEmpty(str) ? str : null;
                                            break;
                                        case CellType.Numeric:
                                            if (DateUtil.IsCellDateFormatted(row.GetCell(j)))
                                                dataRow[j] = DateTime.FromOADate(row.GetCell(j).NumericCellValue);
                                            else
                                                dataRow[j] = Convert.ToDouble(row.GetCell(j).NumericCellValue);
                                            break;
                                        case CellType.Boolean:
                                            dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                                            break;
                                        case CellType.Error:
                                            dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                                            break;
                                        case CellType.Formula:
                                            switch (row.GetCell(j).CachedFormulaResultType)
                                            {
                                                case CellType.String:
                                                    var strFormula = row.GetCell(j).StringCellValue;
                                                    dataRow[j] = !string.IsNullOrEmpty(strFormula)
                                                        ? strFormula
                                                        : null;
                                                    break;
                                                case CellType.Numeric:
                                                    dataRow[j] = Convert.ToString(row.GetCell(j).NumericCellValue);
                                                    break;
                                                case CellType.Boolean:
                                                    dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                                                    break;
                                                case CellType.Error:
                                                    dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                                                    break;
                                                default:
                                                    dataRow[j] = "";
                                                    break;
                                            }
                                            break;
                                        default:
                                            dataRow[j] = "";
                                            break;
                                    }
                                }
                            }
                            catch
                            {
                                //wl.WriteLogs(exception.ToString());
                            }
                        }
                        table.Rows.Add(dataRow);
                    }
                    catch (Exception exception)
                    {
                        //wl.WriteLogs(exception.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                //wl.WriteLogs(exception.ToString());
            }
            return table;
        }
        #endregion

        #region Public Methodes
        public static bool IsNumeric(String message, out double result)
        {
            var rex = new Regex(@"^[-]?\d+[.]?\d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = double.Parse(message);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取Sheet个数
        /// </summary>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        public static int GetSheetCount(string outputFile)
        {
            var count = 0;
            try
            {
                var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);
                var workbook = WorkbookFactory.Create(readfile);
                count = workbook.NumberOfSheets;

            }
            catch
            {
                //wl.WriteLogs(exception.ToString());
            }
            return count;
        }
        /// <summary>
        /// 获取Sheet名称列表
        /// </summary>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        public static IList<string> GetSheetNames(string outputFile)
        {
            IList<string> sheetNameList = new List<string>();
            try
            {
                var readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);
                var workbook = WorkbookFactory.Create(readfile);
                for (var i = 0; i < workbook.NumberOfSheets; i++)
                    sheetNameList.Add(workbook.GetSheetName(i));
            }
            catch (Exception exception)
            {
                //wl.WriteLogs(exception.ToString());
            }
            return sheetNameList;
        }
        #endregion
    }
}
