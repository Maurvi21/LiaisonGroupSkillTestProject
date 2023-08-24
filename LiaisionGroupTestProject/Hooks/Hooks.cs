using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiaisionGroupTestProject.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer container;
        
        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void BeforeScenario( )
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs<IWebDriver>(driver);
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>();
            if(driver!=null)
            {
                driver.Quit();
            }  
        }
    }
}
