using NUnit.Framework;
using OpenQA.Selenium;
using Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps
{
    public class StateMachine17000CancelViaProjectedScneario2Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //https://tibertrack.tibercreek.net/V2/dynamicdata/Test%20Case%20Management/Test%20Case%20Management/12302
        public StateMachine17000CancelViaProjectedScneario2Steps(IWebDriver driver) : base(driver)
        {

        }

        public string randomComment;
        public string randomAmount;

        public void StateMachine17000CancelViaProjectedScneario2()
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
                EnterTxt(p2.Branch_Input, "ANG", "ANG");
                ClickObj(p2.FirstRow, "First Row");

                string CapturedText_FullName_OnPanel3 = GetElementText(p3.FullName_Value, "Full Name Value");
                TestContext.Progress.WriteLine("Captured Text FullName On Panel3: " + CapturedText_FullName_OnPanel3);

                AddReimbursementUsingOrderDates();

                ClickObj(p3.ProjectedPersonnelReimbursementssection_Refresh, "Projected Personnel Reimbursements section Refresh");
                ClickObj(p3.ProjectedPersonnelReimbursementssection_ShowHide_Filters, "Projected Personnel Reimbursements section Show/Hide Filters");
                EnterTxt(p3.ProjectedPersonnelReimbursementssection_Comments_Input, randomComment, randomComment);
                moveToElement(p3.ProjectedPersonnelReimbursementssection_Comments_Value);
                verifyElementText(p3.ProjectedPersonnelReimbursementssection_Comments_Value, randomComment);
                verifyElementText(p3.ProjectedPersonnelReimbursementssection_Amount_Value, randomAmount);
                ClickObj(p1.CommandCenter_Blade_Rotated, "Command Center Going Back");
                ClickObj(p1.Reimbursements_REIM_Tab, "Reimbursements (REIM) Tab");
                pauseExecution(2000);
                ClickObj(p1.Search_Button, "Search Button");
                ClickObj(p2.ShowHide_Filters, "Show/Hide Filters");
                pauseExecution(1000);
                waitForLoadingBarToCompleteinSeconds();

                EnterTxt(p2.ReimbursementComments_Input, randomComment, randomComment);

                ValidateElementText(p2.ReimbursementType_Value, "AT");

                ValidateElementText(p2.FullName_Value, CapturedText_FullName_OnPanel3);

                ValidateElementText(p2.DaysInCurrentStatus_Value, "1");

                ValidateElementText(p2.ReimbursementComments_Value, randomComment);

                ValidateElementText(p2.ReimbursementAmountt_Value, randomAmount);

                ClickObj(p2.FirstRow, "First Row");
                ScrollAndMoveToElement(p3.Delete_Button);
                commonMethods.ValidateElementIsEnabled(p3.Delete_Button, "Delete Button");
                ClickObj(p3.UploadNewFile_btn, "Upload NewFile btn");
                UploadFileFromProjectFolder(p3.DocxFile, "Reimb-Validation");
                ValidateElementText(p3.Column_Name_value, "Test File.docx");
                ValidateElementText(p3.Column_DocumentType_value, "Validation Document Required");
                ValidateElementText(p3.CheckMarkSign_withRequiredText, "Required");
                ValidateElementText(p3.CurrentStatus_value, "Projected");
                EnterTxt(p3.ProvideRemarksn_input_field, "Delete", "Entering Delete text");
                ClickObj(p3.Delete_Button, "Delete Button");
                ClickObj(p3.PopUp_Yes_Btn, " Pop Up Yes Button");
                ValidateElementText(p3.CurrentStatus_value, "Cancel");
                ValidateElementText(p3.Therearenoactionsavailableperyourcurrentuserrole_Text, "There are no actions available per your current user role.");



            }));


        }

        public void AddReimbursementUsingOrderDates()
        {
            Panel3Page p3 = new Panel3Page(driver);

            // Go to the "Orders" tab
            ClickObj(p3.Order_Tab, "Order Tab");

            try
            {
                // Check if Order Start Date element exists and has text
                var orderStartDateElement = driver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//span[contains(., 'Current & Future Orders')]//following::td[@data-header='Order Start DT']"));
                var orderEndDateElement = driver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//span[contains(., 'Current & Future Orders')]//following::td[@data-header='Order End DT']"));

                if (orderStartDateElement.Count > 0 && !string.IsNullOrWhiteSpace(orderStartDateElement[0].Text))
                {
                    string orderStartDateText = orderStartDateElement[0].Text.Trim();
                    TestContext.Progress.WriteLine("Order Start Date Text: " + orderStartDateText);

                    string orderEndDateText = orderEndDateElement[0].Text.Trim();
                    TestContext.Progress.WriteLine("Order End Date Text: " + orderEndDateText);

                    // Parse them as DateTime (format: yyyyMMdd)
                    DateTime orderStartDate = DateTime.ParseExact(orderStartDateText, "yyyyMMdd", null);
                    DateTime orderEndDate = DateTime.ParseExact(orderEndDateText, "yyyyMMdd", null);

                    // Calculate a 6-month range between them
                    DateTime reimbursementStartDate = orderStartDate.AddMonths(6);
                    if (reimbursementStartDate > orderEndDate)
                        reimbursementStartDate = orderStartDate; // fallback if too close

                    DateTime reimbursementEndDate = reimbursementStartDate.AddMonths(6);
                    if (reimbursementEndDate > orderEndDate)
                        reimbursementEndDate = orderEndDate; // don’t exceed the end date

                    // Go to Reimbursements
                    ClickObj(orderStartDateElement[0], "Clicking to remove toolkit on reimbursement tab");
                    ClickObj(p3.Reimbursement_Tab, "Reimbursements");
                    ClickObj(p3.AddReimbursement_Btn, "Add Reimbursement Button");

                    SelectFromCustomDropdownByText(p3.ReimbursementType_Dropdown_Arrow, p3.DropdDownOptions, "AT");
                    // Format back to yyyyMMdd before sending
                    string startDateFormatted = reimbursementStartDate.ToString("yyyyMMdd");
                    TestContext.Progress.WriteLine("start Date Formatted: " + startDateFormatted);

                    string endDateFormatted = reimbursementEndDate.ToString("yyyyMMdd");
                    TestContext.Progress.WriteLine("end Date Formatted: " + endDateFormatted);

                    // Generate random amount and comment
                    randomAmount = GenerateRandomFormattedValue("$1,000.00");
                    TestContext.Progress.WriteLine("Random Amount: " + randomAmount);
                    EnterTxt(p3.Amount_Input, randomAmount, randomAmount);

                    randomComment = GenerateRandomText();
                    TestContext.Progress.WriteLine("Random Comment: " + randomComment);
                    EnterTxt(p3.Comments_Input, randomComment, randomComment);

                    // Enter Start and End Dates
                    driver.FindElement(By.XPath("(//input[@data-value-type='datetime'])[1]")).SendKeys(startDateFormatted);
                    pauseExecution(1000);
                    waitForLoadingBarToCompleteinSeconds();
                    driver.FindElement(By.XPath("(//input[@data-value-type='datetime'])[2]")).SendKeys(endDateFormatted);

                    ClickObj(p3.Save_Btn, "Save Button");
                    verifyElementText(p3.Save_Msg, "Saved Successfully");
                }
                else
                {
                    // If no start date, go to Reimbursements only
                    TestContext.Progress.WriteLine("No Order Start Date found. Navigating only to Reimbursements tab.");
                    ClickObj(p3.OrderTab_IsAmendment_Header, "Clicking to remove toolkit on reimbursement tab");
                    ClickObj(p3.Reimbursement_Tab, "Reimbursements");
                    ClickObj(p3.AddReimbursement_Btn, "Add Reimbursement Button");
                    SelectFromCustomDropdownByText(p3.ReimbursementType_Dropdown_Arrow, p3.DropdDownOptions, "AGR Operational Support");
                    SelectDateFromCalendar(p3.StateDate_Input, p3.Month_DropDown, p3.Year_DropDown, "20291031");
                    SelectDateFromCalendar(p3.EndDate_Input, p3.Month_DropDown, p3.Year_DropDown, "20300630");

                    string randomAmount = GenerateRandomFormattedValue("$1,000.00");
                    TestContext.Progress.WriteLine("Random Amount: " + randomAmount);

                    EnterTxt(p3.Amount_Input, randomAmount, randomAmount);

                    string RandomComment = GenerateRandomText();
                    TestContext.Progress.WriteLine("Random Comment: " + RandomComment);


                    EnterTxt(p3.Comments_Input, RandomComment, RandomComment);
                    ClickObj(p3.Save_Btn, "Save Button");
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("Error occurred: " + ex.Message);
                // Go to Reimbursements tab even if exception happens
                ClickObj(p3.Reimbursement_Tab, "Reimbursements");

            }
        }



















    }
}
