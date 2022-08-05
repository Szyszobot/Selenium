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
    public class Search
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

        public void SearchBar()
        {
            WebDriverWait W = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string ParasoftElementsUrl = "https://www.parasoft.com/products/";
            string Search = "//span[@class='search-icon']";
            string searchLabel = "//input[@placeholder='Search …']";
            string Text = "abc";
            string expectedresult = "ABCD";
            string SearchResult = "//section[@class='search-results-sec']";

            




            GoToUrl2(ParasoftElementsUrl);
            ClickElementByXpath2(Search);
            WaitUntilVisibleByXpath2(searchLabel);
            
            SendKeysToElementByXpath2(searchLabel, Text);
            SendKeysToElementByXpath2(searchLabel, Keys.Enter);
            var Result = driver.FindElement(By.XPath(SearchResult)).Text;
            //var NoResults = driver.FindElement(By.XPath(EmptyResults)).Text;


            //List<WebElement> elements = W.Until( ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//section[@class='search-results-sec']//div[@class='content-area'"](.,'" + expectedresult + "')]");
            //// check if there is any matching elements

            //if (elements.
            //{
            // Assert.AreEqual(expectedresult, elements[0].Text);
            //}
            //else
            //{
                //Assert.AreNotEqual(expectedresult, elements[1]);
            Assert.That (Result , Does.Contain(expectedresult).IgnoreCase);
            
            
            //Assert.That(NoResults,Is.EqualTo(EmptyResults));
            
        }
            [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        public void ClickElementByXpath2(string Xpath)
    {
        driver.FindElement(By.XPath(Xpath)).Click();
    }

    public void SendKeysToElementByXpath2(string Xpath, string Keys)
    {
        driver.FindElement(By.XPath(Xpath)).SendKeys(Keys);
    }

    public void WaitUntilVisibleByXpath2(string Xpath)
    {
        WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        w.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
    }

    public void GoToUrl2(string URL)
    {
        driver.Navigate().GoToUrl(URL);
    }

        
    }
}
