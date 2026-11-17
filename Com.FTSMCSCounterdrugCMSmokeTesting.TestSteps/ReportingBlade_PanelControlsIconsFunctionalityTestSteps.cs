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
    public class ReportingBlade_PanelControlsIconsFunctionalityTestSteps : UtilityMethods

    {
        /// <summary>
        /// This test navigates to the Reporting Blade, clicks on its link to open Panel 2, 
        /// and checks the functionality of the Panel Controls, including the Toggle Fullscreen, Close, and Close All icons.
        /// </summary>
        /// 



        public ReportingBlade_PanelControlsIconsFunctionalityTestSteps(IWebDriver driver) : base(driver)
        {

        }

        public void ReportingIconsValidationTest()
        {

            //creating object to acees elements
            ManagementCenter_Page MCP = new ManagementCenter_Page(driver);
            ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects panel2IconsValidation = new ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects(driver);
            ReportBlade_VerifyLinksLoadWithoutFailurePage reportingBlade = new ReportBlade_VerifyLinksLoadWithoutFailurePage(driver);
            ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects reportingIcons = new ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects(driver);


            Assert.Multiple((Action)(() =>
            {
                ClickObj(reportingBlade.Reporting_Blade, "Report Blade");
                clickOnFirstlink_ReportingBlade();

                //panel 2 Total Icons of Panel Controls
                IList<IWebElement> Panel2TotalIcons = panel2IconsValidation.PanelControlIconsList;
                int totalIcons = Panel2TotalIcons.Count;
                TestContext.Progress.WriteLine("Total Icons are: " + totalIcons);
                // Reporting.infoLog("Total Icons are: " + totalIcons);

                // below for loop handling, if there is no record is available then click links on panel 1 until record is available on panel 2
                for (int IconsIndex = 0; IconsIndex < Panel2TotalIcons.Count; IconsIndex++)
                {
                    Reporting_VerifyThatTextsOfLinkClickedOnPanelareSameOnPanel2();
                    // after getting all Icons on panel 2 then taking the attribute value to handle case accordingly
                    IWebElement singleIcon = Panel2TotalIcons[IconsIndex];
                    string attributeName = singleIcon.GetAttribute("aria-label");
                    ClickObj(singleIcon, "Icon on Panel 2 and Icon is: " + attributeName);

                    //case 1: Toggle Fullscreen
                    if (attributeName.Equals("Toggle Fullscreen"))
                    {
                        if (!isElementPresent(panel2IconsValidation.FullScreen_Expanded_locator))
                        {
                            CaptureScreenshot(true);
                            TestContext.Progress.WriteLine("Screen not Expanded");
                            Reporting.failureLog("Screen not Expanded");
                            Assert.Fail("Screen not Expanded");
                        }

                        if (isElementPresent(panel2IconsValidation.FullScreen_Expanded_locator))
                        {
                            //click expanded screen again to unexpand and verify if this full screen unexpanded.
                            ClickObj(panel2IconsValidation.FullScreen_Expanded_IWebElement, "Expanded full Screen toggle to Unexpand Screen");

                            if (isElementPresent(panel2IconsValidation.FullScreen_Expanded_locator))
                            {
                                CaptureScreenshot(true);
                                TestContext.Progress.WriteLine("Screen is not UnExpanded");
                                Reporting.failureLog("Screen is not UnExpanded");
                                Assert.Fail("Screen is not UnExpanded");
                            }
                        }
                    }
                    //case 2: Close
                    else if (attributeName.Equals("Close"))
                    {
                        string P1_textofFirstLink = GetElementText(reportingBlade.firstLinkText, "First Link of Reporting");
                        TestContext.Progress.WriteLine("Panel1 Text: " + P1_textofFirstLink);
                        //Reporting.infoLog("Panel1 Text: " + P1_textofFirstLink);

                        string textofDropDownonP2 = GetElementText(reportingBlade.panel2_DropDown_Value, "Drop down text on panel 2");
                        TestContext.Progress.WriteLine("Panel2 Text: " + textofDropDownonP2);
                        // Reporting.infoLog("Panel2 Text: " + textofDropDownonP2);

                        if (P1_textofFirstLink.Equals(textofDropDownonP2))
                        {
                            CaptureScreenshot(true);
                            TestContext.Progress.WriteLine("Close Icon Did not Work Correctly");
                            Reporting.failureLog("Close Icon Did not Work Correctly");
                            Assert.Fail("Close Icon Did not work Correctly");
                        }
                    }
                    //case 3: Close All
                    else if (attributeName.Equals("Close All"))
                    {
                        string P1_textofFirstLink = GetElementText(reportingBlade.firstLinkText, "First Link of Reporting");
                        TestContext.Progress.WriteLine("Panel1 Text: " + P1_textofFirstLink);
                        //  Reporting.infoLog("Panel1 Text: " + P1_textofFirstLink);

                        string textofDropDownonP2 = GetElementText(reportingBlade.panel2_DropDown_Value, "Drop down text on panel 2");
                        TestContext.Progress.WriteLine("Panel2 Text: " + textofDropDownonP2);
                        // Reporting.infoLog("Panel2 Text: " + textofDropDownonP2);

                        if (P1_textofFirstLink.Equals(textofDropDownonP2))
                        {
                            CaptureScreenshot(true);
                            TestContext.Progress.WriteLine("Close All Icon Did not Work Correctly");
                            Reporting.failureLog("Close All Icon Did not Work Correctly");
                            Assert.Fail("Close All Icon Did not work Correctly");
                        }

                    }
                    //case 4: else situation
                    else
                    {
                        CaptureScreenshot(true);
                        Reporting.warningLog("This Icon Validation is not added");
                        Assert.Warn("This Icon Validation is not added");
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

        public void Reporting_VerifyThatTextsOfLinkClickedOnPanelareSameOnPanel2()
        {

            ReportBlade_VerifyLinksLoadWithoutFailurePage reportingBlade = new ReportBlade_VerifyLinksLoadWithoutFailurePage(driver);
            string P1_textofFirstLink = GetElementText(reportingBlade.firstLinkText, "First Link of Reporting");
            string textofDropDownonP2 = GetElementText(reportingBlade.panel2_DropDown_Value, "Drop down text on panel 2");
            IList<IWebElement> childLinks = reportingBlade.tot_links;
            if (!P1_textofFirstLink.Equals(textofDropDownonP2))
            {
                for (int childLinksindex = 1; childLinksindex < childLinks.Count; childLinksindex++)
                {
                    IWebElement childlist = childLinks[childLinksindex];
                    ClickObj(childlist, "Reporting Links");
                    if (isElementPresent(reportingBlade.ExtraWindowCancelBtn_locator) == true)
                    {
                        ClickObj(reportingBlade.ExtraWindowCancelBtn, "Cancel Button");
                    }
                    //Checking Red PopUp on panel 2
                    HandleErrorPopupIfPresent_locator(childlist.Text, reportingBlade.closeIconOnPopup_locator);
                    string P1_textofFirstLink2 = GetElementText(childlist, "Captired Text");
                    TestContext.Progress.WriteLine("Panel1 Text: " + P1_textofFirstLink2);
                    string textofDropDownonP22 = GetElementText(reportingBlade.panel2_DropDown_Value, "Drop down text on panel 2");
                    TestContext.Progress.WriteLine("Panel2 Text: " + textofDropDownonP22);
                    if (P1_textofFirstLink2.Equals(textofDropDownonP22))
                    {
                        break;
                    }
                }
            }
        }
    }
}




