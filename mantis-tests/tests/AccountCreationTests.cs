using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Web; //м10л1



namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {

        [TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser5",
                Password = "password",
                Email = "testuser5@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null) //удаляем ЕСЛИ есть что удалять
            {
                app.Admin.DeleteAccount(existingAccount);
            }

            //app.Admin.DeleteAccount(account);
            app.Registration.Register(account); //регитсрация аккаунта
        }

        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");

        }

    }
}
