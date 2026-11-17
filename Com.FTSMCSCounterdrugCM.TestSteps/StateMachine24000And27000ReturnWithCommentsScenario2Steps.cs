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
    public class StateMachine24000And27000ReturnWithCommentsScenario2Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine24000And27000ReturnWithCommentsScenario2Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine24000And27000ReturnWithCommentsScenario2()
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

                List<string> textsToSelect = new List<string> { "Virginia", "Washington", "West Virginia" };


                ClickObj(landingpage.Applications_Dropdown, "Application Dropdown");
                moveToElement(landingpage.Counterdrug_Dropdown_Option);
                moveToElement(landingpage.CaseManagement_Dropdown_Option);
                ClickObj(landingpage.CaseManagement_Dropdown_Option, "Case Management Dropdown Option");
                //SwitchToNewWindow();
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                waitForLoadingBarToCompleteinSeconds();
                JsClick(landingpage.DeveloperTools_Dropdown, "Developer Tools Down Arrow Icon");
                JsMoveTo(landingpage.FMT_Dropdown_Option);
                JsMoveTo(landingpage.CreateFMACase_Dropdown_Option);
                JsClick(landingpage.CreateFMACase_Dropdown_Option, "Create FMA Case Dropdown Option");
                //SwitchToNewWindow();
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                ClickObj(landingpage.PopUp_Ok_Btn, "Pop up OK Button");
                WaitForMessageToAppear(landingpage.successful_message, "Success - FMA Cases Created.");
                ClickObj(p1.FinancialManagementTool_Blade, "Financial Management Tool (FMT)");
                ClickObj(p1.FYTargetsOpen_Link, "FY Targets Open link");
                commonMethods.ClickHighestFY(driver, p2.FY_List);
                ClickObj(p3.AddBOSTarget_btn, "Add BOS Targets");
                //SelectMultipleCheckboxOptions(p3.PopUp_DropDownArrow, p3.DropdDownOptions, textsToSelect);
                SelectFromCustomDropdownByText(p3.PopUp_DropDownArrow, p3.DropdDownOptions, "West Virginia");
                ClickObj(p3.PopUp_DropDownArrow2, "PopUp Drop Down Arrow 2");
                string BudgetReleaseDropdownCapturedText = GetElementText(p3.DropdDownOption, "Dropdown Text");
                TestContext.Progress.WriteLine("Budget Release Dropdown Captured Text is: " + BudgetReleaseDropdownCapturedText);
                ClickObj(p3.PopUp_DropDownArrow2, "PopUp Drop Down Arrow 2");
                commonMethods.SelectCustomTextFromDropdowncontain(p3.PopUp_DropDownArrow2, p3.DropdDownOptions, "Budget Release");
                ClickObj(p3.PopUp_Save_Btn, "PopUp Save button");
                ClickObj(p3.PopUp_Cancel_Btn, "PopUp Cancel button");
                ValidateElementText(p3.CurrentStatus_value, "Open To States");
                EnterTxt(p3.ProvideRemarksn_input_field, BudgetReleaseDropdownCapturedText, BudgetReleaseDropdownCapturedText);
                commonMethods.ClickMatchingReviseButton(BudgetReleaseDropdownCapturedText);
                ClickObj(p3.PopUp_Yes_Btn, "Pop Up Yes Button");
                string CapturedReleaseNumber = commonMethods.GetBudgetReleaseNumber(BudgetReleaseDropdownCapturedText);
                TestContext.Progress.WriteLine("Captured Release Number: " + CapturedReleaseNumber);
                ValidateElementText(p3.CurrentStatus_value, $"In Draft - Budget Release {CapturedReleaseNumber}");
                commonMethods.ClickManageTargetsTab(CapturedReleaseNumber);
                int GeneratedRandomNumber = GenerateRandomNumberInt(6);
                TestContext.Progress.WriteLine(" Generated Random Number : " + GeneratedRandomNumber);
                string expectedTotal = commonMethods.EnterAmountInAllNumberFields(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//input[@data-value-type='number']"), GeneratedRandomNumber);
                TestContext.Progress.WriteLine("Expected Total: " + expectedTotal);
                ClickObj(p3.PopUp_Save_Btn, "PopUp Save button");

                string CapturedTotalFunding = GetElementText(p3.TotalFunding_Value, "Total Funding");
                TestContext.Progress.WriteLine("Captured Total Funding: " + CapturedTotalFunding);

                string CapturedTotalTarget = GetElementText(p3.TotalTarget_Value, "Total Target");
                TestContext.Progress.WriteLine("Captured Total Target: " + CapturedTotalTarget);

                string NetFundingToTargetDIFF = commonMethods.GetNetFundingDifference(CapturedTotalFunding, CapturedTotalTarget);
                TestContext.Progress.WriteLine("Net Funding ToTarget DIFF: " + NetFundingToTargetDIFF);
                ValidateElementText(p3.FundingToTargetDIFF_Value, NetFundingToTargetDIFF);
                ClickObj(p3.ManageFMA_Tab, "Manage FMA");
                ClickObj(p3.Open_Btn, "Open Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ClickObj(p1.CommandCenter_Blade_Rotated, "Going Back to Command Center");
                ClickObj(p1.BOSInDraft_Link, "BOS In Draft Link");
                ClickObj(p2.ShowHide_Filters, "Show/Hide Filters");
                EnterTxt(p2.DaysInCurrentStatus_Input, "1", "1");
                EnterTxt(p2.State_Input, "West Virginia", "West Virginia");
                ClickObj(p2.FirstRow, "First Row");

                EnterTxt(p3.ProvideRemarksn_input_field, "Submit for review", "Submit for review");
                ClickObj(p3.SubmitforReview_Button, "Submit for Review Button");
                ClickObj(p3.PopUp_Yes2_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Pending CDC Review");

                ClickObj(p3.SubmittoRC_Button, "Submit to RC");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Pending RC Review");

                ClickObj(p3.SubmitforFinanceReview_Button, "Submit for Finance Review");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Pending Finance Review");

                EnterTxt(p3.ProvideRemarksn_input_field, "Return With Comments", "Return With Comments");
                ClickObj(p3.ReturnWithComments_Button, "Return With Comments");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Returned to State");

                ClickObj(p3.SubmitforReview_Button, "Submit for Review");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Pending CDC Review");
            }));
        }



    }
}
