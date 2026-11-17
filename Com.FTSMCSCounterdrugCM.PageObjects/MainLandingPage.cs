using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrug.Tests.Com.FTSMCSCounterDrug.PageObjects
{
    public class MainLandingPage : SetUp
    {
        public IWebDriver ldriver;

        public MainLandingPage(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        // --- DYNAMIC ELEMENTS (The New Selenium 4 Way) ---

        public IWebElement Applications_Dropdown => ldriver.FindElement(By.XPath("//div[@id='smoothmenu1']//ul//li//a"));

        public IWebElement DeveloperTools_Dropdown => ldriver.FindElement(By.XPath("//li[@class='dropdown']//a[@aria-label='Developer Tools']"));

        public IWebElement Counterdrug_Dropdown_Option => ldriver.FindElement(By.XPath("//div[@id='smoothmenu1']//a[text()='Counterdrug']"));

        public IWebElement FMT_Dropdown_Option => ldriver.FindElement(By.XPath("//a[text()='FMT']"));

        public IWebElement CaseManagement_Dropdown_Option => driver.FindElement(By.XPath("//div[@id='smoothmenu1']//a[text()='Case Management']"));

        public IWebElement CreateFMACase_Dropdown_Option => ldriver.FindElement(By.XPath("//a[text()='Create FMA Case']"));

        public IWebElement eTrackerHRH_banner => ldriver.FindElement(By.XPath("//h1//a[@href='/v4/eTracker']"));

        public IWebElement CommandCenter => ldriver.FindElement(By.XPath("//*[@id='commandCenterTools-widget']/header/h2"));

        public IWebElement DropDown_UserName => ldriver.FindElement(By.XPath("//ul[@class='dropdown-menu']//a[@class='myAccountUserCollapse']"));

        public IWebElement successful_message => ldriver.FindElement(By.XPath("//div[@class='toast toast-success']//div[@class='toast-message']"));

        public IWebElement QuickLinks_RightRibbob => ldriver.FindElement(By.XPath("((//ul[@class='nav navbar-nav navbar-right'])[2]//li//a[not(contains(@class, 'node-without-children-link'))]//span)[1]"));

        public IWebElement MyProducts_RightRibbob => driver.FindElement(By.XPath("((//ul[@class='nav navbar-nav navbar-right'])[2]//li//a[not(contains(@class, 'node-without-children-link'))]//span)[2]"));

        public IWebElement UserManagement_RightRibbob => driver.FindElement(By.XPath("((//ul[@class='nav navbar-nav navbar-right'])[2]//li//a[not(contains(@class, 'node-without-children-link'))]//span)[3]"));

        public IWebElement Help_RightRibbob => driver.FindElement(By.XPath("((//ul[@class='nav navbar-nav navbar-right'])[2]//li//a[not(contains(@class, 'node-without-children-link'))]//span)[4]"));

        public IWebElement closeIconOnPopup => ldriver.FindElement(By.XPath("//button[@class='toast-close-button']"));

        public IWebElement QuickLinks_DropDown => ldriver.FindElement(By.XPath("//ul[@class='nav navbar-nav']//li//*[contains(text(),'Quick Links')]"));

        public IWebElement Safety_Option => ldriver.FindElement(By.XPath("(//ul[contains(@class,'dropdown-menu')]//li/a[contains(text(),'Safety')])[1]"));

        public IWebElement CAP_Option => ldriver.FindElement(By.XPath("(//ul[contains(@class,'dropdown-menu')]//li/a[contains(text(),'CAP')])[2]"));

        public IWebElement CAPQC_Option => ldriver.FindElement(By.XPath("(//ul[contains(@class,'dropdown-menu')]//li/a[contains(text(),'CAP QC')])"));

        public IWebElement AddSafetyIncident_Option => ldriver.FindElement(By.XPath("(//ul[contains(@class,'dropdown-menu')]//li/a[contains(text(),' Add Safety Incident')])"));

        public IWebElement AddSafetyHazard_Option => ldriver.FindElement(By.XPath("(//ul[contains(@class,'dropdown-menu')]//li/a[contains(text(),' Add Safety Hazard')])"));

        public IWebElement AddPersonnel_Option => ldriver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//i[@aria-label='Add Personnel ']"));

        public IWebElement RequestNewAgency_Option => ldriver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//i[@aria-label='Request New Agency ']"));

        public IWebElement TurnInFunds_Option => ldriver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//i[@aria-label='Turn In Funds ']"));

        public IWebElement RequestFunds_Option => driver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//i[@aria-label='Request Funding ']"));

        public IWebElement CreateASR_Option => ldriver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//i[@aria-label='Create ASR ']"));

        public IWebElement CreateASRMission_Option => ldriver.FindElement(By.XPath("//ul[contains(@class,'dropdown-menu')]//i[@aria-label='Create ASR Mission ']"));

        public IWebElement PopUp_Ok_Btn => ldriver.FindElement(By.XPath("//div[@class='modal-content']//button[@aria-label='OK']"));

        public IWebElement PopUp_Text => ldriver.FindElement(By.XPath("//div[@class='modal-content']//div[contains(@class,'modal-body') or contains(@class,'bootbox-body')]"));

        // --- ELEMENT LISTS ---
        public IList<IWebElement> Right_Ribbon_Menu => ldriver.FindElements(By.XPath("(//ul[@class='nav navbar-nav navbar-right'])[2]//li//a[not(contains(@class, 'node-without-children-link'))]//span"));

        // --- LOCATOR STRATEGIES ---
        public By redPopupErrorMessage_locator = By.XPath("//div[@class='toast toast-error']//div[@class='toast-message']");

        public By redPopUpCloseBtn_locator = By.XPath("//button[@class='toast-close-button']");
    }
}