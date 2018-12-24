using CalculatorFramework.Elements.WebImps;
using CalculatorFramework.Locators.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CalculatorFramework.Form.Web
{
    public class PageParser
    {
        protected string filePath;

        public PageParser(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<string, WebElement> ParseXml()
        {
            Dictionary<string, WebElement> elements = new Dictionary<string, WebElement>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            foreach (XmlNode node in xmlDoc.DocumentElement)
            {
                if (node.Name.ToLower().Equals("element"))
                {
                    string name = "";
                    string type = "";
                    string value = "";
                    WebLocatorType locatorType;
                    try { name = node.Attributes["name"].InnerText; }
                    catch (NullReferenceException) { }
                    try { type = node.Attributes["type"].InnerText.Replace(" ", "").ToLower(); }
                    catch (NullReferenceException) { }
                    try { value = node.Attributes["value"].InnerText; }
                    catch (NullReferenceException) { }
                    switch (type)
                    {
                        case "classname":
                            locatorType = WebLocatorType.ClassName;
                            break;
                        case "cssselector":
                            locatorType = WebLocatorType.CSS;
                            break;
                        case "id":
                            locatorType = WebLocatorType.Id;
                            break;
                        case "linktext":
                            locatorType = WebLocatorType.LinkText;
                            break;
                        case "name":
                            locatorType = WebLocatorType.Name;
                            break;
                        case "partiallinktext":
                            locatorType = WebLocatorType.PartialLinkText;
                            break;
                        case "tagname":
                            locatorType = WebLocatorType.TagName;
                            break;
                        case "xpath":
                            locatorType = WebLocatorType.XPath;
                            break;
                        default:
                            locatorType = WebLocatorType.XPath;
                            break;
                    }
                    elements[name] = new WebElement(name, new WebLocator(locatorType, value));
                }
            }
            return elements;
        }
    }
}
