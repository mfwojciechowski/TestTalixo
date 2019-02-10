using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using  OpenQA.Selenium.Firefox;
using static TestTalixo.SeleniumSet;

namespace TestTalixo
{
    class Program

     
    {
        IWebDriver driver = new ChromeDriver();
        List<string> mails = new List<string>() { "invalid9@mail.com", "jan@o2.pl" };
        static void Main(string[] args)
        {
           
        }

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://talixo.pl/login/?next=/");
            driver.Manage().Window.Maximize();
            Console.WriteLine("Opened URL");
        }

        [Test]
        public void ExecuteTest()
        {
            Console.WriteLine("Doing TEST:");

            foreach (string mail in mails)
            {
                EnterText(driver, "id_email_auth", mail, "Id");
                EnterText(driver, "password", "Test123", "Name");
                Click(driver, "sign-in", "Name");
                Error(driver);
                ClearText(driver, "id_email_auth", "Name");
            }

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Closed Browser");
        }
    }
}
