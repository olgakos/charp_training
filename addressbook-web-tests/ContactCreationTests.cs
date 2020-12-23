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
            GoToHomePage(); // на базовый URL
            Login(new AccountData("admin", "secret"));
            InitNewContactCreation();
            ContactData contact = new ContactData("John");
            contact.Lastname = "Lennon";
            FillContactForm(contact);
            SubmitContactCreationButton();
            ReturnToHomePage();
            LogOut();
        }

        
    }
}
