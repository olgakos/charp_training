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

            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            //блок из строк создания Г переехал в ГХ 2_4          
            app.Groups.CreateGroup(group);
            app.Auth.LogOut();
        }



        public void EmptyGroupCreationTest() //тест на создание группы с пустым именем
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigator.GoToGroupsPage();
            //блок из строк создания Г переехал в ГХ 2_4
            app.Groups.CreateGroup(group);
            
            app.Auth.LogOut();
        }
    }
}
