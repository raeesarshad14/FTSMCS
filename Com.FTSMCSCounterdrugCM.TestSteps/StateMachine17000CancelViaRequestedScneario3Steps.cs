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
    public class StateMachine17000CancelViaRequestedScneario3Steps : UtilityMethods
    {

        public StateMachine17000CancelViaRequestedScneario3Steps(IWebDriver driver) : base(driver)
        {

        }

        public void StateMachine17000CancelViaRequestedScneario3()
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
                verifyElementText(p1.CommandCenter_Header, "Command Center");
                verifyElementText(p2.LandingPage_DropDown, "Landing Page");
                ClickObj(p1.PersonnelManagementTool_PMT_Tab, "Personnel Management Tool (PMT)");
                ClickObj(p1.ActivePersonnel_Link, "Active Personnel");
                verifyElementTextContains(p2.LandingPage_DropDown, "Personnel - Active Personnel");
                ClickObj(p2.FirstRow, "First Row");

                string CapturedText_PersonnelState_OnPanel3 = GetElementText(p3.PersonnelState_Value, "Personnel State Value");
                TestContext.Progress.WriteLine("Captured Text Personnel State On Panel3: " + CapturedText_PersonnelState_OnPanel3);

                string CapturedText_Branch_OnPanel3 = GetElementText(p3.Branch_Value, "Branch Value");
                TestContext.Progress.WriteLine("Captured Text Branch On Panel 3: " + CapturedText_Branch_OnPanel3);

                string CapturedText_FullName_OnPanel3 = GetElementText(p3.FullName_Value, "Full Name Value");
                TestContext.Progress.WriteLine("Captured Text FullName On Panel3: " + CapturedText_FullName_OnPanel3);



                ClickObj(p3.Reimbursement_Tab, "Reimbursements");
                ClickObj(p3.AddReimbursement_Btn, "Add Reimbursement Button");

   
                string StartFiscalYear = GetFederalFiscalYearStartDateMMddyyyy();
                TestContext.Progress.WriteLine("Federal Fiscal Year Start Date is: " + StartFiscalYear);
                string EndFiscalYear = GetFederalFiscalYearEndDateMMddyyyy();
                TestContext.Progress.WriteLine("Federal Fiscal Year end Date is: " + EndFiscalYear);

              

               
                SelectFromCustomDropdownByText(p3.ReimbursementType_Dropdown_Arrow, p3.DropdDownOptions, "AGR Operational Support");
                SelectDateFromCalendarByLocator(p3.StateDate_Input, p3.monthDropdown_Arrow_ByLocator, p3.YearDropdown_Arrow_ByLocator, StartFiscalYear);
                SelectDateFromCalendarByLocator(p3.EndDate_Input, p3.monthDropdown_Arrow_ByLocator, p3.YearDropdown_Arrow_ByLocator, EndFiscalYear);

                string randomAmount = GenerateRandomFormattedValue("$1,000.00");
                TestContext.Progress.WriteLine("Random Amount: " + randomAmount);

                EnterTxt(p3.Amount_Input, randomAmount, randomAmount);

                string RandomComment = GenerateRandomText();
                TestContext.Progress.WriteLine("Random Comment: " + RandomComment);


                EnterTxt(p3.Comments_Input, RandomComment, RandomComment);
                ClickObj(p3.Save_Btn, "Save Button");
                verifyElementText(p3.Save_Msg, "Saved Successfully");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Command Center Going Back");
                ClickObj(p1.Reimbursements_REIM_Tab, "Reimbursements (REIM). ");
                ClickObj(p1.Search_Btn, "Search butoon of Reimbursements (REIM). ");
                ClickObj(p2.ShowHide_Filters, "Show/Hide Filters");
                EnterTxt(p2.FullName_Input, CapturedText_FullName_OnPanel3, CapturedText_FullName_OnPanel3);
                EnterTxt(p2.ReimbursementComments_Input, RandomComment, RandomComment);


               // ValidateElementText(p2.AffilState_Value, CapturedText_PersonnelState_OnPanel3);

                ValidateElementText(p2.FullName_Value, CapturedText_FullName_OnPanel3);

                ValidateElementText(p2.Branch_Value, CapturedText_Branch_OnPanel3);

                ValidateElementText(p2.ReimbursementAmountt_Value, randomAmount);

                ValidateElementText(p2.DaysInCurrentStatus_Value, "1");

                ClickObj(p2.FirstRow2, "First Row");

                commonMethods.ValidateElementIsDisabled(p3.ValidateProjections_Button, "Validate Projections");

                ClickObj(p3.UploadNewFile_btn, "Upload NewFile btn");

                UploadFileFromProjectFolder(p3.DocxFile, "Reimb-Validation");

                ValidateElementText(p3.Column_Name_value, "Test File.docx");
                ValidateElementText(p3.Column_DocumentType_value, "Validation Document Required");
                ValidateElementText(p3.CheckMarkSign_withRequiredText, "Required");
                ClickObj(p3.ValidateProjections_Button, "Validate Projections");
                ClickObj(p3.PopUp_Yes2_Btn, " Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Validated");
                commonMethods.VerifyElementisPresent(p3.NGBRMRequestsReimbursementfromANG_Button, "NGB RM Requests Reimbursement from ANG Button");

                //below test will fail as it is showing delete button currently but should be cancel
                commonMethods.VerifyElementisPresent(p3.Delete_Button, "Delete Button");
                ClickObj(p3.NGBRMRequestsReimbursementfromANG_Button, "NGB RM Requests Reimbursement from ANG Button");
                ClickObj(p3.PopUp_Yes_Btn, " Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Requested");

                //below test will fail as it is showing delete button currently but should be cancel
                commonMethods.VerifyElementisPresent(p3.Delete_Button, "Delete Button");

                commonMethods.VerifyElementisPresent(p3.Close_Button, "Close Button");
                EnterTxt(p3.ProvideRemarksn_input_field, "Delete", "Entering Delete text");
                ClickObj(p3.Delete_Button, "Delete Button");
                ClickObj(p3.PopUp_Yes_Btn, " Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Cancel");
   





            }));
        }



    }
}
