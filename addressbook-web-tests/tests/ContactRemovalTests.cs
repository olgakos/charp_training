using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTest : AuthTestBase //L3_3
    {
        [Test]
        public void TheContactRemovalTest()
        {
            //залогин теперь в ТБ в SetUp 2_4
            //

            //з8_1 правка начало
            if (!app.Contacts.IsElementPresentByName())
            {
                ContactData contact = new ContactData("Ringo2");
                contact.Middlename = "Richard";
                contact.Lastname = "Starr";

                app.Contacts.CreateContact(contact);
            }

            //з8_1 правка конец



            app.Contacts.Remove();
            //app.Navigator.GoToHome(); //точно-точно перейти на список контактов
            //app.Contacts
                //.SelectContact() // Номер строки для удаления не был указан!
                //.RemoveContact() // кнопка "удалить (контакт)"
               // .ConfirmRemoval(); // алерт + подтверждение
            //driver.FindElement(By.LinkText("Logout")).Click();
        }                  
    }
}
