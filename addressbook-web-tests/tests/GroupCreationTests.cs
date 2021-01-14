using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
//юзинг Селеним переехал в ТБ 2_1


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase //L3_3
    {
        
        [Test]
        public void GroupCreationTest()
        {

            //подготовка данных
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); // длина списика до
          
            app.Groups.CreateGroup(group);  //создание группы

            List<GroupData> newGroups = app.Groups.GetGroupList(); //длина после + новая 
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count); // проверка, что это стааря длина +1
            
            //app.Auth.LogOut();
        }


        [Test]
        public void EmptyGroupCreationTest() //тест на создание группы с пустым именем
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); // длина списика до

            app.Groups.CreateGroup(group);

            List<GroupData> newGroups = app.Groups.GetGroupList(); //длина после + новая 
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count); // проверка, что это стааря длина +1

            //app.Auth.LogOut();
        }



        //было до л4_1
        //        [Test]
        //       public void EmptyGroupCreationTest() //тест на создание группы с пустым именем
        //        {

        //      GroupData group = new GroupData("");
        //        group.Header = "";
        //       group.Footer = "";



        //       app.Navigator.GoToGroupsPage();
        //        //блок из строк создания Г переехал в ГХ 2_4
        //        app.Groups.CreateGroup(group);
        //        app.Auth.LogOut(); //разлогин
        //    }



    }
}
