using OpenQA.Selenium;
using POMHomework.Pages;
using StabilizeTestsDemos.ThirdVersion;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation.SeleniumTests.Pages._02AutomateThePlanet
{
    public class NavigationAutomateThePlanet : BasePage
    {
        public NavigationAutomateThePlanet(WebDriver driver) 
            : base(driver)
        {
        }

        public override string Url => "https://www.automatetheplanet.com/";

        public WebElement BlogButton => Driver.FindElement(By.Id("menu-item-6"));

        public List<WebElement> Artikles => 
            Driver.FindElements(By.XPath("//div[@class='so-panel widget widget_categorylist']//article")).ToList();

        public void NavigationToArtikelPage()
        {
            BlogButton.Click();
            Artikles[5].Click();
        }
    }
}
