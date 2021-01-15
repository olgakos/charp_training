//L 2_3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //L3_2
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
        //private bool acceptNextAlert = true; (закомтено при попытке КМТ)

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
       
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        //конструктор:
        private ApplicationManager()
        {
        
            //на 2_4 13.42 фикс в этом месте
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            //verificationErrors = new StringBuilder(); (удали рудимент 2_3)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3); ///hw9 фикс

            loginHelper = new LoginHelper(this); //инициализация метода в СетАп
            navigator = new NavigationHelper(this, baseURL); //инициализация метода в СетАп
            groupHelper = new GroupHelper(this); //инициализация метода в СетАп
            contactHelper = new ContactHelper(this);
        }

         ~ApplicationManager() //3_2 код останавливающйи браузер МОДИФ.ФИДИМОСТИ ДЕСТРУКТОРУ НЕ НУЖЕН!

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




        public static ApplicationManager GetInstance() //L3_2
            //"ЕСЛИ поле инстанс - ноль, надо созать АМ. ИНАЧЕ ничего. L3_2
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage(); // на базовый URL перененесли сюда в 3_3 из ТФС
                app.Value = newInstance;
            }
            return app.Value;
        }



        public IWebDriver Driver 
        {
            get
            {
                return driver;
            }
         }

        //метод Stop удален 3_2 и код переехал выше




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
