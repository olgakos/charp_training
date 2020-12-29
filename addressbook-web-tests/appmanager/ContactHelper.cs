﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase

    {

        public ContactHelper(IWebDriver driver)
            : base (driver)
        { }


        public ContactHelper CreateContact(ContactData contact) 
        {

            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreationButton();
            ReturnToHomePage();
            return this;
        }






        public ContactHelper ReturnToHomePage() //ссылка на страницу Контактов
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }



        public ContactHelper SubmitContactCreationButton() //кноп.подтвердить создание контакта
        {
            //SubmitContactCreationButton
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            //FillContactForm
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            //InitNewContactCreation
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }



        public ContactHelper SelectContact()
        {
            //!!НЕ ЯСНО, КАК ОН ВЫБРАЛ ЧЕКБОКС? Выбрал ли вообще или проскочил?
            //driver.FindElement(By.Id("87")).Click();
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }


        public ContactHelper RemoveContact() //кнопк. удалить контакт
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ConfirmRemoval()  // алерт + подтверждение действия
        {
            driver.SwitchTo().Alert().Accept(); //закрыть окошко
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            //acceptNextAlert = true; //не понятно что это. Что-то про алерт?
            // ERROR: Caught exception [unknown command [CloseAlertAndGetItsText]]
            return this;
        }
    }
}
