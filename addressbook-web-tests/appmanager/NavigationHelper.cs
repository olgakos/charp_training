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
    public class NavigationHelper : HelperBase

    { 
           private string baseURL;

    public NavigationHelper(ApplicationManager manager, string baseURL)
        : base(manager)
            {
                this.baseURL = baseURL;
            }




        public void GoToHomePage() //стартовая страница приложения
        {
            //OpenHomePage

            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
            //driver.Navigate().GoToUrl(baseURL + "/addressbook/"); не поняла L3_5 03.55
        }




        public void GoToGroupsPage()
        {
            //L3_4 «Если на странице уже есть адрес такой-то + есть кнопка «НьюГрупп», то делать ничего не надо. ИНАЧЕ, то надо нажать и перейти»

            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return; 
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }




        public void GoToHome() 
        {
            //Точно ли попали на страницу "Контакты"?
            //Проверка, что ссли мы уже там...
            if (driver.Url == baseURL + "/addressbook/"
                //&& IsElementPresent(By.title(""Sort on “First name""))
                && IsElementPresent(By.LinkText("First name"))
                )
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }


    }
}
