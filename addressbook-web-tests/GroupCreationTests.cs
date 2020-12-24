using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
//юзинг Селеним переехал в ТБ 2_1


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("nnn");
            group.Header = "hhh";
            group.Footer = "fff";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreationButton();
            groupHelper.ReturnToGroupsPage();
            loginHelper.LogOut();
        }

                                   
    }
}
