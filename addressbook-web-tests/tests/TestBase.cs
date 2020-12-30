using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase //BN! ТБ публичный класс, чтобы видели другие 2_1
    {
        //ссылка на место хранения ссылок на помощников вместо них самих
       
        protected ApplicationManager app;

        [SetUp]
        public void SetupAplicationmanager() //L3_3 переименвали
        {
            app = ApplicationManager.GetInstance(); //3_2
            //app.Auth.Login(new AccountData("admin", "secret")); уехал в 3_3
        }


       // [TearDown]уехало в ТСФ 3_2


    }
}
