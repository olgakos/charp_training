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

        /*
        public ContactHelper Remove(string v)
        {
            SelectContact(v);
            RemoveContact();
            return this;
        }


        //до HW16
       
        public ContactHelper Remove()
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact(); // Номер строки для удаления не был указан!
            RemoveContact(); // кнопка "удалить (контакт)" +  алерт + подтверждение
            //ConfirmRemoval(); // алерт + подтверждение
            manager.Navigator.GoToHome();
            return this;
        }
        */


        public ContactHelper Remove(string v)
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact(v);
            RemoveContact();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact(contact.Id);
            RemoveContact();
            return this;
        }



        /*
        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            SelectContact();
            InitContactModification(0); //hw 11 добавлен 0
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов

            return this;
        }
        */

        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHome();//точно-точно перейти на список контактов
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
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



       //hw17
        //public ContactHelper SelectContact(string v)
        public ContactHelper SelectContactByName(string v)
        {
            //driver.FindElement(By.Name("selected[]")).Click(); //было до ДЗ9
            driver.FindElement(By.Name(v)).Click();  //неудачный ДЗ9
            return this;
        }
      


        //HW16
        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }




        //NB16
        public ContactHelper RemoveContact() //нажать кнопк. удалить контакт + согласие
        {
            //acceptNextAlert = false; //алерт сейчас НЕ открыт (true)
            //acceptNextAlert = true; //алерт сейчас НЕ открыт (true)
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click(); //нашли-нажали delete
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            driver.SwitchTo().Alert().Accept(); //new hw10 закрыть окно подтвержления удаления 
            driver.FindElement(By.CssSelector("div.msgbox")); //new hw10 подождать сообщения об успешном удалении контакта 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2); //ожидлание
            contactCache = null;
            return this;
        }

 



        /* СТАРАЯ ВЕРСИЯ 
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


        public void InitContactModification(String id)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])['" + id + "']")).Click();
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
            //string allPhones = cells[6].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones, //все почты WH11
                AllEmail = allEmail //все почты WH11
            };
        }


        public string GetContactInformationFromDetails()
        //public ContactData GetContactInformationFromDetails()
        {
            manager.Navigator.GoToHomePage();
            ShowContactDetails(0);
            string detailsText = driver.FindElement(By.Id("content")).Text;
            return detailsText;
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

        //hw12
        //public void ShowContactDetails(int index)
        public void ShowContactDetails(int index1)

        {
            driver.FindElements(By.Name("entry"))[index1]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }


    
        //7_4
        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            //SelectContactToGroup(contact.Id); //wh 17
            SelectContact(contact.Id); //wh 17
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContactToGroup(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }


        //hw17
        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToRemove(group.Name);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void SelectGroupToRemove(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }



    }
}