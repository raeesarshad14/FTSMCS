using iText.Layout.Element;
using iText.StyledXmlParser.Css.Selector;
using Microsoft.Testing.Platform.Extensions.Messages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System.Configuration;
using System.Linq;
using System.Net.PeerToPeer;
using System.Windows.Forms;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
//using System.Net.PeerToPeer;
//using Uptick.Tests.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps
{
    public class LoginSteps : UtilityMethods
    {

        public LoginSteps(IWebDriver driver) : base(driver)
        {

        }


        public void PerformLogin_4_Multiusers(string userName)
        {
            LoginPage loginPage = new LoginPage(driver);
            //driver.Navigate().GoToUrl(Config.URL);
            //driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WaitForElementByLocator(loginPage.UserID_locator);
            EnterTxt(loginPage.UserID, userName, "UserName");
            //EnterTxt(loginPage.Password, "abc", "Password");
            WaitForElementToBeClickable(loginPage.Submit_Btn);
            waitForLoadingBarToCompleteinSeconds();
            ClickObj(loginPage.Submit_Btn, "Submit Button");
            ClickObj(loginPage.FTSMCS_img_link, "FTSMCS Img Link");

            if (IsElementPresentJs(loginPage.Submit_Btn_locator))
            {
                ClickObj(loginPage.Submit_Btn, "Submit Button To close Session");

            }
            WaitElementToBeVisible(loginPage.Logout_Icon);
            waitForLoadingBarToCompleteinSeconds();

            //waitForLoadingBarToCompleteinSeconds();
            ////driver.Navigate().GoToUrl(Config.URL);
            //waitForLoadingBarToCompleteinSeconds();
            //ClickObj(loginPage.agree_btn, "Accept Button");
            ////driver.Navigate().GoToUrl(Config.URL);
            //TestContext.Progress.WriteLine("is this :" + isIWebElementPresent(loginPage.QA_UserID));
            //if (isIWebElementPresent(loginPage.QA_UserID))
            //{
            //    EnterTxt(loginPage.QA_UserID, userName, "UserName");
            //    ClickObj(loginPage.QA_LogIn_btn, "Login");

            //}
            //string CurrentURL = driver.Url;
            //TestContext.Progress.WriteLine("Current URL is: " + CurrentURL);

            //if (isIWebElementPresent(loginPage.agree_btn))
            //{
            //    ClickObj(loginPage.agree_btn, "Accept Button");
            //    waitForLoadingBarToCompleteinSeconds();
            //}

            //if (isIWebElementPresent(loginPage.Acknowledge_btn))
            //{
            //    ClickObj(loginPage.Acknowledge_btn, "Acknowledge_btn button");
            //}

            //if (!CurrentURL.Equals("https://qa-g1-hub.rcms.local/V4/eTracker/") && CurrentURL.Equals("https://qa-g1-hub.rcms.local/V4/Framework/PortalHome/Portal"))
            //{
            //    //driver.Navigate().GoToUrl(Config.URL);
            //    driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            //    waitForLoadingBarToCompleteinSeconds();
            //    WaitUntilWelcomeMessageDisappeard();
            //}

            ////ReportBladeValidation RBV = new ReportBladeValidation(driver);
            ////ManagementCenter_Page MCP = new ManagementCenter_Page(driver);

            //WaitUntilWelcomeMessageDisappeard();
            ////Extra window
            //// HandleExtraWindowPopupIfPresent("Extra Window", RBV.pop_Xbutton);
            //waitForLoadingBarToCompleteinSeconds();

            //////ClickObj(loginPage.advance_btn, "Advanced");
            //////ClickObj(loginPage.proceed_link_btn, "Proceed Link");
            ////WaitForElementToBeClickable(loginPage.agree_btn);
            ////ClickObj(loginPage.agree_btn, "Accept");
            ////waitForLoadingBarToCompleteinSeconds();
            ////WaitForElementToBeClickable(loginPage.UserID);
            ////EnterTxt(loginPage.UserID, userName, "UserName");
            ////WaitForElementToBeClickable(loginPage.Login_btn);
            ////waitForLoadingBarToCompleteinSeconds();
            ////ClickObj(loginPage.Login_btn, "Login");
            ////WaitUntilWelcomeMessageDisappeard();

        }

        public void PerformLogin_4_SingleUser(string username)
        {


            LoginPage loginPage = new LoginPage(driver);
            MainLandingPage landingpage = new MainLandingPage(driver);

            //driver.Navigate().GoToUrl(Config.URL);
            //driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WaitForElementByLocator(loginPage.UserID_locator);
            EnterTxt(loginPage.UserID, username, "UserName");
            //EnterTxt(loginPage.Password, "pwd", "Password");
            WaitForElementToBeClickable(loginPage.Submit_Btn);
            waitForLoadingBarToCompleteinSeconds();
            ClickObj(loginPage.Submit_Btn, "Submit Button");
            ClickObj(loginPage.FTSMCS_img_link, "FTSMCS Img Link");

            if (IsElementPresentJs(loginPage.Submit_Btn_locator))
            {
                ClickObj(loginPage.Submit_Btn, "Submit Button To close Session");

            }
            WaitElementToBeVisible(loginPage.Logout_Icon);
            waitForLoadingBarToCompleteinSeconds();

            ClickObj(landingpage.Applications_Dropdown, "Application Dropdown");
            moveToElement(landingpage.Counterdrug_Dropdown_Option);
            moveToElement(landingpage.CaseManagement_Dropdown_Option);
            ClickObj(landingpage.CaseManagement_Dropdown_Option, "Case Management Dropdown Option");
            //SwitchToNewWindow();
            pauseExecution(2000);
            waitForLoadingBarToCompleteinSeconds();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            waitForLoadingBarToCompleteinSeconds();
        }
    }
}
