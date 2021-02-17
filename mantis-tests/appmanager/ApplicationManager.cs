﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public AdminHelper Admin { get; set; } //m10 l1 проперти

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            //baseURL = "http://localhost/addressbook";
            baseURL = "http://localhost/mantisbt-2.24.2"; //в лекции  версия 1.2.17
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Admin = new AdminHelper(this, baseURL); //+baseURL как параметр



        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                //newInstance.driver.Url = "http://localhost/mantisbt-2.24.2/login_page.php";
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php"; //10_1
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }
    }
}