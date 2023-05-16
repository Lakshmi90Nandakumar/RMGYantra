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
    [Priority(1)]
    public class ProjectCreateTest:BaseClass
    {
        [TestMethod]
        public void ClickCreateProject()
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
        }
    }
}
