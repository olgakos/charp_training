using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic; //4_1 List
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase //L3_3
    {
       [Test]
        public void ContactCreationTest()

        { }
            public static IEnumerable<ContactData> RandomContactDataProvider()            
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(30),
                    HomePhone = GenerateRandomString(30),
                    MobilePhone = GenerateRandomString(30),
                    WorkPhone = GenerateRandomString(30),
                    Email = GenerateRandomString(30),
                    Email2 = GenerateRandomString(30),
                    Email3 = GenerateRandomString(30)
                });
            }

            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }



        /*

        {
            //залогин теперь в ТБ в SetUp 2_4
            ContactData contact = new ContactData("John", "Lennon");
            contact.Middlename = "Winston";
            contact.Nickname = "first";

        List<ContactData> oldContacts = app.Contacts.GetContactList();
            
            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount()); //hw10

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


        */

    }
}
