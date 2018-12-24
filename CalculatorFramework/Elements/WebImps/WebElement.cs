using CalculatorFramework.Elements.Base;
using CalculatorFramework.Elements.Interfaces;
using CalculatorFramework.Locators.Web;
using CalculatorFramework.Test.Web.TestPropertiesItems;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Elements.WebImps
{
    public class WebElement : BaseElement, IButton, IField, ILabel
    {
        public IWebDriver Driver { get { return TestPropertiesStorage.Instance.Get(TestContext.CurrentContext.Test.ID).Driver; } }
        public WebLocator Locator { get; protected set; }
        public string Text { get { return GetSeleniumElement().Text; } }

        public WebElement(string name, WebLocator locator) : base(name)
        {
            Locator = locator;
        }

        public WebElement(WebLocator locator) : this("", locator)
        { }

        public IWebElement GetSeleniumElement()
        {
            IWebElement element = null;
            try
            {
                element = GetSeleniumElementList()[0];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                new Exception("Element [" + Name + "] not found" + Environment.NewLine + ex);
            }
            return element;
        }

        public List<IWebElement> GetSeleniumElementList() => Driver.FindElements(Locator.ByValue).ToList();

        public void Click() => GetSeleniumElement().Click();

        public void SendKeys(string text) => GetSeleniumElement().SendKeys(text);

        public bool IsState(ElementState state)
        {
            bool isState = false;
            try
            {
                switch (state)
                {
                    case ElementState.VISIBLE:
                        isState = Driver.FindElements(Locator.ByValue)[0].Displayed;
                        break;
                    case ElementState.ENABLE:
                        isState = Driver.FindElements(Locator.ByValue)[0].Enabled;
                        break;
                    case ElementState.CLICKABLE:
                        IWebElement selElement = Driver.FindElements(Locator.ByValue)[0];
                        isState = selElement.Displayed && selElement.Enabled;
                        break;
                }
            }
            catch(ArgumentOutOfRangeException)
            { }
            return isState;
        }

        public void Wait(ElementState state)
        {
            switch (state)
            {
                case ElementState.VISIBLE:
                    new Wait().WaitFor(AppSettings.Instance.DefaultWaitTimeout, () => IsState(ElementState.VISIBLE));
                    break;
                case ElementState.ENABLE:
                    new Wait().WaitFor(AppSettings.Instance.DefaultWaitTimeout, () => IsState(ElementState.ENABLE));
                    break;
                case ElementState.CLICKABLE:
                    new Wait().WaitFor(AppSettings.Instance.DefaultWaitTimeout, () => IsState(ElementState.CLICKABLE));
                    break;
                default:
                    break;
            }
        }
    }
}
