using OpenQA.Selenium;

namespace CalculatorFramework.Locators.Web
{
    public class WebLocator
    {
        public WebLocatorType Type { get; private set; }
        public string Value { get; private set; }
        public By ByValue
        {
            get
            {
                switch (Type)
                {
                    case WebLocatorType.ClassName:
                        return By.ClassName(Value);
                    case WebLocatorType.CSS:
                        return By.CssSelector(Value);
                    case WebLocatorType.Id:
                        return By.Id(Value);
                    case WebLocatorType.LinkText:
                        return By.LinkText(Value);
                    case WebLocatorType.Name:
                        return By.Name(Value);
                    case WebLocatorType.PartialLinkText:
                        return By.PartialLinkText(Value);
                    case WebLocatorType.TagName:
                        return By.TagName(Value);
                    case WebLocatorType.XPath:
                        return By.XPath(Value);
                    default:
                        return By.XPath(Value);
                }
            }
        }

        public WebLocator(WebLocatorType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
