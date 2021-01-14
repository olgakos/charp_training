using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//using System.Collections.Generic; //4_1 List

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase //L3_3
    {
        [Test]
        public void GroupModificationTest() 
        {

            //начало 8_1 правки //начало: поверка, что имеется хотя бы одна группа в наличии, а если нету то создать ее
            app.Navigator.GoToGroupsPage();

            if (!app.Groups.IsElementPresentByClassName())
            {
                GroupData group = new GroupData("ABBA");
                group.Header = "ABBA_h";
                group.Footer = "ABBA_f";
                app.Groups.CreateGroup(group);
            }
            //конец 8_1конец^ поверка, что имеется хотя бы одна группа в наличии, а если нету то создать ее




            GroupData newData = new GroupData("modify zzz");
            newData.Header = null; // т.е поле менять не будем...
            newData.Footer = null; // т.е поле менять не будем...


            List<GroupData> oldGroups = app.Groups.GetGroupList(); //спиок 4_3

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList(); //4_3
            oldGroups[0].Name = newData.Name; //4_3
            oldGroups.Sort(); //4_3
            newGroups.Sort(); //4_3
            Assert.AreEqual(oldGroups, newGroups); //4_3


        }


    }
}

