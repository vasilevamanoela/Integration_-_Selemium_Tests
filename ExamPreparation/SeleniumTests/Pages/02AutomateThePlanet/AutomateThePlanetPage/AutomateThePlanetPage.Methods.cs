using POMHomework.Pages;
using POMHomework.Utilities.Extensions;
using StabilizeTestsDemos.ThirdVersion;
using System.Linq;
using System.Threading;

namespace ExamPreparation.SeleniumTests.Pages._02AutomateThePlanet
{
    public partial class AutomateThePlanetPage : BasePage
    {
        public AutomateThePlanetPage(WebDriver driver)
            : base(driver)
        {
        }

        public void CompareMainTitlesWithQuickNavigationTitles()
        {
            var quickNavigationMainTitles = NavigationMainTitles.Select(t => t.Text).ToList();
            var mainTitles = MainHeaders.Select(t => t.Text).ToList();

            AssertComparisonBothTitles(quickNavigationMainTitles, mainTitles);
        }

        public void CompareSecondaryTitlesWithQuickNavigationTitles()
        {
            var quickNavigationSecondaryTitles = NavigationSecondaryTitles.Select(t => t.Text).ToList();
            var secondaryTitles = NavigationSecondaryTitles.Select(t => t.Text).ToList();

            AssertComparisonBothTitles(quickNavigationSecondaryTitles, secondaryTitles);
        }        

        public void VerifyTheMainTitlesTag()
        {
            for (int i = 0; i < NavigationMainTitles.Count; i++)
            {
                Thread.Sleep(500);
                QuickNavigationSection.ScrollTo();
                NavigationMainTitles[i].ScrollTo();
                Driver.ScrollUp(200);

                NavigationMainTitles[i].Click();

                AssertHeaderDisplayed(i);
            }
        }

        public void VerifyTheSecondaryTitlesTag()
        {
            for (int i = 0; i < NavigationSecondaryTitles.Count; i++)
            {
                Thread.Sleep(500);
                QuickNavigationSection.ScrollTo();
                NavigationSecondaryTitles[i].ScrollTo();
                Driver.ScrollUp(200);

                NavigationSecondaryTitles[i].Click();

                AssertHeaderDisplayed(i);
            }
        }
    }
}
