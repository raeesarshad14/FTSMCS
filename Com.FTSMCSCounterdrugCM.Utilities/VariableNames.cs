using OpenQA.Selenium;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities
{
    public class VariableNames : UtilityMethods
    {

        public VariableNames(IWebDriver driver) : base(driver)
        {

        }

        public string AgencySupportRequests = "Agency Support Request(s)";

    }
}
