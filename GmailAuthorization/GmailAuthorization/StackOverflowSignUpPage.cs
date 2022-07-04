using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAuthorization
{
    internal class StackOverflowSignUpPage : StackOverflowBasePage
    {
        private readonly By _signUpWithGoogle = By.XPath("//button[@data-provider='google']");
        public StackOverflowSignUpPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void SignUpWithGoogle()
        {
            webDriver.FindElement(_signUpWithGoogle).Click();
        }
    }
}
