using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

Feature: Contact Us Page
  As an end user
  I want a contact us page
  So that I can find out more about QAWorks exciting services!

  Scenario: Valid Submission
    Given I am on the QAWorks Site
    Then I should be able to contact QAWorks with the following information
      | name    | j.Bloggs                                  |
      | email   | j.Bloggs@qaworks.com                      |
      | message | please contact me I want to find out more |

  namespace QAWorksSteps
  {
  public class Contact_Steps
    {
        public IWebDriver driver;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
        [Given(@"I am on the QAWorks Site")]
        public void GivenUserOnQASite()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://qaworks.com/");

        }

        [Then(@"I should be able to contact QAWorks with the following information")]
        public void ContactQA(string name, string email, string message)
        {
            driver.FindElement(By.LinkText("Contact")).Click();
            wait.Until(ExpectedConditions.TitleIs("Contact Us - QA Works"))
            driver.FindElement(By.Id("ctl00_MainContent_NameBox")).SendKeys(name);
            driver.FindElement(By.Id("ctl00_MainContent_EmailBox")).SendKeys(email);
            driver.FindElement(By.Id("ctl00_MainContent_MessageBox")).SendKeys(message);
            driver.FindElement(By.LinkText("ctl00_MainContent_SendButton")).Click();
        }
      }
  }
