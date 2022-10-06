using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FinalTask.Utils
{

    public static class WaiterUtil
    {
        private static ITimeoutConfiguration _timeout = AqualityServices.Get<ITimeoutConfiguration>();
        private static WebDriverWait wait = new WebDriverWait(AqualityServices.Browser.Driver, _timeout.Condition);
        public static void WaitForTextInElement(By locator, string text)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }
    }
}
