using AventStack.ExtentReports;
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
    public class LoginTest:BaseClass
    {
        [TestMethod]
        public void LognTest()
        {
            test = report.CreateTest(TestContext.TestName);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login();
            test.Log(Status.Info,"Test Executed");
            WelcomePage welcomePage = new WelcomePage(driver);
            welcomePage.ClickProject();
            string title = driver.Title;
            string eTitle = "React App";
            try
            {
                Assert.AreEqual(eTitle, title);
                test.Pass("TestPassed");
            }
            catch (Exception ex)
            {
                test.Fail("TestFailed");
                Assert.AreEqual(eTitle, title);
            }

        }
    }
}
