//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;//удали
using System.Linq;//удали
using NUnit.Framework;


namespace mantis_tests_project
{

    public class ProjectCreatingTest : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {

            AccountData account = new AccountData("administrator", "root");
            ProjectData project = new ProjectData()
            {
                Name = "project" + Guid.NewGuid()
            };


            app.ManagementMenu.GoToManagePage();
            app.ManagementMenu.GoToManageProjectTab();

            //List<ProjectData> = app.API.GetProjectList(account);
            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.ManagementProject.Create(project.Name);
            app.ManagementProject.Wait(TimeSpan.FromSeconds(7));//ждем


            //List<string> newProjects = app.ManagementProject.GetProjectList();
            List<ProjectData> newProjects = app.API.GetProjectList(account);
            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }

}
