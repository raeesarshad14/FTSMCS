using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects
{
    public class LogoutPage : SetUp
    {
        public IWebDriver ldriver;

        public LogoutPage(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        // --- DYNAMIC ELEMENTS (The New Selenium 4 Way) ---

        public IWebElement myAccount => ldriver.FindElement(By.XPath("//a[contains(text(),'My Account')]"));

        public IWebElement logOut => ldriver.FindElement(By.XPath("//a[contains(text(),'Log Out')]"));

        public IWebElement here_ToLoginBack => ldriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/a"));
    }
}