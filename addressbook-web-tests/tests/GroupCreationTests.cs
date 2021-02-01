using System;
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
using Excel = Microsoft.Office.Interop.Excel; //6_4
using System.Linq; //7_1
 

namespace WebAddressbookTests
{
    [TestFixture]
    //blic class GroupCreationTests : AuthTestBase //L3_3
    public class GroupCreationTests : GroupTestBase //L7_2
    
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
        public static IEnumerable<GroupData> GroupDataFromCsvFile() //fix
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

        public static IEnumerable<GroupData> GroupDataFromJsonFile() // 6_3
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }






        //эксель
        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;

            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }

            wb.Close();
            app.Visible = false;
            app.Quit();

            return groups;
        }



        //[Test, TestCaseSource("GroupDataFromFile")] //6_1будет брать данные из файла
        [Test, TestCaseSource("GroupDataFromJsonFile")] //будет брать данные из файла JSON
        //[Test, TestCaseSource("GroupDataFromExcelFile")] //будет брать данные из файла Эксель


        public void GroupCreationTest(GroupData group)
        {
            //List<GroupData> oldGroups = app.Groups.GetGroupList(); 
            List<GroupData> oldGroups = GroupData.GetAll(); //7_2

            app.Groups.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


        [Test] //7_1
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }



        /*
         [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("aaa'aaa");
            group.Header = "";
            group.Footer = "";

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
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
