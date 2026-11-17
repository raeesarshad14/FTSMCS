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
    public class StateMachine11000UnFundedScenario2Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine11000UnFundedScenario2Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine11000UnFundedScenario2()
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
                JsClick(landingpage.QuickLinks_DropDown, "Quick Links Drop Down Arrow Icon");
                JsMoveTo(landingpage.RequestFunds_Option);
                JsClick(landingpage.RequestFunds_Option, "Request Funds Dropdown Option");
                //SwitchToNewWindow();
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p2.ExchangingFunds_No_Button, "Exchanging Funds");
                EnterTxt(p2.CurrentYearTargetAmount_Input_Field, "2000000", "2000000");
                EnterTxt(p2.PriorYearTarget_Input_Field, "1000000", "1000000");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Kentucky");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "Air National Guard");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_6, p2.DropDown_List, "D5 - D5 (State: KY, MPF: D8, Unit: 123 AW)");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_7, p2.DropDown_List, "FedOps");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "1295 - RINGGOLD");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "RINGGOLD ANG Operations & Maintentnace");

                EnterTxt(p2.Justification_Input_Field, "Justification", "Justification");

                ClickObj(p3.Receivedallofyourfunding_No_Option1, "Have you received all of your funding (AFP only refers to Army funds)? No Option");

                ClickObj(p3.ANGreimbursementstodate_No_Option2, "Have you accounted for all of your ANG reimbursements to date? No Option");

                ClickObj(p3.HaveyoureceivedallofARNGreimbursements_No_Option3, "Have you received all of ARNG reimbursements to date? No Option");

                EnterTxt(p2.ANGOMRequested_Input_Field, "1000000", "1000000");

                EnterTxt(p2.OctoberDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.NovemberDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.DecemberDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.JanuaryDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.FebruaryDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.MarchDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.AprilDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.MayDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.JuneDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.JulyDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.AugustDollarsRequested_Input_Field, "1000", "1000"); ;

                EnterTxt(p2.SeptemberDollarsRequested_Input_Field, "1000", "1000");

                EnterTxt(p2.TotalDollarsRequested_Input_Field, "12000", "12000");

                ClickObj(p2.Add_Btn, "Add Button");

                ValidateElementText(p3.FundingRevisionType_Value, "Request Funds");

                ValidateElementText(p3.State_Value, "Kentucky");

                ValidateElementText(p3.CurrentYearTargetAmount_value, "$2,000,000.00");

                ValidateElementText(p3.PriorYearTarget_value, "$1,000,000.00");

                ValidateElementText(p3.Justification_value, "Justification");

                ValidateElementText(p3.RequestBranch_value, "Air National Guard");

                ValidateElementText(p3.MissionType_value, "FedOps");

                ValidateElementText(p3.ProjectCode_value, "1295 - RINGGOLD");

                ValidateElementText(p3.FundCode_value, "RINGGOLD ANG Operations & Maintentnace");

                ValidateElementText(p3.ANGASN_value, "D5");

                ValidateElementText(p3.ANGMILPERSAmountRequested_value, "$0.00");

                ValidateElementText(p3.ANGEnlistedIDTAmountRequested_value, "$0.00");

                ValidateElementText(p3.ANGOfficerIDTAmountRequested_value, "$0.00");

                ValidateElementText(p3.ANGOMRequested_value, "$1,000,000.00");

                ValidateElementText(p3.ANGEnlistedATAmountRequested_value, "$0.00");

                ValidateElementText(p3.ANGOfficerATAmountRequested_value, "$0.00");

                ValidateElementText(p3.ANGEnlistedAmountRequested_value, "$0.00");

                ValidateElementText(p3.ANGOfficerAmountRequested_value, "$0.00");

                ValidateElementText(p3.OctoberDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.NovemberDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.DecemberDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.JanuaryDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.FebruaryDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.MarchDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.AprilDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.MayDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.JuneDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.JulyDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.AugustDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.SeptemberDollarsRequested_value, "$1,000.00");

                ValidateElementText(p3.TotalDollarsRequested_value, "$12,000.00");

                ValidateElementText(p3.CurrentStatus_value, "State Submission Pending");

                commonMethods.ValidateElementDisplayed(p3.SubmitForReview_Button, "Submit For Review button");
                commonMethods.ValidateElementDisplayed(p3.CancelRequest_Button, "Cancel Request button");

                ClickObj(p3.FundingRevisionBoardRequirements_Tab, "Funding Revision Board Requirements Tab");

                ValidateElementTextContain(p3.FRBR_Tab_Question_1, "Is this an Enduring Mission?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 1 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 1 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 1 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_2, "Is this on the next FY State Plan (Mission Susstainment)?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 2 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 2 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 2 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_3, "Will this person support an enduring mission?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 3 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 3 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 3 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_4, "Was this due to a reduced target?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 4 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 4 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 4 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_5, "Is this request for personnel currently on orders?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 5 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 5 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 5 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_6, "If unfunded, will this result in separation pay to be disbursed?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 6 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 6 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 6 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_7, "Is travel required for NGB mandated functional area training or State purposes?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 7 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 7 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 7 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_8, "Can this be done virtually?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 8 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 8 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 8 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_9, "Is this purchase going to require a 5K packet?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 9 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 9 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 9 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_10, "Has $5K packet been submitted to NGB-J32 for staffing?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 10 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 10 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 10 Next Button Clicked");

                ValidateElementTextContain(p3.FRBR_Tab_Question_11, "Is this request for an existing requirement?");
                ClickObj(p3.FRBR_Tab_Question_Yes, "Question 11 Yes Selected");
                ClickObj(p3.btnSurveyResponseSave_Btn, "Question 11 Saved Button Clicked");
                ClickObj(p3.btnSurveyResponseNext_Btn, "Question 11 Next Button Clicked");

                ValidateElementText(p3.Question1_Yes_Answer, "Yes");
                ValidateElementText(p3.Question2_Yes_Answer, "Yes");
                ValidateElementText(p3.Question3_Yes_Answer, "Yes");
                ValidateElementText(p3.Question4_Yes_Answer, "Yes");
                ValidateElementText(p3.Question5_Yes_Answer, "Yes");
                ValidateElementText(p3.Question6_Yes_Answer, "Yes");
                ValidateElementText(p3.Question7_Yes_Answer, "Yes");
                ValidateElementText(p3.Question8_Yes_Answer, "Yes");

                ClickObj(p3.ManageFundingRevision_Tab, "Manage Funding Revision Tab");

                ClickObj(p3.SubmitForReview_Button, "Submit For Review button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "CDC Certification");

                commonMethods.ValidateElementDisplayed(p3.SubmitRequest_Button, "Submit Request button");
                commonMethods.ValidateElementDisplayed(p3.CancelRequest_Button, "Cancel Request button");
                commonMethods.ValidateElementDisplayed(p3.SubmitasExchange_Button, "Submit as Exchange button");

                EnterTxt(p3.ProvideRemarksn_input_field, "Submit Request button", "Submit Request button");
                ClickObj(p3.SubmitRequest_Button, "Submit Request button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Pending Board");

                commonMethods.ValidateElementDisplayed(p3.ConductBoardPrioritize_Button, "Conduct Board: Prioritize button");
                commonMethods.ValidateElementDisplayed(p3.NonConcurWithRequest_Button, "Non-Concur With Request button");

                ClickObj(p3.ConductBoardPrioritize_Button, "Conduct Board: Prioritize button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Boarded");

                ClickObj(p3.CeritifyRequest_Button, "Ceritify Request button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Pending Funding");

                commonMethods.ValidateElementDisplayed(p3.FundRequest_Button, "fund Request button");
                commonMethods.ValidateElementDisplayed(p3.UnfundRequest_Button, "Unfund Request button");

                ClickObj(p3.UnfundRequest_Button, "Unfund Request button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Unfunded");

            }));
        }
    }
}
