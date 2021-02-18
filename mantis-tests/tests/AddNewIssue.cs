﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis_tests.Mantis;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture] // вручную придаем ему вид Теста, хотя это не тест
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        //public void AddNewIssueTests()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Id = "1"
            };

            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };

            app.API.CreateNewIssue(account, project, issue);
        }
    }
}