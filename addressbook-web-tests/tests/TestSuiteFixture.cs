using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //rконструкция импортирует классы

namespace WebAddressbookTests
{

    [SetUpFixture]
    public class TestSuiteFixture
    {

        public static ApplicationManager app; //поле АМ (из IAM)

        [SetUp]
        public void InitApplicationManager()
        {
            app = new ApplicationManager(); //создали АМ
            app.Navigator.GoToHomePage(); // на базовый URL
            app.Auth.Login(new AccountData("admin", "secret"));
        }



        [TearDown]
        public void StopApplicationManager()
        {
            app.Stop(); //браузер остановистя 1 раз после выполения ВСЕХ тестов
        }


    }
}
