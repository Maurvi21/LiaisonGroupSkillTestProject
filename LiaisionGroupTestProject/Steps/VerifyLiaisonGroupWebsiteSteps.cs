using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiaisionGroupTestProject.Steps
{
    [Binding]
    public class VerifyLiaisonGroupWebsiteSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver driver;
        public static string URLBeforeClickFindMore = "";
        public static string URLafterClickFindMore = "";
        public VerifyLiaisonGroupWebsiteSteps(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        [Given(@": Launch Lisison Group Website")]
        public void GivenLaunchLisisonGroupWebsite()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Navigate().GoToUrl("https://www.liaisongroup.com/");
            //Click on Accept Cookie button
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (driver.FindElement(By.XPath("//button[@data-tid='banner-accept']")).Displayed)
            {
                driver.FindElement(By.XPath("//button[@data-tid='banner-accept']")).Click();
            }

        }

        [When(@": Open Integrated Care System Dropdown by clicking on that")]
        public void WhenOpenIntegratedCareSystemDropdownByClickingOnThat()
        {
            IWebElement el = driver.FindElement(By.XPath("//div[@class='z-10 flex items-center justify-center cursor-pointer align middle']//a[contains(text(),'Integrated Care Systems')]"));
            Actions ac = new Actions(driver);
            ac.MoveToElement(el).Build().Perform();
        }

        [When(@": Click on Liaison Financial Logo")]
        public void WhenClickOnLiaisonFinancialLogo()
        {
            URLBeforeClickFindMore = driver.Url;
            driver.FindElement(By.XPath("//nav//div[@class='items-center hidden space-x-2 sm:hidden md:flex lg:flex lg:space-x-4']//a[@href='https://www.liaisongroup.com/liaison-financial']")).Click();
        }


        [When(@": Enter search value ""(.*)"" in search box")]
        public void WhenEnterSearchValueInSearchBox(string searchvalue)
        {
            driver.FindElement(By.XPath("(//form[@class='relative flex items-center mb-6']//input[@placeholder='Search'])[2]")).Click();
            driver.FindElement(By.XPath("(//form[@class='relative flex items-center mb-6']//input[@placeholder='Search'])[2]")).SendKeys(searchvalue);
        }

        [When(@": click on seatch icon")]
        public void WhenClickOnSeatchIcon()
        {
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
        }

        [When(@": Click on Hamburger menu")]
        public void WhenClickOnHamburgerMenu()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("(//button[@aria-label='Main menu'])[1]")).Click();
        }

        [When(@": Click on Careers link")]
        public void WhenClickOnCareersLink()
        {

            driver.FindElement(By.XPath("//a[@href='/liaison-group/careers']")).Click();
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

        [Then(@": verify user should be able to see carrers page with text ""(.*)""")]
        public void ThenVerifyUserShouldBeAbleToSeeCarrersPageWithText(string p0)
        {
            string carrerURL = driver.Url;
            Assert.IsTrue(carrerURL.Contains("/careers"), "Carrer page navigation is not working");
        }
    }
}
