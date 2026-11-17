using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities
{
    public class Reporting : SetUp
    {

        public static void successLog(string message)
        {
            // Individual test report
            testTest.Log(Status.Pass, message);
            testTest.Log(Status.Pass, captureScreenShot(message));

            // Also log into suite (master) report
            suiteTest.Log(Status.Pass, message);
            suiteTest.Log(Status.Pass, captureScreenShot(message));
        }
        public static void failureLog(string message)
        {
            testTest.Log(Status.Fail, message);
            testTest.Log(Status.Fail, captureScreenShot(message));

            suiteTest.Log(Status.Fail, message);
            suiteTest.Log(Status.Fail, captureScreenShot(message));
        }
        public static void infoLog(string message)
        {
            testTest.Log(Status.Info, message);
            suiteTest.Log(Status.Info, message);
        }
        public static void warningLog(string message)
        {
            testTest.Log(Status.Warning, message);
            testTest.Log(Status.Warning, captureScreenShot(message));

            suiteTest.Log(Status.Warning, message);
            suiteTest.Log(Status.Warning, captureScreenShot(message));
        }
        public static void infoLogWithSS(string message)
        {
            try
            {
                testTest.Log(Status.Info, captureScreenShot(message));
                testTest.Log(Status.Info, message);

                suiteTest.Log(Status.Info, captureScreenShot(message));
                suiteTest.Log(Status.Info, message);
            }
            catch (Exception e)
            {
                testTest.Log(Status.Fail, "Failure to take screenshot " + e.Message + captureScreenShot(message));

                suiteTest.Log(Status.Fail, "Failure to take screenshot " + e.Message + captureScreenShot(message));
            }
        }
        public static MediaEntityModelProvider captureScreenShot(string screenShotName)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string base64 = screenshot.AsBase64EncodedString;

                return MediaEntityBuilder
                    .CreateScreenCaptureFromBase64String(base64, screenShotName)
                    .Build();
            }
            catch (Exception ex)
            {
                return MediaEntityBuilder
                    .CreateScreenCaptureFromBase64String("", "Screenshot Failed: " + ex.Message)
                    .Build();
            }
        }






    }
}
