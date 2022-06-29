using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GmailAuthorization
{
    class BasePage
    {
        protected IWebDriver webDriver;
        
        private readonly By _emailField = By.XPath("//input[@type='email']");
        private readonly By _continueButton = By.XPath("//div[@id='identifierNext']//button");
        private readonly By _repeatAttemptButton = By.XPath("//div[@id='next']//button");
        public BasePage(IWebDriver webDriver) => this.webDriver = webDriver;

        public void EnterEmail()
        {
            var userInfo = new UserInfo();
            webDriver.FindElement(_emailField).SendKeys(userInfo.Email);
            Thread.Sleep(500);
            webDriver.FindElement(_emailField).SendKeys(Keys.Enter);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(_continueButton));
            Thread.Sleep(500);
            //webDriver.FindElement(_continueButton).Click();
        }
        public void RepeatLoginAttempt()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(_repeatAttemptButton));
            if (webDriver.FindElements(_repeatAttemptButton).Count > 0)
            {
                
                webDriver.FindElement(_repeatAttemptButton).Click();
            }
        }
    }
}
