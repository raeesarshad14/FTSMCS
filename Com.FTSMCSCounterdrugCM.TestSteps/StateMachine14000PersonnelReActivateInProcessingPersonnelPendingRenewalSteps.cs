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
    // Process is:
    //Approve => Application in process => in-processing checklist complete => pending cdc acceptance
    // accept: complete in proceesing => active personnel => renewal pending => personnel pending renewal
    //  // Checklist Complete => Pending CDC Approval => out process => in active personnel => Re active (in processing)
    public class StateMachine14000PersonnelReActivateInProcessingPersonnelPendingRenewalSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine14000PersonnelReActivateInProcessingPersonnelPendingRenewalSteps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine14000PersonnelReActivateInProcessingPersonnelPendingRenewal()
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
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();

                commonMethods.AddPersonnelRecordToCompleteTest();
                TestContext.Progress.WriteLine("Captured FullName is: " + commonMethods.CapturedFullName);

                ScrollAndMoveToElement(p1.PersonnelManagementTool_PMT_Tab);
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

                ClickObj(p3.Yes_RadioBtn_1, "Yes_Radio Button Option 1");

                ClickObj(p3.Yes_RadioBtn_2, "Yes_Radio Button Option 2");

                ClickObj(p3.Yes_RadioBtn_3, "Yes_Radio Button Option 3");

                ClickObj(p3.Yes_RadioBtn_4, "Yes_Radio Button Option 4");

                ClickObj(p3.Yes_RadioBtn_5, "Yes_Radio Button Option 5");

                ClickObj(p3.Yes_RadioBtn_6, "Yes_Radio Button Option 6");

                ClickObj(p3.Yes_RadioBtn_7, "Yes_Radio Button Option 7");

                ClickObj(p3.Yes_RadioBtn_8, "Yes_Radio Button Option 8");

                ClickObj(p3.Yes_RadioBtn_9, "Yes_Radio Button Option 9");

                ClickObj(p3.Yes_RadioBtn_10, "Yes_Radio Button Option 10");

                ClickObj(p3.Yes_RadioBtn_11, "Yes_Radio Button Option 11");

                EnterTxt(p3.ProvideRemarksn_input_field, "In-Processing Checklist Complete", "Entering In-Processing Checklist Complete");
                ClickObj(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");

                ValidateElementText(p3.CurrentStatus_value, "Pending CDC Acceptance");

                VerifyRadioIsChecked(p3.Yes_RadioBtn_1, "Yes_Radio Button Option 1");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_2, "Yes_Radio Button Option 2");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_3, "Yes_Radio Button Option 3");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_4, "Yes_Radio Button Option 4");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_5, "Yes_Radio Button Option 5");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_6, "Yes_Radio Button Option 6");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_7, "Yes_Radio Button Option 7");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_8, "Yes_Radio Button Option 8");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_9, "Yes_Radio Button Option 9");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_10, "Yes_Radio Button Option 10");
                VerifyRadioIsChecked(p3.Yes_RadioBtn_11, "Yes_Radio Button Option 11");

                EnterTxt(p3.ProvideRemarksn_input_field, "Accept: Complete In-Processing", "Accept: Complete In-Processing");
                ClickObj(p3.AcceptCompleteInProcessing_Btn, "Accept: Complete In-Processing");
                JsClick(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");

                WaitForMessageToAppearByLocator(p3.RedError_message_Locator, "Current Orders are Required.");
                JsClick(p2.RedPopUp_Close_Btn, "Current Orders are Required. PopUp Close Button");


                ClickObj(p3.Order_Tab, "Orders tab");
                commonMethods.AddCurrentAndFutureOrders();
                ClickObj(p3.Personnel_Tab, "Personnel tab");

                EnterTxt(p3.ProvideRemarksn_input_field, "Accept: Complete In-Processing", "Accept: Complete In-Processing");
                ClickObj(p3.AcceptCompleteInProcessing_Btn, "Accept: Complete In-Processing");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Active Personnel");
                verifyElementDisplay(p3.RenewalPending_Btn, "Renewal Pending Button");
                verifyElementDisplay(p3.OutProcess_Btn, "Out Process Button");
                ClickObj(p3.RenewalPending_Btn, "Renewal Pending Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Personnel Pending Renewal");

                ClickObj(p3.Yes2_RadioBtn_1, "Yes_Radio Button Option 1");
                ClickObj(p3.Yes2_RadioBtn_2, "Yes_Radio Button Option 2");
                ClickObj(p3.Yes2_RadioBtn_3, "Yes_Radio Button Option 3");
                ClickObj(p3.Yes2_RadioBtn_4, "Yes_Radio Button Option 4");
                ClickObj(p3.Yes2_RadioBtn_5, "Yes_Radio Button Option 5");
                ClickObj(p3.Yes2_RadioBtn_6, "Yes_Radio Button Option 6");
                ClickObj(p3.Yes2_RadioBtn_7, "Yes_Radio Button Option 7");
                ClickObj(p3.Yes2_RadioBtn_8, "Yes_Radio Button Option 8");
                ClickObj(p3.Yes2_RadioBtn_9, "Yes_Radio Button Option 9");
                ClickObj(p3.Yes2_RadioBtn_10, "Yes_Radio Button Option 10");
                ClickObj(p3.Yes2_RadioBtn_11, "Yes_Radio Button Option 11");

                ClickObj(p3.ChecklistComplete_Btn, "Checklist Complete");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Pending CDC Approval");
                verifyElementDisplay(p3.OutProcess_Btn, "Out Process Button");
                verifyElementDisplay(p3.RenewalApproved_Btn, "Renewal Approved");


                EnterTxt(p3.ProvideRemarksn_input_field, "Out Process", "Out Process");
                ClickObj(p3.OutProcess_Btn, "Out Process");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "In Active Personnel");

                EnterTxt(p3.ProvideRemarksn_input_field, "Re-Activate (In Processing)", "Entering Re-Activate (In Processing)");
                ClickObj(p3.NReActivateInProcessing_Button, "Re-Activate (In Processing)");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Applicants In Processing");
                commonMethods.verifyElementDisplay(p3.CancelDeny_Btn, "Cancel/Deny");
                commonMethods.verifyElementDisplay(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");
                commonMethods.ValidateElementIsDisabled(p3.InProcessingChecklistComplete_Btn, "In-Processing Checklist Complete");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_1, "Yes_Radio Button Option 1");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_2, "Yes_Radio Button Option 2");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_3, "Yes_Radio Button Option 3");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_4, "Yes_Radio Button Option 4");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_5, "Yes_Radio Button Option 5");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_6, "Yes_Radio Button Option 6");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_7, "Yes_Radio Button Option 7");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_8, "Yes_Radio Button Option 8");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_9, "Yes_Radio Button Option 9");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_10, "Yes_Radio Button Option 10");
                VerifyRadioIsNotChecked(p3.Yes_RadioBtn_11, "Yes_Radio Button Option 11");


            }));
        }




    }
}
