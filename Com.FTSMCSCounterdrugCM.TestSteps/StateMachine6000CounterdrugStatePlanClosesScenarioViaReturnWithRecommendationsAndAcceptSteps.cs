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
    public class StateMachine6000CounterdrugStatePlanClosesScenarioViaReturnWithRecommendationsAndAcceptSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        // in progress => Submit to CDC => CDC Certification => 
        public StateMachine6000CounterdrugStatePlanClosesScenarioViaReturnWithRecommendationsAndAcceptSteps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine6000CounterdrugStatePlanClosesScenarioViaReturnWithRecommendationsAndAccept()
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

                ShowPopup("Run the query to get the record available. Query is in this method nad run this manually: " +
    "commonMethods.ResetStatePlanReturnCloseTestData ");

                ClickObj(p1.StatePlan_Blade, "State Plan (SP) Blade");
                WaitForElement(p1.Refresh_Button);
                WaitForElement(p1.OpentoStates_Link);
                ClickObj(p1.OpentoStates_Link, "Open to States Link");

                ClickObj(p2.ShowHide_Filters, "Show/Hide Filters");
                EnterTxt(p2.State_Input, "Illinois", "Illinois");

                string CapturedState = GetElementText(p2.State_Value, "State");
                TestContext.Progress.WriteLine("Captured State: " + CapturedState);
                string CapturedCaseCode = GetElementText(p2.CaseCode_Value, "Case Code");
                TestContext.Progress.WriteLine("Captured Case Code: " + CapturedCaseCode);
                ClickObj(p2.FirstRow, "First Row");
                ValidateElementTextContain(p3.CurrentStatus_value, "In Progress");
                ClickObj(p3.SubmittoCDC_Button, "Submit to CDC Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus_value, "CDC Certification");
                commonMethods.verifyElementDisplay(p3.SubmittoNGB_Button, "Submit to NGB Button");
                commonMethods.verifyElementDisplay(p3.ReturnwithRecommendationstoState_Button, "Return with Recommendations to State Button");
                ClickObj(p3.SubmittoNGB_Button, "Submit to NGB Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus_value, "NGB PM Review");
                commonMethods.verifyElementDisplay(p3.Return_Button, "Return Button");
                commonMethods.verifyElementDisplay(p3.ReturnwithRecommendations_Button, "Return with Recommendations Button");
                ClickObj(p3.ReturnwithRecommendations_Button, "Return with Recommendations Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus_value, "Returned After NGB PM Review");
                commonMethods.verifyElementDisplay(p3.SubmitforSignatures_Button, "Submit for Signatures");
                ClickObj(p3.SubmitforSignatures_Button, "Submit for Signatures");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus_value, "Submitted for Signatures");
                commonMethods.verifyElementDisplay(p3.SubmittoNGB_Button, "Submit to NGB Button");
                commonMethods.verifyElementDisplay(p3.CDCReturntoStateForRevision_Button, "CDC Return to State For Revision");
                ClickObj(p3.SubmittoNGB_Button, "Submit to NGB Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus_value, "NGB PM Verification");
                commonMethods.verifyElementDisplay(p3.Accept_Button, "Accept Button");
                commonMethods.verifyElementDisplay(p3.ReturnwithRecommendationstoState_Button, "Return with Recommendations to State Button");
                ClickObj(p3.Accept_Button, "Accept Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus_value, "Assessment");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Going Back to Panel 1");
                ClickObj(p1.InProgress_Link, "In Progress  Link");
                ClickObj(p2.ShowHide_Filters, "Show Hide Filters");
                EnterTxt(p2.State_Input, CapturedState, CapturedState);
                EnterTxt(p2.StatePlanCaseCode_Input, CapturedCaseCode, CapturedCaseCode);
                EnterTxt(p2.DaysInCurrentStatus_Input, "1", "1");
                ClickObj(p2.FirstRow, "First Row");
                ValidateElementTextContain(p3.CurrentStatus2_value, "In Progress State");
                ClickObj(p3.SubmittoCDC_Button, "Submit to CDC Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus2_value, "CDC Certification");
                commonMethods.verifyElementDisplay(p3.SubmittoNGB_Button, "Submit to NGB Button");
                commonMethods.verifyElementDisplay(p3.ReturnwithRecommendationstoStateAdmin_Button, "Return with Recommendations to State Admin Button");
                ClickObj(p3.SubmittoNGB_Button, "Submit to NGB Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus2_value, "NGB PM Review");
                commonMethods.verifyElementDisplay(p3.ReturnwithRecommendationstoStateAdmin_Button, "Return with Recommendations to State Admin Button");
                commonMethods.verifyElementDisplay(p3.Approve2_Btn, "Approve Button");
                ClickObj(p3.Approve2_Btn, "Approve Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus2_value, "Complete");
                commonMethods.verifyElementDisplay(p3.Close2_Button, "Close Button");
                EnterTxt(p3.ProvideRemarksn_input_field2, "CLose", "Entered Closed Text");
                ClickObj(p3.Close2_Button, "Close Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus2_value, "Closed");

            }));
        }


    }
}
