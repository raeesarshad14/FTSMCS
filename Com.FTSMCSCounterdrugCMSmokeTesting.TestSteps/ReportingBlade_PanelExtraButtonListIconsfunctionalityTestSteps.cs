using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.TestSteps
{
    public class ReportingBlade_PanelExtraButtonListIconsfunctionalityTestSteps : UtilityMethods
    {

        /// <summary>
        /// This test navigates to the Reporting Blade, clicks on its link to open Panel 2, and checks the functionality of the toolbar icons, 
        /// including, Refresh, Export, Export CSV, Print, Clear filter and, Save As New Report,E-mail Report, etc.
        /// </summary>

        public string attribute;


        public ReportingBlade_PanelExtraButtonListIconsfunctionalityTestSteps(IWebDriver driver) : base(driver)
        {
        }



        /// <summary>
        /// This test navigates to the Reporting Blade, clicks on its link to open Panel 2, and checks the functionality of the toolbar icons, 
        /// including, Refresh, Export, Export CSV, Print, Clear filter and, Save As New Report,E-mail Report, etc.
        /// </summary>

        public void Panel2ReportingIconsIconsfunctionalityvalidation()
        {

            ReportBlade_VerifyLinksLoadWithoutFailurePage reportBlade = new ReportBlade_VerifyLinksLoadWithoutFailurePage(driver);
            ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects reportingIcons = new ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects(driver);
            ManagementCenter_Page MCP = new ManagementCenter_Page(driver);


            Assert.Multiple((Action)(() =>
            {
                ClickObj(reportBlade.Reporting_Blade, "Report Blade");
                clickOnFirstlink_ReportingBlade();

                int totalReportingIconsCount =
                    reportBlade.totalReportingIcons_IWebElement.Count;

                TestContext.Progress.WriteLine(
                    "Total Reporting Icons Are: " + totalReportingIconsCount);

                for (int IconIndex = 0;
                     IconIndex < totalReportingIconsCount;
                     IconIndex++)
                {
                    // Get fresh icon list on every loop iteration.
                    IList<IWebElement> totalReportingIcons =
                        reportBlade.totalReportingIcons_IWebElement;

                    IWebElement ReportingIcon =
                        totalReportingIcons[IconIndex];

                    attribute = ReportingIcon.GetAttribute("title");

                    TestContext.Progress.WriteLine(
                        "Icon attribute is: " + attribute);
                    // Reporting.infoLog("Icon attribute is: " + attribute);

                    if (attribute.Equals("Save As New Report"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Save Report", attribute);

                    }

                    else if (attribute.Equals("E-mail Report"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                    }

                    else if (attribute.Equals("Export to Excel"))
                    {

                        string P2titleText = GetElementText(reportingIcons.p2reportTitle_WebElement, "Panel 2 Title").Replace("(", "").Replace(")", "").Replace(" ", "");
                        TestContext.Progress.WriteLine("Panel 2 capture text for Export to Excel:" + P2titleText);
                        //  Reporting.infoLog("Panel 2 capture text for Export to Excel:" + P2titleText);
                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        CreateFolderIfNotExist();
                        DownloadFileInProjectDownLoadFolder();
                        waitUntilFileDownloaded(".xlsx");
                        // VerifyIfFileDownload(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")), @"Uptick.Tests.Common\DownLoad", P2titleText, "*.xlsx*");
                        verifyIfFileExist("*.xlsx*");
                        DeleteAllFilesAndDirectoriesFromFolder();

                    }

                    else if (attribute.Equals("Export to CSV File"))
                    {

                        string P2titleText = GetElementText(reportingIcons.p2reportTitle_WebElement, "Panel 2 Title").Replace("(", "").Replace(")", "").Replace(" ", "");
                        TestContext.Progress.WriteLine("Panel 2 capture text for Export to CSV File:" + P2titleText);
                        // Reporting.infoLog("Panel 2 capture text for Export to CSV File:" + P2titleText);
                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        CreateFolderIfNotExist();
                        DownloadFileInProjectDownLoadFolder();
                        waitUntilFileDownloaded(".csv");
                        //VerifyIfFileDownload(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")), @"Uptick.Tests.Common\DownLoad", P2titleText, "*.csv*");
                        verifyIfFileExist("*.csv*");
                        DeleteAllFilesAndDirectoriesFromFolder();

                    }

                    else if (attribute.Equals("Export Aggregate/Base Reports to Excel"))
                    {

                        string P2titleText = GetElementText(reportingIcons.p2reportTitle_WebElement, "Panel 2 Title").Replace("(", "").Replace(")", "").Replace(" ", "");
                        TestContext.Progress.WriteLine("Panel 2 capture text for Export to CSV File:" + P2titleText);
                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        CreateFolderIfNotExist();
                        DownloadFileInProjectDownLoadFolder();
                        waitUntilFileDownloaded(".xlsx");
                        //VerifyIfFileDownload(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")), @"Uptick.Tests.Common\DownLoad", P2titleText, "*.xlsx*");
                        verifyIfFileExist("*.xlsx*");
                        DeleteAllFilesAndDirectoriesFromFolder();

                    }

                    else if (attribute.Equals("Export Aggregate to Excel for Current and Child Commands"))
                    {

                        string P2titleText = GetElementText(reportingIcons.p2reportTitle_WebElement, "Panel 2 Title").Replace("(", "").Replace(")", "").Replace(" ", "");
                        TestContext.Progress.WriteLine("Panel 2 capture text for Export to CSV File:" + P2titleText);
                        //  Reporting.infoLog("Panel 2 capture text for Export to CSV File:" + P2titleText);
                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        CreateFolderIfNotExist();
                        DownloadFileInProjectDownLoadFolder();
                        waitUntilFileDownloaded(".xlsx");
                        //VerifyIfFileDownload(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")), @"Uptick.Tests.Common\DownLoad", P2titleText, "*.xlsx*");
                        verifyIfFileExist("*.xlsx*");
                        DeleteAllFilesAndDirectoriesFromFolder();

                    }

                    else if (attribute.Equals("View Current Report as Dashboard"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Report as Dashboard", attribute);

                    }

                    else if (attribute.Equals("Advanced Edit"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Advanced Edit", attribute);

                    }

                    else if (attribute.Equals("Change Dimensions"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");

                        newWindowOpensValidation("Change Dimensions", attribute);

                    }

                    else if (attribute.Equals("Edit Filters"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Edit Filters", attribute);

                    }

                    else if (attribute.Equals("Advanced Sort"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Advanced Sort", attribute);

                    }

                    else if (attribute.Equals("Go to Base Report"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        IList<IWebElement> totalReportingIconsAfterClickingBaseReport = reportBlade.totalReportingIcons_IWebElement;
                        TestContext.Progress.WriteLine("Total Reporting Icons After Clicking Base Report: " + totalReportingIconsAfterClickingBaseReport.Count);
                        // Reporting.infoLog("Total Reporting Icons After Clicking Base Report: " + totalReportingIconsAfterClickingBaseReport.Count);

                        for (int IconIndex2 = 0; IconIndex2 < totalReportingIconsAfterClickingBaseReport.Count; IconIndex2++)
                        {
                            IWebElement ReportingIconsAfterClickingBaseReport = totalReportingIconsAfterClickingBaseReport[IconIndex2];
                            string attributeAfterClickingBaseReport = ReportingIconsAfterClickingBaseReport.GetAttribute("title");
                            TestContext.Progress.WriteLine("Icon attribute After Clicking Base Report: " + attributeAfterClickingBaseReport);
                            //  Reporting.infoLog("Icon attribute After Clicking Base Report: " + attributeAfterClickingBaseReport);

                            if (attributeAfterClickingBaseReport.Contains("Go to Base Report"))
                            {
                                Reporting.failureLog(attributeAfterClickingBaseReport + "still appeared after clicking Go to Base Report");
                                Assert.Fail(attributeAfterClickingBaseReport + "still appeared after clicking Go to Base Report");
                                break;
                            }
                        }

                        ClickObj(reportingIcons.P2Home_WebElement, "Home link on panel 2");
                        // Wait until Home is loaded and the NEXT icon is available.
                        if (IconIndex < totalReportingIconsCount - 1)
                        {
                            WebDriverWait pageWait = new WebDriverWait( driver,TimeSpan.FromSeconds(20));

                            pageWait.Until(d =>
                                reportBlade.totalReportingIcons_IWebElement.Count > IconIndex + 1);
                        }

                    }

                    else if (attribute.Equals("Display SQL Statement"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("SQL", attribute);

                    }
                    else if (attribute.Equals("Display Report Spec Xml"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Report Xml Spec", attribute);

                    }
                    else if (attribute.Equals("Report Help"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Report Help", attribute);

                    }

                    else if (attribute.Equals("Edit Base Report"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("PSL Screening Report", attribute);

                    }
                    else if (attribute.Equals("Subscribe to Report"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        handleErrorMessage(attribute);
                        newWindowOpensValidation("Subscribe to Report", attribute);

                    }
                    else if (attribute.Equals("Generic Help"))
                    {

                        ClickObj(ReportingIcon, attribute + " Icon");
                        closeNewOpenBrowerandSwitchToFirstBrowser(reportBlade.servererror_WebElement);

                    }

                    else
                    {
                        CaptureScreenshot(true);
                        Reporting.warningLog("This Icon is not cover in this test case. Need to add this Icon Funtionality");
                        Assert.Warn("This Icon is not cover in this test case. Need to add this Icon Funtionality");
                    }
                }

            }));
        }

        public void clickOnFirstlink_ReportingBlade()
        {
            ReportBlade_VerifyLinksLoadWithoutFailurePage reportingBlade = new ReportBlade_VerifyLinksLoadWithoutFailurePage(driver);

            IList<IWebElement> childLinks = reportingBlade.tot_links;
            int childLinksSize = childLinks.Count;
            TestContext.Progress.WriteLine("Total Links are: " + childLinksSize);
            for (int childLinksindex = 0; childLinksindex < 1; childLinksindex++)
            {

                IWebElement childlist = childLinks[childLinksindex];
                string itemName = GetElementText(childlist, "Link text is: " + childlist.Text);
                TestContext.Progress.WriteLine("Link number is: " + childLinksindex + " and link is: " + itemName);
                ClickObj(childlist, "Link is: " + itemName);
                if (isElementPresent(reportingBlade.ExtraWindowCancelBtn_locator) == true)
                {
                    ClickObj(reportingBlade.ExtraWindowCancelBtn, "Cancel Button");
                }
                //Checking Red PopUp on panel 2
                HandleErrorPopupIfPresent_locator(itemName, reportingBlade.closeIconOnPopup_locator);
            }
        }

        public void newWindowOpensValidation(string windowName, string attribute)
        {
            Assert.Multiple((Action)(() =>
            {
                ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects reportingIcons = new ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects(driver);

                TestContext.Progress.WriteLine("Icon is: " + attribute);
                string windowText = GetElementText(reportingIcons.newWindowOpened_WebElement, windowName);
                bool CloseBtn = isElementPresent(reportingIcons.CloseBtn_locator);
                bool CancelBtn = isElementPresent(reportingIcons.CancelBtn_locator);
                bool XBtn = isElementPresent(reportingIcons.XBtn_locator);


                if (isElementPresent(reportingIcons.WindowPopUp_Locator))
                {
                    if (windowText.Equals(attribute))
                    {
                        TestContext.Progress.WriteLine("Icon Name and Opened Window Name Match " +
                            "Icon is: " + attribute + " open window name is: " + windowText);
                        if (CloseBtn)
                        {
                            ClickObj(reportingIcons.CloseBtn_WebElement, windowText + " Close Button");
                        }
                        else if (CancelBtn)
                        {
                            ClickObj(reportingIcons.saveReportWindowCancelBtn_WebElement, windowText + " Cancel Button");
                        }
                        else if (XBtn)
                        {
                            ClickObj(reportingIcons.pop_Xbutton, windowText + " X Button");
                        }
                    }
                    else if (!windowText.Equals(attribute))
                    {
                        if (CloseBtn)
                        {
                            ClickObj(reportingIcons.CloseBtn_WebElement, windowText + " Close Button");
                        }
                        else if (CancelBtn)
                        {
                            ClickObj(reportingIcons.saveReportWindowCancelBtn_WebElement, windowText + " Cancel Button");
                        }
                        else if (XBtn)
                        {
                            ClickObj(reportingIcons.pop_Xbutton, windowText + " X Button");
                        }
                        TestContext.Progress.WriteLine("Icon Name and Opened Window Name does not Match " +
                                  "Icon is: " + attribute + " open window name is: " + windowText);
                        Reporting.failureLog("Icon Name and Opened Window Name does not Match " +
                                  "Icon is: " + attribute + " open window name is: " + windowText);
                        Assert.Fail("Icon Name and Opened Window Name does not Match " +
                                  "Icon is: " + attribute + " open window name is: " + windowText);
                    }

                }

            }));
        }
    }
}


