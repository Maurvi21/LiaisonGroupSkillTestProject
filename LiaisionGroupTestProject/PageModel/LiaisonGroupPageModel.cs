using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LiaisionGroupTestProject.PageModel
{
    public class LiaisonGroupPageModel
    {
        public  IWebDriver driver;

        public LiaisonGroupPageModel(IWebDriver driver)
        {
            this.driver = driver;
        }

        //IWebElement el = driver.FindElement(By.XPath(""));
    }
}
