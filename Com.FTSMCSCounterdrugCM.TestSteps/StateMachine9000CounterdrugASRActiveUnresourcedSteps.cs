using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps
{

    // Create Event => Personal Working => Active => Unresource => Unresourced 
    public class StateMachine9000CounterdrugASRActiveUnresourcedSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //https://tibercreekgcc-my.sharepoint.com/:w:/g/personal/sherri_washington_tibercreek_com/IQAxHoHZVL-3SZf5JYRtHTpNAbtCsHQP-fzE2HFqyC7jUuQ?wdOrigin=TEAMS-MAGLEV.p2p_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1767805750354&web=1


        public StateMachine9000CounterdrugASRActiveUnresourcedSteps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine9000CounterdrugASRActiveUnresourced()
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
                VerifyElementIsDisplayed(p3.MovetoActive_Btn, "Move to Active Button");
                VerifyElementIsDisplayed(p3.CancelMission_Btn, "Cancel Mission");
                ClickObj(p3.MovetoActive_Btn, "Move to Active");
                Click(p3.PopUp_Yes_Btn_ByLocator, "Pop Up Yes Button");
                pauseExecution(1000);
                TestContext.Progress.WriteLine("Yes Pop Up Button");
                WaitForMessageToAppearByLocator(p3.RedError_message_ByLocator, "Personnel must be assigned.");
                waitForLoadingBarToCompleteinSeconds();
                Click(p3.RedPopUp_Close_Btn_ByLocator, "Pop Up Yes Button");
                TestContext.Progress.WriteLine("Personnel must be assigned. PopUp Close Button");
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p3.Planning_Tab, "Planning Tab");
                ClickObj(p3.MissionPersonnelSection_Add_Icon, "Mission Personnel section Add Icon");
                commonMethods.AddMissionPersonnel();
                ClickObj(p3.ManageMission_Tab, "Manage Mission Tab");
                ClickObj(p3.MovetoActive_Btn, "Move to Active");
                ClickObj(p3.PopUp_Yes_Btn, "Yes Pop Up Button");
                pauseExecution(1000);
                ValidateElementText(p3.CurrentStatus_value, "Active");
                VerifyElementIsDisplayed(p3.UnresourceMission_Btn, "Unresource Mission");
                VerifyElementIsDisplayed(p3.MovetoCompleted_Btn, "Move to Completed");
                EnterTxt(p3.ProvideRemarksn_input_field, "Unresource Mission", "Entering Unresource Mission Text");
                ClickObj(p3.UnresourceMission_Btn, "Unresource Mission Buttton");
                Click(p3.PopUp_Yes_Btn_ByLocator, "Pop Up Yes Button");
                pauseExecution(1000);
                TestContext.Progress.WriteLine("Yes Pop Up Button");
                WaitForMessageToAppearByLocator(p3.RedError_message_ByLocator, "Personnel can not be assigned to the mission.");
                waitForLoadingBarToCompleteinSeconds();
                Click(p3.RedPopUp_Close_Btn_ByLocator, "Pop Up Yes Button");
                TestContext.Progress.WriteLine("Personnel can not be assigned to the mission. PopUp Close Button");
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p3.Planning_Tab, "Planning Tab");
                ClickObj(p3.PlanningTab_DeleteIcon_ColumnTable, "Delete Icon");
                Click(p3.PopUp_Yes_Btn_ByLocator, "Pop Up Yes Button");
                pauseExecution(1000);
                TestContext.Progress.WriteLine("Successfully Clicked PopUp Yes Button");
                WaitForMessageToAppearByLocator(p2.successful_message_ByLocator, "Deleted Successfully");
                waitForLoadingBarToCompleteinSeconds();
                ValidateElementText(p3.ToAddaiconbutton_Text, "To add a new record click on the + icon/button.");
                ClickObj(p3.ManageMission_Tab, "Manage Mission Tab");
                EnterTxt(p3.ProvideRemarksn_input_field, "Unresource Mission", "Entering Unresource Mission Text");
                ClickObj(p3.UnresourceMission_Btn, "Unresource Mission Button");
                ClickObj(p3.PopUp_Yes_Btn, "Yes Pop Up Button");
                ValidateElementText(p3.MissionInformation_CurrentStatus_Value, "Unresourced");
                ValidateElementText(p3.CurrentStatus_value, "Unresourced");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Unresourced");

            }));
        }







    }

}
