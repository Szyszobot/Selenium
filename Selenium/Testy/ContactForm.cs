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
    public class ContactForms
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

        public void ContactForm()
        {
            var methods = new Method(driver);
            WebDriverWait W = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string parasoftElementsUrl = "https://www.parasoft.com/products/";
            string email = "cooperfieldmichael@gmail.com";
            string first_name = "Adam";
            string last_name = "Kowalski";
            string company = "lidl";
            string job_title = "Engineer";
            string comments = "test";
            string phoneNumber = "123456789";

            string email_label = "//input[@id='email-7e18a454-1995-49f5-a907-ddc7be450646']";
            string first_label = "//input[@id='firstname-7e18a454-1995-49f5-a907-ddc7be450646']";
            string last_label = "//input[@id='lastname-7e18a454-1995-49f5-a907-ddc7be450646']";
            string company_label = "//input[@id='company-7e18a454-1995-49f5-a907-ddc7be450646']";
            string job_label = "//input[@id='jobtitle-7e18a454-1995-49f5-a907-ddc7be450646']";
            string comments_label = "//textarea[@id='comments-7e18a454-1995-49f5-a907-ddc7be450646']";
            string Country_label = "//select[@id='country-7e18a454-1995-49f5-a907-ddc7be450646']";
            string phone_label = "//input[@id='phone-7e18a454-1995-49f5-a907-ddc7be450646']";

            string email_error = "//div[@class='hs_email hs-email hs-fieldtype-text field hs-form-field']//label[@class='hs-error-msg'][normalize-space()='Please complete this required field.']";
            string first_error = "//div[@class='hs_firstname hs-firstname hs-fieldtype-text field hs-form-field']//label[@class='hs-error-msg'][normalize-space()='Please complete this required field.']";
            string last_error = "//div[@class='hs_lastname hs-lastname hs-fieldtype-text field hs-form-field']//label[@class='hs-error-msg'][normalize-space()='Please complete this required field.']";
            string company_error = "//div[@class='hs_company hs-company hs-fieldtype-text field hs-form-field']//label[@class='hs-error-msg'][normalize-space()='Please complete this required field.']";
           

            string form_email = "//div[@class='hs_email hs-email hs-fieldtype-text field hs-form-field']//div[@class='input']";
            


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);


            methods.GoToUrl(parasoftElementsUrl);
            methods.ClickElement("//a[normalize-space()='Contact Us']");

            methods.SendKeysToElement(email_label, email);
            methods.SendKeysToElement(first_label, first_name);
            methods.SendKeysToElement(last_label,last_name);
            methods.SendKeysToElement(company_label, company);
            methods.SendKeysToElement(job_label, job_title);
            methods.SendKeysToElement(comments_label, comments);
            methods.SendKeysToElement(phone_label, phoneNumber);
            SelectElement Choose_country = new SelectElement(driver.FindElement(By.XPath(Country_label)));
            Choose_country.SelectByText("Poland");
            var e_results = driver.FindElement(By.XPath(form_email)).Text;
            var l_results = driver.FindElement(By.XPath(email_label)).Text;
            var f_results = driver.FindElement(By.XPath(first_label)).Text;
            var c_results = driver.FindElement(By.XPath(company_label)).Text;
            var j_results = driver.FindElement(By.XPath(job_label)).Text;
            var pn_results = driver.FindElement(By.XPath(phone_label)).Text;
            var co_results = driver.FindElement(By.XPath(comments_label)).Text;
            var country_results = driver.FindElement(By.XPath(Country_label)).Text;


            Assert.That(email, Does.Contain(e_results));
            Assert.That(first_name, Does.Contain(f_results));
            Assert.That(last_name, Does.Contain(l_results));
            Assert.That(company, Does.Contain(c_results));
            Assert.That(job_title, Does.Contain(j_results));
            Assert.That(comments, Does.Contain(co_results));
            Assert.That(phoneNumber, Does.Contain(pn_results));
            Assert.That(country_results, Does.Contain("Poland"));

            bool first_result = methods.IsElementNOTPresent(By.XPath(first_error));
            bool last_result = methods.IsElementNOTPresent(By.XPath(last_error));
            bool company_result = methods.IsElementNOTPresent(By.XPath(company_error));
            bool email_result = methods.IsElementNOTPresent(By.XPath(email_error));
            

            Assert.IsTrue(first_result);
            
            Assert.IsTrue(last_result);
            Assert.IsTrue(company_result);
            Assert.IsTrue(email_result);

        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }





    }
}