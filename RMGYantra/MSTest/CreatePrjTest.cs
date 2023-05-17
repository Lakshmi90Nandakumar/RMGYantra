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

            createProject.CreateProject(createdBy,projectname+ran,status,teamsize);
            Thread.Sleep(2000);
            test.Info("Clicked Create Project Link");
            test.Info("Project details has been added");

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
