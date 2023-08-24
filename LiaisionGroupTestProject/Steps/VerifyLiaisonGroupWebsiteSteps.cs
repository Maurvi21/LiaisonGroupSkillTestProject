using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExtras.WaitHelpers;

namespace LiaisionGroupTestProject.Steps
{
    [Binding]
    public class VerifyLiaisonGroupWebsiteSteps
    {
        private readonly IWebDriver driver;
        public static string URLBeforeClickFindMore = "";
        public static string URLafterClickFindMore = "";
        WebDriverWait wait;
        public VerifyLiaisonGroupWebsiteSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        
        [Given(@": Launch Lisison Group Website")]
        public void GivenLaunchLisisonGroupWebsite()
        {
            // Launch LiaisonGroup URL
            driver.Navigate().GoToUrl("https://www.liaisongroup.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@data-tid='banner-accept']")));
            //Click on Accept Cookie button
            driver.FindElement(By.XPath("//button[@data-tid='banner-accept']")).Click();
        }

        [When(@": Open Integrated Care System Dropdown by clicking on that")]
        public void WhenOpenIntegratedCareSystemDropdownByClickingOnThat()
        {
            //Hover over the Integrated Care Syste Drodown
            IWebElement el = driver.FindElement(By.XPath("//div[@class='z-10 flex items-center justify-center cursor-pointer align middle']//a[contains(text(),'Integrated Care Systems')]"));
            Actions ac = new Actions(driver);
            ac.MoveToElement(el).Build().Perform();
        }

        [When(@": Click on Liaison Financial Logo")]
        public void WhenClickOnLiaisonFinancialLogo()
        {
            //Click on LiaisonGroup Logo
            URLBeforeClickFindMore = driver.Url;
            driver.FindElement(By.XPath("//nav//div[@class='items-center hidden space-x-2 sm:hidden md:flex lg:flex lg:space-x-4']//a[@href='https://www.liaisongroup.com/liaison-financial']")).Click();
        }


        [When(@": Enter search value ""(.*)"" in search box")]
        public void WhenEnterSearchValueInSearchBox(string searchvalue)
        {
            //Enter Value in search box
            driver.FindElement(By.XPath("(//form[@class='relative flex items-center mb-6']//input[@placeholder='Search'])[2]")).Click();
            driver.FindElement(By.XPath("(//form[@class='relative flex items-center mb-6']//input[@placeholder='Search'])[2]")).SendKeys(searchvalue);
        }

        [When(@": click on seatch icon")]
        public void WhenClickOnSeatchIcon()
        {
            //Click on search icon
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
        }

        [When(@": Click on Hamburger menu")]
        public void WhenClickOnHamburgerMenu()
        {
            //Click on Hamburger menu
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("(//button[@aria-label='Main menu'])[1]")).Click();
        }

        [When(@": Click on Careers link")]
        public void WhenClickOnCareersLink()
        {
            // Click on Carrer Link
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@href='/liaison-group/careers']")));
            driver.FindElement(By.XPath("//a[@href='/liaison-group/careers']")).Click();
        }

        [When(@": Navigate to Contact Us Section")]
        public void WhenNavigateToContactUsSection()
        {
            //Click on Contact Page
            driver.FindElement(By.XPath("//div[@class='flex pr-2 space-x-2 lg:space-x-4']//a[contains(text(),'Contact')]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(),'Contact Us')]")));
        }

        [When(@": Enter Contact Us From Details like Full Name, Email, Organization, Subject and Message")]
        public void WhenEnterContactUsFromDetailsLikeFullNameEmailOrganizationSubjectAndMessage()
        {
            //Enter Name
            driver.FindElement(By.Id("field_qh4icy")).SendKeys("NameTest");
            //Enter Email
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("Test@test.com");
            //Enter Org
            driver.FindElement(By.XPath("//input[@id='field_e6lis6']")).SendKeys("TestOrg");
            //Enter Subject
            driver.FindElement(By.XPath("//input[@id='field_as377']")).SendKeys("Test Subject");
            //Enter Message
            driver.FindElement(By.XPath("//textarea[@id='field_9jv0r1']")).SendKeys("Test Message");
        }

        [When(@": Click on Submit arrow")]
        public void WhenClickOnSubmitArrow()
        {
            //Click on Submit
            driver.FindElement(By.XPath("//div[@id='mapSubmit']//button[@class='frm_button_submit frm_final_submit']")).Click();
        }

        [Then(@": Verify user should be able to see dropdown options")]
        public void ThenVerifyUserShouldBeAbleToSeeDropdownOptions()
        {
            IWebElement el = driver.FindElement(By.XPath("//div[@class='z-10 flex items-center justify-center cursor-pointer align middle']//a[contains(text(),'Integrated Care Systems')]//parent::div//following-sibling::div"));
            Assert.IsTrue(el.Displayed, "Dropdown element is not displayed");

        }

        [Then(@": Verify User should be able to redirect to another page")]
        public void ThenVerifyUserShouldBeAbleToRedirectToAnotherPage()
        {
            URLafterClickFindMore = driver.Url;
            Assert.AreNotEqual(URLafterClickFindMore, URLBeforeClickFindMore, "Find out navigation is not working");
        }

        [Then(@": Verify user should be able to see search results")]
        public void ThenVerifyUserShouldBeAbleToSeeSearchResults()
        {
            string ExpectedText = "Search results for 'About Us'";
            string ActualText = driver.FindElement(By.XPath("//div/h1[contains(text(),'About')]")).Text;
            Assert.IsTrue(ExpectedText.Contains(ActualText), "Search is not working ");
        }

        [Then(@": verify user should be able to see carrers page with URL contains ""(.*)""")]
        public void ThenVerifyUserShouldBeAbleToSeeCarrersPageWithURLContains(string url)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string carrerURL = driver.Url;
            Assert.IsTrue(carrerURL.Contains(url), "Carrer page navigation is not working");
        }

        [Then(@": User should get success message")]
        public void ThenUserShouldGetSuccessMessage()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='frm_message']//em")));
            string successmeesage = driver.FindElement(By.XPath("//div[@class='frm_message']//em")).Text;
            Assert.IsTrue(successmeesage.Contains("Thank you"),"Success message is not properly displayed");
        }

    }
}
