using CalculatorFramework.Parameters;
using CalculatorFramework.Parameters.Web;
using CalculatorFramework.Test.Web.TestPropertiesItems;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Test.Web
{
    public abstract class BaseTest
    {
        public IWebDriver Driver { get { return TestPropertiesStorage.Instance.Get(TestContext.CurrentContext.Test.ID).Driver; } }

        public void TestInitialize(string name, DriverType driverType, CalcExpression expression)
        {
            IWebDriver driver = CreateDriver(driverType);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            TestPropertiesStorage.Instance.Add(TestContext.CurrentContext.Test.ID,new TestProperties(name, driver, expression));
        }

        private IWebDriver CreateDriver(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.ChromeDriver:
                    {
                        var options = new ChromeOptions();
                        options.AddAdditionalCapability("PageLoadStrategy", "none", true);
                        return new ChromeDriver(options);
                    }
                case DriverType.GeckoDriver:
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        return new FirefoxDriver(options);
                    }
                case DriverType.IEDriver:
                    {
                        InternetExplorerOptions options = new InternetExplorerOptions()
                        {
                            RequireWindowFocus = true,
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                            IgnoreZoomLevel = true,
                            EnablePersistentHover = true,
                            UsePerProcessProxy = true
                        };
                        return new InternetExplorerDriver(options);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        protected void TakeScreenshot(string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            using (BinaryWriter bw = new BinaryWriter(new FileStream(filePath, FileMode.Append, FileAccess.Write)))
            {
                bw.Write(Convert.FromBase64String(((ITakesScreenshot)Driver).GetScreenshot().ToString()));
                bw.Close();
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            ResultState testResult = TestContext.CurrentContext.Result.Outcome;
            if (testResult.Equals(ResultState.Failure) || testResult.Equals(ResultState.Error))
            {
                string screenshotName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ffff") + "_" + TestContext.CurrentContext.Test.MethodName + ".jpeg";
                string screenshotPath = AppSettings.Instance.ScreenshotDirectory + @"\" + screenshotName;
                TakeScreenshot(screenshotPath);
                TestContext.AddTestAttachment(screenshotPath, "screenshot");
            }
            Driver.Quit();
            TestPropertiesStorage.Instance.Remove(TestContext.CurrentContext.Test.ID);
        }
    }
}
