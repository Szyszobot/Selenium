using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selenium.Testy
{
    public class Method
    {

        public readonly IWebDriver _driver;

        public string GetTitle() => _driver.Title;

        public string GetCurrentUrl() => _driver.Url;

        public void SleepInMiliseconds(int miliseconds) => Thread.Sleep(miliseconds);

        public void SleepInSeconds(int miliseconds) => Thread.Sleep(miliseconds * 1000);

        public void SwitchToAnotherTab(int WhichTab) => _driver.SwitchTo().Window(_driver.WindowHandles[WhichTab - 1]);

        public void CloseTab() => _driver.Close();

        public Method(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void MaximizeWindow()
        {
            _driver.Manage().Window.Maximize();
        }

        public void WaitForPage()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        public void WaitForFunctions(int seconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public void GoToUrl(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
        }

        public void ClickElement(string Xpath)
        {
            _driver.FindElement(By.XPath(Xpath)).Click();
        }

        public void ClickElement(By by)
        {
            _driver.FindElement(by).Click();
        }

        public void SendKeysToElement(string Xpath, string Keys)
        {
            _driver.FindElement(By.XPath(Xpath)).SendKeys(Keys);
        }

        public void SendKeysToElement(By by, string Keys)
        {
            _driver.FindElement(by).SendKeys(Keys);
        }

        public void GoBack()
        {
            _driver.Navigate().Back();
        }

        public void GoForward()
        {
            _driver.Navigate().Forward();
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }


        public string GetText(string Xpath) => _driver.FindElement(By.XPath(Xpath)).Text;

        public string GetText(By by) => _driver.FindElement(by).Text;



        public void WaitUntilVisible(string Xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
        }

        public void WaitUntilVisible(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public void WaitUntilElementExists(string Xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementExists(By.XPath(Xpath)));
        }

        public void WaitUntilElementExists(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitUntiElementContains(string Xpath, string text)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath(Xpath), text));
        }

        public void WaitUntiElementContains(By by, string text)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }

        public void ClickWhenItBeClickable(string Xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            Actions builder = new Actions(_driver);
            builder.MoveToElement(element).Click().Build().Perform();
        }
        public void ClickWhenItBeClickable(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(by));
            Actions builder = new Actions(_driver);
            builder.MoveToElement(element).Click().Build().Perform();
        }

        public IWebElement WaitForElementToBeClickable(string xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement moveToButton = _driver.FindElement(By.XPath(xpath));
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(moveToButton));
            return element;
        }

        public IWebElement WaitForElementToBeClickable(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement moveToButton = _driver.FindElement(by);
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(moveToButton));
            return element;
        }

        public void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
        }

        public void MoveToElement(string xpath)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(By.XPath(xpath));
            action.MoveToElement(element).Perform();
        }

        public void MoveToElement(By by)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(by);
            action.MoveToElement(element).Perform();
        }

        public void DoubleClickElement(string xpath)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(By.XPath(xpath));
            action.DoubleClick(element).Perform();
        }

        public void DoubleClickElement(By by)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(by);
            action.DoubleClick(element).Perform();
        }

        public void RightClickElement(string xpath)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(By.XPath(xpath));
            action.ContextClick(element).Perform();
        }
        public void RightClickElement(By by)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(by);
            action.ContextClick(element).Perform();
        }

        public bool IsElementPresent(string Xpath)
        {
            try
            {
                _driver.FindElement(By.XPath(Xpath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementNOTPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        public bool IsElementNOTPresent(string Xpath)
        {
            try
            {
                _driver.FindElement(By.XPath(Xpath));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool CheckFileDownloaded(string filename)
        {
            bool exist = true;
            string Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }

        public IWebElement FindElemnt(string Xpath)
        {
            IWebElement find = _driver.FindElement(By.XPath(Xpath));
            return find;
        }

        public IWebElement FindElemnt(By by)
        {
            IWebElement find = _driver.FindElement(by);
            return find;
        }








        public string UpFirstLetter(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public ChromeOptions SetupOptions()
        {
            string pathToExtension = @"C:\Users\michal.chrzeszczyk\AppData\Local\Google\Chrome\User Data\Default\Extensions\cjpalhdlnbpafiamejdnhcphjbkeiagm\1.43.0_0";
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
            return options;
        }
    }
}