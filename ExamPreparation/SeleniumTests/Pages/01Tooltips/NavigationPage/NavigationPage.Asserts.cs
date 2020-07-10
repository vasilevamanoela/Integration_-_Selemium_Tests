using NUnit.Framework;
using StabilizeTestsDemos.ThirdVersion;

namespace ExamPreparation.SeleniumTests.Pages._01Tooltips
{
    public partial class NavigationPage
    {
        public void AssertCorrectTitleSection(string sectionName, WebElement element)
        {
            Assert.AreEqual(sectionName, element.Text);
        }
    }
}
