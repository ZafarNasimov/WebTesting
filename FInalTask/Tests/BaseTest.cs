using NUnit.Framework;
using Aquality.Selenium.Browsers;
using FinalTask.Models;
using FinalTask.Utils;

namespace FinalTask.Tests
{
    public class BaseTest
    {
        private Browser browser = AqualityServices.Browser;
        private ConfigData _configData = JsonUtil.GetConfigData(JsonUtil._configJsonString);
        [SetUp]
        public void Setup()
        {
            browser.GoTo(_configData.Main_Url);
            browser.Maximize();
            browser.WaitForPageToLoad();
        }

        [TearDown]
        public void Teardown()
        {
            //browser.Quit();
        }
    }
}
