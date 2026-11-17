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
    public class MCR91304SAFUpdateInsertAddCaseCodeSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //https://tibercreekgcc-my.sharepoint.com/:w:/g/personal/sherri_washington_tibercreek_com/IQDyhf42BwnkQZKD9t9P8lWWAd97ZcycYlA021AXttNkNwM?wdOrigin=TEAMS-MAGLEV.undefined_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1764083978182&web=1
        public MCR91304SAFUpdateInsertAddCaseCodeSteps(IWebDriver driver) : base(driver)
        {

        }

        public void MCR91304SAFUpdateInsertAddCaseCode()
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
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                JsClick(landingpage.QuickLinks_DropDown, "Quick Links DropDown");
                pauseExecution(1000);
                JsClick(landingpage.Safety_Option, "Safety Option");
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                JsClick(landingpage.AddSafetyIncident_Option, "Add Safety Incident");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Alaska");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "A - Property damage is $2 million or more.");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "Air Force");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "Government");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "Admin");
                SelectDateFromCalendarByLocator(p2.Calendar_1,p2.monthDropdown_Arrow_ByLocator,p2.YearDropdown_Arrow_ByLocator, "07082024");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_6, p2.DropDown_List, "On-Duty:AT");
                ClickObj(p2.IsMissionRelated_Yes_CheckBox, " Is Mission Related Yes CheckBox");
                ClickObj(p2.IsEquipmentInvolved_Yes_CheckBox, "Is Equipment Involved Yes CheckBox");
                ClickObj(p2.HasInjuries_Yes_CheckBox, "Has Injuries Yes CheckBox");
                ClickObj(p2.AccidentPlanExercised_Yes_CheckBox, "Accident Plan Exercised Yes CheckBox");
                ClickObj(p2.IsCDAviation_Yes_CheckBox, "Is CD Aviation Yes CheckBox");
                ClickObj(p2.Add_Btn, "Add Button");

                string CapturedCaseCodeText = GetElementText(p3.CaseCode_value, "Case Code").Trim();
                TestContext.Progress.WriteLine("Captured Case Code Text: " + CapturedCaseCodeText);

                // Expected header format
                string FormatedCaseCode = "Safety Case: " + CapturedCaseCodeText;
                TestContext.Progress.WriteLine("Formated Case Code text: " + FormatedCaseCode);

                // Header from UI
                string CapturedHeaderText = GetElementText(p3.HeaderText, "Header text").Trim();
                TestContext.Progress.WriteLine("Captured Header Text: " + CapturedHeaderText);

                if (CapturedHeaderText.Equals(FormatedCaseCode, StringComparison.OrdinalIgnoreCase))
                {
                    TestContext.Progress.WriteLine("Header matches expected format. Remaining header is empty.");
                    Reporting.successLog("Header matches expected format. Remaining header is empty.");
                }
                else
                {
                    TestContext.Progress.WriteLine("Header does NOT match expected format.");
                    TestContext.Progress.WriteLine("Expected: " + FormatedCaseCode);
                    TestContext.Progress.WriteLine("Found:    " + CapturedHeaderText);

                    Reporting.failureLog("Header does NOT match expected format.");
                    Assert.Fail("Header does NOT match expected format.");
                }





            }));
        }






    }
}
