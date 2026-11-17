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
    public class SmokeTesting_CounterdrugCMValidationSteps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public SmokeTesting_CounterdrugCMValidationSteps(IWebDriver driver) : base(driver)
        {

        }


        public void SmokeTesting_CounterdrugCMValidation()
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
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                moveToElement(landingpage.Counterdrug_Dropdown_Option);
                moveToElement(landingpage.CaseManagement_Dropdown_Option);
                ClickObj(landingpage.CaseManagement_Dropdown_Option, "Case Management Dropdown Option");
                //SwitchToNewWindow();
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                pauseExecution(2000);
                waitForLoadingBarToCompleteinSeconds();
               
                ClickObj(p1.StatePlan_Blade, "State Plan");
                WaitForElement(p1.Refresh_Button);
                commonMethods.ValidateElementDisplayed(p1.Refresh_Button, "Refresh Button");
                ClickObj(p1.StatePlan_Blade, "State Plan");
                commonMethods.VerifyElementDisappeared(p1.Refresh_Button, "Refresh Button");
               
                ClickObj(p1.ComplianceAssuranceProgram_Blade, "Compliance Assurance Program (CAP). ");
                WaitForElement(p1.Refresh_Button);
                commonMethods.ValidateElementDisplayed(p1.Refresh_Button, "Refresh Button");
                ClickObj(p1.ComplianceAssuranceProgram_Blade, "Compliance Assurance Program (CAP). ");
                commonMethods.VerifyElementDisappeared(p1.Refresh_Button, "Refresh Button");

                ClickObj(p1.AgencySupportRequestASR_Blade, "Agency Support Request (ASR) Icon");
                WaitForElement(p1.Refresh_Button);
                commonMethods.ValidateElementDisplayed(p1.Refresh_Button, "Refresh Button");
                ClickObj(p1.AgencySupportRequestASR_Blade, "Agency Support Request (ASR) Icon");
                commonMethods.VerifyElementDisappeared(p1.Refresh_Button, "Refresh Button");

                ClickObj(p1.NGCounterdrugSchoolsNGCSIcon_Blade, "NG Counterdrug Schools (NGCS)");
                WaitForElement(p1.Refresh_Button);
                commonMethods.ValidateElementDisplayed(p1.Refresh_Button, "Refresh Button");
                ClickObj(p1.NGCounterdrugSchoolsNGCSIcon_Blade, "NG Counterdrug Schools (NGCS)");
                commonMethods.VerifyElementDisappeared(p1.Refresh_Button, "Refresh Button");

                ClickObj(p1.FundingRevisions_Blade, "Funding Revisions (FR) Icon");
                WaitForElement(p1.Refresh_Button);
                commonMethods.ValidateElementDisplayed(p1.Refresh_Button, "Refresh Button");
                ClickObj(p1.FundingRevisions_Blade, "Funding Revisions (FR) Icon");
                commonMethods.VerifyElementDisappeared(p1.Refresh_Button, "Refresh Button");

                ClickObj(p1.ReimbursementsREIMIcon_Blade, "Reimbursements (REIM) Icon");
                WaitForElement(p1.Refresh_Button);
                commonMethods.ValidateElementDisplayed(p1.Refresh_Button, "Refresh Button");
                ClickObj(p1.ReimbursementsREIMIcon_Blade, "Reimbursements (REIM) Icon");
                commonMethods.VerifyElementDisappeared(p1.Refresh_Button, "Refresh Button");

                ClickObj(p1.PersonnelManagementTool_PMT_Tab, "Personnel Management Tool (PMT)");
                WaitForElement(p1.Refresh_Button);
                commonMethods.ValidateElementDisplayed(p1.Refresh_Button, "Refresh Button");
                ClickObj(p1.PersonnelManagementTool_PMT_Tab, "Personnel Management Tool (PMT)");
                commonMethods.VerifyElementDisappeared(p1.Refresh_Button, "Refresh Button");



            }));
        }




    }
}
