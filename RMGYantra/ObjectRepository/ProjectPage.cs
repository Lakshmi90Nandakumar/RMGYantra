using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.ObjectRepository
{
    public class ProjectPage
    {
        [FindsBy(How = How.XPath, Using = "//span[.='Create Project']")]
        public IWebElement createPrjLnk;
        public ProjectPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public void ClickCreateProject()
        {
            createPrjLnk.Click();
        }
    }
}
