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
    public class StateMachine12000CancelledViaCancelRequestScenario1Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine12000CancelledViaCancelRequestScenario1Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine12000CancelledViaCancelRequestScenario1()
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
                JsMoveTo(landingpage.TurnInFunds_Option);
                JsClick(landingpage.TurnInFunds_Option, "Turn In Funds Dropdown Option");
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p2.ExchangingFunds_No_Button, "Exchanging Funds");
                EnterTxt(p2.CurrentYearTargetAmount_Input_Field2, "2000000", "2000000");
                EnterTxt(p2.PriorYearTarget_Input_Field, "1000000", "1000000");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Kentucky");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "Air National Guard");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_6, p2.DropDown_List, "D5 - D5 (State: KY, MPF: D8, Unit: 123 AW)");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_7, p2.DropDown_List, "FedOps");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "1295 - RINGGOLD");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "DR - OM(RG) - RINGGOLD ANG Operations & Maintentnace");

                EnterTxt(p2.MissionImpact_Input_Field, "Mission Impact", "Mission Impact");

                EnterTxt(p2.ANGOMReturned_Input_Field, "1000000", "1000000");

                EnterTxt(p2.OctoberDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.NovemberDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.DecemberDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.JanuaryDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.FebruaryDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.MarchDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.AprilDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.MayDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.JuneDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.JulyDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.AugustDollarsReturned_Input_Field, "1000", "1000"); ;

                EnterTxt(p2.SeptemberDollarsReturned_Input_Field, "1000", "1000");

                EnterTxt(p2.TotalDollarsReturned_Input_Field, "12000", "12000");

                ClickObj(p2.Add_Btn, "Add Button");

                ValidateElementText(p3.FundingRevisionType_Value, "Turn In Funds");

                ValidateElementText(p3.State_Value, "Kentucky");

                ValidateElementText(p3.CurrentYearTargetAmount_value, "$2,000,000.00");

                ValidateElementText(p3.PriorYearTarget_value, "$1,000,000.00");

                ValidateElementText(p3.Justification_value, "Mission Impact");

                ValidateElementText(p3.ReturnBranch_value, "ANG");

                ValidateElementText(p3.MissionType_value, "FedOps");

                ValidateElementText(p3.ProjectCode_value, "1295 - RINGGOLD");

                ValidateElementText(p3.FundCode_value, "RINGGOLD ANG Operations & Maintentnace");

                ValidateElementText(p3.ASN_value, "D5");

                ValidateElementText(p3.ANGMILPERSAmountReturned_value, "$0.00");

                ValidateElementText(p3.ANGEnlistedATAmountReturned_value, "$0.00");

                ValidateElementText(p3.ANGOfficerATAmountReturned_value, "$0.00");

                ValidateElementText(p3.ANGOMReturned_value, "$1,000,000.00");

                ValidateElementText(p3.ANGEnlistedIDTAmountReturned_value, "$0.00");

                ValidateElementText(p3.ANGOfficerIDTAmountReturned_value, "$0.00");

                ValidateElementText(p3.ANGEnlistedAmountReturned_value, "$0.00");
                
                ValidateElementText(p3.ANGOfficerAmountReturned_value, "$0.00");

                ValidateElementText(p3.OctoberDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.NovemberDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.DecemberDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.JanuaryDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.FebruaryDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.MarchDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.AprilDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.MayDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.JuneDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.JulyDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.AugustDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.SeptemberDollarsReturned_value, "$1,000.00");

                ValidateElementText(p3.TotalDollarsReturned_value, "$12,000.00");

                ValidateElementText(p3.CurrentStatus_value, "Turn-In Initiated");

                commonMethods.ValidateElementDisplayed(p3.SubmittoCDC_Button, "Submit to CDC button");
                commonMethods.ValidateElementDisplayed(p3.CancelRequest_Button, "Cancel Request button");

                EnterTxt(p3.ProvideRemarksn_input_field, "Submit Request button", "Submit Request button");
                ClickObj(p3.CancelRequest_Button, "Cancel Request button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Cancelled");


            }));
        }

         
    }
}
