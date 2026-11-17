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
    public class POCAdmin33000RePointOfContactCancelledScenario2Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public POCAdmin33000RePointOfContactCancelledScenario2Steps(IWebDriver driver) : base(driver)
        {

        }


        public void POCAdmin33000RePointOfContactCancelledScenario2()
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
                ClickObj(p1.POCManagement_Blade, "POC Management (POC) blade");
                WaitForElement(p1.Refresh_Button);
                ClickObj(p1.Search_Btn, "Search Btn");
                commonMethods.AddPointOfContact();
                ClickObj(p1.ActivePointofContact_Link, "Active Point of Contact");
                ClickObj(p2.ShowHide_Filters, "Show/Hide Filter");
                EnterTxt(p2.DaysInCurrentStatus_Input, "1", "Entered 1");
                EnterTxt(p2.Region_Input, "NorthEast", "Entered NorthEast");
                EnterTxt(p2.Program_Input, "Virginia National Guard Counterdrug Task Force", "Entered Virginia National Guard Counterdrug Task Force");
                EnterTxt(p2.State_Input, "Virginia", "Entered Virginia");
                EnterTxt(p2.Position_Input, "STADMIN", "Entered STADMIN");
                ValidateElementText(p2.Region_Value, "NorthEast");
                ValidateElementText(p2.State_Value, "Virginia");
                ValidateElementText(p2.Program_Value, "Virginia National Guard Counterdrug Task Force");
                ValidateElementText(p2.Position_Value, "STADMIN");
                ClickObj(p2.FirstRow, "First Row");
                ValidateElementText(p3.Description_OfCurrentStatus_value, "Active Point of Contact");
                commonMethods.verifyElementDisplay(p3.InActivatePOC_Button, "In-Activate POC");
                commonMethods.verifyElementDisplay(p3.CancelPOC_Button, "Cancel POC Button");
                EnterTxt(p3.ProvideRemarksn_input_field, "Cancel POC", "Entered Cancel POC");
                ClickObj(p3.CancelPOC_Button, "Cancel POC Button");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Cancelled");
                ValidateElementText(p3.Description_OfCurrentStatus_value, "Point of Contact Cancelled");

            }));
        }


    }
}
