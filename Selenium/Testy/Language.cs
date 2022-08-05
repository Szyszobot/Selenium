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
    public class Language
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
        public void Germany()
        {
            var methods = new Method(driver);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string ParasoftElementsUrl = "https://www.parasoft.com/products/";

            //variables
            
            //string fullName = "Michal";
            // string email = "mail@mail.com";
            // string currentAddres = "addres";
            // string permanentAddres = "addres";

            // //Xpaths of buttons
            // string TranslatorBtn = "//select[@id='gtranslate_selector']";
            // string submitBtn = "//button[@id='submit']";

            // //Xpaths of TextBoxes
            // string fullNameTxtBox = "//input[@id='userName']";
            // string emailTxtBox = "//input[@id='userEmail']";
            // string currentAddresTxtBox = "//textarea[@id='currentAddress']";
            // string permanentAddresTxtBox = "//textarea[@id='permanentAddress']";

            // //Xpaths for wait
            //// string outputBox = "//div[@id='output']";

            // //Xpaths of results
            // string fullNameResult = "//p[@id='name']";
            // string emailResult = "//p[@id='email']";
            // string currentAddresslNameResult = "//p[@id='currentAddress']";
            // string permanentAddressResult = "//p[@id='permanentAddress']";

            methods.GoToUrl(ParasoftElementsUrl);

            SelectElement Lang = new SelectElement(driver.FindElement(By.Id("gtranslate_selector")));
            Lang.SelectByText("Deutsch");

            //SendKeysToElementByXpath(fullNameTxtBox, fullName);
            //SendKeysToElementByXpath(emailTxtBox, email);
            //SendKeysToElementByXpath(currentAddresTxtBox, currentAddres);
            //(permanentAddresTxtBox, permanentAddres);

            //check if box with results is invisible
            //Assert.IsFalse(driver.FindElement(By.XPath(outputBox)).Displayed, "Box is visible");

            //ClickElementByXpath(submitBtn);
            //WaitUntilVisibleByXpath(outputBox);

            //check if box with results is visible
            //Assert.IsTrue(driver.FindElement(By.XPath(outputBox)).Displayed, "Box is invisible");

            //var firstResult = driver.FindElement(By.XPath(fullNameResult)).Text;
            //var secondResult = driver.FindElement(By.XPath(emailResult)).Text;
            //var thirdResult = driver.FindElement(By.XPath(currentAddresslNameResult)).Text;
            //fourthResult = driver.FindElement(By.XPath(permanentAddressResult)).Text;

            //Assert.That("Name:" + fullName, Is.EqualTo(firstResult));
            //Assert.That("Email:" + email, Is.EqualTo(secondResult));
            //Assert.That("Current Address :" + currentAddres, Is.EqualTo(thirdResult));
            //Assert.That("Permananet Address :" + permanentAddres, Is.EqualTo(fourthResult));
            string URL = driver.Url;
            Assert.AreEqual(URL, "https://de.parasoft.com/products/");
        }

        [Test]

        public void Français()
        {
            var methods = new Method(driver);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string ParasoftElementsUrl = "https://www.parasoft.com/products/";

            methods.GoToUrl(ParasoftElementsUrl);

            SelectElement Lang = new SelectElement(driver.FindElement(By.Id("gtranslate_selector")));
            Lang.SelectByText("Français");
            string URL = driver.Url;
            Assert.AreEqual(URL, "https://fr.parasoft.com/products/");
        }

        [Test]
        public void Español()
        {
            var methods = new Method(driver);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string ParasoftElementsUrl = "https://www.parasoft.com/products/";

            methods.GoToUrl(ParasoftElementsUrl);

            SelectElement Lang = new SelectElement(driver.FindElement(By.Id("gtranslate_selector")));
            Lang.SelectByText("Español");
            string URL = driver.Url;
            Assert.AreEqual(URL, "https://es.parasoft.com/products/");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        
        



    }
}