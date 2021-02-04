using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {


            ContactData newContact = new ContactData("firstnameTest", "lastnameTest");
            newContact.Address = "Адрес";
            newContact.HomePhone = "ДомТел";
            newContact.MobilePhone = "МобТел";
            newContact.WorkPhone = "ВоркТел";
            newContact.Email = "Мыло1";
            newContact.Email2 = "Мыло2";
            newContact.Email3 = "Мыло3";


            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresentByClassName())
            {
                GroupData newGroup = new GroupData("ГрупДейта");
                newGroup.Header = "Хедер";
                newGroup.Footer = "Футер";
                app.Groups.CreateGroup(newGroup);
            }

            app.Navigator.GoToHomePage();
            if (!app.Contacts.IsElementPresentByName())
            {
                app.Contacts.CreateContact(newContact);
            }



            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            IList<ContactData> contactsOutOfGroup = ContactData.GetAll().Except(group.GetContacts()).ToList();

            if (contactsOutOfGroup.Count == 0)
            {
                app.Contacts.CreateContact(newContact);
                List<ContactData> newContacts = ContactData.GetAll();
                newContact.Id = newContacts.Last().Id;
                app.Contacts.AddContactToGroup(newContact, group);
                oldList.Add(newContact);
            }
            else
            {
                ContactData contact = ContactData.GetAll().Except(oldList).First();
                app.Contacts.AddContactToGroup(contact, group);
                oldList.Add(contact);
            }

            List<ContactData> newList = group.GetContacts();
            //oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
