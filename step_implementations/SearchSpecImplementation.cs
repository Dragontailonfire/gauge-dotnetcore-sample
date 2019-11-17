using System;
using System.IO;
using Cubereum_automation_project.components;
using Cubereum_automation_project.step_implementations.pages;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cubereum_automation_project.step_implementations
{
    /// <summary>
    /// Contains the direct implementation of the steps in amazon_search.spec file and product_search.cpt file.
    /// </summary>
    public class SearchSpecImplementation
    {
        IWebDriver _webDriver;
        SearchPage _searchPage;
        SearchFilterPage _searchFilterPage;
        SearchResultsPage _searchResultsPage;

        /// <summary>
        /// Navigates to the application under test URL.
        /// </summary>
        [Step("Open amazon site")]
        public void OpenAmazonSite()
        {
            _webDriver = WebDriverManager.Driver;
            string url = Environment.GetEnvironmentVariable("test_url");
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Search for a product. The product name is parametrized and taken from the step.
        /// </summary>
        /// <param name="product"></param>
        [Step("Enter text - <product> in Search field")]
        public void EnterTextInSearchField(string product)
        {
            _searchPage = new SearchPage(_webDriver);
            _searchPage.EnterTextInSearchField(product);
        }

        /// <summary>
        /// Clicks the search button.
        /// </summary>
        [Step("Click search button")]
        public void ClickSearchButton()
        {
            _searchPage = new SearchPage(_webDriver);
            _searchPage.ClickSearchButton();
        }

        /// <summary>
        /// Selects a filter from the panel on the left.
        /// </summary>
        /// <param name="filterValue"></param>
        /// <param name="filterName"></param>
		[Step("Select value - <filterValue> for filter - <filterName>")]
		public void SelectValueForFilter(string filterValue, string filterName)
		{
            _searchFilterPage = new SearchFilterPage(_webDriver);
            _searchFilterPage.SelectValueForFilter(filterValue, filterName);
		}

        /// <summary>
        /// Selects discount value from the panel on the left.
        /// </summary>
        /// <param name="discount"></param>
		[Step("Set discount value as - <discount> %")]
		public void SetDiscountValueAs(string discount)
		{
            _searchFilterPage = new SearchFilterPage(_webDriver);
            _searchFilterPage.SetDiscountValue(discount);
		}

        /// <summary>
        /// Retrives data and store it in DataStore that is provided by Gauge.
        /// </summary>
        /// <param name="DataStoreKey"></param>
		[Step("Retrieve all product name and price and store in DataStore - <DataStoreKey>")]
		public void RetrieveAllProductNameAndPrice(string DataStoreKey)
		{
            _searchResultsPage = new SearchResultsPage(_webDriver);
            _searchResultsPage.RetrieveAllProductNameAndPrice(DataStoreKey);
		}

        /// <summary>
        /// The value stored in the DataStore is taken and written to a csv file.
        /// </summary>
        /// <param name="DataStoreKey"></param>
		[Step("Write product result to file from DataStore - <DataStoreKey>")]
		public void WriteProductResultToFile(string DataStoreKey)
		{
            _searchResultsPage = new SearchResultsPage(_webDriver);
            _searchResultsPage.WriteProductResultToFile(DataStoreKey);
		}

        /// <summary>
        /// The value stored in the DataStore is taken and printed in the final HTML report. 
        /// Same implementation can be used for 3 different possible step description. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="DataStoreKey"></param>
		[Step("Print <index>th product details from DataStore - <DataStoreKey>", 
        "Print <index>st product details from DataStore - <DataStoreKey>",
        "Print <index>nd product details from DataStore - <DataStoreKey>")]
		public void PrintThProductDetailsFromDatastore(string index, string DataStoreKey)
		{
            _searchResultsPage = new SearchResultsPage(_webDriver);
            _searchResultsPage.PrintNThProductDetailsFromDatastore(index, DataStoreKey);
		}
    }
}
