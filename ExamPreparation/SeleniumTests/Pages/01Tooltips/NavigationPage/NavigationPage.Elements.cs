using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;

namespace ExamPreparation.SeleniumTests.Pages._01Tooltips
{
    public partial class NavigationPage
    {
        public WebElement WidgetsButton => Driver.FindElement(By.XPath("//*[normalize-space(text())='Widgets']/ancestor::div[contains(@class, 'top-card')]"));

        public WebElement WidgetsSideBarMenu => Driver.FindElement(By.XPath($"//*[normalize-space(text())='Tool Tips']"));

        public WebElement PageHeader => Driver.FindElement(By.ClassName("main-header"));
    }
}
