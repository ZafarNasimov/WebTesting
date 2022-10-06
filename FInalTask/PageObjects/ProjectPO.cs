using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using FinalTask.Models;
using FinalTask.Utils;

namespace FinalTask.PageObjects
{
    public class ProjectPO : Form
    {
        private static IElementFactory _elementFactory = AqualityServices.Get<IElementFactory>();

        private readonly ILink _homeLabel = _elementFactory.GetLink(By.XPath("//a[contains(@href,'projects')]"), "Home Link");
        private readonly ILabel _testNameLabel = _elementFactory.GetLabel(By.XPath("//table[@id='allTests']//tr[2]//td[1]"), "Created test name");

        private readonly By _testNameLabelLocator = By.XPath("//table[@id='allTests']//tr[2]//td[1]");

        private string _testsListBegin = "//table[@id='allTests']//tr[";
        private string _testsListEnd = "]//td[4]";

        public ProjectPO() : base(By.XPath("//table[@id='allTests']"), "List of projects")
        {

        }

        public ILabel GetLabel(string loc, string desc)
        {
            return _elementFactory.GetLabel(By.XPath(loc), desc);
        }

        public bool IsTestDateDescending(int startVal, int lastVal)
        {
            DateTime prevDate = DateTime.MaxValue;
            for (int i = startVal; i <= lastVal; i++)
            {                
                DateTime date = Convert.ToDateTime(GetLabel($"{_testsListBegin}{i}{_testsListEnd}", "Test Date").Text);
                if (date > prevDate)
                {
                    return false;
                } 
                prevDate = date;
            }
            return true;
        }

        public bool AreTestsCorressponding(TestInfo[] testInfos)
        {
            var sortedTests = testInfos.OrderByDescending(x => x.StartTime).ToList();
            int j = 0;
            for (int i = 2; i <= 21; i++)
            {
                DateTime date = Convert.ToDateTime(GetLabel($"{_testsListBegin}{i}{_testsListEnd}", "Test Date").Text);
                if (date != sortedTests[j].StartTime)
                {
                    return false;
                }
                j++;
            }
            return true;
        }

        public void ReturnToHomePage()
        {
            _homeLabel.Click();
        }

        public bool IsTestNameEqual(string name)
        {
            WaiterUtil.WaitForTextInElement(_testNameLabelLocator, name);
            return _testNameLabel.Text == name;
        }
    }
}
