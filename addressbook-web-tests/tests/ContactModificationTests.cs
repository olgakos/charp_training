using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase //L3_3
    {
        [Test]
        public void ContactModificationTest()
        {

            ContactData newData = new ContactData("Ringo");
            newData.Middlename = null; // т.е поле менять не будем...
            newData.Lastname = null; // т.е поле менять не будем...

            app.Contacts.Modify(newData); 

        }
    }
}
