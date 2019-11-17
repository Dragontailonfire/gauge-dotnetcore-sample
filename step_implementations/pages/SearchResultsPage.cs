using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Cubereum_automation_project.components;
using Gauge.CSharp.Lib;
using OpenQA.Selenium;

namespace Cubereum_automation_project.step_implementations.pages
{
    /// <summary>
    /// Page object model for the Search results page.
    /// </summary>
    public class SearchResultsPage
    {
        IWebDriver _webDriver;

        public SearchResultsPage(IWebDriver webDriver) => _webDriver = webDriver;

        /// <summary>
        /// Identifies all the listed product name and price, stores it in Product class and stores it in ScenarioDataStore.
        /// </summary>
        /// <param name="key"></param>
        public void RetrieveAllProductNameAndPrice(string key)
        {
            By nameIdentifier = By.XPath("//*[@class='a-size-base-plus a-color-base']");
            IList<IWebElement> allNames = _webDriver.FindElements(nameIdentifier);
            By priceIdentifier = By.XPath("//*[@class='a-price-whole']");
            IList<IWebElement> allPrices = _webDriver.FindElements(priceIdentifier);
            List<Product> products = new List<Product>();
            for (var i = 0; i < allNames.Count; i++)
            {
                string productName = allNames[i].GetAttribute("innerText");
                string productPrice = allPrices[i].GetAttribute("innerText");
                products.Add(new Product { ProductName = productName, Price = productPrice });
            }
            var scenarioStore = DataStoreFactory.ScenarioDataStore;
            scenarioStore.Add(key, products);
            GaugeMessages.WriteMessage("Search results captured in DataStore with key - " + key);
            GaugeScreenshots.Capture();
        }

        /// <summary>
        /// Takes the product details stored in the ScenarioDataStore and prints it to a csv file.
        /// </summary>
        /// <param name="key"></param>
        public void WriteProductResultToFile(string key)
        {
            var scenarioStore = DataStoreFactory.ScenarioDataStore;
            List<Product> data = (List<Product>)scenarioStore.Get(key);
            string path = Directory.GetCurrentDirectory() + Environment.GetEnvironmentVariable("results_folder");
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(data);
            }
            GaugeMessages.WriteMessage("Data written to file. Location: " + path);
        }

        /// <summary>
        /// Takes the product details stored in the ScenarioDataStore and prints 
        /// the specific product detail in the Gauge message in the HTML report. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="key"></param>
        public void PrintNThProductDetailsFromDatastore(string index, string key)
        {
            var scenarioStore = DataStoreFactory.ScenarioDataStore;
            List<Product> data = (List<Product>)scenarioStore.Get(key);
            int position = Int32.Parse(index);
            GaugeMessages.WriteMessage("The product details at position : " + index + " is - Product Name : '" +
                                        data[position].ProductName + "' and Price : '" + data[position].Price + "'");
        }
    }
}