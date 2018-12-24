using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace CalculatorFramework.Parameters
{
    public class TestExpressionsParser
    {
        protected string filePath;

        public TestExpressionsParser(string filePath)
        {
            this.filePath = filePath;
        }

        public List<CalcExpression> ParseXml()
        {
            List<CalcExpression> expressions = new List<CalcExpression>();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                foreach (XmlNode node in xmlDoc.DocumentElement)
                {
                    if (node.Name.ToLower().Equals("expression"))
                    {
                        string actions = "";
                        string expectedResult = "";
                        try { actions = node.Attributes["actions"].InnerText; }
                        catch (NullReferenceException) { }
                        try { expectedResult = node.Attributes["expectedResult"].InnerText; }
                        catch (NullReferenceException) { }
                        expressions.Add(new CalcExpression(actions, expectedResult));
                    }
                }
            }
            catch (FileNotFoundException)
            { }
            return expressions;
        }
    }
}