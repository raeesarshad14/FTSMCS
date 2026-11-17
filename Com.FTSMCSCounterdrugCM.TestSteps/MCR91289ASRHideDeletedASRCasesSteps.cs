using NUnit.Framework;
using OpenQA.Selenium;
using Org.BouncyCastle.Asn1.Tsp;
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
    public class MCR91289ASRHideDeletedASRCasesSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //https://tibercreekgcc-my.sharepoint.com/:w:/g/personal/sherri_washington_tibercreek_com/IQCVq7cFeSZ5QIF0GxF-INRXATny3Pd2OoIbTlpxX7yxqMc?wdOrigin=TEAMS-MAGLEV.p2p_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1763651419932&web=1
        public MCR91289ASRHideDeletedASRCasesSteps(IWebDriver driver) : base(driver)
        {

        }


        public void MCR91289ASRHideDeletedASRCases()
        {

            Assert.Multiple((Action)(() =>
            {
                LoginPage loginPage = new LoginPage(driver);
                MainLandingPage landingpage = new MainLandingPage(driver);
                CommonMethods commonMethods = new CommonMethods(driver);
                VariableNames variableNames = new VariableNames(driver);
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
                ClickObj(p1.AgencySupportRequestASR_Blade, "Agency Support Request (ASR) blade");
                pauseExecution(1000);
                waitForLoadingBarToCompleteinSeconds();
                SelectFromCustomDropdownByText(p1.SearchesDropDown_Arrow, p1.SearchesDropDown_Options, variableNames.AgencySupportRequests);
                ClickObj(p1.Search_Btn, "Search Button");
                VerifyElementText(p2.LandingPage_DropDown, "Agency Support Request(s)");
                VerifyElementText(p2.SearchResult_PanelTitle, "Agency Support Request Search Results");
                ClickObj(p2.FirstRow, "First Row");
                string CaseCodeCapturedText = GetElementText(p3.CaseCode_value, "Case Code Captured Text");
                TestContext.Progress.WriteLine("Case Code Captured Text: " + CaseCodeCapturedText);
                //JsHighlight(p3.DeveloperTools_DropDown);
                //JsMoveTo(p3.DeveloperTools_DropDown);
                JsClick(p3.DeveloperTools_DropDown, "DeveloperT ools Dropdown");
                pauseExecution(2000);
                //JsHighlight(p3.DeleteCase_Option);
                //JsMoveTo(p3.DeleteCase_Option);
                JsClick(p3.DeleteCase_Option,"Delete Case Option");
                pauseExecution(2000);
                //JsHighlight(p3.DeleteASRCase_Option);
                //JsMoveTo(p3.DeleteASRCase_Option);
                JsClick(p3.DeleteASRCase_Option, "Delete ASR Case Option");
                ClickObj(p3.CDCaseDelete_ShowHideFilters, "CD Case Delete Search Results section Show/Hide Filters");
                EnterTxt(p3.CaseCode_Input, CaseCodeCapturedText, CaseCodeCapturedText);
                VerifyElementText(p3.CaseCode_Value2, CaseCodeCapturedText);
                ClickObj(p3.Delete_Btn, "Delete Button");
                ClickObj(p3.PopUp_Ok_btn, "Pop Up Ok Button");
                string deletedmesage = GetElementText(p3.successful_message, "Case Deleted Message");
                TestContext.Progress.WriteLine("deletedmesage " + deletedmesage);
                VerifyElementText(p3.successful_message, "Success - Case Deleted.");
                VerifyElementText(p3.Nodataavailableintable, "No data available in table");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Going back to panel 1");
                SelectFromCustomDropdownByText(p1.SearchesDropDown_Arrow, p1.SearchesDropDown_Options, variableNames.AgencySupportRequests);
                ClickObj(p1.Search_Btn, "Search Button");
                ClickObj(p2.ShowHide_Filters, "Show/Hide filter");
                EnterTxt(p2.CaseCode_Input, CaseCodeCapturedText, CaseCodeCapturedText);
                VerifyElementText(p2.Nodataavailableintable, "No data available in table");
            }));

        }
      



    }
}
