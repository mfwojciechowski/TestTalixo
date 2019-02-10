using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestTalixo
{
    public class SeleniumSet

    {
        static int i = 1;
        public static void EnterText(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
            {
                driver.FindElement(By.Id(element)).SendKeys(value + Keys.Tab);
            }

            if (elementType == "Name")
            {
                driver.FindElement(By.Name(element)).SendKeys(value + Keys.Tab);
                
            }
            
        }

        public static void Click(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                driver.FindElement(By.Name(element)).Click();

            if (elementType == "Name")
                driver.FindElement(By.Name(element)).Click();

        }

        public static void ClearText(IWebDriver driver, string element, string elementType)
        {
            try
            {
                driver.FindElement(By.Id(element)).Clear();

            }
            catch (NoSuchElementException)
            {
                
            }

        }
        

        public static void Error(IWebDriver driver)
        {
            try
            {
                string error = driver.FindElement(By.ClassName("errorlist")).FindElement(By.TagName("li")).Text;
                Console.WriteLine("Login error # "+i+" text: "+ error);
                

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Login successful");
            }
            i++;
        }

    }
}