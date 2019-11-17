# Product Search Automation

## 1. Summary
This project is created using Gauge framework, in dotnet flavour of Selenium WebDriver. All details about the project, including setup and run instructions are provided below.

## 2. Project components

### Folder structure
* components - Contains the helper classes that are used throughout the project.
* drivers - Contains the driver files for each browser.
* env - Contains the properties file that provides the run configuration (browser name, url, results file path etc).
* reports - Contains the html report of the run result. New test run overwrites the previous result.
* results - This is where the result file containing the product search result is created.
* specs - Contains the .spec file that lists out the business flow of the test case.
    * concepts - .cpt files that contain reusable steps
* spec_implementations - Contains the implementation of the steps used in spec file.
    * pages - Contains the page object model of the application under test.

## 3. System setup

### Driver download
Download and keep all the following driver files in the drivers folder.
* ChromeDriver - [Download chromedriver_win32.zip](https://chromedriver.storage.googleapis.com/index.html?path=78.0.3904.70/)
* Firefox - [Download Gheckodriver-v0.26.0-win64.zip](https://github.com/mozilla/geckodriver/releases)
* Internet Explorer -  [Download InternetExplorerDriver](https://www.seleniumhq.org/download/)

### Gauge download
* All details about setup is provided in the official site. [Gauge website](https://docs.gauge.org/getting_started/installing-gauge.html?os=windows&language=csharp&ide=vscode)
* In addition to Gauge, following plugins should also be installed. ([Visit](https://docs.gauge.org/plugin.html?os=windows&language=csharp&ide=vscode))
    * dotnet
    * html-report
    * screenshot

## 4. Project setup
* Open the project in Visual Studio.
* Restore all NuGet packages and Build the project.
* Close Visual Studio.
* Open the project in Visual Studio Code.
* Install Gauge and C# plugins for execution.

## 5. Running the project
* From VS Code with the help of Gauge plugin installed.
* From command prompt with the command - "gauge run specs" from the project file path.

## 6. Known issues / workaround
1. IWebElement.Click() is not working for the filters, as the click gets submitted to another element. 
    * As a workaround, introduced Advanced User Interactions API to click the element. This is working now.
2. The filter heading changes each time the product list page is brought up in the WebDriver. (eg: Brand becomes Brands, Display becomes Watch Display Type)
    * Workaround - Handle FindElement() in try block. Use the changed XPath in the catch block for alternate filter header. (This has not been implemented)
3. Commenting out the filtering steps will prevent the Exceptions. This will successfully complete the test run, including writing to csv and displaying product display. 