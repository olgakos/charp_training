using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            ContactData contact = new ContactData("John");
            contact.Middlename = "Winston";
            contact.Lastname = "Lennon";
            app.Contacts.CreateContact(contact);
            //app.Auth.LogOut();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            //залогин теперь в ТБ в SetUp 2_4
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";
            //блок из строк создания К переехал в КХ 2_4

            app.Contacts.CreateContact(contact);
            //app.Auth.LogOut();
        }

    }
}
