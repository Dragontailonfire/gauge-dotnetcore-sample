using Gauge.CSharp.Lib;
using OpenQA.Selenium;

namespace Cubereum_automation_project.step_implementations.pages
{
    /// <summary>
    /// Page object model for the main Search page.
    /// </summary>
    public class SearchPage 
    {
        IWebDriver _webDriver;

        public SearchPage(IWebDriver webDriver) => _webDriver = webDriver;

        /// <summary>
        /// Enters text in the main search field. Identified using Id
        /// </summary>
        /// <param name="product"></param>
        public void EnterTextInSearchField(string product)
        {
            By identifier = By.Id("twotabsearchtextbox");
            IWebElement element = _webDriver.FindElement(identifier);
            element.Clear();
            element.SendKeys(product);
            GaugeMessages.WriteMessage(product + " entered in Search field");
            GaugeScreenshots.Capture();
        }

        /// <summary>
        /// Clicks the main search button. Identified using XPath.
        /// </summary>
        public void ClickSearchButton()
        {
            By identifier = By.XPath("//*[@value='Go']");
            IWebElement element = _webDriver.FindElement(identifier);
            element.Click();
            GaugeMessages.WriteMessage("Search button is clicked");
            GaugeScreenshots.Capture();
        }
    }
}