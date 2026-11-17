using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects
{
   public class ReportBlade_VerifyLinksLoadWithoutFailurePage : SetUp
    {
        public IWebDriver ldriver;
        public ReportBlade_VerifyLinksLoadWithoutFailurePage(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }


        public By ReportingBlade => By.XPath("//div[@data-jsobject='ReportingCenter']//ancestor::div[contains(@class, 'command-center-component panel-default')] | //div[@id='commandCenterTools-widget']//i[@*='Reporting Center Icon']");

        public By panel2_DropDown_Locater => By.XPath("//div[@id='rosterViewNavigator-widget']//span[@class='dropdown-title']");

        public By reportinglink => By.XPath("//div[@data-jsobject='ReportingCenter']//a[@class='rc-node rc-node-without-children']");

        public By servererror => By.XPath("//div[@id='header']//h1");

        public By closeIconOnPopup_locator => By.XPath("//button[@class='toast-close-button']");

        public By pop_Xbutton_locator => By.XPath("//button[@class='bootbox-close-button close']");










        public IWebElement Reporting_Blade => ldriver.FindElement(By.XPath("//div[@data-jsobject='ReportingCenter']//ancestor::div[contains(@class, 'command-center-component panel-default')] | //div[@id='commandCenterTools-widget']//i[@*='Reporting Center Icon']"));

        public IWebElement firstLinkText => ldriver.FindElement(By.XPath("//div[@data-jsobject='ReportingCenter']//a[@class='rc-node rc-node-without-children']"));

        public IWebElement closeIconOnPopup => ldriver.FindElement(By.XPath("//button[@class='toast-close-button']"));

        public IList<IWebElement> tot_links => ldriver.FindElements(By.XPath("//div[@data-jsobject='ReportingCenter']//a[@class='rc-node rc-node-without-children']"));

        public IList<IWebElement> totalTextOnFirstRow_IWebElement => ldriver.FindElements(By.XPath("(//*[@id='rosterViewNavigator']//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tr[@class='odd'])[1]//td"));

        public IList<IWebElement> totalReportingIcons_IWebElement => ldriver.FindElements(By.XPath("//ancestor::div[@class='tab-content active']//div[@class='tab-pane fade nav-panel-parent active in']//div[@id='rc-panel']//div[@class='widget-toolbar no-border']//a"));

        public IWebElement pop_Xbutton => ldriver.FindElement(By.XPath("//button[@class='bootbox-close-button close']"));

        public IWebElement panel2_DropDown_Value => ldriver.FindElement(By.XPath("(//span[@class='dropdown-title'])[1] | (//ul[@class='breadcrumb list-inline tab-list']//a)[2]"));

        public IWebElement servererror_WebElement => ldriver.FindElement(By.XPath("//div[@id='header']//h1"));

        public IWebElement ExtraWindowCancelBtn => ldriver.FindElement(By.XPath("//div[@class='bootbox modal fade in']//button[@value='Cancel']"));


        public By ExtraWindowCancelBtn_locator => By.XPath("//div[@class='bootbox modal fade in']//button[@value='Cancel']");



    }
}
