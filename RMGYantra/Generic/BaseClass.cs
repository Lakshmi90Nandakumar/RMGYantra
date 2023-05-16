using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.Generic
{
    [TestClass]
    public class BaseClass
    {
        public IWebDriver driver;
        public ExtentTest test;
        public string screenShotPath = "C:\\Users\\LENOVO\\source\\repos\\RMGYantra\\RMGYantra\\Generic\\ScreenShot\\";
        public static ExtentReports report;
        public static ExtentHtmlReporter htmlReport;
        public static string reportPath="C:\\Users\\LENOVO\\source\\repos\\RMGYantra\\RMGYantra\\Generic\\Reports\\report.html";
        WebDriverUtility webDriverUtility=new WebDriverUtility();
        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
           
            htmlReport = new ExtentHtmlReporter(reportPath);//creating path to the htmlreport
            report = new ExtentReports();//initializing the extendreport
            htmlReport.Start();
            report.AttachReporter(htmlReport);//attaching htmlreport to the extend report
           
        }
        [TestInitialize]
        public void TestInit() 
        {
            driver = new ChromeDriver();
            //var url=TestContext.Properties["URL"].ToString();
            //driver.Url =url; 
            ExcelUtility eu=new ExcelUtility();
            driver.Url = eu.FetchSingleDataExcel("USERCREDENTIAL",1,0);
            webDriverUtility.Maximize(driver);
            webDriverUtility.ImplicitWait(driver);                  
        }
        [TestCleanup]
        public void Cleanup() 
        {
            //test.Log(test.Status);
            var res = test.Status;
            if (res.Equals(Status.Fail))
            {
                test.Fail("Test Failed");
                webDriverUtility.TakeScreenShot(driver, TestContext.TestName);
                test.AddScreenCaptureFromPath(screenShotPath, "Failed");
                test.Log(Status.Info, "--->Test Failed");
                Console.WriteLine("Test Failed");

            }
            else
            {
                test.Pass("Test Passed");
                test.Log(Status.Pass, "--->Test Passed");
               // test.Log(test.Status);
                Console.WriteLine(test.Status);
                Console.WriteLine("Test Passed");
            }

            driver.Close();

        }
        [AssemblyCleanup]
        public static void AssemblyCleanup() 
        {
            report.Flush();
            htmlReport.Stop();
                    
        }
      
    }
}
