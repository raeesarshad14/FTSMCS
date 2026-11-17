using NUnit.Framework;
using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.TestSteps
{
    internal class ReportBlade_VerifyLinksLoadWithoutFailureSteps : UtilityMethods
    {

        // Below is the URL path for this test:


        public ReportBlade_VerifyLinksLoadWithoutFailureSteps(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyReportBladeLinksLoadWithoutFailure()
        {
            ReportBlade_VerifyLinksLoadWithoutFailurePage reportingBlade = new ReportBlade_VerifyLinksLoadWithoutFailurePage(driver);

            if (isElementPresent(reportingBlade.ReportingBlade) == true)
            {
                ClickObj(reportingBlade.Reporting_Blade, "Report Blade");

                IList<IWebElement> childLinks = reportingBlade.tot_links;
                int childLinksSize = childLinks.Count;
                TestContext.Progress.WriteLine("Total Links are: " + childLinksSize);
                //Reporting.infoLog("Total Links are: " + childLinksSize);

                Assert.Multiple((Action)(() =>
                {
                    for (int i = 0; i < childLinksSize; i++)
                    {

                        IWebElement childlist = childLinks[i];
                        string itemName = GetElementText(childlist, "Tree item text is: " + childlist.Text);
                        TestContext.Progress.WriteLine("I value is: " + i + " and link is: " + itemName);
                        // Reporting.infoLog("I value is: " + i + " and link is: " + itemName);

                        JsClick(childlist, "The Tree Item is: " + itemName);

                        //Extra window
                        HandleExtraWindowPopupIfPresent_locator("Extra Window", reportingBlade.pop_Xbutton_locator);

                        //Checking Red PopUp on panel 2
                        HandleErrorPopupIfPresent_locator(itemName, reportingBlade.closeIconOnPopup_locator);

                        //validating dropdown on panel 2 of the same link click on panel 1
                        string dropdwondText = GetElementText(reportingBlade.panel2_DropDown_Value, "Panel 2 Drop down Text");
                        TestContext.Progress.WriteLine("Text is: " + dropdwondText);
                        // Reporting.infoLog("Text is: " + dropdwondText);

                        if (!itemName.Contains(dropdwondText))
                        {
                            CaptureScreenshot(true);
                            Reporting.failureLog("Second Page was not displayed for: " + itemName);
                            Assert.Fail("Second Page was not displayed for: " + itemName);
                        }
                    }
                }));
            }
            else
            {
                CaptureScreenshot(true);
                TestContext.Progress.WriteLine("Report blade is not present.");
                Reporting.infoLogWithSS("Report blade is not present.");
            }
        }

        public void ReportBladeDetailsValidation()
        {
            ReportBlade_VerifyLinksLoadWithoutFailurePage reportingBlade = new ReportBlade_VerifyLinksLoadWithoutFailurePage(driver);

            if (isElementPresent(reportingBlade.ReportingBlade) == true)
            {
                ClickObj(reportingBlade.Reporting_Blade, "Report Blade");

                IList<IWebElement> childLinks = reportingBlade.tot_links;
                int childLinksSize = childLinks.Count;
                TestContext.Progress.WriteLine("Total Links are: " + childLinksSize);
                // Reporting.infoLog("Total Links are: " + childLinksSize);

                Assert.Multiple((Action)(() =>
                {
                    foreach (var item in childLinks)
                    {
                        waitForLoadingBarToComplete();
                        TestContext.Progress.WriteLine("Clicking report type " + item.Text);
                        // Reporting.infoLog("Clicking report type " + item.Text);

                        highlight_obj(item);
                        //item.Click();
                        ClickObj(item, item.Text);
                        waitForLoadingBarToCompleteinSeconds();

                        //Extra window
                        HandleExtraWindowPopupIfPresent_locator("Extra Window", reportingBlade.pop_Xbutton_locator);

                        //Checking Red PopUp on panel 2
                        HandleErrorPopupIfPresent_locator(item.Text + " Link", reportingBlade.closeIconOnPopup_locator);

                        ClickRandomTableRowData();
                    }
                }));
            }
            else
            {
                TestContext.Progress.WriteLine("Report details are not present.");
            }
        }

        public void ClickRandomTableRowData()
        {
            //Data Table rows
            //IWebElement table = driver.FindElement(By.CssSelector("table.wb-results-table.table.table-bordered.table-responsive"));
            IWebElement parentElement = driver.FindElement(By.ClassName("nav-panel-parent"));
            IList<IWebElement> tableElements = parentElement.FindElements(By.CssSelector("a[data-currentdimension]"));

            //If list has elements then we need to generate a random row number to click
            if (tableElements.Count > 0)
            {
                //Randomize row click of table data
                Random rand = new Random();

                int randomRowIndex = rand.Next(1, tableElements.Count - 1);
                IWebElement rowElement = tableElements[randomRowIndex];
                waitForLoadingBarToComplete();
                if (rowElement.Enabled)
                {
                    TestContext.Progress.WriteLine("Clicking row " + rowElement.Text);
                    highlight_obj(rowElement);
                    CaptureScreenshot(true);
                    rowElement.Click();
                }
            }
            else
            {
                TestContext.Progress.WriteLine("Report details has no row data.");
            }
        }

        public void SwitchToModalAndClose(IWebElement modal)
        {
            driver.SwitchTo().Frame(modal);

        }





    }
}
