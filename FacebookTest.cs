using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation
{
    class FacebookTest
    {
        static void Main(string[] args)
        {

        }

        [SetUp]
        public void Initialize()
        {
            Driver.driver = new ChromeDriver();
            Driver.driver.Navigate().GoToUrl("https://www.facebook.com");
        }

        [Test]
        public void ExecuteTest()
        {
            PageObjects page = new PageObjects();
            page.FirstName.SendKeys("Djuro");
            page.LastName.SendKeys("Djuric");
            page.Email.SendKeys("djurodjuro@email.com");
            page.EmailConfirm.SendKeys("djurodjuro@email.com");
            page.Password.SendKeys("jasamdjurodjuric");
            page.BirthDay.SendKeys("31");
            page.BirthMonth.SendKeys("Velj");
            page.BirthYear.SendKeys("1990");
            page.Submit.Click();

            if (page.SexWarning.Displayed == true)
            {
                Console.WriteLine("Message is displayed!");
            }
            else
            {
                Console.WriteLine("Message isn't displayed!");
            }
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.driver.Close();
        }
    }

    class Driver
    {
        public static IWebDriver driver { get; set; }
    }

    class PageObjects
    {
        public PageObjects()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.Name, Using = "firstname")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "lastname")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Name, Using = "reg_email__")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "reg_email_confirmation__")]
        public IWebElement EmailConfirm { get; set; }

        [FindsBy(How = How.Name, Using = "reg_passwd__")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "day")]
        public IWebElement BirthDay { get; set; }

        [FindsBy(How = How.Id, Using = "month")]
        public IWebElement BirthMonth { get; set; }

        [FindsBy(How = How.Id, Using = "year")]
        public IWebElement BirthYear { get; set; }

        [FindsBy(How = How.Name, Using = "websubmit")]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.ClassName, Using = "uiContextualLayer")]
        public IWebElement SexWarning { get; set; }
    }
}
