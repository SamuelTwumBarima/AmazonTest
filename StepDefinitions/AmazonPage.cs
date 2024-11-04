using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Security.Policy;

namespace AmazonTest.StepDefinitions
{
    public class AmazonPage : BasePage
    {
      

        public AmazonPage(IWebDriver driver) : base(driver) { }

        public IWebElement btnSearchIcon => driver.FindElement(By.Id("nav-search-submit-text"));

        public IWebElement btnAcceptCookies => driver.FindElement(By.Id("sp-cc-accept"));

        public IWebElement txtSearchField
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("twotabsearchtextbox")));
            }
        }



        public void OpenUrl(string amazonUrl)
        {
            driver.Navigate().GoToUrl(amazonUrl);
            
        }

        public void SearchForLaptop(string itemName)
        {
            txtSearchField.SendKeys(itemName);
            btnSearchIcon.Click();

            AcceptCookies();

        }

        public void AcceptCookies()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(btnAcceptCookies));

                if (btnAcceptCookies.Displayed)
                {
                    btnAcceptCookies.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Accept Cookies button not found.");
            }
            catch (ElementNotInteractableException)
            {
                Console.WriteLine("Accept Cookies button is not interactable.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Timed out waiting for the Accept Cookies button.");
            }
        }
    }
}