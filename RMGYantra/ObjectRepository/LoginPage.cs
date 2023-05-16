using OpenQA.Selenium;
using RMGYantra.Generic;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.ObjectRepository
{
   
    public class LoginPage:BaseClass
    {
        [FindsBy(How = How.Id, Using = "usernmae")]
        public IWebElement usernameTxt;

        [FindsBy(How=How.Id,Using = "inputPassword")]
        public IWebElement passwordTxt;

        [FindsBy(How=How.XPath,Using = "//button[@type='submit']")]
        public IWebElement loginBtn;

        ExcelUtility excelUtility=new ExcelUtility();

        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public void Login() 
        {
            // var user = TestContext.Properties["user"].ToString();
            //var password = TestContext.Properties["password"].ToString();
            //  string user = "rmgyantra";
            //string password = "rmgy@9999";
            string user = excelUtility.FetchSingleDataExcel("USERCREDENTIAL", 1, 1);
            string password = excelUtility.FetchSingleDataExcel("USERCREDENTIAL", 1, 2);
            usernameTxt.SendKeys(user);
            passwordTxt.SendKeys(password);
            loginBtn.Click();
           

        }

    }
}
