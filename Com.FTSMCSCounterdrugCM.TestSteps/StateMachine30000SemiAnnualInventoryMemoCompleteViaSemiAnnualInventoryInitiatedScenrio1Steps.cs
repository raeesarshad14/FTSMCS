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
    public class StateMachine30000SemiAnnualInventoryMemoCompleteViaSemiAnnualInventoryInitiatedScenrio1Steps : UtilityMethods
    {

        public StateMachine30000SemiAnnualInventoryMemoCompleteViaSemiAnnualInventoryInitiatedScenrio1Steps(IWebDriver driver) : base(driver)
        {

        }

        public void StateMachine30000SemiAnnualInventoryMemoCompleteViaSemiAnnualInventoryInitiatedScenrio1()
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


                ClickObj(p1.Logistics_Tab, "Logistics Tab");
                ClickObj(p1.AwaitingAcceptanceByCDC_Link, "Awaiting Acceptance By CDC Link");
                verifyElementTextContains(p2.LandingPage_DropDown, "Property Book Management - Awaiting Acceptance By CDC");
                ClickObj(p2.FirstRow, "First Row");

                ValidateElementText(p3.CurrentStatus_value, "Property Book Awaiting Acceptance By CDC");
                ValidateElementText(p3.Description_value, "Property Book Awaiting Acceptance By CDC");

                ClickObj(p3.DD3161Completed_Button, "DD 3161 Completed Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");

                ValidateElementTextContain(p3.CurrentStatus_value, "Property Book Awaiting Supply Off/NCO Appointment");
                ValidateElementTextContain(p3.Description_value, "Property Book Awaiting Supply Off/NCO Appointment");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Property Book Awaiting Supply Off/NCO Appointment");
                ValidateElementText(p3.HistoryofActions_Action_Value, "DD 3161 Completed");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Property Book Awaiting Acceptance By CDC");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Auto Remarks: DD 3161 Completed");

                EnterTxt(p3.ProvideRemarksn_input_field, "Memo Certified and Accepted", "Memo Certified and Accepted");
                ClickObj(p3.MemoCertifiedandAccepted_Button, "Memo Certified and Accepted Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementTextContain(p3.CurrentStatus_value, "Property Book Awaiting Delegation Of Authority");
                ValidateElementTextContain(p3.Description_value, "Property Book Awaiting Delegation Of Authority");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Property Book Awaiting Delegation Of Authority");
                ValidateElementText(p3.HistoryofActions_Action_Value, "Memo Certified and Accepted");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Property Book Awaiting Supply Off/NCO Appointment");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Memo Certified and Accepted");

                ClickObj(p3.DA1687Complete_Button, "DA 1687 Complete Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");

                commonMethods.verifyElementDisplay(p3.SemiAnnualInventoryInitiated_Button, "Semi Annual Inventory Initiated Button");
                commonMethods.verifyElementDisplay(p3.AnnualInventoryInitiated_Button, "Annual Inventory Initiated");
                commonMethods.verifyElementDisplay(p3.CDCChangeDDFormsExpire_Button, "CDC Change/DD Forms Expire");

                ValidateElementTextContain(p3.CurrentStatus_value, "Property Book Active");
                ValidateElementTextContain(p3.Description_value, "Property Book Active");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Property Book Active");
                ValidateElementText(p3.HistoryofActions_Action_Value, "DA 1687 Complete");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Property Book Awaiting Delegation Of Authority");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Auto Remarks: DA 1687 Complete");

                ClickObj(p3.SemiAnnualInventoryInitiated_Button, "Semi Annual Inventory Initiated Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");

                ValidateElementTextContain(p3.CurrentStatus_value, "Property Book Semi-Annual Inventory In Progress");
                ValidateElementTextContain(p3.Description_value, "Property Book Semi-Annual Inventory In Progress");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Property Book Semi-Annual Inventory In Progress");
                ValidateElementText(p3.HistoryofActions_Action_Value, "Semi-Annual Inventory Initiated");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Property Book Active");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Auto Remarks: Semi-Annual Inventory Initiated");

                ClickObj(p3.SemiAnnualInventoryMemoComplete_Button, "Semi-Annual Inventory Memo Complete Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");

                commonMethods.verifyElementDisplay(p3.SemiAnnualInventoryInitiated_Button, "Semi Annual Inventory Initiated Button");
                commonMethods.verifyElementDisplay(p3.AnnualInventoryInitiated_Button, "Annual Inventory Initiated");
                commonMethods.verifyElementDisplay(p3.CDCChangeDDFormsExpire_Button, "CDC Change/DD Forms Expire");

                ValidateElementTextContain(p3.CurrentStatus_value, "Property Book Active");
                ValidateElementTextContain(p3.Description_value, "Property Book Active");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Property Book Active");
                ValidateElementText(p3.HistoryofActions_Action_Value, "Semi-Annual Inventory Memo Complete");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Property Book Semi-Annual Inventory In Progress");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Auto Remarks: Semi-Annual Inventory Memo Complete");

                ClickObj(p3.CDCChangeDDFormsExpire_Button, "CDC Change/DD Forms Expire");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");

                ValidateElementTextContain(p3.CurrentStatus_value, "Property Book Closed");
                ValidateElementTextContain(p3.Description_value, "Property Book Closed");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Property Book Closed");
                ValidateElementText(p3.HistoryofActions_Action_Value, "CDC Change/DD Forms Expire");
                ValidateElementText(p3.HistoryofActions_PreviousStatus_Value, "Property Book Active");
                ValidateElementText(p3.HistoryofActions_Note_Value, "Auto Remarks: CDC Change/DD Forms Expire");

                ClickObj(p3.NewCDCAdded_Button, "New CDC Added");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Property Book Awaiting Acceptance By CDC");
                ValidateElementText(p3.Description_value, "Property Book Awaiting Acceptance By CDC");

                commonMethods.verifyElementDisplay(p3.DD3161Completed_Button, "DD 3161 Completed Button");

            }));
        }


    }
}
