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
        public void CreateProject(string createdBy, string projectname, string status, string teamsize)
        {
            projectNameTxt.SendKeys(projectname);
            createdByTxt.SendKeys(createdBy);
            Thread.Sleep(2000);
            WebDriverUtility wdu = new WebDriverUtility();
            wdu.Select(driver, statusDD, status);
            int team=Convert.ToInt32(teamsize);
 //          IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            js.ExecuteScript("document.getElementsByName('teamSize').value='"+team+"';");
            Thread.Sleep(2000);
            submitBtn.Click();
            
        }
        

    }
}
