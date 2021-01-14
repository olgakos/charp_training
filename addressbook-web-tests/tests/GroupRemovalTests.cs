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


            //начало: поверка, что имеется хотя бы одна группа в наличии, а если нету то создать ее
            if (!app.Groups.IsElementPresentByClassName())
            {
                GroupData group = new GroupData("ABBA");
                group.Header = "ABBA_h";
                group.Footer = "ABBA_f";
                app.Groups.CreateGroup(group);
            }
            //конец проверка, что имеется хотя бы одна группа в наличии, а если нету то создать ее



            app.Groups.Remove(1);
            //app.Navigator.GoToGroupsPage();
            //app.Groups
                //.SelectGroup(1) //выбор ч-боксом первой группы из списка
                //.RemoveGroup()
               // .ReturnToGroupsPage();
            app.Auth.LogOut();
        }
     }
}
