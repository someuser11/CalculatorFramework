using CalculatorFramework.Elements.WebImps;
using CalculatorFramework.Test.Web.TestPropertiesItems;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Form.Web
{
    public abstract class BaseWebPage : BaseForm
    {
        protected Dictionary<string, WebElement> elements = new Dictionary<string, WebElement>();
        protected IWebDriver Driver { get { return TestPropertiesStorage.Instance.Get(TestContext.CurrentContext.Test.ID).Driver; } }

        public BaseWebPage()
        {
            elements = new PageParser(AppSettings.Instance.PageLocatorsDirectory + @"\" + this.GetType().Name + ".xml").ParseXml();
        }
    }
}
