using OpenQA.Selenium;
using RMGYantra.Generic;
using RMGYantra.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.MSTest
{
    [TestClass]
    public class CreatePrjTest:BaseClass
    {
        [TestMethod]
        //[Priority(2)]
        [DynamicData(nameof(Data), DynamicDataSourceType.Method)]

        public void CreateProject(string createdBy, string projectname, string status, string teamsize)
        {
            test = report.CreateTest(TestContext.TestName);
            WebDriverUtility wdu = new WebDriverUtility();

            LoginPage page = new LoginPage(driver);
            page.Login();

            WelcomePage welcomePage = new WelcomePage(driver);
            Thread.Sleep(2000);
            welcomePage.ClickProject();

            ProjectPage projectPage = new ProjectPage(driver);

            projectPage.ClickCreateProject();
            Thread.Sleep(3000);

            CreateProjectPage createProject = new CreateProjectPage(driver);
            CSharpUtility cSharpUtility = new CSharpUtility();
            int ran = cSharpUtility.ran();
            string prjName = projectname + ran;
            createProject.CreateProject(createdBy,prjName,status,teamsize);

            Thread.Sleep(2000);
            test.Info("Clicked Create Project Link");
            test.Info("Project details has been added");
            wdu.ExplicitWait(driver, "//tbody//tr//td[2]");
            IReadOnlyCollection<IWebElement> projectNames=driver.FindElements(By.XPath("//tbody//tr//td[2]"));
            try
            {
                bool flag = false;
                foreach( IWebElement projectName in projectNames) 
                {
                    Thread.Sleep(1000);
                    if (projectName.Equals(prjName))
                    {
                        Assert.AreEqual(prjName, projectName);
                        Console.WriteLine("Success");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    test.Pass("test executed Successfully");
                    test.Info(prjName + " Created successfully");
                }
            }
            catch (Exception ex) 
            {
                test.Fail(ex.ToString());
                string screeShotPath=wdu.TakeScreenShot(driver,TestContext.TestName);
                test.AddScreenCaptureFromPath(screenShotPath);
                test.Info(prjName + " Not Created successfully");

            }

        }
        public static IEnumerable<object[]> Data()
        {
            int rowcount = ExcelUtility.MethodLoad("PROJECTDATA");
            for (int i = 1; i <= rowcount; i++)
            {
                yield return new Object[]
                {
                  ExcelUtility.sh.Cell(i,0).ToString(),
                  ExcelUtility.sh.Cell(i,1).ToString(),
                  ExcelUtility.sh.Cell(i,2).ToString(),
                  ExcelUtility.sh.Cell(i,3).ToString()
                };
            }

        }
    }
}
