using CalculatorFramework.Elements.WebImps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CalculatorFramework.Calculator.Web
{
    public class WebCalculator
    {
        protected Calculator<WebElement> baseCalculator;

        public string Result {
            get
            {
                WebElement resultElement = baseCalculator.GetButton(CalcElementType.RESULT);
                resultElement.Wait(ElementState.VISIBLE);
                return resultElement.Text;
            }
        }
        public WebCalculator(Calculator<WebElement> calculator)
        {
            baseCalculator = calculator;
        }

        protected void ActionWithCalcBtn(WebElement element)
        {
            element.Wait(ElementState.CLICKABLE);
            element.Click();
        }

        public WebCalculator Execute(CalcElementType calcElement)
        {
            if (calcElement != CalcElementType.NONE && calcElement != CalcElementType.RESULT)
            {
                ActionWithCalcBtn(baseCalculator.GetButton(calcElement));
            }
            return this;
        }

        public WebCalculator Execute(List<CalcElementType> calcElements)
        {
            calcElements.ForEach(x => Execute(x));
            return this;
        }

        public WebCalculator Execute(string executeString)
        {
            Execute(baseCalculator.StringToCalcElementList(executeString));
            return this;
        }
    }
}
