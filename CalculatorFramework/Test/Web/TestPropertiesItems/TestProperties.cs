using CalculatorFramework.Parameters;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Test.Web.TestPropertiesItems
{
    public class TestProperties
    {
        public string Name { get; protected set; }
        public IWebDriver Driver { get; protected set; }
        public CalcExpression Expression { get; protected set; }

        public TestProperties(string name, IWebDriver driver, CalcExpression expression)
        {
            Name = name;
            Driver = driver;
            Expression = expression;
        }
    }
}
