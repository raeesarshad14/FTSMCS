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
    public class SafetyIncident22000SafetyIncidentCaseCancelScenario3Steps : UtilityMethods
    {

        // Below is the URL path for this test:
        //
        public SafetyIncident22000SafetyIncidentCaseCancelScenario3Steps(IWebDriver driver) : base(driver)
        {

        }


        public void SafetyIncident22000SafetyIncidentCaseCancelScenario3()
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
                commonMethods.AddSafetyIncident();
                ValidateElementText(p3.CurrentStatus_value, "Safety Incident Case Initiated");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Safety Incident Case Initiated");
                EnterTxt(p3.ProvideRemarksn_input_field, "Cancel Case", "Entered Cancel Case Text");
                ClickObj(p3.CancelCase_Btn, "Cancel Case Button");
                ClickObj(p3.PopUp_Yes_Btn, "PopUp Yes Btn");
                ValidateElementText(p3.CurrentStatus_value, "Safety Incident Case Canceled");
                ValidateElementText(p3.HistoryofActions_NewStatus_Value, "Safety Incident Case Canceled");


            }));
        }



    }
}
