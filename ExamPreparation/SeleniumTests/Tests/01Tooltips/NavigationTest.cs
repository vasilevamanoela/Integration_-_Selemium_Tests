using ExamPreparation.SeleniumTests.Pages._01Tooltips;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using POMHomework.Tests._01GoogleSearch;

namespace ExamPreparation.SeleniumTests.Tests._02AutomateThePlanet
{
    [TestFixture]
    public class NavigationTest : BaseTest
    {
        private NavigationPage _navigationPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _navigationPage = new NavigationPage(Driver);
            _navigationPage.NavigateTo();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Driver.TakeScreenshot();
            }

            Driver.Quit();
        }

        [Test]
        public void ToolTipsSectionNameDisplayed_When_NavigationToWidgets()
        {
            _navigationPage.NavigationToToolTipsPage();

            _navigationPage.AssertCorrectTitleSection("Tool Tips", _navigationPage.PageHeader);
        }
    }    
}
