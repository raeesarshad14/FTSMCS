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
    public class StateMachine1000and2000OverrideViaSubmitToNGBCapAdminScenario1Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine1000and2000OverrideViaSubmitToNGBCapAdminScenario1Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine1000and2000OverrideViaSubmitToNGBCapAdminScenario1()
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
                moveToElement(landingpage.Counterdrug_Dropdown_Option);
                moveToElement(landingpage.CaseManagement_Dropdown_Option);
                ClickObj(landingpage.CaseManagement_Dropdown_Option, "Case Management Dropdown Option");
                //SwitchToNewWindow();
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p1.ComplianceAssuranceProgram_Blade, "Compliance Assurance Program (CAP) Blade");
                WaitForElementByLocator(p1.Refresh_ByLoacator);
                WaitForElementByLocator(p1.SearchesDropDown_Locator);
                SelectFromCustomDropdownByText(p1.SearchesDropDown_Arrow, p1.SearchesDropDown_Options, "Annual Assessment");
                ClickObj(p1.Search_Btn, "Search Button");
                commonMethods.CloseStateCounterDrugCaseIfOpened();
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "FY 27");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "State Counterdrug");
                string RandomString = GenerateRandomAlphaNumeric();
                TestContext.Progress.Write("Random String for Description is: " + RandomString);
                Reporting.infoLog("Random String for Description is: " + RandomString);
                EnterTxt(p2.Description_Input, RandomString, RandomString);
                ClickObj(p2.Add_Btn, "Add Button");
                EnterTxt(p2.Description_Input_2, RandomString, RandomString);
                ClickObj(p2.FirstRow, "New Created Record");
                ClickObj(p3.Questions_Tab, "Questions Tab");
                ClickObj(p3.QuestionssectionAdd_Icon, "Questions section Add Icon");
                SelectFromCustomDropdownByText(p3.Dropdown_Arrow_1, p3.DropdDownOptions, "State Counterdrug");
                SelectFromCustomDropdownByText(p3.Dropdown_Arrow_2, p3.DropdDownOptions, "Analyst Support");
                SelectDropDownCheckboxOptionByIndex(p3.Dropdown_Arrow_3, p2.DropDown_List, 0);
                ClickObj(p3.Dropdown_Arrow_1, "Clicking Dropdown Arrow ");
                ClickObj(p3.Add_Btn, "Add Button");
                ClickObj(p3.Questionnaires_Tab, "Questionnaire(s) Tab");
                ClickObj(p3.QuestionnairesAdd_Icon, "Questionnaire(s) section Add Icon");
                SelectDropDownCheckboxOptionByIndex(p3.Dropdown_Arrow_1, p3.DropdDownOptions, 0);
                ClickObj(p3.Dropdown_Arrow_1, "Clicking Dropdown Arrow ");
                SelectFromCustomDropdownByText(p3.Dropdown_Arrow_2, p3.DropdDownOptions, "Onsite Assessment Visit");
                ClickObj(p3.IsActive_Yes, "Yes Selected for Is Active Option");
                ClickObj(p3.Add_Btn, "Add Button");
                ClickObj(p3.Actions_Tab, "Actions Tab");
                ValidateElementText(p3.CurrentStatus_value, "Created");
                ValidateElementText(p3.Description_value, "Create Annual Assessment");
                ClickObj(p3.Open_Btn, "Open Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Yp Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Open");
                ValidateElementText(p3.Description_value, "Open Annual Assessment");
                commonMethods.verifyElementDisplay(p3.Close_Button, "Close Button");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn1, "Cancel Button");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn1, "Cancel Button");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Going back to command center");
                ClickObj(p1.StateCAPAdmin_Link, "State CAP Admin Link");
                ClickObj(p2.ShowHide_Filters, "Show Hide Filter");
                EnterTxt(p2.DaysInCurrentStatus_Input, "1", "1");
                ValidateElementText(p2.Program_Value, "State Counterdrug");
                ValidateElementText(p2.Status_Value, "State CAP Admin");
                ValidateElementText(p2.EvaluationType_Value, "Onsite Assessment Visit");
                ClickObj(p2.FirstRow, "First Row");
                ClickObj(p3.NeedsImprovement_CheckBox, "Needs Improvement CheckBox");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Save Button");
                ClickObj(p3.SurveyResponse_Next_Btn, "Next Button");
                ValidateElementText(p3.CurrentStatus_value, "State CAP Admin");
                ValidateElementText(p3.Description_value, "State CAP Admin - complete questionnaire");
                commonMethods.verifyElementDisplay(p3.SubmittoCDC_Button, "Submit to CDC Button");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn1, "Cancel Button");
                ClickObj(p3.SubmittoCDC_Button, "Submit to CDC Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Yp Yes Button");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Going back to command center");
                ClickObj(p1.CDCReview_Link, "CDC Review Link");
                ClickObj(p2.ShowHide_Filters, "Show Hide Filter");
                EnterTxt(p2.DaysInCurrentStatus_Input, "1", "1");
                ValidateElementText(p2.Program_Value, "State Counterdrug");
                ValidateElementText(p2.EvaluationType_Value, "Onsite Assessment Visit");
                ValidateElementText(p2.Status_Value, "CDC Review");
                ClickObj(p2.FirstRow, "First Row");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Save Button");
                ClickObj(p3.SurveyResponse_Next_Btn, "Next Button");
                ValidateElementText(p3.CurrentStatus_value, "CDC Review");
                ValidateElementText(p3.Description_value, "CDC Review");
                commonMethods.verifyElementDisplay(p3.SubmittoNGBPM_Button, "Submit to NGB PM Button");
                commonMethods.verifyElementDisplay(p3.ReturntoStateCAPAdmin_Button, "Return to State CAP Admin");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn1, "Cancel Button");
                ClickObj(p3.SubmittoNGBPM_Button, "Submit to NGB PM Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Yp Yes Button");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Going back to command center");
                ClickObj(p1.NGBPMVerification_Link, "NGB PM Verification Link");

                ClickObj(p2.ShowHide_Filters, "Show Hide Filter");
                EnterTxt(p2.DaysInCurrentStatus_Input, "1", "1");
                ValidateElementText(p2.Program_Value, "State Counterdrug");
                ValidateElementText(p2.EvaluationType_Value, "Onsite Assessment Visit");
                ValidateElementText(p2.Status_Value, "NGB PM Verification");
                ClickObj(p2.FirstRow, "First Row");
                ClickObj(p3.Edit_Response, "Edit Response");
                ClickObj(p3.btnSurveyResponseAccept_Btn, "Accept Button");
                commonMethods.verifyElementDisplay(p3.SubmittoNGBCAPAdmin_Button, "Submit to NGB CAP Admin Button");
                commonMethods.verifyElementDisplay(p3.VirtualVerificationandSubmittoNGBCAPAdmin_Button, "Virtual Verification and Submit to NGB CAP Admin Button");
                commonMethods.verifyElementDisplay(p3.ReturntoCDC_Button, "Return to CDC Button");
                commonMethods.verifyElementDisplay(p3.ReturntoStateCAPAdmin_Button, "Return to State CAP Admin Button");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn1, "Cancel Button");
                ClickObj(p3.SubmittoNGBCAPAdmin_Button, "Submit to NGB CAP Admin Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Yp Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "NGB CAP Admin Validation");
                ValidateElementText(p3.Description_value, "NGB CAP Admin Validation");
                commonMethods.verifyElementDisplay(p3.CompleteAnnualQuestionnaire_Button, "Complete Annual Questionnaire Button");
                commonMethods.verifyElementDisplay(p3.VirtualVerificationandCompleteAnnualQuestionnaire_Button, "Virtual Verification and Complete Annual Questionnaire Button");
                commonMethods.verifyElementDisplay(p3.ReturntoNGBPM_Button, "Return to NGB PM Button");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn1, "Cancel Button");
                ClickObj(p3.CompleteAnnualQuestionnaire_Button, "Complete Annual Questionnaire Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Yp Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Completed");
                ValidateElementText(p3.Description_value, "Completed");
                commonMethods.verifyElementDisplay(p3.Override_Button, "Override Button");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Going back to command center");
                SelectFromCustomDropdownByText(p1.SearchesDropDown_Arrow, p1.SearchesDropDown_Options, "Annual Assessment");
                ClickObj(p1.Search_Btn, "Search Button");
                ClickObj(p2.ShowHide_Filters, "Show Hide Filters");
                EnterTxt(p2.Description_Input_2, RandomString, RandomString);
                ClickObj(p2.FirstRow, "First Row");
                commonMethods.verifyElementDisplay(p3.Close_Button, "Close Button");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn1, "Cancel Button");
                commonMethods.verifyElementDisplay(p3.Revise_Btn1, "Revise Button");
                EnterTxt(p3.ProvideRemarksn_input_field, "Closing", "Closing");
                ClickObj(p3.Close_Button, "Close Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Yp Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Closed");
                ValidateElementText(p3.Description_value, "Close Annual Assessment");



            }));
        }








    }
}
