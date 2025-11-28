using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Section2.PageObject;
using static System.Net.WebRequestMethods;

namespace Section1
{
    public class MyTest
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var service = ChromeDriverService.CreateDefaultService();
            Driver = new ChromeDriver(service);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver.Url = "https://automationexercise.com/";
        }

        [Test]
        public void Ex1()
        {
            Driver.Url = "https://automationexercise.com/";

            HomePage homePage = new HomePage(Driver);
            Assert.True(homePage.IsHomePageDisplayed());

            homePage.GoToLoginPage();


            LoginPage loginPage = new LoginPage(Driver);
            loginPage.InputAndLogin("huyenvu@gmail.com", "huyenvu");
            Assert.True(loginPage.IsLoginErrorDisplayed("Your email or password is incorrect!"));
        }

        [Test]
        public void Ex2()
        {
            Driver.Url = "https://automationexercise.com/";

            HomePage homePage = new HomePage(Driver);
            Assert.True(homePage.IsHomePageDisplayed());

            homePage.GoToLoginPage();


            LoginPage loginPage = new LoginPage(Driver);
            loginPage.InputAndLogin("huyenvu01@gmail.com", "huyenvu");


            homePage.IsLoginIn("huyen");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();   // correct shutdown
            Driver.Dispose();
        }
    }
}