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
    public class StateMachine11000FundedViaSubmitAsExchangeScenario4Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine11000FundedViaSubmitAsExchangeScenario4Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine11000FundedViaSubmitAsExchangeScenario4()
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

                commonMethods.ValidateElementDisplayed(p3.SubmitForReview_Button, "Submit For Review button");
                commonMethods.ValidateElementDisplayed(p3.CancelRequest_Button, "Cancel Request button");

                ClickObj(p3.SubmitForReview_Button, "Submit For Review button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "CDC Certification");

                commonMethods.ValidateElementDisplayed(p3.SubmitRequest_Button, "Submit Request button");
                commonMethods.ValidateElementDisplayed(p3.CancelRequest_Button, "Cancel Request button");
                commonMethods.ValidateElementDisplayed(p3.SubmitasExchange_Button, "Submit as Exchange button");

                EnterTxt(p3.ProvideRemarksn_input_field, "Submit as Exchange", "Submit as Exchange");
                ClickObj(p3.SubmitasExchange_Button, "Submit as Exchange button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Pending Funding");

                commonMethods.ValidateElementDisplayed(p3.FundRequest_Button, "fund Request button");
                commonMethods.ValidateElementDisplayed(p3.UnfundRequest_Button, "Unfund Request button");

                ClickObj(p3.FundRequest_Button, "fund Request button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Funded");


            }));
        }



    }
}
