using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAuthorization
{
    class ProvidePassword : BasePage
    {
        private readonly By _passwordField = By.XPath("//input[@type='password']");
        private readonly By _continueWithPasswordButton = By.XPath("//div[@id='passwordNext']//button");
        private readonly By _invalidPasswordValidationMessage = By.XPath("//div[@jsname='B34EJ']//span[@jsslot]");
        private readonly string _expectedInvalidPasswordValiationMessage = "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.";
        public ProvidePassword(IWebDriver webDriver) : base(webDriver)
        {
        }
        public void ProvideInvalidPassword()
        {
            var userInfo = new UserInfo();
            webDriver.FindElement(_passwordField).SendKeys(userInfo.InvalidPassword);
            webDriver.FindElement(_continueWithPasswordButton).Click();
        }
        public string ReadPasswordValidationMessage() => webDriver.FindElement(_invalidPasswordValidationMessage).Text;
        public string ReadExpectedInvalidPasswordValiationMessage() => _expectedInvalidPasswordValiationMessage;
        
    }
}
