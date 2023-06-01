using ICProject.Page;
using ICProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICProject.Test
{
    [TestFixture]

    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpAction()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();

            //Login page object identified and defined
            LoginPage loginpageObj = new LoginPage();
            loginpageObj.loginSteps(driver);

            // Homepage object identified and defined
            Homepage homepageObj = new Homepage();
            homepageObj.GoToTMPage(driver);
        }
      [Test, Order(1)]
        public void CreatTMRecord_Test()
        {
            // Timepage object identified and create time record
            TMPage TimePageObj = new TMPage();
            TimePageObj.ClickCreateNew(driver);
            TimePageObj.TMTypeCode(driver);
            TimePageObj.TMCode(driver);
            TimePageObj.TMdescription(driver);
            TimePageObj.TMPrice(driver);
            TimePageObj.SaveRecord(driver);
            TimePageObj.GoToLastPage(driver);
            TimePageObj.VerifyTMRecordCreation(driver);
        }
      [Test, Order(2)]
        public void EditTMRecord_test()
        {

            TMPage TimePageObj = new TMPage();
            TimePageObj.EditLastRecord(driver);
        }

      [Test, Order(3)]
        public void DeleteTM_Test()
        {
            //DeleteTM Record
            TMPage TMPageObj = new TMPage();
            TMPageObj.DeleteLastRecord(driver);

        }

       [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
