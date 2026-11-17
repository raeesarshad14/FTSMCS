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
    public class StateMachine9000ASRCounterdrugCancelSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        // https://tibercreekgcc-my.sharepoint.com/:w:/g/personal/sherri_washington_tibercreek_com/IQCe6xwz2R_YSIkL59OaYO5cAV-HILUc_PFZ0hNrA-Aym3M?wdOrigin=TEAMS-MAGLEV.p2p_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1767720499775&web=1


        public StateMachine9000ASRCounterdrugCancelSteps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine9000ASRCounterdrugCancel()
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
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                commonMethods.CreateASR();
                commonMethods.CreateASRMission();
                ClickObj(p1.AgencySupportRequestASR_Blade, "Agency Support Request ASR");
                WaitForElementByLocator(p1.ASRAdministration_Refresh_Button_ByLoacator);
                string FiscalYear = GetFiscalYearAsString("0000");
                TestContext.Progress.WriteLine("Fiscal Year is: " + FiscalYear);
                p1.FiscalYear = FiscalYear;
                TestContext.Progress.WriteLine("Panel1Page Fiscal Year is: " + p1.FiscalYear);
                ClickObj(p1.AerialReconnaissance_2026_link, "Aerial Reconnaissance");
                ClickObj(p1.AerialReconnaissance_2026_ASRMission_link, "Aerial Reconnaissance => ASR Mission");
                ClickObj(p1.AerialReconnaissance_2026_Inactive_link, "Aerial Reconnaissance Inactive link");
                ClickObj(p2.ShowHide_Filters, "Show Hide Filters");
                EnterTxt(p2.State_Input, "Alaska", "Alaska");
                EnterTxt(p2.FiscalYear_Input, FiscalYear, FiscalYear);
                EnterTxt(p2.DrugThreat_Input, "Cannabis", "Cannabis");
                EnterTxt(p2.Status_Input, "Inactive", "Inactive");
                ClickObj(p2.FirstRow, "First Row");
                ValidateElementText(p3.ASRMissionSummary_State_Value, "Alaska");
                ValidateElementText(p3.ASRMissionSummary_Program_Value, "State Counterdrug");
                ValidateElementText(p3.ASRMissionSummary_RequestingAgency_Value, "Directorate for National Protection and Programs (US)");
                ValidateElementText(p3.ASRMissionSummary_AgencyLocationTaskForceOrCoalitiont_Value, "CA NPPD");
                ValidateElementText(p3.MissionInformation_CurrentStatus_Value, "Inactive");
                string FiscalYearstatrDate = GetFiscalYearStartAsString("yyyyMMdd");
                string FiscalYearEndDate = GetFiscalYearEndAsString("yyyyMMdd");
                ValidateElementText(p3.MissionInformation_MissionStartDate_Value, FiscalYearstatrDate);
                ValidateElementText(p3.MissionInformation_MissionEndtDate_Value, FiscalYearEndDate);
                ValidateElementText(p3.MissionInformation_Activity_Value, "Aerial Reconnaissance");
                ValidateElementText(p3.MissionInformation_DrugThreat_Value, "Cannabis");
                ValidateElementText(p3.MissionInformation_Tab_MissionStartDate_Value, FiscalYearstatrDate);
                ValidateElementText(p3.MissionInformation_Tab_MissionEndDate_Value, FiscalYearEndDate);
                ValidateElementText(p3.MissionInformation_Tab_Activity_Value, "Aerial Reconnaissance");
                ValidateElementText(p3.MissionInformation_Tab_DrugThreat_Value, "Cannabis");
                ValidateElementText(p3.MissionInformation_Tab_AgencyLocationTaskForceOrCoalition_Value, "CA NPPD");
                ScrollAndMoveToElement(p3.MovetoActive_Btn);
                VerifyElementIsDisplayed(p3.MovetoActive_Btn, "Move to Active Button");
                ScrollAndMoveToElement(p3.CancelMission_Btn);
                VerifyElementIsDisplayed(p3.CancelMission_Btn, "Cancel Mission");
                EnterTxt(p3.ProvideRemarksn_input_field, "Cancel Mission", "Entering Cancel Mission Text");
                ClickObj(p3.CancelMission_Btn, "Cancel Mission");
                ClickObj(p3.PopUp_Yes_Btn, "Yes Popup Button");
                ValidateElementText(p3.MissionInformation_CurrentStatus_Value, "Cancelled");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Cancelled");
                EnterTxt(p3.ProvideRemarksn_input_field, "Undo", "Entering Undo Text");
                ClickObj(p3.Undo_Btn, "Undo Btn");
                ClickObj(p3.PopUp_Yes_Btn, "Yes Popup Button");
                ValidateElementText(p3.MissionInformation_CurrentStatus_Value, "Inactive");
                ScrollAndMoveToElement(p3.MovetoActive_Btn);
                VerifyElementIsDisplayed(p3.MovetoActive_Btn, "Move to Active Button");
                ScrollAndMoveToElement(p3.CancelMission_Btn);
                VerifyElementIsDisplayed(p3.CancelMission_Btn, "Cancel Mission");

            }));
        }



    }
}
