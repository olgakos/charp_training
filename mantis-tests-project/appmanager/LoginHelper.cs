﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests_project
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            Type(By.Name("username"), account.Username);
            //driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();

            Type(By.Name("password"), account.Password);
            //driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.ClassName("user-info")).Click();
            //driver.FindElement(By.LinkText("Logout")).Click();
            driver.FindElement(By.LinkText("Выход")).Click();
        }
    }
}