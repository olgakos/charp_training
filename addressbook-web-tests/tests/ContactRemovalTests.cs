using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic; //не забывай вставлять в тесты где есть <List!!>
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase //L3_3
    {
        [Test]
        public void ContactRemovalTest()
        {

            //з8_1 правка начало
            if (!app.Contacts.IsElementPresentByName())
            {
                ContactData contact = new ContactData("Ringo2", "Starr");
                contact.Middlename = "Richard";
                //contact.Nickname = "4";
                //contact.Title = "Title";
                //contact.Company = "Company";
                contact.Address = "ddress";
                contact.HomePhone = "HomePhone";
                contact.MobilePhone = "MobilePhone";
                contact.WorkPhone = "WorkPhone";
                //contact.Fax = "123";
                contact.Email = "ppp";
                contact.Email2 = "aaa";
                contact.Email3 = "ddd";
                //contact.Homepage = "ccc";
                //contact.Address2 = "bbb";
                //contact.Home2 = "kkk";
                //contact.Notes = "lll";
                //contact.Birthday.Day = "1";
                //contact.Birthday.Month = "Jule";
                //contact.Birthday.Year = "1940";
                //contact.Anniversary.Day = "7";
                //contact.Anniversary.Month = "Jule";
                //contact.Anniversary.Year = "2021";

                app.Contacts.CreateContact(contact);
            }

            /*до HW16
            //з8_1 правка конец
                        //app.Contacts.Remove(); //было ранее11
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            //app.Contacts.Remove("selected[]");
            app.Contacts.Remove();
            //app.Contacts.Wait(TimeSpan.FromSeconds(oldContacts.Count * 4)); ; //лишняя строка
            */


            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            //app.Contacts.Remove();
            app.Contacts.Remove("selected[]");
            app.Contacts.Remove(toBeRemoved);
            //app.Contacts.Wait(TimeSpan.FromSeconds(oldContacts.Count * 4)); ; //лишняя строка


            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }                  
    }
}
