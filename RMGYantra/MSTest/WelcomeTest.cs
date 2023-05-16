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
    public class WelcomeTest:BaseClass
    {
        [TestMethod]
        public void Welcome() 
        {
            test = report.CreateTest(TestContext.TestName);

            LoginPage page = new LoginPage(driver);
            page.Login();
           
            WelcomePage welcomePage = new WelcomePage(driver);
            Thread.Sleep(2000);
            welcomePage.ClickProject();
            string address=driver.Url;
            Console.WriteLine(address);
            string exp = "projects";
            try
            {
                Assert.IsTrue(address.Contains(exp));
                test.Pass("test Passed");
                test.Log(AventStack.ExtentReports.Status.Info, "Succefully Navigated to Projects page");
            }
            catch (Exception ex) 
            {
            
                test.Fail(ex.ToString());
                Assert.IsTrue(address.Contains(exp));
            }
                
                
        }  
    }
}
