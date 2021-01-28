using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests; //m6l1
using System.IO; //m6l1
using System.Xml; //m6 l2
using System.Xml.Serialization; //m6 l2
using Newtonsoft.Json; //m6 l3
using Formatting = Newtonsoft.Json.Formatting; //m6 l3
using Excel = Microsoft.Office.Interop.Excel; //6_4


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.Out.Write("Hello world!");
            int count = Convert.ToInt32(args[0]);
            //StreamWriter writer = new StreamWriter(args[1]); //6_4
            string filename = args[1]; //6_4
            //string format = args[3];
            string format = args[2];
            string type = args[3]; //для контактов


            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>(); //пустой список для контактов14


            //ГРУППЫ
            if (type == "group")
            {

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }


                if (format == "excel") //эксель для групп
                { writeGroupsToExcelFile(groups, filename); }

                else
                {
                    StreamWriter writer = new StreamWriter(args[1]);
                    if (format == "csv")
                    { writeGroupsToCsvFile(groups, writer); }
                    else if (format == "xml")
                    { writeGroupsToXmlFile(groups, writer); }
                    else if (format == "json")
                    { writeGroupsToJsonFile(groups, writer); }
                    else
                    { System.Console.Out.Write("Unrecognized format " + format); }
                    
                    writer.Close();
                }
            }

            ////

            else if (type == "contact")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(100),
                        HomePhone = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(20),
                        Email2 = TestBase.GenerateRandomString(20),
                        Email3 = TestBase.GenerateRandomString(20)
                    });
                }





                StreamWriter writer = new StreamWriter(args[1]);
                if (format == "xml")
                { writeContactsToXmlFile(contacts, writer); }
                else if (format == "json")
                { writeContactsToJsonFile(contacts, writer); }
                else
                { System.Console.Out.Write("Unrecognized format " + format); }
               
                writer.Close();
            } // конец else if (type == "contact")


            ////

            else
            {
                System.Console.Out.Write("Unrecognized type. Enter group or contact1.");
            }


        }






            static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
                {
                    writer.WriteLine(String.Format("${0},${1},${2}",
                         group.Name, group.Header, group.Footer));
                }
        }





        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        { new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); }

        //Лекция 6.3. Чтение и запись файлов в формате Json
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer) //6_3
        { writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented)); }

        //Лекция 6.4. Чтение и запись файлов в формате Excel
        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;

            foreach (GroupData group in groups) // 6_4 t8-43
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            //m6_l4 t11-40
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }




        //КОНТАКТЫ 14
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        { new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts); }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        { writer.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented)); }


    }
}
