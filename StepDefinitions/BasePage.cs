using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V128.FedCm;

namespace AmazonTest.StepDefinitions
{
    public class BasePage
    {
        public IWebDriver driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
       
    }
}