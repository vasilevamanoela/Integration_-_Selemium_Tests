using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StabilizeTestsDemos.ThirdVersion;
using System;

namespace POMHomework.Utilities.Extensions
{
    public static class ElementExtensions
    {
        public static WebElement ScrollTo(this WebElement element)
        {
            ((IJavaScriptExecutor)element.WrappedDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);

            return element;
        }

        public static WebElement ToBeVisible(this WebElement element)
        {
            var wait = new WebDriverWait(element.WrappedDriver, TimeSpan.FromSeconds(20));
            IWebElement nativeWebElement =
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element.By));

            return element;
        }

        public static string GetCssColor(this WebElement element)
        {
            return element.WrappedElement.GetCssValue("background-color");
        }

        public static string GetProperty(this WebElement element)
        {
            return element.WrappedElement.GetProperty("value");
        }
    }
}
