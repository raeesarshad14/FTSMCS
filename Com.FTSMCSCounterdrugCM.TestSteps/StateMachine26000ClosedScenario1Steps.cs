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
    public class StateMachine26000ClosedScenario1Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine26000ClosedScenario1Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine26000ClosedScenario1()
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
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                JsClick(landingpage.DeveloperTools_Dropdown, "Developer Tools Dropdown");

                JsMoveTo(landingpage.CAP_Option);
                JsClick(landingpage.CAPQC_Option, "CAP QC Option");

                WaitForElement(landingpage.PopUp_Text);
                string capturedCAPQCPopupText = GetElementText(landingpage.PopUp_Text, "CAP QC Popup Text");
                VerifyElementText(landingpage.PopUp_Text, capturedCAPQCPopupText);
                ClickObj(landingpage.PopUp_Ok_Btn, "Pop up OK Button");

                ClickObj(p1.ComplianceAssuranceProgram_Blade, "Compliance Assurance Program (CAP) Blade");
                WaitForElement(p1.Refresh_Button);
                ClickObj(p1.QCInitiated_Link, "QC Initiated Link");
                ClickObj(p2.FirstRow, "First Row");
                ClickObj(p3.ManageCAPQC_Tab, "Manage CAP QC Tab");

                ValidateElementText(p3.CurrentStatus_value, "Initial State");
                ValidateElementText(p3.Description_value, "Initial State");
                commonMethods.verifyElementDisplay(p3.StartQC_Button, "Start QC Button");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Initial case creation for quarter.");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, string.Empty);
                ValidateElementText(p3.HistoryofActions_Action_Value, string.Empty);
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Initial State");

                ClickObj(p3.StartQC_Button, "Start QC Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");

                ValidateElementText(p3.CurrentStatus_value, "In Progress");
                ValidateElementText(p3.Description_value, "In Progress");
                commonMethods.verifyElementDisplay(p3.Submit_Button, "Submit Button");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Auto Remarks: Start QC");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Initial State");
                ValidateElementText(p3.HistoryofActions_Action_Value, "Start QC");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "In Progress");

                ClickObj(p3.Submit_Button, "Submit Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");

                ClickObj(p3.CDCCertificationChecklist_Tab, "CDC Certification Checklist Tab");
                ValidateElementText(p3.CurrentStatus_value, "Pending Validation");
                ValidateElementText(p3.Description_value, "Pending Validation");
                commonMethods.ValidateElementIsDisabled(p3.Certify_Button, "Certify Button");

                Assert.That(p3.CDCCertification_QuestionList.Count, Is.EqualTo(17), "Expected 17 CDC Certification questions.");
                Assert.That(p3.CDCCertification_YesRadioButtonList.Count, Is.EqualTo(17), "Expected 17 CDC Certification Yes radio buttons.");
                Assert.That(p3.CDCCertification_NoRadioButtonList.Count, Is.EqualTo(17), "Expected 17 CDC Certification No radio buttons.");

                List<string> capturedQuestionTextList = new List<string>();

                for (int i = 0; i < p3.CDCCertification_QuestionList.Count; i++)
                {
                    string capturedQuestionText = GetElementText(p3.CDCCertification_QuestionList[i], $"CDC Certification Question {i + 1}");
                    capturedQuestionTextList.Add(capturedQuestionText);
                    ValidateElementText(p3.CDCCertification_QuestionList[i], capturedQuestionText);
                    ClickObj(p3.CDCCertification_YesRadioButtonList[i], $"CDC Certification Yes Radio Button {i + 1}");
                    VerifyRadioIsChecked(p3.CDCCertification_YesRadioButtonList[i], $"CDC Certification Yes Radio Button {i + 1}");
                    VerifyRadioIsNotChecked(p3.CDCCertification_NoRadioButtonList[i], $"CDC Certification No Radio Button {i + 1}");
                }

                commonMethods.ValidateElementIsEnabled(p3.Certify_Button, "Certify Button");
                ClickObj(p3.Certify_Button, "Certify Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");

                for (int i = 0; i < p3.CDCCertification_QuestionList.Count; i++)
                {
                    ValidateElementText(p3.CDCCertification_QuestionList[i], capturedQuestionTextList[i]);
                    VerifyRadioIsChecked(p3.CDCCertification_YesRadioButtonList[i], $"CDC Certification Yes Radio Button {i + 1}");
                    VerifyRadioIsNotChecked(p3.CDCCertification_NoRadioButtonList[i], $"CDC Certification No Radio Button {i + 1}");
                }

                ClickObj(p3.ManageCAPQC_Tab, "Manage CAP QC Tab");
                ValidateElementText(p3.CurrentStatus_value, "Pending Verification");
                ValidateElementText(p3.Description_value, "Pending Verification");
                commonMethods.verifyElementDisplay(p3.Verify_Button, "Verify Button");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Auto Remarks: Certify");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Pending Validation");
                ValidateElementText(p3.HistoryofActions_Action_Value, "Certify");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Pending Verification");

                string capturedPreviousStatusBeforeVerify = GetElementText(p3.CurrentStatus_value, "Current Status Before Verify");
                EnterTxt(p3.ProvideRemarksn_input_field, "verify", "Entering verify remarks");
                ClickObj(p3.Verify_Button, "Verify Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");

                ValidateElementText(p3.CurrentStatus_value, "Closed");
                ValidateElementText(p3.Description_value, "Closed");
                ValidateElementText(p3.HistoryofActions_Note_Value, "verify");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, capturedPreviousStatusBeforeVerify);
                ValidateElementText(p3.HistoryofActions_Action_Value, "Verify");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Closed");

            }));
        }



    }
}
