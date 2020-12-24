using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper
    {
        
            private IWebDriver driver; //поле Драйвер
            private string baseURL;

        public NavigationHelper (IWebDriver driver, string baseURL)//конструктор Драйвер
            {
                this.driver = driver;
                this.baseURL = baseURL;
            }




        public void GoToHomePage() //стартовая страница приложения
        {
            //OpenHomePage
            driver.Navigate().GoToUrl(baseURL);
        }




        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }




        public void GoToHome() //Точно попасть на страницу "Контакты"
        {
            driver.FindElement(By.LinkText("home")).Click();
        }






    }
}
