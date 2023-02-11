using NUnit.Framework;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;



using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using NUnit.Framework.Internal;
using System.Security.Cryptography;



namespace VRI_JavaScript_Prompt
{
    public class JavaScriptPrompt
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
           

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            driver = new ChromeDriver(path + @"\drivers\");
            
            driver.Manage().Window.Maximize();
            
        }

        [Test, Order(1)]
        public void TC01_VerifyJavaScriptPromptOkEmpty()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

            By jsprompt = By.XPath("//*[@id=\"content\"]/div/ul/li[3]/button");
            driver.FindElement(jsprompt).Click();

            var expectedAlertText = "I am a JS prompt";
            var alert_win = driver.SwitchTo().Alert();
            
            Assert.That(alert_win.Text, Is.EqualTo(expectedAlertText));

            alert_win.Accept();

           
            String expectedresult = "You entered:";
            String actualresult = driver.FindElement(By.Id("result")).Text;
           
            Assert.That(actualresult, Is.EqualTo(expectedresult));

            




        }


        [Test, Order(2)]

        public void TC02_VerifyJavaScriptPromptOkFilled()

        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

            By jsprompt = By.XPath("//*[@id=\"content\"]/div/ul/li[3]/button");
            driver.FindElement(jsprompt).Click();

            var expectedAlertText = "I am a JS prompt";
            var alert_win = driver.SwitchTo().Alert();

            Assert.That(alert_win.Text, Is.EqualTo(expectedAlertText));


            alert_win.SendKeys("VRTEST");
            alert_win.Accept();

            
            String expectedresult = "You entered: VRTEST";
            String actualresult = driver.FindElement(By.Id("result")).Text;
            
            Assert.That(actualresult, Is.EqualTo(expectedresult));

            

        }


        [Test, Order(3)]
        public void TC03_VerifyJavaScriptPromptCancel()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

            By jsprompt = By.XPath("//*[@id=\"content\"]/div/ul/li[3]/button");
            driver.FindElement(jsprompt).Click();

            var expectedAlertText = "I am a JS prompt";
            var alert_win = driver.SwitchTo().Alert();

            Assert.That(alert_win.Text, Is.EqualTo(expectedAlertText));


            alert_win.Dismiss();


            String expectedresult = "You entered: null";
            String actualresult = driver.FindElement(By.Id("result")).Text;

            Assert.That(actualresult, Is.EqualTo(expectedresult));






        }



        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }
}