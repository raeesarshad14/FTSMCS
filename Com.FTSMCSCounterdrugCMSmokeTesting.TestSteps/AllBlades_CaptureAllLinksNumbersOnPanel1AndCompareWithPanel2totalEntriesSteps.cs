using NUnit.Framework;
using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.TestSteps
{
    public class AllBlades_CaptureAllLinksNumbersOnPanel1AndCompareWithPanel2totalEntriesSteps : UtilityMethods

    {

        public AllBlades_CaptureAllLinksNumbersOnPanel1AndCompareWithPanel2totalEntriesSteps(IWebDriver driver) : base(driver)
        {
        }
        public void AllBlades_CaptureAllLinksNumbersOnPanel1AndCompareWithPanel2totalEntries()
        {

            //creating object to acees elements
            ManagementCenter_Page MCP = new ManagementCenter_Page(driver);

            TestContext.Progress.WriteLine("Total Blades Are: " + MCP.ManagementCenter_List.Count);


            Assert.Multiple((Action)(() =>
            {
                for (int BladeNumber = 0; BladeNumber < MCP.ManagementCenter_List.Count; BladeNumber++)
                {
                    IWebElement BladeElement = MCP.ManagementCenter_List[BladeNumber];
                    TestContext.Progress.WriteLine("Blade Name is: " + BladeElement.Text + " and Blade number is: " + BladeNumber);
                    Reporting.infoLogWithSS("Blade Name is: " + BladeElement.Text + " and Blade number is: " + BladeNumber);
                    //below method expanding Managenment Blade if this is not exapnd/open
                    ClickObj(BladeElement, BladeElement.Text);
                    //Below Method is is to open Parent Node if these are not already open/expand.(Get all items in a parent container, expand)
                    GetAllparentlistClosedNodeandExpand(null, MCP.parent_li_closed_node);

                    //below line is to get total child links
                    IList<IWebElement> NoOfChildLinks_2loopThru = driver.FindElements(By.XPath("//div[contains(@class, 'command-center-component') and contains(@class, 'active')]//a[@class='treeitem-node wb-node wb-node-without-children']"));
                    TestContext.Progress.WriteLine("Total Number of Child Links to Loop Through are: " + NoOfChildLinks_2loopThru.Count);
                    //Reporting.infoLog("Total Number of Child Links to Loop Through are: " + NoOfChildLinks_2loopThru.Count);

                    if (NoOfChildLinks_2loopThru.Count == 0)
                    {
                        TestContext.Progress.WriteLine("Seems like Management blade was not clicked");
                        //Reporting.warningLog("Seems like Management blade was not clicked");
                        Assert.Warn("Seems like Management blade was not clicked");
                    }


                    // below loop is to click the child links
                    for (int i = 0; i < NoOfChildLinks_2loopThru.Count(); i++)
                    {
                        IWebElement ChildLists = NoOfChildLinks_2loopThru[i];
                        string itemName = GetElementText(ChildLists, "Tree items text is: " + ChildLists.Text);
                        TestContext.Progress.WriteLine("I value is: " + i + " and link is: " + itemName);
                        //Reporting.infoLog("I value is: " + i + " and link is: " + itemName);

                        string Tot_Records = null;
                        IWebElement total = null;
                        try
                        {
                            total = ChildLists.FindElement(By.TagName("span"));
                        }
                        catch (Exception e)
                        {

                        }

                        // below if (total == null) is doing, if link does not contain any number or 0 number then it will still click and see panel 2 have the same 0 number also handle the red pop up
                        if (total == null)
                        {
                            TestContext.Progress.WriteLine("This is:   if (total == null) if statement");
                            Tot_Records = "0";
                            ClickObj(ChildLists, "The Tree Item: " + itemName);
                            //HandleErrorPopupIfPresent(itemName, MCP.closeIconOnPopup);
                            TestContext.Progress.WriteLine("Total record appear or not: " + isElementPresent(MCP.totalNumberOnPanel2) + " Total Record on panel 2");
                            //Reporting.infoLog("Total record appear or not: " + getElementDisplay(MCP.totalNumberOnPanel2, "Total Record on panel 2"));
                            if (isElementPresent(MCP.totalNumberOnPanel2))
                            {
                                string Element_TotEnt2 = driver.FindElement(By.XPath("(//*[contains(@class,'active')]//div[contains(@class,'dataTables_info')])[last()]")).Text;
                                TestContext.Progress.WriteLine("total entries are " + Element_TotEnt2);
                                // Reporting.infoLog("total entries are " + Element_TotEnt2);

                                //spliting the validation text for example Showing 1 to 7 of 7 entries 
                                string[] Element_TotEnt_SplitedUntil_Of2 = Element_TotEnt2.Split("f".ToCharArray());
                                string[] Element_TotEnt_Splited_enteries2 = Element_TotEnt_SplitedUntil_Of2[1].Split("entries".ToCharArray());
                                string FinalSplittedText2 = Element_TotEnt_Splited_enteries2[0].Replace(",", "").Trim();
                                TestContext.Progress.WriteLine("Final Splitted text is: " + FinalSplittedText2);
                                //Reporting.infoLog("Final Splitted text is: " + FinalSplittedText2);

                                //below is validating the expted with actual 
                                if (Tot_Records.Equals(FinalSplittedText2))
                                {
                                    CaptureScreenshot(true);
                                    TestContext.Progress.WriteLine("Count matched Successfully for tree item " + itemName);
                                    Reporting.successLog("Count matched Successfully for tree item " + itemName);
                                }
                                else
                                {
                                    CaptureScreenshot(true);
                                    TestContext.Progress.WriteLine("Failure to match Count for tree item " + itemName);
                                    Reporting.failureLog("Failure to match Count for tree item " + itemName);
                                    Assert.Fail("Failure to match Count for: " + itemName + " Total Records are showing on Panel 1 are: " + Tot_Records + " But Actual showing on panel 2 are: " + FinalSplittedText2);

                                }
                            }
                            else
                            {
                                TestContext.Progress.WriteLine("No record appeared due to red popup");
                                //Reporting.infoLog("No record appeared due to red popup");
                                continue; // Skip since its empty
                            }
                        }
                        //if (total == not null) or contain value then execute the else part.
                        else
                        {
                            TestContext.Progress.WriteLine(" This is else part where: if (total == not null) or contain value then execute the else part.");
                            Tot_Records = GetElementText(total, "Tree items text " + ChildLists.Text).Replace("[^0-9]", "").Replace(",", ""); // 15274                                                                                                                 //}
                            TestContext.Progress.WriteLine("Total Records in Tree item are: " + Tot_Records);
                            //Reporting.infoLog("Total Records in Tree item are: " + Tot_Records);

                            ClickObj(ChildLists, "The Tree Item: " + itemName);
                            HandleErrorPopupIfPresent_locator(itemName, MCP.closeIconOnPopup_locator);
                            TestContext.Progress.WriteLine("This is else part which showing record on panel 1 and now verifing on panel2: Total record appear or not: " + isElementPresent(MCP.totalNumberOnPanel2) + " Total Record on panel 2");
                            //Reporting.infoLog("This is else part which showing record on panel 1 and now verifing on panel2: Total record appear or not: " + getElementDisplay(MCP.totalNumberOnPanel2, "Total Record on panel 2"));

                            string text = GetElementTextWithoutMoveToElement(MCP.totalNumberOnPanel_WebElement);
                            TestContext.Progress.WriteLine("Text are: " + text);

                            if (isElementPresent(MCP.totalNumberOnPanel2) && text != null)
                            {
                                string Element_TotEnt = driver.FindElement(By.XPath("(//*[contains(@class,'active')]//div[contains(@class,'dataTables_info')])[last()]")).Text;
                                TestContext.Progress.WriteLine("total entries are " + Element_TotEnt);
                                // Reporting.infoLog("total entries are " + Element_TotEnt);

                                //spliting the validation text for example Showing 1 to 7 of 7 entries 
                                string[] Element_TotEnt_SplitedUntil_Of = Element_TotEnt.Split("f".ToCharArray());
                                string[] Element_TotEnt_Splited_enteries = Element_TotEnt_SplitedUntil_Of[1].Split("entries".ToCharArray());
                                string FinalSplittedText = Element_TotEnt_Splited_enteries[0].Replace(",", "").Trim();
                                TestContext.Progress.WriteLine("Final Splitted text is: " + FinalSplittedText);
                                // Reporting.infoLog("Final Splitted text is: " + FinalSplittedText);


                                //below is validating the expected with actual 
                                if (Tot_Records.Equals(FinalSplittedText))
                                {
                                    CaptureScreenshot(true);
                                    TestContext.Progress.WriteLine("Count matched Successfully for tree item " + itemName);
                                    Reporting.successLog("Count matched Successfully for tree item " + itemName);
                                }
                                else
                                {
                                    CaptureScreenshot(true);
                                    TestContext.Progress.WriteLine("Failure to match Count for tree item " + itemName);
                                    Reporting.failureLog("Failure to match Count for: " + itemName + " Total Records are showing on Panel 1: " + Tot_Records + " But Actual showing on panel 2 are: " + FinalSplittedText);
                                    Assert.Fail("Failure to match Count for: " + itemName + " Total Records are showing on Panel 1: " + Tot_Records + " But Actual showing on panel 2 are: " + FinalSplittedText);
                                }
                            }
                            else
                            {
                                CaptureScreenshot(true);
                                TestContext.Progress.WriteLine("Showing entries were not appeard on panel 2");
                                Reporting.infoLog("Showing entries were not appeard on panel 2");
                                Assert.Fail("Showing entries were not appeard on panel 2");
                                continue; // Skip since its empty
                            }
                        }
                    }
                }
            }));

        }

    }
}
