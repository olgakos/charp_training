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
        public void SetupTest()
        {
            //инициализируем АМ
            app = new ApplicationManager();
            app.Navigator.GoToHomePage(); // на базовый URL
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }





        








        

    }
}
