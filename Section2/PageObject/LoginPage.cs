using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2.PageObject
{
    public class LoginPage
    {
        IWebDriver Driver;

        By Email =  By.XPath("//input[@name='email']");
        By Password = By.XPath("//input[@name='password']");
        By BtnLogin = By.XPath("//button[text()='Login']");
        By LoginError = By.XPath("//form[@action='/login']//p");
        By loginTitle = By.XPath("//h2[text()='Login to your account']");

        public LoginPage(IWebDriver Driver) 
        { 
            this.Driver = Driver;
        }

        public bool IsLoginPageDisplayed()
        {
            return Driver.FindElement(loginTitle).Displayed;
        }

        public bool IsLoginErrorDisplayed(string error)
        {
            IWebElement loginError = Driver.FindElement(LoginError);
            return loginError.Displayed && loginError.Text.Equals(error);
        }

        public void InputAndLogin(string username, string password)
        {
            Driver.FindElement(Email).SendKeys(username);
            Driver.FindElement(Password).SendKeys(password);
            Driver.FindElement(BtnLogin).Click();
        }
    }
}
