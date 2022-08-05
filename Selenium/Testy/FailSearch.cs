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
    public class NoSearch
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            string pathToExtension = @"C:\Users\jedrzej.szyszka\AppData\Local\Google\Chrome\User Data\Default\Extensions\cjpalhdlnbpafiamejdnhcphjbkeiagm\1.43.0_0";
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--no-experiments");
            options.AddArgument("--disable-translate");
            options.AddArgument("--disable-plugins");
            options.AddArgument("--no-default-browser-check");
            options.AddArgument("--clear-token-service");
            options.AddArgument("--disable-default-apps");
            options.AddArgument("--no-displaying-insecure-content");
            options.AddArgument("load-extension=" + pathToExtension);
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [Test]

        public void FailSearchBar()
        {
            var methods = new Method(driver);
            WebDriverWait W = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string ParasoftElementsUrl = "https://www.parasoft.com/products/";
            string Search = "//span[@class='search-icon']";
            string searchLabel = "//input[@placeholder='Search …']";
            string Text = "asdgwaga";
            string TestText = "Sorry, but nothing matched your search terms. Please try again with some different keywords.";
            string SearchResult = "//section[@class='search-results-sec']";
            




            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Search);
            methods.WaitUntilVisible(searchLabel);

            methods.SendKeysToElement(searchLabel, Text);
            methods.SendKeysToElement(searchLabel, Keys.Enter);

            var NoResults = driver.FindElement(By.XPath(SearchResult)).Text; 
            


            Assert.That(NoResults, Does.Contain(TestText));


            

        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        


    }
}
