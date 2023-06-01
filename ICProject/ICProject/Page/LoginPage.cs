using ICProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICProject.Page
{
    public class LoginPage
    {

        public void loginSteps(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            Wait.WaitToExist(driver, "Id", "UserName", 3);
            try
            {
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");
            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page didn't load", ex);
            }
            //Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");
            //Click login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(1000);
        }
    }
}

