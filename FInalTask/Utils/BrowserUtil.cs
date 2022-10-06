using Aquality.Selenium.Browsers;
using OpenQA.Selenium;

namespace FinalTask.Utils
{
    public static class BrowserUtil
    {
        private static Browser browser = AqualityServices.Browser;
        public static void AddTokenToCookie(string _token)
        {
            Cookie token = new Cookie("token", _token);
            browser.Driver.Manage().Cookies.AddCookie(token);
            browser.Refresh();
        }

        public static string GetScreenshotTo64()
        {
            return browser.Driver.GetScreenshot().AsBase64EncodedString.ToString();
        }
    }
}
