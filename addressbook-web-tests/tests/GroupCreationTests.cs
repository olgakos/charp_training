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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData ("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("nnn");
            group.Header = "hhh";
            group.Footer = "fff";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreationButton();
            app.Groups.ReturnToGroupsPage();
            app.Auth.LogOut();
        }

                                   
    }
}
