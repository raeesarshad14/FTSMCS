using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities
{
    public class ExtentManager
    {
        public static AventStack.ExtentReports.ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;

        //public static AventStack.ExtentReports.ExtentReports getInstace()
        //{
        //    if (extent == null)
        //    {
        //        string currentBinDir = Environment.CurrentDirectory.Replace("\\bin", "");
        //        string currentDir = Directory.GetParent(Directory.GetParent(currentBinDir).FullName).FullName;

        //        // if we need multiple reports with date and time we can uncomment below two lines
        //        // string currentDateTime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_");
        //        //string reportPath = currentDir + "\\ExtentReport\\Reports "+  currentDateTime+"\\index.html";
        //        string reportPath = currentDir + "\\Reports\\CounterDrugCM.html";
        //        //string reportPath = currentDir + "\\Uptick.Tests.Common\\Reports\\index.html";

        //        htmlReporter = new ExtentHtmlReporter(reportPath); // Object created for Line number 12
        //        extent = new AventStack.ExtentReports.ExtentReports();// Object created for Line number 11
        //        extent.AttachReporter(htmlReporter);

        //        extent.AddSystemInfo("Host name", "localhost");
        //        extent.AddSystemInfo("Environemnt", "QA");
        //        extent.AddSystemInfo("user", "Raees");

        //        //previously below was the path 
        //        string extentConfigPath = currentDir + "\\extent-config.xml";

        //        //below is the new path for pipeline 
        //        //string extentConfigPath = currentDir + "\\Uptick.Tests.Common\\ExtentConfig\\extent-config.xml";
        //        TestContext.Progress.WriteLine("Extent Config Path is: " + extentConfigPath);
        //        htmlReporter.LoadConfig(extentConfigPath);

        //    }
        //    return extent;
        //}


        public static AventStack.ExtentReports.ExtentReports getInstace()
        {
            if (extent == null)
            {
                string currentBinDir = Environment.CurrentDirectory.Replace("\\bin", "");
                string currentDir = Directory.GetParent(Directory.GetParent(currentBinDir).FullName).FullName;

                // ✅ Get only the method name (no parameters)
                string cleanedTestName = TestContext.CurrentContext.Test.MethodName;

                if (string.IsNullOrWhiteSpace(cleanedTestName))
                    cleanedTestName = "TestReport";

                // Create a folder per test case
                string reportFolder = Path.Combine(currentDir, "Reports", cleanedTestName);
                Directory.CreateDirectory(reportFolder);

                // index.html will be placed inside that folder automatically
                string reportPath = Path.Combine(reportFolder, "index.html");

                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new AventStack.ExtentReports.ExtentReports();
                extent.AttachReporter(htmlReporter);

                extent.AddSystemInfo("Host name", "localhost");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("User", "Raees");

                string extentConfigPath = Path.Combine(currentDir, "extent-config.xml");
                TestContext.Progress.WriteLine("Extent Config Path is: " + extentConfigPath);
                htmlReporter.LoadConfig(extentConfigPath);
            }

            return extent;
        }
    }
}

