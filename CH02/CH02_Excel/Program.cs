namespace CH02_Excel
{
    using System;
    using Excel = Microsoft.Office.Interop.Excel;

    class Program
    {
        static void Main(string[] args)
        {
            var excel = new Excel.Application();
            var workbook = excel.Workbooks.Open("C:\\Temp\\mysheet.xlsx");
            var worksheet = excel.ActiveSheet as Excel.Worksheet;
            
            Excel.Range userRange = worksheet.UsedRange;
            int countRecords = userRange.Rows.Count;
            int add = countRecords + 1;
            worksheet.Cells[add, 1] = $"Total Rows: {countRecords}";

            workbook.Close(true, Type.Missing, Type.Missing);
            excel.Quit();
        }
    }
}
