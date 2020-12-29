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
            //залогин теперь в ТБ в SetUp 2_4
            app.Navigator.GoToHome(); //точно-точно перейти на список контактов
            app.Contacts
                .SelectContact() // Номер строки для удаления не был указан!
                .RemoveContact() // кнопка "удалить (контакт)"
                .ConfirmRemoval(); // алерт + подтверждение
            //driver.FindElement(By.LinkText("Logout")).Click();
        }                  
    }
}
