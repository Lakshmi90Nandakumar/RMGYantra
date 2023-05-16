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
            createdByTxt.SendKeys("Lakshmi");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByName('teamSize').value='5';");
            Thread.Sleep(2000);
            /* var stus=driver.FindElement(By.XPath("//label[text()='Project Status ']/parent::div/descendant::select"));
             Console.WriteLine(stus.TagName);
             SelectElement s=new SelectElement(stus);
             s.SelectByText("Created");*/
            WebDriverUtility wdu = new WebDriverUtility();
            wdu.Select(driver, statusDD, "Created");

            Thread.Sleep(2000);
            submitBtn.Click();
            
        }
        
    }
}
