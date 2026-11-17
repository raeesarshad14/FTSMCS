using NUnit.Framework;
using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.TestSteps
{
    public class AllBlades_TabsValidationForPanel3andPanel4Steps : UtilityMethods
    {

        // Below is the URL path for this test:


        public AllBlades_TabsValidationForPanel3andPanel4Steps(IWebDriver driver) : base(driver)
        {
        }

        public void ValidateTabsForFirsto4Blades()
        {

            AllBlades_TabsValidationForPanel3andPanel4(0,4);

        }

        public void ValidateTabsFor5To8Blades()
        {

            AllBlades_TabsValidationForPanel3andPanel4(5, 8);

        }

        public void ValidateTabsFor9To12Blades()
        {

            AllBlades_TabsValidationForPanel3andPanel4(9,12);

        }

        public void ValidateTabsFor13ToEndBlades()
        {

            AllBlades_TabsValidationForPanel3andPanel4(13);

        }

        /// </summary>
        /// <param name="startBladeNumber">
        /// The first blade index to validate. Default is 0.
        /// </param>
        /// <param name="endBladeNumber">
        /// The final blade index to validate. If not provided, validation continues
        /// from startBladeNumber through the last available blade.
        /// </param>
        /// <remarks>
        public void AllBlades_TabsValidationForPanel3andPanel4(int startBladeNumber = 0,int? endBladeNumber = null)
        {
            AllBlades_TabsValidationForPanel3andPanel4_PageObjects penal3And4 =
                new AllBlades_TabsValidationForPanel3andPanel4_PageObjects(driver);

            ManagementCenter_Page MCP = new ManagementCenter_Page(driver);
            Panel1Page p1 = new Panel1Page(driver);

            int totalBladeCount = MCP.ManagementCenter_List.Count;

            // If no ending number was supplied, run through the final blade.
            int lastBladeNumber = endBladeNumber ?? totalBladeCount - 1;

            if (startBladeNumber < 0)
            {
                throw new ArgumentException("startBladeNumber cannot be less than 0.");
            }

            if (lastBladeNumber >= totalBladeCount)
            {
                throw new ArgumentException(
                    $"endBladeNumber cannot be greater than {totalBladeCount - 1}. " +
                    $"Total blade count is {totalBladeCount}.");
            }

            if (startBladeNumber > lastBladeNumber)
            {
                throw new ArgumentException(
                    "startBladeNumber cannot be greater than endBladeNumber.");
            }

            Assert.Multiple((Action)(() =>
            {
                for (int BladeNumber = startBladeNumber;
                     BladeNumber <= lastBladeNumber;
                     BladeNumber++)
                {
                    IWebElement BladeElement = MCP.ManagementCenter_List[BladeNumber];

                    TestContext.Progress.WriteLine(
                        "Blade Name is: " + BladeElement.Text +
                        " and Blade number is: " + BladeNumber);

                    Reporting.infoLogWithSS(
                        "Blade Name is: " + BladeElement.Text +
                        " and Blade number is: " + BladeNumber);

                    // Expand/open Management blade if it is not already open.
                    ClickObj(BladeElement, BladeElement.Text);
                    //Below Method is is to open Parent Node if these are not already open/expand.(Get all items in a parent container, expand)
                    GetAllparentlistClosedNodeandExpand(null, MCP.parent_li_closed_node);

                    //IList<IWebElement> weblist = driver.FindElements(By.XPath("//div[contains(@class, 'command-center-component panel-default panel') and contains(@class, 'active')]//a[@class='treeitem-node wb-node wb-node-without-children']"));
                    IList<IWebElement> weblist = driver.FindElements(By.XPath("//div[contains(@class, 'command-center-component') and contains(@class, 'active')]//a[@class='treeitem-node wb-node wb-node-without-children']"));
                    TestContext.Progress.WriteLine("Total Child Links are: " + weblist.Count);
                    //Reporting.infoLog("Total Child Links are: " + weblist.Count);

                    WaitForElementToBeClickable(weblist);

                    if (weblist.Count == 0)
                    {
                        TestContext.Progress.WriteLine("Seems like Management blade was not clicked");
                        //Reporting.warningLog("Seems like Management blade was not clicked");
                        //Assert.Warn("Seems like Management blade was not clicked");
                    }

                    Assert.Multiple((Action)(() =>
                    {
                        //below loop is Clicking(expanding) each child link and and checking red pop up on panel 2.
                        for (int i = 0; i < weblist.Count; i++)
                        {
                            IWebElement ChildLists = weblist[i];
                            string itemName = GetElementText(ChildLists, "Tree items text is: " + ChildLists.Text);//Pending Review 15,274                
                            TestContext.Progress.WriteLine("I value is: " + i + " and link is: " + itemName);
                            Reporting.successLog("I value is: " + i + " and link is: " + itemName);

                            IWebElement totalCountInTree = null;
                            try
                            {
                                totalCountInTree = ChildLists.FindElement(By.TagName("span"));
                            }
                            catch (Exception e)
                            {
                            }
                            ClickObj(ChildLists, itemName);
                            // This is for Red popup handel on panel 2
                            HandleErrorPopupIfPresent_locator("I value is: " + i + " and link is: " + itemName, penal3And4.closeIconOnPopup_locator);
                            //CloseWarningPopUp();

                            //TestContext.Progress.WriteLine("Any record is available to click on panel 2: " + getElementDisplay(penal3And4.locator_FirstRecordInTable, "First Record on panel 2"));

                            if (isElementPresent(penal3And4.locator_FirstRecordInTable) == true)
                            {

                                // if child link does not have any value then it will click on this child and then jump next child.
                                if (totalCountInTree == null)
                                {
                                    TestContext.Progress.WriteLine("No Record to Click on Panel 2 for: " + itemName);
                                    Reporting.successLog("No Record to Click on Panel 2 for: " + itemName);
                                    CaptureScreenshot(true);
                                    continue;
                                }

                                // clicking on first record
                                WaitForElementToBeClickable(By.XPath("//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tbody//td[2]"));

                                By locator_FirstRecordInTable = By.XPath("//div[contains(@class,'active in')]//table[contains(@id,'DataTables_Table')]//tbody//td[2]");
                                IWebElement firstRecord = WaitForElementToBeClickable(locator_FirstRecordInTable);
                                WaitForElementToBeClickable(locator_FirstRecordInTable);
                                moveToElement(firstRecord);
                                ClickObj(firstRecord, "And Selected First record of the table which belongs to: " + itemName);
                                waitForLoadingBarToComplete();
                                //CloseWarningPopUp();
                                pauseExecution(200);

                                //new addition for becasue when clicking new record is not opening panel 3 and 4.
                                if (firstRecord.Displayed == true)
                                {
                                    TestContext.Progress.WriteLine("Record is not clickable and it is not opening panel 3 and 4");
                                    Reporting.infoLogWithSS("Record is not clickable and it is not opening panel 3 and 4");
                                    CaptureScreenshot(true);
                                    continue;
                                }

                                //checking red popup error on panel 3 and panel 4. if display then close red pop up and close panel3 and panel4 and skip this step;
                                if (IsRedPopUpPrent())
                                {
                                    HandleErrorPopupIfPresent_locator(itemName + " and I value of this link is: " + i, penal3And4.closeIconOnPopup_locator);

                                }

                                bool AreTabsPresent = isElementPresent(By.XPath("//li[@role='presentation']"));

                                if (AreTabsPresent)
                                {
                                    // below else statements are finding all the tabs and will click on all the tabs and see if any error appears or not
                                    List<IWebElement> items = new List<IWebElement>();
                                    IList<IWebElement> listofExpandTabsArrow = driver.FindElements(By.XPath("//i[@alt='Expand Tabs Icon']"));
                                    IList<IWebElement> listOfTabs = driver.FindElements(By.XPath("//li[@role='presentation']"));
                                    //IList<IWebElement> rightArrowList = driver.FindElements(By.XPath("//i[@class='fa fa-2x fa-angle-right']"));

                                    // below foreach expanding before clicking all the tabs by clicking expand arrow
                                    foreach (IWebElement expandTabArrow in listofExpandTabsArrow)
                                    {
                                        if (expandTabArrow.Displayed == true)
                                        {
                                            //targeting "a" tag from "//li[@role='presentation']" in below addrange line.
                                            //using this addrange to add collection of list which is coming from listOfTabs  
                                            items.AddRange(expandTabArrow.FindElements(By.TagName("i")));
                                            ClickObj(expandTabArrow, "And Expand Tab Arrow");
                                            //CloseWarningPopUp();
                                        }
                                    }

                                    //below foreach is clicking all the tabs and checking if red popup appears
                                    foreach (IWebElement Tab in listOfTabs)
                                    {
                                        if (Tab.Displayed == true)

                                        {
                                            // below if statement is to get class attribute which is disabled.
                                            // Becasue RMS application has some disabled tabs and we were receiving failure to click error.
                                            // Below statment is handling this situation.
                                            string tabattrubute = Tab.GetAttribute("class");
                                            if (tabattrubute.Contains("disabled"))
                                            {
                                                TestContext.Progress.WriteLine("Tab is disabled");
                                                Reporting.infoLogWithSS("Tab is disabled");
                                                //Assert.Warn("Warning message: Tab is disabled");
                                                continue;
                                            }
                                            //targeting "a" tag from "//li[@role='presentation']" in below addrange line.
                                            //using this addrange to add collection of list which is coming from listOfTabs  
                                            items.AddRange(Tab.FindElements(By.TagName("a")));
                                            string tabName = Tab.Text;
                                            moveToElement(Tab);
                                            js_ClickObj(Tab, tabName + " Which is Tab of: " + itemName + " On panel 1" + " And I value is: " + i);
                                            HandleAlert();
                                            HandleErrorPopupIfPresent_locator(itemName + " link and I value of this link is: " + i + " and Tab name is: " + tabName, penal3And4.closeIconOnPopup_locator);
                                            //CloseWarningPopUp();
                                        }

                                    }

                                }

                                // below foreach loop is finding all the close icons on panel 3 and panel 4 and clicking on them to close p3 and p4 
                                List<IWebElement> closeIconWebElementList = new List<IWebElement>();
                                IList<IWebElement> closeAllBtnListIcon = driver.FindElements(By.XPath("//i[@alt='Close All Icon' or @aria-label='Close All Icon']\r\n"));

                                foreach (IWebElement closebtn in closeAllBtnListIcon)
                                {
                                    if (closebtn.Displayed == true)
                                    {
                                        //targeting "a" tag from "//li[@role='presentation']" in below addrange line.
                                        //using this addrange to add collection of list which is coming from listOfTabs  
                                        closeIconWebElementList.AddRange(closebtn.FindElements(By.TagName("i")));
                                        ClickObj(closebtn, "on Close All Icon Button");
                                        //CloseWarningPopUp();
                                    }
                                }


                                TestContext.Progress.WriteLine("Is command center in rotating Position?: " + isIWebElementPresent(penal3And4.commandCenter));
                                // going back to panel 1
                                if (isIWebElementPresent(penal3And4.commandCenter) == true)
                                {
                                    moveToElement(penal3And4.commandCenter);
                                    ClickObj(penal3And4.commandCenter, "Command Center");
                                    //CloseWarningPopUp();
                                }
                            }
                            else
                            {
                                TestContext.Progress.WriteLine("No Record is available to Click on Panel 2");
                                //Reporting.infoLog("No Record is available to Click on Panel 2");
                                //Assert.Warn("No Record is available to Click on Panel 2");
                                continue; // Skip since its empty
                            }
                        }

                    }));


                }
            }));
        }
    }
}
