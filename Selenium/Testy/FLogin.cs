using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Testy
{
    public class FailLogin
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            string pathToExtension = @"C:\Users\jedrzej.szyszka\AppData\Local\Google\Chrome\User Data\Default\Extensions\cjpalhdlnbpafiamejdnhcphjbkeiagm\1.43.0_0";
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 0); 
            options.AddUserProfilePreference("profile.cookie_controls_mode", 1);
            options.AddArgument("--no-experiments");
            options.AddArgument("--disable-translate");
            options.AddArgument("--disable-plugins");
            options.AddArgument("--no-default-browser-check");
            options.AddArgument("--clear-token-service");
            options.AddArgument("--disable-default-apps");
            options.AddArgument("--no-displaying-insecure-content");
            options.AddArgument("load-extension=" + pathToExtension);
            

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [Test]

        public void SupportLogin()
        {
            var methods = new Method(driver);
            WebDriverWait W = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string ParasoftElementsUrl = "https://www.parasoft.com/products/";
            string Support_button = "//a[normalize-space()='Support']";
            string Support_ticket_b = "//a[normalize-space()='Create a Support Ticket']";
            string Username_Email = "//input[@id='47:2;a']";
            string Password = "//input[@id='59:2;a']";
            string Username = "abcd";
            string password = "1234";
            string login = "//span[@class=' label bBody']";
            string login_xpath = "//div[@class='uiOutputRichText']";

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);


            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Support_button);
            
            
            methods.MoveToElement(Support_ticket_b);
            
            Thread.Sleep(3000);
            methods.ClickElement(Support_ticket_b);
            Thread.Sleep(5000);
            
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            methods.WaitUntilVisible("//input[@id='47:2;a']");
            methods.SendKeysToElement(Username_Email, Username);
            methods.SendKeysToElement(Password, password);
            Thread.Sleep(5000);
            methods.ClickElement(login);
            
            var User_Result = driver.FindElement(By.XPath(Username_Email)).Text;
            var Pass_Result = driver.FindElement(By.XPath(Password)).Text;
            Assert.That(password, Does.Contain(Pass_Result));
            Assert.That(login, Does.Contain(User_Result));
            
            bool result = methods.IsElementPresent(By.XPath(login_xpath));
            Assert.IsTrue(result);

            



        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        


    }
}