using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects
{
    public class Panel1Page : SetUp
    {
        public IWebDriver ldriver;

        public Panel1Page(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        public string FiscalYear { get; set; }

        // --- DYNAMIC ELEMENTS (The New Selenium 4 Way) ---

        public IWebElement CommandCenter_Header => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//h2[@aria-label='Command Center, Command Center']"));

        public IWebElement PersonnelManagementTool_PMT_Tab => ldriver.FindElement(By.XPath("//div[@aria-label='Personnel Management Tool (PMT). ']"));

        public IWebElement Logistics_Tab => ldriver.FindElement(By.XPath("//div[@aria-label='Logistics (LOG). ']"));

        public IWebElement StatePlan_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='State Plan (SP) Icon']"));

        public IWebElement FinancialManagementTool_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='Financial Management Tool (FMT) Icon']"));

        public IWebElement ClassSchedulingUtility_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='Class Scheduling Utility (CSU) Icon']"));

        public IWebElement StateCSUTrainingCenter_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='State CSU Training Center Icon']"));

        public IWebElement MyCSUTrainingCenter_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='My CSU Training Center Icon']"));

        public IWebElement ClassOpenforRegistration_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title, 'CSU Classes - Class Open for Registration')]"));

        public IWebElement ManageClass_Link => ldriver.FindElement(By.XPath("(//a[contains(@data-title, 'Manage Class ')])[2]"));

        public IWebElement StateCSUManageClass_Link => ldriver.FindElement(By.XPath("(//a[contains(@data-title, 'State CSU Manage Class')])[2]"));

        public IWebElement ComplianceAssuranceProgram_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='Compliance Assurance Program (CAP) Icon']"));

        public IWebElement OpentoStates_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title,'State Plan - Open to States')]"));

        public IWebElement StateCAPAdmin_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title,'Questionnaire(s) - State CAP Admin')]"));

        public IWebElement CDCReview_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title,'Questionnaire(s) - CDC Review')]"));

        public IWebElement NGBPMVerification_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title,'Questionnaire(s) - NGB PM Verification')]"));

        public IWebElement FYTargetsOpen_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title,'FY Targets Open ')]"));

        public IWebElement Assessment_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title,'State Plan - Assessment')]"));

        public IWebElement InProgress_Link => ldriver.FindElement(By.XPath("//a[contains(@data-title,'State Plan Assessment - In Progress')]"));

        public IWebElement QCInitiated_Link => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//a[contains(@data-title,'QC Initiated') or contains(normalize-space(.),'QC Initiated')]"));

        public IWebElement ReportsIcon_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='Reports Icon']"));

        public IWebElement POCManagement_Blade => ldriver.FindElement(By.XPath("//div[@aria-label='POC Management (POC). ']"));

        public IWebElement AgencySupportRequestASR_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='Agency Support Request (ASR) Icon']"));

        public IWebElement NGCounterdrugSchoolsNGCSIcon_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='NG Counterdrug Schools (NGCS) Icon']"));

        public IWebElement FundingRevisions_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='Funding Revisions (FR) Icon']"));

        public IWebElement ReimbursementsREIMIcon_Blade => ldriver.FindElement(By.XPath("//i[@aria-label='Reimbursements (REIM) Icon']"));

        public IWebElement ReportsBlade_DDROPersonnelSupportHoursReport_link => ldriver.FindElement(By.XPath("//div[@class='panel-collapse collapse in']//*[contains(text(), 'DDRO Personnel Support Hours Report')]"));

        public IWebElement AerialReconnaissance_2026_link =>
            ldriver.FindElement(By.XPath(
                $"//li[span[contains(@data-groupbyfilter, \"'{FiscalYear}'\")]]" +
                $"//li[span[starts-with(normalize-space(.), 'Aerial Reconnaissance')]]/span"));

        public IWebElement ASRAdministration_Refresh_Button => ldriver.FindElement(By.XPath("//div[@class='panel-collapse collapse in']//button[@aria-label='Refresh']"));

        public IWebElement Refresh_Button => ldriver.FindElement(By.XPath("//div[@class='panel-collapse collapse in']//button[@aria-label='Refresh']"));

        public IWebElement AerialReconnaissance_2026_ASRMission_link => ldriver.FindElement(By.XPath(
                $"//li[span[contains(@data-groupbyfilter, \"'{FiscalYear}'\")]]" +
                $"//li[span[starts-with(normalize-space(.), 'Aerial Reconnaissance')]]" +
                $"//li[span[starts-with(normalize-space(.), 'ASR Mission')]]/span"));

        public IWebElement AerialReconnaissance_2026_Inactive_link =>ldriver.FindElement(By.XPath(
         $"//li[span[contains(@data-groupbyfilter, \"'{FiscalYear}'\")]]" +
         $"//li[span[starts-with(normalize-space(.), 'Aerial Reconnaissance')]]" +
         $"//li[span[starts-with(normalize-space(.), 'ASR Mission')]]" +
         $"//a[contains(@data-title, 'Inactive')]"));

        public IWebElement Reimbursements_REIM_Tab => ldriver.FindElement(By.XPath("//div[@aria-label='Reimbursements (REIM). ']"));

        public IWebElement Reimbursements_REIM_Management_Tab => ldriver.FindElement(By.XPath("//div[@aria-label='Reimbursements (REIM) Management']"));

        public IWebElement OctFolder => ldriver.FindElement(By.XPath("//i[@aria-label='Oct Folder ']"));

        public IWebElement OctFolder_Projected_Link => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//a[contains(@data-title, 'Oct - Projected')]"));

        public IWebElement ActivePersonnel_Link => ldriver.FindElement(By.XPath("//li[contains(@class,'parent_li')]//a[contains(text(),'Active Personnel') and not(contains(text(),'In-Active Personnel'))]"));

        public IWebElement AwaitingAcceptanceByCDC_Link => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//a[contains(@data-title, 'Awaiting Acceptance By CDC ')]"));

        public IWebElement Active_Link => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//a[contains(@data-title, 'Active ')]"));

        public IWebElement ActivePointofContact_Link => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//a[contains(@data-title, 'Active Point of Contact ')]"));

        public IWebElement ApplicantsPendingHire_Link => ldriver.FindElement(By.XPath("//li[contains(@class,'parent_li')]//a[contains(text(),'Applicants Pending Hire ')]"));

        public IWebElement BOSInDraft_Link => ldriver.FindElement(By.XPath("//li[contains(@class,'parent_li')]//a[contains(text(),'BOS In Draft ')]"));

        public IWebElement FYTargetsInRevision_Link => ldriver.FindElement(By.XPath("//li[contains(@class,'parent_li')]//a[contains(text(),'FY Targets In Revision ')]"));

        public IWebElement CommandCenter_Blade_Rotated => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//header[@class='rotated']"));

        public IWebElement Search_Button => ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//button[@aria-label='Search']"));

        public IWebElement SearchesDropDown_Arrow => ldriver.FindElement(By.XPath("(//div[@class='search-section']//b[@role='presentation'])[1]"));

        public IWebElement DropDown1_Arrow => ldriver.FindElement(By.XPath("(//div[@class='panel-collapse collapse in']//div[@class='search-section']//b[@role='presentation'])[1]"));

        public IWebElement Search_Btn => ldriver.FindElement(By.XPath("//div[@class='panel-collapse collapse in']//button[@aria-label='Search']"));

        public IWebElement DropdownArrow => ldriver.FindElement(By.XPath("//span[@class='select2-selection__arrow']"));

        public IWebElement CourseName_Input => ldriver.FindElement(By.XPath("//label[contains(text(), 'Course Name')]/following-sibling::div/input"));

        // --- LOCATOR STRATEGIES ---
        public By SearchesDropDown_Options = By.XPath("//ul[@class='select2-results__options']//li");

        public By ASRAdministration_Refresh_Button_ByLoacator = By.XPath("//div[@class='panel-collapse collapse in']//button[@aria-label='Refresh']");

        public By Refresh_ByLoacator = By.XPath("//div[@class='panel-collapse collapse in']//button[@aria-label='Refresh']");

        public By Active_Link_locator => (By.XPath("//div[@id='commandCenterTools-widget']//a[contains(@data-title, 'Active ')]"));

        public By SearchesDropDown_Locator => (By.XPath("(//div[@class='search-section']//b[@role='presentation'])[1]"));
    }
}