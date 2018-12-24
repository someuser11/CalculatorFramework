using CalculatorFramework.Elements.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Calculator
{
    public class CalculatorBuilder<T> where T : BaseElement
    {
        protected Dictionary<CalcElementType, T> elements;

        public CalculatorBuilder()
        {
            elements = new Dictionary<CalcElementType, T>();
        }

        public CalculatorBuilder<T> SetNumElements(T zero, T one, T two, T three, T four, T five, T six, T seven, T eight, T nine, T point)
        {
            elements.Add(CalcElementType.ZERO, zero);
            elements.Add(CalcElementType.ONE, one);
            elements.Add(CalcElementType.TWO, two);
            elements.Add(CalcElementType.THREE, three);
            elements.Add(CalcElementType.FOUR, four);
            elements.Add(CalcElementType.FIVE, five);
            elements.Add(CalcElementType.SIX, six);
            elements.Add(CalcElementType.SEVEN, seven);
            elements.Add(CalcElementType.EIGHT, eight);
            elements.Add(CalcElementType.NINE, nine);
            elements.Add(CalcElementType.POINT, point);
            return this;
        }

        public CalculatorBuilder<T> SetActionElements(T add, T subtract, T multiply, T divide, T equals)
        {
            elements.Add(CalcElementType.ADD, add);
            elements.Add(CalcElementType.SUBTRACT, subtract);
            elements.Add(CalcElementType.MULTIPLY, multiply);
            elements.Add(CalcElementType.DIVIDE, divide);
            elements.Add(CalcElementType.EQUALS, equals);
            return this;
        }

        public CalculatorBuilder<T> SetResultElement(T result)
        {
            elements.Add(CalcElementType.RESULT, result);
            return this;
        }

        public static implicit operator Calculator<T>(CalculatorBuilder<T> builder)
        {
            return new Calculator<T>(builder.elements);
        }
    }
}
