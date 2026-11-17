using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects
{
    public class ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects : SetUp
    {
        public IWebDriver ldriver;
        public ReportingBlade_PanelExtraButtonListIconsfunctionality_PageObjects(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }


        public IWebElement ClearFilters_Enabled_IWebElement =>
    ldriver.FindElement(By.XPath("//div[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//i[@alt='Clear Filters Icon']"));

        public IWebElement ToggleSection_UnCollapsed_IWebElement =>
            ldriver.FindElement(By.XPath("//div[@id='rosterViewNavigator-widget']//li[@data-title='Toggle Section']//a"));

        public IWebElement ToggleSection_UnXpanded_IWebElement =>
            ldriver.FindElement(By.XPath("//div[@id='rosterViewNavigator-widget']//a[@class='collapse-panel collapsed' and @aria-expanded='false']"));

        public IWebElement Minimize_IWebElement =>
            ldriver.FindElement(By.XPath("//div[@id='rosterViewNavigator-widget']//a[@data-original-title='Minimize']"));

        public IWebElement FirstRecordInTable_IWebElement =>
            ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator']//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tbody//tr"));

        public IWebElement redPopUpCloseBtn_IWebElement =>
            ldriver.FindElement(By.XPath("//button[@class='toast-close-button']"));

        public IWebElement FullScreen_Expanded_IWebElement =>
            ldriver.FindElement(By.XPath("//*[@id='rosterViewNavigator']//i[@class='fa fa-compress']"));

        public IWebElement ClearFilter_Disabled_IWebElement =>
            ldriver.FindElement(By.XPath("//div[@id='rosterViewNavigator-widget']//div[@class='tab-content active']//li[@title='Clear Filters' ]//a[@style='']"));

        public IWebElement PanelTitleOnPanel2_IWebElement =>
            ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='panel-title'] | //div[@id='breadcrumbsNavigator-widget']//li[@role='menuitem' and @class='active']//a"));

        public IWebElement Panel2ShowFilter_IWebElement =>
            ldriver.FindElement(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@class='fa fa-filter']"));

        public IWebElement redPopupErrorMessage =>
            ldriver.FindElement(By.XPath("//div[@class='toast-message']"));

        public IWebElement saveReportWindow_WebElement =>
            ldriver.FindElement(By.XPath("//h5[@class='modal-title']//parent::div[@class='modal-header']//h5"));

        public IWebElement saveReportWindowCancelBtn_WebElement =>
            ldriver.FindElement(By.XPath("//div[contains(@class, 'bootbox modal fade in') or contains(@class, 'modal fade subscription_modal in')]//div[@class='modal-content']//button[@aria-label='Cancel']"));

        public IWebElement p2reportTitle_WebElement =>
            ldriver.FindElement(By.XPath("//div[@class='tab-content active']//div[@class='btn-group']//h4"));

        public IWebElement newWindowOpened_WebElement =>
            ldriver.FindElement(By.XPath("//div[contains(@class, 'bootbox modal fade in') or contains(@class, 'modal fade subscription_modal in')  ]//div[@class='modal-content']//div[@class='modal-header']//h5"));

        public IWebElement Advanced_Edit_newWindowOpened_WebElement =>
            ldriver.FindElement(By.XPath("//div[@class='bootbox modal fade in']//div[@class='modal-content']//div[@class='modal-header']//h5"));

        public IWebElement CloseBtn_WebElement =>
            ldriver.FindElement(By.XPath("//div[@class='modal-footer']//button[@aria-label='Close']"));

        public IWebElement pop_Xbutton =>
            ldriver.FindElement(By.XPath("//button[@class='bootbox-close-button close']"));

        public IWebElement AdvancedEdit_CancelBtn_WebElement =>
            ldriver.FindElement(By.XPath("//div[@class='modal-body']//button[@value='Cancel']"));

        public IWebElement P2Home_WebElement =>
            ldriver.FindElement(By.XPath("//div[@class='tab-content active']//li//a[@data-home='1']"));

        public IWebElement P2FirstInput_WebElement =>
            ldriver.FindElement(By.XPath("//div[@id='rosterViewNavigator-widget']//div//input"));

        public IWebElement totalEntries_WebElement =>
            ldriver.FindElement(By.XPath("(//*[contains(@class,'active')]//div[contains(@class,'dataTables_info')])[last()]"));

        public IWebElement panel2_DropDown_Value =>
            ldriver.FindElement(By.XPath("(//span[@class='dropdown-title'])[1]"));





        public By noDataAvailable_locator =>
    By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//td[@title='No data available in table']");

        public By FirstRecordInTable_locator => By.XPath("//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tbody//tr");

        public By FullScreen_Expanded_locator =>
            By.XPath("//*[@id='rosterViewNavigator']//i[@class='fa fa-compress']");

        public By Panel_Heading_locator =>
            By.XPath("//div[@id='rosterViewNavigator-widget']//div[@class='panel-heading']//li");

        public By PanelTitleOnPanel2_locator =>
            By.XPath("//div[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//span[@class='panel-title']");

        public By ClearFilter_Disabled_locator =>
            By.XPath("//div[@class='tab-content active']//li[@title='Clear Filters' ]//a[@style=''] | //div[@class='no-sorting grid-filter' and @style='display: block;']/ancestor::div[@id='rosterViewNavigator']");

        public By ClearFilters_Enabled_locator =>
            By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//i[@class='fa fa fa-eraser']");

        public By Nomatchingrecordsfound_locator =>
            By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//tbody//tr//td[@title='No matching records found']");

        public By redPopupErrorMessage_locator => By.XPath("//div[@class='toast toast-error']//div[@class='toast-message']");

        public By saveReportWindow_locator =>
            By.XPath("//h5[@class='modal-title']//parent::div[@class='modal-header']//h5");

        public By redPopUpCloseBtn_locator =>
            By.XPath("//button[@class='toast-close-button']");

        public By newWindowOpened_locator =>
            By.XPath("//div[@class='modal-content']//div[@class='modal-header']//h5");

        public By Advanced_Edit_newWindowOpened_locator =>
            By.XPath("//div[@class='modal-content']//div[@class='modal-header']//h5");

        public By CloseBtn_locator =>
            By.XPath("//div[@class='modal-footer']//button[@aria-label='Close']");

        public By CancelBtn_locator =>
            By.XPath("//div[@class='modal-content']//button[@aria-label='Cancel']");

        public By Advanced_Edit_CancelBtn_locator =>
            By.XPath("//div[@class='bootbox modal fade in']//div[@class='modal-content']//button[@aria-label='Cancel']");

        public By XBtn_locator =>
            By.XPath("//button[@class='bootbox-close-button close']");

        public By parentShadowRoot =>
            By.CssSelector("body > print-preview-app");

        public By toolbarDiv =>
            By.XPath("//div[@id='rosterViewNavigator-widget']//ancestor::div[@class='tab-content active']//div[@class='tab-pane fade nav-panel-parent active in']//div[@id='rc-panel']//div[@class='widget-toolbar no-border']");

        public By Minimize_locator =>
            By.XPath("//div[@id='rosterViewNavigator-widget']//a[@data-original-title='Minimize']");

        public By ToggleSection_UnCollapsed_locator =>
            By.XPath("//div[@id='rosterViewNavigator-widget']//li[@data-title='Toggle Section']//a");

        public By SearchFilterInputAppeard_Locator =>
            By.XPath("//div[@class='dataTables_scrollHeadInner'][contains(@style,'box-sizing: content-box; width:')]//table[@class='table-condensed wb-results-table common-grid scrollingTable table table-striped table-bordered table-hover dataTable no-footer']");

        public By WindowPopUp_Locator => By.XPath("//div[contains(@class, 'bootbox modal fade in') or contains(@class, 'modal fade subscription_modal in')]//div[@class='modal-content']");



        public IList<IWebElement> PanelControlIconsList =>
    ldriver.FindElements(By.XPath("//*[@id='rosterViewNavigator']//div[@class='panel-controls']//a"));

        public IList<IWebElement> Panel_Heading_IWebElement =>
            ldriver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//ul[@class='extra-buttons fa-lg list-inline pull-right navbar-right']/li"));

        public IList<IWebElement> NoOfRowsonPanel2_IWebElement =>
            ldriver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//table[contains(@id,'DataTables_Table')]//tbody//tr"));

        public IList<IWebElement> NoOfFilterSearchInput_IWebElement =>
            ldriver.FindElements(By.XPath("//div[@id='rosterViewNavigator-widget']//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='dataTables_scrollHeadInner']//input"));

        public IList<IWebElement> totalTextListonPanel2Table_IWebElement =>
            ldriver.FindElements(By.XPath("(//*[@id='rosterViewNavigator']//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//td)"));

        public IList<IWebElement> totalTextOnFirstRow_IWebElement =>
            ldriver.FindElements(By.XPath("(//*[@id='rosterViewNavigator']//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tr[@class='odd'])[1]//td"));

        public IList<IWebElement> totalSortingFilter_IWebElement =>
            ldriver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='dataTables_scrollHead']//th"));

        public IList<IWebElement> hearderRowText_IWebElement =>
            ldriver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[@class='dataTables_scrollHeadInner']//th"));

        public IList<IWebElement> totalrowsonpanel2_IWebElement =>
            ldriver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//*[contains(@id,'DataTables_Table')]/tbody/tr"));

        public IList<IWebElement> totalIcons_IWebElementList =>
            ldriver.FindElements(By.XPath("//div[@class='tab-pane fade nav-panel-parent active in']//div[2]/div[1]/div/table/thead/tr/th"));

        public IList<IWebElement> totalRows_IWebElementList =>
            ldriver.FindElements(By.XPath("//*[@id='rosterViewNavigator']//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tbody//tr"));

        public IList<IWebElement> toolBarIconsDiv_IWebElement =>
            ldriver.FindElements(By.XPath("//div[@id='rosterViewNavigator-widget']//ancestor::div[@class='tab-content active']//div[@class='tab-pane fade nav-panel-parent active in']//div[@id='rc-panel']//div[@class='widget-toolbar no-border']//a"));


    }
}
