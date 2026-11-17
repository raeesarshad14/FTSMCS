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
    public class StateMachine32000TransferredEquipmentScenario1Steps : UtilityMethods
    {

        public StateMachine32000TransferredEquipmentScenario1Steps(IWebDriver driver) : base(driver)
        {

        }

        public void StateMachine32000TransferredEquipmentScenario1()
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
                WaitForElementByLocator(p1.Refresh_ByLoacator);
                WaitForElementByLocator(p1.Active_Link_locator);
                ClickObj(p1.Active_Link, "Active Link");
                verifyElementTextContains(p2.LandingPage_DropDown, "Property Book Management - Active");
                ClickObj(p2.FirstRow, "First Row");
                ClickObj(p3.PropertyBookAdministrationEquipment_Tab, "Property Book Administration Equipment Tab");
                ClickObj(p3.EquipmentSection_Add_Icon, "Equipment section Add Icon");

                string RandomDescription = GenerateRandomPhrase();
                TestContext.Progress.WriteLine("This is genrated Description: " + RandomDescription);

                string SerialNumber = GenerateRandomNumber(6);
                TestContext.Progress.WriteLine("This is Serial Number: " + SerialNumber);

                string NationalStockNumber = GenerateRandomNumber(6);
                TestContext.Progress.WriteLine("This is National Stock Number: " + NationalStockNumber);

                string LineItemNumber = GenerateRandomNumber(6);
                TestContext.Progress.WriteLine("This is Line Item Number: " + LineItemNumber);

                EnterTxt(p3.Description_Input, RandomDescription, RandomDescription);
                EnterTxt(p3.LineItemNumber_Input, LineItemNumber, LineItemNumber);
                EnterTxt(p3.NationalStockNumber_Input, NationalStockNumber, NationalStockNumber);
                EnterTxt(p3.SerialNumber_Input, SerialNumber, SerialNumber);
                EnterTxt(p3.Quantity_Input, "5", "5");
                EnterTxt(p3.QuantityUsed_Input, "5", "5");
                ClickObj(p3.Standard_Yes_CheckBox, "Standard_Yes_CheckBox");
                ClickObj(p3.Expendable_Yes_CheckBox, "Expendable_Yes_CheckBox");
                ClickObj(p3.Serviceable_Yes_CheckBox, "Serviceable_Yes_CheckBox");
                ClickObj(p3.Destroyed_Yes_CheckBox, "Destroyed_Yes_CheckBox");
                ClickObj(p3.Add_Btn, "Add Button");

                ClickTurnInByIndex(p3.LineItemNumber, LineItemNumber);
                ClickObj(p3.PopUp_Ok_btn, "Pop Up Ok btn");

                string TurninCaseCode = GetElementText(p4.TurnInCaseCode_Value, "Capturing Turnin CaseCode Value");
                TestContext.Progress.WriteLine("Captured Turnin Case Code Value is: " + TurninCaseCode);

                ValidateElementText(p4.Description_value_2, RandomDescription);
                ValidateElementText(p4.Quantity_Value, "5");
                ValidateElementText(p4.NSN_Value, NationalStockNumber);
                ValidateElementText(p4.TurninOption_Value, "TRNIN");
                ValidateElementText(p4.LIN_Value, LineItemNumber);

                ValidateElementText(p4.CurrentStatus_value, "Initiated");
                ValidateElementText(p4.Description_value, "Initiated");
                commonMethods.verifyElementDisplay(p4.OffertoOthers_Button, "Offer to Others Button");
                commonMethods.verifyElementDisplay(p4.CompleteTransfer_Button, "Complete Transfer Button");

                ClickObj(p4.OffertoOthers_Button, "Offer to Others Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes btn");

                ValidateElementText(p4.CurrentStatus_value, "Available Equipment");
                ValidateElementText(p4.Description_value, "Available Equipment");
                commonMethods.verifyElementDisplay(p4.RequestEquipment_Button, "Request Equipment Button");

                ClickObj(p4.RequestEquipment_Button, "Request Equipment Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes btn");

                ValidateElementText(p4.CurrentStatus_value, "Selected Equipment");
                ValidateElementText(p4.Description_value, "Selected Equipment");
                commonMethods.verifyElementDisplay(p4.ApproveTransfer_Button, "Approve Transfer Button");

                ClickObj(p4.ApproveTransfer_Button, "Approve Transfer Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes btn");

                ValidateElementText(p4.CurrentStatus_value, "Transferred Equipment");
                ValidateElementText(p4.Description_value, "Transferred Equipment");

            }));
        }





    }
}
