using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
//юзинг Селеним переехал в ТБ 2_1

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        
    [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1); //выбор ч-боксом первой группы из списка
            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupsPage();
            app.Auth.LogOut();
        }
     }
}
