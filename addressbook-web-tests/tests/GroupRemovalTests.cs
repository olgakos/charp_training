using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic; //4_1 List
using NUnit.Framework;
//юзинг Селеним переехал в ТБ 2_1

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase //L3_3
    {
        
    [Test]
        public void GroupRemovalTest()
        {
            //app.Navigator.GoToGroupsPage();

            //начало: поверка, что имеется хотя бы одна группа в наличии, а если нету то создать ее
            if (!app.Groups.IsElementPresentByClassName())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ABBA_h";
                group.Footer = "ABBA_f";
                app.Groups.CreateGroup(group);
            }
            //конец поверка, что имеется хотя бы одна группа в наличии, а если нету то создать ее

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //4_3

            app.Groups.Remove(0);  //4_3  Почему падает, если занченеи 0??? (4_3)

           List<GroupData> newGroups = app.Groups.GetGroupList(); //4_3

            oldGroups.RemoveAt(0); //4_3  Почему падает, если занченеи 0??? (4_3)
            Assert.AreEqual(oldGroups, newGroups); //4_3

            //app.Auth.LogOut();
        }
     }
}
