using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Parameters.Web
{
    public class WebParameters
    {
        public static IEnumerable<DriverType> DriverToRun()
        {
            return AppSettings.Instance.DriversList;
        }

        public static IEnumerable<CalcExpression> ExpressionToRun()
        {
            return AppSettings.Instance.CalcExpressionsList;
        }
    }
}
