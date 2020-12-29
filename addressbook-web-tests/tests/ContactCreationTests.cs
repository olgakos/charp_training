using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
       [Test]
        public void TheContactCreationTest()
        {
            app.Navigator.GoToHomePage(); // на базовый URL
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitNewContactCreation();
            ContactData contact = new ContactData("John");
            contact.Lastname = "Lennon";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreationButton();
            app.Contacts.ReturnToHomePage();
            app.Auth.LogOut();
        }

        
    }
}
