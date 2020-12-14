using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheContactCreationTest()
        {
            OpenHomePage();
            Login("admin", "secret");
            InitNewContactCreation();
            FillContactForm("John", "Lennon");
            SubmitContactCreationButton();
            ReturnToHomePage();
            LogOut();
        }

        private void LogOut()
        {
            //LogOut
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToHomePage()
        {
            //ReturnToHomePage
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void SubmitContactCreationButton()
        {
            //SubmitContactCreationButton
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        private void FillContactForm(string firstname, string lastname)
        {
            //FillContactForm
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(lastname);
        }

        private void InitNewContactCreation()
        {
            //InitNewContactCreation
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(string username, string password)
        {
            //Login
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            //OpenHomePage
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
