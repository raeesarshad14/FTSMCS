using AventStack.ExtentReports.Gherkin.Model;
using ICSharpCode.SharpZipLib.GZip;
using Microsoft.Testing.Platform.Extensions.Messages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using static iText.Kernel.Pdf.Colorspace.PdfDeviceCs;
using static System.Windows.Forms.AxHost;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects
{
    public class Panel3Page : SetUp
    {
        public IWebDriver ldriver;

        public Panel3Page(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        public string DocxFile = "ThisDocisfortest.docx";

        // --- SINGLE ELEMENTS (IWebElement) ---

        public IWebElement Reimbursement_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Reimbursements. ']"));

        public IWebElement PropertyBookAdministrationEquipment_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//ul[@role='tablist']//a[@aria-label='Property Book Administration Equipment. ']"));

        public IWebElement Grade_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Grade')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement Branch_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Branch')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement FullName_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Full Name')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement PersonnelState_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Personnel State')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement State_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'State')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement PropertyBookType_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Property Book Type')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement ServiceMember_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Service Member')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement ServiceMember2_Value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Service Member')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement POCState_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'POC State')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement Status_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Status')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement POCState2_Value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'POC State')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement Region_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Region')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement Program_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Program')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement PositionType_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Position Type')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement Position_Value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space(text())='Position']/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement POCStartDate_Value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space(text())='POC Start Date']/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement POCEndDate_Value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space(text())='POC End Date']/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement Email_Value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space(text())='Email']/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement OfficePhone_Value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[normalize-space(text())='Office Phone']/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement RecognitionDate_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Recognition Date')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement BuildingName_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Building Name')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement IncidentDT_Value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Incident DT')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement AddReimbursement_Btn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Add Reimbursement']"));

        public IWebElement ReimbursementType_Dropdown_Arrow => ldriver.FindElement(By.XPath("//div[@class='modal-content' and .//*[contains(text(),'Add a New Reimbursement')]]//span[@class='select2-selection__arrow']"));

        public IWebElement StateDate_Input => ldriver.FindElement(By.XPath("(//div[@class='control-input']//div[@class='input-group section-data-item-value']//input)[1]"));

        public IWebElement EndDate_Input => ldriver.FindElement(By.XPath("(//div[@class='control-input']//div[@class='input-group section-data-item-value']//input)[2]"));

        public IWebElement Amount_Input => ldriver.FindElement(By.XPath("(//div[@class='control-input']//div[@class='input-group section-data-item-value']//input)[3]"));

        public IWebElement Comments_Input => ldriver.FindElement(By.XPath("(//div[@class='control-input']//div[@class='input-group section-data-item-value'])//textarea"));

        public IWebElement Month_DropDown => ldriver.FindElement(By.XPath("//select[@class='ui-datepicker-month']"));

        public IWebElement Year_DropDown => ldriver.FindElement(By.XPath("//select[@class='ui-datepicker-year']"));

        public IWebElement Save_Btn => ldriver.FindElement(By.XPath("//button[@aria-label='Save']"));

        public IWebElement PopUp_Save_Btn => ldriver.FindElement(By.XPath("//button[@aria-label='Save']"));

        public IWebElement PopUp_Cancel_Btn => ldriver.FindElement(By.XPath("//button[@aria-label='Cancel']"));

        public IWebElement Save_Msg => ldriver.FindElement(By.XPath("//div[@class='toast toast-success']//div"));

        public IWebElement ValidateProjections_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Validate Projections']"));

        public IWebElement CancelPOC_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel POC']"));

        public IWebElement InActivatePOC_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='In-Activate POC']"));

        public IWebElement ReActivatePOC_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Re-Activate POC']"));

        public IWebElement UploadNewFile_btn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd']//button[@aria-label='Upload New File']"));

        public IWebElement ChooseFile => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//input[@placeholder='Choose']"));

        public IWebElement DropDownArrow => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd-modal-fileupload fade modal in']//b[@role='presentation']"));

        public IWebElement PopUp_DropDownArrow => ldriver.FindElement(By.XPath("//div[@class='modal-content']//b[@role='presentation']"));

        public IWebElement PopUp_DropDownArrow2 => ldriver.FindElement(By.XPath("(//div[@class='modal-content']//b[@role='presentation'])[2]"));

        public IWebElement DocumentType_option_Input_Filed => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd-modal-fileupload fade modal in']//div[@class='uploadfilediv']//span[@class='select2-selection select2-selection--single']"));

        public IWebElement UploadNewFile_Filename => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd-modal-fileupload fade modal in']//input[@id='filename']"));

        public IWebElement UploadNewFile_FileDescription => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd-modal-fileupload fade modal in']//input[@id='filedescription']"));

        public IWebElement UpLoadBtn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd-modal-fileupload fade modal in']//button[@class='btn btn-default modal-upload-btn']"));

        public IWebElement Column_Name_value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd']//td[@colname='Name']"));

        public IWebElement Column_DocumentType_value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd']//td[@data-header='Document Type']"));

        public IWebElement CheckMarkSign_withRequiredText => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='vsd']//small"));

        public IWebElement ProvideRemarksn_input_field => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//textarea[contains(@placeholder, 'Provide Remarks')]"));

        public IWebElement ProvideRemarksn_input_field2 => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//textarea[contains(@placeholder, 'Provide Remarks')])[2]"));

        public IWebElement PopUp_Yes2_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@class='actionconfirmation-ok-button btn btn-primary btn-round']"));

        public IWebElement PopUp_Yes_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@aria-label='Yes']"));

        public IWebElement Latest_PhaseBar_Text => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//li[@class='phase phase-current']"));

        public IWebElement Phase_Header_Text => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='case-progress-indicator']//b"));

        public IWebElement Phase_Text => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='case-progress-indicator']//div/div[2]"));

        public IWebElement CurrentStatus_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='form-group']//p//span)[1]"));

        public IWebElement Description_OfCurrentStatus_value => ldriver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='form-group']//p//span)[2]"));

        public IWebElement CurrentStatus2_value => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='form-group']//p//span)[1]"));

        public IWebElement NGBRMRequestsReimbursementfromANG_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='NGB RM Requests Reimbursement from ANG']"));

        public IWebElement SubmittoCDC_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Submit to CDC')]"));

        public IWebElement ApprovedSubmittoRC_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Approved -Submit to RC']"));

        public IWebElement Reviewed_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Reviewed']"));

        public IWebElement Received_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Received']"));

        public IWebElement SubmittoNGB_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Submit to NGB')]"));

        public IWebElement SubmittoNGBPM_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Submit to NGB PM')]"));

        public IWebElement ReturntoStateCAPAdmin_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Return to State CAP Admin')]"));

        public IWebElement ReturntoNGBPM_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Return to NGB PM')]"));

        public IWebElement SubmittoNGBCAPAdmin_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Submit to NGB CAP Admin')]"));

        public IWebElement CompleteAnnualQuestionnaire_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Complete Annual Questionnaire')]"));

        public IWebElement Override_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Override')]"));

        public IWebElement VirtualVerificationandSubmittoNGBCAPAdmin_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Virtual Verification and Submit to NGB CAP Admin')]"));

        public IWebElement VirtualVerificationandCompleteAnnualQuestionnaire_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Virtual Verification and Complete Annual Questionnaire')]"));

        public IWebElement ReturntoCDC_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Return to CDC')]"));

        public IWebElement ReturnwithRecommendationstoStateAdmin_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Return with Recommendations to State Admin')]"));

        public IWebElement Return_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Return')]"));

        public IWebElement ReturnwithRecommendationstoState_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Return with Recommendations to State')]"));

        public IWebElement ReturnwithRecommendations_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Return with Recommendations')]"));

        public IWebElement CDCReturntoStateForRevision_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'CDC Return to State For Revision')]"));

        public IWebElement Accept_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Accept')]"));

        public IWebElement DD3161Completed_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'DD 3161 Completed')]"));

        public IWebElement MemoCertifiedandAccepted_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Memo Certified and Accepted')]"));

        public IWebElement DA1687Complete_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'DA 1687 Complete')]"));

        public IWebElement SemiAnnualInventoryInitiated_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Semi-Annual Inventory Initiated')]"));

        public IWebElement SemiAnnualInventoryMemoComplete_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Semi-Annual Inventory Memo Complete')]"));

        public IWebElement AnnualInventoryMemoComplete_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Annual Inventory Memo Complete')]"));

        public IWebElement AnnualInventoryInitiated_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Annual Inventory Initiated']"));

        public IWebElement CDCChangeDDFormsExpire_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'CDC Change/DD Forms Expire')]"));

        public IWebElement NewCDCAdded_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'New CDC Added')]"));

        public IWebElement SubmitforSignatures_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label,'Submit for Signatures')]"));

        public IWebElement SubmitForApproval_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit For Approval']"));

        public IWebElement SubmittoRC_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit to RC']"));

        public IWebElement ReturntoState_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Return to State']"));

        public IWebElement SubmitforFinanceReview_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit for Finance Review']"));

        public IWebElement ReturnWithComments_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Return With Comments']"));

        public IWebElement SubmitforReview_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit for Review']"));

        public IWebElement SubmitForReview_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit For Review']"));

        public IWebElement FundingRevisionBoardRequirements_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Funding Revision Board Requirements. ']"));

        public IWebElement ManageFundingRevision_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Manage Funding Revision. ']"));

        public IWebElement SubmitRequest_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit Request']"));

        public IWebElement ConductBoardPrioritize_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Conduct Board: Prioritize']"));

        public IWebElement NonConcurWithRequest_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Non-Concur With Request']"));

        public IWebElement CeritifyRequest_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Ceritify Request']"));

        public IWebElement FundRequest_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Fund Request']"));

        public IWebElement UnfundRequest_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Unfund Request']"));

        public IWebElement SubmitasExchange_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit as Exchange']"));

        public IWebElement CancelRequest_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel Request']"));

        public IWebElement SubmitforNGBApproval_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit for NGB Approval']"));

        public IWebElement ApproveAgency_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Approve Agency']"));

        public IWebElement InActivateAgency_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='In-Activate Agency']"));

        public IWebElement RequestStateLocalTribalAgencyReActivation_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Request State, Local , Tribal Agency Re-Activation']"));

        public IWebElement RequestFederalAgencyReActivation_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Request  Federal Agency Re-Activation']"));

        public IWebElement DenyAgencyRequest_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Deny Agency Request']"));

        public IWebElement NReActivateInProcessing_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Re-Activate (In Processing)']"));

        public IWebElement Delete_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Delete']"));

        public IWebElement Close_Button => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Close']"));

        public IWebElement Close2_Button => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorTwo-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label, 'Close')]"));

        public IWebElement Therearenoactionsavailableperyourcurrentuserrole_Text => ldriver.FindElement(By.XPath("//div[@aria-label='Personnel Reimbursement  Actions']/following::p[contains(normalize-space(.), 'There are no actions available per your current user role.')]"));

        public IWebElement Order_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[contains(text(), 'Orders')]"));

        public IWebElement Personnel_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[contains(text(), 'Personnel')]"));

        public IWebElement OrderTab_StartDate => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Order Start DT']"));

        public IWebElement OrderTab_EndDate => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Order End DT']"));

        public IWebElement OrderTab_IsAmendment_Header => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Is Amendment?']"));

        public IWebElement ProjectedPersonnelReimbursementssection_Refresh => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Projected Personnel Reimbursements section Refresh']"));

        public IWebElement ProjectedPersonnelReimbursementssection_ShowHide_Filters => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Projected Personnel Reimbursements section Show/Hide Filters']"));

        public IWebElement ProjectedPersonnelReimbursementssection_Comments_Input => ldriver.FindElement(By.XPath("//*[contains(text(),'Projected Personnel Reimbursements')]/following::th[contains(@data-headertext,'Comments')]//input[contains(@class,'column-search-filter')]"));

        public IWebElement ProjectedPersonnelReimbursementssection_Comments_Value => ldriver.FindElement(By.XPath("//*[contains(text(),'Projected Personnel Reimbursements')]/following::table//tr[1]/td[@data-header='Comments']"));

        public IWebElement ProjectedPersonnelReimbursementssection_Amount_Value => ldriver.FindElement(By.XPath("//*[contains(text(),'Projected Personnel Reimbursements')]/following::table//tr[1]/td[@data-header='Amount']"));

        public IWebElement ProjectedPersonnelReimbursementssection_CurrentStatus_Value => ldriver.FindElement(By.XPath("//*[contains(text(),'Projected Personnel Reimbursements')]/following::table//tr[1]/td[@data-header='Current Status']"));

        public IWebElement First_Row => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[contains(text(),'Projected Personnel Reimbursements')]/following::table//tr[@class='odd']//td[2]"));

        public IWebElement CaseCode_value => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Case Code')]/ancestor::div[@class='col-md-12 show']//following-sibling::div[@class='el-data']//span"));

        public IWebElement DeveloperTools_DropDown => ldriver.FindElement(By.XPath("//ul[@class='nav navbar-nav']//li//*[contains(text(),'Developer Tools')]"));

        public IWebElement DeleteCase_Option => ldriver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//li/a[contains(text(),'Delete Case')]"));

        public IWebElement DeleteASRCase_Option => ldriver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//li/a[contains(text(),'Delete ASR Case')]"));

        public IWebElement CDCaseDelete_ShowHideFilters => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@aria-label='CD Case Delete Search Results section Show/Hide Filters']"));

        public IWebElement CaseCode_Input => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//th[@data-headertext='Case Code']//input[@class='column-search-filter']"));

        public IWebElement CaseCode_Value2 => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Case Code']"));

        public IWebElement Delete_Btn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//td[@title='Delete']//button"));

        public IWebElement CancelDeny_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel/Deny']"));

        public IWebElement AcceptCompleteInProcessing_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Accept: Complete In-Processing']"));

        public IWebElement Approve_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Approve']"));

        public IWebElement TargetChange_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Target Change']"));

        public IWebElement Approve2_Btn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[contains(@aria-label, 'Approve')]"));

        public IWebElement InProcessingChecklistComplete_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='In-Processing Checklist Complete']"));

        public IWebElement OutProcess_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Out Process']"));

        public IWebElement RenewalPending_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Renewal Pending']"));

        public IWebElement RenewalApproved_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Renewal Approved']"));

        public IWebElement ChecklistComplete_Btn => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Checklist Complete']"));

        public IWebElement PopUp_Ok_btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@class='btn btn-primary bootbox-accept']"));

        public IWebElement Nodataavailableintable => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//tr/td"));

        public IWebElement successful_message => ldriver.FindElement(By.XPath("//div[@class='toast-message']"));

        public IWebElement RedError_message => ldriver.FindElement(By.XPath("//div[@class='toast-message']"));

        public IWebElement RedPopUp_Close_Btn => ldriver.FindElement(By.XPath("//div[@class='toast toast-error']//button[@class='toast-close-button']"));

        public IWebElement ManageMission_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Manage Mission. ']"));

        public IWebElement ManageFMA_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Manage FMA. ']"));

        public IWebElement Planning_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Planning. ']"));

        public IWebElement ManageCAPQC_Tab => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Manage CAP QC. ']"));

        public IWebElement CDCCertificationChecklist_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='CDC Certification Checklist. ']"));

        public IWebElement StartQC_Button => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Start QC']"));

        public IWebElement Submit_Button => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Submit']"));

        public IWebElement Certify_Button => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Certify']"));

        public IWebElement Verify_Button => ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Verify']"));

        public IList<IWebElement> CDCCertification_NoRadioButtonList => driver.FindElements(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and starts-with(@name,'Yes/No_')]"));
        // --- ELEMENT LISTS (IList<IWebElement>) ---

        public IList<IWebElement> CDCCertification_QuestionList => ldriver.FindElements(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[contains(@class,'cklistfrm_item')]//td[position() mod 2 = 1]"));

        public IList<IWebElement> CDCCertification_YesRadioButtonList => ldriver.FindElements(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and starts-with(@name,'Yes/No_')]"));

        public IWebElement MissionPersonnelSection_Add_Icon => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@aria-label='Mission Personnel section Add']"));

        public IWebElement EquipmentSection_Add_Icon => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@aria-label='Equipment section Add']"));

        public IWebElement HeaderText => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//header"));

        public IWebElement Yes_RadioBtn_1 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_5']"));

        public IWebElement Yes_RadioBtn_2 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_6']"));

        public IWebElement Yes_RadioBtn_3 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_7']"));

        public IWebElement Yes_RadioBtn_4 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_8']"));

        public IWebElement Yes_RadioBtn_5 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_9']"));

        public IWebElement Yes_RadioBtn_6 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_10']"));

        public IWebElement Yes_RadioBtn_7 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_11']"));

        public IWebElement Yes_RadioBtn_8 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_13']"));

        public IWebElement Yes_RadioBtn_9 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_14']"));

        public IWebElement Yes_RadioBtn_10 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_15']"));

        public IWebElement Yes_RadioBtn_11 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_16']"));

        public IWebElement Yes2_RadioBtn_1 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_17']"));

        public IWebElement Yes2_RadioBtn_2 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_18']"));

        public IWebElement Yes2_RadioBtn_3 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_19']"));

        public IWebElement Yes2_RadioBtn_4 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_20']"));

        public IWebElement Yes2_RadioBtn_5 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_21']"));

        public IWebElement Yes2_RadioBtn_6 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_22']"));

        public IWebElement Yes2_RadioBtn_7 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_24']"));

        public IWebElement Yes2_RadioBtn_8 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_25']"));

        public IWebElement Yes2_RadioBtn_9 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_26']"));

        public IWebElement Yes2_RadioBtn_10 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_27']"));

        public IWebElement Yes2_RadioBtn_11 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='1' and @name='Yes/No_28']"));

        public IWebElement Calendar_1 => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])"));

        public IWebElement Calendar_2 => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[2]"));

        public IWebElement Calendar_5 => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[5]"));

        public IWebElement Calendar_6 => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//input[contains(@class,' jquery-datepicker hasDatepicker')])[6]"));

        public IWebElement monthDropdown_Arrow => driver.FindElement(By.XPath("//select[@data-handler='selectMonth']"));

        public IWebElement YearDropdown_Arrow => driver.FindElement(By.XPath("//select[@data-handler='selectYear']"));

        public IWebElement No_RadioBtn_1 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_5']"));

        public IWebElement No_RadioBtn_2 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_6']"));

        public IWebElement No_RadioBtn_3 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_7']"));

        public IWebElement No_RadioBtn_4 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_8']"));

        public IWebElement No_RadioBtn_5 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_9']"));

        public IWebElement No_RadioBtn_6 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_10']"));

        public IWebElement No_RadioBtn_7 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_11']"));

        public IWebElement No_RadioBtn_8 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_13']"));

        public IWebElement No_RadioBtn_9 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_14']"));

        public IWebElement No_RadioBtn_10 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_15']"));

        public IWebElement No_RadioBtn_11 => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@id='2' and @name='Yes/No_16']"));

        public IWebElement _1stQuestion => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td"));

        public IWebElement _2ndQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[3]"));

        public IWebElement _3rdQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[5]"));

        public IWebElement _4thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[7]"));

        public IWebElement _5thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[9]"));

        public IWebElement _6thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[11]"));

        public IWebElement _7thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[13]"));

        public IWebElement _8thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[15]"));

        public IWebElement _9thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[17]"));

        public IWebElement _10thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[19]"));

        public IWebElement _11thQuestion => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//tr[@class='cklistfrm_item']//td)[21]"));

        public IWebElement CurrentFuture_OrdersAddIcon => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@aria-label='Current & Future Orders section Add']"));

        public IWebElement TourType_Dropdown_Arrow => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'Tour Type')]]//span[@class='select2-selection__arrow']"));

        public IWebElement MissionActivity_Dropdown_Arrow => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'Mission Activity')]]//span[@class='select2-selection__arrow']"));

        public IWebElement Role_Dropdown_Arrow => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'Role')]]//span[@class='select2-selection__arrow']"));

        public IWebElement FundCode_Dropdown_Arrow => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'Fund Code')]]//span[@class='select2-selection__arrow']"));

        public IWebElement ASN_Dropdown_Arrow => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'ASN')]]//span[@class='select2-selection__arrow']"));

        public IWebElement ASN => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'ASN')]]//span[@class='select2-selection__placeholder']"));
       
        public IWebElement DutyZipCode_Dropdown_Arrow => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'Duty Zip Code')]]//input"));

        public IWebElement ProjectCode_Dropdown_Arrow => driver.FindElement(By.XPath("//div[@class='form-group' and .//*[contains(text(),'Project Code')]]//span[@class='select2-selection__arrow']"));

        public IWebElement OrderStartDT_Input => driver.FindElement(By.XPath("(//div[@class='control-input']//div[@class='input-group section-data-item-value']//input)[2]"));

        public IWebElement OrderEndtDT_Input => driver.FindElement(By.XPath("(//div[@class='control-input']//div[@class='input-group section-data-item-value']//input)[3]"));

        public IWebElement IsMissionRelated_Yes_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='18496'])[1]"));

        public IWebElement HasInjuries_Yes_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='19254'])[1]"));

        public IWebElement IsCDAviationYes_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='18495'])[1]"));

        public IWebElement AccidentPlanExercised_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='18494'])[1]"));

        public IWebElement IsEquipmentInvolved_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='19253'])[1]"));

        public IWebElement VerifyAuthority_Yes_CheckBox => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='20654']"));

        public IWebElement VerifyIAW32_Yes_CheckBox => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='20655']"));

        public IWebElement VerifyAvailabilityofFunding_Yes_CheckBox => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='20656']"));

        public IWebElement Add_Btn => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Add']"));

        public IWebElement MissionInformation_CurrentStatus_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Current Status')]/ancestor::div[@class='section-layout-item show']//following-sibling::div[@class='el-data']//span)[3]"));

        public IWebElement HistoryofActions_Note_Value => driver.FindElement(By.XPath("//*[normalize-space(.)='History of Actions']/following::td[@data-header='Note'][1]"));

        public IWebElement HistoryofActions_PreviousStatus_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(.)='History of Actions']/following::td[@data-header='Previous Status'][1]"));

        public IWebElement HistoryofActions_Action_Value => driver.FindElement(By.XPath("//*[normalize-space(.)='History of Actions']/following::td[@data-header='Action'][1]"));

        public IWebElement HistoryofActions_Comment_Value => driver.FindElement(By.XPath("//*[normalize-space(.)='History of Actions']/following::td[@data-header='Comment'][1]"));

        public IWebElement HistoryofActions_NewStatus_Value => driver.FindElement(By.XPath("//*[normalize-space(.)='History of Actions']/following::td[@data-header='New Status'][1]"));

        public IWebElement HistoryofActions_CurrentStatus_Value => driver.FindElement(By.XPath("//*[normalize-space(.)='History of Actions']/following::td[@data-header='Current Status'][1]"));

        public IWebElement HistoryofActions_ActionTaken_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space(.)='History of Actions']/following::td[@data-header='Action Taken'][1]"));

        public IWebElement MissionInformation_MissionStartDate_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Start DT')]/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement MissionInformation_MissionEndtDate_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'End DT')]/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement MissionInformation_Activity_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Activity')]/ancestor::div[@class='section-layout-item show']//following-sibling::div[@class='el-data']//span)[1]"));

        public IWebElement MissionInformation_DrugThreat_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Drug Threat')]/ancestor::div[@class='section-layout-item show']//following-sibling::div[@class='el-data']//span)[1]"));

        public IWebElement ASRMissionSummary_AgencyLocationTaskForceOrCoalitiont_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Agency Location, Task Force Or Coalition')]/ancestor::div[@class='section-layout-item show']//following-sibling::div[@class='el-data']//span)[1]"));

        public IWebElement ASRMissionSummary_State_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'State')]/ancestor::div[@class='section-layout-item show']//following-sibling::div[@class='el-data']//span)[1]"));

        public IWebElement ASRMissionSummary_Program_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Program')]/ancestor::div[@class='section-layout-item show']//following-sibling::div[@class='el-data']//span)[1]"));

        public IWebElement ASRMissionSummary_RequestingAgency_Value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Requesting Agency')]/ancestor::div[@class='section-layout-item show']//following-sibling::div[@class='el-data']//span)[1]"));

        public IWebElement MissionInformation_Tab_MissionStartDate_Value => driver.FindElement(By.XPath("//div[.//span[text()='Mission Information']]//label[text()='Mission Start Date']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span"));

        public IWebElement MissionInformation_Tab_MissionEndDate_Value => driver.FindElement(By.XPath("//div[.//span[text()='Mission Information']]//label[text()='Mission End Date']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span"));

        public IWebElement MissionInformation_Tab_Activity_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Mission Information']]//label[text()='Activity']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement MissionInformation_Tab_DrugThreat_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Mission Information']]//label[text()='Drug Threat']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement MissionInformation_Tab_AgencyLocationTaskForceOrCoalition_Value => driver.FindElement(By.XPath("(//div[.//span[text()='Mission Information']]//label[text()=' Agency Location, Task Force Or Coalition']/ancestor::div[contains(@class, 'el-label')]/following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement OpenCase_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Open Case']"));

        public IWebElement Open_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Open']"));

        public IWebElement Cancel_Btn => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel'])[2]"));

        public IWebElement Cancel_Btn1 => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel'])[1]"));

        public IWebElement Revise_Btn1 => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Revise'])[1]"));

        public IWebElement Complete_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Complete']"));

        public IWebElement CancelCase_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel Case']"));

        public IWebElement CloseCase_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Close Case']"));

        public IWebElement MovetoActive_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Move to Active']"));

        public IWebElement CancelMission_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Cancel Mission']"));

        public IWebElement Undo_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Undo']"));

        public IWebElement UnresourceMission_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Unresource Mission']"));

        public IWebElement MovetoCompleted_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Move to Completed']"));

        public IWebElement ReOpen_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Re-Open']"));

        public IWebElement PlanningTab_DeleteIcon_ColumnTable => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@aria-label='Delete Icon']"));

        public IWebElement PlanningTab_State_Column_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in' and .//div[text()='Planning']]//td[@data-header='State']"));

        public IWebElement PlanningTab_Role_Column_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in' and .//div[text()='Planning']]//td[@data-header='Role']"));

        public IWebElement PlanningTab_Name_Column_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in' and .//div[text()='Planning']]//td[@data-header='Name']"));

        public IWebElement PlanningTab_StartDT_Column_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in' and .//div[text()='Planning']]//td[@data-header='Start DT']"));

        public IWebElement PlanningTab_EndDT_Column_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in' and .//div[text()='Planning']]//td[@data-header='End DT']"));

        public IWebElement ToAddaiconbutton_Text => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//p"));

        public IWebElement AgencyCode_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Agency Code')]/ancestor::div[@class='form-group']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement RequestingAgency_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Requesting Agency')]/ancestor::div[@class='form-group']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement RequestingAgency2_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Requesting Agency')]/ancestor::div[@class='form-group']//following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement AgencyState_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Agency State')]/ancestor::div[@class='form-group']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement AgencyState2_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Agency State')]/ancestor::div[@class='form-group']//following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement AgencyType_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Agency Type')]/ancestor::div[@class='form-group']//following-sibling::div[@class='el-data']//span)"));

        public IWebElement AgencyType2_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(text(), 'Agency Type')]/ancestor::div[@class='form-group']//following-sibling::div[@class='el-data']//span)[2]"));

        public IWebElement Description_value => driver.FindElement(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='form-group']//p//span)[2]"));

        public IWebElement SafetyDutyType_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Safety Duty Type']/following::span[contains(@class,'select2-selection__rendered')][1]"));

        public IWebElement SafetyType_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Safety Type']/following::span[contains(@class,'select2-selection__rendered')][1]"));

        public IWebElement AccidentClass_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Accident Class']/following::span[contains(@class,'select2-selection__rendered')][1]"));

        public IWebElement SafetyEquipmentBranch_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Safety Equipment Branch']/following::span[contains(@class,'select2-selection__rendered')][1]"));

        public IWebElement EquipmentType_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Equipment Type']/following::span[contains(@class,'select2-selection__rendered')][1]"));

        public IWebElement HazardDescription_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Hazard Description']/following::textarea[1]"));

        public IWebElement BasicAgencyInformation_Description => driver.FindElement(By.XPath("//*[normalize-space()='Basic Agency Information']//following::label[.='Description']/following::span[1]"));

        public IWebElement RAC_value => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='RAC']/following::span[@class=\"select2-selection__rendered\"])[1]"));

        public IWebElement ReferenceRegulation_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Reference Regulation']/following::textarea[1]"));

        public IWebElement WorkOrderNumber_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Work Order Number']/following::input[1]"));

        public IWebElement WorkOrderSubmissionDate_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space(text())='Work Order Submission Date']/following::input[1]"));

        public IWebElement BuildingName_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space()='Building Name']//following-sibling::div[contains(@class,'control-input')] //input"));

        public IWebElement BuildingNumber_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space()='Building Number']//following-sibling::div[contains(@class,'control-input')] //input"));

        public IWebElement RegionorCity_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space()='Region or City']//following-sibling::div[contains(@class,'control-input')] //input"));

        public IWebElement RoomName_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space()='Room Name']//following-sibling::div[contains(@class,'control-input')] //input"));

        public IWebElement RoomNumber_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space()='Room Number']//following-sibling::div[contains(@class,'control-input')] //input"));

        public IWebElement CorrectiveAction_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space()='Corrective Action']//following-sibling::div[contains(@class,'control-input')] //textarea"));

        public IWebElement UpdatedDate_value => driver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne-widget']//*[normalize-space()='Updated Date']//following-sibling::div[contains(@class,'control-input')] //input"));

        public IWebElement AddBOSTarget_btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//a[@aria-label='Add BOS Targets']"));

        public IWebElement DropdDownOption => driver.FindElement(By.XPath("//ul[@class='select2-results__options']//li"));

        public IWebElement TotalFunding_Value => driver.FindElement(By.XPath("//label[contains(text(),'Total Funding')]/following::span[contains(@class,'sdi-multiline-text')][1]"));

        public IWebElement Questions_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//ul[@role='tablist']//a[@aria-label='Questions. ']"));

        public IWebElement Questionnaires_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//ul[@role='tablist']//a[@aria-label='Questionnaire(s). ']"));

        public IWebElement QuestionssectionAdd_Icon => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@aria-label='Questions section Add']"));

        public IWebElement QuestionnairesAdd_Icon => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@aria-label='Questionnaire(s) section Add']"));

        public IWebElement Actions_Tab => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//ul[@role='tablist']//a[@aria-label='Actions. ']"));

        public IWebElement Edit_Response => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@title='Edit response']"));

        public IWebElement TotalTarget_Value => driver.FindElement(By.XPath("//label[contains(text(),'Total Target')]/following::span[contains(@class,'sdi-multiline-text')][1]"));

        public IWebElement FundingToTargetDIFF_Value => driver.FindElement(By.XPath("//label[contains(text(),'Funding To Target DIFF')]/following::span[contains(@class,'sdi-multiline-text')][1]"));

        public IWebElement CurrentYearTargetAmount_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Current Year Target Amount'] //following-sibling::div[@class='el-data']"));

        public IWebElement PriorYearTarget_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Prior Year Target'] //following-sibling::div[@class='el-data']"));

        public IWebElement FiscalYear_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Fiscal Year'] //following-sibling::div[@class='el-data']"));

        public IWebElement Justification_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Justification'] //following-sibling::div[@class='el-data']"));

        public IWebElement ReturnBranch_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Return Branch'] //following-sibling::div[@class='el-data']"));

        public IWebElement RequestBranch_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Request Branch'] //following-sibling::div[@class='el-data']"));

        public IWebElement MissionType_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Mission Type'] //following-sibling::div[@class='el-data']"));

        public IWebElement ProjectCode_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Project Code'] //following-sibling::div[@class='el-data']"));

        public IWebElement FundCode_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Fund Code'] //following-sibling::div[@class='el-data']"));

        public IWebElement ASN_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ASN'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGASN_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG ASN'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGMILPERSAmountReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG MILPERS Amount Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGEnlistedATAmountReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Enlisted AT Amount Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGMILPERSAmountRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG MILPERS Amount Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOMReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG O&M Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGEnlistedIDTAmountReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Enlisted IDT Amount Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOMRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG O&M Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGEnlistedATAmountRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Enlisted AT Amount Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOfficerATAmountReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Officer AT Amount Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOfficerATAmountRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Officer AT Amount Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGEnlistedIDTAmountRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Enlisted IDT Amount Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOfficerIDTAmountReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Officer IDT Amount Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOfficerIDTAmountRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Officer IDT Amount Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGEnlistedAmountReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Enlisted Amount Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGEnlistedAmountRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Enlisted Amount Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOfficerAmountReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Officer Amount Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement ANGOfficerAmountRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='ANG Officer Amount Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement IsExchange_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Is Exchange'] //following-sibling::div[@class='el-data']"));

        public IWebElement OctoberDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='October Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement OctoberDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='October Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement NovemberDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='November Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement NovemberDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='November Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement DecemberDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='December Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement DecemberDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='December Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement JanuaryDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='January Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement JanuaryDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='January Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement FebruaryDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='February Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement FebruaryDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='February Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement MarchDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='March Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement MarchDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='March Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement AprilDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='April Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement AprilDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='April Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement MayDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='May Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement MayDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='May Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement JuneDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='June Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement JuneDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='June Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement JulyDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='July Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement JulyDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='July Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement AugustDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='August Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement AugustDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='August Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement SeptemberDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='September Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement SeptemberDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='September Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement TotalDollarsReturned_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Total Dollars Returned'] //following-sibling::div[@class='el-data']"));

        public IWebElement TotalDollarsRequested_value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Total Dollars Requested'] //following-sibling::div[@class='el-data']"));

        public IWebElement FundingRevisionType_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[normalize-space()='Funding Revision Type'] //following-sibling::div[@class='el-data']"));

        public IWebElement Receivedallofyourfunding_No_Option1 => driver.FindElement(By.XPath("(//div[contains(@class,'tab-pane') and contains(@class,'active')]  //label[contains(normalize-space(.),'Have you received all of your funding (AFP only refers to Army funds)?')]  /following::label[normalize-space()='No']  /preceding-sibling::input)[1]"));

        public IWebElement ANGreimbursementstodate_No_Option2 => driver.FindElement(By.XPath("(//div[contains(@class,'tab-pane') and contains(@class,'active')]  //label[contains(normalize-space(.),'Have you accounted for all of your ANG reimbursements to date? (Yes/No)')]  /following::label[normalize-space()='No']  /preceding-sibling::input)[1]"));

        public IWebElement HaveyoureceivedallofARNGreimbursements_No_Option3 => driver.FindElement(By.XPath("(//div[contains(@class,'tab-pane') and contains(@class,'active')]  //label[contains(normalize-space(.),'Have you received all of ARNG reimbursements to date? (Yes/No)')]  /following::label[normalize-space()='No']  /preceding-sibling::input)[1]"));

        public IWebElement ANGreimbursementstodateg_No_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(.,'ANG reimbursements to date')] /ancestor::div[contains(@class,'el-form-group')] /following-sibling::div[contains(@class,'el-data')] //i[@aria-label='X Icon']"));

        public IWebElement ANGreimbursementstodate_No_Value => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//label[contains(.,'Have you received all of ARNG reimbursements to date? (Yes/No)')] /ancestor::div[contains(@class,'el-form-group')] /following-sibling::div[contains(@class,'el-data')] //i[@aria-label='X Icon']"));

        public IWebElement receivedallofyourfunding_No_Value => driver.FindElement(By.XPath("//label[contains(.,'Have you received all of your funding (AFP only refers to Army funds)? (Yes/No)')] /ancestor::div[contains(@class,'el-form-group')] /following-sibling::div[contains(@class,'el-data')] //i[@aria-label='X Icon']"));

        public IWebElement FRBR_Tab_Question_1 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_2 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_3 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_4 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_5 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_6 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_7 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_8 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_9 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_10 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_11 => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='assessment-question']"));

        public IWebElement FRBR_Tab_Question_Yes => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//input[@value='Y']"));

        public IWebElement btnSurveyResponseSave_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@id='btnSurveyResponseSave']"));

        public IWebElement btnSurveyResponseAccept_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@id='btnSurveyResponseAccept']"));

        public IWebElement btnSurveyResponseNext_Btn => driver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@id='btnSurveyResponseSkip']"));

        public IWebElement Question1_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Is this an Enduring Mission?')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement Question2_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Is this on the next FY State Plan (Mission Susstainment)? ')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement Question3_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Will this person support an enduring mission? ')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement Question4_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Was this due to a reduced target? ')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement Question5_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Is this request for personnel currently on orders?')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement Question6_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Is travel required for NGB mandated functional area training or State purposes?')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement Question7_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Is this purchase going to require a 5K packet?')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement Question8_Yes_Answer => driver.FindElement(By.XPath("//tr[.//text()[contains(.,'Is this request for an existing requirement?')]] //td[@class='alignRight']//span[normalize-space()='Yes']"));

        public IWebElement CreateClass_table_Row => driver.FindElement(By.XPath("//*[contains(text(), 'Create Class')]/ancestor::div[contains(@class, 'tab-pane')]//tr[@class='odd']/td[@title='CSU Class']"));

        public IWebElement Description_Input => ldriver.FindElement(By.XPath("//*[contains(text(),'Property Book Administration Equipment')]//following::*[contains(text(),'Add Equipment')]//following::*[contains(text(),'Description')]//following::textarea[1]"));

        public IWebElement LineItemNumber_Input => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[text()='Property Book Administration Equipment']/following::*[text()='Add Equipment']/following::*[text()='Line Item Number']/following::input[1]"));

        public IWebElement NationalStockNumber_Input => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[text()='Property Book Administration Equipment']/following::*[text()='Add Equipment']/following::*[text()='National Stock Number']/following::input[1]"));

        public IWebElement SerialNumber_Input => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[text()='Property Book Administration Equipment']/following::*[text()='Add Equipment']/following::*[text()='Serial Number']/following::input[1]"));

        public IWebElement Quantity_Input => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in'] //*[text()='Property Book Administration Equipment']/following::*[text()='Add Equipment']/following::*[text()='Quantity']/following::input[1]"));

        public IWebElement QuantityUsed_Input => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in'] //*[text()='Property Book Administration Equipment']/following::*[text()='Add Equipment']/following::*[text()='Quantity Used']/following::input[1]"));

        public IWebElement Standard_Yes_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='21786'])[1]"));

        public IWebElement Expendable_Yes_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='21777'])[1]"));

        public IWebElement Serviceable_Yes_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='21784'])[1]"));

        public IWebElement Destroyed_Yes_CheckBox => driver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-sdi='21776'])[1]"));

        public IWebElement Dropdown_Arrow_1 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[1]"));

        public IWebElement Dropdown_Arrow_2 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[2]"));

        public IWebElement Dropdown_Arrow_3 => ldriver.FindElement(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='select2-selection__arrow'])[3]"));

        public IWebElement IsActive_Yes => ldriver.FindElement(By.XPath("//label[contains(., 'Is Active')]/following::label[contains(., 'Yes')][1]"));

        public IWebElement NeedsImprovement_CheckBox => ldriver.FindElement(By.XPath("//input[following-sibling::text()[contains(., 'Needs Improvement')]]"));

        public IWebElement SurveyResponse_Save_Btn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@id='btnSurveyResponseSave']"));

        public IWebElement SurveyResponse_Next_Btn => ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@id='btnSurveyResponseSkip']"));








        public By DropdDownOptions = By.XPath("//ul[@class='select2-results__options']//li");

        public By DocumentType_Options = By.XPath("//*[@class='select2-results']//ul[@class='select2-results__options']//li");

        public By TurnIn_btn = By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Turn In']");


        public IList<IWebElement> YesAndNo_Row => driver.FindElements(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@style='text-align:right;'])"));

        public IList<IWebElement> LineItemNumber => driver.FindElements(By.XPath("(//div[@id='entityViewNavigatorOne-widget']//div[@class='tab-pane fade nav-panel-parent active in']//td[@data-header='Line Item Number'])"));



        public By monthDropdown_Arrow_ByLocator = By.XPath("//select[@data-handler='selectMonth']");

        public By YearDropdown_Arrow_ByLocator = By.XPath("//select[@data-handler='selectYear']");

        public By Close_Button_ByLocator = By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Close']");
        
        public By Delete_Button_ByLocator = By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Delete']");

        public By PopUp_Yes_Btn_ByLocator = By.XPath("//div[@class='modal-content']//button[@aria-label='Yes']");

        public By RedError_message_ByLocator = By.XPath("//div[@class='toast-message']");

        public By RedPopUp_Close_Btn_ByLocator = By.XPath("//div[@class='toast toast-error']//button[@class='toast-close-button']");

        public By Add_Btn_ByLocator = By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//button[@aria-label='Add']");

        public By Save_Msg_ByLocator = By.XPath("//div[@class='toast toast-success']//div");

        public By RedError_message_Locator = By.XPath("//div[@class='toast-message']");


    }
}
