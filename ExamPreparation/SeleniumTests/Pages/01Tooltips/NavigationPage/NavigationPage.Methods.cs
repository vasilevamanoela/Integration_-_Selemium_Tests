using POMHomework.Pages;
using POMHomework.Utilities.Extensions;
using StabilizeTestsDemos.ThirdVersion;

namespace ExamPreparation.SeleniumTests.Pages._01Tooltips
{
    public partial class NavigationPage : BasePage
    {
        public NavigationPage(WebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => "http://demoqa.com/";
       
        public void NavigationToToolTipsPage()
        {
            WidgetsButton.Click();
            WidgetsSideBarMenu.ScrollTo().ToBeVisible().Click();
        }
    }
}
