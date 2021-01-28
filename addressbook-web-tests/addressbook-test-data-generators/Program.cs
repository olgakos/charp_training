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

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }






            if (format == "excel")
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




    }
}
