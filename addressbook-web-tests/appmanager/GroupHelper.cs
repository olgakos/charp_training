using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase

    {

        public GroupHelper(ApplicationManager manager)
            : base (manager)
        { 
        }


        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreationButton();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage(); 
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }


        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }



        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();

            //SelectGroup(p); //выбор ч-боксом передаваемого занчения? 2_5 03.57 из списка
            SelectGroup(p); //выбор ч-боксом первой группы из списка
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }



        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }


           public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            //driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click(); //было в л3
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }


        public GroupHelper InitNewGroupCreation()
        {
            //InitNewGroupCreation
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper FillGroupForm(GroupData group)
        {
            //FillGroupForm
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }

    //Type 3_1 уехал в ТБ


        public GroupHelper SubmitGroupCreationButton()
        {
            //SubmitGroupCreationButton
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        //кажатие кнопки EDIT в группах...
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }


        //кажатие кнопки Updte в группах...
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }



    }
}
