using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTest : TestBase
    {
       

        [Test]
        public void TheContactRemovalTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToHome();
            SelectContact();
            RemoveContact();
            ConfirmRemoval();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

                
    }
}
