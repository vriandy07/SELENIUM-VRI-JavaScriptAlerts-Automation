# VRI-JavaScript-Alerts-Automation

## Project Description ##

The JavaScript-Alerts-Automation is a automation project with SELENIUM Webdriver using NUnit framework, NUnit framework is an open–source unit testing framework in C#, for this project I created the automation of some examples of different JavaScript alerts which can be troublesome for automation.

*This is a Selenium project developed in C# using Visual Studio and NUnit for testing automation of the computer database website.*



## Prerequisites ##

Before running this project, make sure to have the following installed:

   - Visual Studio
   - Create Selenium C# automation framework .NET Core
   - Google Chrome or Firefox
   - ChromeDriver or GeckoDriver

 You can follow the instructions here [Selenium Installing Guide](https://www.browserstack.com/guide/selenium-with-c-sharp-for-automated-test)

 
 
## Installing ##

 Clone or download the project.
 Open the project using Visual Studio.
    
 To open the project file in Visual Studio, you can follow these steps:

   1. Install Visual Studio on your computer if you don't have it already installed.
   2. Install Git on your computer if you don't have it already installed.
   3. Open Visual Studio and click on "Clone or checkout code" under the "Start" tab or go to "File" -> "Open" -> "Project/Solution"
   4. In the "Clone Repository" section, paste the link to the GitHub repository [GitHub](https://github.com/vriandy07/SELENIUM-VRI-JavaScriptAlerts-Automation.git) and  click "Clone".
   5. Visual Studio will now clone the repository and you should see the project files in the Solution Explorer.
   6. To open the solution, you can double-click on the .sln file in the Solution Explorer.
   7. Set the ChromeDriver or GeckoDriver path in Setup() method in **AddComputer.cs** class as mentioned below:
```
string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
driver = new ChromeDriver(path + @"\drivers\");
```
    
 You should now be able to build and run the project, or you can check this link [OpenProject](https://learn.microsoft.com/en-us/visualstudio/get-started/tutorial-open-project-from-repo?view=vs-2022)
 
 If there are any missing packages or dependencies, you can install them by right-clicking on the solution in the Solution Explorer and choosing "Manage NuGet Packages".

Note: Make sure to have the required software and libraries installed on your computer before opening the project.


## Tests ##

This is the set up before the test
```
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

```
Explanation:

In Selenium C#, the [OneTimeSetUp] attribute is used to define a setup method that will run only once before all the tests in a test fixture are run. This is useful for performing actions that need to be done once before the tests start, such as initializing test data, starting a browser, or logging in to an application.

The [OneTimeSetUp] method is part of the NUnit testing framework and is used to set up a test fixture, which is a collection of tests that are intended to be run together. The [OneTimeSetUp] method will run before any of the tests in the test fixture and is only run once, even if multiple tests are run within the same fixture.


Set the ChromeDriver or GeckoDriver path in Setup() method
```
string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
```
 


This is to maximize the windows browser
```
driver.Manage().Window.Maximize();
```





The following tests have been automated:

   - JavaScriptAlerts
     - TC01_VerifyJavaScriptAlerts
       > In the JavaScriptAlerts test case **TC01_VerifyJavaScriptAlerts** I want to verify when click on 'Click for JS alert' button it will display pop up with "I am a JS Alert" message, then I click on OK by **alert_win.Accept**, then as a result in the page will display "You successfully clicked an alert".
       ```
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
       ```
       
  - JavaScriptConfirm
    - TC01_VerifyJavaScriptConfirmOK
      > In the JavaScriptConfirm **TC01_VerifyJavaScriptConfirmOK** I want to verify when click on 'JS Script Confirm' then pop up displayed with "I am a JS Confirm" message, and when click on OK by **alert_win.Accept**, then as a result in the page will display "You clicked: Ok".
       ```
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
       ```
       
    - TC02_VerifyJavaScriptConfirmCancel
      > In the JavaScriptConfirm **TC02_VerifyJavaScriptConfirmCancel** I want to verify when click on 'JS Script Confirm' then pop up displayed with "I am a JS Confirm" message, and when click on Cancel by **alert_win.Dismiss**, then as a result in the page will display "You clicked: Cancel".
       ```
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
       ```

  - JavaScriptPrompt
    - TC01_VerifyJavaScriptPromptOkEmpty
      > In the JavaScriptPrompt **TC01_VerifyJavaScriptPromptOkEmpty** I want to verify when click on 'JS Script Prompt' then pop up displayed with "I am a JS prompt" message and a field and when I click on OK by **alert_win.Accept**, without enter anything on the field, then as a result in the page will display "You entered:".
       ```
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
       ```
       
    - TC02_VerifyJavaScriptPromptOkFilled
      > In the JavaScriptPrompt **TC02_VerifyJavaScriptPromptOkFilled** I want to verify when click on 'JS Script Prompt' then pop up displayed with "I am a JS prompt" message and a field and when I click on OK by **alert_win.Accept** with "VRTEST" entered on the field, then as a result in the page will display "You entered: VRTEST".
       ```
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
       ```

    - TC03_VerifyJavaScriptPromptCancel
      > In the JavaScriptPrompt **TC03_VerifyJavaScriptPromptCancel** I want to verify when click on 'JS Script Prompt' then pop up displayed with "I am a JS prompt" message and a field and when I click on Cancel by **alert_win.Dismiss**, then as a result in the page will display "You entered: null".
       ```
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
       ```





## Built With ##
   - Visual Studio - Microsoft Visual Studio is an integrated development environment (IDE) from Microsoft.
   - NUnit - The unit testing framework used.
   - OpenQA.Selenium - The browser automation tool used.
   - Google ChromeDriver - The web driver used for Google Chrome browser.
   - Firefox GeckoDriver - The web driver used for Firefox browser.
