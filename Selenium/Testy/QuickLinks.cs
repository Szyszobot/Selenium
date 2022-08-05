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
    public class Quicklink
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

        public void Quicklinks()
        {
            var methods = new Method(driver);
            
            string ParasoftElementsUrl = "https://www.parasoft.com/products/";
            string Forums_site = "https://forums.parasoft.com/";
            string Marketplace_site = "https://customerportal.parasoft.com/lightningportal/s/marketplace";
            string Partners_site = "https://www.parasoft.com/partners/";
            string Customer_Advocacy_sit = "https://www.parasoft.com/customer-advocacy/";
            string Careers_sit = "https://www.parasoft.com/company/careers/";
            string Try_parasoft_sit = "https://www.parasoft.com/request-a-demo/";
            string Sitemap_site = "https://www.parasoft.com/sitemap/";
            string Company_site = "https://www.parasoft.com/company/";
            string News_Events_site = "https://www.parasoft.com/company/news-events/";
            string Customer_Portal_site = "https://customerportal.parasoft.com/s/";
            string Blog_site = "https://www.parasoft.com/blog/";
            string Support_site = "https://www.parasoft.com/support/";
            string Contact_us_site = "https://www.parasoft.com/contact/";
            string Quick_Forum = "//a[@title='FORUMS']";
            string Quick_Marketplace = "//a[@title='MARKETPLACE']";
            string Quick_Partners = "//li[@id='menu-item-21855']//a[1]";
            string Quick_Customer = "//a[@title='Customer Advocacy']";
            string Quick_Carriers = "//a[@title='Careers']";
            string Quick_Try_Parasoft = "//li[@id='menu-item-12095']//a[1]";
            string Quick_site = "//a[@title='Sitemap']";
            string Quick_Company = "//a[@title='Company']";
            string Quick_News_Events = "//a[@title='News & Events']";
            string Quick_Blog = "//li[@id='menu-item-8998']//a[1]";
            string Quick_Customer_Portal = "//a[@title='CUSTOMER PORTAL']";
            string Quick_Support = "//a[@title='Support']";
            string Quick_Contact = "//a[@title='Contact']";

           

            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Quick_Forum);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string URL = driver.Url;
            Assert.AreEqual(URL, (Forums_site));
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            methods.ClickElement(Quick_Marketplace);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string URL2 = driver.Url;
            Assert.AreEqual(URL2, (Marketplace_site));
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            
            methods.ClickElement(Quick_Partners);
            string URL3 = driver.Url;
            Assert.AreEqual(URL3, (Partners_site));
            driver.Navigate().Back();

            methods.ClickElement(Quick_Customer);

            string URL4 = driver.Url;
            Assert.AreEqual(URL4, (Customer_Advocacy_sit));
            driver.Navigate().Back();


            methods.ClickElement(Quick_Carriers);
            string URL5 = driver.Url;
            Assert.AreEqual(URL5, (Careers_sit));
            driver.Navigate().Back();



            methods.ClickElement(Quick_Try_Parasoft);
            string URL6 = driver.Url;
            Assert.AreEqual(URL6, (Try_parasoft_sit));
            driver.Navigate().Back();



            methods.ClickElement(Quick_site);
            string URL7 = driver.Url;
            Assert.AreEqual(URL7, (Sitemap_site));
            driver.Navigate().Back();



            methods.ClickElement(Quick_Company);
            string URL8 = driver.Url;
            Assert.AreEqual(URL8, (Company_site));
            driver.Navigate().Back();


            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Quick_News_Events);
            
            string URL10 = driver.Url;
            Assert.AreEqual(URL10, (News_Events_site));
            driver.Navigate().Back();


            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Quick_Blog);
            
            string URL11 = driver.Url;
            Assert.AreEqual(URL11, (Blog_site));
            driver.Navigate().Back();


            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Quick_Customer_Portal);
            
            string URL12 = driver.Url;
            Assert.AreEqual(URL12, (Customer_Portal_site));
            driver.Navigate().Back(); ;


            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Quick_Support);
           
            string URL13 = driver.Url;
            Assert.AreEqual(URL13, (Support_site));
            driver.Navigate().Back();


            methods.GoToUrl(ParasoftElementsUrl);
            methods.ClickElement(Quick_Contact);
           
            string URL14 = driver.Url;
            Assert.AreEqual(URL14, (Contact_us_site));
            


        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }




    }
}
