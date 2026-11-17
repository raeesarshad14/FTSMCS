using iText.Kernel.Pdf;
using iText.Svg.Renderers.Path.Impl;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PdfiumViewer;
using Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using UglyToad.PdfPig;
//using Uptick.Tests.Common;
//using Uptick.Tests.Common.PageObjects;
//using Uptick.Tests.Common.TestSteps;
using MessageBox = System.Windows.Forms.MessageBox;
using PdfDocument = UglyToad.PdfPig.PdfDocument;





namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities
{
    public class UtilityMethods
    {

        private static string testFolder;

        public IWebDriver driver;
        private int totalLoadingTime = 0; // Variable to store the total loading time

        protected UtilityMethods(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void TakesScreenshot(string element)
        {
            //    var fileName = $"{TestContext.CurrentContext.Test.MethodName}: {element}.jpg";
            //    fileName = Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
            //    var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, fileName);
            //    TestContext.Progress.WriteLine("Screen shot path is: " + filePath);
            //    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            //    screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Jpeg);

            //    TestContext.AddTestAttachment(filePath, fileName);

            //above method was comemtned out when I updated Selenium.WebDriver from 4.15.0 to 4.18.1 becasue then creenshotImageFormat.Jpeg was not accpeting it so I updated this method below

            var fileName = $"{TestContext.CurrentContext.Test.MethodName}: {element}.jpg";
            fileName = Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
            var filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, fileName);
            TestContext.Progress.WriteLine("Screen shot path is: " + filePath);

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            // Convert screenshot to byte array
            var screenshotBytes = screenshot.AsByteArray;

            // Write bytes to file with JPEG format
            System.IO.File.WriteAllBytes(filePath, screenshotBytes);

            // Add the screenshot file as a test attachment
            TestContext.AddTestAttachment(filePath, fileName);
        }



        /// <summary>
        /// Gets the full path of a file located inside the 'UpLoad' folder of the project.
        /// </summary>
        /// <param name="fileName">The name of the file (e.g., "sample.csv", "document.pdf").</param>
        /// <returns>Full path to the file.</returns>
        public string UploadFileFromUploadFolder(string fileName)
        {
            string uploadFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\UpLoad");
            string fullFilePath = Path.GetFullPath(Path.Combine(uploadFolderPath, fileName));

            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException($"The file '{fileName}' was not found in the UpLoad folder.", fullFilePath);
            }

            return fullFilePath;
        }

        //public string GetProjectDirectory()
        //{
        //    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\") ?? "Cannot retreive current directory.";
        //}

        public void DownloadFileInDesiredDirectory(string PathOfProject, string folderpathTodownload)
        {

            //string SolutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string SolutionPath = PathOfProject;
            TestContext.Progress.WriteLine("Solution Path is: " + SolutionPath);
            string DownloadPath = SolutionPath + folderpathTodownload;
            TestContext.Progress.WriteLine("Download Path is: " + DownloadPath);

        }

        public void CreateFolderIfNotExist()
        {

            DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")) + @"Uptick.Tests.Common\DownLoad");

            if (!dir.Exists)
            {
                dir.Create();
            }
        }

        public void DownloadFileInProjectDownLoadFolder()
        {

            string downloadFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")) + @"Projects.FTSMCSCounterDrugCM.Tests\DownLoad";
            TestContext.Progress.WriteLine("File download in " + downloadFolder);
            //Reporting.infoLog("File download in " + downloadFolder);

        }

        public static string DownloadFileInProjectDownLoadFolder2()
        {
            string downloadFolder = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "DownLoad"));

            Directory.CreateDirectory(downloadFolder);

            TestContext.Progress.WriteLine("File download in: " + downloadFolder);

            return downloadFolder;
        }

        public void waitUntilFileDownloaded(string fileExtention)
        {
            // put file extention as parameter. for example ".xlsx" or ".csv"
            //string fileExtension = ".xlsx"; or 

            string downloadFolder = Path.GetFullPath(
                 Path.Combine(
                     AppDomain.CurrentDomain.BaseDirectory,
                     "..",
                     "..",
                     "..",
                     "DownLoad"));
            string fileExtension = fileExtention;
            string filePath = Path.Combine(downloadFolder, fileExtension);
            int count = 0;

            // Wait until file is downloaded completely
            bool isDownloading = true;
            while (isDownloading && count <= 120)
            {
                // Get a list of files in the directory with the specified extension
                DirectoryInfo directory = new DirectoryInfo(downloadFolder);
                FileInfo[] files = directory.GetFiles("*" + fileExtension);

                // Check if there are any files with the specified extension
                if (files.Length > 0)
                {
                    // File has finished downloading
                    TestContext.Progress.WriteLine("File downloaded successfully ");
                    //Reporting.infoLog("File downloaded successfully ");
                    isDownloading = false;
                }
                else
                {
                    TestContext.Progress.WriteLine("Wait for one second before checking again " + count);
                    // Reporting.infoLog("Wait for one second before checking again " + count);
                    // Wait for one second before checking again
                    Thread.Sleep(1000);
                    count++;
                }
            }
        }

        public void verifyIfFileExist(string fileExtention)
        {
            // put file extention as parameter. for example ".xlsx" or ".csv"
            //string fileExtension = ".xlsx"; or 

            string downloadFolder = Path.GetFullPath(
                 Path.Combine(
                     AppDomain.CurrentDomain.BaseDirectory,
                     "..",
                     "..",
                     "..",
                     "DownLoad"));
            string fileExtension = fileExtention;
            // Get a list of files in the directory with the specified extension
            DirectoryInfo directory = new DirectoryInfo(downloadFolder);
            FileInfo[] files = directory.GetFiles("*" + fileExtension);
            int len = files.Length;
            TestContext.Progress.WriteLine("file length is : " + len);
            // Check if the file exists
            if (files.Length > 0)
            {
                TestContext.Progress.WriteLine("File exists");
            }
            else
            {
                TestContext.Progress.WriteLine(fileExtention + " File does not exist");
                Reporting.failureLog(fileExtention + " File does not exist");
                Assert.Fail(fileExtention + " File does not exist");
            }
        }

        public void VerifyIfFileExists(string expectedFileName, string fileExtension)
        {
            // Example input: expectedFileName = "NGB 89_PromoUV059874", fileExtension = ".pdf"

            // Construct download folder path
            //string downloadFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DownLoad"));
            string downloadFolder = (GetDownloadFolderPath());
            TestContext.Progress.WriteLine("📁 Verifying file in download folder: " + downloadFolder);

            string expectedFullFileName = expectedFileName + fileExtension;
            TestContext.Progress.WriteLine("🔍 Looking for expected file: " + expectedFullFileName);

            DirectoryInfo directory = new DirectoryInfo(downloadFolder);
            FileInfo[] files = directory.GetFiles("*" + fileExtension);

            TestContext.Progress.WriteLine("📂 Total files found with extension '" + fileExtension + "': " + files.Length);

            FileInfo matchingFile = files.FirstOrDefault(file =>
         file.Name.StartsWith(expectedFileName, StringComparison.OrdinalIgnoreCase) &&
         file.Extension.Equals(fileExtension, StringComparison.OrdinalIgnoreCase));

            if (matchingFile != null)
            {
                TestContext.Progress.WriteLine("✅ File was found in the folder.");
                Reporting.successLog("✅ File was found in the folder.");
                TestContext.Progress.WriteLine($"📄 Found file name: '{matchingFile.Name}'");
                Reporting.successLog($"📄 Found file name: '{matchingFile.Name}'");
                TestContext.Progress.WriteLine($"🎯 Expected file name: '{expectedFullFileName}'");
                Reporting.successLog($"🎯 Expected file name: '{expectedFullFileName}'");

                if (matchingFile.Name.StartsWith(expectedFileName, StringComparison.OrdinalIgnoreCase))
                {
                    TestContext.Progress.WriteLine("✅ File name matches the expected name.");
                    Reporting.successLog("✅ File name matches the expected name.");
                }
                else
                {
                    TestContext.Progress.WriteLine("❌ File name does NOT match the expected name!");
                    Reporting.successLog("❌ File name does NOT match the expected name!");
                    Assert.Fail("❌ File name does NOT match the expected name!");
                }

                try
                {
                    // Open the PDF file in browser (not external viewer)
                    string fileUrl = "file:///" + matchingFile.FullName.Replace("\\", "/");
                    TestContext.Progress.WriteLine("🌐 Opening file in browser: " + fileUrl);

                    driver.Navigate().GoToUrl(fileUrl);
                    Thread.Sleep(2000); // Wait for file to load

                    TestContext.Progress.WriteLine("📸 Attempting to capture screenshot of opened file.");
                    Reporting.successLog("📸 Attempting to capture screenshot of opened file.");
                    //CaptureScreenshot(true);
                    TestContext.Progress.WriteLine("✅ Screenshot captured successfully.");
                    Reporting.successLog("✅ Screenshot captured successfully.");
                }
                catch (Exception ex)
                {
                    TestContext.Progress.WriteLine("⚠️ Could not open file or capture screenshot: " + ex.Message);
                    Reporting.failureLog("⚠️ Could not open file or capture screenshot: " + ex.Message);
                }
            }
            else
            {
                string message = $"❌ Expected file '{expectedFullFileName}' does not exist in folder: {downloadFolder}";
                TestContext.Progress.WriteLine(message);
                // CaptureScreenshot(false);
                Reporting.failureLog(message);
                Assert.Fail(message);
            }
        }

        public static void VerifyTextInOpenedPdf(string expectedText, string downloadsPath)
        {
            string pdfText = ExtractTextFromLatestDownloadedPdf(downloadsPath);

            // Normalize both texts to ignore line breaks, tabs, multiple spaces
            string normalizedPdfText = NormalizeText(pdfText);
            string normalizedExpectedText = NormalizeText(expectedText);

            if (!normalizedPdfText.Contains(normalizedExpectedText))
            {
                Console.WriteLine($"❌ Expected text '{expectedText}' not found in PDF.\nExtracted text:\n{pdfText}");
                TestContext.Progress.WriteLine($"❌ Expected text '{expectedText}' not found in PDF.\nExtracted text:\n{pdfText}");
                Reporting.failureLog($"❌ Expected text '{expectedText}' not found in PDF.\nExtracted text:\n{pdfText}");
                throw new Exception($"Expected text '{expectedText}' not found in PDF.");
            }
            else
            {
                TestContext.Progress.WriteLine($"✅ Signature verified: expected text which is '{expectedText}' found in the PDF which is {pdfText}");
                Reporting.successLog($"✅ Signature verified: expected text which is '{expectedText}' found in the PDF which is {pdfText}");
                Console.WriteLine($"✅ Signature verified: expected text which is '{expectedText}' found in the PDF which is {pdfText}");
            }
        }

        public void VerifyUniformFontWithPdfPig(string filePath)
        {
            var fontNames = new HashSet<string>();
            var capturedTextBuilder = new StringBuilder();

            using (var document = PdfDocument.Open(filePath))
            {
                foreach (var page in document.GetPages())
                {
                    foreach (var letter in page.Letters)
                    {
                        fontNames.Add(letter.FontName);
                        capturedTextBuilder.Append(letter.Value);
                    }
                    capturedTextBuilder.AppendLine(); // New page separator if needed
                }
            }

            string capturedText = capturedTextBuilder.ToString().Trim();

            Reporting.infoLog("📄 Captured text is:\n" + capturedText);
            TestContext.Progress.WriteLine("📄 Captured text is:\n" + capturedText);
            Console.WriteLine("📄 Captured text is:\n" + capturedText);

            if (fontNames.Count == 1)
            {
                string fontUsed = fontNames.First();
                Console.WriteLine($"✅ Font is uniform. Font used: {fontUsed}");
                TestContext.Progress.WriteLine($"✅ Font is uniform. Font used: {fontUsed}");
                Reporting.successLog($"✅ Font is uniform. Font used: {fontUsed}");
            }
            else
            {
                string fontList = string.Join(", ", fontNames);
                Console.WriteLine($"❌ Multiple fonts detected: {fontList}");
                TestContext.Progress.WriteLine($"❌ Multiple fonts detected: {fontList}");
                Reporting.failureLog($"❌ Multiple fonts detected: {fontList}");
                throw new Exception("Font is not uniform in the PDF.");
            }
        }


        private static string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Replace newlines, tabs, and multiple spaces with a single space
            return System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ").Trim();
        }

        public static string ExtractTextFromLatestDownloadedPdf(string downloadsPath)
        {
            var latestFile = Directory.GetFiles(downloadsPath, "*.pdf")
                                      .Select(f => new FileInfo(f))
                                      .OrderByDescending(f => f.LastWriteTime)
                                      .FirstOrDefault();

            if (latestFile == null)
                throw new FileNotFoundException("No PDF files found in the folder.");

            string filePath = latestFile.FullName;

            // 1. Extract form field values
            var formFields = ExtractFormFieldsFromPdf(filePath);
            string formFieldText = string.Join(" ", formFields.Values.Where(v => !string.IsNullOrWhiteSpace(v)));

            // 2. Extract visible PDF content
            string fullPdfText = ExtractVisibleTextFromPdf(filePath);

            // 3. Combine both
            string combinedText = formFieldText + " " + fullPdfText;

            return combinedText;
        }

        public static string ExtractVisibleTextFromPdf(string filePath)
        {
            var sb = new StringBuilder();

            using (var reader = new iTextSharp.text.pdf.PdfReader(filePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string pageText = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, i);
                    sb.AppendLine(pageText);
                }
            }

            string result = sb.ToString();

            // ✅ Console log for debugging
            Console.WriteLine("📄 Extracted Visible Text from PDF:\n" + result);
            TestContext.Progress.WriteLine("📄 Extracted Visible Text from PDF:\n" + result);
            Reporting.successLog("📄 Extracted Visible Text from PDF:\n" + result);

            return result;
        }

        public static Dictionary<string, string> ExtractFormFieldsFromPdf(string filePath)
        {
            var fields = new Dictionary<string, string>();
            var sb = new StringBuilder();

            using (var pdfReader = new iTextSharp.text.pdf.PdfReader(filePath))
            {
                var form = pdfReader.AcroFields;
                var fieldKeys = form.Fields.Keys;

                foreach (string key in fieldKeys)
                {
                    string value = form.GetField(key);
                    fields[key] = value;

                    // Build string for console/log/report
                    sb.AppendLine($"Field: {key} | Value: {value}");
                }
            }

            string capturedText = sb.ToString();

            // ✅ Console output (for debugging)
            Console.WriteLine("📄 Extracted PDF Form Fields:\n" + capturedText);
            TestContext.Progress.WriteLine("📄 Extracted PDF Form Fields:\n" + capturedText);
            Reporting.successLog("📄 Extracted PDF Form Fields:\n" + capturedText);

            return fields;
        }
        public string GetDownloadFolderPath()
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")) + @"\DownLoad";
        }


        public void waitUntilCSVFileDownloaded()
        {

            string downloadFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")) + @"Uptick.Tests.Common\DownLoad";
            string fileExtension = ".csv";
            int count = 0;

            // Wait until file is downloaded completely
            bool isDownloading = true;
            while (isDownloading && count <= 120)
            {
                // Get a list of files in the directory with the specified extension
                DirectoryInfo directory = new DirectoryInfo(downloadFolder);
                FileInfo[] files = directory.GetFiles("*" + fileExtension);

                // Check if there are any files with the specified extension
                if (files.Length > 0)
                {
                    // File has finished downloading
                    TestContext.Progress.WriteLine("File downloaded successfully and making sure ");
                    isDownloading = false;
                }
                else
                {
                    TestContext.Progress.WriteLine("Wait for one second before checking again " + count);
                    // Wait for one second before checking again
                    Thread.Sleep(1000);
                    count++;
                }
            }
        }

        /// <summary>
        /// This method is going to verify that If file download in desire location. 
        /// PathOfProject parameter, is where we have to provide the path of the project(root of the project)
        /// folderpathTodownload parameter, is where you want to add specific location to download the file
        /// ComparisonFileName parameter, is where we can take any string text and compare with this file
        /// <param name="PathOfProject"></param>
        /// <param name="FolderpathTodownload"></param>
        /// <param name="ComparisonFileName"></param>
        /// </summary>
        public void VerifyIfFileDownload(string PathOfProject, string FolderpathTodownload, string ComparisonFileName, string fileType)
        {
            DirectoryInfo dicinfo = new DirectoryInfo(PathOfProject + FolderpathTodownload);

            FileInfo[] files = dicinfo.GetFiles(fileType);

            foreach (FileInfo file in files)
            {
                string name = file.Name;
                bool fileexist = file.Exists;
                if (name.Contains(ComparisonFileName) || (fileexist == true))
                {
                    TestContext.Progress.WriteLine("File is downloaded and Verified Successfully");
                    waitForLoadingBarToCompleteinSeconds();
                    // DeleteAllFileAndDirectoryFromFolder(PathOfProject,FolderpathTodownload);
                }
                else
                {
                    TestContext.Progress.WriteLine("File is not downloaded in current location");
                    Reporting.failureLog("File is not downloaded in current location");
                    waitForLoadingBarToCompleteinSeconds();
                    //DeleteAllFileAndDirectoryFromFolder(PathOfProject, FolderpathTodownload);
                    Assert.Fail("File is not downloaded in current location");
                }
            }
        }

        /// <summary>
        /// This method is going to verify that If file download in desire location. 
        /// PathOfProject parameter, is where we have to provide the path of the project(root of the project)
        /// folderpathTodownload parameter, is where you want to add specific location to download the file
        /// </summary>

        public void DeleteAllFileAndDirectoryFromFolder(string PathOfProject, string folderpathTodownload)
        {

            string downloadFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")) + @"Uptick.Tests.Common\DownLoad";
            // string filepath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string filepath = PathOfProject;
            TestContext.Progress.WriteLine("The path is:" + filepath);
            //DirectoryInfo di = new DirectoryInfo(filepath + @"Uptick.Tests.Common\DownLoad\");
            DirectoryInfo di = new DirectoryInfo(filepath + folderpathTodownload);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
                TestContext.Progress.WriteLine("File Deleted Successfully");
                //Reporting.infoLog("File Deleted Successfully");
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
                TestContext.Progress.WriteLine("Directory Deleted Successfully");
            }

        }

        public void DeleteAllFilesAndDirectoriesFromFolder()
        {

            // Resolve path to the "DownLoad" folder in your solution root
            string downloadFolder = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..",
                    "..",
                    "..",
                    "DownLoad"));
            string resolvedPath = Path.GetFullPath(downloadFolder);

            TestContext.Progress.WriteLine("📂 Resolved download folder path: " + resolvedPath);
            Reporting.infoLog("📂 Resolved download folder path: " + resolvedPath);
            DirectoryInfo di = new DirectoryInfo(downloadFolder);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
                TestContext.Progress.WriteLine("File Deleted Successfully");

            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
                TestContext.Progress.WriteLine("Directory Deleted Successfully");
                //Reporting.infoLog("Directory Deleted Successfully");
            }

        }

        private string testPassFolder = string.Empty;
        private string testFailFolder = string.Empty;
        private static string runTimestamp = DateTime.Now.ToString("MM_dd_yyyy_HHmmss");  // Fixed for entire test run

        public void CaptureScreenshot(bool isPassedStep)
        {
            try
            {
                // Get the base directory
                string currentDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
                while (!Directory.Exists(Path.Combine(currentDir, "ScreenShots")) && Directory.Exists(currentDir))
                {
                    currentDir = Directory.GetParent(currentDir)?.FullName;
                }

                // Define the correct base path for screenshots
                string baseScreenshotsPath = Path.Combine(currentDir, "ScreenShots");

                // Get the test method name
                string methodName = TestContext.CurrentContext.Test.MethodName;

                // Create a single folder for this test execution (fixed timestamp)
                string testRunFolder = $"{methodName}_{runTimestamp}";

                // Ensure the same folder is used for all screenshots during this test execution
                if (isPassedStep)
                {
                    if (string.IsNullOrEmpty(testPassFolder))
                    {
                        testPassFolder = Path.Combine(baseScreenshotsPath, "PassedSteps_ScreenShots", testRunFolder);
                        Directory.CreateDirectory(testPassFolder);
                        TestContext.Progress.WriteLine("Test Pass Folder Created: " + testPassFolder);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(testFailFolder))
                    {
                        testFailFolder = Path.Combine(baseScreenshotsPath, "FailedSteps_ScreenShots", testRunFolder);
                        Directory.CreateDirectory(testFailFolder);
                        TestContext.Progress.WriteLine("Test Fail Folder Created: " + testFailFolder);
                    }
                }

                // Use the existing folder (do not create new folders per second)
                string targetFolder = isPassedStep ? testPassFolder : testFailFolder;

                // Generate a unique filename for each screenshot within the same folder
                string timestamp = DateTime.Now.ToString("HHmmssfff");  // Unique for each screenshot
                string screenshotFileName = $"Screenshot_{timestamp}.png";
                string screenshotPath = Path.Combine(targetFolder, screenshotFileName);

                // Take the screenshot and save it
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);

                TestContext.Progress.WriteLine($"Screenshot saved at: {screenshotPath}");
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("Failed to capture screenshot: " + ex.Message);
            }
        }




        // The screen shot method below deletes old records, screenshots, and folders inside the "Reports" directory before creating a new folder.
        // It ensures a clean slate for each test, creating a new folder with the same test name and preserving the latest screenshot.

        /// <summary>
        /// Captures a screenshot and saves it in a folder named after the test case with a timestamp.
        /// If the suite is rerun, it deletes existing folders for each test case before capturing new screenshots.
        /// </summary>

        public static bool isSuiteStarted = false;
        //public void CaptureScreenshot()
        //{
        //    try
        //    {
        //        // Find the correct base directory (moving up if needed)
        //        string currentDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
        //        while (!Directory.Exists(Path.Combine(currentDir, "ScreenShots")) && Directory.Exists(currentDir))
        //        {
        //            currentDir = Directory.GetParent(currentDir)?.FullName;
        //        }

        //        TestContext.Progress.WriteLine("Current Directory: " + currentDir);

        //        // Define the correct screenshots folder
        //        string reportsPath = Path.Combine(currentDir, "ScreenShots");
        //        TestContext.Progress.WriteLine("Reports Path: " + reportsPath);

        //        // Ensure WebDriver is initialized
        //        if (driver == null)
        //        {
        //            TestContext.Progress.WriteLine("WebDriver is not initialized!");
        //            return;
        //        }

        //        // Get the test method name
        //        string methodName = TestContext.CurrentContext.Test.MethodName;

        //        // Create test folder only once per test
        //        if (string.IsNullOrEmpty(testFolder))
        //        {
        //            string timestamp = DateTime.Now.ToString("MM-dd-yyyy_HHmmssfff");
        //            testFolder = Path.Combine(reportsPath, $"{methodName}_{timestamp}");
        //            Directory.CreateDirectory(testFolder);
        //            TestContext.Progress.WriteLine("Test Folder Created: " + testFolder);
        //        }

        //        // Generate a unique filename for each screenshot
        //        string timestampForScreenshot = DateTime.Now.ToString("MM_dd_yyyy_HHmmssfff");
        //        string screenshotFileName = $"Screenshot_{timestampForScreenshot}.png";
        //        string screenshotPath = Path.Combine(testFolder, screenshotFileName);

        //        TestContext.Progress.WriteLine("Screenshot Path: " + screenshotPath);

        //        // Take the screenshot and save it
        //        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //        File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);

        //        TestContext.Progress.WriteLine($"Screenshot saved at: {screenshotPath}");
        //    }
        //    catch (Exception ex)
        //    {
        //        TestContext.Progress.WriteLine("Failed to capture screenshot: " + ex.Message);
        //    }
        //}




        // The screen shot method below is similar to the one above. The only difference is that the method below does not delete old records, screenshots, or folders inside the "Reports" directory.
        // It will retain all existing records and create a new folder each time with the same test name, preserving the latest screenshot in it.

        ///// <summary>
        ///// Captures a screenshot and saves it in a folder named after the test case with a timestamp.
        ///// </summary>
        ///// 
        //public void CaptureScreenshot()
        //{
        //    try
        //    {
        //        // Get the current test method name
        //        string methodName = TestContext.CurrentContext.Test.MethodName;

        //        // Check if the current test run is a new run (first screenshot for the test)
        //        if (testFolder == null || !testFolder.Contains(methodName))
        //        {
        //            // Get the current timestamp
        //            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        //            // Create the main folder with the test case name and timestamp for each run
        //            testFolder = Path.Combine("C:\\QATesting\\AutomatedUITesting\\Uptick.Tests.Common\\Reports", $"{methodName}_{timestamp}");

        //            // Create the main folder if it doesn't exist
        //            Directory.CreateDirectory(testFolder);
        //        }

        //        // Generate a unique filename for the screenshot with a timestamp
        //        string timestampForScreenshot = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
        //        string screenshotFileName = $"Screenshot_{timestampForScreenshot}.png";
        //        string screenshotPath = Path.Combine(testFolder, screenshotFileName);

        //        // Take the screenshot and save it
        //        var screenshot = driver.TakeScreenshot();
        //        screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Failed to capture screenshot: " + ex.Message);
        //    }
        //}

        /// <summary>
        ///  used to verify obj is clickable, and wait for loading bar is present. 
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="msg"></param>
        public void ClickObj(IWebElement ele, string msg)
        {
            try
            {
                highlight_obj(ele);
                moveToElement(ele);
                WaitForElementToBeClickable(ele);
                //CaptureScreenshot(true);
                ele.Click();
                handleErrorMessage(msg);
                // CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Successfully Clicked: " + msg);
                Reporting.successLog("Successfully Clicked: " + msg);
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count;
            }
            catch (Exception e)
            {
                // (Note: I think this is causing issue in pipeline)if you want to use this method then uncomment this method from TestElementManipulation but this is causing issue in pipeline.
                //CaptureScreenshot(true);
                TakesScreenshot(msg);
                TestContext.Progress.WriteLine("Failure to Click: " + msg);
                Reporting.failureLog("Failure to Click: " + msg);
                Console.WriteLine("Failure to Click: " + msg);
                Assert.Fail("Failure to Click " + msg);
                Assert.Fail("Exception is: " + e.Message);
            }
        }
        public void Click(By locator, string msg)
        {
            var element = driver.FindElement(locator);

            // Highlight before clicking
            highlight_obj(element);

            element.Click();
            TestContext.Progress.WriteLine("Successfully Clicked: " + msg);
            Reporting.successLog("Successfully Clicked: " + msg);
        }


        //    public void HideAnyTooltip()
        //    {
        //        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //        string script = @"
        //    var el = document.evaluate(""//*[@aria-describedby and starts-with(@aria-describedby, 'tooltip')]"", 
        //                               document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
        //    if (el) {
        //        el.style.display = 'none';
        //    }
        //";
        //        js.ExecuteScript(script);
        //    }

        public void HideTooltipAndRestore(int delayMilliseconds = 500)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Step 1: Hide tooltip
            string hideScript = @"
    var el = document.evaluate(""//*[@aria-describedby and starts-with(@aria-describedby, 'tooltip')]"", 
                               document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
    if (el) {
        el.style.display = 'none';
    }
    ";
            js.ExecuteScript(hideScript);

            // Step 2: Wait for it to disappear
            Thread.Sleep(delayMilliseconds);

            // Step 3: Restore tooltip
            string restoreScript = @"
    var el = document.evaluate(""//*[@aria-describedby and starts-with(@aria-describedby, 'tooltip')]"", 
                               document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
    if (el) {
        el.style.display = ''; // remove inline override to restore original
    }
    ";
            js.ExecuteScript(restoreScript);
        }

        public void ClickObjAndWait(IWebElement ele)
        {
            try
            {
                //WaitForElementToBeClickable(ele);
                highlight_obj(ele);
                //CaptureScreenshot(true);
                ele.Click();
                //CaptureScreenshot(true);
                Reporting.successLog("Successfully Clicked");
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count; // Update the total loading time
            }
            catch (Exception e)
            {
                //CaptureScreenshot(true);
                TakesScreenshot(ele.Text);
                TestContext.Progress.WriteLine("Failure to Click ");
                Reporting.failureLog("Failure to Click");
                Assert.Fail("Failure to Click " + e.Message);
            }
        }
        // Enter any text in then textElement box. This Method we can use in our any test case to enter text in the  elements
        public void EnterTxt(IWebElement ele, string txt, string msg)
        {
            try
            {
                highlight_obj(ele);
                moveToElement(ele);
                ele.Clear();
                ele.SendKeys(txt);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Successfully Enter Text " + msg);
                Reporting.successLog("Successfully Enter Text " + msg);
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count; // Update the total loading time
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                Reporting.failureLog("Failure to Enter " + msg);
                TestContext.Progress.WriteLine("Failure to Enter " + msg);
                Assert.Fail("Failure to Enter " + msg + " " + e.Message);
            }
        }

        public void EnterTxtOnlyForIcons(IWebElement ele, string txt, string msg)
        {
            try
            {
                //WaitForElementToBeClickable(ele);
                highlight_obj(ele);
                moveToElement(ele);
                ele.SendKeys(txt);
                //CaptureScreenshot(true);
                pauseExecution(500);

                TestContext.Progress.WriteLine("Successfully Enter Text " + msg);
                Reporting.successLog("Successfully Enter Text" + msg);
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count; // Update the total loading time
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                // CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to Enter " + msg);
                Reporting.failureLog("Failure to Enter " + msg);
                Assert.Fail("Failure to Enter " + msg + " " + e.Message);
            }
        }

        public string GetElementText(IWebElement ele, string msg)
        {
            string text = null;
            try
            {
                //WaitForElementToBeClickable(ele);
                moveToElement(ele);
                highlight_obj(ele);
                text = ele.Text;
                Reporting.successLog("Captured text and text is:" + text);
                //CaptureScreenshot(true);
                return text;
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                // CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to get element: " + e.Message);
                Reporting.failureLog("Failure to get element: " + e.Message);
                return null;
            }
        }

        public string GetElementTextWithoutMoveToElement(IWebElement element)
        {
            try
            {
                if (element.Displayed)
                {
                    //CaptureScreenshot(true);
                    return element.Text.Trim(); // Return trimmed text if element is displayed
                }
                else
                {
                    Console.WriteLine($"Element is not visible.");
                    return null;
                }
            }
            catch (NoSuchElementException)
            {
                //CaptureScreenshot(true);
                Console.WriteLine($"Element was not found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting text from element: {ex.Message}");
                return null;
            }
        }


        public void pauseExecution(int milliSec)
        {
            try
            {
                Thread.Sleep(milliSec);
            }
            catch (Exception e)
            {
                // TODO: handle exception
            }
        }

        public void selectfromlist(IWebElement ele, string text, string msg)
        {
            try
            {
                WaitForElementToBeClickable(ele);
                highlight_obj(ele);
                SelectElement select = new SelectElement(ele);
                select.SelectByText(text);
                //CaptureScreenshot(true);
                Reporting.successLog("Successfully select:" + msg);
                TestContext.Progress.WriteLine("Successfully select: " + msg);
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count;
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to  select: " + msg);
                Reporting.failureLog("Failure to  select: " + msg);
                Assert.Fail("Failure to  select: " + msg + " " + e.Message);
            }

        }

        public void selectfromlistOnlyForIcons(IWebElement ele, string text, string msg)
        {
            try
            {
                WaitForElementToBeClickable(ele);
                highlight_obj(ele);
                SelectElement select = new SelectElement(ele);
                select.SelectByText(text);
                pauseExecution(500);
                //CaptureScreenshot(true);
                Reporting.successLog("Successfully select: " + msg);
                TestContext.Progress.WriteLine("Successfully select: " + msg);
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count;
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to  select: " + msg);
                Reporting.failureLog("Failure to  select: " + msg);
                Assert.Fail("Failure to  select: " + msg + " " + e.Message);
            }

        }

        public void SelectFromDropdownUingIndax(IWebElement ele, int indexNumber, string msg)
        {
            try
            {
                WaitForElementToBeClickable(ele);
                highlight_obj(ele);
                ele.Click();

                By optionsLocator = By.XPath("//ul[@class='select2-results__options']//li");

                var options = driver.FindElements(optionsLocator);

                if (options.Count <= indexNumber)
                {
                    throw new Exception(
                        $"Option index {indexNumber} was not found. Available options: {options.Count}");
                }

                WaitForElementToBeClickable(options[indexNumber]);
                highlight_obj(options[indexNumber]);
                options[indexNumber].Click();

                TestContext.Progress.WriteLine("Successfully selected " + msg);
                Reporting.successLog("Successfully selected " + msg);
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                TestContext.Progress.WriteLine("Failure to select " + msg);
                Reporting.failureLog("Failure to select " + msg);
                Assert.Fail("Failure to select " + msg + " " + e.Message);
            }
        }

        // Get Element Display
        public bool getElementDisplay(By locator, string msg)
        {
            bool eleDisplay = false;
            try
            {
                IWebElement ele = WaitForElementToBeClickable(locator);
                eleDisplay = ele.Displayed;
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Successfully element display " + msg);
                Reporting.successLog("Successfully element display " + msg);
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to  display element " + msg);
                Reporting.failureLog("Failure to  display element " + msg);
                Assert.Fail("Failure to  display element " + msg + " " + e.Message);
            }
            return eleDisplay;
        }
        // Get Element Display
        public bool getElementDisplay(IWebElement ele, string msg)
        {
            bool eleDisplay = false;
            try
            {
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count;
                eleDisplay = ele.Displayed;
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Successfully element display " + msg);
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to  display element " + msg);
                Reporting.failureLog("Failure to  display element " + msg);
            }
            return eleDisplay;
        }


        /// <summary>
        /// Waits for the specified web element to be clickable on the page.
        /// </summary>
        /// <param name="locator">The locator of the web element to wait for.</param>
        /// <returns>The web element if it becomes clickable, or null if an exception occurs.</returns>
        public IWebElement WaitForElementToBeClickable(By locator)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };

                // Native Selenium 4 way: Use a lambda expression instead of ExpectedConditions
                var ele = wait.Until(d =>
                {
                    var element = d.FindElement(locator);
                    return (element != null && element.Displayed && element.Enabled) ? element : null;
                });

                return ele;
            }
            catch (Exception e)
            {
                TakesScreenshot(null);
                TestContext.Progress.WriteLine(e);
                return null;
            }
        }


        // <summary>
        /// Waits for the WebElement to become clickable.
        /// </summary>
        /// <param name="element">The WebElement to wait for.</param>
        /// <returns>The WebElement if it becomes clickable within the timeout period; otherwise, null.</returns>
        public void WaitForElementToBeClickable(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };

                // Selenium 4 native lambda instead of ExpectedConditions
                wait.Until(d =>
                {
                    try
                    {
                        return (element != null && element.Displayed && element.Enabled);
                    }
                    catch
                    {
                        return false;
                    }
                });
            }
            catch (Exception e)
            {
                TakesScreenshot(null);
                TestContext.Progress.WriteLine(e);
            }
        }


        /// <summary>
        /// Waits for any of the WebElements in the IList to become clickable.
        /// </summary>
        /// <param name="elements">The IList of WebElements to wait for.</param>
        /// <returns>The first clickable WebElement within the timeout period; otherwise, null.</returns>
        public IWebElement WaitForElementToBeClickable(IList<IWebElement> elements)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };

                // Selenium 4 native lambda instead of ExpectedConditions
                var ele = wait.Until(d =>
                {
                    try
                    {
                        var first = elements.FirstOrDefault();
                        return (first != null && first.Displayed && first.Enabled) ? first : null;
                    }
                    catch
                    {
                        return null;
                    }
                });

                return ele;
            }
            catch (Exception e)
            {
                TakesScreenshot(null);
                TestContext.Progress.WriteLine(e);
                return null;
            }
        }



        public bool getElementDisplayWithoutWait(IWebElement ele, string msg)
        {
            bool eleDisplay = false;

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };

                // Selenium 4 native lambda instead of ExpectedConditions
                wait.Until(d =>
                {
                    try
                    {
                        return (ele != null && ele.Displayed && ele.Enabled);
                    }
                    catch
                    {
                        return false;
                    }
                });

                eleDisplay = true;
            }
            catch (NoSuchElementException e)
            {
                TakesScreenshot(msg);
                TestContext.Progress.WriteLine("getElementDisplayWithoutWait method threw: " + e);
                Reporting.failureLog(e.Message);
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                TestContext.Progress.WriteLine("Unexpected error: " + e);
                Reporting.failureLog(e.Message);
            }

            return eleDisplay;
        }



        public void moveToElement(IWebElement ele)
        {
            try
            {
                WaitForElementToBeClickable(ele);
                Actions action = new Actions(driver);
                action.MoveToElement(ele).Perform();
            }
            catch (Exception e)
            {
                TakesScreenshot(null);
                TestContext.Progress.WriteLine(e);
            }

        }

        public void JsClick(IWebElement element, string Msg)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                JsMoveTo(element);
                JsHighlight(element);
                js.ExecuteScript("arguments[0].click();", element);
                TestContext.Progress.WriteLine("Successfully Clicked: " + Msg);
                Reporting.successLog("Successfully Clicked: " + Msg);
                waitForLoadingBarToCompleteinSeconds();
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("JS click failed: " + ex.Message);
                Reporting.successLog("JS click failed: " + ex.Message);
                throw new Exception("JS click failed: " + ex.Message);
            }
        }

        public void js_ClickObj(IWebElement js_element, string msg)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].style.display='block'", js_element);
                js.ExecuteScript("arguments[0].click();", js_element);
                highlight_obj(js_element);
                WaitForElementToBeClickable(js_element);
                js_element.Click();
                CaptureScreenshot(true);
                js.ExecuteScript("arguments[0].style.display='none'", js_element);
                TestContext.Progress.WriteLine("Successfully Clicked " + msg);
                Reporting.successLog("Successfully Clicked " + msg);
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count;
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to Click " + msg);
                Reporting.failureLog("Failure to Click " + msg);
                Assert.Fail("Failure to Click " + msg);
            }

        }

        public void JsHighlight(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].style.border='3px solid red'", element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Highlight failed: " + ex.Message);
            }
        }

        public void JsMoveTo(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                highlight_obj(element);
                // Scroll into view
                js.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);

                // Focus the element
                js.ExecuteScript("arguments[0].focus();", element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("JS move-to failed: " + ex.Message);
            }
        }

        public void highlight_obj(IWebElement ele)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", ele);
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e);
            }

        }

        public void clear_highlight(IWebElement ele)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].setAttribute('style', '');", ele);
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine(e);
                Reporting.failureLog(e.Message);
            }
        }


        // Get Element Display
        public bool getLocatorDiaplay(By locator, string msg)
        {
            bool eleDisplay = false;
            try
            {
                IWebElement ele = WaitForElementToBeClickable(locator);
                eleDisplay = ele.Displayed;
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Successfully element display " + msg);
                Reporting.successLog("Successfully element display " + msg);
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to  display element " + msg);
                Assert.Fail("Failure to  display element " + msg + " " + e.Message);
                Reporting.failureLog("Failure to  display element " + msg);
            }
            return eleDisplay;
        }

        //Get Element Display
        public void verifyElementDisplay(IWebElement ele, string msg)
        {
            try
            {
                WaitForElementToBeClickable(ele);
                highlight_obj(ele);
                HandleVerification(ele.Displayed, msg);
                //CaptureScreenshot(true);
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine(e.Message);
                Reporting.failureLog(e.Message);
            }
        }

        public void HandleVerification(bool isDisplayed, string msg)
        {
            if (isDisplayed)
            {
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Successfully element display " + msg);
                Reporting.successLog("Successfully element display " + msg);

            }
            else
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Failure to  display element " + msg);
                Reporting.failureLog("Failure to  display element " + msg);
                //Assert.IsTrue(isDisplayed, "Failure to  display element " + msg);
                Assert.That(isDisplayed, Is.True, "Failure to display element " + msg);
            }
        }

        public void verifyElementText(IWebElement ele, string text)
        {
            try
            {
                WaitForElementToBeClickable(ele);
                highlight_obj(ele);
                HandleVerification(ele.Displayed, text);
                //CaptureScreenshot(true);
            }
            catch (Exception e)
            {
                TakesScreenshot(text);
                //CaptureScreenshot(true);
                Reporting.failureLog("Text are not matching: " + text);
                TestContext.Progress.WriteLine(e.Message);
                Assert.Fail("Text are not matching: " + text);
            }

        }

        public void verifyElementTextContains(IWebElement ele, string text)
        {
            WaitForElementToBeClickable(ele);
            HandleVerification(ele.Text.Contains(text), text);
        }

        public void verifyElementTextEqual(IWebElement ele, string text)
        {
            WaitForElementToBeClickable(ele);
            HandleVerification(ele.Text.Equals(text), text);
        }

        public bool getElementDiaplayWithoutWait(IWebElement ele, string msg)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };

                // Selenium 4 native lambda instead of ExpectedConditions
                wait.Until(d =>
                {
                    try
                    {
                        return (ele != null && ele.Displayed && ele.Enabled);
                    }
                    catch
                    {
                        return false;
                    }
                });

                sw.Stop();
                TestContext.Progress.WriteLine("Element displayed for " + sw.ElapsedMilliseconds + "ms.");
                return true;
            }
            catch (Exception e)
            {
                sw.Stop();
                TakesScreenshot(msg);
                TestContext.Progress.WriteLine("Element not found after " + sw.ElapsedMilliseconds + "ms.");
                TestContext.Progress.WriteLine("Error" + e);
                Reporting.failureLog(e.Message);
                return false;
            }
        }


        public void WaitElementToBeVisible(By locator)
        {
            try
            {
                var sw = Stopwatch.StartNew();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };

                // Selenium 4 native lambda instead of ExpectedConditions
                wait.Until(d =>
                {
                    try
                    {
                        var element = d.FindElement(locator);
                        return element != null && element.Displayed;
                    }
                    catch
                    {
                        return false;
                    }
                });

                // If you want to log timing, uncomment:
                // TestContext.Progress.WriteLine($"Waited {sw.Elapsed} for element {locator}");
            }
            catch (Exception e)
            {
                TakesScreenshot(null);
                TestContext.Progress.WriteLine(e.Message);
                Reporting.failureLog(e.Message);
            }
        }


        public void WaitForElementToBeInVisible(By ele)
        {
            try
            {
                var sw = Stopwatch.StartNew();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };

                // Selenium 4 native lambda instead of ExpectedConditions.InvisibilityOfElementLocated
                wait.Until(d =>
                {
                    try
                    {
                        var element = d.FindElement(ele);
                        return !element.Displayed; // invisible when NOT displayed
                    }
                    catch (NoSuchElementException)
                    {
                        return true; // element not in DOM = invisible
                    }
                    catch
                    {
                        return false;
                    }
                });

                // Optional timing log:
                // TestContext.Progress.WriteLine($"Waited {sw.Elapsed} for element {ele} to become invisible");
            }
            catch (Exception e)
            {
                TakesScreenshot(null);
                TestContext.Progress.WriteLine(e.Message);
                Reporting.failureLog(e.Message);
            }
        }


        public void clickRadioBtn(IWebElement ele, string msg)
        {
            try
            {
                highlight_obj(ele);
                ele.Click();
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Successfully Selected " + msg);
                Reporting.successLog("Successfully Selected " + msg);
            }
            catch (Exception e)
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(false);
                TestContext.Progress.WriteLine("Failure to Select " + msg);
                Reporting.failureLog("Failure to Select " + msg);
                Assert.Fail("Failure to Select " + msg + " " + e.Message);
            }
        }

        public void isObjSelected(IWebElement ele, string msg)
        {
            //Boolean isSelected = driver.FindElement(By.XPath("(//input [@data-sdi='387842' and @type='radio'])[2]")).Selected;
            highlight_obj(ele);
            Boolean isSelected = ele.Selected;

            if (isSelected == true)

            {
                TestContext.Progress.WriteLine("Element is Selected and it is: " + isSelected + " :and object is: " + msg);
                Reporting.successLog("Element is Selected and it is: " + isSelected + " :and object is: " + msg);
                //CaptureScreenshot(true);
                Assert.Pass("Element is Selected and it is: " + isSelected + " :and object is: " + msg);
            }
            else
            {
                TakesScreenshot(msg);
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Element is not Selected and Value is: " + isSelected + " :and object is: " + msg);
                Reporting.failureLog("Element is not Selected Screenshot");
                Assert.Fail("Element is not Selected and Value is: " + isSelected + " :and object is: " + msg);
            }
        }

        public void verifyElementTextNotContains(IWebElement ele, string text)
        {
            WaitForElementToBeClickable(ele);
            HandleVerification(!ele.Text.Contains(text), text);

        }

        public void HandleExtraWindowPopupIfPresent_locator(string item, By locatorClick)
        {
            // Try to find the element safely
            IWebElement popupElement = null;

            try
            {
                popupElement = driver.FindElement(locatorClick);
            }
            catch (NoSuchElementException)
            {
                TestContext.Progress.WriteLine("Element identifier passed to HandlePopupIfPresent() was blank or null");
                return;
            }

            // If element exists, follow your exact logic
            if (popupElement != null && popupElement.Displayed)
            {
                moveToElement(popupElement);
                ClickObj(popupElement, "Window Pop-Up");
            }
            else
            {
                TestContext.Progress.WriteLine("Element identifier passed to HandlePopupIfPresent() was blank or null");
            }
        }


        #region new methods
        /// <summary>
        /// This method is used to check if the specified element is present on the page
        /// </summary>
        /// <param name="by"></param>
        /// <returns>True/False based on element prence within current IFRAME.</returns>

        public bool isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                // CaptureScreenshot(true);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                TakesScreenshot(null);
                // CaptureScreenshot(true);
                TestContext.Out.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// This method is used to check if the specified IWebElement is present on the page
        /// </summary>
        /// <param name="IWebElement"></param>
        /// <returns>True/False based on element prence within current IFRAME.</returns>

        public bool isIWebElementPresent(IWebElement ele)
        {
            try
            {
                // (Note: I think this is causing issue in pipeline)if you want to use this method then uncomment this method from TestElementManipulation but this is causing issue in pipeline.
                // CaptureScreenshot(true);
                return ele.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                TakesScreenshot(null);
                //CaptureScreenshot(true);
                Console.Write(ex);
                return false;
            }
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                var elements = driver.FindElements(locator);
                return elements.Count > 0 && elements[0].Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Element not found: {ex.Message}");
                return false;
            }
        }

        public bool IsElementPresentJs(By locator)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                string script = @"
            var locatorType = arguments[0];
            var locatorValue = arguments[1];
            var element = null;

            if (locatorType === 'xpath') {
                var result = document.evaluate(locatorValue, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null);
                element = result.singleNodeValue;
            } else if (locatorType === 'css') {
                element = document.querySelector(locatorValue);
            }

            return element !== null && element.offsetParent !== null;
        ";

                string locatorType = locator.ToString().StartsWith("By.XPath") ? "xpath" : "css";
                string locatorValue = locator.ToString().Replace("By.XPath: ", "").Replace("By.CssSelector: ", "");

                var result = (bool)js.ExecuteScript(script, locatorType, locatorValue);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"JS check failed: {ex.Message}");
                return false;
            }
        }




        public void SwitchToIframe()
        {
            // Find the iframe element by its ID
            IWebElement iframeElement = driver.FindElement(By.Id("G1IFrame"));

            // Switch to the iframe
            driver.SwitchTo().Frame(iframeElement);
            //CaptureScreenshot(true);
        }

        public bool IsElementPresent_forDPRO(IWebElement element)
        {
            try
            {
                //Check if the element is present and visible using JavaScript
                bool isPresent = (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                    "return arguments[0] != null && arguments[0].offsetHeight > 0", element);
                //CaptureScreenshot(true);
                return isPresent;
            }
            catch (NoSuchElementException ex)
            {
                // CaptureScreenshot(true);
                TestContext.Progress.WriteLine(ex);
                Reporting.failureLog(ex.Message);
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// This method is used to click on IWebelement by using "By" locator, bypass the moveto requirement.
        /// </summary>
        /// <param name="locator"></param>
        public void ClickOnElement(By locator)
        {
            WaitForElementToBeClickable(locator);
            driver.FindElement(locator).Click();
            //CaptureScreenshot(true);
            int count = waitForLoadingBarToCompleteinSeconds();
            totalLoadingTime += count;
        }

        /// <summary>
        /// This method is used to click on IWebelement by using "By" locator, bypass the moveto requirement.
        /// </summary>
        /// <param name="locator"></param>
        public void ClickOnElementOnlyForIcons(By locator)
        {
            driver.FindElement(locator).Click();
            // CaptureScreenshot(true);
            pauseExecution(300);
            int count = waitForLoadingBarToCompleteinSeconds();
            totalLoadingTime += count;
        }


        /// <summary>
        /// Gets list of Iframes within current view. 
        /// </summary>
        public IList<IWebElement> GetListIFrames()
        {
            IList<IWebElement> iframes = driver.FindElements(By.XPath("//iframe"));
            return iframes;
        }

        /// <summary>
        /// Gets all dropdown elements. 
        /// </summary>
        public int GetNumIFrames()
        {
            return driver.FindElements(By.XPath("//iframe")).Count();
        }

        /// <summary>
        /// Switch to Iframe, by frame id, frame num, or frame name
        /// </summary>
        public void SwitchToIframe(string method, int index, string frame)
        {
            switch (method.ToLower())
            {
                case "id":
                    //uses WebElement frame by frame id
                    driver.SwitchTo().Frame(index);
                    break;

                case "num":
                    //uses WebElement frame by frameNumber
                    driver.SwitchTo().Frame(index);
                    break;

                default:
                    //uses WebElement frame by name
                    driver.SwitchTo().Frame(frame);
                    break;
            }
        }

        /// <summary>
        /// Automatically switches to Iframe based on input element. 
        /// </summary>
        public void SwitchToIframeHoldingElement(By name)
        {
            //We need to switch to parent first. 
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(driver.FindElement(name));
        }

        /// <summary>
        /// Determine if loading bar is present in view. 
        /// Regular methods like isPresent, is cliackable, and isDisplayed will not always work by themselves. 
        /// </summary>
        /// <returns>True/False. We Mask NoSuchElementException when progress bar is not present.</returns>
        public Boolean isLoadingBarPresent()
        {
            //return driver.FindElements(By.XPath("//*[contains(@class, 'pace-running')]"));
            return driver.FindElements(By.XPath("//*[contains(@class, 'pace-active')]")).Count > 0;
        }

        /// <summary>
        /// Wait for loading bar to leave view, and for the done condition to trigger within ithe body of the page. 
        /// </summary>
        public void waitForLoadingBarToComplete()
        {
            if (isLoadingBarPresent())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Selenium 4 native lambda instead of ExpectedConditions.VisibilityOfAllElementsLocatedBy
                wait.Until(d =>
                {
                    try
                    {
                        var elements = d.FindElements(By.XPath("//*[contains(@class, 'pace-done')]"));
                        return elements != null && elements.Count > 0 && elements.All(e => e.Displayed);
                    }
                    catch
                    {
                        return false;
                    }
                });
            }
        }


        /// <summary>
        /// Get all items in a parent container, expand and collapse them. 
        /// </summary>
        public void GetAllparentlistClosedNodeandExpand(IList<IWebElement> elements, IList<IWebElement> Xpath)
        {
            // below codes are clicking and expanding links within management center blade if these all links are not expanded/opened
            if (elements == null)
            {
                elements = Xpath;
            }

            foreach (var item in elements)
            {
                string ParentText = GetElementText(item, "Parent text is: " + item.Text);
                TestContext.Progress.WriteLine("Parent text is: " + ParentText);
                TestContext.Progress.WriteLine("Total Parent links are: " + elements.Count);
                WaitForElementToBeClickable(item);
                moveToElement(item);
                highlight_obj(item);
                //CaptureScreenshot(true);
                item.Click();
            }
        }

        /// <summary>
        /// Get all items in a Child container, expand and collapse them. 
        /// </summary>
        /// 
        public void GetAllChildList(IList<IWebElement> elements)
        {
            // below line is to get total child links
            IList<IWebElement> NoOfChildLinks_2loopThru = elements; ;
            TestContext.Progress.WriteLine("Total Number of Child Links to Loop Through are: " + NoOfChildLinks_2loopThru.Count);
            //Reporting.infoLog("Total Number of Child Links to Loop Through are: " + NoOfChildLinks_2loopThru.Count);
        }

        /// <summary>
        /// Expand Managenment Blade If this is not expanded when Landing on the main page. 
        /// </summary>
        /// 



        /// <summary>
        /// Wait for loading bar to leave view, and for the done condition to trigger within the body of the page.  
        /// </summary>
        public int waitForLoadingBarToCompleteinSeconds()
        {
            int count = 0;
            if (isLoadingBarPresent())
            {
                while (isLoadingBarPresent() == true && count <= 500)
                {
                    Thread.Sleep(1000);
                    TestContext.Progress.WriteLine("Waiting For Loading Bar To Complete becasue Bar is Present and Second waited are: " + count);
                    count++;
                }
            }
            //// After the loop, check if the loading bar is still present.
            //if (isLoadingBarPresent())
            //{
            //    Assert.Fail("Loading bar did not complete within the timeout of 120 seconds.");
            //    return -1; // Return a special value (-1) to indicate timeout.
            //}

            return count; // Return the number of seconds waited
        }
        public int getTotalLoadingTime()
        {

            return totalLoadingTime;
        }

        /// <summary>
        /// Determine if Red PopUp error is present in view.  
        /// <returns>True/False. We Mask NoSuchElementException when progress Red PopUp error is not present.</returns>
        /// </summary>
        public Boolean isRedPopUpErrorPresent()
        {
            //return driver.FindElements(By.XPath("//*[contains(@class, 'pace-running')]"));
            return driver.FindElements(By.XPath("//button[@class='toast-close-button']")).Count > 0;
        }

        /// <summary>
        /// Wait for loading bar to leave view, and for the done condition to trigger within the body of the page.  
        /// </summary>
        public void waitForRedPopUpErrorToDisappearCompletely()
        {
            int count = 0;
            if (isRedPopUpErrorPresent())
            {
                while (isRedPopUpErrorPresent() == true && count <= 75)
                {
                    Thread.Sleep(1000);
                    TestContext.Progress.WriteLine("Waiting For Red PopUp Error to disappear completely and Second waited are: " + count);
                    count++;
                }
            }
        }

        /// <summary>
        /// Determine if Red PopUp error is present in view.  
        /// <returns>True/False. We Mask NoSuchElementException when progress Red PopUp error is not present.</returns>
        /// </summary>
        public Boolean IsErrorToastPresent()
        {
            return driver.FindElements(By.XPath("//*[@class='toast toast-error']")).Count > 0;
        }

        /// <summary>
        /// Handle Error Popup and log scrrenshot.  
        /// Maditory: eleClick(close button IWebElement) Optional: item(string name used for logging)
        ///</summary>
        public void HandleErrorPopupIfPresent(string item, IWebElement eleClick)
        {
            bool errorHandled = false;

            while (IsErrorToastPresent())
            {
                if (!errorHandled)
                {
                    // CaptureScreenshot(true);
                    Reporting.failureLog("Red pop Up appeared for: " + item);
                    Assert.Fail("Red pop Up appeared for: " + item);
                    TestContext.Progress.WriteLine("Red pop Up appeared for: " + item);
                    errorHandled = true; // Set the flag to true to indicate that the error has been handled
                }

                pauseExecution(500);
                ClickObj(eleClick, " Close popup");
                WaitUntilErrorPopupDisapeard();
            }
        }

        public int WaitUntilErrorPopupDisapeard()
        {
            int count = 0;
            while (isRedPopUpErrorPresent() && count <= 5)
            {
                Thread.Sleep(1000);
                TestContext.Progress.WriteLine("Waiting For RedPop to disappear: " + count);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Handle Popup by identifier for popup, popup btn, and item name.  
        /// Maditory: eleClick(close button IWebElement), eleIdentifier(close popup IWebElement, Optional: item(string name used for logging)
        ///</summary>
        public void HandleExtraWindowPopupIfPresent(string item, IWebElement eleClick)
        {
            if (isIWebElementPresent(eleClick))
            {
                moveToElement(eleClick);
                ClickObj(eleClick, "Window Pop-Up");
            }
            else
            {
                TestContext.Progress.WriteLine("element identifier passed to HandlePopupIfPresent() was blank or null");
            }
        }

        public void HandleExtraWindowsPopupIfPresent(string item, IList<IWebElement> eleClicks)
        {
            foreach (var eleClick in eleClicks)
            {
                if (isIWebElementPresent(eleClick))
                {
                    moveToElement(eleClick);
                    ClickObj(eleClick, item);
                }
                else
                {
                    TestContext.Progress.WriteLine("element identifier passed to HandlePopupIfPresent() was blank or null");
                }
            }
        }




        /// <summary>
        /// Checks if item is clickable and then proceeds to click all items in IWebList.  
        ///</summary>
        public void clickAllIWebElements(IList<IWebElement> elements)
        {
            foreach (IWebElement item in elements)
            {
                //Check if item is clickable, and click if true
                try
                {
                    if (item.Displayed)
                    {
                        waitForLoadingBarToCompleteinSeconds();
                        highlight_obj(item);
                        item.Click();
                        // CaptureScreenshot(true);
                        int count = waitForLoadingBarToCompleteinSeconds();
                        totalLoadingTime += count;
                    }
                }
                catch (Exception e)
                {
                    //CaptureScreenshot(true);
                    TestContext.Progress.WriteLine("Red pop Up appeard for: " + item);
                    Reporting.failureLog("Red pop Up appeard for: " + item);
                    Assert.Fail("Pop Up appeard for: " + item);
                    pauseExecution(2000);
                    ClickObj(item, "Successfully Clicked on Close PopUp button");
                }
            }
        }

        /// <summary>
        /// Determine if Welcome is present in view.  
        /// <returns>True/False. We Mask NoSuchElementException when not present.</returns>
        /// </summary>
        public Boolean IsWelcomePresent()
        {
            return driver.FindElements(By.XPath("//*[contains(text(), 'Welcome ') and not(contains(text(), 'Welcome to CMAST.'))]")).Count > 0;
        }

        public int WaitUntilWelcomeMessageDisappeard()
        {

            int count = 0;
            while (IsWelcomePresent() && count <= 30)
            {
                Thread.Sleep(1000);
                TestContext.Progress.WriteLine("Waiting For Welcome Message to disappear: " + count);
                count++;
            }

            return count;

        }

        public Boolean IsRedPopUpPrent()
        {
            return driver.FindElements(By.XPath("//div[@id='toast-container'] | //button[@class='bootbox-close-button close']")).Count > 0;
        }

        /// <summary>
        /// Handle will scroll to the element (LeftRight) 
        /// Maditory: Just pass the element locator.
        ///</summary>
        public void ScrollToElement(IWebElement ele)
        {
            highlight_obj(ele);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", ele);

        }

        public Boolean IsWarningPopUpPresent()
        {
            return driver.FindElements(By.XPath("//*[@id='toast-container']//div[@class='toast-message']")).Count > 0;
        }



        /// <summary>
        ///  Generates an absolute XPath of a given element using a JavaScript function, 
        ///  which provides a reliable and unique way to locate the element on a webpage.
        /// </summary>
        /// <param name="element">The IWebElement to generate the XPath for.</param>
        /// <returns>The XPath in a dynamic fashion.</returns>

        public string GetElementXPath(IWebElement element)
        {
            string script = @"
        function getPathTo(element) {
            if (element.tagName === 'HTML') return '/HTML[1]';
            if (element === document.body) return '/HTML[1]/BODY[1]';
            var ix = 0;
            var siblings = element.parentNode.childNodes;
            for (var i = 0; i < siblings.length; i++) {
                var sibling = siblings[i];
                if (sibling === element) return getPathTo(element.parentNode) + '/' + element.tagName + '[' + (ix + 1) + ']';
                if (sibling.nodeType === 1 && sibling.tagName === element.tagName) ix++;
            }
        }
        return getPathTo(arguments[0]);";

            return ((IJavaScriptExecutor)driver).ExecuteScript(script, element).ToString();
        }

        /// <summary>
        /// Retrieves all data "header and body rows" from a table on a given page based on the input CSS selector. 
        /// </summary>
        /// <param name="cssSelector">The CSS selector to locate the table element.</param>
        /// <param name="inputCount">The maximum number of rows to return from the table. If null, all rows will be returned.</param>
        /// <returns>A list of string arrays, where each array represents a row of data from the table.</returns>
        public List<string[]> GetTableData(string cssSelector, int? inputCount = null)
        {
            // Check if the CSS selector is present on the page
            bool isCssSelectorPresent = driver.FindElements(By.CssSelector(cssSelector)).Count > 0;

            // Click the search button if the CSS selector is not present
            if (!isCssSelectorPresent)
            {
                IWebElement search = driver.FindElement(By.CssSelector("button[class*='entity-search-button']"));
                search.Click();
            }

            // Wait for the table element to be present and visible on the page
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            // Selenium 4 native lambda instead of ExpectedConditions.VisibilityOfAllElementsLocatedBy
            IList<IWebElement> tables = wait.Until(d =>
            {
                try
                {
                    var found = d.FindElements(By.CssSelector(cssSelector));
                    return (found != null && found.Count > 0 && found.All(e => e.Displayed)) ? found : null;
                }
                catch
                {
                    return null;
                }
            });

            // Find the header row in the first table
            IList<IWebElement> headerRow = tables[0].FindElements(By.CssSelector("thead tr"))
                .Where(row => row.FindElements(By.CssSelector("th")).Any())
                .ToList();

            // Find the body rows in the second table
            IList<IWebElement> bodyRows = tables[1].FindElements(By.CssSelector("tbody tr"))
                .Where(row => row.FindElements(By.CssSelector("td")).Any())
                .ToList();

            if (inputCount != null)
            {
                bodyRows = bodyRows.Take((int)inputCount).ToList();
            }

            // Combine header + body
            IList<IWebElement> allRows = headerRow.Concat(bodyRows).ToList();

            // Create a list to hold the table data
            List<string[]> tableData = new List<string[]>();

            // Loop through each row and get the data from each cell
            foreach (IWebElement row in allRows)
            {
                IList<IWebElement> cells = row.FindElements(By.CssSelector("th, td"));
                string[] rowData = new string[cells.Count];

                for (int i = 0; i < cells.Count; i++)
                {
                    rowData[i] = cells[i].Text;
                }

                tableData.Add(rowData);
            }

            return tableData;
        }


        public bool IsExpanded(IWebElement element)
        {
            return element.GetAttribute("aria-expanded") == "true";
        }

        /// <summary>
        /// Scrolls to the specified element using JavaScript and moves the cursor to the element using Actions.
        /// </summary>
        /// <param name="ele">The WebElement to scroll to and move the cursor to.</param>
        public void ScrollAndMoveToElement(IWebElement ele)
        {
            try
            {
                highlight_obj(ele);
                TestContext.Progress.WriteLine("Scrolled to Element");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                // Scroll to the element using JavaScript
                js.ExecuteScript("arguments[0].scrollIntoView({ block: 'center', inline: 'center' });", ele);

                // Move to the element using Actions
                Actions action = new Actions(driver);
                action.MoveToElement(ele).Perform();
            }
            catch (Exception e)
            {
                TakesScreenshot(null);
                Reporting.failureLog(e.Message);
                TestContext.Progress.WriteLine(e);

            }
        }

        /// <summary>
        /// Selects an option from a dropdown list by index and returns the selected option's text.
        /// </summary>
        /// <param name="options">The list of options in the dropdown.</param>
        /// <param name="index">The index of the option to select.</param>
        /// <returns>The text of the selected option.</returns>
        /// example = string selectedOptionText = SelectOptionByIndex(p3CaseGrid.AddCase_IWebElement, 1);
        public string SelectOptionByIndex(IList<IWebElement> options, int index)
        {
            if (index >= 0 && index < options.Count)
            {
                string optionText = options[index].Text;
                options[index].Click(); // Replace this line with your desired interaction
                                        //CaptureScreenshot(true);                        // Reporting.successLog("Successfully Clicked: " + options[index].Text);
                                        // (Note: I think this is causing issue in pipeline)if you want to use this method then uncomment this method from TestElementManipulation but this is causing issue in pipeline.
                                        //CaptureScreenshot();
                return optionText;
            }
            else
            {
                Reporting.failureLog("Invalid index specified.");
                throw new ArgumentOutOfRangeException("Invalid index specified.");
            }
        }

        /// <summary>
        /// Selects an option from a custom dropdown list by visible text.
        /// Re-fetches dropdown options after opening to avoid stale element reference errors.
        /// </summary>
        /// <param name="dropdownToggle">The WebElement that toggles the dropdown open.</param>
        /// <param name="optionLocator">The locator used to find the dropdown option elements after it is opened.</param>
        /// <param name="textToSelect">The visible text of the option to select.</param>
        /// <returns>True if the option was found and selected; otherwise, false.</returns>
        /// here are the xpath used for example etrackerhrp
        ///         [FindsBy(How = How.XPath, Using = "//div[@class='search-section']//b[@role='presentation']")]
        ///         public IWebElement MultiSearchBlade_SearchesDropDown_Arrow;
        ///public By MultiSearchBlade_SearchesDropDown_Options = By.XPath("//ul[@class='select2-results__options']//li");
        public bool SelectFromCustomDropdownByText(IWebElement dropdownToggle, By optionLocator, string textToSelect)
        {
            try
            {
                moveToElement(dropdownToggle);
                highlight_obj(dropdownToggle);
                dropdownToggle.Click();
                //CaptureScreenshot(true);
                pauseExecution(500);

                var options = driver.FindElements(optionLocator);

                foreach (var option in options)
                {
                    if (option.Text.Trim().Equals(textToSelect, StringComparison.OrdinalIgnoreCase))
                    {
                        highlight_obj(option);
                        ScrollAndMoveToElement(option);
                        ClickObj(option, option.Text);
                        pauseExecution(500);
                        TestContext.Progress.WriteLine("Successfully selected: " + option.Text + " From Dropdown");
                        Reporting.successLog("Successfully selected: " + option.Text + " From Dropdown");
                        //CaptureScreenshot(true);
                        return true;
                    }
                }
            }
            catch
            {
                // Do nothing or log minimal info if needed
            }

            return false;
        }

        public bool SelectFromCustomDropdownByTextcontain(IWebElement dropdownToggle, By optionLocator, string textToSelect)
        {
            try
            {
                highlight_obj(dropdownToggle);
                dropdownToggle.Click();
                //CaptureScreenshot(true);
                pauseExecution(1000);

                var options = driver.FindElements(optionLocator);

                foreach (var option in options)
                {
                    if (option.Text.Trim().IndexOf(textToSelect, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        highlight_obj(option);
                        ScrollAndMoveToElement(option);
                        option.Click();
                        pauseExecution(1000);
                        TestContext.Progress.WriteLine("Successfully selected: " + option.Text + " From Dropdown");
                        Reporting.successLog("Successfully selected: " + option.Text + " From Dropdown");
                        //CaptureScreenshot(true);
                        return true;
                    }
                }
            }
            catch
            {
                // Do nothing or log minimal info if needed
            }

            return false;
        }

        public bool SelectDropDownCheckboxOptionByIndex(IWebElement dropdownToggle, By optionsLocator, int index)
        {
            try
            {
                // Open the dropdown
                highlight_obj(dropdownToggle);
                dropdownToggle.Click();
                pauseExecution(1000);

                // Get all options
                var options = driver.FindElements(optionsLocator);

                if (index >= 0 && index < options.Count)
                {
                    var option = options[index];
                    highlight_obj(option);
                    option.Click(); // Select checkbox at given index
                    TestContext.Progress.WriteLine($"Selected option {index}: {option.Text}");
                    Reporting.successLog($"Selected option {index}: {option.Text}");
                    return true;
                }

                TestContext.Progress.WriteLine("Invalid index: " + index);
                return false;
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("Error: " + ex.Message);
                return false;
            }
        }



        /// <summary>
        /// Selects multiple options from a checkbox-style dropdown by visible text.
        /// Re-fetches dropdown options after opening to avoid stale element reference errors.
        /// </summary>
        /// <param name="dropdownToggle">The WebElement that toggles the dropdown open.</param>
        /// <param name="optionLocator">The locator used to find the checkbox option elements after the dropdown is opened.</param>
        /// <param name="textsToSelect">A list of visible texts to select.</param>
        /// <returns>True if all options were found and selected; otherwise, false.</returns>
        public bool SelectMultipleCheckboxOptions(IWebElement dropdownToggle, By optionsLocator, List<string> textsToSelect)
        {
            try
            {
                // Open the dropdown
                highlight_obj(dropdownToggle);
                dropdownToggle.Click();
                //CaptureScreenshot(true);
                pauseExecution(1000);

                var lowercaseTargets = textsToSelect.Select(t => t.Trim().ToLower()).ToList();
                int selectedCount = 0;

                // Re-fetch the options every time in case of stale elements
                var options = driver.FindElements(optionsLocator);

                foreach (var target in lowercaseTargets)
                {
                    foreach (var option in options)
                    {
                        string optionText = option.Text.Trim().ToLower();
                        if (optionText.Contains(target))
                        {
                            highlight_obj(option);
                            option.Click(); // Click to select the checkbox
                            selectedCount++;
                            TestContext.Progress.WriteLine("Selected: " + option.Text);
                            Reporting.successLog("Selected: " + option.Text);
                            // CaptureScreenshot(true);
                            break; // Move to the next target
                        }
                    }
                }

                return selectedCount == textsToSelect.Count;
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool IsCellContainingValue(IWebElement cell)
        {
            try
            {
                string cellText = cell.Text.Trim();
                return !string.IsNullOrEmpty(cellText) && cellText != "-" && cellText.ToLower() != "n/a";
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("Error checking cell value: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Unchecks all selected checkbox-style options from a dropdown.
        /// </summary>
        /// <param name="dropdownToggle">Element to click to open the dropdown.</param>
        /// <param name="optionsLocator">Locator for the checkbox option elements.</param>
        public void UncheckAllSelectedCheckboxOptions(IWebElement dropdownToggle, By optionsLocator)
        {
            try
            {
                ClickObj(dropdownToggle, "Board Members Present dropdown");
                pauseExecution(1000); // Give time for dropdown to open

                var options = driver.FindElements(optionsLocator);

                foreach (var option in options)
                {
                    string optionText = option.Text.Trim();
                    TestContext.Progress.WriteLine($"option Text is: : '{optionText}'");

                    string classAttr = option.GetAttribute("class");
                    TestContext.Progress.WriteLine($"class Attr is: : '{classAttr}'");

                    string ariaChecked = option.GetAttribute("aria-selected");
                    TestContext.Progress.WriteLine($"aria Checked Attr is: : '{ariaChecked}'");

                    bool isSelected = classAttr.Contains("selected") || ariaChecked == "true";

                    if (isSelected)
                    {
                        ClickObj(option, option.Text);
                        TestContext.Progress.WriteLine($"✅ Unchecked selected option: '{optionText}'");
                        Reporting.successLog($"Unchecked selected option: '{optionText}'");
                        pauseExecution(300); // Small delay for UI to update after unchecking
                    }
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("❌ Error in UncheckAllSelectedCheckboxOptions: " + ex.Message);
                Reporting.failureLog("Error in UncheckAllSelectedCheckboxOptions: " + ex.Message);
                Assert.Fail("Error in UncheckAllSelectedCheckboxOptions: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles switching to a new browser window, closing it if it exists, and then switching back to the main window.
        /// </summary>
        public void HandleNewBrowserWindow()
        {
            // Get the handle of the main browser window
            string mainHandle = driver.CurrentWindowHandle;

            // Get the handle of the new browser window
            string newHandle = GetNewWindowHandle();

            if (!string.IsNullOrEmpty(newHandle))
            {
                // Switch to the new browser window
                driver.SwitchTo().Window(newHandle);

                // Close the new browser window
                driver.Close();
                //CaptureScreenshot(true);
            }

            // Switch back to the main browser window
            driver.SwitchTo().Window(mainHandle);
            //CaptureScreenshot(true);

            // Continue with the remaining execution in the main browser window
            // ...
        }

        /// <summary>
        /// Retrieves the handle of the new browser window.
        /// </summary>
        /// <returns>The handle of the new browser window.</returns>
        public string GetNewWindowHandle()
        {
            // Get the window handles of all open windows
            IReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            // Find the new window handle by excluding the main handle
            string newHandle = windowHandles.FirstOrDefault(handle => handle != driver.CurrentWindowHandle);

            return newHandle;
        }


        /// <summary>
        /// Waits for the print window to appear for a specified maximum timeout.
        /// If the print window does not appear within the specified timeout, it throws an exception.
        /// </summary>
        /// <param name="maxTimeoutInSeconds">The maximum timeout to wait for the print window to appear (default is 70 seconds).</param>
        public void WaitForPrintWindowToAppear(int maxTimeoutInSeconds = 70)
        {
            int currentTimeoutInSeconds = 0;
            bool printWindowAppeared = false;

            while (!printWindowAppeared && currentTimeoutInSeconds <= maxTimeoutInSeconds)
            {
                try
                {
                    // Check if the print window has appeared by counting the window handles
                    if (driver.WindowHandles.Count == 2)
                    {
                        printWindowAppeared = true;
                    }
                    else
                    {
                        // Wait for another second before checking again
                        currentTimeoutInSeconds++;
                        TestContext.Progress.WriteLine($"Print window did not appear yet, waiting for another second {currentTimeoutInSeconds}...");
                        Thread.Sleep(1000);
                    }
                }
                catch (WebDriverException)
                {
                    // Catch any WebDriverException (e.g., if the window is still in the process of opening)
                    currentTimeoutInSeconds++;
                    TestContext.Progress.WriteLine($"Print window did not appear yet, waiting for another second {currentTimeoutInSeconds}...");
                    Thread.Sleep(1000);
                }
            }


            if (!printWindowAppeared)
            {
                // Reporting.failureLog("Print window did not appear within the specified timeout.");
                // Throw an exception if the print window did not appear within the specified timeout
                Assert.Fail("Print window did not appear within the specified timeout.");
                Reporting.failureLog("Print window did not appear within the specified timeout.");
                return;
            }

        }

        /// <summary>
        /// Handles a scenario where a new window may appear and switches back to the main window.
        /// This method assumes that there are two open windows, with the main window as the current window.
        /// It identifies the new window, closes it, and switches back to the main window.
        /// </summary>
        public void HandleNewWindowAndSwitchBack()
        {
            string mainWindowHandle = driver.CurrentWindowHandle;
            string newWindowHandle = null;

            // Get a list of all window handles
            IList<string> allWindowHandles = driver.WindowHandles;

            // Check if there are multiple window handles
            if (allWindowHandles.Count > 1)
            {
                // Identify the new window handle
                foreach (string handle in allWindowHandles)
                {
                    if (handle != mainWindowHandle)
                    {
                        newWindowHandle = handle;
                        break;
                    }
                }

                // Switch to the new window
                driver.SwitchTo().Window(newWindowHandle);
                // CaptureScreenshot(true);

                // Close the new window
                driver.Close();
                // CaptureScreenshot(true);

                // Switch back to the main window
                driver.SwitchTo().Window(mainWindowHandle);
                // CaptureScreenshot(true);
            }
        }



        public Boolean isToolTipPresent()
        {
            //return driver.FindElements(By.XPath("//*[contains(@class, 'pace-running')]"));
            return driver.FindElements(By.XPath("//div[@class='tooltip-inner']")).Count > 0;
        }

        public int WaitUntilToolTipDisapeard()
        {
            int count = 0;
            while (isToolTipPresent() && count <= 5)
            {
                Thread.Sleep(1000);
                TestContext.Progress.WriteLine("Waiting For ToolTip to disappear: " + count);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Handles browser alerts (pop-up dialogs) by logging and failing the test if an unexpected alert appears.
        /// </summary>
        /// <remarks>
        /// This method checks if an alert is present and, if so, logs the failure message and fails the test.
        /// It handles the case where no alert is present without logging or failing.
        /// </remarks>
        public void HandleAlert()
        {
            try
            {
                // Check if the alert is present without waiting
                IAlert alert = driver.SwitchTo().Alert();

                // Get the alert text (optional)
                string alertText = alert.Text;
                pauseExecution(2000);
                alert.Accept(); // To accept the alert (click OK)
                                // CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Test failed due to unexpected alert. Alert Text: " + alertText);
                Reporting.failureLog("Test failed due to unexpected alert. Alert Text: " + alertText);
                Assert.Fail("Test failed due to unexpected alert. Alert Text: " + alertText);
            }
            catch (NoAlertPresentException)
            {
                // Do nothing if no alert is present
            }
        }

        public void HandleETPIncompleteChecklistAlert()
        {

            bool IsETPIncompleteChecklistAlertPresent = isElementPresent(By.XPath("//div[@class='bootbox-body']"));
            // Check if the alert window is present
            if (IsETPIncompleteChecklistAlertPresent)
            {
                IWebElement alertWindow = driver.FindElement(By.XPath("//div[@class='bootbox-body']"));
                // Get the text of the alert window
                string alertWindowText = alertWindow.Text;
                TestContext.Progress.WriteLine("Alert Text: " + alertWindowText);

                // Find and click the OK button
                IWebElement okButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary bootbox-accept']"));
                TestContext.Progress.WriteLine("ETP Incomplete Checklist Alert Appeared");
                //Reporting.warningLog("ETP Incomplete Checklist Alert Appeared");
                okButton.Click();
                // CaptureScreenshot(true);

            }

        }

        /// <summary>
        /// Generates a random number between the specified range and returns it 
        /// formatted to match the style of a given example string (e.g., "$1,000.00").
        /// </summary>
        /// <param name="formatExample">
        /// A sample string that defines the desired output format. The method detects
        /// elements such as:
        /// - "$" → Prefixes the output with a dollar sign.
        /// - "," → Includes thousand separators.
        /// - ".00" → Displays two decimal places.
        /// Examples:
        /// - "$1,000.00" → Outputs values like "$743.25"
        /// - "1,000" → Outputs values like "523"
        /// - "1000.00" → Outputs values like "857.00"
        /// - "$1000" → Outputs values like "$412"
        /// </param>
        /// <param name="min">
        /// The minimum integer value (inclusive) for random generation. Default is 100.
        /// </param>
        /// <param name="max">
        /// The maximum integer value (inclusive) for random generation. Default is 1000.
        /// </param>
        /// <returns>
        /// A string containing the randomly generated number formatted to match 
        /// the structure of <paramref name="formatExample"/>.
        /// </returns>
        /// <example>
        /// string randomValue = GenerateRandomFormattedValue("$1,000.00");
        /// // Example output: "$845.00"
        /// </example>

        private static readonly Random random = new Random();

        public string GenerateRandomFormattedValue(string formatExample, int min = 100, int max = 1000)
        {
            // Generate random value
            double value = random.Next(min, max + 1);

            // Detect if the example has a currency symbol
            bool hasDollar = formatExample.Contains("$");

            // Detect if decimals are present
            bool hasDecimals = formatExample.Contains(".00");

            // Determine number formatting style (with commas or not)
            bool hasComma = formatExample.Contains(",");

            string formattedValue;

            // Build formatting pattern dynamically
            if (hasDollar)
            {
                if (hasComma && hasDecimals)
                    formattedValue = value.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")); // $1,000.00
                else if (hasComma)
                    formattedValue = "$" + value.ToString("#,0", CultureInfo.InvariantCulture);         // $1,000
                else
                    formattedValue = "$" + value.ToString("0", CultureInfo.InvariantCulture);           // $1000
            }
            else
            {
                if (hasComma && hasDecimals)
                    formattedValue = value.ToString("#,0.00", CultureInfo.InvariantCulture);            // 1,000.00
                else if (hasComma)
                    formattedValue = value.ToString("#,0", CultureInfo.InvariantCulture);               // 1,000
                else if (hasDecimals)
                    formattedValue = value.ToString("0.00", CultureInfo.InvariantCulture);              // 1000.00
                else
                    formattedValue = value.ToString("0", CultureInfo.InvariantCulture);                 // 1000
            }

            return formattedValue;
        }

        public string GenerateRandomPhrase()
        {
            string[] subjects = { "This", "That", "It", "Value", "Data", "Item" };
            string[] verbs = { "is", "was", "used", "made", "prepared", "kept" };
            string[] prepositions = { "for", "in", "as", "while", "during" };
            string[] nouns = { "Testing", "Validation", "Automation", "Demo", "Execution", "Checking" };

            string phrase = $"{subjects[random.Next(subjects.Length)]} {verbs[random.Next(verbs.Length)]} {prepositions[random.Next(prepositions.Length)]} {nouns[random.Next(nouns.Length)]}";
            return phrase;
        }

        public string GenerateRandomText(int wordCount = 4)
        {
            string[] words = { "Test", "Data", "Value", "Random", "Check", "Automation", "For", "Demo", "Run", "Sample", "Verify", "Process", "Input", "Case", "Execution" };

            var result = new List<string>();

            for (int i = 0; i < wordCount; i++)
            {
                string word = words[random.Next(words.Length)];
                result.Add(word);
            }

            // Capitalize first word and join with spaces
            string sentence = string.Join(" ", result);
            return char.ToUpper(sentence[0]) + sentence.Substring(1);
        }

        public static string GenerateRandomAlphaNumeric()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            int length = random.Next(3, 8); // 3 to 7 inclusive

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GenerateRandomNumber(int digits)
        {
            if (digits <= 0)
                throw new ArgumentException("Digits must be greater than zero.");

            // First digit cannot be zero
            Random rnd = new Random();
            char firstDigit = (char)rnd.Next('1', '9' + 1);

            // Remaining digits can be 0–9
            char[] number = new char[digits];
            number[0] = firstDigit;

            for (int i = 1; i < digits; i++)
            {
                number[i] = (char)rnd.Next('0', '9' + 1);
            }

            return new string(number);
        }

        public int GenerateRandomNumberInt(int digits)
        {
            if (digits <= 0 || digits > 9)
                throw new ArgumentException("Digits must be between 1 and 9 for int output.");

            Random rnd = new Random();

            // First digit: 1–9
            int firstDigit = rnd.Next(1, 10);

            int number = firstDigit;

            // Remaining digits: 0–9
            for (int i = 1; i < digits; i++)
            {
                number = number * 10 + rnd.Next(0, 10);
            }

            return number;
        }



        public void ClickRandomly()
        {
            Random random = new Random();
            Actions actions = new Actions(driver);

            // Generate random coordinates on the page
            int randomX = random.Next(0, driver.Manage().Window.Size.Width);
            int randomY = random.Next(0, driver.Manage().Window.Size.Height);

            // Perform the random click using Actions class
            actions.MoveByOffset(randomX, randomY).Click().Perform();
            TestContext.Progress.WriteLine("Randomly Clicked");
        }

        /// <summary>
        /// Displays a popup with a custom message and pauses execution until OK is clicked.
        /// </summary>
        /// <param name="message">The message to display in the popup.</param>
        public void ShowPopup(string message = "")
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Execution Paused";
            }

            MessageBox.Show(
                message,
                "Execution Paused",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

       public static bool _shown = false;

        public static void ShowPopupOnce(string message = "")
        {
            if (_shown) return;   // skip if already shown

            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Execution Paused";
            }

            MessageBox.Show(
                message,
                "Execution Paused",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            _shown = true;  // mark as shown
        }














        //************************Common Methods*********************************



        public void checkRefreshIcon()
        {
            if (isLoadingBarPresent())
            {
                TestContext.Progress.WriteLine("Refresh Icon Worked Successfully");
                int count = waitForLoadingBarToCompleteinSeconds();
                totalLoadingTime += count;
            }
            else
            {
                TestContext.Progress.WriteLine("Refresh Icon did not work");
                Reporting.failureLog("Refresh Icon did not work");
                Assert.Fail("Refresh Icon did not work");
            }
        }

        public void WaitUntilColumnRowAppears(int FilterSearchInputIndax)
        {
            bool columnrowAppeard = isElementPresent(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[contains(@id,'DataTables_Table')]/tbody/tr[1]/td[" + (FilterSearchInputIndax + 1) + "]"));

            if (!columnrowAppeard)
            {
                int counts = 0;
                do
                {
                    Thread.Sleep(1000);
                    TestContext.Progress.WriteLine("Waiting for column row to appear: " + counts);
                    counts++;
                    columnrowAppeard = isElementPresent(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[contains(@id,'DataTables_Table')]/tbody/tr[1]/td[" + (FilterSearchInputIndax + 1) + "]"));
                } while (!columnrowAppeard && counts <= 15);

                if (columnrowAppeard)
                {
                    int count = waitForLoadingBarToCompleteinSeconds();
                    totalLoadingTime += count;
                }
            }
        }



        public void checkIfManagementBladeClickedAndHaveLinks()
        {
            //below line is to get total child links
            IList<IWebElement> NoOfChildLinks_2loopThru = driver.FindElements(By.XPath("//div[contains(@class, 'command-center-component') and contains(@class, 'active')]//a[@class='treeitem-node wb-node wb-node-without-children']"));
            TestContext.Progress.WriteLine("Total Number of Child Links to Loop Through are: " + NoOfChildLinks_2loopThru.Count);

            if (NoOfChildLinks_2loopThru.Count == 0)
            {
                TestContext.Progress.WriteLine("Seems like Management blade was not clicked");
                //Reporting.warningLog("Seems like Management blade was not clicked");
                Assert.Warn("Seems like Management blade was not clicked");
            }

        }


        public void closeNewOpenBrowerandSwitchToFirstBrowser(IWebElement element)
        {
            IList<string> windowHandles = driver.WindowHandles;
            TestContext.Progress.WriteLine("Total windows are: " + windowHandles.Count);
            TestContext.Progress.WriteLine("Window names are: " + windowHandles);

            if (windowHandles.Count == 2)
            {
                string currentWindowHandle = driver.CurrentWindowHandle;

                driver.SwitchTo().Window(windowHandles[1]);
                bool errorDisplayed = getElementDisplay(element, "Server Error");
                TestContext.Progress.WriteLine("Is error displayed or not: " + errorDisplayed);

                if (errorDisplayed)
                {
                    string text = GetElementText(element, "Error message");
                    TestContext.Progress.WriteLine("Text is: " + text);

                    if (text.Contains("error"))
                    {
                        //  CaptureScreenshot(true);
                        Reporting.failureLog("New page contains error");
                        Assert.Fail("New page contains error");
                        // Or throw a specific exception if you want to stop execution immediately.
                    }
                }
                else
                {
                    // CaptureScreenshot(true);
                    TestContext.Progress.WriteLine("Second Page appeared correctly");
                }

                // Close the second window and switch back to the original window.
                driver.Close();
                driver.SwitchTo().Window(currentWindowHandle);
            }
        }

        public void handleErrorMessage(string element)
        {
            MainLandingPage landingpage = new MainLandingPage(driver);
            bool errormessage = isElementPresent(landingpage.redPopupErrorMessage_locator);
            bool redpopup_closeBtn = isElementPresent(landingpage.redPopUpCloseBtn_locator);

            if (errormessage && redpopup_closeBtn)
            {
                TestContext.Progress.WriteLine("toast-error received for: " + element);

                if (redpopup_closeBtn)
                {
                    //CaptureScreenshot(true);
                    landingpage.closeIconOnPopup.Click();
                    //CaptureScreenshot(true);
                }
                Reporting.failureLog("toast-error received for: " + element);
                Assert.Fail("toast-error received for: " + element);
            }
            else if (errormessage && !redpopup_closeBtn)
            {
                int count = 0;

                while (errormessage && count <= 7)
                {
                    pauseExecution(1000);
                    TestContext.Progress.WriteLine("Waiting For Error Message to disappear: " + count);
                    count++;
                    errormessage = isElementPresent(landingpage.redPopupErrorMessage_locator);
                }
                // CaptureScreenshot(true);
                Reporting.failureLog("toast-error received for: " + element);
                Assert.Fail("toast-error received for: " + element);
            }
        }




        public void SelectFirstOption(IList<IWebElement> dropdownList)
        {
            // Define regex patterns for single alphabetic or numeric values
            string singleAlphabetPattern = @"^[a-zA-Z]$";  // Matches a single alphabetic character
            string singleNumericPattern = @"^\d$";          // Matches a single numeric character

            // First, check if any option contains "NGB" (case-insensitive)
            foreach (var option in dropdownList)
            {
                string optionText = option.Text.Trim();

                // Proceed only if the optionText is not null or empty and contains "NGB" (case-insensitive)
                if (!string.IsNullOrEmpty(optionText) && optionText.IndexOf("NGB", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // If an option contains "NGB", select it and log the selection
                    option.Click();
                    //CaptureScreenshot(true);
                    TestContext.Progress.WriteLine($"Option selected: '{optionText}' (contains 'NGB')");
                    return; // Exit the method once the option is selected
                }
            }

            // If no option containing "NGB" is found, proceed with skipping invalid options
            if (dropdownList != null && dropdownList.Count > 0)
            {
                foreach (var option in dropdownList)
                {
                    string optionText = option.Text.Trim();

                    // Skip if the option is a single alphabetic or a single numeric value
                    if (!Regex.IsMatch(optionText, singleAlphabetPattern) && !Regex.IsMatch(optionText, singleNumericPattern))
                    {
                        // Click on the valid option and log the selection
                        option.Click();
                        // CaptureScreenshot(true);
                        TestContext.Progress.WriteLine($"Option selected: '{optionText}'");
                        return; // Exit once a valid option is selected
                    }
                }

                // If no valid option is found, log a message
                TestContext.Progress.WriteLine("No valid option found to select.");
                //CaptureScreenshot(true);
            }
            else
            {
                TestContext.Progress.WriteLine("Dropdown list is empty or null, cannot select an option.");
            }
        }

        public string SelectRandomOption(IList<IWebElement> options)
        {
            if (options == null || options.Count == 0)
            {
                TestContext.Progress.WriteLine("❌ Failed to select an option: No options available.");
                Reporting.failureLog("Failed to select an option: No options available.");
                return null;
            }

            var random = new Random();
            int index = random.Next(options.Count);
            string selectedText = options[index].Text;

            try
            {
                options[index].Click();
                waitForLoadingBarToCompleteinSeconds();
                TestContext.Progress.WriteLine($"✅ Selected option: {selectedText}");
                Reporting.successLog($"Selected option: {selectedText}");
                return selectedText;
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"❌ Could not click on option: {selectedText}. Error: {ex.Message}");
                Reporting.failureLog($"Click failed for option: {selectedText}. Error: {ex.Message}");
                return null;
            }
        }



        public string SelectRandomOptionStartingFromIndex1(IList<IWebElement> options)
        {
            if (options.Count <= 1)
            {
                throw new InvalidOperationException("There are not enough options to select from.");
            }

            Random random = new Random();
            int randomIndex = random.Next(1, options.Count);

            string optionText = options[randomIndex].Text;
            options[randomIndex].Click(); // Replace this line with your desired interaction
            //CaptureScreenshot(true);
            return optionText;
        }


        //public void HandleRedPopUp_Updated(string element)
        //{
        //    ReportBladeValidation reportBlade = new ReportBladeValidation(driver);
        //    Panel2IconsValidationPage reportingIcons = new Panel2IconsValidationPage(driver);
        //    RedPopUpPage RedPopUpPage = new RedPopUpPage(driver);

        //    bool errormessage = isIWebElementPresent(RedPopUpPage.ToastError);
        //    bool redpopup_closeBtn = isElementPresent(reportingIcons.redPopUpCloseBtn_locator);

        //    if (errormessage && redpopup_closeBtn)
        //    {
        //        TestContext.Progress.WriteLine("toast-error received for: " + element);
        //        //Reporting.infoLog("toast-error received for: " + element);

        //        // Keep clicking the close button while it is present
        //        while (redpopup_closeBtn)
        //        {
        //            reportBlade.closeIconOnPopup.Click();
        //            pauseExecution(500);  // Small delay to allow UI to update
        //            redpopup_closeBtn = isElementPresent(reportingIcons.redPopUpCloseBtn_locator); // Re-check for close button presence
        //        }

        //        Assert.Fail("toast-error received for: " + element);
        //        Reporting.failureLog("toast-error received for: " + element);
        //        Assert.Fail("toast-error received for: " + element);
        //    }
        //    else if (errormessage && !redpopup_closeBtn)
        //    {
        //        int count = 0;

        //        while (errormessage && count <= 7)
        //        {
        //            pauseExecution(1000);
        //            TestContext.Progress.WriteLine("Waiting For Error Message to disappear: " + count);
        //            // Reporting.infoLog("Waiting For Error Message to disappear: " + count);
        //            count++;
        //            errormessage = isElementPresent(reportingIcons.redPopupErrorMessage_locator);
        //        }

        //        Reporting.failureLog("toast-error received for: " + element);
        //        Assert.Fail("toast-error received for: " + element);
        //    }
        //}

        public bool IsElementEnabled(IWebElement element)
        {
            try
            {
                highlight_obj(element);
                // CaptureScreenshot(true);
                // Return whether the element is enabled
                return element.Enabled;
            }
            catch (NoSuchElementException e)
            {
                Reporting.failureLog(e.Message);
                // CaptureScreenshot(true);
                return false;
            }
        }


        /// <summary>
        /// Captures the text of each dropdown option before and after selecting it, 
        /// and verifies that the correct option was selected.
        /// </summary>
        /// <param name="selectElement">The select element containing the options.</param>
        /// <returns>True if the selected option matches the option captured before selection, false otherwise.</returns>
        public bool ValidateDropdownOptionSelection(IWebElement selectElement, IWebElement ApplyButton)
        {
            try
            {
                // Find all the options from the select list
                var options = selectElement.FindElements(By.TagName("option"));

                // Loop through each option and select it, then verify the selected option
                for (int i = 0; i < options.Count; i++)
                {
                    // Capture the text before selecting the option
                    string optionTextBeforeSelect = options[i].Text.Trim();
                    TestContext.Progress.WriteLine($"Captured before selection: '{optionTextBeforeSelect}'");
                    Reporting.successLog($"Captured before selection: '{optionTextBeforeSelect}'");

                    // Select the option
                    options[i].Click();
                    // CaptureScreenshot(true);
                    ApplyButton.Click();
                    //CaptureScreenshot(true);
                    waitForLoadingBarToCompleteinSeconds();
                    // Capture the selected option text after selection
                    SelectElement select = new SelectElement(selectElement);
                    string selectedOptionText = select.SelectedOption.Text.Trim();
                    TestContext.Progress.WriteLine($"Captured after selection: '{selectedOptionText}'");

                    // Verify if the selected option matches the one before selection
                    if (!optionTextBeforeSelect.Equals(selectedOptionText, StringComparison.OrdinalIgnoreCase))
                    {
                        TestContext.Progress.WriteLine($"Mismatch after selecting option {i + 1}: Expected '{optionTextBeforeSelect}', but got '{selectedOptionText}'");
                        // CaptureScreenshot(true);
                        return false;
                    }

                    TestContext.Progress.WriteLine($"Option '{selectedOptionText}' was selected correctly.");
                    pauseExecution(3000);
                }

                // If all options match, return true
                TestContext.Progress.WriteLine("All options were selected and verified successfully.");
                return true;
            }
            catch (Exception e)
            {
                Reporting.failureLog("An error occurred during the dropdown selection validation: " + e.Message);
                TestContext.Progress.WriteLine("An error occurred during the dropdown selection validation: " + e.Message);
                return false;
            }
        }



        public void ValidateElementText(IWebElement element, string expectedText)
        {
            Assert.Multiple((Action)(() =>
            {
                ScrollAndMoveToElement(element);
                highlight_obj(element);
                // Capture the text of the provided element
                string actualText = element.Text.Trim();
                // CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Captures Text is: " + actualText);
                Reporting.successLog("Captures Text is: " + actualText);
                // Compare and assert
                if (actualText.Equals(expectedText))
                {
                    TestContext.Progress.WriteLine($"✅ Text matches. Captured text is:  '{actualText}' and expected text is: '{expectedText}'");
                    Reporting.successLog($"✅ Text matches. Captured text is:  '{actualText}' and expected text is: '{expectedText}'");
                }
                else
                {
                    //CaptureScreenshot(false);
                    TestContext.Progress.WriteLine($"❌ Text mismatch! Expected: '{expectedText}', Actual: '{actualText}'");
                    Reporting.failureLog($"❌ Text mismatch! Expected: '{expectedText}', Actual: '{actualText}'");
                    Assert.Fail($"❌ Text mismatch! Expected: '{expectedText}', Actual: '{actualText}'");
                }
            }));
        }

        public void ValidateElementTextContain(IWebElement element, string expectedText)
        {
            Assert.Multiple((Action)(() =>
            {
                ScrollAndMoveToElement(element);
                highlight_obj(element);
                // Capture the text of the provided element
                string actualText = element.Text.Trim();
                // CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Captures Text is: " + actualText);
                highlight_obj(element);
                Reporting.successLog("Captures Text is: " + actualText);
                // Compare and assert
                if (actualText.Contains(expectedText))
                {
                    TestContext.Progress.WriteLine($"✅ Text matches: '{actualText}'");
                    Reporting.successLog($"✅ Text matches: '{actualText}'");
                }
                else
                {
                    //CaptureScreenshot(false);
                    TestContext.Progress.WriteLine($"❌ Text mismatch! Expected: '{expectedText}', Actual: '{actualText}'");
                    Reporting.failureLog($"❌ Text mismatch! Expected: '{expectedText}', Actual: '{actualText}'");
                    Assert.Fail($"❌ Text mismatch! Expected: '{expectedText}', Actual: '{actualText}'");
                }
            }));
        }

        public void VerifyElementIsDisplayed(IWebElement element, string elementName)
        {

            if (element.Displayed)
            {
                //CaptureScreenshot(true);
                highlight_obj(element);
                Reporting.successLog($"✅ '{elementName}' is displayed.");
                TestContext.Progress.WriteLine($"✅ '{elementName}' is displayed.");
            }
            else
            {
                // CaptureScreenshot(false);
                TestContext.Progress.WriteLine($"❌ '{elementName}' is not displayed.");
                Reporting.failureLog($"'{elementName}' is not displayed.");
                Assert.Fail($"'{elementName}' is not displayed.");
            }

        }

        public void VerifyElementText(IWebElement element, string expectedText)
        {
            try
            {
                string actualText = element.Text.Trim();
                // CaptureScreenshot(true);
                if (actualText.Contains(expectedText))
                {
                    Console.WriteLine($"✅ Text matches. Expected: '{expectedText}', Actual: '{actualText}'");
                    TestContext.Progress.WriteLine($"✅ Text matches. Expected: '{expectedText}', Actual: '{actualText}'");
                    highlight_obj(element);
                    Reporting.successLog($"✅ Text matches. Expected: '{expectedText}', Actual: '{actualText}'");
                }
                else
                {
                    //CaptureScreenshot(false);
                    Console.WriteLine($"❌ Text mismatch. Expected: '{expectedText}', Actual: '{actualText}'");
                    TestContext.Progress.WriteLine($"❌ Text mismatch. Expected: '{expectedText}', Actual: '{actualText}'");
                    Reporting.failureLog($"❌ Text mismatch. Expected: '{expectedText}', Actual: '{actualText}'");
                    Assert.Fail($"❌ Text mismatch. Expected: '{expectedText}', Actual: '{actualText}'");
                }
            }
            catch (Exception ex)
            {
                // Catch any unexpected failure (element not found, stale, etc.)
                // CaptureScreenshot(false);
                Console.WriteLine($"❌ Exception occurred while verifying text: {ex.Message}");
                TestContext.Progress.WriteLine($"❌ Exception occurred while verifying text: {ex.Message}");
                Reporting.failureLog($"❌ Exception occurred while verifying text: {ex.Message}");

                Assert.Fail($"❌ Exception occurred while verifying text: {ex.Message}");
            }
        }


        public void VerifyTableLabels(IList<IWebElement> actualLabels, string[] expectedLabels)
        {

            Assert.Multiple((Action)(() =>
            {
                if (actualLabels.Count != expectedLabels.Length)
                {
                    //throw new Exception($"Label count mismatch: Expected {expectedLabels.Length}, but found {actualLabels.Count}.");
                    Reporting.failureLog($"Label count mismatch: Expected {expectedLabels.Length}, but found {actualLabels.Count}.");
                    Assert.Fail($"Label count mismatch: Expected {expectedLabels.Length}, but found {actualLabels.Count}.");
                }

                for (int i = 0; i < actualLabels.Count; i++)
                {
                    ScrollAndMoveToElement(actualLabels[i]);
                    highlight_obj(actualLabels[i]);
                    string actualText = actualLabels[i].Text.Trim();
                    //CaptureScreenshot(true);
                    string expectedText = expectedLabels[i].Trim();
                    // CaptureScreenshot(true);

                    if (actualText.Equals(expectedText, StringComparison.OrdinalIgnoreCase))
                    {
                        TestContext.Progress.WriteLine($"✅ Match: '{actualText}' matches expected '{expectedText}'.");
                        TestContext.Progress.WriteLine($"✅ Match: '{actualText}' matches expected '{expectedText}'.");
                        Reporting.successLog($"✅ Match: '{actualText}' matches expected '{expectedText}'.");
                    }
                    else
                    {
                        // CaptureScreenshot(false);
                        TestContext.Progress.WriteLine($"❌ Mismatch: Actual '{actualText}', Expected '{expectedText}'.");
                        Reporting.failureLog($"Mismatch at position {i + 1}: Actual '{actualText}', Expected '{expectedText}'.");
                        //throw new Exception($"Label verification failed at position {i + 1}.");
                        Assert.Fail($"Mismatch at position {i + 1}: Actual '{actualText}', Expected '{expectedText}'.");
                    }
                }
            }));
        }

        /// <summary>
        /// Scrolls horizontally through a tab list and clicks the tab with the specified name
        /// once it becomes visible and clickable. Attempts up to 10 scrolls.
        /// </summary>
        /// <param name="tabName">The visible text of the tab to click.</param>
        /// <param name="tabsLocator">The locator for all tab elements.</param>
        /// <param name="scrollRightLocator">The locator for the scroll-right button.</param>
        /// <exception cref="Exception">Throws if the tab is not found after scrolling.</exception>
        public void ClickTabWhenVisible(string tabName, By tabLocator, By rightScrollLocator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool tabFoundAndClicked = false;

            for (int i = 0; i < 10; i++) // max 10 scrolls
            {
                var tabs = driver.FindElements(tabLocator);

                foreach (var tab in tabs)
                {
                    var text = tab.Text?.Trim();
                    if (!string.IsNullOrEmpty(text) &&
                        text.Equals(tabName, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            ScrollElementIntoView(tab); // Force scroll into view using JS

                            // Selenium 4 native lambda instead of ExpectedConditions
                            wait.Until(d =>
                            {
                                try
                                {
                                    return tab.Displayed && tab.Enabled;
                                }
                                catch
                                {
                                    return false;
                                }
                            });

                            tab.Click();
                            handleErrorMessage("Clicking on tab: " + text);
                            tabFoundAndClicked = true;
                            break;
                        }
                        catch (Exception ex)
                        {
                            TestContext.Progress.WriteLine($"Tab '{text}' found but not clickable: " + ex.Message);
                        }
                    }
                }

                if (tabFoundAndClicked)
                    break;

                // Try to scroll right
                try
                {
                    IWebElement rightScroll = wait.Until(driver => driver.FindElement(rightScrollLocator));
                    if (rightScroll.Displayed && rightScroll.Enabled)
                    {
                        rightScroll.Click();
                        Thread.Sleep(500); // allow UI to update
                    }
                    else
                    {
                        break; // No more scrolling possible
                    }
                }
                catch
                {
                    break; // Right arrow not found, stop trying
                }
            }

            if (!tabFoundAndClicked)
            {
                TestContext.Progress.WriteLine($"Tab '{tabName}' not found or not clickable after scrolling.");
                Reporting.failureLog($"Tab '{tabName}' not found or not clickable after scrolling.");
                throw new Exception($"Tab '{tabName}' not found or not clickable after scrolling.");
            }
        }


        private void ScrollElementIntoView(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView({inline: 'center'});", element);
        }


        // Utility to check if element is fully in viewport using JavaScript
        public bool IsElementInViewport(IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;
            return (bool)js.ExecuteScript(
                @"var rect = arguments[0].getBoundingClientRect();
          return (
            rect.top >= 0 &&
            rect.left >= 0 &&
            rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
            rect.right <= (window.innerWidth || document.documentElement.clientWidth)
          );", element);
        }



        /// <summary>
        /// Verifies that a list of elements are vertically aligned (from top to bottom) on the page.
        /// It compares the Y-axis (vertical position) of each element to ensure the next one appears below the previous one.
        /// </summary>
        /// <param name="elements">A list of IWebElement items you want to verify for vertical alignment.</param>
        public void VerifyElementsAreVerticallyAligned(IList<IWebElement> elements)
        {
            TestContext.Progress.WriteLine("🔍 Starting vertical alignment check for the listed elements...");

            if (elements == null || elements.Count == 0)
            {
                TestContext.Progress.WriteLine("⚠️ No elements found to check alignment.");
                Assert.Fail("Element list is empty or null.");
            }

            // Assume they are aligned until we find an issue
            bool isVerticallyAligned = true;

            // Get the Y position of the first element
            int previousY = elements[0].Location.Y;
            TestContext.Progress.WriteLine($"📌 Element 0 Y-position: {previousY}");

            // Loop through all elements starting from the second
            for (int i = 1; i < elements.Count; i++)
            {
                int currentY = elements[i].Location.Y;
                TestContext.Progress.WriteLine($"📌 Element {i} Y-position: {currentY}");

                // Check if the current element is below the previous one
                if (currentY <= previousY)
                {
                    TestContext.Progress.WriteLine($"❌ Element {i} is NOT below Element {i - 1}. Vertical alignment broken.");
                    isVerticallyAligned = false;
                }
                else
                {
                    TestContext.Progress.WriteLine($"✅ Element {i} is correctly positioned below Element {i - 1}.");
                }

                previousY = currentY;
            }

            // Final result logging and test outcome
            if (isVerticallyAligned)
            {
                TestContext.Progress.WriteLine("🎯 All elements are vertically aligned from top to bottom.");
            }
            else
            {
                TestContext.Progress.WriteLine("❌ One or more elements are not in vertical order.");
                Assert.Fail("Vertical alignment validation failed.");
            }
        }


        public void ClickElementMultipleTimes(By locator, int times)
        {
            for (int i = 0; i < times; i++)
            {
                driver.FindElement(locator).Click();
                Thread.Sleep(300); // Optional: gives UI time to update
            }
        }

        public void ClickUntilTabVisibleAndClick(By arrowLocator, IWebElement tabElement, string TabName, int maxClicks = 20)
        {
            int clicks = 0;
            bool tabVisible = false;

            // First, check if arrow exists
            bool arrowExists = driver.FindElements(arrowLocator).Count > 0;

            while (clicks < maxClicks)
            {
                try
                {
                    if (tabElement.Displayed && tabElement.Enabled && IsElementFullyClickable(tabElement))
                    {
                        tabElement.Click();
                        waitForLoadingBarToCompleteinSeconds();
                        tabVisible = true;
                        Console.WriteLine($"✅ Found and clicked the {TabName} Successfully.");
                        TestContext.Progress.WriteLine($"✅ Found and clicked the {TabName} Successfully.");
                        Reporting.infoLogWithSS($"✅ Found and clicked the {TabName} Successfully.");
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    // Tab not in DOM yet, skip
                }
                catch (ElementClickInterceptedException)
                {
                    // Just keep clicking arrow until it becomes clickable
                }
                catch (ElementNotInteractableException)
                {
                    // Just keep clicking arrow until it becomes clickable
                }

                if (arrowExists && driver.FindElements(arrowLocator).Count > 0)
                {
                    driver.FindElement(arrowLocator).Click();
                    Thread.Sleep(300); // Give UI time to shift
                }
                else
                {
                    // No arrow present; break to avoid infinite loop
                    break;
                }

                clicks++;
            }

            if (!tabVisible)
            {
                TestContext.Progress.WriteLine($"❌ Tab {TabName} was not found after {maxClicks} arrow clicks.");
                Reporting.failureLog($"❌ Tab {TabName} was not found after {maxClicks} arrow clicks.");
                throw new Exception($"❌ Tab was not found after {maxClicks} arrow clicks.");
            }
        }

        // Helper to check if element is fully clickable on screen
        private bool IsElementFullyClickable(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (bool)js.ExecuteScript(@"
        var rect = arguments[0].getBoundingClientRect();
        return (
            rect.top >= 0 &&
            rect.left >= 0 &&
            rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
            rect.right <= (window.innerWidth || document.documentElement.clientWidth)
        );
    ", element);
        }


        public void ClickElementsIfAvailable(IList<IWebElement> elements, string msg)
        {
            if (elements != null && elements.Count > 0)
            {
                foreach (IWebElement element in elements)
                {

                    if (element.Displayed && element.Enabled)
                    {
                        ClickObj(element, msg);
                        Thread.Sleep(500);
                    }

                }
            }

        }

        public string GetCurrentDateInCustomFormat()
        {
            string currentDate = DateTime.Now.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            TestContext.Progress.WriteLine($"Current date: {currentDate}");
            Reporting.infoLog("Current Date: " + currentDate);
            return currentDate;
        }

        /// <summary>
        /// Returns the current date formatted according to the specified format string.
        /// </summary>
        /// <param name="format">
        /// A valid .NET date format string. For example:
        /// - "MM/dd/yyyy" → 06/16/2025
        /// - "dd-MM-yyyy" → 16-06-2025
        /// - "yyyyMMdd" → 20250616
        /// - "MMddyyyy" → 06162025 
        /// - "dd MMM yyyy" → 16 Jun 2025
        /// - "MMMM dd, yyyy" → June 16, 2025
        /// Note: Use "MM" for month and "mm" for minutes (case-sensitive).
        /// </param>
        /// <returns>The current date as a string formatted according to the provided format.</returns>
        /// <example>
        /// string currentDate = GetCurrentDateInCustomFormat("MM/dd/yyyy");
        /// </example>
        public string GetCurrentDateInCustomFormat(string format)
        {
            try
            {
                string currentDate = DateTime.Now.ToString(format, CultureInfo.InvariantCulture);
                TestContext.Progress.WriteLine($"Current date ({format}): {currentDate}");
                Reporting.infoLog($"Current date ({format}): {currentDate}");
                return currentDate;
            }
            catch (FormatException ex)
            {
                string errorMessage = $"Invalid date format: '{format}'. Error: {ex.Message}";
                TestContext.Progress.WriteLine(errorMessage);
                Reporting.infoLog(errorMessage);
                return null;
            }
        }


        /// <summary>
        /// Converts a date string from one format to another.
        /// </summary>
        /// <param name="inputDate">The original date string (e.g., "16 JUN 2025").</param>
        /// <param name="inputFormat">The current format of the input date (e.g., "dd MMM yyyy").</param>
        /// <param name="outputFormat">The desired output format (e.g., "MM/dd/yyyy").</param>
        /// <returns>Formatted date string in the desired format.</returns>
        /// <example>
        /// string result = ConvertDateFormat("16 JUN 2025", "dd MMM yyyy", "MM/dd/yyyy"); 
        /// Output: "06/16/2025"
        /// </example>
        public string ConvertDateFormat(string inputDate, string inputFormat, string outputFormat)
        {
            try
            {
                DateTime parsedDate = DateTime.ParseExact(inputDate, inputFormat, CultureInfo.InvariantCulture);
                return parsedDate.ToString(outputFormat, CultureInfo.InvariantCulture).ToUpper();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Date format error: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Selects a specific date from a calendar widget that uses dropdowns for month and year selection.
        /// </summary>
        /// <param name="calendarIcon">The WebElement that opens the calendar popup (e.g., a calendar icon or input field).</param>
        /// <param name="monthDropdownElement">The dropdown WebElement for selecting the month (e.g., shows "Jul", "Aug").</param>
        /// <param name="yearDropdownElement">The dropdown WebElement for selecting the year (e.g., shows "2024").</param>
        /// <param name="dateString">Target date in "MMddyyyy" format (e.g., "07082025" for July 8, 2025).</param>
        public void SelectDateFromCalendar(IWebElement calendarIcon, IWebElement monthDropdownElement, IWebElement yearDropdownElement, string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "MMddyyyy", CultureInfo.InvariantCulture);

            // Click the calendar icon to open the popup
            calendarIcon.Click();
            waitForLoadingBarToCompleteinSeconds();

            // Format the values needed
            string shortMonth = date.ToString("MMM", CultureInfo.InvariantCulture); // e.g., "Jul"
            string year = date.Year.ToString();
            string day = date.Day.ToString(); // e.g., "8"

            // Select Month
            SelectElement monthSelect = new SelectElement(monthDropdownElement);
            monthSelect.SelectByText(shortMonth);
            pauseExecution(500);

            // Select Year
            SelectElement yearSelect = new SelectElement(yearDropdownElement);
            yearSelect.SelectByText(year);
            pauseExecution(500);

            // Automatically construct XPath for the day
            string dayXPath = $"//td/a[normalize-space(text())='{day}']";

            // Click the Day
            IWebElement dayElement = driver.FindElement(By.XPath(dayXPath));
            dayElement.Click();
            waitForLoadingBarToCompleteinSeconds();
        }

        public void SelectDateFromCalendarByLocator(IWebElement calendarIcon, By monthDropdownLocator, By yearDropdownLocator, string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "MMddyyyy", CultureInfo.InvariantCulture);

            // Click the calendar icon to open the popup
            calendarIcon.Click();
            waitForLoadingBarToCompleteinSeconds();

            // Format the values needed
            string shortMonth = date.ToString("MMM", CultureInfo.InvariantCulture); // e.g., "Jul"
            string year = date.Year.ToString();
            string day = date.Day.ToString(); // e.g., "8"

            // Select Month - Found dynamically after opening to prevent stale element reference
            IWebElement monthDropdownElement = driver.FindElement(monthDropdownLocator);
            SelectElement monthSelect = new SelectElement(monthDropdownElement);
            monthSelect.SelectByText(shortMonth);
            pauseExecution(500);

            // Select Year - Found dynamically after month selection in case DOM refreshed again
            IWebElement yearDropdownElement = driver.FindElement(yearDropdownLocator);
            SelectElement yearSelect = new SelectElement(yearDropdownElement);
            yearSelect.SelectByText(year);
            pauseExecution(500);

            // Automatically construct XPath for the day
            string dayXPath = $"//td/a[normalize-space(text())='{day}']";

            // Click the Day
            IWebElement dayElement = driver.FindElement(By.XPath(dayXPath));
            dayElement.Click();
            waitForLoadingBarToCompleteinSeconds();
        }
        public string GetFederalFiscalYearStartDateMMddyyyy()
        {
            DateTime today = DateTime.Today;

            // If today is Oct-Dec, the current FY started Oct 1 of this year.
            // If today is Jan-Sep, the current FY started Oct 1 of last year.
            int fiscalYearStartYear = today.Month >= 10
                ? today.Year
                : today.Year - 1;

            DateTime fiscalYearStartDate = new DateTime(fiscalYearStartYear, 10, 1);

            return fiscalYearStartDate.ToString("MMddyyyy");
        }

        public string GetFederalFiscalYearEndDateMMddyyyy()
        {
            DateTime today = DateTime.Today;

            int fiscalYearEndYear = today.Month >= 10
                ? today.Year + 1
                : today.Year;

            DateTime fiscalYearEndDate = new DateTime(fiscalYearEndYear, 9, 30);

            return fiscalYearEndDate.ToString("MMddyyyy");
        }

        /// <summary>
        /// Selects a specific date from a calendar widget that uses left and right navigation arrows 
        /// instead of dropdowns to change the month and year.
        /// </summary>
        /// <param name="calendarOpenButton">The web element that opens the calendar popup (e.g., input box or calendar icon).</param>
        /// <param name="calendarHeaderLocator">The element showing the current calendar month and year (e.g., "July 2025").</param>
        /// <param name="prevButtonLocator">The web element for the left arrow button that navigates to earlier months.</param>
        /// <param name="nextButtonLocator">The web element for the right arrow button that navigates to later months.</param>
        /// <param name="targetDate">The date to select, in "MMddyyyy" format (e.g., "07082025" for July 8, 2025).</param>
        public void SelectDateFromCalendarByArrows(IWebElement calendarIcon, IWebElement calendarHeader, IWebElement prevArrow, IWebElement nextArrow, string dateString) // format: MMddyyyy)
        {
            DateTime targetDate = DateTime.ParseExact(dateString, "MMddyyyy", CultureInfo.InvariantCulture);

            calendarIcon.Click(); // Open calendar
            waitForLoadingBarToCompleteinSeconds();

            // Loop until the header matches the target month and year
            string targetMonthYear = targetDate.ToString("MMMM yyyy", CultureInfo.InvariantCulture); // e.g., "July 2025"

            while (true)
            {
                string currentHeader = calendarHeader.Text.Trim();

                if (currentHeader.Equals(targetMonthYear, StringComparison.OrdinalIgnoreCase))
                    break;

                DateTime currentCalendarDate = DateTime.ParseExact(currentHeader, "MMMM yyyy", CultureInfo.InvariantCulture);

                if (currentCalendarDate < targetDate)
                    nextArrow.Click();
                else
                    prevArrow.Click();

                waitForLoadingBarToCompleteinSeconds();
            }

            // Click on the target day
            string targetDay = targetDate.Day.ToString(); // e.g., "8" or "25"
            IWebElement dayElement = driver.FindElement(By.XPath($"//td/a[normalize-space(text())='{targetDay}']"));
            dayElement.Click();

            waitForLoadingBarToCompleteinSeconds();
        }

        /// <summary>
        /// Returns the current date in the specified format, with optional uppercase conversion for the month part (if format includes "MMM").
        /// </summary>
        /// <param name="format">The date format string (e.g., "dd MMM yyyy").</param>
        /// <param name="uppercaseMonth">If true, converts the month part to uppercase (only if "MMM" is in the format). Default is false.</param>
        /// <returns>The formatted date string.</returns>
        /// <example>
        /// GetCurrentDateInCustomFormat("dd MMM yyyy");           // "09 Jul 2025"
        /// GetCurrentDateInCustomFormat("dd MMM yyyy", true);     // "09 JUL 2025"
        /// </example>
        public string GetCurrentDateInCustomFormat(string format, bool uppercaseMonth = false)
        {
            try
            {
                DateTime now = DateTime.Now;
                string formattedDate = now.ToString(format, CultureInfo.InvariantCulture);

                if (uppercaseMonth && format.Contains("MMM") && !format.Contains("MMMM"))
                {
                    string[] parts = formattedDate.Split(' ');

                    if (parts.Length == 3)
                    {
                        // Convert only the month part to uppercase
                        formattedDate = $"{parts[0]} {parts[1].ToUpper()} {parts[2]}";
                    }
                }

                TestContext.Progress.WriteLine($"Current date ({format}): {formattedDate}");
                Reporting.infoLog($"Current date ({format}): {formattedDate}");

                return formattedDate;
            }
            catch (FormatException ex)
            {
                string errorMessage = $"Invalid date format: '{format}'. Error: {ex.Message}";
                TestContext.Progress.WriteLine(errorMessage);
                Reporting.infoLog(errorMessage);
                return null;
            }
        }

        public void CheckElementNotPresent(IWebElement element, string elementName)
        {
            try
            {
                if (element != null && element.Displayed)
                {
                    // ❌ Fail if element is visible
                    TestContext.Progress.WriteLine($"❌ Element '{elementName}' is present on the page, but it should NOT be.");
                    Reporting.failureLog($"❌ Element '{elementName}' is present on the page, but it should NOT be.");
                    Assert.Fail($"❌ Element '{elementName}' is present on the page, but it should NOT be.");
                }
                else
                {
                    // ✅ Pass if not visible
                    Reporting.successLog($"✅ Element '{elementName}' is not present, as expected.");
                    Console.WriteLine($"✅ Element '{elementName}' is not present, as expected.");
                    TestContext.Progress.WriteLine($"✅ Element '{elementName}' is not present, as expected.");
                }
            }
            catch (NoSuchElementException)
            {
                // ✅ Element not found — pass
                Reporting.successLog($"✅ Element '{elementName}' is not present, as expected.");
                Console.WriteLine($"✅ Element '{elementName}' is not present, as expected.");
                TestContext.Progress.WriteLine($"✅ Element '{elementName}' is not present, as expected.");
            }
            catch (StaleElementReferenceException)
            {
                // ✅ Element existed but now gone — pass
                Reporting.successLog($"✅ Element '{elementName}' is no longer present, as expected.");
                Console.WriteLine($"✅ Element '{elementName}' is no longer present, as expected.");
                TestContext.Progress.WriteLine($"✅ Element '{elementName}' is no longer present, as expected.");
            }
            catch (Exception ex)
            {
                // ⚠️ Handle unexpected errors
                Reporting.failureLog($"⚠️ Error while checking '{elementName}': {ex.Message}");
                TestContext.Progress.WriteLine($"⚠️ Error while checking '{elementName}': {ex.Message}");
                Assert.Fail($"⚠️ Error while checking '{elementName}': {ex.Message}");
            }
        }

        /// <summary>
        /// Returns tomorrow's date formatted using the specified .NET date format string.
        /// </summary>
        /// <param name="format">
        /// A valid .NET date format string. Examples:
        /// - "MM/dd/yyyy" → 06/22/2025
        /// - "dd-MM-yyyy" → 22-06-2025
        /// - "yyyyMMdd" → 20250622
        /// - "MMddyyyy" → 06222025
        /// - "dd MMM yyyy" → 22 Jun 2025
        /// - "MMMM dd, yyyy" → June 22, 2025
        /// Note: "MM" = month, "mm" = minutes (case-sensitive).
        /// </param>
        /// <returns>
        /// A string representing tomorrow's date in the specified format.
        /// </returns>
        /// <example>
        /// string nextDay = GetNextDayInFormat("MM/dd/yyyy");
        /// </example>
        public string GetNextDayDate(string format)
        {
            return DateTime.Now.AddDays(1).ToString(format);
        }



        //public void SwitchToNewWindowOrTab()
        //{
        //    var originalHandles = driver.WindowHandles.ToList();
        //    TestContext.WriteLine($"[INFO] Existing windows: {originalHandles.Count}");
        //    foreach (var handle in originalHandles)
        //        TestContext.WriteLine($" - Handle: {handle}, Title: {driver.SwitchTo().Window(handle).Title}");

        //    // Wait up to 5s for a new window
        //    bool newWindowAppeared = false;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Thread.Sleep(1000);
        //        if (driver.WindowHandles.Count > originalHandles.Count)
        //        {
        //            newWindowAppeared = true;
        //            break;
        //        }
        //    }

        //    if (newWindowAppeared)
        //    {
        //        var newHandle = driver.WindowHandles.Except(originalHandles).First();
        //        driver.SwitchTo().Window(newHandle);
        //        TestContext.WriteLine($"[INFO] Switched to new window: {driver.Title}");
        //    }
        //    else
        //    {
        //        TestContext.WriteLine("[WARN] No new window detected — checking for same-tab navigation...");

        //        string oldUrl = driver.Url;
        //        string oldTitle = driver.Title;

        //        // wait for URL or title change
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Thread.Sleep(500);
        //            if (driver.Url != oldUrl || driver.Title != oldTitle)
        //            {
        //                TestContext.WriteLine($"[INFO] Same-tab navigation detected. New title: {driver.Title}");
        //                return;
        //            }
        //        }

        //        TestContext.WriteLine("[WARN] Neither new window nor navigation occurred after click.");
        //    }

        //    TestContext.WriteLine($"[INFO] Total windows now: {driver.WindowHandles.Count}");
        //}

        public void SwitchToNewWindow()
        {
            var oldHandles = driver.WindowHandles.ToList();
            TestContext.WriteLine($"[INFO] Windows before: {oldHandles.Count}");

            // Wait up to 5 seconds for a new window
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                var newHandles = driver.WindowHandles.ToList();
                if (newHandles.Count > oldHandles.Count)
                {
                    var newHandle = newHandles.Except(oldHandles).First();
                    driver.SwitchTo().Window(newHandle);
                    TestContext.WriteLine($"[INFO] Switched to new window: {driver.Title}");
                    return;
                }
            }

            TestContext.WriteLine("[WARN] No new window detected — staying on current tab.");
        }


        public void UploadFileFromProjectFolder(string fileName, string DocumentType)
        {

            Panel3Page p3 = new Panel3Page(driver);

            // Get the full path of the file within the project folder included file name
            string fullFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\UpLoad", fileName));

            IWebElement fileInput = p3.ChooseFile;
            // Send the full file path to the file input element
            fileInput.SendKeys(fullFilePath);
            if (isIWebElementPresent(p3.DropDownArrow) == true)
            {
                pauseExecution(500);
                waitForLoadingBarToCompleteinSeconds();
                SelectFromCustomDropdownByText(p3.DropDownArrow, p3.DocumentType_Options, DocumentType);
                ValidateElementText(p3.DocumentType_option_Input_Filed, DocumentType);
                waitForLoadingBarToCompleteinSeconds();
                EnterTxt(p3.UploadNewFile_Filename, "Test File", " Entering Test File Text");
                EnterTxt(p3.UploadNewFile_FileDescription, "Description", " Entering Description Text");
            }
            ClickObj(p3.UpLoadBtn, "UpLoad Button");
            pauseExecution(500);
            waitForLoadingBarToCompleteinSeconds();
            //Clear the file input (if needed)
            //fileInput.Clear();
        }

        public void VerifyRadioIsChecked(IWebElement radioElement, string radioName)
        {
            try
            {
                ScrollAndMoveToElement(radioElement);
                bool isSelected = radioElement.Selected;

                TestContext.Progress.WriteLine($"{radioName} radio selected: {isSelected}");

                if (isSelected)
                {
                    TestContext.Progress.WriteLine($"{radioName} radio button is selected as expected.");
                    Reporting.successLog($"{radioName} radio button is selected as expected.");
                }
                else
                {
                    TestContext.Progress.WriteLine($"{radioName} radio button is NOT selected.");
                    Reporting.failureLog($"{radioName} radio button is NOT selected.");
                    Assert.Fail($"{radioName} radio button is NOT selected.");
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Error checking radio button {radioName}: {ex.Message}");
                Reporting.failureLog($"Error checking radio button {radioName}: {ex.Message}");
                Assert.Fail($"Error checking radio button {radioName}: {ex.Message}");
            }
        }

        public void VerifyRadioIsNotChecked(IWebElement radioElement, string radioName)
        {
            try
            {
                moveToElement(radioElement); // optional scrolling if needed
                bool isSelected = radioElement.Selected;

                TestContext.Progress.WriteLine($"{radioName} radio selected: {isSelected}");

                if (!isSelected)
                {
                    TestContext.Progress.WriteLine($"{radioName} radio button is NOT selected, as expected.");
                    Reporting.successLog($"{radioName} radio button is NOT selected, as expected.");
                }
                else
                {
                    TestContext.Progress.WriteLine($"{radioName} radio button IS selected (unexpected).");
                    Reporting.failureLog($"{radioName} radio button IS selected (unexpected).");
                    Assert.Fail($"{radioName} radio button IS selected (unexpected).");
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Error checking radio button {radioName}: {ex.Message}");
                Reporting.failureLog($"Error checking radio button {radioName}: {ex.Message}");
                Assert.Fail($"Error checking radio button {radioName}: {ex.Message}");
            }
        }


        public void WaitForMessageToAppear(IWebElement messageElement, string messageDescription)
        {
            Assert.Multiple((Action)(() =>
            {
                int maxWaitSeconds = 10;
                int intervalMilliseconds = 1000;
                bool isMessageVisible = false;

                for (int i = 0; i < maxWaitSeconds; i++)
                {
                    try
                    {
                        if (messageElement.Displayed)
                        {
                            TestContext.Progress.WriteLine($"✅ Message appeared: {messageDescription}");
                            Reporting.successLog($"✅ Message appeared: {messageDescription}");
                            isMessageVisible = true;
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        // Element not found yet — keep waiting
                    }

                    TestContext.Progress.WriteLine($"{messageDescription} not appeared yet. Waiting another second...");
                    Thread.Sleep(intervalMilliseconds);
                }

                if (!isMessageVisible)
                {
                    TestContext.Progress.WriteLine($"❌ Message did not appear within {maxWaitSeconds} seconds: {messageDescription}");
                    Reporting.failureLog($"❌ Message did not appear within {maxWaitSeconds} seconds: {messageDescription}");
                    throw new Exception($"❌ Message did not appear within {maxWaitSeconds} seconds: {messageDescription}");
                }
            }));
        }

        public void WaitForMessageToAppearByLocator(By locator, string messageDescription)
        {
            int maxWaitSeconds = 10;
            int intervalMilliseconds = 1000;
            bool isMessageVisible = false;

            for (int i = 0; i < maxWaitSeconds; i++)
            {
                try
                {
                    var element = driver.FindElement(locator);

                    if (element.Displayed)
                    {
                        TestContext.Progress.WriteLine($"✅ Message appeared: {messageDescription}");
                        Reporting.successLog($"✅ Message appeared: {messageDescription}");
                        isMessageVisible = true;
                        break;
                    }
                }
                catch
                {
                    // Element not found yet — keep waiting
                }

                TestContext.Progress.WriteLine($"{messageDescription} not appeared yet. Waiting another second...");
                Thread.Sleep(intervalMilliseconds);
            }

            if (!isMessageVisible)
            {
                string failureMessage = $"❌ Message did not appear within {maxWaitSeconds} seconds: {messageDescription}";
                TestContext.Progress.WriteLine(failureMessage);
                Reporting.failureLog(failureMessage);
                throw new Exception(failureMessage);
            }
        }



        public void VerifyText(IWebElement element, string expectedText)
        {
            try
            {
                string actualText = element.Text.Trim();

                if (expectedText.Equals(actualText, StringComparison.OrdinalIgnoreCase))
                {
                    TestContext.Progress.WriteLine($"✅ Text matched. Expected and Actual: '{actualText}'");
                    Reporting.successLog($"✅ Text matched. Expected and Actual: '{actualText}'");
                }
                else
                {
                    string message = $"❌ Text mismatch. Expected: '{expectedText}', Actual: '{actualText}'";
                    TestContext.Progress.WriteLine(message);
                    Reporting.failureLog(message);
                    Assert.Fail(message);
                }
            }
            catch (Exception ex)
            {
                string message = $"❌ Error while verifying text: {ex.Message}";
                TestContext.Progress.WriteLine(message);
                Reporting.failureLog(message);
                Assert.Fail(message);
            }
        }

        /// <summary>
        /// Returns the start date of the fiscal year (October 1) formatted using the
        /// specified .NET date format string.
        ///
        /// Any valid standard or custom .NET date format string can be supplied.
        /// The returned date always represents October 1 of the calculated fiscal year.
        /// 
        /// Example format strings and outputs:
        ///
        ///   • "MMddyyyy"              → "10012025"
        ///   • "yyyyMMdd"              → "20251001"
        ///   • "MM/dd/yyyy"            → "10/01/2025"
        ///   • "dd-MM-yyyy"            → "01-10-2025"
        ///   • "MMM dd, yyyy"          → "Oct 01, 2025"
        ///   • "MMMM dd, yyyy"         → "October 01, 2025"
        ///   • "yyMMdd"                → "251001"
        ///   • "M/d/yy"                → "10/1/25"
        ///   • "dddd, MMMM dd yyyy"    → "Wednesday, October 01 2025"
        ///   • "yyyy-MM-ddTHH:mm:ss"   → "2025-10-01T00:00:00"
        ///
        public string GetFiscalYearStartAsString(string dateFormat)
        {
            DateTime today = DateTime.Today;
            int year = today.Month < 10 ? today.Year - 1 : today.Year;
            DateTime startDate = new DateTime(year, 10, 1);

            string formattedDate = startDate.ToString(dateFormat); // e.g., "MMddyyyy" or "yyyyMMdd"

            TestContext.Progress.WriteLine($"Fiscal year start date (string): {formattedDate}");
            Reporting.infoLog($"Fiscal year start date (string): {formattedDate}");

            return formattedDate;
        }


        /// <summary>
        /// Returns the fiscal year as a formatted string based on today's date.
        /// The fiscal year changes on October 1 (dates on/after Oct 1 use the next calendar year).
        ///
        /// Examples:
        ///   • "0000"     → "2025"
        ///   • "##"       → "25"
        ///   • "'FY'0000" → "FY2025"
        /// </summary>
        public string GetFiscalYearAsString(string format)
        {
            DateTime today = DateTime.Today;

            // Fiscal year starts in October
            int fiscalYear = (today.Month >= 10) ? today.Year + 1 : today.Year;

            // Format the fiscal year using the supplied format string
            return fiscalYear.ToString(format);
        }

        /// <summary>
        /// Example format strings and outputs:
        ///
        ///   • "MMddyyyy"              → "10012025"
        ///   • "yyyyMMdd"              → "20251001"
        ///   • "MM/dd/yyyy"            → "10/01/2025"
        ///   • "dd-MM-yyyy"            → "01-10-2025"
        ///   • "MMM dd, yyyy"          → "Oct 01, 2025"
        ///   • "MMMM dd, yyyy"         → "October 01, 2025"
        ///   • "yyMMdd"                → "251001"
        ///   • "M/d/yy"                → "10/1/25"
        ///   • "dddd, MMMM dd yyyy"    → "Wednesday, October 01 2025"
        ///   • "yyyy-MM-ddTHH:mm:ss"   → "2025-10-01T00:00:00"
        /// <summary>
        public string GetFiscalYearEndAsString(string format)
        {
            DateTime today = DateTime.Today;
            int year = today.Month < 10 ? today.Year : today.Year + 1;
            DateTime endDate = new DateTime(year, 9, 30);

            string formattedDate = endDate.ToString(format);

            TestContext.Progress.WriteLine($"Fiscal year end date (string): {formattedDate}");
            Reporting.infoLog($"Fiscal year end date (string): {formattedDate}");

            return formattedDate;
        }

        public void WaitForElement(IWebElement element, int timeoutInSeconds = 25)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.Until(d =>
            {
                try
                {
                    if (element.Displayed)
                    {
                        TestContext.Progress.WriteLine("✅ Element is displayed.");
                        return true;
                    }
                    else
                    {
                        TestContext.Progress.WriteLine("⏳ Element not displayed yet. Waiting for 500ms...");
                        return false;
                    }
                }
                catch (Exception)
                {
                    TestContext.Progress.WriteLine("⏳ Element not found in DOM yet. Waiting for 500ms...");
                    return false;
                }
            });
        }
        public void WaitForElementByLocator(By locator, int timeoutInSeconds = 25)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);

                    if (element.Displayed)
                    {
                        TestContext.Progress.WriteLine("✅ Element is displayed.");
                        return true;
                    }
                    else
                    {
                        TestContext.Progress.WriteLine("⏳ Element found but not displayed yet...");
                        return false;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    TestContext.Progress.WriteLine("♻️ Element went stale. Re-trying...");
                    return false;
                }
                catch (NoSuchElementException)
                {
                    TestContext.Progress.WriteLine("⏳ Element not found yet...");
                    return false;
                }
            });
        }


        public static string GetElementAttribute(IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element), "Element cannot be null");

            string tagName = element.TagName.ToLower();

            // Input & Textarea → value attribute
            if (tagName == "input" || tagName == "textarea")
            {
                return element.GetAttribute("value")?.Trim() ?? string.Empty;
            }

            // Select dropdown
            if (tagName == "select")
            {
                SelectElement select = new SelectElement(element);
                return select.SelectedOption.Text.Trim();
            }

            // Default → visible text
            return element.Text?.Trim() ?? string.Empty;
        }

        public void ValidateElementAttributeValue(IWebElement element, string expectedValue)
        {
            try
            {
                ScrollAndMoveToElement(element);
                highlight_obj(element);
                string actualValue = null;

                // Try common attributes first
                actualValue = element.GetAttribute("value");

                if (string.IsNullOrWhiteSpace(actualValue))
                    actualValue = element.GetAttribute("textContent");

                if (string.IsNullOrWhiteSpace(actualValue))
                    actualValue = element.Text;

                if (string.IsNullOrWhiteSpace(actualValue))
                    actualValue = element.GetAttribute("innerText");

                if (string.IsNullOrWhiteSpace(actualValue))
                    actualValue = element.GetAttribute("title");

                actualValue = actualValue?.Trim();

                if (actualValue == expectedValue)
                {
                    TestContext.Progress.WriteLine($"PASS: Element value matched expected value '{expectedValue}'.");
                    Reporting.successLog($"PASS: Element value matched expected value '{expectedValue}'.");
                }
                else
                {
                    TestContext.Progress.WriteLine($"FAIL: Expected '{expectedValue}' but found '{actualValue}'.");
                    Reporting.failureLog($"FAIL: Expected '{expectedValue}' but found '{actualValue}'.");
                    Assert.Fail($"Expected '{expectedValue}' but found '{actualValue}'.");
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"Exception while verifying element value: {ex.Message}");
                Reporting.failureLog($"Exception while verifying element value: {ex.Message}"); ;
                Assert.Fail($"Exception while verifying element value: {ex.Message}");
            }
        }


        /// <summary>
        /// Finds a row in a table/list of elements that contains the target string,
        /// then clicks the Turn In button in the same row by using index.
        /// </summary>
        public void ClickTurnInByIndex( IList<IWebElement> rows, string targetValue)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                highlight_obj(row);

                if (row.Text.Contains(targetValue))
                {
                    // Build XPath using row index (i+1 because XPath is 1-based)
                    string xpath = $"//div[@class='tab-pane fade nav-panel-parent active in']//tr[{i + 1}]//button[@aria-label='Turn In']";

                    IWebElement turnInButton = driver.FindElement(By.XPath(xpath));

                    highlight_obj(turnInButton);
                    ClickObj(turnInButton, $"Turn In button in row {i + 1} for {targetValue}");
                    return;
                }
            }

            throw new Exception($"No row found with value: {targetValue}");
        }

        public void HandleErrorPopupIfPresent_locator(string item, By locatorClick)
        {
            bool errorHandled = false;

            while (IsErrorToastPresent())
            {
                if (!errorHandled)
                {
                    CaptureScreenshot(true);
                    Reporting.failureLog("Red pop Up appeared for: " + item);
                    Assert.Fail("Red pop Up appeared for: " + item);
                    TestContext.Progress.WriteLine("Red pop Up appeared for: " + item);
                    errorHandled = true; // Set the flag to true to indicate that the error has been handled
                }

                pauseExecution(500);
                ClickLocator(locatorClick, "Close popup");
                WaitUntilErrorPopupDisapeard();
            }
        }

        public void ClickLocator(By locator, string description)
        {
            driver.FindElement(locator).Click();
            waitForLoadingBarToCompleteinSeconds();
            TestContext.Progress.WriteLine("Clicked: " + description);
        }









        #endregion





    }
}