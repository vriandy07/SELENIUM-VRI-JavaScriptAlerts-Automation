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



namespace VRI_JavaScript_Confirm
{
    public class JavaScriptConfirm
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
        public void TC01_VerifyJavaScriptConfirmOK()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

            By jsconfirm = By.XPath("//*[@id=\"content\"]/div/ul/li[2]/button");
            driver.FindElement(jsconfirm).Click();

            var expectedAlertText = "I am a JS Confirm";

            var alert_win = driver.SwitchTo().Alert();
            
            Assert.That(alert_win.Text, Is.EqualTo(expectedAlertText));

            alert_win.Accept();

            

            String expectedresult = "You clicked: Ok";
            String actualresult = driver.FindElement(By.Id("result")).Text;
            


            Assert.That(actualresult, Is.EqualTo(expectedresult));

            




        }


        [Test, Order(2)]

        public void TC02_VerifyJavaScriptConfirmCancel()

        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            By jsconfirm = By.XPath("//*[@id=\"content\"]/div/ul/li[2]/button");
            driver.FindElement(jsconfirm).Click();

            var expectedAlertText = "I am a JS Confirm";

            var alert_win = driver.SwitchTo().Alert();

            Assert.That(alert_win.Text, Is.EqualTo(expectedAlertText));

            alert_win.Dismiss();

            

            String expectedresult = "You clicked: Cancel";
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