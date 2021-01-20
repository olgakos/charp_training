using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase


    {
        [Test]
        public void TestContactInformationFromTable()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }


         //hw12
        [Test]
        public void TestContactInformationFromDetails()

        {
            string fromDetailsText = app.Contacts.GetContactInformationFromDetails();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            string fromFormText = "";

           
            if (!string.IsNullOrWhiteSpace(fromForm.Firstname))
            {
                fromFormText = fromForm.Firstname;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.Lastname))
            {
                fromFormText += " " + fromForm.Lastname;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.Address))
            {
                fromFormText += "\r\n" + fromForm.Address;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.HomePhone))
            {
                fromFormText += "\r\n\r\n" + "H: " + fromForm.HomePhone;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.MobilePhone))
            {
                fromFormText += "\r\n" + "M: " + fromForm.MobilePhone;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.WorkPhone))
            {
                fromFormText += "\r\n" + "W: " + fromForm.WorkPhone;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.Email))
            {
                fromFormText += "\r\n\r\n" + fromForm.Email;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.Email2))
            {
                fromFormText += "\r\n" + fromForm.Email2;
            }
            if (!string.IsNullOrWhiteSpace(fromForm.Email3))
            {
                fromFormText += "\r\n" + fromForm.Email3;
            }

            Assert.AreEqual(fromDetailsText, fromFormText);
        }
    }
}
