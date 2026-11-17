using NUnit.Framework;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestCases
{
    public partial class SingleUser_eTrackerHRH_TestCases : SetUp
    {


        // when we run using single user then we dont pass Parameter next to method for example: [ DeathEposureEventstoAdRelevantDetails_7639_TestCase() ]
        // and call login method first then remaining steps

        //[Test]
        //[Category("Regression Testing For Single User")]
        //public void _40145__SearchBladeShallShowARNGHistoryResults_TestCase()
        //{
        //    _40145__SearchBladeShallShowARNGHistoryResults_Steps TestID40145 = new _40145__SearchBladeShallShowARNGHistoryResults_Steps(driver);


        //    Assert.Multiple(() =>
        //    {
        //        LoginSteps loginSteps = new LoginSteps(driver);

        //        loginSteps.PerformLogin_4_SingleUser(username);
        //        TestID40145._40145__SearchBladeShallShowARNGHistoryResults();

        //    });
        //}

      


    }
}
