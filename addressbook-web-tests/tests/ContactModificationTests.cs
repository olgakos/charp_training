using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic; //не забывай вставлять в тесты где есть <List!!> 4_1
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase //L3_3
    {
        [Test]
        public void ContactModificationTest()
        {


            //з8_1 правка начаало
            if (!app.Contacts.IsElementPresentByName())
            {
                ContactData contact = new ContactData("Ringo2", "Starr");
                contact.Middlename = "Richard";
                contact.Nickname = "4";


                app.Contacts.CreateContact(contact);
            }
            //з8_1 правка конец



            ContactData newData = new ContactData("Ringo", "Starr");
            newData.Middlename = null; // т.е поле менять не будем...
            newData.Nickname = null; // т.е поле менять не будем...



            List<ContactData> oldContacts = app.Contacts.GetContactList(); //hw9

            app.Contacts.Modify(newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount()); //hw10

            List<ContactData> newContacts = app.Contacts.GetContactList(); //hw9
            oldContacts[0].Firstname = newData.Firstname; //hw9
            oldContacts[0].Lastname = newData.Lastname; //hw9
            oldContacts.Sort(); //hw9
            newContacts.Sort(); //hw9
            Assert.AreEqual(oldContacts, newContacts); //hw9


        }
    }
}
