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

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        //private bool acceptNextAlert = true; // ломает КМТ?
       
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        //конструктор:
        private ApplicationManager()
        {
        
            //на 2_4 13.42 фикс в этом месте
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3); ///hw9 фикс

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
                newInstance.driver.Url = "http://localhost/mantisbt-1.2.17/login_page.php"; // базовый URL перененесли сюда в 3_3 из ТФС
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
     


    }
}
