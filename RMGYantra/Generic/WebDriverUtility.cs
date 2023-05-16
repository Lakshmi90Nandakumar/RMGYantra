using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.Generic
{
    public class WebDriverUtility
    {
        public void Maximize(IWebDriver driver)
        {

            driver.Manage().Window.Maximize();
        }
        public void ImplicitWait(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void Select(IWebDriver driver, IWebElement element, int index)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);

        }
        public void Select(IWebDriver driver, IWebElement element, string text)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(text);

        }
        public void Select(string value, IWebDriver driver, IWebElement element)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);

        }
        public void SwitchToFrame(IWebDriver driver, int index)
        {

            driver.SwitchTo().Frame(index);
        }
        public void SwitchToFrame(IWebDriver driver, string text)
        {
            driver.SwitchTo().Frame(text);
        }
        public void SwitchToFrame(string id, IWebDriver driver)
        {
            driver.SwitchTo().Frame(id);
        }
        public void AlertAccept(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }
        public void AlertDismiss(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Dismiss();
        }
        public string AlertGetText(IWebDriver driver)
        {
            string text = driver.SwitchTo().Alert().Text;
            return text;
        }
        public void AlertSendValue(IWebDriver driver, string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }
        public string TakeScreenShot(IWebDriver driver, string testName)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            var ss = screenshot.GetScreenshot();
            string screenShotPath = "C:\\Users\\LENOVO\\source\\repos\\RMGYantra\\RMGYantra\\Generic\\ScreenShot\\" + testName + ".png";
            Console.WriteLine(screenShotPath);
            ss.SaveAsFile(screenShotPath, ScreenshotImageFormat.Png);
            return screenShotPath;

        }

    }
}
