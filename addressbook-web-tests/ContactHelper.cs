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
    public class ContactHelper
    {

        //Это Конструктор, в поле котрого хранится ссылка на драйвер барузера
        private IWebDriver driver; //поле Драйвер
        public ContactHelper(IWebDriver driver)
        { //конструктор Драйвер
            this.driver = driver;
        }




        public void ReturnToHomePage() //ссылка на страницу Контактов
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }



        public void SubmitContactCreationButton() //кноп.подтвердить создание контакта
        {
            //SubmitContactCreationButton
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        public void FillContactForm(ContactData contact)
        {
            //FillContactForm
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }

        public void InitNewContactCreation()
        {
            //InitNewContactCreation
            driver.FindElement(By.LinkText("add new")).Click();
        }



        public void SelectContact()
        {
            //!!НЕ ЯСНО, КАК ОН ВЫБРАЛ ЧЕКБОКС? Выбрал ли вообще или проскочил?
            //driver.FindElement(By.Id("87")).Click();
            driver.FindElement(By.Name("selected[]")).Click();
        }


        public void RemoveContact() //кнопк. удалить контакт
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }

        public void ConfirmRemoval()  // алерт + подтверждение действия
        {
            driver.SwitchTo().Alert().Accept(); //закрыть окошко
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            //acceptNextAlert = true; //не понятно что это. Что-то про алерт?
            // ERROR: Caught exception [unknown command [CloseAlertAndGetItsText]]
        }




    }
}
