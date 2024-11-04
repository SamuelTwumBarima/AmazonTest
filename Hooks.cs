using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AmazonTest
{
    [Binding]
    public  class Hooks
    {
        // Private field to hold the WebDriver instance
        private IWebDriver _driver;

        // Dependency injection container for registering objects
        private readonly IObjectContainer _objectContainer;

        // Constructor to initialize the Hooks class with IObjectContainer
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        // Method that runs before each scenario to set up WebDriver
        [BeforeScenario()]
        public void BeforeScenario()
        {
            // Initialize a new ChromeDriver instance
            _driver = new ChromeDriver();

            // Maximize the browser window
            _driver.Manage().Window.Maximize();

            // Register the WebDriver instance in the object container for dependency injection
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        // Method that runs after each scenario to tear down WebDriver
        [AfterScenario]
        public void AfterScenario()
        {
            // Check if the WebDriver instance is not null
            if (_driver != null)
            {
                // Quit the WebDriver instance, closing all browser windows and ending the WebDriver session
                _driver.Quit();

                // Dispose of the WebDriver instance to release resources
                _driver.Dispose();
            }
        }
    }
}