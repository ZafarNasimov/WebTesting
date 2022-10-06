using FinalTask.API;
using NUnit.Framework;
using FinalTask.PageObjects;
using FinalTask.Models;
using FinalTask.Utils;

namespace FinalTask.Tests
{
    public class Test : BaseTest
    {
        private TestData _testData = JsonUtil.GetTestData(JsonUtil._testJsonString);
        [Test]
        public void Test1()
        {
            MainPO mainPO = new MainPO();
            ProjectPO projectPO = new ProjectPO();
            
            Responses responses = new Responses(ProjectAPI.GetToken(_testData.Variant));
            string _token = responses.GetResponseContent();
            Assert.IsTrue(_token != null);

            BrowserUtil.AddTokenToCookie(_token);
            Assert.IsTrue(mainPO.IsVersionEqual(_testData.Variant));

            mainPO.ClickLabel(_testData.Label);
            responses = new Responses(ProjectAPI.GetListOfTests(_testData.ProjectId));
            TestInfo[] testInfos = JsonUtil.GetTestContent(responses.GetResponseContent());
            Assert.IsTrue(projectPO.IsTestDateDescending(2, 21), "Data is not descending");
            Assert.IsTrue(projectPO.AreTestsCorressponding(testInfos), "Data is not corresponding");

            projectPO.ReturnToHomePage();
            mainPO.ClickAddButton();
            mainPO.SendProjectNameAndSave(_testData.ProjectName);
            //Assert.IsTrue(mainPO.IsProjectSaved(), "Project was not saved");

            mainPO.CloseSavingProjectTab();
            Assert.IsTrue(mainPO.IsAddedTabClosed(), "Added tab is not closed");
            Thread.Sleep(1000);
            Assert.IsTrue(mainPO.IsProjectCreated(_testData.ProjectName), "Project was not created");

            mainPO.ClickCreatedProjectLink();
            responses = new Responses(ProjectAPI.CreateTest(_testData.SID, _testData.ProjectName, _testData.TestName, _testData.MethodName, _testData.Env));
            string testId = responses.GetResponseContent();

            responses = new Responses(ProjectAPI.AttachLogFile(testId, JsonUtil._log));
            string screenshotText = BrowserUtil.GetScreenshotTo64();
            responses = new Responses(ProjectAPI.AttachScreenshot(testId, screenshotText, _testData.ContentType));
            Assert.IsTrue(projectPO.IsTestNameEqual(_testData.TestName), "Test name is not equal to expected");
        }
    }
}