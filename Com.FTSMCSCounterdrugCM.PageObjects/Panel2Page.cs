using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Script;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects
{
    public class Panel2Page : SetUp
    {
        public IWebDriver ldriver;

        public Panel2Page(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        // --- DYNAMIC ELEMENTS (The New Selenium 4 Way) ---

        public IWebElement LandingPage_DropDown => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-menu']/span[1]"));

        public IWebElement SearchResult_PanelTitle => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div//span[@class='panel-title']"));

        public IWebElement ReportingBlade_SearchResult_PanelTitle => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='col-sm-12']//h4"));

        public IWebElement SearchResult_LinkName => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='search-section panel-group entity-section']//span[@class='panel-title']"));

        public IWebElement SearchResult_LinkName_h5 => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//h5"));

        public IWebElement FirstRow => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='odd']//td"));

        public IWebElement FirstRow2 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='odd']//td)[3]"));

        public IWebElement ShowHide_Filters => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//ul[@class='extra-buttons fa-lg list-inline pull-right navbar-right']//li[@title='Show/Hide Filters']"));

        public IWebElement ShowHide_Expanded => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//th[@style='width: 233.438px;']"));

        public IWebElement Amount_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Amount']//input[@class='column-search-filter']"));

        public IWebElement FullName_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Full Name']//input[@class='column-search-filter']"));

        public IWebElement DaysInCurrentStatus_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Days In Current Status']//input[@class='column-search-filter']"));

        public IWebElement Region_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Region']//input[@class='column-search-filter']"));

        public IWebElement Program_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Program']//input[@class='column-search-filter']"));

        public IWebElement ServiceMember_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Service Member']//input[@class='column-search-filter']"));

        public IWebElement Branch_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Branch']//input[@class='column-search-filter']"));

        public IWebElement Position_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Position']//input[@class='column-search-filter']"));

        public IWebElement Status_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Status']//input[@class='column-search-filter']"));

        public IWebElement POCStartDT_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='POC Start DT']//input"));

        public IWebElement LatestActionDate_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Latest Action Date']//input"));

        public IWebElement Comments_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Comments']//input[@class='column-search-filter']"));

        public IWebElement ReimbursementComments_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Reimbursement Comments']//input[@class='column-search-filter']"));

        public IWebElement State_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='State']//input[@class='column-search-filter']"));

        public IWebElement PropertyBookType_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Property Book Type']//input[@class='column-search-filter']"));

        public IWebElement FiscalYear_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Fiscal Year']//input[@class='column-search-filter']"));

        public IWebElement DrugThreat_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Drug Threat']//input[@class='column-search-filter']"));

        public IWebElement State_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='State']"));

        public IWebElement AffilState_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Affil State']"));

        public IWebElement Region_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Region']"));

        public IWebElement POCStartDT_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='POC Start DT']"));

        public IWebElement POCState_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='POC State']"));

        public IWebElement Program_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Program']"));

        public IWebElement Position_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Position']"));

        public IWebElement ServiceMember_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Service Member']"));

        public IWebElement LatestActionDate_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Latest Action Date']"));

        public IWebElement CaseCode_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Case Code']"));

        public IWebElement Type_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Type']"));

        public IWebElement ReimbursementType_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Reimbursement Type']"));

        public IWebElement FullName_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Full Name']"));

        public IWebElement Last4_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Last 4']"));

        public IWebElement COLBranch_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='COL Branch']"));

        public IWebElement Branch_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Branch']"));
        public IWebElement Amount_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Amount']"));

        public IWebElement Reimbursement_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Reimbursement Amount']"));

        public IWebElement DaysInCurrentStatus_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Days In Current Status']"));

        public IWebElement Status_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Status']"));

        public IWebElement EvaluationType_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Evaluation Type']"));

        public IWebElement ReimbursementComments_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Reimbursement Comments']"));

        public IWebElement ReimbursementAmountt_Value => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Reimbursement Amount']"));

        public IWebElement FiscalYear_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Fiscal Year the event took place in.']"));

        public IWebElement SupportHours_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Event Personnel Support Hours for the Fact Mission DDRO Event record.']"));

        public IWebElement TransportHours_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Transportation Hours for the Fact Mission DDRO Event record.']"));

        public IWebElement DrugTakeBack_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Drug Takebacks for the DDRO Event.']"));

        public IWebElement Training_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of DDRO Training Events for the Fact Mission DDRO Event record.']"));

        public IWebElement CBO_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of CBOs for the DDRO Event.']"));

        public IWebElement DDROEvent_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of DDRO Events related to the Fact Mission.']"));

        public IWebElement MissionCaseCode_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='Case Code for the mission']"));

        public IWebElement State_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The state in which the mission is assigned.']"));

        public IWebElement MissionFiscalYear_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Fiscal Year the event took place in.']"));

        public IWebElement MissionState_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The state in which the mission is assigned.']"));

        public IWebElement MissionDrugThreat_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The unique identifier of the Drug Threat.']"));

        public IWebElement AgencyLocationTaskForceOrCoalition_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The unique identifier of the Agency Location.']"));

        public IWebElement RequestingAgency_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The requesting agency for the Agency Support Request']"));

        public IWebElement StartDT_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The start date of the record.']"));

        public IWebElement EndDT_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The end date of the record.']"));

        public IWebElement FullName_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Full Name of the Personnel associated to the Fact Mission DDRO Event record.']"));

        public IWebElement HasFlightHours_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='A flag indicating a mission has flight hours.']"));

        public IWebElement ArmedOps_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='A flag indicating that this is an armed operation.']"));

        public IWebElement Interstate_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='A flag indicating that this is an interstate mission.']"));

        public IWebElement OutOfState_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='A flag indicating that this is an out of state mission.']"));

        public IWebElement EventType_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Code that represents the DDRO Event Type for the Fact Mission DDRO Event record.']"));

        public IWebElement EventDate_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Date of the DDRO Event for the Fact Mission DDRO Event record.']"));

        public IWebElement EventNotes_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Event Notes for the DDRO Event.']"));

        public IWebElement EventLocation_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Location (address, city, state, or other location information) related to the DDRO event.']"));

        public IWebElement ZipCode_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The Zip Code in which the DDRO Event took place.']"));

        public IWebElement EventCourseName_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The DDRO Event Course Name.']"));

        public IWebElement DrugsByLb_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The amount of Drugs by Pound that were seized for the DDRO Event.']"));

        public IWebElement AdultQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Adults who attended the DDRO Event.']"));

        public IWebElement ElementaryQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Elementary Schoolers who attended the DDRO Event.']"));

        public IWebElement HighschoolQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of High School students who attended the DDRO Event.']"));

        public IWebElement MiddleSchoolQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Middle Schoolers who attended the DDRO Event.']"));

        public IWebElement ParticipantQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The total number of Event Participants who attended the DDRO event.']"));

        public IWebElement SeniorQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Seniors who attended the DDRO Event.']"));

        public IWebElement UnknownQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Unknown participants who attended the DDRO Event.']"));

        public IWebElement YoungAdultQuantity_Header => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@data-title='The number of Young Adults who attended the DDRO Event.']"));

        public IWebElement Home_Link => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//ol[@class='breadcrumb']//a[contains(text(), 'Home')]"));

        public IWebElement CaseCode_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Case Code']//input"));

        public IWebElement StatePlanCaseCode_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='State Plan Case Code']//input"));

        public IWebElement Nodataavailableintable => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr/td"));

        public IWebElement FiscalYear_First_Link => ldriver.FindElement(By.XPath("//th[contains(.,'Fiscal Year')]/ancestor::table//tr[td[1][normalize-space()='2026']]/td[count(//th[contains(.,'Fiscal Year')]/preceding-sibling::th)+1]//a"));

        public IWebElement SupportHours_First_Link => ldriver.FindElement(By.XPath("//th[contains(.,'# Support Hours')]/ancestor::table//tr[td[1][normalize-space()='2026']]/td[count(//th[contains(.,'# Support Hours')]/preceding-sibling::th)+1]//a"));

        public IWebElement TransportHours_First_Link => ldriver.FindElement(By.XPath("//th[contains(.,'# Transport Hours')]/ancestor::table//tr[td[1][normalize-space()='2026']]/td[count(//th[contains(.,'# Transport Hours')]/preceding-sibling::th)+1]//a"));

        public IWebElement DrugTakeBack_First_Link => ldriver.FindElement(By.XPath("//th[contains(.,'Drug Take Back')]/ancestor::table//tr[td[1][normalize-space()='2026']]/td[count(//th[contains(.,'Drug Take Back')]/preceding-sibling::th)+1]//a"));

        public IWebElement Training_First_Link => ldriver.FindElement(By.XPath("//th[contains(.,'Training')]/ancestor::table//tr[td[1][normalize-space()='2026']]/td[count(//th[contains(.,'Training')]/preceding-sibling::th)+1]//a"));

        public IWebElement CBO_First_Link => ldriver.FindElement(By.XPath("//th[contains(.,'CBO')]/ancestor::table//tr[td[1][normalize-space()='2026']]/td[count(//th[contains(.,'CBO')]/preceding-sibling::th)+1]//a"));

        public IWebElement DDROEvent_First_Link => ldriver.FindElement(By.XPath("//th[contains(.,'DDRO Event')]/ancestor::table//tr[td[1][normalize-space()='2026']]/td[count(//th[contains(.,'DDRO Event')]/preceding-sibling::th)+1]//a"));

        public IWebElement Dropdown_Arrow_1 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[1]"));

        public IWebElement Dropdown_Arrow_2 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[2]"));

        public IWebElement Dropdown_Arrow_3 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[3]"));

        public IWebElement Dropdown_Arrow_4 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[4]"));

        public IWebElement Dropdown_Arrow_5 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[5]"));

        public IWebElement Dropdown_Arrow_6 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[6]"));

        public IWebElement Dropdown_Arrow_7 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[7]"));

        public IWebElement StartDate_Input => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='input-group section-data-item-value']//input)[1]"));

        public IWebElement EndDate_Input => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='input-group section-data-item-value']//input)[2]"));

        public IWebElement Calendar_1 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])"));

        public IWebElement Calendar_2 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[2]"));

        public IWebElement Calendar_5 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[5]"));

        public IWebElement Calendar_6 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[6]"));

        public IWebElement monthDropdown_Arrow => ldriver.FindElement(By.XPath("//select[@data-handler='selectMonth']"));

        public IWebElement YearDropdown_Arrow => ldriver.FindElement(By.XPath("//select[@data-handler='selectYear']"));

        public IWebElement IsMissionRelated_Yes_CheckBox => ldriver.FindElement(By.XPath("//label[contains(., 'Is Mission Related')]/following::label[contains(., 'Yes')][1]"));

        public IWebElement IsNGBSponsored_No_CheckBox => ldriver.FindElement(By.XPath("//label[contains(., 'Is NGB Sponsored?')]/following::label[contains(., 'No')][1]"));

        public IWebElement IsStateDoctrinalTraining_No_CheckBox => ldriver.FindElement(By.XPath("//label[contains(., 'Is State Doctrinal Training?')]/following::label[contains(., 'No')][2]"));

        public IWebElement IsEquipmentInvolved_Yes_CheckBox => ldriver.FindElement(By.XPath("//label[contains(., 'Is Equipment Involved?')]/following::label[contains(., 'Yes')][1]"));

        public IWebElement HasInjuries_Yes_CheckBox => ldriver.FindElement(By.XPath("//label[contains(., 'Has Injuries?')]/following::label[contains(., 'Yes')][1]"));

        public IWebElement AccidentPlanExercised_Yes_CheckBox => ldriver.FindElement(By.XPath("//label[contains(., 'Accident Plan Exercised?')]/following::label[contains(., 'Yes')][1]"));

        public IWebElement IsCDAviation_Yes_CheckBox => ldriver.FindElement(By.XPath("//label[contains(., 'Is CD Aviation?')]/following::label[contains(., 'Yes')][1]"));

        public IWebElement Add_Btn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Add']"));

        public IWebElement CreateClass_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//ul[@role='tablist']//a[@aria-label='Create Class. ']"));

        public IWebElement CreateNewClass_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@data-original-title='Create New Class']"));

        public IWebElement SeriesName_Input => ldriver.FindElement(By.XPath("//form[@class='caseseriesForm']//input[@id='caseSeriesName']"));

        public IWebElement PopUp_Ok_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@aria-label='OK']"));

        public IWebElement PopUp_Save_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@aria-label='Save']"));

        public IWebElement BuildingNumber_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Building Number']/following::input[1]"));

        public IWebElement BuildingName_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Building Name']/following::input[1]"));

        public IWebElement RoomNumber_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Room Number']/following::input[1]"));

        public IWebElement RoomName_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Room Name']/following::input[1]"));

        public IWebElement RegionorCity_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Region or City']/following::input[1]"));

        public IWebElement HazardDescription_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Hazard Description']//following::textarea[1]"));

        public IWebElement ReferenceRegulation_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Reference Regulation']//following::textarea[1]"));

        public IWebElement CorrectiveAction_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Corrective Action']//following::textarea[1]"));

        public IWebElement WorkOrderNumber_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Work Order Number']//following::input[1]"));

        public IWebElement Save_Btn => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Save'])[1]"));

        public IWebElement RedPopUp_Close_Btn => ldriver.FindElement(By.XPath("//div[@class='toast toast-error']//button[@class='toast-close-button']"));

        public IWebElement successful_message => ldriver.FindElement(By.XPath("//div[@class='toast-message']"));

        public IWebElement Activity_DropDown_Value => ldriver.FindElement(By.XPath("//label[contains(., 'Activity')]/following::span[@class='select2-selection__rendered'][1]"));

        public IWebElement AgencyCode_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Agency Code'] //following-sibling::div[@class='input-group section-data-item-value']//input"));

        public IWebElement Name_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Name'] //following-sibling::div[@class='input-group section-data-item-value']//input"));

        public IWebElement CourseName_Input => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Course Name']//input[@class='column-search-filter']"));

        public IWebElement RequestingAgency_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Requesting Agency'] //following-sibling::div[@class='input-group section-data-item-value']//input"));
        // --- CONTINUATION OF DYNAMIC ELEMENTS ---

        public IWebElement Description_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Description']//following-sibling::div[@class='input-group section-data-item-value']//textarea"));

        public IWebElement Description_Input_2 => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Description']//input[@class='column-search-filter']"));

        public IWebElement Lessons_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Lessons'] //following-sibling::div[@class='input-group section-data-item-value']//input"));

        public IWebElement Hours_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Hours'] //following-sibling::div[@class='input-group section-data-item-value']//input"));

        public IWebElement OfficePhone_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Office Phone'] //following-sibling::div[@class='input-group section-data-item-value']//input"));

        public IWebElement Email_Input => ldriver.FindElement(By.XPath("//*[normalize-space()='Email'] //following-sibling::div[@class='input-group section-data-item-value']//input"));

        public IWebElement POC_Refresh_Button => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//i[@aria-label='Point of Contact Search section Refresh']"));

        public IWebElement ExchangingFunds_No_Button => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[@aria-label='No'])[1]"));

        public IWebElement CurrentYearTargetAmount_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Current Year Target Amount']/following::input[1]"));

        public IWebElement CurrentYearTargetAmount_Input_Field2 => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Current Year Target']/following::input[1]"));

        public IWebElement Justification_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Justification']/following::textarea[1]"));

        public IWebElement PriorYearTarget_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Prior Year Target']/following::input[1]"));

        public IWebElement MissionImpact_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Mission Impact']/following::textarea[1]"));

        public IWebElement ANGOMReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='ANG O&M Returned']/following::input[1]"));

        public IWebElement OctoberDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='October Dollars Requested']/following::input[1]"));

        public IWebElement OctoberDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='October Dollars Returned']/following::input[1]"));

        public IWebElement NovemberDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='November Dollars Requested']/following::input[1]"));

        public IWebElement NovemberDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='November Dollars Returned']/following::input[1]"));

        public IWebElement DecemberDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='December Dollars Requested']/following::input[1]"));

        public IWebElement DecemberDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='December Dollars Returned']/following::input[1]"));

        public IWebElement JanuaryDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='January Dollars Requested']/following::input[1]"));

        public IWebElement JanuaryDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='January Dollars Returned']/following::input[1]"));

        public IWebElement FebruaryDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='February Dollars Requested']/following::input[1]"));

        public IWebElement FebruaryDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='February Dollars Returned']/following::input[1]"));

        public IWebElement MarchDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='March Dollars Requested']/following::input[1]"));

        public IWebElement MarchDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='March Dollars Returned']/following::input[1]"));

        public IWebElement AprilDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='April Dollars Requested']/following::input[1]"));

        public IWebElement AprilDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='April Dollars Returned']/following::input[1]"));

        public IWebElement MayDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='May Dollars Requested']/following::input[1]"));

        public IWebElement MayDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='May Dollars Returned']/following::input[1]"));

        public IWebElement JuneDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='June Dollars Requested']/following::input[1]"));

        public IWebElement JuneDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='June Dollars Returned']/following::input[1]"));

        public IWebElement JulyDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='July Dollars Requested']/following::input[1]"));

        public IWebElement JulyDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='July Dollars Returned']/following::input[1]"));

        public IWebElement AugustDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='August Dollars Requested']/following::input[1]"));

        public IWebElement AugustDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='August Dollars Returned']/following::input[1]"));

        public IWebElement ANGOMRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='ANG O&M Requested']/following::input[1]"));

        public IWebElement SeptemberDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='September Dollars Requested']/following::input[1]"));

        public IWebElement SeptemberDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='September Dollars Returned']/following::input[1]"));

        public IWebElement TotalDollarsRequested_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Total Dollars Requested']/following::input[1]"));

        public IWebElement TotalDollarsReturned_Input_Field => ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space()='Total Dollars Returned']/following::input[1]"));

        public IWebElement State_value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='State'] //following-sibling::div[@class='el-data']"));

        public IWebElement FiscalYear_value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Fiscal Year'] //following-sibling::div[@class='el-data']"));

       







        // --- WEB ELEMENT LISTS (Using FindElements) ---

        public IList<IWebElement> DropDown_WebElementList => ldriver.FindElements(By.XPath("//ul[@class='select2-results__options']//li"));

        public IList<IWebElement> FY_WebElementList => ldriver.FindElements(By.XPath("//div[@class='wb-results panel-body']//table//td[1]"));

        // --- NATIVE BY LOCATORS ---

        public By DropDown_List = By.XPath("//ul[@class='select2-results__options']//li");

        public By FY_List = By.XPath("//div[@class='wb-results panel-body']//table//td[1]");

        public By monthDropdown_Arrow_ByLocator = By.XPath("//select[@data-handler='selectMonth']");

        public By YearDropdown_Arrow_ByLocator = By.XPath("//select[@data-handler='selectYear']");

        public By successful_message_ByLocator = By.XPath("//div[@class='toast-message']");

        public By Add_Btn_ByLocator = By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Add']");

        public By Description_Input_Locator => By.XPath("//*[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Description']//input[@class='column-search-filter']");

        public By ShowHide_Expanded_Locator => By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//th[@style='width: 233.438px;']");









    }
}





























