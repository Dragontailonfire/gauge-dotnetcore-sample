using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Cubereum_automation_project.components
{
    /// <summary>
    /// Launches the browser based on the value given in the properties file.
    /// </summary>
    public class WebDriverManager
    {
        private static IWebDriver _Webdriver;

        public static IWebDriver Driver
        {
            get
            {
                return LaunchDriver();
            }

        }

        public static IWebDriver LaunchDriver()
        {
            if (_Webdriver != null)
            {
                return _Webdriver;
            }
            string browser = Environment.GetEnvironmentVariable("test_browser");
            string browserPath = Directory.GetCurrentDirectory() + Environment.GetEnvironmentVariable("test_browser_path");

            switch (browser)
            {
                case "Chrome": _Webdriver = new ChromeDriver(browserPath); break;
                case "Firefox": _Webdriver = new FirefoxDriver(browserPath); break;
                case "IE": _Webdriver = new InternetExplorerDriver(browserPath); break;
                default: throw new Exception("No proper Browser name given in properties file");
            }
            return _Webdriver;
        }

        public static void DisposeDriver()
        {
            if (_Webdriver != null)
            {
                _Webdriver.Quit();
            }
            _Webdriver = null;
        }
    }
}