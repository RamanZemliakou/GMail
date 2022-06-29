using NHibernate.Engine;
using NUnit.Framework;
using OpenQA.Selenium;
using NHibernate;
using OpenQA.Selenium.Chrome;
using SeleniumUndetectedChromeDriver;
using OpenQA.Selenium.Firefox;

namespace GmailAuthorization
{
    public class Tests
    {
        IWebDriver webDriver;
        public static readonly string Url = "https://gmail.com";
        [SetUp]
        
        public void Setup()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--safebrowsing-enable-enhanced-protection");
            options.AddArgument("--disable-web-security");
            options.AddArgument("--allow-running-insecure-content");
            //options.AddArgument("--disable-blink-features = AutomationControlled");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddUserProfilePreference("safebrowsing.enabled", "true");
            options.AddExcludedArguments("excludeSwitches", "enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", "false");

            //options.AddArguments("--disable-web-security", "--disable-gpu", "--proxy-bypass-list=*", "--proxy-server='direct://'", "--log-level=3", "--hide-scrollbars", "--lang=en-us");
            
            webDriver = new ChromeDriver(options);
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(Url);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)webDriver;
        }

        [Test]
        public void Test1()
        {
            var passwordCheck = new ProvidePassword(webDriver);
            passwordCheck.EnterEmail();
            passwordCheck.RepeatLoginAttempt();
            passwordCheck.EnterEmail();
            passwordCheck.ProvideInvalidPassword();
            var actualMessage = passwordCheck.ReadPasswordValidationMessage();
            var expectedMessage = passwordCheck.ReadExpectedInvalidPasswordValiationMessage();
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}