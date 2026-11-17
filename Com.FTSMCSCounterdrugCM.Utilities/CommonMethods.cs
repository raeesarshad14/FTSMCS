using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;


namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities
{
    public class CommonMethods : UtilityMethods
    {
        public IWebDriver ldriver;

        public string CapturedFullName;
        public string CapturedLast4SSN;

        public string randomComment;
        public string randomAmount;


        public CommonMethods(IWebDriver driver) : base(driver)
        {

        }

        public void VerifyText(string expectedText, string actualText)
        {
            if (expectedText.Equals(actualText))
            {
                //CaptureScreenshot(true);
                TestContext.Progress.WriteLine("✅ Captured Text Matching and Captured Text is:" + actualText);
                Reporting.successLog("✅ Captured Text Matching and Captured Text is:" + actualText);
            }
            else
            {
                //CaptureScreenshot(false);
                string message = $"❌ Captured Text is not Matching. Expected: '{expectedText}' but Actual: '{actualText}'";
                TestContext.Progress.WriteLine(message);
                Reporting.failureLog(message);
                Assert.Fail(message);
            }
        }


        public void VerifyElementDisappeared(IWebElement element, string elementDescription)
        {
            bool isPresent = isIWebElementPresent(element);

            TestContext.Progress.WriteLine($"Is {elementDescription} Present: {isPresent}");

            if (!isPresent)
            {
                string successMessage = $"✅ Passed: {elementDescription} disappeared after required action.";
                TestContext.Progress.WriteLine(successMessage);
                Reporting.successLog(successMessage);
            }
            else
            {
                string failureMessage = $"❌ Test Failed: {elementDescription} is still present after required action.";
                TestContext.Progress.WriteLine(failureMessage);
                Reporting.failureLog(failureMessage);
                Assert.Fail(failureMessage);
            }
        }
        public void VerifyElementDisappearedByLocator(By locator, string elementDescription)
        {
            bool isPresent = isElementPresent(locator);

            TestContext.Progress.WriteLine($"Is {elementDescription} Present: {isPresent}");

            if (!isPresent)
            {
                string successMessage = $"✅ Passed: {elementDescription} disappeared after required action.";
                TestContext.Progress.WriteLine(successMessage);
                Reporting.successLog(successMessage);
            }
            else
            {
                string failureMessage = $"❌ Test Failed: {elementDescription} is still present after required action.";
                TestContext.Progress.WriteLine(failureMessage);
                Reporting.failureLog(failureMessage);
                Assert.Fail(failureMessage);
            }
        }

        public void ValidateElementDisplayed(IWebElement element, string elementName)
        {
            try
            {
                ScrollAndMoveToElement(element);
                highlight_obj(element);
                if (element.Displayed)
                {
                    TestContext.Progress.WriteLine(elementName + " is displayed.");
                    Reporting.successLog(elementName + " is displayed.");
                }
                else
                {
                    TestContext.Progress.WriteLine(elementName + " is not displayed.");
                    Reporting.failureLog(elementName + " is not displayed.");
                    Assert.Fail(elementName + " is not displayed.");
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine(elementName + " check failed due to exception: " + ex.Message);
                Reporting.failureLog(elementName + " check failed due to exception: " + ex.Message);
                Assert.Fail(elementName + " check failed due to exception: " + ex.Message);
            }
        }


        public void VerifyPDFPageCountAndPageNumbering(string expectedPartialName, int expectedPageCount)
        {
            try
            {
                // ✅ Step 1: Get the download folder path
                string downloadFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DownLoad"));

                // ✅ Step 2: Get all PDF files in the folder
                FileInfo[] files = new DirectoryInfo(downloadFolder).GetFiles("*.pdf");

                // ✅ Step 3: Find the first PDF file that contains the expected partial name
                FileInfo matchingFile = files.FirstOrDefault(file =>
                    file.Name.ToLower().Contains(expectedPartialName.ToLower()) &&
                    file.Name.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase));

                TestContext.Progress.WriteLine($"Match File Name is '{matchingFile}");
                Reporting.infoLogWithSS($"Match File Name is '{matchingFile}");

                // ❌ If no matching file is found, fail the test
                if (matchingFile == null)
                {
                    TestContext.Progress.WriteLine($"❌ No PDF file found in '{downloadFolder}' matching '{expectedPartialName}'");
                    Reporting.failureLog($"❌ No PDF file found in '{downloadFolder}' matching '{expectedPartialName}'");
                    Assert.Fail($"❌ No PDF file found in '{downloadFolder}' matching '{expectedPartialName}'");
                }

                // ✅ Step 4: Copy the file to a temporary path to avoid file locking issues
                string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
                File.Copy(matchingFile.FullName, tempFilePath, true);

                // ✅ Step 5: Open the PDF using iText
                using (PdfReader reader = new PdfReader(tempFilePath))
                using (PdfDocument pdfDoc = new PdfDocument(reader))
                {
                    // ✅ Step 6: Get the total number of pages in the PDF
                    int actualPageCount = pdfDoc.GetNumberOfPages();
                    TestContext.Progress.WriteLine($"📄 Total pages in PDF: {actualPageCount}");
                    Reporting.infoLog($"📄 Total pages in PDF: {actualPageCount}");

                    // ✅ Step 7: Check if actual page count matches expected
                    if (actualPageCount == expectedPageCount)
                    {
                        string message = $"✅ Page count matched. Expected: {expectedPageCount}, Found: {actualPageCount}";
                        TestContext.Progress.WriteLine(message);
                        Reporting.successLog(message);
                    }
                    else
                    {
                        string message = $"❌ Page count mismatch. Expected: {expectedPageCount}, Found: {actualPageCount}";
                        TestContext.Progress.WriteLine(message);
                        Reporting.failureLog(message);
                        Assert.Fail(message);
                    }

                    // ✅ Step 8: Loop through each page from 2 to last and verify the page number is present in the text
                    for (int i = 2; i <= actualPageCount; i++)
                    {
                        string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                        TestContext.Progress.WriteLine($"Page Number Capture: {pageText}");
                        Reporting.infoLog($"Page Number Capture: {pageText}");

                        // ❌ Check if the actual page contains the expected page number (as text)
                        if (!pageText.Contains(i.ToString()))
                        {
                            TestContext.Progress.WriteLine($"❌ Page number '{i}' not found on page {i}.");
                            Reporting.infoLog($"❌ Page number '{i}' not found on page {i}.");
                            Assert.Fail($"❌ Page number '{i}' not found on page {i}.");
                        }
                        else
                        {
                            Reporting.successLog($"✅ Page number {i} found on page {i}");
                            TestContext.Progress.WriteLine($"✅ Page number {i} found on page {i}");
                        }
                    }
                    // ✅ All checks passed
                    TestContext.Progress.WriteLine($"✅ PDF page count and page numbering verified.");
                    Reporting.successLog($"✅ PDF page count and page numbering verified.");
                }

            }
            catch (Exception ex)
            {
                // ❌ Log and fail in case of any exception
                TestContext.Progress.WriteLine("❌ Exception during PDF check: " + ex.Message);
                Reporting.failureLog("❌ Exception during PDF check: " + ex.Message);
                Assert.Fail("❌ Exception during PDF check: " + ex.Message);
            }
        }

        public void Logout()
        {

            LogoutPage logoutPage = new LogoutPage(driver);
            try
            {
                ClickObj(logoutPage.logOut, "Log out");
                TestContext.Progress.WriteLine("✅ Successfully logged out.");
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("❌ Error during logout: " + ex.Message);
                throw;
            }
        }



        public void VerifyElementisPresent(IWebElement element, string elementDescription)
        {
            bool isPresent = isIWebElementPresent(element);

            TestContext.Progress.WriteLine($"Is {elementDescription} Present: {isPresent}");

            if (isPresent)
            {
                string successMessage = $"✅ Passed: {elementDescription} is present";
                TestContext.Progress.WriteLine(successMessage);
                Reporting.successLog(successMessage);
            }
            else
            {
                string failureMessage = $"❌ Test Failed: {elementDescription} is not present";
                TestContext.Progress.WriteLine(failureMessage);
                Reporting.failureLog(failureMessage);
                Assert.Fail(failureMessage);
            }
        }

        public void ValidateElementIsDisabled(IWebElement element, string elementName)
        {
            ScrollAndMoveToElement(element);

            bool isPresent = isIWebElementPresent(element);
            bool isEnabled = IsElementEnabled(element);

            // Fail if not present
            if (!isPresent)
            {
                TestContext.Progress.WriteLine($"{elementName} is NOT present on the page.");
                Reporting.failureLog($"{elementName} is NOT present on the page.");
                Assert.Fail($"{elementName} is NOT present.");
            }

            // Fail if enabled (should be disabled)
            if (isEnabled)
            {
                TestContext.Progress.WriteLine($"{elementName} should be DISABLED but is ENABLED.");
                Reporting.failureLog($"{elementName} should be DISABLED but is ENABLED.");
                Assert.Fail($"{elementName} should be DISABLED.");
            }

            // Pass
            Reporting.successLog($"{elementName} is present and DISABLED as expected.");
            TestContext.Progress.WriteLine($"{elementName} is present and disabled.");
        }


        public void ValidateElementIsEnabled(IWebElement element, string elementName)
        {
            moveToElement(element);

            bool isPresent = isIWebElementPresent(element);
            bool isEnabled = IsElementEnabled(element);

            // Fail if element is NOT present
            if (!isPresent)
            {
                TestContext.Progress.WriteLine($"{elementName} is NOT present on the page.");
                Reporting.failureLog($"{elementName} is NOT present on the page.");
                Assert.Fail($"{elementName} is NOT present.");
            }

            // Fail if element is present BUT disabled
            if (!isEnabled)
            {
                TestContext.Progress.WriteLine($"{elementName} should be ENABLED but is DISABLED.");
                Reporting.failureLog($"{elementName} should be ENABLED but is DISABLED.");
                Assert.Fail($"{elementName} should be ENABLED.");
            }

            // Pass
            Reporting.successLog($"{elementName} is present and ENABLED as expected.");
            TestContext.Progress.WriteLine($"{elementName} is present and enabled.");
        }



        public bool WaitForElementToAppear(IWebElement element, string elementName)
        {
            int maxWaitSeconds = 3;
            int count = 0;

            while (count < maxWaitSeconds)
            {
                if (element.Displayed)
                {
                    TestContext.Progress.WriteLine($"{elementName} appeared successfully.");
                    Reporting.successLog($"{elementName} appeared successfully.");
                    return true;
                }

                Thread.Sleep(500);
                count++;
                TestContext.Progress.WriteLine($"Waiting for {elementName} to appear. Seconds waited: {count}");
            }

            TestContext.Progress.WriteLine($"{elementName} did not appear within {maxWaitSeconds} seconds.");
            Reporting.successLog($"{elementName} did not appear within {maxWaitSeconds} seconds.");
            Assert.Fail($"{elementName} did not appear within {maxWaitSeconds} seconds.");
            return false;
        }


        public void VerifyAllTableCellsStartWithAA(IList<IWebElement> tableCells, string expectedName)
        {
            bool hasAtLeastOneNonEmpty = false;
            List<int> nonMatchingRows = new List<int>();

            for (int i = 0; i < tableCells.Count; i++)
            {
                string actualValue = tableCells[i].Text.Trim();
                ScrollAndMoveToElement(tableCells[i]);
                highlight_obj(tableCells[i]);

                if (!string.IsNullOrEmpty(actualValue))
                {
                    hasAtLeastOneNonEmpty = true;
                }

                TestContext.Progress.WriteLine($"🔍 Row {i + 1}: Cell value = \"{actualValue}\"");

                if (actualValue.IndexOf(expectedName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    TestContext.Progress.WriteLine($"✅ Row {i + 1}: Value matches expected \"{expectedName}\".");
                    Reporting.successLog($"✅ Row {i + 1}: Value matches expected \"{expectedName}\".");
                }
                else
                {
                    Reporting.failureLog($"❌ Row {i + 1}: Value does NOT match expected \"{expectedName}\".");
                    TestContext.Progress.WriteLine($"❌ Row {i + 1}: Value does NOT match expected \"{expectedName}\".");
                    nonMatchingRows.Add(i + 1); // Record row number
                }
            }

            if (!hasAtLeastOneNonEmpty)
            {
                string msg = "❌ All cells are empty — test failed. Expected at least one non-empty cell.";
                Reporting.failureLog(msg);
                TestContext.Progress.WriteLine(msg);
                Assert.Fail(msg); // Exit here — no point checking further
                return;
            }

            if (nonMatchingRows.Count == 0)
            {
                string msg = $"✅ All rows contain the expected value: \"{expectedName}\"";
                Reporting.successLog(msg);
                TestContext.Progress.WriteLine(msg);
            }
            else
            {
                string msg = $"❌ {nonMatchingRows.Count} row(s) did NOT match the expected value \"{expectedName}\". Mismatched rows: {string.Join(", ", nonMatchingRows)}";
                Reporting.failureLog(msg);
                TestContext.Progress.WriteLine(msg);
            }
        }

        public void AddPersonnelRecordToCompleteTest()
        {
            Assert.Multiple((Action)(() =>
            {
                MainLandingPage landingpage = new MainLandingPage(driver);
                Panel1Page p1 = new Panel1Page(driver);
                Panel2Page p2 = new Panel2Page(driver);

                JsClick(landingpage.QuickLinks_DropDown, "Quick Links");
                JsMoveTo(landingpage.AddPersonnel_Option);
                JsClick(landingpage.AddPersonnel_Option, "Add Personnel");

                CapturedFullName = GetElementText(p2.FullName_Value, "Capturing Full name");
                TestContext.Progress.WriteLine("Captured Full Name: " + CapturedFullName);

                CapturedLast4SSN = GetElementText(p2.Last4_Value, "Capturing Last 4 SSN");
                TestContext.Progress.WriteLine("Captured Last 4 SSN: " + CapturedLast4SSN);

                ClickObj(p2.Add_Btn, "Add Button");
                ClickObj(p2.PopUp_Ok_Btn, "Pop Up Ok Button");

            }));
        }

        public void AddCurrentAndFutureOrders()
        {
            Panel3Page p3 = new Panel3Page(driver);

            ClickObj(p3.CurrentFuture_OrdersAddIcon, "Current & Future Orders section Add Icon ");
            SelectDateFromCalendarByLocator(p3.OrderStartDT_Input, p3.monthDropdown_Arrow_ByLocator, p3.YearDropdown_Arrow_ByLocator, "12012025");
            SelectFromCustomDropdownByText(p3.TourType_Dropdown_Arrow, p3.DropdDownOptions, "ADSW TITLE 10");
            SelectDateFromCalendarByLocator(p3.OrderEndtDT_Input, p3.monthDropdown_Arrow_ByLocator, p3.YearDropdown_Arrow_ByLocator, "12122025");
            SelectFromCustomDropdownByText(p3.MissionActivity_Dropdown_Arrow, p3.DropdDownOptions, "Aerial Observation");
            SelectFromCustomDropdownByText(p3.Role_Dropdown_Arrow, p3.DropdDownOptions, "Admin Officer / NCO");
            SelectFromCustomDropdownByText(p3.ProjectCode_Dropdown_Arrow, p3.DropdDownOptions, "1295 - RINGGOLD");
            SelectFromCustomDropdownByText(p3.FundCode_Dropdown_Arrow, p3.DropdDownOptions, "32 - RINGGOLD ANG Operations & Maintentnace");
            SelectFromDropdownUingIndax(p3.ASN, 0, "Selected First Option");
            EnterTxt(p3.DutyZipCode_Dropdown_Arrow, "22193", "22193");
            ClickObj(p3.VerifyAuthority_Yes_CheckBox, "Verify Authority 32 USC 502 (f) (1) (b");
            ClickObj(p3.VerifyIAW32_Yes_CheckBox, "Verify IAW 32 USC 112");
            ClickObj(p3.VerifyAvailabilityofFunding_Yes_CheckBox, "Verify Subject To Availability of Funding");
            ClickObj(p3.Add_Btn, "Current & Future Orders Add Button");

        }

        public void CreateASR()
        {
            Assert.Multiple((Action)(() =>
            {
                MainLandingPage landingpage = new MainLandingPage(driver);
                Panel1Page p1 = new Panel1Page(driver);
                Panel2Page p2 = new Panel2Page(driver);

                JsClick(landingpage.QuickLinks_DropDown, "Quick Links");
                JsMoveTo(landingpage.CreateASR_Option);
                JsClick(landingpage.CreateASR_Option, "Create ASR");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Alaska");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Federal");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "Directorate for National Protection and Programs (US)");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "State Counterdrug");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "7403 - STATE PLANS");
                string FiscalYearstatrDate = GetFiscalYearStartAsString("MMddyyyy");
                string FiscalYearEndDate = GetFiscalYearEndAsString("MMddyyyy");
                SelectDateFromCalendarByLocator(p2.StartDate_Input, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, FiscalYearstatrDate);
                SelectDateFromCalendarByLocator(p2.EndDate_Input, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, FiscalYearEndDate);
                p2.Add_Btn.Click();
                pauseExecution(1000);
                TestContext.Progress.WriteLine("Add Button");
                WaitForMessageToAppear(p2.successful_message, "Saved Successfully");
                waitForLoadingBarToCompleteinSeconds();

            }));
        }

        public void CreateASRMission()
        {
            Assert.Multiple((Action)(() =>
            {
                MainLandingPage landingpage = new MainLandingPage(driver);
                Panel1Page p1 = new Panel1Page(driver);
                Panel2Page p2 = new Panel2Page(driver);

                JsClick(landingpage.QuickLinks_DropDown, "Quick Links");
                JsMoveTo(landingpage.CreateASRMission_Option);
                JsClick(landingpage.CreateASRMission_Option, "Create ASR Mission");

                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Alaska");
                ClickObj(p2.Dropdown_Arrow_2, "Support Year Arrow");
                SelectHighestSYOption(p2.DropDown_WebElementList);
                waitForLoadingBarToCompleteinSeconds();
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "Directorate for National Protection and Programs");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "CA NPPD");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "Aerial Reconnaissance");
                string CapturedActivityValueText = GetElementText(p2.Activity_DropDown_Value, "Activity Value Text");
                TestContext.Progress.WriteLine("Captured Activity Value Text is: " + CapturedActivityValueText);
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_6, p2.DropDown_List, "Cannabis");
                string FiscalYearstatrDate = GetFiscalYearStartAsString("MMddyyyy");
                string FiscalYearEndDate = GetFiscalYearEndAsString("MMddyyyy");
                SelectDateFromCalendarByLocator(p2.Calendar_1, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, FiscalYearstatrDate);
                SelectDateFromCalendarByLocator(p2.Calendar_2, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, FiscalYearEndDate);
                Click(p2.Add_Btn_ByLocator, "Add Button");
                pauseExecution(1000);
                TestContext.Progress.WriteLine("Add Button");
                WaitForMessageToAppearByLocator(p2.successful_message_ByLocator, "Saved Successfully");
                waitForLoadingBarToCompleteinSeconds();

            }));
        }


        public string SelectHighestSYOption(IList<IWebElement> options)
        {
            if (options == null || options.Count == 0)
            {
                TestContext.Progress.WriteLine("❌ No options available in the dropdown.");
                Reporting.failureLog("No options available in the dropdown.");
                return null;
            }

            var syOptions = options
                .Select(option => new
                {
                    Element = option,
                    Text = option.Text,
                    Value = ExtractLastNumber(option.Text)
                })
                .Where(x => x.Text.StartsWith("SY-NPPD-1") && x.Value.HasValue)
                .OrderByDescending(x => x.Value.Value)
                .FirstOrDefault();

            if (syOptions == null)
            {
                TestContext.Progress.WriteLine("❌ No valid SY-NPPD-1 options with numeric values found.");
                Reporting.failureLog("No valid SY-NPPD-1 options with numeric values found.");
                return null;
            }

            try
            {
                syOptions.Element.Click();
                waitForLoadingBarToCompleteinSeconds();
                TestContext.Progress.WriteLine($"✅ Selected highest SY-NPPD-1 option: {syOptions.Text}");
                Reporting.infoLog($"Selected highest SY-NPPD-1 option: {syOptions.Text}");
                return syOptions.Text;
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine($"❌ Failed to click on option: {syOptions.Text}. Error: {ex.Message}");
                Reporting.failureLog($"Click failed for option: {syOptions.Text}. Error: {ex.Message}");
                return null;
            }
        }

        // Extracts the last number from a string like "SY-NPPD-1-FY26-18830"
        private int? ExtractLastNumber(string text)
        {
            var parts = text.Split('-');
            if (parts.Length > 0 && int.TryParse(parts.Last(), out int number))
            {
                return number;
            }
            return null;
        }

        public void AddMissionPersonnel()
        {
            MainLandingPage landingpage = new MainLandingPage(driver);
            Panel1Page p1 = new Panel1Page(driver);
            Panel2Page p2 = new Panel2Page(driver);
            Panel3Page p3 = new Panel3Page(driver);


            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Alaska");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "SMITH JOHN A A1C");
            string FiscalYearstatrDate = GetFiscalYearStartAsString("MMddyyyy");
            string FiscalYearEndDate = GetFiscalYearEndAsString("MMddyyyy");
            SelectDateFromCalendarByLocator(p3.Calendar_5, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, FiscalYearstatrDate);
            SelectDateFromCalendarByLocator(p3.Calendar_6, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, FiscalYearEndDate);
            Click(p3.Add_Btn_ByLocator, "Add Mission Section's Add Button");
            pauseExecution(1000);
            TestContext.Progress.WriteLine("Add Mission Section's Add Button");
            WaitForMessageToAppearByLocator(p3.Save_Msg_ByLocator, "Saved Successfully");
            waitForLoadingBarToCompleteinSeconds();
            ValidateElementText(p3.PlanningTab_State_Column_Value, "Alaska");
            ValidateElementText(p3.PlanningTab_Name_Column_Value, "SMITH JOHN A");
            ValidateElementText(p3.PlanningTab_Role_Column_Value, "UnKnown");
            string FiscalYearstatrDate_yyyyMMdd_Format = GetFiscalYearStartAsString("yyyyMMdd");
            string FiscalYearEndDate_yyyyMMdd_Format = GetFiscalYearEndAsString("yyyyMMdd");
            ValidateElementText(p3.PlanningTab_StartDT_Column_Value, FiscalYearstatrDate_yyyyMMdd_Format);
            ValidateElementText(p3.PlanningTab_EndDT_Column_Value, FiscalYearEndDate_yyyyMMdd_Format);

        }

        public void AddRequestNewAgency()
        {
            Assert.Multiple((Action)(() =>
            {
                MainLandingPage landingpage = new MainLandingPage(driver);
                Panel1Page p1 = new Panel1Page(driver);
                Panel2Page p2 = new Panel2Page(driver);
                Panel3Page p3 = new Panel3Page(driver);

                string GenratedText_AgencyCode = GenerateRandomAlphaNumeric();
                TestContext.Progress.WriteLine("Genrated Text of Agency Code : " + GenratedText_AgencyCode);

                string GenratedText_RequestingAgency = GenerateRandomText(4);
                TestContext.Progress.WriteLine("Genrated Text of Requesting Agency : " + GenratedText_RequestingAgency);

                string DescriptionText = GenerateRandomPhrase();
                TestContext.Progress.WriteLine("Genrated Text of Description : " + DescriptionText);

                JsClick(landingpage.QuickLinks_DropDown, "Quick Links");
                JsMoveTo(landingpage.RequestNewAgency_Option);
                JsClick(landingpage.RequestNewAgency_Option, "Request New Agency");
                EnterTxt(p2.AgencyCode_Input, GenratedText_AgencyCode, GenratedText_AgencyCode);
                EnterTxt(p2.RequestingAgency_Input, GenratedText_RequestingAgency, GenratedText_RequestingAgency);
                EnterTxt(p2.Description_Input, DescriptionText, DescriptionText);
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "State");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Alaska");
                ClickObj(p2.Add_Btn, "Add Button");
                ValidateElementText(p3.AgencyCode_value, GenratedText_AgencyCode);
                ValidateElementText(p3.RequestingAgency_value, GenratedText_RequestingAgency);
                ValidateElementText(p3.AgencyState_value, "Alaska");
                ValidateElementText(p3.AgencyType_value, "State");
                ValidateElementText(p3.RequestingAgency2_value, GenratedText_RequestingAgency);
                ValidateElementText(p3.BasicAgencyInformation_Description, DescriptionText);
                ValidateElementText(p3.AgencyType2_value, "State");
                ValidateElementText(p3.AgencyState2_value, "Alaska");
                ValidateElementText(p3.CurrentStatus_value, "Agency Requested");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Agency Requested");

            }));
        }

        public void AddRequestNewAgencyFederal()
        {
            Assert.Multiple((Action)(() =>
            {
                MainLandingPage landingpage = new MainLandingPage(driver);
                Panel1Page p1 = new Panel1Page(driver);
                Panel2Page p2 = new Panel2Page(driver);
                Panel3Page p3 = new Panel3Page(driver);

                string GenratedText_AgencyCode = GenerateRandomAlphaNumeric();
                TestContext.Progress.WriteLine("Genrated Text of Agency Code : " + GenratedText_AgencyCode);

                string GenratedText_RequestingAgency = GenerateRandomText(4);
                TestContext.Progress.WriteLine("Genrated Text of Requesting Agency : " + GenratedText_RequestingAgency);

                string DescriptionText = GenerateRandomPhrase();
                TestContext.Progress.WriteLine("Genrated Text of Description : " + DescriptionText);

                JsClick(landingpage.QuickLinks_DropDown, "Quick Links");
                JsMoveTo(landingpage.RequestNewAgency_Option);
                JsClick(landingpage.RequestNewAgency_Option, "Request New Agency");
                EnterTxt(p2.AgencyCode_Input, GenratedText_AgencyCode, GenratedText_AgencyCode);
                EnterTxt(p2.RequestingAgency_Input, GenratedText_RequestingAgency, GenratedText_RequestingAgency);
                EnterTxt(p2.Description_Input, DescriptionText, DescriptionText);
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Federal");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "United States");
                ClickObj(p2.Add_Btn, "Add Button");
                ValidateElementText(p3.AgencyCode_value, GenratedText_AgencyCode);
                ValidateElementText(p3.RequestingAgency_value, GenratedText_RequestingAgency);
                ValidateElementText(p3.AgencyState_value, "United States");
                ValidateElementText(p3.AgencyType_value, "Federal");
                ValidateElementText(p3.RequestingAgency2_value, GenratedText_RequestingAgency);
                ValidateElementText(p3.BasicAgencyInformation_Description, DescriptionText);
                ValidateElementText(p3.AgencyType2_value, "Federal");
                ValidateElementText(p3.AgencyState2_value, "United States");
                ValidateElementText(p3.CurrentStatus_value, "Agency Requested");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Agency Requested");

            }));
        }


        public void AddSafetyIncident()
        {
            Assert.Multiple((Action)(() =>
            {
                MainLandingPage landingpage = new MainLandingPage(driver);
                Panel1Page p1 = new Panel1Page(driver);
                Panel2Page p2 = new Panel2Page(driver);
                Panel3Page p3 = new Panel3Page(driver);

                JsClick(landingpage.QuickLinks_DropDown, "Quick Links");
                JsClick(landingpage.AddSafetyIncident_Option, "Add Safety Incident");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Alaska");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "A - Property damage is $2 million or more.");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "Air Force");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "Government");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "Admin");
                SelectDateFromCalendarByLocator(p2.Calendar_1, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, "07082024");
                SelectFromCustomDropdownByText(p2.Dropdown_Arrow_6, p2.DropDown_List, "On-Duty:AT");
                ClickObj(p2.IsMissionRelated_Yes_CheckBox, " Is Mission Related Yes CheckBox");
                ClickObj(p2.IsEquipmentInvolved_Yes_CheckBox, "Is Equipment Involved Yes CheckBox");
                ClickObj(p2.HasInjuries_Yes_CheckBox, "Has Injuries Yes CheckBox");
                ClickObj(p2.AccidentPlanExercised_Yes_CheckBox, "Accident Plan Exercised Yes CheckBox");
                ClickObj(p2.IsCDAviation_Yes_CheckBox, "Is CD Aviation Yes CheckBox");
                ClickObj(p2.Add_Btn, "Add Button");
                ValidateElementText(p3.State_Value, "Alaska");
                ValidateElementText(p3.IncidentDT_Value, "20240708");
                ValidateElementText(p3.SafetyDutyType_value, "On-Duty:AT");
                ValidateElementText(p3.SafetyType_value, "Admin");
                ValidateElementText(p3.AccidentClass_value, "A - Property damage is $2 million or more.");
                VerifyRadioIsChecked(p3.HasInjuries_Yes_CheckBox, "Has Injuries?");
                VerifyRadioIsChecked(p3.IsMissionRelated_Yes_CheckBox, "Is Mission Related?");
                VerifyRadioIsChecked(p3.IsCDAviationYes_CheckBox, "Is CD Aviation?");
                VerifyRadioIsChecked(p3.AccidentPlanExercised_CheckBox, "Accident Plan Exercised?");
                VerifyRadioIsChecked(p3.IsEquipmentInvolved_CheckBox, "Is Equipment Involved?");
                ValidateElementText(p3.SafetyEquipmentBranch_value, "Air Force");
                ValidateElementText(p3.EquipmentType_value, "Government");

            }));
        }

        public void addSafetyHazred()
        {
            MainLandingPage landingpage = new MainLandingPage(driver);
            Panel1Page p1 = new Panel1Page(driver);
            Panel2Page p2 = new Panel2Page(driver);
            Panel3Page p3 = new Panel3Page(driver);

            JsClick(landingpage.QuickLinks_DropDown, "Quick Links");
            JsClick(landingpage.Safety_Option, "Safety Option");
            JsClick(landingpage.AddSafetyHazard_Option, "Add Safety Hazard");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "FY 24");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Alaska");
            SelectDateFromCalendarByLocator(p2.Calendar_1, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, "07082024");
            EnterTxt(p2.BuildingNumber_Input, "1", "1");
            EnterTxt(p2.BuildingName_Input, "abc", "abc");
            EnterTxt(p2.RoomNumber_Input, "1", "1");
            EnterTxt(p2.RoomName_Input, "xyz", "xyz");
            EnterTxt(p2.RegionorCity_Input, "north", "north");
            EnterTxt(p2.HazardDescription_Input, "Hazard Description", "Hazard Description");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "Medium");
            EnterTxt(p2.ReferenceRegulation_Input, "Reference Regulation", "Reference Regulation");
            EnterTxt(p2.CorrectiveAction_Input, "Corrective Action", "Corrective Action");
            EnterTxt(p2.WorkOrderNumber_Input, "Work Order Number", "Work Order Number");
            SelectDateFromCalendarByLocator(p2.Calendar_2, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, "11282025");
            ClickObj(p2.Save_Btn, "Save Button");
            ValidateElementText(p3.State_Value, "Alaska");
            ValidateElementText(p3.RecognitionDate_Value, "20240708");
            ValidateElementAttributeValue(p3.BuildingName_value, "abc");
            ValidateElementText(p3.HazardDescription_value, "Hazard Description");
            ValidateElementText(p3.RAC_value, "Medium");
            ValidateElementText(p3.ReferenceRegulation_value, "Reference Regulation");
            ValidateElementAttributeValue(p3.WorkOrderNumber_value, "Work Order Number");
            ValidateElementAttributeValue(p3.WorkOrderSubmissionDate_value, "20251128");
            ValidateElementAttributeValue(p3.BuildingName_value, "abc");
            ValidateElementAttributeValue(p3.BuildingNumber_value, "1");
            ValidateElementAttributeValue(p3.RegionorCity_value, "north");
            ValidateElementAttributeValue(p3.RoomName_value, "xyz");
            ValidateElementAttributeValue(p3.RoomNumber_value, "1");
            ValidateElementText(p3.CorrectiveAction_value, "Corrective Action");
            string currentdate = GetCurrentDateInCustomFormat("yyyyMMdd");
            TestContext.Progress.WriteLine("Current date is: " + currentdate);
            ValidateElementAttributeValue(p3.UpdatedDate_value, currentdate);

        }

        public void AddPointOfContact()
        {
            Panel1Page p1 = new Panel1Page(driver);
            Panel2Page p2 = new Panel2Page(driver);

            SelectFromCustomDropdownByText(p1.DropDown1_Arrow, p1.SearchesDropDown_Options, "Point of Contact Administration");
            ClickObj(p1.Search_Btn, "Search Button");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_1, p2.DropDown_List, "Virginia");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_2, p2.DropDown_List, "Virginia National Guard Counterdrug Task Force");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "State Administration");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "State Administrator");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_5, p2.DropDown_List, "SMITH JOHN A CMS");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_7, p2.DropDown_List, "NorthEast");
            string currentdate = GetCurrentDateInCustomFormat("MMddyyyy");
            SelectDateFromCalendarByLocator(p2.Calendar_1, p2.monthDropdown_Arrow_ByLocator, p2.YearDropdown_Arrow_ByLocator, currentdate);
            ClickObj(p2.Add_Btn, "Add Button");
            WaitForMessageToAppear(p2.successful_message, "Saved Successfully");
        }


        public void ClickHighestFY(IWebDriver driver, By fyColumnLocator)
        {
            // Step 1: Get all FY column cells
            var elements = driver.FindElements(fyColumnLocator);

            // Step 2: Convert text to integers
            var years = elements
                .Select(e => int.Parse(e.Text.Trim()))
                .ToList();

            // Step 3: Find the highest FY
            int highestFY = years.Max();

            // Step 4: Click the cell that matches the highest FY
            var elementToClick = driver.FindElement(
                By.XPath($"//div[@class='wb-results panel-body']//table//td[1][text()='{highestFY}']")
            );

            highlight_obj(elementToClick);
            ClickObj(elementToClick, elementToClick.Text);

        }

        public bool SelectCustomTextFromDropdowncontain(IWebElement dropdownToggle, By optionLocator, string textToSelect)
        {
            try
            {
                highlight_obj(dropdownToggle);
                dropdownToggle.Click();
                pauseExecution(500);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElements(optionLocator).Count > 0);

                var options = driver.FindElements(optionLocator);

                foreach (var option in options)
                {
                    string optionText = option.Text.Trim();

                    if (optionText.IndexOf(textToSelect, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        highlight_obj(option);
                        ScrollAndMoveToElement(option);
                        option.Click();
                        pauseExecution(500);

                        TestContext.Progress.WriteLine("Successfully selected: " + optionText);
                        Reporting.successLog("Successfully selected: " + optionText);
                        return true;
                    }
                }

                TestContext.Progress.WriteLine("No matching option found for: " + textToSelect);
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine("Dropdown selection failed: " + ex.Message);
            }

            return false;
        }

        public void ClickMatchingReviseButton(string budgetReleaseText)
        {
            // Extract number from "Budget Release 6"
            var match = Regex.Match(budgetReleaseText, @"\d+");
            if (!match.Success)
            {
                TestContext.Progress.WriteLine("No number found in Budget Release text.");
                return;
            }

            int number = int.Parse(match.Value);
            string twoDigit = number.ToString("D2");   // 6 -> 06

            string ariaLabel = $"Revise - BR{twoDigit}";

            // Build dynamic XPath
            string xpath = $"//button[@aria-label='{ariaLabel}']";

            // Find and click the button
            var reviseButton = driver.FindElement(By.XPath(xpath));

            highlight_obj(reviseButton);
            ScrollAndMoveToElement(reviseButton);
            ClickObj(reviseButton, ariaLabel);

            TestContext.Progress.WriteLine("Clicked button: " + ariaLabel);
        }

        public string GetBudgetReleaseNumber(string budgetReleaseText)
        {
            var match = Regex.Match(budgetReleaseText, @"\d+");
            if (!match.Success)
                throw new Exception("No number found in Budget Release text.");

            return match.Value;   // returns "6" or "10" etc.
        }

        public string EnterAmountInAllNumberFields(By numberInputLocator, int amountPerField)
        {
            var inputs = driver.FindElements(numberInputLocator);

            int count = inputs.Count;
            int expectedTotal = count * amountPerField;

            foreach (var input in inputs)
            {
                highlight_obj(input);
                ScrollAndMoveToElement(input);
                input.Clear();
                input.SendKeys(amountPerField.ToString());
                pauseExecution(300);
            }

            TestContext.Progress.WriteLine($"Entered {amountPerField} into {count} fields.");
            TestContext.Progress.WriteLine($"Expected Total: {expectedTotal}");

            return expectedTotal.ToString();
        }

        public void ClickManageTargetsTab(string releaseNumber)
        {
            // Build dynamic aria-label
            string ariaLabel = $"Manage Targets - Budget Release {releaseNumber}. ";

            // Build XPath
            string xpath = $"//a[@aria-label='{ariaLabel}']";

            // Find the element
            var tab = driver.FindElement(By.XPath(xpath));

            // Highlight + scroll + click
            highlight_obj(tab);
            ScrollAndMoveToElement(tab);
            tab.Click();
            pauseExecution(1000);
            waitForLoadingBarToCompleteinSeconds();

            TestContext.Progress.WriteLine("Clicked Manage Targets tab: " + ariaLabel);
        }

        public string GetNetFundingDifference(string totalFunding, string totalTarget)
        {
            // Convert UI strings → decimals
            decimal funding = decimal.Parse(totalFunding.Replace("$", "").Replace(",", "").Trim());
            decimal target = decimal.Parse(totalTarget.Replace("$", "").Replace(",", "").Trim());

            // Calculate difference
            decimal diff = funding - target;

            // Format EXACTLY like UI: $-6,586,782.00
            string formatted = diff.ToString("$#,##0.00");

            // If negative, .NET formats as -$X — we need $-X
            if (formatted.StartsWith("-$"))
            {
                formatted = "$-" + formatted.Substring(2);
            }

            return formatted;
        }

        public void AddReimbursementUsingOrderDates()
        {


            Panel3Page p3 = new Panel3Page(driver);

            // Go to the "Orders" tab
            ClickObj(p3.Order_Tab, "Order Tab");

            try
            {
                // Check if Order Start Date element exists and has text
                var orderStartDateElement = driver.FindElements(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[contains(., 'Current & Future Orders')]//following::td[@data-header='Order Start DT'])[1]"));
                var orderEndDateElement = driver.FindElements(By.XPath("(//div[@class='tab-pane fade nav-panel-parent active in']//span[contains(., 'Current & Future Orders')]//following::td[@data-header='Order End DT'])[1]"));

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
                    string endDateFormatted = reimbursementEndDate.ToString("yyyyMMdd");

                    // Generate random amount and comment
                    randomAmount = GenerateRandomFormattedValue("$1,000.00");
                    TestContext.Progress.WriteLine("Random Amount: " + randomAmount);
                    EnterTxt(p3.Amount_Input, randomAmount, randomAmount);

                    randomComment = GenerateRandomText();
                    TestContext.Progress.WriteLine("Random Comment: " + randomComment);
                    EnterTxt(p3.Comments_Input, randomComment, randomComment);

                    // Enter Start and End Dates
                    TestContext.Progress.WriteLine("Formatted start Date entered: " + startDateFormatted);
                    driver.FindElement(By.XPath("(//input[@data-value-type='datetime'])[1]")).SendKeys(startDateFormatted);
                    pauseExecution(1000);
                    waitForLoadingBarToCompleteinSeconds();
                    TestContext.Progress.WriteLine("Formatted end Date entered: " + endDateFormatted);
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

        public void ResetStatePlanReturnCloseTestData()
        {
            string connectionString = "Data Source=ftsdevdb12;Initial Catalog=CounterdrugCM;Integrated Security=True;TrustServerCertificate=True";

            string sqlQuery = @"
USE CounterdrugCM;

SET XACT_ABORT ON;
SET NOCOUNT ON;

DECLARE @spCaseID INT;
DECLARE @esmCurrentID INT;

SET @spCaseID = 63447;

SELECT @esmCurrentID = ESM.StateMachineStateID_Current
FROM casemgr.[Case] C
INNER JOIN sm.EntityStateMember ESM 
    ON C.CaseEntityStateMemberID = ESM.ID 
WHERE C.CaseID = @spCaseID;

IF @esmCurrentID <> 6001
BEGIN
    DECLARE @spBatch sm.BatchUpdateType;

    INSERT INTO @spBatch (
        EntityStateMemberID,
        StateMachineID,
        StateMachineActionID,
        StateMachineStateID_Before,
        StateMachineStateID_After,
        DateStamp,
        UserID,
        Note,
        UserName
    )
    SELECT 
        esm.ID,
        esm.StateMachineID,
        6004,
        esm.StateMachineStateID_Current,
        6001,
        GETDATE(),
        NULL,
        'Assessment Completed',
        'SYSTEM'
    FROM casemgr.[Case] c
    INNER JOIN sm.EntityStateMember esm 
        ON c.CaseEntityStateMemberID = esm.ID 
    WHERE c.CaseID = @spCaseID;

    EXEC sm.ApplyAction @spBatch;
END;

DELETE FROM CounterdrugCM.dbo.CaseStateCode
WHERE CaseID IN (
    SELECT CaseID
    FROM casemgr.[Case]
    WHERE CaseTargetID = 585
      AND CaseType_CD = '15'
);

DELETE FROM CounterdrugCM.casemgr.[Case]
WHERE CaseTargetID = 585
  AND CaseType_CD = '15';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandTimeout = 120;
                connection.Open();
                command.ExecuteNonQuery();
            }

            TestContext.Progress.WriteLine("StateMachine6000CounterdrugSPReturnClose SQL reset completed.");
        }





        public void CloseStateCounterDrugCaseIfOpened()
        {
            Panel1Page p1 = new Panel1Page(driver);
            Panel2Page p2 = new Panel2Page(driver);
            Panel3Page p3 = new Panel3Page(driver);
            Panel4Page p4 = new Panel4Page(driver);

            ClickObj(p2.ShowHide_Filters, "Show/Hide Filters");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_3, p2.DropDown_List, "2027");
            SelectFromCustomDropdownByText(p2.Dropdown_Arrow_4, p2.DropDown_List, "State Counterdrug");
            ClickUntilDescendingSort();


            var statusCells = driver.FindElements(By.XPath(
                "//div[@class='tab-pane fade nav-panel-parent active in']//tr//td[@data-header='Status']"
            ));

            foreach (var cell in statusCells)
            {
                highlight_obj(cell);
                string statusText = cell.Text.Trim();

                if (statusText.Equals("Open", StringComparison.OrdinalIgnoreCase) ||
                                statusText.Equals("Created", StringComparison.OrdinalIgnoreCase))
                {
                    highlight_obj(cell); // optional highlight
                    ClickObj(cell, "Created/or Open Case");
                    EnterTxt(p3.ProvideRemarksn_input_field, "Closing", "Closing");
                    ClickObj(p3.Cancel_Btn1, "Cancel Button");
                    ClickObj(p3.PopUp_Yes_Btn, "Pop Yp Yes Button");
                    ValidateElementText(p3.CurrentStatus_value, "Cancelled");
                    ValidateElementText(p3.Description_value, "Cancel Annual Assessment");
                    ClickObj(p1.CommandCenter_Blade_Rotated, "Going back to command center");
                    ClickObj(p1.Search_Btn, "Search Button");
                    ClickObj(p2.ShowHide_Filters, "Show/Hide Filters");
                    break;
                }
            }
        }

        public void ClickUntilDescendingSort()
        {
            // XPath for the Created Date column header
            string baseXPath = "//th[contains(@class,'results-column') and @data-headertext='Created Date']";

            // Keep clicking until the header has 'sorting_desc'
            while (true)
            {
                var header = driver.FindElement(By.XPath(baseXPath));
                string classAttr = header.GetAttribute("class");

                // If already descending, stop
                if (classAttr.Contains("results-column text-right sorting sorting_desc"))
                {
                    Console.WriteLine("Reached descending sort state.");
                    break;
                }

                // Otherwise click and wait for state change
                highlight_obj(header);
                ClickObj(header, "Arrived on Desending position");

                // Optional: small wait for UI update
                Thread.Sleep(500);
            }
        }




    }
}

