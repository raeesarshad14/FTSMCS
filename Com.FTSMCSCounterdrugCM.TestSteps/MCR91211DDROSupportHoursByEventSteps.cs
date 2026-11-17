using NUnit.Framework;
using OpenQA.Selenium;
using Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps
{
    public class MCR91211DDROSupportHoursByEventSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //https://tibercreekgcc-my.sharepoint.com/:w:/g/personal/sherri_washington_tibercreek_com/IQDvdKRnET48SpaMxUkMQZKtAcz-89MHwTybhjkNOJDK8bo?wdOrigin=TEAMS-MAGLEV.p2p_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1763478439957&web=1
        public MCR91211DDROSupportHoursByEventSteps(IWebDriver driver) : base(driver)
        {

        }


        public void MCR91211DDROSupportHoursByEvent()
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
                ClickObj(p1.ReportsIcon_Blade, "Reports blade");
                ClickObj(p1.ReportsBlade_DDROPersonnelSupportHoursReport_link, "DDRO Personnel Support Hours Report");
                VerifyElementText(p2.LandingPage_DropDown, "DDRO Personnel Support Hours Report");
                VerifyElementText(p2.ReportingBlade_SearchResult_PanelTitle, "DDRO Event Support Hours Datamart");
                VerifyElementText(p2.SearchResult_LinkName_h5, "DDRO Event Support Hours Datamart");
                VerifyElementText(p2.FiscalYear_Header, "Fiscal Year");
                VerifyElementText(p2.SupportHours_Header, "Support Hours");
                VerifyElementText(p2.TransportHours_Header, "Transport Hours");
                VerifyElementText(p2.DrugTakeBack_Header, "Drug Take Back");
                VerifyElementText(p2.Training_Header, "Training");
                VerifyElementText(p2.CBO_Header, "CBO");
                VerifyElementText(p2.DDROEvent_Header, "DDRO Event");
                pauseExecution(1000);
                ClickObj(p2.FiscalYear_First_Link, "Fiscal Year link");
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.MissionFiscalYear_Header, "Mission Fiscal Year");
                VerifyElementText(p2.MissionState_Header, "Mission State");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.RequestingAgency_Header, "Requesting Agency");
                VerifyElementText(p2.StartDT_Header, "Start DT");
                VerifyElementText(p2.EndDT_Header, "End DT");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.HasFlightHours_Header, "Has Flight Hours?");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.ArmedOps_Header, "Armed Ops?");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");
                VerifyElementText(p2.Interstate_Header, "Interstate?");
                VerifyElementText(p2.OutOfState_Header, "Out Of State?");
                VerifyElementText(p2.EventType_Header, "Event Type");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventDate_Header, "Event Date");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventNotes_Header, "Event Notes");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventLocation_Header, "Event Location");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ZipCode_Header, "Zip Code");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventCourseName_Header, "Event Course Name");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.DrugsByLb_Header, "Drugs By Lb");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.AdultQuantity_Header, "Adult Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ElementaryQuantity_Header, "Elementary Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.HighschoolQuantity_Header, "Highschool Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.MiddleSchoolQuantity_Header, "Middle School Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ParticipantQuantity_Header, "Participant Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.SeniorQuantity_Header, "Senior Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.UnknownQuantity_Header, "Unknown Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.YoungAdultQuantity_Header, "Young Adult Quantity");

                ClickObj(p2.Home_Link, " Home Link");
                ClickObj(p2.SupportHours_First_Link, " First Link of Support Hours Column");
                pauseExecution(3000);
                waitForLoadingBarToCompleteinSeconds();
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.MissionFiscalYear_Header, "Mission Fiscal Year");
                VerifyElementText(p2.MissionState_Header, "Mission State");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.StartDT_Header, "Start DT");
                VerifyElementText(p2.EndDT_Header, "End DT");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");

                ClickObj(p2.Home_Link, " Home Link");
                ClickObj(p2.TransportHours_First_Link, " First Link of Transport Hours Column");
                pauseExecution(3000);
                waitForLoadingBarToCompleteinSeconds();
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.MissionFiscalYear_Header, "Mission Fiscal Year");
                VerifyElementText(p2.MissionState_Header, "Mission State");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.StartDT_Header, "Start DT");
                VerifyElementText(p2.EndDT_Header, "End DT");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");

                ClickObj(p2.Home_Link, " Home Link");
                pauseExecution(3000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p2.DrugTakeBack_First_Link, "First Link of Drug Take Back Column");
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.State_Header, "State");
                VerifyElementText(p2.FiscalYear_Header, "Fiscal Year");
                VerifyElementText(p2.RequestingAgency_Header, "Requesting Agency");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.AgencyLocationTaskForceOrCoalition_Header, "Agency Location, Task Force Or Coalition");
                VerifyElementText(p2.HasFlightHours_Header, "Has Flight Hours?");
                VerifyElementText(p2.ArmedOps_Header, "Armed Ops?");
                VerifyElementText(p2.Interstate_Header, "Interstate?");
                VerifyElementText(p2.OutOfState_Header, "Out Of State?");
                VerifyElementText(p2.EventType_Header, "Event Type");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventDate_Header, "Event Date");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventNotes_Header, "Event Notes");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventLocation_Header, "Event Location");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ZipCode_Header, "Zip Code");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventCourseName_Header, "Event Course Name");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.DrugsByLb_Header, "Drugs By Lb");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.AdultQuantity_Header, "Adult Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ElementaryQuantity_Header, "Elementary Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.HighschoolQuantity_Header, "Highschool Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.MiddleSchoolQuantity_Header, "Middle School Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ParticipantQuantity_Header, "Participant Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.SeniorQuantity_Header, "Senior Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.UnknownQuantity_Header, "Unknown Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.YoungAdultQuantity_Header, "Young Adult Quantity");

                ClickObj(p2.Home_Link, " Home Link");
                pauseExecution(3000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p2.Training_First_Link, "First Link of Training Column");
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.State_Header, "State");
                VerifyElementText(p2.FiscalYear_Header, "Fiscal Year");
                VerifyElementText(p2.RequestingAgency_Header, "Requesting Agency");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.AgencyLocationTaskForceOrCoalition_Header, "Agency Location, Task Force Or Coalition");
                VerifyElementText(p2.HasFlightHours_Header, "Has Flight Hours?");
                VerifyElementText(p2.ArmedOps_Header, "Armed Ops?");
                VerifyElementText(p2.Interstate_Header, "Interstate?");
                VerifyElementText(p2.OutOfState_Header, "Out Of State?");
                VerifyElementText(p2.EventType_Header, "Event Type");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventDate_Header, "Event Date");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventNotes_Header, "Event Notes");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventLocation_Header, "Event Location");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ZipCode_Header, "Zip Code");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventCourseName_Header, "Event Course Name");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.DrugsByLb_Header, "Drugs By Lb");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.AdultQuantity_Header, "Adult Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ElementaryQuantity_Header, "Elementary Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.HighschoolQuantity_Header, "Highschool Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.MiddleSchoolQuantity_Header, "Middle School Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ParticipantQuantity_Header, "Participant Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.SeniorQuantity_Header, "Senior Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.UnknownQuantity_Header, "Unknown Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.YoungAdultQuantity_Header, "Young Adult Quantity");

                ClickObj(p2.Home_Link, " Home Link");
                pauseExecution(3000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p2.CBO_First_Link, "First Link of CBO Column");
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.State_Header, "State");
                VerifyElementText(p2.FiscalYear_Header, "Fiscal Year");
                VerifyElementText(p2.RequestingAgency_Header, "Requesting Agency");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.AgencyLocationTaskForceOrCoalition_Header, "Agency Location, Task Force Or Coalition");
                VerifyElementText(p2.HasFlightHours_Header, "Has Flight Hours?");
                VerifyElementText(p2.ArmedOps_Header, "Armed Ops?");
                VerifyElementText(p2.Interstate_Header, "Interstate?");
                VerifyElementText(p2.OutOfState_Header, "Out Of State?");
                VerifyElementText(p2.EventType_Header, "Event Type");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventDate_Header, "Event Date");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventNotes_Header, "Event Notes");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventLocation_Header, "Event Location");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ZipCode_Header, "Zip Code");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventCourseName_Header, "Event Course Name");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.DrugsByLb_Header, "Drugs By Lb");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.AdultQuantity_Header, "Adult Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ElementaryQuantity_Header, "Elementary Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.HighschoolQuantity_Header, "Highschool Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.MiddleSchoolQuantity_Header, "Middle School Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ParticipantQuantity_Header, "Participant Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.SeniorQuantity_Header, "Senior Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.UnknownQuantity_Header, "Unknown Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.YoungAdultQuantity_Header, "Young Adult Quantity");

                ClickObj(p2.Home_Link, " Home Link");
                pauseExecution(3000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(p2.DDROEvent_First_Link, "First Link of DDRO Event Column");
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.State_Header, "State");
                VerifyElementText(p2.FiscalYear_Header, "Fiscal Year");
                VerifyElementText(p2.RequestingAgency_Header, "Requesting Agency");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.AgencyLocationTaskForceOrCoalition_Header, "Agency Location, Task Force Or Coalition");
                VerifyElementText(p2.HasFlightHours_Header, "Has Flight Hours?");
                VerifyElementText(p2.ArmedOps_Header, "Armed Ops?");
                VerifyElementText(p2.Interstate_Header, "Interstate?");
                VerifyElementText(p2.OutOfState_Header, "Out Of State?");
                VerifyElementText(p2.EventType_Header, "Event Type");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventDate_Header, "Event Date");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventNotes_Header, "Event Notes");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventLocation_Header, "Event Location");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ZipCode_Header, "Zip Code");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.EventCourseName_Header, "Event Course Name");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.DrugsByLb_Header, "Drugs By Lb");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.AdultQuantity_Header, "Adult Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ElementaryQuantity_Header, "Elementary Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.HighschoolQuantity_Header, "Highschool Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.MiddleSchoolQuantity_Header, "Middle School Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.ParticipantQuantity_Header, "Participant Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.SeniorQuantity_Header, "Senior Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.UnknownQuantity_Header, "Unknown Quantity");
                moveToElement(p2.YoungAdultQuantity_Header);
                VerifyElementText(p2.YoungAdultQuantity_Header, "Young Adult Quantity");


            }));



        }

        public void ClickAllLinkOnEachRowAndValidateColumnHeadersDisplayed()
        {

            Panel2Page p2 = new Panel2Page(driver);

            string xpath = "//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tbody/tr[(contains(@class,'odd') or contains(@class,'even'))]/td//a";

            // Collect all elements first
            var allLinks = driver.FindElements(By.XPath(xpath));

            for (int i = 0; i < allLinks.Count; i++)
            {
                // Re-locate elements each loop (prevents stale element exception)
                allLinks = driver.FindElements(By.XPath(xpath));

                IWebElement link = allLinks[i];

                // Scroll to element (optional)
                moveToElement(link);

                // Click the link
                ClickObj(link, link.Text);
                ShowPopup("Sherri is rewritting this test. I need to update this accordingly");
                VerifyElementText(p2.MissionCaseCode_Header, "Mission Case Code");
                VerifyElementText(p2.MissionFiscalYear_Header, "Mission Fiscal Year");
                VerifyElementText(p2.MissionState_Header, "Mission State");
                VerifyElementText(p2.MissionDrugThreat_Header, "Mission Drug Threat");
                VerifyElementText(p2.StartDT_Header, "Start DT");
                VerifyElementText(p2.EndDT_Header, "End DT");
                VerifyElementText(p2.FullName_Header, "Full Name");
                VerifyElementText(p2.SupportHours_Header, "# Support Hours");
                VerifyElementText(p2.TransportHours_Header, "# Transport Hours");
                ClickObj(p2.Home_Link, " Home Link");
                pauseExecution(3000);
                waitForLoadingBarToCompleteinSeconds();


            }
        }

    }
}
