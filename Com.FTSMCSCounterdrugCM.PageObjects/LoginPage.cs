using OpenQA.Selenium;
using Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.FTSMCSCounterDrugCM.Tests.Com.FTSMCSCounterdrugCM.PageObjects
{
    public class LoginPage : SetUp
    {
        public IWebDriver ldriver;

        public LoginPage(IWebDriver rdriver)
        {
            this.ldriver = rdriver;
        }

        // --- DYNAMIC ELEMENTS (The New Selenium 4 Way) ---

        public IWebElement advance_btn => ldriver.FindElement(By.Id("details-button"));

        public IWebElement proceed_link_btn => ldriver.FindElement(By.Id("proceed-link"));

        public IWebElement agree_btn => ldriver.FindElement(By.Name("agreement"));

        public IWebElement signinEmail => ldriver.FindElement(By.Id("i0116"));

        public IWebElement Next_Btn => ldriver.FindElement(By.Id("idSIButton9"));

        public IWebElement smartCard_Btn => ldriver.FindElement(By.Id("idA_PWD_SwitchToCertificate"));

        // This is the element that was causing your NullReferenceException!
        public IWebElement UserID => ldriver.FindElement(By.Id("LoginUser_UserName"));

        public IWebElement UserID_afterLogoutAndLoginBack => ldriver.FindElement(By.XPath("//input[@id='Dev_UserName']"));

        public IWebElement Login_btn => ldriver.FindElement(By.XPath("//input[@class='btn btn-default']"));

        public IWebElement requestAccess_link => ldriver.FindElement(By.XPath("/html/body/div/div/a[1]"));

        public IWebElement LandingPage_MyAccount => ldriver.FindElement(By.XPath("/html/body/nav/div/div[3]/ul/li/a"));

        public IWebElement ALURRT_product => ldriver.FindElement(By.XPath("//a[@href='/v4/ALURRT']"));

        public IWebElement welcome_login_note => ldriver.FindElement(By.XPath("//div[@class='toast-title']"));

        public IWebElement welcome_login_close => ldriver.FindElement(By.XPath("//button[@class='toast-close-button']"));

        public IWebElement FTSMCS_img_link => ldriver.FindElement(By.XPath("//a[@href='protected/FTSMCS']//img[@alt='FTSMCS']"));

        public IWebElement Submit_Btn => ldriver.FindElement(By.XPath("//input[@type='submit']"));

        public IWebElement QA_UserID => ldriver.FindElement(By.Id("Dev_UserName"));

        public IWebElement QA_LogIn_btn => ldriver.FindElement(By.XPath("//input[@type='submit']"));

        public IWebElement Password => ldriver.FindElement(By.Id("txtPassword"));

        public IWebElement LogIn_btn => ldriver.FindElement(By.Id("btnLogin"));

        public IWebElement Acknowledge_btn => ldriver.FindElement(By.XPath("//button[contains(normalize-space(text()), 'Acknowledge')]"));

        // --- LOCATOR STRATEGIES ---
        public By Logout_Icon = By.XPath("//img[@alt='Logout']");

        public By Submit_Btn_locator => By.XPath("//button[@onclick='onSubmitClick()']");

        public By signinEmail_locator => By.Id("i0116");

        public By password_locator => By.Id("i0118");

        public By UserID_locator => By.Id("LoginUser_UserName");
    }
}