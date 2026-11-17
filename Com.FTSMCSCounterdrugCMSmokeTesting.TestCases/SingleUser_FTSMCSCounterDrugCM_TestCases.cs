using NUnit.Framework;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.TestSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCMSmokeTesting.TestCases
{
    public class SingleUser_FTSMCSCounterDrugCM_TestCases : SetUp
    {


        // when we run using single user then we dont pass Parameter next to method for example: [DeathEposureEventstoAdRelevantDetails_7639_TestCase()]
        //and call login method first then remaining steps

        [Test]
        [Category("Regression Testing For Single User")]
        public void AllBlades_CaptureAllLinksNumbersOnPanel1AndCompareWithPanel2totalEntries_TestCase()
        {
            AllBlades_CaptureAllLinksNumbersOnPanel1AndCompareWithPanel2totalEntriesSteps AllBlades = new AllBlades_CaptureAllLinksNumbersOnPanel1AndCompareWithPanel2totalEntriesSteps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                AllBlades.AllBlades_CaptureAllLinksNumbersOnPanel1AndCompareWithPanel2totalEntries();

            }));
        }

        [Test]
        [Category("Regression Testing For Single User")]
        public void ValidateTabsForFirsto4Blades_TestCase()
        {
            AllBlades_TabsValidationForPanel3andPanel4Steps zeroTo4= new AllBlades_TabsValidationForPanel3andPanel4Steps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                zeroTo4.ValidateTabsForFirsto4Blades();

            }));
        }

        [Test]
        [Category("Regression Testing For Single User")]
        public void ValidateTabsFor5To8Blades_TestCase()
        {
            AllBlades_TabsValidationForPanel3andPanel4Steps FifthTo8 = new AllBlades_TabsValidationForPanel3andPanel4Steps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                FifthTo8.ValidateTabsFor5To8Blades();

            }));
        }

        [Test]
        [Category("Regression Testing For Single User")]
        public void ValidateTabsFor9To12Blades_TestCase()
        {
            AllBlades_TabsValidationForPanel3andPanel4Steps NineTo12 = new AllBlades_TabsValidationForPanel3andPanel4Steps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                NineTo12.ValidateTabsFor9To12Blades();

            }));
        }

        [Test]
        [Category("Regression Testing For Single User")]
        public void ValidateTabsFor13ToEndBlades_TestCase()
        {
            AllBlades_TabsValidationForPanel3andPanel4Steps ThreeToEnd = new AllBlades_TabsValidationForPanel3andPanel4Steps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                ThreeToEnd.ValidateTabsFor13ToEndBlades();

            }));
        }

        [Test]
        [Category("Regression Testing For Single User")]
        public void ReportBlade_VerifyLinksLoadWithoutFailure_TestCase()
        {
            ReportBlade_VerifyLinksLoadWithoutFailureSteps VerifyLinks = new ReportBlade_VerifyLinksLoadWithoutFailureSteps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                VerifyLinks.VerifyReportBladeLinksLoadWithoutFailure();

            }));
        }

        [Test]
        [Category("Regression Testing For Single User")]
        public void ReportingBlade_PanelExtraButtonListIconsfunctionalityTestStepse_TestCase()
        {
            ReportingBlade_PanelExtraButtonListIconsfunctionalityTestSteps IconsVerification = new ReportingBlade_PanelExtraButtonListIconsfunctionalityTestSteps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                IconsVerification.Panel2ReportingIconsIconsfunctionalityvalidation();

            }));
        }

        [Test]
        [Category("Regression Testing For Single User")]
        public void ReportingBlade_PanelControlsIconsFunctionalityTestStepse_TestCase()
        {
            ReportingBlade_PanelControlsIconsFunctionalityTestSteps PanelControlsIcons = new ReportingBlade_PanelControlsIconsFunctionalityTestSteps(driver);


            Assert.Multiple((Action)(() =>
            {
                LoginSteps loginSteps = new LoginSteps(driver);

                loginSteps.PerformLogin_4_SingleUser(username);
                PanelControlsIcons.ReportingIconsValidationTest();

            }));
        }








    }
}
