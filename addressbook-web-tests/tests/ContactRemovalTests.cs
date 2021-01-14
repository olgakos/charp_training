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
    public class ContactRemovalTest : AuthTestBase //L3_3
    {
        [Test]
        public void TheContactRemovalTest()
        {

            //з8_1 правка начало
            if (!app.Contacts.IsElementPresentByName())
            {
                ContactData contact = new ContactData("Ringo2", "Starr");
                contact.Middlename = "Richard";
                contact.Nickname = "4";
                //список пунктов можно продолжить...

                app.Contacts.CreateContact(contact);
            }

            //з8_1 правка конец


            //app.Contacts.Remove(); //было ранее

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            //app.Contacts.Remove("selected[]");
            app.Contacts.Remove();
            app.Contacts.Wait(TimeSpan.FromSeconds(oldContacts.Count * 4));

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }                  
    }
}
