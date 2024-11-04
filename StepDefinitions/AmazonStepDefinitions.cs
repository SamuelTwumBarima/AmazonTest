using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace AmazonTest.StepDefinitions
{
    [Binding]
    public class AmazonStepDefinitions
    {
        private IWebDriver _driver;
        private ResultsPage resultsPage;
        private AmazonPage amazonPage;

        public AmazonStepDefinitions(IWebDriver driver) 
        {
            _driver = driver;
            amazonPage = new AmazonPage(_driver);
            resultsPage = new ResultsPage(_driver);
        }

       

        [Given(@"I open the amazon website ""([^""]*)""")]
        public void GivenIOpenTheAmazonWebsite(string amazonUrl)
        {
            amazonPage.OpenUrl(amazonUrl);
        }

        [When(@"I search for ""([^""]*)"" on second page")]
        public void WhenISearchForOnSecondPage(string laptop)
        {
            int pageNumber = 2;
            amazonPage.SearchForLaptop(laptop);
            resultsPage.SelectPageNumber(pageNumber);
        }



        [When(@"I add item number (.*) to the basket")]
        public void WhenIAddItemNumberToTheBasket(int itemNumber)
        {
            resultsPage.SelectItem(itemNumber);
        }


        [Then(@"The item should be added to my basket")]
        public void ThenTheItemShouldBeAddedToMyBasket()
        {
            resultsPage.BasketAmount().Should().Be("1","Item 1 should be displayed in basket");
        }


    }
}
