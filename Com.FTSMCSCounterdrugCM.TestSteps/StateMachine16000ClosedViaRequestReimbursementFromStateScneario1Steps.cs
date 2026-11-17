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
    public class StateMachine16000ClosedViaRequestReimbursementFromStateScneario1Steps : UtilityMethods
    {

        // Below is the URL path for this test:
       
        public StateMachine16000ClosedViaRequestReimbursementFromStateScneario1Steps(IWebDriver driver) : base(driver)
        {

        }



        public void StateMachine16000ClosedViaRequestReimbursementFromStateScneario1()
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
                ClickObj(p2.ShowHide_Filters, "ShowHide/Filters");
                EnterTxt(p2.Branch_Input, "ARNG", "ARNG");
                ClickObj(p2.FirstRow, "First Row");

                string CapturedText_FullName_OnPanel3 = GetElementText(p3.FullName_Value, "Full Name Value");
                TestContext.Progress.WriteLine("Captured Text FullName On Panel3: " + CapturedText_FullName_OnPanel3);

                commonMethods.AddReimbursementUsingOrderDates();

                ClickObj(p3.ProjectedPersonnelReimbursementssection_Refresh, "Projected Personnel Reimbursements section Refresh");
                ClickObj(p3.ProjectedPersonnelReimbursementssection_ShowHide_Filters, "Projected Personnel Reimbursements section Show/Hide Filters");
                EnterTxt(p3.ProjectedPersonnelReimbursementssection_Comments_Input, commonMethods.randomComment, commonMethods.randomComment);
                moveToElement(p3.ProjectedPersonnelReimbursementssection_Comments_Value);
                verifyElementText(p3.ProjectedPersonnelReimbursementssection_Comments_Value, commonMethods.randomComment);
                verifyElementText(p3.ProjectedPersonnelReimbursementssection_Amount_Value, commonMethods.randomAmount);
                moveToElement(p3.ProjectedPersonnelReimbursementssection_CurrentStatus_Value);
                verifyElementText(p3.ProjectedPersonnelReimbursementssection_CurrentStatus_Value, "Projected");
                ClickObj(p3.First_Row, "Projected Personnel Reimbursements Table First row");
                waitForLoadingBarToCompleteinSeconds();
                ScrollAndMoveToElement(p4.ValidateProjections_Button);
                commonMethods.ValidateElementDisplayed(p4.ValidateProjections_Button, "Validate Projections");
                ScrollAndMoveToElement(p4.ValidateProjections_Button);
                commonMethods.ValidateElementIsEnabled(p3.Delete_Button, "Delete Button");
                ClickObj(p4.UploadNewFile_Btn, "Upload NewFile btn");
                waitForLoadingBarToCompleteinSeconds();
                UploadFileFromProjectFolder(p3.DocxFile, "Reimb-Validation");
                ValidateElementText(p4.Column_Name_value, "Test File.docx");
                ValidateElementText(p4.Column_DocumentType_value, "Validation Document Required");
                ValidateElementText(p4.CheckMarkSign_withRequiredText, "Required");
                ValidateElementText(p4.CurrentStatus_value, "Projected");
                commonMethods.ValidateElementIsEnabled(p3.ValidateProjections_Button, "Delete Button");
                commonMethods.ValidateElementIsEnabled(p3.Delete_Button, "Delete Button");
                ClickObj(p4.ValidateProjections_Button, "Delete Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p4.CurrentStatus_value, "Validated");
                commonMethods.ValidateElementIsEnabled(p4.RequestReimbursementfromState_Button, "Request Reimbursement from State Button");
                commonMethods.ValidateElementIsEnabled(p4.Delete_Button, "Delete Button");
                ClickObj(p4.RequestReimbursementfromState_Button, "Request Reimbursement from State Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p4.CurrentStatus_value, "Requested");
                commonMethods.ValidateElementIsEnabled(p4.Close_Button, "Close Button");
                commonMethods.ValidateElementIsEnabled(p4.Delete_Button, "Delete Button");
                EnterTxt(p4.ProvideRemarksn_input_field, "Close Text Entered", "Close Text Entered");
                ClickObj(p4.Close_Button, "Close Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                ValidateElementText(p4.CurrentStatus_value, "Closed");

            }));

        }
      



    }
}
