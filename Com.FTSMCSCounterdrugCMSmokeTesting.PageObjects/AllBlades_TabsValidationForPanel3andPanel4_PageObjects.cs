using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects
{
    public class AllBlades_TabsValidationForPanel3andPanel4_PageObjects : SetUp
    {
        public IWebDriver ldriver;
        public AllBlades_TabsValidationForPanel3andPanel4_PageObjects(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        public IWebElement panel3 =>
    ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorOne']//div[@id='entityViewNavigatorOne-widget'] | //div[@id='breadcrumbsNavigator-widget']"));

        public IWebElement panel4 =>
            ldriver.FindElement(By.XPath("//div[@id='entityViewNavigatorTwo']//div[@id='entityViewNavigatorTwo-widget']"));

        public IWebElement commandCenter =>
            ldriver.FindElement(By.XPath("//div[@id='commandCenterTools-widget']//header[@class='rotated']"));

        public IWebElement closeIconOnPopup => ldriver.FindElement(By.XPath("//button[@class='toast-close-button' or contains(@class,'bootbox-close-button close')]"));

        public IWebElement DEI_Window_WebElement =>
            ldriver.FindElement(By.XPath("//div[@class='modal - content']//h5[@class='modal-title']"));

        public IWebElement FullScreen_Expanded_WebElement =>
            ldriver.FindElement(By.XPath("//*[@id='entityViewNavigatorOne-widget']//i[@class='fa fa-compress' and @alt='Toggle Fullscreen Icon']"));







        public IList<IWebElement> allCloseAllbuttons => ldriver.FindElements(By.XPath("//div[contains(@id, 'entityViewNavigator') and not(contains(@class, 'panel-minimized'))]//i[( @aria-label='Close All Icon' or @alt='Close All Icon' ) and not(ancestor-or-self::*[contains(@style, 'display: none') or contains(@style, 'visibility: hidden')])]"));

        public IList<IWebElement> panel3_Soldier_Summery_Section => ldriver.FindElements(By.XPath("//*[@id='entityViewNavigatorOne-widget']//div[@class='panel-primary panel']//ul[@class='extra-buttons fa-lg list-inline pull-right navbar-right']//li"));

        public IList<IWebElement> panel3_Top_Header_Icons => ldriver.FindElements(By.XPath("//div[@id='entityViewNavigatorOne-widget']//ancestor::div[@class='panel-controls']//a"));





        public By locator_FirstRecordInTable => By.XPath("//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tbody//td[2]");

        public By FullScreen_Expanded_locator => By.XPath("//*[@id='entityViewNavigatorOne-widget']//i[@class='fa fa-compress' and @alt='Toggle Fullscreen Icon']");

        public By closeIconOnPopup_locator => By.XPath("//button[@class='toast-close-button' or contains(@class,'bootbox-close-button close')]");












    }
}
