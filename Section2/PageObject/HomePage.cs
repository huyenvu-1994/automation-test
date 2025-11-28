using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2.PageObject
{
    public class HomePage
    {
        IWebDriver Driver;

        By homepageLogo = By.XPath("//img[@src='/static/images/home/logo.png']");
        By loggedIn = By.XPath("//a[contains(text(),'Logged in as ')]");
        By signupButton = By.XPath("//a[@href='/login']");

        public HomePage(IWebDriver Driver) 
        { 
            this.Driver = Driver;
        }

        public bool IsHomePageDisplayed()
        {
            return Driver.FindElement(homepageLogo).Displayed;
        }

        public void GoToLoginPage()
        {
            Driver.FindElement(signupButton).Click();
        }

        public bool IsLoginIn(string username)
        {
            return Driver.FindElement(loggedIn).Text.Contains("Logged in as " + username);
        }
    }
}
