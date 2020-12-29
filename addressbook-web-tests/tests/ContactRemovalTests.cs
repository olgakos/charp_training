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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToHome(); //точно-точно перейти на список контактов
            app.Contacts.SelectContact(); // Номер строки для удаления не был указан!
            app.Contacts.RemoveContact(); // кнопка "удалить (контакт)"
            app.Contacts.ConfirmRemoval(); // алерт + подтверждение
            //driver.FindElement(By.LinkText("Logout")).Click();
        }                  
    }
}
