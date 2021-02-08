using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_test_autoit
{
    public class TestBase
    {
        public ApplicationManager app;


        [OneTimeSetUp]
        //[SetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDown]
        // [TearDown]
        public void stopApplication()
        {
            app.Stop();
        }

    }
}