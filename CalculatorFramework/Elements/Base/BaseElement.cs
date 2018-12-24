using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Elements.Base
{
    public abstract class BaseElement : IBaseElement
    {
        public string Name { get; protected set; }

        public BaseElement(string name)
        { }
    }
}
