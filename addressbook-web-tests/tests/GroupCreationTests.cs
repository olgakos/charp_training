﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
//юзинг Селеним переехал в ТБ 2_1
using System.Collections.Generic; //неделя4
using System.IO; //неделя 6_1
using System.Xml; //6_3
using System.Xml.Serialization; //6_3
using Newtonsoft.Json; //6_3


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase //L3_3
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }


        //public static IEnumerable<GroupData> GroupDataFromFile() //6_1
        public static IEnumerable<GroupData> GroupDataFromCvsFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string[] lines = File.ReadAllLines(@"groups.csv");

            foreach (string l in lines)

            {
                string[] parts = l.Split(',');

                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });

            }

            return groups;
        }



        public static IEnumerable<GroupData> GroupDataFromXmlFile() // 6_2 с новым юзингом System.Xml.Serialization
        {

            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));

        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }




        //[Test, TestCaseSource("GroupDataFromFile")] //6_1будет брать данные из файла
        [Test, TestCaseSource("GroupDataFromJsonFile")] //будет брать данные из файла JSON
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }



        /*
         [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("aaa'aaa");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        */

        /* БЫЛО ДО HW 10
        [Test]
        public void GroupCreationTest()
        {

            //подготовка данных
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); // длина списика до
          
            app.Groups.CreateGroup(group);  

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList(); //длина после + новая 
            oldGroups.Add(group);
            oldGroups.Sort(); 
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //app.Auth.LogOut();
        }


       // [Test] //тест на создание группы с пустым именем
       // public void EmptyGroupCreationTest() 
      //  {
//
      //      GroupData group = new GroupData("");
      //      group.Header = "";
      //      group.Footer = "";

      //      List<GroupData> oldGroups = app.Groups.GetGroupList(); // длина списика до
//
      //      app.Groups.CreateGroup(group);
//
       //     Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
//
       //     List<GroupData> newGroups = app.Groups.GetGroupList(); //длина после + новая 
       //     oldGroups.Add(group); //l4_m3
       //     oldGroups.Sort(); //l4_m3
       //     newGroups.Sort(); //l4_m3
       //     Assert.AreEqual(oldGroups, newGroups); //l4_m3
       //                 
       //     //app.Auth.LogOut();
      //  }


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



        /* [Test]  
         public void BadNameGroupCreationTest()
         {
             GroupData group = new GroupData("a'a");
             group.Header = "";
             group.Footer = "";

             List<GroupData> oldGroups = app.Groups.GetGroupList();

             app.Groups.CreateGroup(group);

             Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

             List<GroupData> newGroups = app.Groups.GetGroupList();
             oldGroups.Add(group);
             oldGroups.Sort();
             newGroups.Sort();
             Assert.AreEqual(oldGroups, newGroups);
         }
        */



    }

}
