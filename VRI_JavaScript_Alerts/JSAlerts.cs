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



namespace VRI_JavaScript_Alerts
{
    public class JavaScriptAlerts
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
        public void TC01_VerifyJavaScriptAlerts()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

            By jsalert = By.XPath("//*[@id=\"content\"]/div/ul/li[1]/button");
            driver.FindElement(jsalert).Click();

            var expectedAlertText = "I am a JS Alert";

            var alert_win = driver.SwitchTo().Alert();
            
            Assert.That(alert_win.Text, Is.EqualTo(expectedAlertText));

            alert_win.Accept();

            

            String expectedresult = "You successfully clicked an alert";
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