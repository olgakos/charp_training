using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase //L3_3
    {
        [Test]
        public void GroupModificationTest() 
        {
            GroupData newData = new GroupData("modify zzz");
            newData.Header = null; // т.е поле менять не будем...
            newData.Footer = null; // т.е поле менять не будем...

            app.Groups.Modify(1, newData);
        }


    }
}

