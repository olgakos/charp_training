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
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        { }

        public void Login(AccountData account) // L3_3
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn())
                {
                    return;
                }



                LogOut(); //!!! вниемнеи, удали его из тела тестов, елли будет падать

            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();


            //Login 3_1
            //Type(By.Name("user"), account.Username);
            //Type(By.Name("pass"), account.Password);
            //driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }



        public void LogOut()
        {
            //л3_3: "если был залогинен - выйди")
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user")); // ждём появления формы логина hw_9
            }

        }




        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout")); //нашли элемент характерынй для залогиенного юзера 3_3
        }



        public bool IsLoggedIn(AccountData account) //Как убеляться, что это именно тот пользователь, который указан в параметре Аккаунт
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                == "(" + account.Username + ")";
        }
    }
}
