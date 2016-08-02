using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.IO;

namespace Mallcoo.Web.CMSv2.Util
{
    public static class SheetExtensions
    {
        public static IRow AppendRow(this ISheet sheet)
        {
            return sheet.CreateRow(sheet.LastRowNum);
        }
    }

    public class ExportUtil
    {
        public MemoryStream Export(DataTable table)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet();

            var headerRow = sheet.CreateRow(0);
            foreach (DataColumn column in table.Columns)
            {
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }

            foreach (DataRow row in table.Rows)
            {
                var dataRow = sheet.CreateRow(table.Rows.IndexOf(row) + 1);
                foreach (DataColumn column in table.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
            }

            var memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            return memoryStream;
        }
    }
}