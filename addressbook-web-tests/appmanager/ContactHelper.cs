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
    public class ContactHelper : HelperBase

    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        { }



        public ContactHelper CreateContact(ContactData contact) 
        {

            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreationButton();
            ReturnToHomePage();
            return this;
        }



        public ContactHelper Modify(ContactData contact)
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact();
            InitContactModification();
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов

            return this;
        }







        public ContactHelper Remove()
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact(); // Номер строки для удаления не был указан!
            RemoveContact(); // кнопка "удалить (контакт)"
            ConfirmRemoval(); // алерт + подтверждение
            manager.Navigator.GoToHome();
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
            //FillContactForm 3_1
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);

            return this;
        }
        //FillContactForm(part2) 3_1
        private void Type(By locator, string text)
        {
            driver.FindElement(locator).Click();
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
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





        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }


        //кажатие кнопки EDIT в контактах...
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            //contactCache = null; ....

            return this;
        }






    }
}
