using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;

namespace FinalTask.PageObjects
{
    public class MainPO : Form
    {
        private static IElementFactory _elementFactory = AqualityServices.Get<IElementFactory>();
        private static Browser _browser = AqualityServices.Browser;

        private readonly ILabel _versionTextLabel = _elementFactory.GetLabel(By.XPath("//p[contains(@class,'footer-text')]//span"), "Version Label");
        private readonly IButton _addButton = _elementFactory.GetButton(By.XPath("//a[contains(@href,'addProject')]"), "Add Button");
        private readonly ITextBox _projectName = _elementFactory.GetTextBox(By.XPath("//input[@id='projectName']"), "Project name textbox");
        private readonly IButton _submitButton = _elementFactory.GetButton(By.XPath("//button[@type='submit']"), "Submit button");
        private readonly ILabel _alertSuccessLabel = _elementFactory.GetLabel(By.XPath("//div[contains(@class,'alert-success')]"), "Alert Label");
        private readonly IList<ILabel> _projectNamesList = _elementFactory.FindElements<ILabel>(By.XPath("//a[@class='list-group-item']"), "Project names").ToList();



        private int _createdProjectId = 0;

        public MainPO() : base(By.XPath("//div[@class='list-group']"), "List of projects")
        {

        }

        public bool IsVersionEqual(string version)
        {
            return _versionTextLabel.Text.Contains(version);
        }

        public void ClickLabel(string label)
        {
            for (int i = 0; i < _projectNamesList.Count; i++)
            {
                if (_projectNamesList[i].Text == label)
                {
                    _projectNamesList[i].ClickAndWait();
                    break;
                }
            }
        }

        public void ClickAddButton()
        {
            _addButton.Click();
        }

        public void SendProjectNameAndSave(string name)
        {
            _browser.Tabs().SwitchToTab(1);
            _projectName.SendKeys(name);
            _submitButton.Click();
        }

        public void CloseSavingProjectTab()
        {
            _browser.Tabs().CloseTab();
            _browser.Tabs().SwitchToTab(0);
            _browser.Refresh();
        }

        public bool IsProjectSaved()
        {
            return _alertSuccessLabel.State.IsDisplayed;
        }

        public bool IsAddedTabClosed()
        {
            return _browser.Tabs().TabHandles.Count == 1;
        }

        public bool IsProjectCreated(string name)
        {
            for(int i = 0; i < _projectNamesList.Count; i++)
            {
                if (_projectNamesList[i].Text == name)
                {
                    _createdProjectId = i;
                    return true;
                }    
            }
            return false;
        }

        public void ClickCreatedProjectLink()
        {
            _projectNamesList[_createdProjectId].Click();
        }
    }
}
