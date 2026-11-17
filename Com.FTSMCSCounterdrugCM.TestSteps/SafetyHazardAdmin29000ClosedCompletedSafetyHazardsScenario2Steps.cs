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
    public class SafetyHazardAdmin29000ClosedCompletedSafetyHazardsScenario2Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public SafetyHazardAdmin29000ClosedCompletedSafetyHazardsScenario2Steps(IWebDriver driver) : base(driver)
        {

        }


        public void SafetyHazardAdmin29000ClosedCompletedSafetyHazardsScenario2()
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
                commonMethods.addSafetyHazred();
                ValidateElementText(p3.Phase_Header_Text, "Open");
                ValidateElementText(p3.Phase_Text, "Open");
                ValidateElementText(p3.CurrentStatus_value, "Opened Safety Hazards");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Opened Safety Hazards");
                commonMethods.verifyElementDisplay(p3.Cancel_Btn, "Cancel Button");
                commonMethods.verifyElementDisplay(p3.Complete_Btn, "Complete Button");
                EnterTxt(p3.ProvideRemarksn_input_field, "Complete", "Entered CompleteText");
                ClickObj(p3.Complete_Btn, "Complete Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Closed/Completed Safety Hazards");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Closed/Completed Safety Hazards");

            }));
        }



    }
}
