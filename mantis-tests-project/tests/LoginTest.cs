﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests_project
{
    [TestFixture]
    //[SetUp]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {



            //action
            AccountData account = new AccountData("administrator", "root");
            app.Auth.Login(account);

            app.Auth.Logout();

            ////verification
            //Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
    }
}