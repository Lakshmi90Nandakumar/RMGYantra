using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.ObjectRepository
{
    public class WelcomePage
    {
        [FindsBy(How = How.LinkText, Using = "Projects")]
        public IWebElement projectLnk;

        public WelcomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickProject()
        {
            Thread.Sleep(2000);
            projectLnk.Click();
        }
    }
}
