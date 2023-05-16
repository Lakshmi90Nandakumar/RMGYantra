using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.PageObjects;
using RMGYantra.Generic;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.ObjectRepository
{
    public class CreateProjectPage:BaseClass
    {

        [FindsBy(How = How.Name, Using = "projectName")]
        public IWebElement projectNameTxt;

        [FindsBy(How = How.Name, Using = "createdBy")]
        public IWebElement createdByTxt;

        [FindsBy(How=How.XPath,Using = "//input[@type='submit']")]
        public IWebElement submitBtn;

        [FindsBy(How=How.XPath,Using = "//label[text()='Project Status ']/parent::div/descendant::select")]
        public IWebElement statusDD;
        
        public CreateProjectPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void CreateProject()
        {
            projectNameTxt.SendKeys("HouseRent");
            createdByTxt.SendKeys("Raja");
            Thread.Sleep(2000);
            WebDriverUtility wdu = new WebDriverUtility();
            wdu.Select(driver, statusDD, "Created");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByName('teamSize').value='5';");
            Thread.Sleep(2000);
            submitBtn.Click();
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
                };
            }

            yield return new object[] { }
        }

    }
}
