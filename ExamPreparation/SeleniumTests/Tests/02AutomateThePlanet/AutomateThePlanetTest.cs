using ExamPreparation.SeleniumTests.Pages._02AutomateThePlanet;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using POMHomework.Tests._01GoogleSearch;

namespace ExamPreparation.SeleniumTests.Tests._02AutomateThePlanet
{
    [TestFixture]
    public class AutomateThePlanetTest : BaseTest
    {
        private NavigationAutomateThePlanet _navigationPage;
        private AutomateThePlanetPage _automateThePlanetPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _navigationPage = new NavigationAutomateThePlanet(Driver);
            _navigationPage.NavigateTo();

            _navigationPage.NavigationToArtikelPage();

            _automateThePlanetPage = new AutomateThePlanetPage(Driver);
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
        public void CompareMainAndSecondaryTitlesWithQuckNavigationTitles_When_NavigateToAutomateThePlanetArtikel()
        {
            _automateThePlanetPage.CompareMainTitlesWithQuickNavigationTitles();
            _automateThePlanetPage.CompareSecondaryTitlesWithQuickNavigationTitles();
        }

        [Test]
        public void VerifyMainAndSecondaryTitles_When_NavigateToAutomateThePlanetArtikel()
        {
            _automateThePlanetPage.VerifyTheMainTitlesTag();
            _automateThePlanetPage.VerifyTheSecondaryTitlesTag();
        }     
    }
}
