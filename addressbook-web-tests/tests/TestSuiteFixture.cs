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

        //public static ApplicationManager app; //поле АМ (из IAM) больше не надо Л3_2

        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance(); //создали АМ
            app.Navigator.GoToHomePage(); // на базовый URL
            app.Auth.Login(new AccountData("admin", "secret"));
        }


        //[TearDown] 3_2 удалили

    }
}
