using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testing
{
    class NunitTest
        
    {
        IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void ExecuteTest()
        {
            //Day
            IWebElement day = driver.FindElement(By.Id("day"));
            //create select element object 
            var selectElement = new SelectElement(day);

            //select by index(day 10)
            selectElement.SelectByIndex(10);
            Console.WriteLine("Selected day==:"+20);
            Thread.Sleep(6000);

            IWebElement title = driver.FindElement(By.Id("month"));

            IList<IWebElement> DropdownList = driver.FindElements(By.XPath("//select/option"));
            int countmonth = DropdownList.Count();

            for (int i = 0; i < countmonth; i++)
            {
                if (DropdownList[i].Text == "Jun")
                {
                    DropdownList[i].Click();
                    break;
                }
            }

            //Year

            SelectElement year = new SelectElement(driver.FindElement(By.Id("year")));
            //var year = new SelectElement(driver.FindElement(By.Id("year")));
            year.SelectByValue("2012");
        }
        [Test]
        public void AlertTest()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/delete_customer.php");
            driver.Manage().Window.Maximize();

            IWebElement customerId = driver.FindElement(By.Name("cusid"));
            customerId.SendKeys("53920");
            IWebElement submitB = driver.FindElement(By.Name("submit"));
            submitB.Click();

            // Switching to Alert        
            IAlert alert = driver.SwitchTo().Alert();

            Thread.Sleep(6000);
            // Capturing alert message.    
            String alertMessage = driver.SwitchTo().Alert().Text;
            Console.WriteLine("Alert text is " + alertMessage);

            //Accept alert
            alert.Accept();
            Thread.Sleep(6000);
            alert.Accept();


        }
        [TearDown]
        public void EndTest()
        {
            //driver.Close();
        }
    }
}
