using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase //BN! ТБ публичный класс, чтобы видели другие 2_1
    {
        //ссылка на место хранения ссылок на помощников вместо них самих
       
        protected ApplicationManager app; //7-1
        //public static bool PERFORM_LONG_UI_CHECKS = true; //7_2
        public static bool PERFORM_LONG_UI_CHECKS = false; //7_2

        //[TestFixture]
        //[TestFixtureSetUp]

        public void SetupApplicationManager() //L3_3 переименвали
        {
            app = ApplicationManager.GetInstance(); //3_2
        }


        //HW 13 ниже
        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < l; i++)
            {
                //builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }




    }
}
