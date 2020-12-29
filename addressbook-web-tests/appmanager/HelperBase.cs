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

    }
}