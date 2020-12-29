//L 2_3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        //этот блок мз ТБ. в АМ сразу после class1
        protected IWebDriver driver;
        //private StringBuilder verificationErrors; (удали рудимент 2_3)
        protected string baseURL;
        private bool acceptNextAlert = true;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        //конструктор:
        public ApplicationManager()
        {
        
            //на 2_4 13.42 фикс в этом месте
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            //verificationErrors = new StringBuilder(); (удали рудимент 2_3)

            loginHelper = new LoginHelper(this); //инициализация метода в СетАп
            navigator = new NavigationHelper(this, baseURL); //инициализация метода в СетАп
            groupHelper = new GroupHelper(this); //инициализация метода в СетАп
            contactHelper = new ContactHelper(this);
        }


        public IWebDriver Driver 
        {
            get
            {
                return driver;
            }
         }

        //новый метод для пеоеноса сюда Stop
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }




        //новое из L2-3 4^16

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }


        public GroupHelper Groups

        {
            get
            {
                return groupHelper;
            }
        }

        public  ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }


    }
}
