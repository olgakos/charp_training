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
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.SelectGroup(1); //выбор ч-боксом первой группы из списка
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupsPage();
            loginHelper.LogOut();
        }
     }
}
