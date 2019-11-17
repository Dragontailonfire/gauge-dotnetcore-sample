using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;

namespace Cubereum_automation_project.components 
{
    /// <summary>
    /// Contains helper methods used throughout the project.
    /// </summary>
    public class ProjectHandler
    {
        /// <summary>
        /// Will run before each scenario is executed. The driver is initialized in this method.
        /// </summary>
        [BeforeScenario]
        public void start()
        {
            WebDriverManager.LaunchDriver();
        }

        /// <summary>
        /// Will run after each scenario is executed. It closes the driver instance.
        /// </summary>
        [AfterScenario]
        public void tearDown()
        {
            WebDriverManager.DisposeDriver();
        }        
    }
}