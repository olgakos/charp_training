using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis_tests_project.Mantis;
using NUnit.Framework;

namespace mantis_tests_project
{
    class ProjectRemovalTest : AuthTestBase
    {

        [Test]
        public void ProjectRemoveTest()
        {

            /* так было для ДЗ20
            //проверка на "Для теста удаления проектов реализуйте также проверку предусловий (что хотя бы один проект присутствует в приложении)."
            app.ManagementMenu.GoToManagePage();
            app.ManagementMenu.GoToManageProjectTab();

            if (app.ManagementProject.GetProjectList().Count == 0)
            {
                string project = "projectTest";
                app.ManagementProject.Create(project);
                app.ManagementProject.Wait(TimeSpan.FromSeconds(7));//ожидание
            }
            //конец проверки

            List<string> oldProjects = app.ManagementProject.GetProjectList();

            app.ManagementProject.Remove();

            List<string> newProjects = app.ManagementProject.GetProjectList();

            */


            AccountData account = new AccountData("administrator", "root");

            if (app.API.GetProjectList(account).Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "testProject"
                };

                app.API.CreateProject(account, project);
            }

            app.ManagementMenu.GoToManagePage();
            app.ManagementMenu.GoToManageProjectTab();

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.ManagementProject.Remove();

            List<ProjectData> newProjects = app.API.GetProjectList(account);




            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }


    }
}
