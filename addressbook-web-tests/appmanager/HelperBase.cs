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
    public class HelperBase
    {
        protected IWebDriver driver; //поле Драйвер protected
        protected ApplicationManager manager; //поле manager - protected

        public HelperBase(ApplicationManager manager) {
            this.manager = manager;
            driver = manager.Driver;
        }


        //новый общий ПУБЛИК метод Type (вводит значения в поля ввода) в ФиггГКФорм 3_1
        public void Type(By locator, string text)
        {
            //если тескт НЕ ноль, ТО выполняем.... ИНАЧЕ проскакиаем  3_1
            if (text != null)

            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }



        public bool IsElementPresent(By by) ////????
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}