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
            navigator.GoToHomePage(); // на базовый URL
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitNewContactCreation();
            ContactData contact = new ContactData("John");
            contact.Lastname = "Lennon";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreationButton();
            contactHelper.ReturnToHomePage();
            loginHelper.LogOut();
        }

        
    }
}
