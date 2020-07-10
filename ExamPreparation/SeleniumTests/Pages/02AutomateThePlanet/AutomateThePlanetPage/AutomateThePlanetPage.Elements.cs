using OpenQA.Selenium;
using StabilizeTestsDemos.ThirdVersion;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation.SeleniumTests.Pages._02AutomateThePlanet
{
    public partial class AutomateThePlanetPage 
    {
        public WebElement QuickNavigationSection => Driver.FindElement(By.ClassName("tve_ct_title"));

        public List<WebElement> NavigationMainTitles =>
            Driver.FindElements(By.ClassName("tve_ct_level0")).ToList();

        public List<WebElement> NavigationSecondaryTitles =>
            Driver.FindElements(By.ClassName("tve_ct_level1")).ToList();

        public List<WebElement> MainHeaders =>
            Driver.FindElements(By.XPath("//*[@id='tve_flt']//h2")).ToList();

        public List<WebElement> SecondaryHeaders =>
            Driver.FindElements(By.XPath("//*[@id='tve_flt']//h3")).ToList();
    }
}
