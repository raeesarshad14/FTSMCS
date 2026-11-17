using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Collections.Generic;
using iText.Layout.Element;
using Microsoft.Testing.Platform.Extensions.Messages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities
{

    //public class SetUp
    //{
    //    string currentDir = Directory.GetCurrentDirectory();
    //    string runHeadless = ConfigurationManager.AppSettings["RunHeadless"];
    //    [ThreadStatic]
    //    public static IWebDriver driver;

    //    public static AventStack.ExtentReports.ExtentReports extent;
    //    public static ExtentTest test;

    //    ////below is when you want to generate the report
    //    //[OneTimeSetUp]
    //    //public void OnStart()
    //    //{
    //    //    extent = ExtentManager.getInstace();
    //    //}

    //    [OneTimeTearDown]
    //    public void EndReport()
    //    {
    //        extent.Flush();
    //    }

    //    //Below parameters is using to read variable value from "app.config" file.
    //    string browsername = ConfigurationManager.AppSettings["Browser"];
    //    string url = ConfigurationManager.AppSettings["URL"];

    //    // IF you need to run Test case using one user then use below
    //    public string username = ConfigurationManager.AppSettings["UserName"];
    //    public string password = ConfigurationManager.AppSettings["Password"];

    //    // IF you need to run Test case using multiple users then use below and GetUserNames Method
    //    private static string multiUserNames = ConfigurationManager.AppSettings["MultiUserNames"];
    //    public static string[] GetUserNames()
    //    {
    //        return multiUserNames.Split(',');
    //    }
    //    /*
    //     * //Below parameters is using to read variable value from "Config.cs" class.
    //            string browsername = Config.BROWSER;
    //            string url = Config.URL;
    //            public string username = Config.USERNAME;
    //            //public string password = Config.PASSWORD;
    //    */






    //    [SetUp]
    //    public void StartBrowser()
    //    {
    //        //below is related to reprting
    //        extent = ExtentManager.getInstace();
    //        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

    //        InitBrowser(browsername);
    //        driver.Url = url;
    //        driver.Manage().Cookies.DeleteAllCookies();
    //        //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
    //        driver.Manage().Window.Maximize();
    //        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
    //        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
    //    }

    //    [TearDown]
    //    public void AfterTest()
    //    {
    //        driver.Quit();
    //    }

    //    public void InitBrowser(string browserName)
    //    {
    //        switch (browserName)
    //        {
    //            //case "Firefox":
    //            //    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
    //            //    driver = new FirefoxDriver();
    //            //    break;

    //            //case "Chrome":
    //            //    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
    //            //    driver = new ChromeDriver();
    //            //    break;

    //            //case "Edge":
    //            //    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
    //            //    driver = new EdgeDriver();
    //            //    break;

    //            case "Firefox":
    //                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
    //                driver = new FirefoxDriver();
    //                break;

    //            case "Chrome":
    //                //below ChromeOptions class is to handle download any file into specific location
    //                string filepath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DownLoad"));
    //                TestContext.Progress.WriteLine("The path is:" + filepath);
    //                ChromeOptions options = new ChromeOptions();
    //                options.AddUserProfilePreference("download.default_directory", filepath);
    //                TestContext.Progress.WriteLine("This is the place where it is downloading the form:" + filepath);
    //                // 🆕 Check if RunHeadless is ON
    //                if (runHeadless.Equals("ON", StringComparison.OrdinalIgnoreCase))
    //                {
    //                    options.AddArgument("--headless=new"); // use "new" for better rendering on latest Chrome
    //                    options.AddArgument("start-maximized");
    //                    options.AddArgument("--disable-gpu");
    //                    options.AddArgument("--disable-extensions");
    //                }
    //                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
    //                //new DriverManager().SetUpDriver(new ChromeConfig(), "125.0.6422.76");
    //                driver = new ChromeDriver(options);
    //                break;

    //            case "Edge":
    //                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
    //                driver = new EdgeDriver();
    //               // string edgeDriverPath = @"C:\Users\raees.arshad\.nuget\packages\selenium.webdriver.msedgedriver\edgedriver_win64\msedgedriver.exe";
    //               // driver = new EdgeDriver(edgeDriverPath);
    //                break;

    //            case "Headless":
    //                var options2 = new ChromeOptions();
    //                options2.AddArgument("--headless");
    //                options2.AddArgument("start-maximized");
    //                options2.AddArgument("--disable-gpu");
    //                options2.AddArgument("--disable-extensions");

    //                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
    //                driver = new ChromeDriver(options2);
    //                break;
    //        }
    //    }
    //    public string GetProjectDirectory()
    //    {
    //        // return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")) ?? "Cannot retreive current directory.";  C:\agent1\_work\1085\s\src\Projects.ALURRT.Tests\bin\Release\TestData\DeathEposureEventstoAdRelevantDetails_7639.csv
    //        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"); // returned C:\agent1\_work\1085\s\src\Projects.ALURRT.Tests\bin\Projects.ALURRT.Tests\TestData\DeathEposureEventstoAdRelevantDetails_7639.csv
    //                                                                                    // return Directory.GetCurrentDirectory() ?? "Cannot retreive current directory."; // returned C:/
    //                                                                                    // return Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
    //                                                                                    // return this.GetType().Assembly.Location ?? "Cannot retreive current directory.";
    //    }

    //    //public string GetProjectDirectory()
    //    //{
    //    //    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\") ?? "Cannot retreive current directory.";
    //    //}

    public class SetUp
    {


        public static string originalTabHandle;

        [ThreadStatic]
        public static IWebDriver driver;

        // Suite-level report (one for whole run)
        public static AventStack.ExtentReports.ExtentReports suiteExtent;
        public static ExtentHtmlReporter suiteReporter;

        // Test-level report (one per test)
        public static AventStack.ExtentReports.ExtentReports testExtent;
        public static ExtentHtmlReporter testReporter;

        public static ExtentTest suiteTest;
        public static ExtentTest testTest;

        string browsername = ConfigurationManager.AppSettings["Browser"];
        string url = ConfigurationManager.AppSettings["URL"];
        string runHeadless = ConfigurationManager.AppSettings["RunHeadless"];

        // =======================
        //    SUITE REPORT START
        // =======================
        [OneTimeSetUp]
        public void StartSuiteReport()
        {
            string rootDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            string suiteReportPath = Path.Combine(rootDir, "Reports", "FullSuiteReport.html");

            suiteReporter = new ExtentHtmlReporter(suiteReportPath);
            suiteExtent = new AventStack.ExtentReports.ExtentReports();
            suiteExtent.AttachReporter(suiteReporter);

            suiteExtent.AddSystemInfo("Host Name", "localhost");
            suiteExtent.AddSystemInfo("Environment", "QA");
            suiteExtent.AddSystemInfo("User", "Raees");
        }

        // =======================
        //    BEFORE EACH TEST
        // =======================
        [SetUp]
        public void StartBrowser()
        {
            // -------- INDIVIDUAL TEST REPORT --------
            string testName = TestContext.CurrentContext.Test.MethodName;

            string rootDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            string testFolder = Path.Combine(rootDir, "Reports", testName);
            Directory.CreateDirectory(testFolder);

            string testReportPath = Path.Combine(testFolder, "index.html");

            testReporter = new ExtentHtmlReporter(testReportPath);
            testExtent = new AventStack.ExtentReports.ExtentReports();
            testExtent.AttachReporter(testReporter);

            testTest = testExtent.CreateTest(testName);
            suiteTest = suiteExtent.CreateTest(testName);

            // -------- BROWSER SETUP --------
            //InitBrowser(browsername);
            //driver.Url = url;
            //driver.Manage().Cookies.DeleteAllCookies();
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            // -------- BROWSER SETUP --------
            // -------- BROWSER SETUP --------

            UtilityMethods.ShowPopupOnce(
    "1: Close all the browsers (Edge)\n" +
    "2: Run command on cmd prompt:\n" +
    "\"C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe\" --remote-debugging-port=9222 --user-data-dir=\"C:\\EdgeAutomationProfile\""
);
            if (driver == null)
            {
                InitBrowser(browsername);
                // Save the handle of your manual / authenticated tab
                originalTabHandle = driver.CurrentWindowHandle;
            }

            // Open a new tab specifically for this test case
            driver.SwitchTo().NewWindow(WindowType.Tab);

            driver.Url = url;
            UtilityMethods.ShowPopupOnce("Validate Cert and this is only one time");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);


        }

        // =======================
        //    AFTER EACH TEST
        // =======================
        [TearDown]
        public void AfterTest()
        {
            //driver.Quit();
            //testExtent.Flush();   // flush individual report

            try
            {
                if (driver != null)
                {
                    // Retrieve all currently open windows/tabs
                    var allTabs = driver.WindowHandles;

                    // Loop through and close every tab/window EXCEPT the original authenticated one
                    foreach (string handle in allTabs)
                    {
                        if (handle != originalTabHandle)
                        {
                            driver.SwitchTo().Window(handle);
                            driver.Close();
                        }
                    }

                    // Switch back focus to the original authenticated browser window
                    if (!string.IsNullOrEmpty(originalTabHandle) && driver.WindowHandles.Contains(originalTabHandle))
                    {
                        driver.SwitchTo().Window(originalTabHandle);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cleaning up test tabs: {ex.Message}");
            }
            finally
            {
                testExtent.Flush(); // Flush individual test report
            }
        }

        // =======================
        //   END SUITE REPORT
        // =======================
        [OneTimeTearDown]
        public void EndSuiteReport()
        {
            suiteExtent.Flush();  // flush full suite report
        }

        //    // IF you need to run Test case using one user then use below
        public string username = ConfigurationManager.AppSettings["UserName"];
        public string password = ConfigurationManager.AppSettings["Password"];

        // =======================
        //   BROWSER INITIALIZER
        // =======================
        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    string filepath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DownLoad"));
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("download.default_directory", filepath);

                    if (runHeadless.Equals("ON", StringComparison.OrdinalIgnoreCase))
                    {
                        options.AddArgument("--headless=new");
                        options.AddArgument("start-maximized");
                        options.AddArgument("--disable-gpu");
                        options.AddArgument("--disable-extensions");
                    }

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(options);
                    break;

                case "Edge":
                    //// Set up Edge driver using WebDriverManager
                    //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    ////new DriverManager().SetUpDriver(new EdgeConfig(), "149.0.4022.98");

                    //// Configure Edge options
                    //var edgeOptions = new EdgeOptions();
                    //edgeOptions.AddArgument("start-maximized");
                    //// OR: edgeOptions.AddArgument("window-size=1920,1080");

                    //// Create EdgeDriver with options
                    //driver = new EdgeDriver(edgeOptions);
                    //break;

                    // Set up Edge driver using WebDriverManager
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

                    string downloadFolder = UtilityMethods.DownloadFileInProjectDownLoadFolder2();

                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.DebuggerAddress = "127.0.0.1:9222";

                    EdgeDriver edgeDriver = new EdgeDriver(edgeOptions);

                    edgeDriver.ExecuteCdpCommand(
                        "Browser.setDownloadBehavior",
                        new Dictionary<string, object>
                        {
            { "behavior", "allow" },
            { "downloadPath", downloadFolder },
            { "eventsEnabled", true }
                        });

                    driver = edgeDriver;
                    break;


                case "Headless":
                    ChromeOptions options2 = new ChromeOptions();
                    options2.AddArgument("--headless");
                    options2.AddArgument("start-maximized");
                    options2.AddArgument("--disable-gpu");
                    options2.AddArgument("--disable-extensions");

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(options2);
                    break;
            }
        }

        public string GetProjectDirectory()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\");
        }


    }
}