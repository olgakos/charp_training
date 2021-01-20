using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //l5_4
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        { }




        public ContactHelper CreateContact(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreationButton();
            ReturnToHomePage();
            return this;
        }


        //v ???
        public ContactHelper Remove()
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact(); // Номер строки для удаления не был указан!
            RemoveContact(); // кнопка "удалить (контакт)" +  алерт + подтверждение
            //ConfirmRemoval(); // алерт + подтверждение
            manager.Navigator.GoToHome();

            return this;
        }

        public ContactHelper Modify(ContactData contact)
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact();
            InitContactModification(0); //hw 11 добавлен 0
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов

            return this;
        }



        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()

        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            }

            return new List<ContactData>(contactCache);
        }





        /* неудачный 
        public ContactHelper Remove(string v)
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact(v); // Номер строки для удаления не был указан!
            RemoveContact(); // кнопка "удалить (контакт)"
            ConfirmRemoval(); // алерт + подтверждение
            manager.Navigator.GoToHome();

            return this;
        }
        */



        public ContactHelper ReturnToHomePage() //ссылка на страницу Контактов
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }




        public ContactHelper SubmitContactCreationButton() //кноп.подтвердить создание контакта
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }




        //FillContactForm 3_1 сильно сокращено...
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            //список можно продолжить...
            return this;
        }
        //Type 3_1 уехал в ТБ 




        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }



        // public ContactHelper SelectContact(string v) //неудачный hw9
        public ContactHelper SelectContact() //hw9
        {
            //!!НЕ ЯСНО, КАК ОН ВЫБРАЛ ЧЕКБОКС? Выбрал ли вообще или проскочил?
            //driver.FindElement(By.Id("87")).Click();
            driver.FindElement(By.Name("selected[]")).Click(); //было до ДЗ9
            //driver.FindElement(By.Name(v)).Click();  //неудачный ДЗ9
            return this;
        }




        public ContactHelper RemoveContact() //нажать кнопк. удалить контакт + согласие
        {
            acceptNextAlert = false; //алерт сейчас НЕ открыт (true)
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click(); //нашли-нажали delete
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            driver.SwitchTo().Alert().Accept(); //new hw10 закрыть окно подтвержления удаления 
            driver.FindElement(By.CssSelector("div.msgbox")); //new hw10 подождать сообщения об успешном удалении контакта 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1); //ожидлание
            contactCache = null;
            return this;
        }


        /*
        public ContactHelper ConfirmRemoval()  // алерт + подтверждение действия
        {
            driver.SwitchTo().Alert().Accept(); //закрыть окошко
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            acceptNextAlert = true; //закрыть окошко
            // ERROR: Caught exception [unknown command [CloseAlertAndGetItsText]]

            //acceptNextAlert = true; //закрыть окошко
            //driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            driver.FindElement(By.CssSelector("div.msgbox"));
            contactCache = null;
            return this;
        }

        */



        /* было ДО нед5
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click(); 
            return this; 
        }
        */

        //нед5
        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]  //нашли столбец7
                .FindElement(By.TagName("a")).Click(); //клик по кнопке Edit
        }




        //кажатие кнопки EDIT в контактах...
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            //driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            contactCache = null;

            return this;
        }



        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }



        //нед6-2
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text; //номер столбца "все почты" WH11
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones, //все почты WH11
                AllEmail = allEmail //все почты WH11
            };
        }






        //нед6
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);


            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

        }
    }
}