using CalculatorFramework.Elements.Base;
using CalculatorFramework.Elements.WebImps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Calculator
{
    public class Calculator<T> where T : BaseElement
    {
        protected Dictionary<CalcElementType, T> calcButtons;

        public Calculator(Dictionary<CalcElementType, T> calcButtons)
        {
            this.calcButtons = calcButtons;
        }

        public T GetButton(CalcElementType button)
        {
            return calcButtons[button];
        }

        public List<CalcElementType> StringToCalcElementList(string actions)
        {
            List<CalcElementType> buttonList = new List<CalcElementType>();
            foreach(char buttonChar in actions)
            {
                buttonList.Add(CharToCalcElement
                    (buttonChar));
            }
            for(int i = 0; i < buttonList.Count; i++)
            {
                if (buttonList[i].Equals(CalcElementType.NONE))
                {
                    buttonList.RemoveAt(i);
                }
            }
            return buttonList;
        }

        protected string DoubleValueToString(double value)
        {
            string strValue = String.Format("{0:0.000000}", value);
            string strValueAfterPoint = strValue.Substring(strValue.IndexOf('.') + 1, strValue.Length);
            int pointerToLastNotZeroValue = -1;
            for (int i = 0; i < strValueAfterPoint.Length; i++)
            {
                if (!strValueAfterPoint[i].Equals('0'))
                {
                    pointerToLastNotZeroValue = i;
                }
            }
            return strValue = strValue.Substring(0, strValue.IndexOf('.') + pointerToLastNotZeroValue);
        }

        protected CalcElementType CharToCalcElement(char character)
        {
            switch (character)
            {
                case '1':
                    return CalcElementType.ONE;
                case '2':
                    return CalcElementType.TWO;
                case '3':
                    return CalcElementType.THREE;
                case '4':
                    return CalcElementType.FOUR;
                case '5':
                    return CalcElementType.FIVE;
                case '6':
                    return CalcElementType.SIX;
                case '7':
                    return CalcElementType.SEVEN;
                case '8':
                    return CalcElementType.EIGHT;
                case '9':
                    return CalcElementType.NINE;
                case '0':
                    return CalcElementType.ZERO;
                case '.':
                    return CalcElementType.POINT;
                case '+':
                    return CalcElementType.ADD;
                case '-':
                    return CalcElementType.SUBTRACT;
                case '*':
                    return CalcElementType.MULTIPLY;
                case '/':
                    return CalcElementType.DIVIDE;
                case '=':
                    return CalcElementType.EQUALS;
                default:
                    return CalcElementType.NONE;
            }
        }
    }
}
