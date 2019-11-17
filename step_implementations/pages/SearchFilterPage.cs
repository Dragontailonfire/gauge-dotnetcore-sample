using Gauge.CSharp.Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Cubereum_automation_project.step_implementations.pages
{
    /// <summary>
    /// Page object model for the Search filter panel on the left
    /// </summary>
    public class SearchFilterPage 
    {
        IWebDriver _webDriver;

        public SearchFilterPage(IWebDriver webDriver) => _webDriver = webDriver;

        /// <summary>
        /// Clicks the filter identified by XPath. 
        /// </summary>
        /// <param name="filterValue"></param>
        /// <param name="filterName"></param>
        public void SelectValueForFilter(string filterValue, string filterName)
        {
            By identifier = By.XPath("//*[.='" + filterName + "']/../following-sibling::ul//*[.='" + filterValue + "']");
            IWebElement element = _webDriver.FindElement(identifier);
            Actions builder = new Actions(_webDriver);
            builder.MoveToElement(element).Click();
            IAction clickFilter = builder.Build();
            clickFilter.Perform();
            GaugeMessages.WriteMessage(filterName + " filter is selected");
            GaugeScreenshots.Capture();
        }

        /// <summary>
        /// Clicks the discount text identified by XPath
        /// </summary>
        /// <param name="discount"></param>
        public void SetDiscountValue(string discount)
        {
            By identifier = By.XPath("//*[.='" + discount + "% Off or more']/../..");
            IWebElement element = _webDriver.FindElement(identifier);
            Actions builder = new Actions(_webDriver);
            builder.MoveToElement(element).Click();
            IAction clickDiscount = builder.Build();
            clickDiscount.Perform();
            GaugeMessages.WriteMessage(discount + " discount is selected");
            GaugeScreenshots.Capture();
        }
    }
}