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
    public class StateMachine18000And19000CanceledViaOnWaitlistScenario5Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public StateMachine18000And19000CanceledViaOnWaitlistScenario5Steps(IWebDriver driver) : base(driver)
        {

        }


        public void StateMachine18000And19000CanceledViaOnWaitlistScenario5()
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
                ClickObj(p1.ClassSchedulingUtility_Blade, "Class Scheduling Utility (CSU) Blade");
                SelectFromCustomDropdownByText(p1.DropdownArrow, p1.SearchesDropDown_Options, "CSU Course Catalog Management");
                ClickObj(p1.Search_Btn, "Search Button");
                string RandomName = GenerateRandomAlphaNumeric();
                TestContext.Progress.WriteLine("Random Name: " + RandomName);
                EnterTxt(p2.Name_Input, RandomName, RandomName);
                EnterTxt(p2.Description_Input, RandomName, RandomName);
                EnterTxt(p2.Lessons_Input, "1", "entered 1");
                EnterTxt(p2.Hours_Input, "2", "entered 2");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p1.SearchesDropDown_Options, "Alaska");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p1.SearchesDropDown_Options, "Analysis");
                ClickObj(p2.IsNGBSponsored_No_CheckBox, "Is NGB Sponsored? No selected");
                ClickObj(p2.IsStateDoctrinalTraining_No_CheckBox, "Is State Doctrinal Training? No selected");
                ClickObj(p2.Add_Btn, "Add Button");
                ClickObj(p2.CreateClass_Tab, "Create Class Tab");
                ClickObj(p2.CreateNewClass_Button, "Create New Class Button");
                EnterTxt(p2.SeriesName_Input, RandomName, RandomName);
                ClickObj(p2.PopUp_Save_Btn, "Pop Up Save Button");
                ValidateElementText(p4.CurrentStatus_value, "Class Created");
                ValidateElementText(p4.Description_value, "Create Created - The Administrator/Instructor may Open the Class for Registration, or Cancel the Class.");
                ClickObj(p4.ManageClassLessons_Modify_Icon, "Modify Edit Icon Under Manage Class Lessons");

                string StartDate = GetCurrentDateInCustomFormat("MMddyyyy");
                TestContext.Progress.WriteLine("Start Date is: " + StartDate);

                string EndDate = GetNextDayDate("MMddyyyy");
                TestContext.Progress.WriteLine("End Date  is: " + EndDate);

                SelectFromCustomDropdownByText(p4.Dropdown_Arrow_3, p1.SearchesDropDown_Options, "SMITH JOHN A");
                SelectDateFromCalendarByLocator(p4.Calendar_1, p4.monthDropdown_Arrow_ByLocator, p4.YearDropdown_Arrow_ByLocator, StartDate);
                SelectFromCustomDropdownByText(p4.Dropdown_Arrow_1, p1.SearchesDropDown_Options, "0500");
                EnterTxt(p4.ManageClassLessons_Remarks_Input, RandomName, RandomName);
                SelectDateFromCalendarByLocator(p4.Calendar_2, p4.monthDropdown_Arrow_ByLocator, p4.YearDropdown_Arrow_ByLocator, EndDate);
                SelectFromCustomDropdownByText(p4.Dropdown_Arrow_2, p1.SearchesDropDown_Options, "0500");
                SelectFromCustomDropdownByText(p4.Dropdown_Arrow_4, p1.SearchesDropDown_Options, "Online Class AAR");
                ClickObj(p4.Save_Btn, "Manage Class Lessons Save Button");

                string StartDateValidation = GetCurrentDateInCustomFormat("yyyyMMdd");
                TestContext.Progress.WriteLine("Start Date Validation is: " + StartDateValidation);

                string EndDateValidation = GetNextDayDate("yyyyMMdd");
                TestContext.Progress.WriteLine("End Date Validation  is: " + EndDateValidation);
                ValidateElementText(p4.Name_TableData, "Lesson 1");
                ValidateElementText(p4.StartDT_TableData, StartDateValidation);
                ValidateElementText(p4.StartTime_TableData, "0500");
                ValidateElementText(p4.EndDT_TableData, EndDateValidation);
                ValidateElementText(p4.EndTime_TableData, "0500");
                ValidateElementText(p4.Remarks_TableData, RandomName);
                ValidateElementText(p4.Instructors_TableData, "SMITH JOHN A");
                ValidateElementText(p4.Assessment_TableData, "Online Class AAR");

                ClickObj(p4.ManageClassFacility_Facility_Icon, "Manage Class Facility section Edit");
                SelectFromCustomDropdownByText(p4.ManageClassFacility_Facility_DropdownArrow, p1.SearchesDropDown_Options, "Location 1");
                ClickObj(p4.Save_Btn, "Manage Class Facility Save Button");
                ClickObj(p4.OpenClassforRegistration_Button, "Open Class for Registration Button");
                ClickObj(p4.PopUp_Yes2_Btn, "PopUp_Yes_Btn");

                ValidateElementText(p4.CurrentStatus_value, "Opened for Registration");
                ValidateElementText(p4.Description_value, "Open for Registration - The Administrator/Instructor May Close the Class for Registration or Cancel the Class.");
                ValidateElementText(p4.HistoryofActions_NewStatus_Value, "Opened for Registration");
                ValidateElementText(p4.HistoryofActions_Action_Value, "Open Class for Registration");
                ValidateElementText(p4.HistoryofActions_PreviousStatus_Value, "Class Created");
                ValidateElementText(p4.HistoryofActions_Note_Value, "Auto Remarks: Open Class for Registration");

                ClickObj(p1.CommandCenter_Blade_Rotated, "Going Back to Panel 1");
                ClickObj(p1.MyCSUTrainingCenter_Blade, "My CSU Training Center");
                ClickObj(p1.ClassOpenforRegistration_Link, "Class Open for Registration link");
                ClickObj(p2.ShowHide_Filters, "Show/Hide Filter");
                EnterTxt(p2.CourseName_Input, RandomName, RandomName);
                EnterTxt(p2.DaysInCurrentStatus_Input, "1", "1");
                ClickObj(p2.FirstRow, "First Row");
                ClickObj(p4.RequestSeatForOthers_Button, "Request Seat For Others Button");
                ClickObj(p4.selectAl_CheckBox, "Select Al Check Box");
                ClickObj(p4.RequestSeatForOthers_Icon, "Request Seat For Others Icon");
                ClickObj(p4.PopUp_Ok_Btn, "Pop Up Ok Button");



                ClickObj(p1.CommandCenter_Blade_Rotated, "Going Back to Panel 1");
                ClickObj(p1.ClassSchedulingUtility_Blade, "Class Scheduling Utility (CSU) Blade");
                EnterTxt(p1.CourseName_Input, RandomName, RandomName);
                ClickObj(p1.Search_Btn, "Search Button");

                ClickObj(p2.FirstRow, "First Row on panel 2");
                ClickObj(p2.CreateClass_Tab, "Create Class Tab");
                ClickObj(p3.CreateClass_table_Row, "Create Class Table Row");
                ClickObj(p4.ClassRoster_tab, "Class Roster Tab");
                ValidateElementText(p4.ClassStatus_Column1_value, "Opened for Registration");

                ValidateElementText(p4.StudentStatus_Column1_value, "Seat Requested - Pending State Approval");

                ValidateElementText(p4.State_Column1_value, "Alaska");

                ValidateElementText(p4.LastName_Column1_value, "SMITH");

                ValidateElementText(p4.FirstName_Column1_value, "JOHN");


                ClickObj(p4.ManageClass_tab, "Manage Class tab");

                commonMethods.VerifyElementisPresent(p4.CancelClass_Button, "Cancel Class Button");
                commonMethods.VerifyElementisPresent(p4.CloseClassforRegistration_Button, "Close Class for Registration Button");
                ClickObj(p4.CloseClassforRegistration_Button, "Close Class for Registration Button");
                ClickObj(p4.PopUp_Yes2_Btn, " Pop up Ues Button");


                commonMethods.VerifyElementisPresent(p4.OpenClassforRegistration_Button, "Open Class for Registration Button");
                commonMethods.VerifyElementisPresent(p4.BeginClass_Button, "Begin Class");
                commonMethods.VerifyElementisPresent(p4.CancelClass_Button, "Cancel Class Button");
                ClickObj(p4.BeginClass_Button, "Begin Class");
                ClickObj(p4.PopUp_Yes2_Btn, " Pop up Ues Button");

                ValidateElementText(p4.CurrentStatus_value, "In-Progress");
                ValidateElementText(p4.Description_value, "In-Progress - The Administrator/Instructor can either mark the class as Complete or Cancel the class.");
                commonMethods.VerifyElementisPresent(p4.CompleteClass_Button, "Complete Class Button");
                commonMethods.VerifyElementisPresent(p4.CancelClass_Button, "Cancel Class Button");

                ValidateElementText(p4.HistoryofActions_NewStatus_Value, "In-Progress");
                ValidateElementText(p4.HistoryofActions_Action_Value, "Begin Class");
                ValidateElementText(p4.HistoryofActions_PreviousStatus_Value, "Closed for Registration");
                ValidateElementText(p4.HistoryofActions_Note_Value, "Auto Remarks: Begin Class");
                ClickObj(p4.ClassRoster_tab, "Class Roster Tab");

                ValidateElementText(p4.ClassStatus_Column1_value, "In-Progress");

                ValidateElementText(p4.StudentStatus_Column1_value, "Seat Requested - Pending State Approval");

                ValidateElementText(p4.State_Column1_value, "Alaska");

                ValidateElementText(p4.LastName_Column1_value, "SMITH");

                ValidateElementText(p4.FirstName_Column1_value, "JOHN");

                ClickObj(p4.ClassStatus_Column1_value, "In-Progress");

                commonMethods.VerifyElementisPresent(p4.CancelorWithdraw_Button, "Cancel or Withdraw Button");
                commonMethods.VerifyElementisPresent(p4.ApproveatStateLevel_Button, "Approve at State Level Button");
                ClickObj(p4.ApproveatStateLevel_Button, "Approve at State Level Button");
                ClickObj(p4.PopUp_Yes2_Btn, " Pop up Ues Button");

                ValidateElementText(p4.CurrentStatus_value, "Seat Requested - Pending NGB Approval");
                ValidateElementText(p4.Description_value, "Seat Requested - Pending NGB Approval");
                ValidateElementText(p4.HistoryofActions_NewStatus_Value, "Seat Requested - Pending NGB Approval");
                ValidateElementText(p4.HistoryofActions_Action_Value, "Approve at State Level");
                ValidateElementText(p4.HistoryofActions_PreviousStatus_Value, "Seat Requested - Pending State Approval");
                ValidateElementText(p4.HistoryofActions_Note_Value, "Auto Remarks: Approve at State Level");

                commonMethods.VerifyElementisPresent(p4.CancelorWithdraw_Button, "Cancel or Withdraw Button");
                commonMethods.VerifyElementisPresent(p4.ApproveatNGBLevel_Button, "Approve at NGB Level Button");
                ClickObj(p4.ApproveatNGBLevel_Button, "Approve at NGB Level Button");
                ClickObj(p4.PopUp_Yes2_Btn, " Pop up Ues Button");

                ValidateElementText(p4.CurrentStatus_value, "Registered for Class");
                ValidateElementText(p4.Description_value, "Registered - The Administrator/Instructor may move the student to the Waitlist, mark them as Attending or Cancel the registration. The student may Cancel their registration.");
                ValidateElementText(p4.HistoryofActions_NewStatus_Value, "Registered for Class");
                ValidateElementText(p4.HistoryofActions_Action_Value, "Approve at NGB Level");
                ValidateElementText(p4.HistoryofActions_PreviousStatus_Value, "Seat Requested - Pending NGB Approval");
                ValidateElementText(p4.HistoryofActions_Note_Value, "Auto Remarks: Approve at NGB Level");

                commonMethods.VerifyElementisPresent(p4.ConfirmAttendance_Button, "Confirm Attendance Button");
                commonMethods.VerifyElementisPresent(p4.WaitList_Button, "Wait List Button");
                commonMethods.VerifyElementisPresent(p4.CancelorWithdraw_Button, "Cancel or Withdraw Button");

                ClickObj(p4.WaitList_Button, "Wait List Button");
                ClickObj(p4.PopUp_Yes2_Btn, " Pop up Ues Button");


                ValidateElementText(p4.CurrentStatus_value, "On Waitlist For Class");
                ValidateElementText(p4.Description_value, "Waitlisted - The Administror/Instructor may move the student to Registered or Cancel the registration.The student may cancel the registration.");
                ValidateElementText(p4.HistoryofActions_NewStatus_Value, "On Waitlist For Class");
                ValidateElementText(p4.HistoryofActions_Action_Value, "Wait List");
                ValidateElementText(p4.HistoryofActions_PreviousStatus_Value, "Registered for Class");
                ValidateElementText(p4.HistoryofActions_Note_Value, "Auto Remarks: Wait List");

                commonMethods.VerifyElementisPresent(p4.CancelorWithdraw_Button, "Cancel or Withdraw Button");
                commonMethods.VerifyElementisPresent(p4.MovedtoRegistered_Button, "Moved to Registered Button");

                EnterTxt(p4.ProvideRemarksn_input_field, "Cancel Or WithDraw Text", "Cancel Or WithDraw Text");
                ClickObj(p4.CancelorWithdraw_Button, "Cancel or Withdraw Button");
                ClickObj(p4.PopUp_Yes2_Btn, " Pop up Ues Button");

                ValidateElementText(p4.CurrentStatus_value, "Withdrawn/Canceled");
                ValidateElementText(p4.Description_value, "Withdrawn/Canceled - No further action is required.");
                ValidateElementText(p4.HistoryofActions_NewStatus_Value, "Withdrawn/Canceled");
                ValidateElementText(p4.HistoryofActions_Action_Value, "Cancel or Withdraw");
                ValidateElementText(p4.HistoryofActions_PreviousStatus_Value, "On Waitlist For Class");
                ValidateElementText(p4.HistoryofActions_Note_Value, "Cancel Or WithDraw Text");

            }));

        }



    }
}
