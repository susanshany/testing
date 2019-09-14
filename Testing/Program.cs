using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();

            //Day
            IWebElement day = driver.FindElement(By.Id("day"));
            //create select element object 
            var selectElement = new SelectElement(day);

            //select by index(day 10)
            selectElement.SelectByIndex(10);

            //Month

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
            year.SelectByValue("2012");

            driver.Close();
        }

      
        
    }
}
