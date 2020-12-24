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
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToHome(); //точно-точно перейти на список контактов
            contactHelper.SelectContact(); // Номер строки для удаления не был указан!
            contactHelper.RemoveContact(); // кнопка "удалить (контакт)"
            contactHelper.ConfirmRemoval(); // алерт + подтверждение
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

                
    }
}
