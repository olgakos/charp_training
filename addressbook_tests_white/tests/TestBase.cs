﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    public class TestBase
    {
        public ApplicationManager app;

        [OneTimeSetUp]
        //[TestFixtureSetUp]
       // [SetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDown]
        //[TestFixtureTearDown]
        //[TearDown]
        public void stopApplication()
        {
            app.Stop();
        }

    }
}