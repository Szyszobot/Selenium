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
    public class MainP
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

        public void MainPage()
        {
            var methods = new Method(driver);
            string parasoftWeb = "https://www.parasoft.com/";
            string solutions = "//a[normalize-space()='Solutions']";
            string industries = "//a[normalize-space()='Industries']";
            string products = "//a[normalize-space()='Products']";
            string customers = "//a[normalize-space()='Customers']";
            string resources = "//a[normalize-space()='Resources']";
            string s_web = "https://www.parasoft.com/solutions/";
            string i_web = "https://www.parasoft.com/industries/";
            string p_web = "https://www.parasoft.com/products/";
            string c_web = "https://www.parasoft.com/company/notable-clients/";
            string r_web = "https://www.parasoft.com/resources/";



            methods.GoToUrl(parasoftWeb);
            methods.ClickElement(solutions);
            string so_web = driver.Url;
            Assert.AreEqual(so_web, (s_web));

            driver.Navigate().Back();
            methods.ClickElement(industries);
            string in_web = driver.Url;
            Assert.AreEqual(in_web, (i_web));
            driver.Navigate().Back();

            methods.ClickElement(products);
            string pr_web = driver.Url;
            Assert.AreEqual(pr_web, (p_web));

            driver.Navigate().Back();
            methods.ClickElement(customers);
            string cu_web = driver.Url;
            Assert.AreEqual(cu_web, (c_web));

            driver.Navigate().Back();
            methods.ClickElement(resources);
            string re_web = driver.Url;
            Assert.AreEqual(re_web, (r_web));

            driver.Navigate().Back();






        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}