using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic; //4_1 List
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase //L3_3
    {
       [Test]
        public void TheContactCreationTest()
        {
            //залогин теперь в ТБ в SetUp 2_4
            ContactData contact = new ContactData("John", "Lennon");
            contact.Middlename = "Winston";
            contact.Nickname = "first";

        List<ContactData> oldContacts = app.Contacts.GetContactList();
            
            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //app.Auth.LogOut();
        }





        [Test]
        public void EmptyContactCreationTest()
        {
            //залогин теперь в ТБ в SetUp 2_4
            ContactData contact = new ContactData("", "");
            contact.Middlename = "";
            contact.Nickname = "";
            //блок из строк создания К переехал в КХ 2_4

            app.Contacts.CreateContact(contact);
            //app.Auth.LogOut();
        }

    }
}
