using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Elements.Interfaces
{
    interface IField
    {
        string Text { get; }

        void SendKeys(string text);
    }
}