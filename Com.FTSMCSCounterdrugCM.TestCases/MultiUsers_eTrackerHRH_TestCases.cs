using NUnit.Framework;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestSteps;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.TestCases
{
    public partial class MultiUsers_FTSMCS_TestCases : SetUp
    {

        //below filepath is to read data from file and GetProjectDirectory() is conming from global framework
        //string filePath = Uptick.Tests.Common.TestElementManipulation.GetProjectDirectory()

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine17000ClosedViaRequestsScenario1Steps_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine17000 = new StateMachine17000ClosedViaRequestsScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine17000.StateMachine17000ClosedViaRequestsScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine17000CancelViaProjectedScneario2Steps_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine17000 = new StateMachine17000CancelViaProjectedScneario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine17000.StateMachine17000CancelViaProjectedScneario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine17000CancelViaRequestedScneario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine17000 = new StateMachine17000CancelViaRequestedScneario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine17000.StateMachine17000CancelViaRequestedScneario3();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine17000CancelViaValidatedScneario4_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine17000 = new StateMachine17000CancelViaValidatedScneario4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine17000.StateMachine17000CancelViaValidatedScneario4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine16000ClosedViaRequestReimbursementFromStateScneario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine16000 = new StateMachine16000ClosedViaRequestReimbursementFromStateScneario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine16000.StateMachine16000ClosedViaRequestReimbursementFromStateScneario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine16000CancelViaRequestReimbursementFromStateScneario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine16000 = new StateMachine16000CancelViaRequestReimbursementFromStateScneario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine16000.StateMachine16000CancelViaRequestReimbursementFromStateScneario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine16000CancelViaValidateScneario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine16000 = new StateMachine16000CancelViaValidateScneario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine16000.StateMachine16000CancelViaValidateScneario3();

                }
            }));
        }



        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine16000CancelViaProjectedScneario4Steps_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine16000 = new StateMachine16000CancelViaProjectedScneario4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine16000.StateMachine16000CancelViaProjectedScneario4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void MCR91211DDROSupportHoursByEvent_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var RMCR91211DDROSupportHours = new MCR91211DDROSupportHoursByEventSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    RMCR91211DDROSupportHours.MCR91211DDROSupportHoursByEvent();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void MCR91289ASRHideDeletedASRCases_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var MCR91289 = new MCR91289ASRHideDeletedASRCasesSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    MCR91289.MCR91289ASRHideDeletedASRCases();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void MCR91304SAFUpdateInsertAddCaseCode_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var MCR91304 = new MCR91304SAFUpdateInsertAddCaseCodeSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    MCR91304.MCR91304SAFUpdateInsertAddCaseCode();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void MCR91305SAFUpdateInsertSafetyHazardAddCaseCode_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var MCR91305 = new MCR91305SAFUpdateInsertSafetyHazardAddCaseCodeSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    MCR91305.MCR91305SAFUpdateInsertSafetyHazardAddCaseCode();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine14000PersonnelReActivateInProcessingViaDeleteDeny_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SM_14000 = new StateMachine14000PersonnelReActivateInProcessingViaDeleteDenySteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SM_14000.StateMachine14000PersonnelReActivateInProcessingViaDeleteDeny();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine14000PersonnelReActivateInProcessingViaApprove_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SM_14000 = new StateMachine14000PersonnelReActivateInProcessingViaApproveSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SM_14000.StateMachine14000PersonnelReActivateInProcessingViaApprove();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine14000PersonnelReActivateInProcessingViaApproveAndInProcessingChecklistComplete_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SM_14000 = new StateMachine14000PersonnelReActivateInProcessingViaApproveAndInProcessingChecklistCompleteSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SM_14000.StateMachine14000PersonnelReActivateInProcessingViaApproveAndInProcessingChecklistComplete();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine14000PersonnelReActivateInProcessingViaApproveAndAcceptCompleteInProcessing_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SM_14000 = new StateMachine14000PersonnelReActivateInProcessingViaApproveAndAcceptCompleteInProcessingSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SM_14000.StateMachine14000PersonnelReActivateInProcessingViaApproveAndAcceptCompleteInProcessing();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine14000PersonnelReActivateInProcessingPersonnelPendingRenewal_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SM_14000 = new StateMachine14000PersonnelReActivateInProcessingPersonnelPendingRenewalSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SM_14000.StateMachine14000PersonnelReActivateInProcessingPersonnelPendingRenewal();

                }
            }));
        }


        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine14000PersonnelReActivateInProcessingRenewalApptoved_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SM_14000 = new StateMachine14000PersonnelReActivateInProcessingRenewalApptovedSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SM_14000.StateMachine14000PersonnelReActivateInProcessingRenewalApptoved();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine9000CounterdrugASRActiveUnresourced_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var Mission9000 = new StateMachine9000CounterdrugASRActiveUnresourcedSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    Mission9000.StateMachine9000CounterdrugASRActiveUnresourced();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine9000ReOpen_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var Mission9000 = new StateMachine9000ReOpenSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    Mission9000.StateMachine9000ReOpen();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine9000ASRCounterdrugCancel_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var Mission9000 = new StateMachine9000ASRCounterdrugCancelSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    Mission9000.StateMachine9000ASRCounterdrugCancel();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine6000CounterdrugSPReturnClose_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StatePlan6000 = new StateMachine6000CounterdrugSPReturnCloseSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StatePlan6000.StateMachine6000CounterdrugSPReturnClose();

                }
            }));
        }


        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine6000CounterdrugStatePlanSubnittedForSignaturesViaReturnAndReturnWithRecommendationsToState_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StatePlan6000 = new StateMachine6000CounterdrugStatePlanSubnittedForSignaturesViaReturnAndReturnWithRecommendationsToStateSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StatePlan6000.StateMachine6000CounterdrugStatePlanSubnittedForSignaturesViaReturnAndReturnWithRecommendationsToState();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine6000CounterdrugStatePlanClosesScenarioViaReturnWithRecommendationsAndAccept_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StatePlan6000 = new StateMachine6000CounterdrugStatePlanClosesScenarioViaReturnWithRecommendationsAndAcceptSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StatePlan6000.StateMachine6000CounterdrugStatePlanClosesScenarioViaReturnWithRecommendationsAndAccept();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine6000CounterdrugStatePlanReturnWithRecommendationsReturnedState_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StatePlan6000 = new StateMachine6000CounterdrugStatePlanReturnWithRecommendationsReturnedStateSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StatePlan6000.StateMachine6000CounterdrugStatePlanReturnWithRecommendationsReturnedState();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnAndCDCReturnToStateForRevision_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StatePlan6000 = new StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnAndCDCReturnToStateForRevisionSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StatePlan6000.StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnAndCDCReturnToStateForRevision();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnWithRecommendationsAndCDCReturnToStateForRevision_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StatePlan6000 = new StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnWithRecommendationsAndCDCReturnToStateForRevisionSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StatePlan6000.StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnWithRecommendationsAndCDCReturnToStateForRevision();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnWithRecommendationsToStateAndReturned_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StatePlan6000 = new StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnWithRecommendationsToStateAndReturnedSteps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StatePlan6000.StateMachine6000CounterdrugStatePlanSubmitToCDCViaReturnWithRecommendationsToStateAndReturned();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine28000CounterdrugAgencyAdminFederalAgencyPendingNGBApprovalAndApproveAgnecyScenario4_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var AgencyAdmin28000 = new StateMachine28000CounterdrugAgencyAdminFederalAgencyPendingNGBApprovalAndApproveAgnecyScenario4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    AgencyAdmin28000.StateMachine28000CounterdrugAgencyAdminFederalAgencyPendingNGBApprovalAndApproveAgnecyScenario4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine28000CounterdrugAgencyAdminStateLocalTribalPendingRCApprovalDenyAgencyRequestCancelledDeniedScenario5_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var AgencyAdmin28000 = new StateMachine28000CounterdrugAgencyAdminStateLocalTribalPendingRCApprovalDenyAgencyRequestCancelledDeniedScenario5Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    AgencyAdmin28000.StateMachine28000CounterdrugAgencyAdminStateLocalTribalPendingRCApprovalDenyAgencyRequestCancelledDeniedScenario5();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine28000CounterdrugAgencyAdminDenyAgencyRequestCancelledDeniedScenario6_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var AgencyAdmin28000 = new StateMachine28000CounterdrugAgencyAdminDenyAgencyRequestCancelledDeniedScenario6Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    AgencyAdmin28000.StateMachine28000CounterdrugAgencyAdminDenyAgencyRequestCancelledDeniedScenario6();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine28000CounterdrugAgencyAdminFederalAgencyPendingNGBApprovalCancelledDeniedScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var AgencyAdmin28000 = new StateMachine28000CounterdrugAgencyAdminFederalAgencyPendingNGBApprovalCancelledDeniedScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    AgencyAdmin28000.StateMachine28000CounterdrugAgencyAdminFederalAgencyPendingNGBApprovalCancelledDeniedScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine28000CounterdrugAgencyAdminApproveAgencyFederalAgencyPendingNGBApprovalCancelledDeniedScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var AgencyAdmin28000 = new StateMachine28000CounterdrugAgencyAdminApproveAgencyFederalAgencyPendingNGBApprovalCancelledDeniedScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    AgencyAdmin28000.StateMachine28000CounterdrugAgencyAdminApproveAgencyFederalAgencyPendingNGBApprovalCancelledDeniedScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void SafetyIncident22000SafetyIncidentCaseClosedScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SafetyIncident22000 = new SafetyIncident22000SafetyIncidentCaseClosedScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SafetyIncident22000.SafetyIncident22000SafetyIncidentCaseClosedScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void SafetyIncident22000SafetyIncidentCaseCancelScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SafetyIncident22000 = new SafetyIncident22000SafetyIncidentCaseCancelScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SafetyIncident22000.SafetyIncident22000SafetyIncidentCaseCancelScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void SafetyIncident22000SafetyIncidentCaseCancelScenario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SafetyIncident22000 = new SafetyIncident22000SafetyIncidentCaseCancelScenario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SafetyIncident22000.SafetyIncident22000SafetyIncidentCaseCancelScenario3();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void SafetyHazardAdmin29000CanceledScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SafetyHazardAdmin29000 = new SafetyHazardAdmin29000CanceledScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SafetyHazardAdmin29000.SafetyHazardAdmin29000CanceledScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void SafetyHazardAdmin29000ClosedCompletedSafetyHazardsScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var SafetyHazardAdmin29000 = new SafetyHazardAdmin29000ClosedCompletedSafetyHazardsScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    SafetyHazardAdmin29000.SafetyHazardAdmin29000ClosedCompletedSafetyHazardsScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void POCAdmin33000ReActivatePOCScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var POCAdmin33000 = new POCAdmin33000ReActivatePOCScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    POCAdmin33000.POCAdmin33000ReActivatePOCScenario1();

                }
            }));
        }

        [Test]
        [TestCase("AutoVer.TestUser1.ctr", "https://releaseftsmcs.tibercreek.local/ProxyLogin.aspx?ReturnUrl=%2fprotected%2fCounterdrugCM%2fAtlas")]
        [Category("Smoke Testing")]
        public void SmokeTesting_CounterdrugCMValidation_TestCase(string userName, string url)
        {
            var loginSteps = new LoginSteps(driver);
            var SmokeTesting = new SmokeTesting_CounterdrugCMValidationSteps(driver);

            // ⭐ Navigate to the URL passed from TestCase
            driver.Navigate().GoToUrl(url);

            Assert.Multiple((Action)(() =>
            {
                TestContext.Progress.WriteLine($"Logging in as: {userName}");
                loginSteps.PerformLogin_4_Multiusers(userName);
                SmokeTesting.SmokeTesting_CounterdrugCMValidation();
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void POCAdmin33000RePointOfContactCancelledScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var POCAdmin33000 = new POCAdmin33000RePointOfContactCancelledScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    POCAdmin33000.POCAdmin33000RePointOfContactCancelledScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine24000And27000TargetChangeScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine24000And27000 = new StateMachine24000And27000TargetChangeScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine24000And27000.StateMachine24000And27000TargetChangeScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine24000And27000ReturnWithCommentsScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine24000And27000 = new StateMachine24000And27000ReturnWithCommentsScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine24000And27000.StateMachine24000And27000ReturnWithCommentsScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine24000And27000ReturnToStateScenario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine24000And27000 = new StateMachine24000And27000ReturnToStateScenario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine24000And27000.StateMachine24000And27000ReturnToStateScenario3();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine24000And27000ReturnToStateViaPendingCDCReviewScenario4_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine24000And27000 = new StateMachine24000And27000ReturnToStateViaPendingCDCReviewScenario4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine24000And27000.StateMachine24000And27000ReturnToStateViaPendingCDCReviewScenario4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine11000FundedScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine11000 = new StateMachine11000FundedScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine11000.StateMachine11000FundedScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine11000UnFundedScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine11000 = new StateMachine11000UnFundedScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine11000.StateMachine11000UnFundedScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine11000ReturnWithCommentsScenario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine11000 = new StateMachine11000ReturnWithCommentsScenario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine11000.StateMachine11000ReturnWithCommentsScenario3();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine11000FundedViaSubmitAsExchangeScenario4_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine11000 = new StateMachine11000FundedViaSubmitAsExchangeScenario4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine11000.StateMachine11000FundedViaSubmitAsExchangeScenario4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine11000UnFundedViaSubmitAsExchangeScenario5_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine11000 = new StateMachine11000UnFundedViaSubmitAsExchangeScenario5Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine11000.StateMachine11000UnFundedViaSubmitAsExchangeScenario5();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine11000CancellledViaCDCCertificationScenario6_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine11000 = new StateMachine11000CancellledViaCDCCertificationScenario6Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine11000.StateMachine11000CancellledViaCDCCertificationScenario6();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine11000CancellledViaStateSubmissionPendingScenario7_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine11000 = new StateMachine11000CancellledViaStateSubmissionPendingScenario7Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine11000.StateMachine11000CancellledViaStateSubmissionPendingScenario7();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine12000CancelledViaCancelRequestScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine12000 = new StateMachine12000CancelledViaCancelRequestScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine12000.StateMachine12000CancelledViaCancelRequestScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine12000CancelledViaCancelRequestScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine12000 = new StateMachine12000CancelledViaCancelRequestScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine12000.StateMachine12000CancelledViaCancelRequestScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine12000TurnedInViaReceivedScenario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine12000 = new StateMachine12000TurnedInViaReceivedScenario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine12000.StateMachine12000TurnedInViaReceivedScenario3();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine12000ReturnedViaReturnScenario4_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine12000 = new StateMachine12000ReturnedViaReturnScenario4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine12000.StateMachine12000ReturnedViaReturnScenario4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine12000ReturnedViaPendingRCReviewScenario5_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine12000 = new StateMachine12000ReturnedViaPendingRCReviewScenario5Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine12000.StateMachine12000ReturnedViaPendingRCReviewScenario5();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine12000ReturnedViaPendingCDCVerificationScenario6_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine12000 = new StateMachine12000ReturnedViaPendingCDCVerificationScenario6Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine12000.StateMachine12000ReturnedViaPendingCDCVerificationScenario6();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine18000And19000RetrainViaAttendingClassScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine18000And19000 = new StateMachine18000And19000RetrainViaAttendingClassScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine18000And19000.StateMachine18000And19000RetrainViaAttendingClassScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine18000And19000RetrainViaCompletedScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine18000And19000 = new StateMachine18000And19000RetrainViaCompletedScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine18000And19000.StateMachine18000And19000RetrainViaCompletedScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine18000And19000RetrainViaCanceledScenario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine18000And19000 = new StateMachine18000And19000RetrainViaCanceledScenario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine18000And19000.StateMachine18000And19000RetrainViaCanceledScenario3();

                }
            }));
        }


        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine18000And19000MovedToRegisteredViaOnWaitlistScenario4_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine18000And19000 = new StateMachine18000And19000MovedToRegisteredViaOnWaitlistScenario4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine18000And19000.StateMachine18000And19000MovedToRegisteredViaOnWaitlistScenario4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine18000And19000CanceledViaOnWaitlistScenario5_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine18000And19000 = new StateMachine18000And19000CanceledViaOnWaitlistScenario5Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine18000And19000.StateMachine18000And19000CanceledViaOnWaitlistScenario5();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine26000ClosedScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine26000 = new StateMachine26000ClosedScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine26000.StateMachine26000ClosedScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine30000SemiAnnualInventoryMemoCompleteViaSemiAnnualInventoryInitiatedScenrio1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine30000 = new StateMachine30000SemiAnnualInventoryMemoCompleteViaSemiAnnualInventoryInitiatedScenrio1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine30000.StateMachine30000SemiAnnualInventoryMemoCompleteViaSemiAnnualInventoryInitiatedScenrio1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine30000AnnualInventoryMemoCompleteViaAnnualInventoryInitiatedScenrio2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine30000 = new StateMachine30000AnnualInventoryMemoCompleteViaAnnualInventoryInitiatedScenrio2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine30000.StateMachine30000AnnualInventoryMemoCompleteViaAnnualInventoryInitiatedScenrio2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine30000NewCDCAddedViaCDCChangeDDFormsScenrio3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine30000 = new StateMachine30000NewCDCAddedViaCDCChangeDDFormsScenrio3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine30000.StateMachine30000NewCDCAddedViaCDCChangeDDFormsScenrio3();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine32000TransferredEquipmentScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine32000 = new StateMachine32000TransferredEquipmentScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine32000.StateMachine32000TransferredEquipmentScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine32000TransferredEquipmentViaCompleteTransferScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine32000 = new StateMachine32000TransferredEquipmentViaCompleteTransferScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine32000.StateMachine32000TransferredEquipmentViaCompleteTransferScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine1000and2000OverrideViaSubmitToNGBCapAdminScenario1_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine1000and2000 = new StateMachine1000and2000OverrideViaSubmitToNGBCapAdminScenario1Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine1000and2000.StateMachine1000and2000OverrideViaSubmitToNGBCapAdminScenario1();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine1000and2000OverrideViaVirtualVerificationAndSubmitToNGBCapAdminScenario2_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine1000and2000 = new StateMachine1000and2000OverrideViaVirtualVerificationAndSubmitToNGBCapAdminScenario2Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine1000and2000.StateMachine1000and2000OverrideViaVirtualVerificationAndSubmitToNGBCapAdminScenario2();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine1000and2000ReOpenViaCancelScenario3_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine1000and2000 = new StateMachine1000and2000ReOpenViaCancelScenario3Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine1000and2000.StateMachine1000and2000ReOpenViaCancelScenario3();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine1000and2000ReturnToNGBPMVerificationViaNGBCAPAdminValidation4_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine1000and2000 = new StateMachine1000and2000ReturnToNGBPMVerificationViaNGBCAPAdminValidation4Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine1000and2000.StateMachine1000and2000ReturnToNGBPMVerificationViaNGBCAPAdminValidation4();

                }
            }));
        }

        [Test]
        [TestCase("Raees.Admin.MIL")]
        [Category("Regression Testing")]
        public void StateMachine1000and2000OverrideViaVirtualVerificationAndSubmitToNGBCapAdminScenario5_TestCase(params string[] usernames)
        {

            var loginSteps = new LoginSteps(driver);
            var StateMachine1000and2000 = new StateMachine1000and2000OverrideViaVirtualVerificationAndSubmitToNGBCapAdminScenario5Steps(driver);

            Assert.Multiple((Action)(() =>
            {
                foreach (var user in usernames)
                {
                    TestContext.Progress.WriteLine($"Logging in as: {user}");
                    loginSteps.PerformLogin_4_Multiusers(user);
                    StateMachine1000and2000.StateMachine1000and2000OverrideViaVirtualVerificationAndSubmitToNGBCapAdminScenario5();

                }
            }));
        }





    }
}
