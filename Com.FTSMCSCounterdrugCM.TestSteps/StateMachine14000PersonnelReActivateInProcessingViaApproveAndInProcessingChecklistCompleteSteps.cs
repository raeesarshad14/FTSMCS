using NUnit.Framework;
using OpenQA.Selenium;
using Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps
{
    public class StateMachine14000PersonnelReActivateInProcessingViaApproveAndInProcessingChecklistCompleteSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine14000PersonnelReActivateInProcessingViaApproveAndInProcessingChecklistCompleteSteps(IWebDriver driver) : base(driver)
        {

        }

        public string randomComment;
        public string randomAmount;

        public void StateMachine14000PersonnelReActivateInProcessingViaApproveAndInProcessingChecklistComplete()
        {


            Assert.Multiple((Action)(() =>
            {
                LoginPage loginPage = new LoginPage(driver);
                MainLandingPage landingpage = new MainLandingPage(driver);
                CommonMethods commonMethods = new CommonMethods(driver);
                Panel1Page p1 = new Panel1Page(driver);
                Panel2Page p2 = new Panel2Page(driver);
                Panel3Page p3 = new Panel3Page(driver);
                Panel4Page p4 = new Panel4Page(driver);



                ClickObj(landingpage.Applications_Dropdown, "Application Dropdown");
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                moveToElement(landingpage.Counterdrug_Dropdown_Option);
                moveToElement(landingpage.CaseManagement_Dropdown_Option);
                ClickObj(landingpage.CaseManagement_Dropdown_Option, "Case Management Dropdown Option");
                //SwitchToNewWindow();
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                commonMethods.AddPersonnelRecordToCompleteTest();
                TestContext.Progress.WriteLine("Captured FullName is: " + commonMethods.CapturedFullName);

                ScrollAndMoveToElement(p1.PersonnelManagementTool_PMT_Tab);
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p1.PersonnelManagementTool_PMT_Tab, "Personnel Management Tool (PMT)");
                ClickObj(p1.ApplicantsPendingHire_Link, "Applicants Pending Hire");
                VerifyText(p2.Status_Value, "Applicants Pending Hire");
                ClickObj(p2.ShowHide_Filters, "Show/Hide Filters");
                EnterTxt(p2.FullName_Input, commonMethods.CapturedFullName, commonMethods.CapturedFullName);
                VerifyText(p2.FullName_Value, commonMethods.CapturedFullName);
                ClickObj(p2.FirstRow, "First Row");
                ScrollAndMoveToElement(p3.CancelDeny_Btn);
                commonMethods.verifyElementDisplay(p3.CancelDeny_Btn, "Cancel/Deny");
                commonMethods.verifyElementDisplay(p3.Approve_Btn, "Approve");
                EnterTxt(p3.ProvideRemarksn_input_field, "Approve", "Entering Approve");
                ClickObj(p3.Approve_Btn, "Approve");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Applicants In Processing");
                commonMethods.verifyElementDisplay(p3.CancelDeny_Btn, "Cancel/Deny");
                VerifyElementIsDisplayed(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ValidateElementText(p3._1stQuestion, "Commander`s Recommendation Memo per FY (within 30 days of application)");
                ValidateElementText(p3._2ndQuestion, "PCARS Point Summary Report or NGB Form 23 A RPAM SM verifies statement is accurate to determine the last 31-day break in orders for the purposes of determining separation pay (within 30 days of application)");
                ValidateElementText(p3._3rdQuestion, "Current copy of IMR with qualifying Medical Readiness Code (within 30 days of application)");
                ValidateElementText(p3._4thQuestion, "HIV (within 2 years of order start date)");
                ValidateElementText(p3._5thQuestion, "PHA (within 1 year of order start date)");
                ValidateElementText(p3._6thQuestion, "If applicable, current copy of DA 3349s, Physical Profiles/AF Form 469 Duty Limiting Condition. SMs on temporary profile are not eligible for orders >29 days");
                ValidateElementText(p3._7thQuestion, "Current passing test DA 705 ACFT. (within 12 months of application) or AFFMS Scorecard (within 1 year of application)");
                ValidateElementText(p3._8thQuestion, "ARNG If applicable, Current copy of DA 5500-R/5501-R Body Fat Content Worksheet or Compliance Memo");
                ValidateElementText(p3._9thQuestion, "Security Clearance Level Verification (30 days or more) (within 30 days of application)");
                ValidateElementText(p3._10thQuestion, "DD 369 Police Record Check Required for all CD (within 30 days of order start date)");
                ValidateElementText(p3._11thQuestion, "Special Requirements for CD Duty (within 30 days of order start date)");

                ClickObj(p3.Yes_RadioBtn_1, "Yes_Radio Button Option 1");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_2, "Yes_Radio Button Option 2");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_3, "Yes_Radio Button Option 3");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_4, "Yes_Radio Button Option 4");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_5, "Yes_Radio Button Option 5");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_6, "Yes_Radio Button Option 6");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_7, "Yes_Radio Button Option 7");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_8, "Yes_Radio Button Option 8");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_9, "Yes_Radio Button Option 9");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.Yes_RadioBtn_10, "Yes_Radio Button Option 10");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_1, "No_Radio Button Option 1");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_2, "No_Radio Button Option 2");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_3, "No_Radio Button Option 3");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_4, "No_Radio Button Option 4");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_5, "No_Radio Button Option 5");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_6, "No_Radio Button Option 6");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_7, "No_Radio Button Option 7");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_8, "No_Radio Button Option 8");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_9, "No_Radio Button Option 9");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_10, "No_Radio Button Option 10");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");

                ClickObj(p3.No_RadioBtn_11, "No_Radio Button Option 11");
                commonMethods.ValidateElementIsEnabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");


                EnterTxt(p3.ProvideRemarksn_input_field, "In-Processing Checklist Complete", "Entering In-Processing Checklist Complete");
                ClickObj(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Pending CDC Acceptance");
                EnterTxt(p3.ProvideRemarksn_input_field, "Cancel/Deny", "Entering Cancel/Deny");
                ClickObj(p3.CancelDeny_Btn, "Cancel/Deny");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "In Active Personnel");
                EnterTxt(p3.ProvideRemarksn_input_field, "Re-Activate (In Processing)", "Entering Re-Activate (In Processing)");
                ClickObj(p3.NReActivateInProcessing_Button, "Re-Activate (In Processing)");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Applicants In Processing");
                commonMethods.verifyElementDisplay(p3.CancelDeny_Btn, "Cancel/Deny");
                commonMethods.verifyElementDisplay(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");



            }));
        }

    }
}
