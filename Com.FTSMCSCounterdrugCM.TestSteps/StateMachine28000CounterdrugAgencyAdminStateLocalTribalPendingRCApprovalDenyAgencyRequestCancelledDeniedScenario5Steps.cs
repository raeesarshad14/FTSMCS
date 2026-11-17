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
    public class StateMachine28000CounterdrugAgencyAdminStateLocalTribalPendingRCApprovalDenyAgencyRequestCancelledDeniedScenario5Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine28000CounterdrugAgencyAdminStateLocalTribalPendingRCApprovalDenyAgencyRequestCancelledDeniedScenario5Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine28000CounterdrugAgencyAdminStateLocalTribalPendingRCApprovalDenyAgencyRequestCancelledDeniedScenario5()
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
                commonMethods.AddRequestNewAgency();
                VerifyElementIsDisplayed(p3.SubmitForApproval_Button, "Submit For Approval Button");
                VerifyElementIsDisplayed(p3.DenyAgencyRequest_Button, "Deny Agency Request");
                ClickObj(p3.SubmitForApproval_Button, "Submit For Approval Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "State, Local, Tribal Pending RC Approval");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "State, Local, Tribal Pending RC Approval");
                VerifyElementIsDisplayed(p3.ApproveAgency_Button, "Approve Agency Button");
                VerifyElementIsDisplayed(p3.DenyAgencyRequest_Button, "Deny Agency Request");
                EnterTxt(p3.ProvideRemarksn_input_field, "Deny Agency Request", "Deny Agency Request");
                ClickObj(p3.DenyAgencyRequest_Button, "Deny Agency Request");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Cancelled/Denied");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Cancelled/Denied");

            }));
        }



    }
}
