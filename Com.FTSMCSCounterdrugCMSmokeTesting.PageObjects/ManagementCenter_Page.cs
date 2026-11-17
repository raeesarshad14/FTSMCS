using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects
{
    public class ManagementCenter_Page : SetUp
    {
        public IWebDriver ldriver;
        public ManagementCenter_Page(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }
        public By ManagementBlade =>
        By.XPath("//div[@data-jsobject='WorkBuckets.WbHierarchy']//ancestor::div[contains(@class, 'command-center-component panel-default')]|//div[@id='commandCenterTools-widget']//i[@*='Management Center Icon']");

        public By MyCDCActionsBlade => By.XPath("//div[@data-jsobject='WorkBuckets.WbHierarchy']//ancestor::div[contains(@class, 'command-center-component panel-default')]|//div[@id='commandCenterTools-widget']//i[@*='Management Center Icon']");

        public By ManagementBlade_Pilot_Icon =>
            By.XPath("//div[@data-jsobject='WorkBuckets.WbHierarchy']//ancestor::div[contains(@class, 'command-center-component panel-default')]|//div[@id='commandCenterTools-widget']//i[@*='Management Center (Pilot) Icon']");

        public IWebElement blade_ManagementCenter =>
            ldriver.FindElement(By.XPath("//div[@data-jsobject='WorkBuckets.WbHierarchy']//ancestor::div[contains(@class, 'command-center-component panel-default')]|//div[@id='commandCenterTools-widget']//i[@*='Management Center Icon']"));

        public IWebElement blade_ManagementCenter_Pilot_Icon =>
            ldriver.FindElement(By.XPath("//div[@data-jsobject='WorkBuckets.WbHierarchy']//ancestor::div[contains(@class, 'command-center-component panel-default')]|//div[@id='commandCenterTools-widget']//i[@*='Management Center (Pilot) Icon']"));

        public IWebElement totalNumberOnPanel_WebElement =>
            ldriver.FindElement(By.XPath("//div[@class='tab-content active']//div[@class='tab-pane fade nav-panel-parent active in']//div[contains(@class,'dataTables_info') and not(contains(@style,'display: none')) and normalize-space() != '']"));

        public IList<IWebElement> parent_li_closed_node =>
            ldriver.FindElements(By.XPath("//div[@data-jsobject='WorkBuckets.WbHierarchy']//li[@class='parent_li closed-node']"));

        public IWebElement closeIconOnPopup => ldriver.FindElement(By.XPath("//button[@class='toast-close-button']"));




        public By totalNumberOnPanel2 =>
            By.XPath("//div[@class='tab-content active']//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='dataTables_info']");


        public By closeIconOnPopup_locator => By.XPath("//button[@class='toast-close-button']");

        public IList<IWebElement> ManagementCenter_List =>
            ldriver.FindElements(By.XPath("//div[@data-jsobject='WorkBuckets.WbHierarchy']//ancestor::div[contains(@class, 'command-center-component panel-default')]|//div[@id='commandCenterTools-widget']//*[contains(@*, 'Management Center')]"));

        public IList<IWebElement> MyCDCActionsBlade_List =>
            ldriver.FindElements(By.XPath("//div[@id='commandCenterTools-widget']//i[@aria-label='My CDC Actions Icon']"));













    }
}
