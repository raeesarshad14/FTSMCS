using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects
{
    public class Panel4Page : SetUp
    {


        public IWebDriver ldriver;

        public Panel4Page(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        public IWebElement ValidateProjections_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(text())='Reimbursement Documents']/ancestor::div[contains(@class,'panel') or contains(@class,'vsd')]//button[contains(.,'Validate Projections')]"));

        public IWebElement Cancel_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(text())='Reimbursement Documents']/ancestor::div[contains(@class,'panel') or contains(@class,'vsd')]//button[contains(.,'Cancel')]"));

        public IWebElement Column_Name_value => ldriver.FindElement(By.XPath("//*[normalize-space(text())='Reimbursement Documents']/ancestor::div[contains(@class,'panel') or contains(@class,'vsd')]/descendant::td[@colname='Name']"));

        public IWebElement Column_DocumentType_value => ldriver.FindElement(By.XPath("//*[normalize-space(text())='Reimbursement Documents']/ancestor::div[contains(@class,'panel') or contains(@class,'vsd')]/descendant::td[@data-header='Document Type']"));

        public IWebElement UploadNewFile_Btn => ldriver.FindElement(By.XPath("//*[normalize-space(text())='Reimbursement Documents']/ancestor::div[contains(@class,'panel') or contains(@class,'vsd')]//button[contains(.,'Upload New File')]"));

        public IWebElement CurrentStatus_value => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='form-group']//p//span)[1]"));

        public IWebElement Description_value => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='form-group']//p//span)[2]"));

        public IWebElement ManageClassLessons_Modify_Icon => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//i[@aria-label='Edit Icon']"));

        public IWebElement ManageClassFacility_Facility_Icon => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Facility']//i[@aria-label='Manage Class Facility section Edit']"));

        public IWebElement ProvideRemarksn_input_field => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorTwo']//div[@class='tab-pane fade nav-panel-parent active in']//textarea[contains(@placeholder, 'Provide Remarks')]"));

        public IWebElement CheckMarkSign_withRequiredText => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd']//small"));

        public IWebElement RequestReimbursementfromState_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Request Reimbursement from State']"));

        public IWebElement Delete_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Delete']"));

        public IWebElement Close_Button => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorTwo']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Close']"));

        public IWebElement PopUp_Yes_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@class='actionconfirmation-ok-button btn btn-primary btn-round']"));

        public IWebElement PopUp_Yes2_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@aria-label='Yes']"));

        public IWebElement PopUp_Ok_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@aria-label='Ok']"));

        public IWebElement Calendar_1 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])"));

        public IWebElement Calendar_2 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[2]"));

        public IWebElement Calendar_5 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[5]"));

        public IWebElement Calendar_6 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[6]"));

        public IWebElement monthDropdown_Arrow => ldriver.FindElement(By.XPath("//select[@data-handler='selectMonth']"));

        public IWebElement YearDropdown_Arrow => ldriver.FindElement(By.XPath("//select[@data-handler='selectYear']"));

        public IWebElement Dropdown_Arrow_1 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[1]"));

        public IWebElement Dropdown_Arrow_2 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[2]"));

        public IWebElement Dropdown_Arrow_3 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[3]"));

        public IWebElement Dropdown_Arrow_4 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[4]"));

        public IWebElement Dropdown_Arrow_5 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[5]"));

        public IWebElement Dropdown_Arrow_6 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[6]"));

        public IWebElement Dropdown_Arrow_7 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[7]"));

        public IWebElement Save_Btn => ldriver.FindElement(By.XPath("//button[@aria-label='Save']"));

        public IWebElement Save2_Btn => ldriver.FindElement(By.XPath("(//button[@aria-label='Save'])[2]"));

        public IWebElement Table_Name_Column => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Name']//table//td[@data-header='Name']"));

        public IWebElement Name_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='Name']"));

        public IWebElement StartDT_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='Start DT']"));

        public IWebElement StartTime_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='Start Time']"));

        public IWebElement EndDT_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='End DT']"));

        public IWebElement EndTime_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='End Time']"));

        public IWebElement Remarks_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='Remarks']"));

        public IWebElement Instructors_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='Instructors']"));

        public IWebElement Assessment_TableData => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Manage Class Lessons']//table//td[@data-header='Assessment']"));

        public IWebElement ManageClassLessons_Remarks_Input => ldriver.FindElement(By.XPath("//div[contains(@class, 'tab-pane') and .//text()='Remarks']//div[@class='control-input']//textarea"));

        public IWebElement ManageClassFacility_Facility_DropdownArrow => ldriver.FindElement(By.XPath("//*[text()='Manage Class Facility']/following::span[@class='select2-selection__arrow'][1]"));

        public IWebElement OpenClassforRegistration_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Open Class for Registration']"));

        public IWebElement CloseClassforRegistration_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Close Class for Registration']"));

        public IWebElement BeginClass_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Begin Class']"));

        public IWebElement CancelClass_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel Class']"));

        public IWebElement CompleteClass_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Complete Class']"));

        public IWebElement CancelorWithdraw_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel or Withdraw']"));

        public IWebElement RetrainingNeeded_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Retraining Needed']"));

        public IWebElement ConfirmAttendance_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Confirm Attendance']"));

        public IWebElement PassorComplete_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Pass or Complete']"));

        public IWebElement WaitList_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Wait List']"));

        public IWebElement MovedtoRegistered_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Moved to Registered']"));

        public IWebElement ApproveatStateLevel_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Approve at State Level']"));

        public IWebElement ApproveatNGBLevel_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Approve at NGB Level']"));

        public IWebElement RequestSeatForOthers_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Request Seat For Others']"));

        public IWebElement selectAl_CheckBox => ldriver.FindElement(By.XPath("//div[@class='modal-content']//input[@name='selectAll']"));

        public IWebElement RequestSeatForOthers_Icon => ldriver.FindElement(By.XPath("//div[@class='modal-content']//li[@title='Request Seat For Others']"));

        public IWebElement ClassRoster_tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Class Roster. ']"));

        public IWebElement ManageClass_tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Manage Class. ']"));

        public IWebElement ClassStatus_Column1_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Class Status'])[1]"));

        public IWebElement ClassStatus_Column2_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Class Status'])[2]"));

        public IWebElement StudentStatus_Column1_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Student Status'])[1]"));

        public IWebElement StudentStatus_Column2_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Student Status'])[2]"));

        public IWebElement State_Column1_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='State'])[1]"));

        public IWebElement State_Column2_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='State'])[2]"));

        public IWebElement LastName_Column1_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Last Name'])[1]"));

        public IWebElement LastName_Column2_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Last Name'])[2]"));

        public IWebElement FirstName_Column1_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='First Name'])[1]"));

        public IWebElement FirstName_Column2_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='First Name'])[2]"));

        public IWebElement Rank_Column1_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Rank'])[1]"));

        public IWebElement Rank_Column2_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Rank'])[2]"));

        public IWebElement HistoryofActions_NewStatus_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(.)='History of Actions']/following::td[@data-header='New Status'][1]"));

        public IWebElement HistoryofActions_Action_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(.)='History of Actions']/following::td[@data-header='Action'][1]"));

        public IWebElement HistoryofActions_PreviousStatus_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(.)='History of Actions']/following::td[@data-header='Previous Status'][1]"));

        public IWebElement HistoryofActions_Note_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(.)='History of Actions']/following::td[@data-header='Note'][1]"));

        public IWebElement TurnInCaseCode_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Equipment Turn In Information']]//label[text()='Turn In Case Code']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement Description_value_2 => driver.FindElement(By.XPath("(//div[.//span[text()='Equipment Turn In Information']]//label[text()='Description']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)"));

        public IWebElement PropertyBookEquipment_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Equipment Turn In Information']]//label[text()='Property Book Equipment']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)"));

        public IWebElement Quantity_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Equipment Turn In Information']]//label[text()='Quantity']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)"));

        public IWebElement NSN_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Equipment Turn In Information']]//label[text()='NSN']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)"));

        public IWebElement TurninOption_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Equipment Turn In Information']]//label[text()='Turn in Option']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)"));

        public IWebElement LIN_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Equipment Turn In Information']]//label[text()='LIN']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)"));

        public IWebElement OffertoOthers_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Offer to Others')]"));

        public IWebElement CompleteTransfer_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Complete Transfer')]"));

        public IWebElement RequestEquipment_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Request Equipment')]"));

        public IWebElement ApproveTransfer_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Approve Transfer')]"));






        public By monthDropdown_Arrow_ByLocator = By.XPath("//select[@data-handler='selectMonth']");

        public By YearDropdown_Arrow_ByLocator = By.XPath("//select[@data-handler='selectYear']");


    }
}