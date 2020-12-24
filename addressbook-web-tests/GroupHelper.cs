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
    public class GroupHelper
    {


        //Это Конструктор, в поле котрого хранится ссылка на драйвер барузера
        private IWebDriver driver; //поле Драйвер
        public GroupHelper(IWebDriver driver)
        { //конструктор Драйвер
            this.driver = driver;
        }


        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }



        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }








        public void InitNewGroupCreation()
        {
            //InitNewGroupCreation
            driver.FindElement(By.Name("new")).Click();
        }



        public void FillGroupForm(GroupData group)
        {
            //FillGroupForm
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }


        public void SubmitGroupCreationButton()
        {
            //SubmitGroupCreationButton
            driver.FindElement(By.Name("submit")).Click();
        }




    }
}
