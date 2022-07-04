using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAuthorization
{
    internal class StackOverflowBasePage : BasePage
    {

        private readonly By _signUpButtonLocator = By.XPath("//li//a[@class='s-topbar--item s-topbar--item__unset ml4 s-btn s-btn__primary ws-nowrap']");

        public StackOverflowBasePage(IWebDriver webDriver) : base(webDriver)
        {
        }
        public void NavigateToSignUp()
        {
            webDriver.FindElement(_signUpButtonLocator).Click();
        }
    }
}
