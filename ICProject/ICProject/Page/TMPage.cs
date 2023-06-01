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
    public class TMPage:CommonDriver
    {
            public void ClickCreateNew (IWebDriver driver)
            {
                IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createnewButton.Click();
            }
            public void TMTypeCode(IWebDriver driver)
            {
                IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
                typeCodeDropdown.Click();
                IWebElement option = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
                Thread.Sleep(1000);

                option.Click();
            }
            public void TMCode(IWebDriver driver)
            {
                IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
                codeTextbox.SendKeys("AB123");
            }
            public void TMdescription(IWebDriver driver)
            {
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.SendKeys("DES123");
            }
            public void TMPrice(IWebDriver driver)
            {
                IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
                priceTextbox.SendKeys("12");
                Thread.Sleep(2000);
            }
            public void SaveRecord(IWebDriver driver)
            {
                IWebElement saveRecord = driver.FindElement(By.Id("SaveButton"));
                saveRecord.Click();
                Thread.Sleep(4000);
            }
            public void GoToLastPage(IWebDriver driver)
            {
                //IWebElement goToLastPageButton = driver.FindElement(By.XPath("//span[@class='k-icon k-i-seek-e']"));
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
                goToLastPageButton.Click();
                Thread.Sleep(4000);
            }
            //*************** Check Time Record present in the Table**********
            public void VerifyTMRecordCreation(IWebDriver driver)
            {
                //check if the record is present in the table
                IWebElement newcode = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
                if (newcode.Text == "AB123")
                {
                    Assert.Pass("TM record has created succesfully");
                }
                else
                {
                    Assert.Fail("TM record has not been created successfully");
                }
            }
            
            public void EditLastRecord(IWebDriver driver)
            {
                Thread.Sleep(2000);
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
                goToLastPageButton.Click();
                
                IWebElement editTMlastRecord = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[1]"));
                editTMlastRecord.Click();
               
                IWebElement editTMCode = driver.FindElement(By.Id("Code"));
                editTMCode.Clear();
                editTMCode.SendKeys("EDITAB123");
                
                IWebElement editTMDescription = driver.FindElement(By.Id("Description"));
                editTMDescription.Clear();
                editTMDescription.SendKeys("EDITDES123");
               
                IWebElement saveRecord = driver.FindElement(By.Id("SaveButton"));
                saveRecord.Click();
                Thread.Sleep(4000);
                Thread.Sleep(2000);
               
                IWebElement goToLastPage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
                goToLastPage.Click();
                
                 //check if the Edit record is present in the table
                 IWebElement editcode = driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]"));
                if (editcode.Text == "EDITAB123")
                {
                    Assert.Pass("Edit last record has created succesfully");
                }
                else
                {
                    Assert.Fail("Edit last record has not been created successfully");
                }
            }
        public void DeleteLastRecord(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            // click delete last record
            Thread.Sleep(3000);
            IWebElement deleteTMRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteTMRecord.Click();
            Thread.Sleep(3000);
            // To Click OK in altert window
            driver.SwitchTo().Alert().Accept();
            // To Click Cancel in alert window, if you dont want to delete
            //driver.SwitchTo().Alert().Dismiss();

            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastRecordCode.Text != "EDITAB123", "Record has  been deleted");
        }
    }
}

