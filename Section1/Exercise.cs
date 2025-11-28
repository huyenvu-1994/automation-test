using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace Section1
{
    public class Exercise
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var service = ChromeDriverService.CreateDefaultService();
            Driver = new ChromeDriver(service);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void Ex1()
        {
            Driver.Url = "https://automationexercise.com/";

            IWebElement homepageLogo = Driver.FindElement(By.XPath("//img[@src='/static/images/home/logo.png']"));
            Assert.True(homepageLogo.Displayed);

            IWebElement signupButton = Driver.FindElement(By.XPath("//a[@href='/login']"));
            signupButton.Click();

            IWebElement loginTitle = Driver.FindElement(By.XPath("//h2[text()='Login to your account']"));
            Assert.True(loginTitle.Displayed);

            IWebElement Email = Driver.FindElement(By.XPath("//input[@name='email']"));
            IWebElement Password = Driver.FindElement(By.XPath("//input[@name='password']"));
            IWebElement BtnLogin = Driver.FindElement(By.XPath("//button[text()='Login']"));

            Email.SendKeys("huyenvu@gmail.com");
            Password.SendKeys("Password");
            BtnLogin.Click();

            IWebElement Error = Driver.FindElement(By.XPath("//form[@action='/login']//p"));
            Assert.True(Error.Displayed);
            Assert.True(Error.Text == "Your email or password is incorrect!");
        }

        [Test]
        public void Ex2()
        {
            Driver.Url = "https://automationexercise.com/";

            IWebElement homepageLogo = Driver.FindElement(By.XPath("//img[@src='/static/images/home/logo.png']"));
            Assert.True(homepageLogo.Displayed);

            IWebElement signupButton = Driver.FindElement(By.XPath("//a[@href='/login']"));
            signupButton.Click();

            IWebElement loginTitle = Driver.FindElement(By.XPath("//h2[text()='Login to your account']"));
            Assert.True(loginTitle.Displayed);

            IWebElement Email = Driver.FindElement(By.XPath("//input[@name='email']"));
            IWebElement Password = Driver.FindElement(By.XPath("//input[@name='password']"));
            IWebElement BtnLogin = Driver.FindElement(By.XPath("//button[text()='Login']"));

            Email.SendKeys("huyenvu01@gmail.com");
            Password.SendKeys("huyenvu");
            BtnLogin.Click();

            IWebElement loggedIn = Driver.FindElement(By.XPath("//a[contains(text(),'Logged in as ')]"));
            Assert.True(loggedIn.Displayed);
            Assert.True(loggedIn.Text.Contains("Logged in as huyen"));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();   // correct shutdown
            Driver.Dispose();
        }
    }
}