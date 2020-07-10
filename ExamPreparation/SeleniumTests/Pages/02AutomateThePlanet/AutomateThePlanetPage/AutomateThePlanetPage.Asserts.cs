using NUnit.Framework;
using System.Collections.Generic;

namespace ExamPreparation.SeleniumTests.Pages._02AutomateThePlanet
{
    public partial class AutomateThePlanetPage 
    {
        public void AssertComparisonBothTitles(List<string> quickNavigationTitles, List<string> titles)
        {
            CollectionAssert.AreEqual(quickNavigationTitles, titles);
        }

        public void AssertHeaderDisplayed(int index)
        {
            Assert.IsTrue(MainHeaders[index].Displayed);
        }
    }
}
