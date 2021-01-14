using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic; //4_1 List
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
                ContactData contact = new ContactData("Ringo2");
                contact.Middlename = "Richard";
                contact.Lastname = "Starr";


                app.Contacts.CreateContact(contact);
            }
            //з8_1 правка конец



            ContactData newData = new ContactData("Ringo");
            newData.Middlename = null; // т.е поле менять не будем...
            newData.Lastname = null; // т.е поле менять не будем...

            app.Contacts.Modify(newData); 

        }
    }
}
