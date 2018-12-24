using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Parameters
{
    public class CalcExpression
    {
        public string Actions { get; }
        public string ExpectedResult { get; }

        public CalcExpression(string actions, string expectedResult)
        {
            Actions = actions;
            ExpectedResult = expectedResult;
        }

        public override string ToString()
        {
            return "[Expression:[Actions:" + Actions + "],[ExpectedResult:" + ExpectedResult + "]]";
        }
    }
}
