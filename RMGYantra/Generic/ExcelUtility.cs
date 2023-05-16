using Bytescout.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.Generic
{
    public class ExcelUtility
    {

        public static Spreadsheet sheet { get; set; }
        public static Worksheet sh { get; set; }

        //generic method to get rowcount from sheet
        public static int Method1(string sheetName)
        {
            string projdata = "C:\\Users\\LENOVO\\source\\repos\\VTigerAutomation\\VTigerAutomation\\Resources\\TestDataLogin.xlsx";
            Spreadsheet sheet = new Spreadsheet();
            sheet.LoadFromFile(projdata);//loading the excel
            int rowcount = sheet.Workbook.Worksheets.ByName(sheetName).UsedRangeRowMax;//getting max row number
            Console.WriteLine(rowcount);
            sh = sheet.Workbook.Worksheets.ByName(sheetName);
            return rowcount;//returning max row number

        }

        //reading single data from excel
        public string FetchingleDataExcel(string sheetName, int row, int col)
        {
            string projdata = "C:\\Users\\LENOVO\\source\\repos\\BankingProjectPrac\\AutomationProject\\Resources\\demodata.xlsx";
            sheet = new Spreadsheet();
            sheet.LoadFromFile(projdata);//loading the excel
            //getting single data from excel sheet
            string data = sheet.Workbook.Worksheets.ByName(sheetName).Cell(row, col).ToString();
            return data;//returning the data
        }
        //getting multiple data from excel
        public static IEnumerable<Object[]> MultipleData()
        {
            string projdata = "C:\\Users\\LENOVO\\source\\repos\\VTigerAutomation\\VTigerAutomation\\Resources\\TestDataLogin.xlsx";
            Spreadsheet sheet = new Spreadsheet();
            sheet.LoadFromFile(projdata);//loading the excel
            int rowcount = sheet.Workbook.Worksheets.ByName("Sheet1").UsedRangeRowMax;
            Console.WriteLine(rowcount);
            Worksheet sh = sheet.Workbook.Worksheets.ByName("Sheet1");
            for (int i = 1; i <= rowcount; i++)

            {
                yield return new Object[]
                {
                  sh.Cell(i,0).ToString(),
                  sh.Cell(i,1).ToString()

                };
            }

        }
    }
}

