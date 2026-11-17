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
    public class POCAdmin33000ReActivatePOCScenario1Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public POCAdmin33000ReActivatePOCScenario1Steps(IWebDriver driver) : base(driver)
        {

        }


        public void POCAdmin33000ReActivatePOCScenario1()
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

                // Use the commented line only if the record is missing.
                // It is disabled because AddPointOfContact() already created the record,
                // and duplicate entries are not permitted.

                //SelectFromCustomDropdownByText(p1.DropDown1_Arrow, p1.SearchesDropDown_Options, "Point of Contact Administration");
                //ClickObj(p1.Search_Btn, "Search Button");
                // AddPointOfContact();
                ClickObj(p1.ActivePointofContact_Link, "Active Point of Contact");
                ClickObj(p2.ShowHide_Filters, "Show Hide Filters");
                EnterTxt(p2.Region_Input, "NorthEast", "Entered NorthEast Text");
                EnterTxt(p2.State_Input, "Virginia", "Entered Virginia Text");
                EnterTxt(p2.Program_Input, "Virginia National Guard Counterdrug Task Force", "Entered Virginia National Guard Counterdrug Task Force Text");
                EnterTxt(p2.ServiceMember_Input, "SMITH JOHN A", "Entered SMITH JOHN A Text");
                ValidateElementText(p2.POCStartDT_Value, "20251231");
                string CurrentDate = GetCurrentDateInCustomFormat("yyyyMMdd");
                ClickObj(p2.FirstRow, "First Row");
                ValidateElementText(p3.ServiceMember_Value, "SMITH JOHN A CMS");
                ValidateElementText(p3.POCState_Value, "Virginia");
                ValidateElementText(p3.Status_Value, "Active");
                ValidateElementText(p3.ServiceMember2_Value, "SMITH JOHN A CMS");
                ValidateElementText(p3.POCState2_Value, "Virginia");
                ValidateElementText(p3.Region_Value, "NorthEast");
                ValidateElementText(p3.Program_Value, "Virginia National Guard Counterdrug Task Force");
                ValidateElementText(p3.PositionType_Value, "Other");
                ValidateElementText(p3.Position_Value, "Personnel & Admin Section NCO");
                ValidateElementText(p3.POCStartDate_Value, "20251231");
                ValidateElementText(p3.Email_Value, "raeestest@gmail.com");
                ValidateElementText(p3.OfficePhone_Value, "5778887788");
                ValidateElementText(p3.CurrentStatus_value, "Active");
                ValidateElementText(p3.Description_OfCurrentStatus_value, "Active Point of Contact");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Active");
                commonMethods.verifyElementDisplay(p3.InActivatePOC_Button, "In-Activate POC");
                commonMethods.verifyElementDisplay(p3.CancelPOC_Button, "Cancel POC Button");
                ClickObj(p3.InActivatePOC_Button, "In-Activate POC");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "In-Active");
                ValidateElementText(p3.Description_OfCurrentStatus_value, "In-Active Point of Contact");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "In-Active");
                ClickObj(p3.ReActivatePOC_Button, "Re-Activate POC");
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Active");
                ValidateElementText(p3.Description_OfCurrentStatus_value, "Active Point of Contact");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Active");
                commonMethods.verifyElementDisplay(p3.InActivatePOC_Button, "In-Activate POC");
                commonMethods.verifyElementDisplay(p3.CancelPOC_Button, "Cancel POC Button");



            }));
        }


        public void AddPointOfContact()
        {
            Panel1Page p1 = new Panel1Page(driver);
            Panel2Page p2 = new Panel2Page(driver);

            SelectFromCustomDropdownByText(p1.DropDown1_Arrow, p1.SearchesDropDown_Options, "Point of Contact Administration");
            ClickObj(p1.Search_Btn, "Search Button");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Virginia");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Virginia National Guard Counterdrug Task Force");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "Other");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "Personnel & Admin Section NCO");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "SMITH JOHN A CMS");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_7, p2.DropDown_List, "NorthEast");
            EnterTxt(p2.OfficePhone_Input, "5778887788", "Entered 5778887788 Text");
            EnterTxt(p2.Email_Input, "raeestest@gmail.com", "Entered raeestest@gmail.com Text");
            SelectDateFromCalendarByLocator(p2.Calendar_1, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, "12312025");
            ClickObj(p2.Add_Btn, "Add Button");
            WaitForMessageToAppear(p2.successful_message, "Saved Successfully");
        }



    }
}
