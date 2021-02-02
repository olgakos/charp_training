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
    public class GroupModificationTests : GroupTestBase //7_2
    {
        [Test]
        public void GroupModificationTest() 
        {

            app.Navigator.GoToGroupsPage();

            if (!app.Groups.IsElementPresentByClassName())
            {
                GroupData group = new GroupData("ABBA");
                group.Header = "ABBA_h";
                group.Footer = "ABBA_f";
                app.Groups.CreateGroup(group);
            }


            GroupData newData = new GroupData("modify zzz");
            newData.Header = null; // т.е поле менять не будем...
            newData.Footer = null; // т.е поле менять не будем...


            List<GroupData> oldGroups = app.Groups.GetGroupList(); //спиок 4_3
            GroupData oldData = oldGroups[0];


            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //4_5

            List<GroupData> newGroups = app.Groups.GetGroupList(); //4_3
            oldGroups[0].Name = newData.Name; //4_3
            oldGroups.Sort(); //4_3
            newGroups.Sort(); //4_3
            Assert.AreEqual(oldGroups, newGroups); //4_3

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }




        }

    }
}

