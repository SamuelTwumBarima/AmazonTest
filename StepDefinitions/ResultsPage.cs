using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AmazonTest.StepDefinitions
{
    public class ResultsPage : BasePage
    {
        public ResultsPage(IWebDriver driver) : base(driver) { }

        

        public void SelectPageNumber(int pageNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait until the page selection element is clickable
            IWebElement pageSelection = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.CssSelector($"[aria-label='Go to page {pageNumber}']"))
            );

            pageSelection.Click();
        }

        public void SelectItem(int itemNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait until the item selection element is clickable
            IWebElement itemSelection = wait.Until(
                ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='s-main-slot s-result-list s-search-results sg-row']/div[@data-component-type='s-search-result'][{itemNumber}]//button"))
            );

            itemSelection.Click();
        }

        public string BasketAmount()
        {
            return driver.FindElement(By.Id("nav-cart-count")).Text;
        }
    }
}