using AventStack.ExtentReports.Model;
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
using UglyToad.PdfPig.Content;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps
{
    public class MCR91305SAFUpdateInsertSafetyHazardAddCaseCodeSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //https://tibercreekgcc-my.sharepoint.com/:w:/g/personal/sherri_washington_tibercreek_com/IQATXApVPEO3Sr10K_MfGq14AYtfJuofFcz5NkIzS1y4crI?wdOrigin=TEAMS-MAGLEV.p2p_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1764187659002&web=1
        public MCR91305SAFUpdateInsertSafetyHazardAddCaseCodeSteps(IWebDriver driver) : base(driver)
        {

        }

        public void MCR91305SAFUpdateInsertSafetyHazardAddCaseCode()
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
                JsClick(landingpage.AddSafetyHazard_Option, "Add Safety Hazard");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "FY 24");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Alaska");
                SelectDateFromCalendarByLocator(p2.Calendar_1, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, "07082024");
                EnterTxt(p2.BuildingNumber_Input, "1", "1");
                EnterTxt(p2.BuildingName_Input, "abc", "abc");
                EnterTxt(p2.RoomNumber_Input, "1", "1");
                EnterTxt(p2.RoomName_Input, "xyz", "xyz");
                EnterTxt(p2.RegionorCity_Input, "north", "north");
                EnterTxt(p2.HazardDescription_Input, "Hazard Description", "Hazard Description");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "Medium");
                EnterTxt(p2.ReferenceRegulation_Input, "Reference Regulation", "Reference Regulation");
                EnterTxt(p2.CorrectiveAction_Input, "Corrective Action", "Corrective Action");
                EnterTxt(p2.WorkOrderNumber_Input, "Work Order Number", "Work Order Number");
                SelectDateFromCalendarByLocator(p2.Calendar_2,p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, "11282025");
                ClickObj(p2.Save_Btn, "Save Button");

                string CapturedCaseCodeText = GetElementText(p3.CaseCode_value, "Case Code").Trim();
                TestContext.Progress.WriteLine("Captured Case Code Text: " + CapturedCaseCodeText);

                // Expected header format
                string FormatedCaseCode = "Safety Hazard: " + CapturedCaseCodeText;
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
