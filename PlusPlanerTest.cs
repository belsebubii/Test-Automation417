using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusPlanerTest
{
    class PlusPlanerTest
    {
        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            WebDriver.driver = new ChromeDriver();
            WebDriver.driver.Navigate().GoToUrl("http://www.plusplaner.com/");
        }

        [Test]
        public void ExecuteTest()
        {
            PageObject Page = new PageObject();

            if (Page.Username.Enabled == true && Page.Username.Text == "")
            {
                Console.WriteLine("Username textbox is enabled and empty!");
            }
            else
            {
                Console.WriteLine("Username textbox isn't enabled or empty!");
            }

            if (Page.Password.Enabled == true && Page.Password.Text == "")
            {
                Console.WriteLine("Password textbox is enabled and empty!");
            }
            else
            {
                Console.WriteLine("Password textbox isn't enabled or empty!");
            }

            if (Page.Button.Enabled == true)
            {
                Console.WriteLine("Button is enabled!");
            }
            else
            {
                Console.WriteLine("Button isn't enabled!");
            }

            Page.Button.Click();

            if (Page.Warning.Displayed == true)
            {
                Console.WriteLine("\"Korisničko ime je obvezno. Lozinka je obvezna.\" message is displayed!");
            }
            else
            {
                Console.WriteLine("\"Korisničko ime je obvezno. Lozinka je obvezna.\" message isn't displayed!");
            }

            Page.Username.SendKeys("user21");
            Page.Button.Click();

            if (Page.Warning.Displayed == true)
            {
                Console.WriteLine("\"Lozinka je obvezna.\" message is displayed!");
            }
            else
            {
                Console.WriteLine("\"Lozinka je obvezna.\" message isn't displayed!");
            }

            Page.Username.Clear();
            Page.Password.SendKeys("Pass21");
            Page.Button.Click();

            if (Page.Warning.Displayed == true)
            {
                Console.WriteLine("\"Korisničko ime je obvezno.\" message is displayed!");
            }
            else
            {
                Console.WriteLine("\"Korisničko ime je obvezno.\" message isn't displayed!");
            }

            Page.Username.SendKeys("user21");
            Page.Password.SendKeys("pass21");
            Page.Button.Click();

            if (Page.Warning.Displayed == true)
            {
                Console.WriteLine("\"Neispravno korisničko ime ili lozinka.\" message is displayed!");
            }
            else
            {
                Console.WriteLine("\"Neispravno korisničko ime ili lozinka.\" message isn't displayed!");
            }

            Page.Password.Clear();
            Page.Password.SendKeys("Pass21");
            Page.Button.Click();

            if (WebDriver.driver.Url == "http://www.plusplaner.com/raspored")
            {
                Console.WriteLine("This is \"Raspored\" page!");
            }
            else
            {
                Console.WriteLine("This isn't \"Raspored\" page!");
            }
        }

        [TearDown]
        public void CleanUp()
        {
            WebDriver.driver.Close();
        }
    }

    class WebDriver
    {
        public static IWebDriver driver { get; set; }
    }

    class PageObject
    {
        public PageObject()
        {
            PageFactory.InitElements(WebDriver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "action")]
        public IWebElement Button { get; set; }

        [FindsBy(How = How.ClassName, Using = "red-text")]
        public IWebElement Warning { get; set; }
    }
}
