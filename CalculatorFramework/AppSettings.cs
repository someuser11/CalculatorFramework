using CalculatorFramework.Parameters.Web;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CalculatorFramework.Parameters;

namespace CalculatorFramework
{
    public class AppSettings
    {
        protected static AppSettings instance = null;

        public static AppSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppSettings();
                    instance.Initialization();
                }
                return instance;
            }
        }
        public List<DriverType> DriversList { get; protected set; }
        public List<CalcExpression> CalcExpressionsList { get; protected set; }
        public int DefaultWaitTimeout { get; protected set; }
        public string PageLocatorsDirectory { get; private set; }
        public string ScreenshotDirectory { get; private set; }
        public string CalcExpressionPath { get; private set; }

        protected AppSettings()
        { }

        protected void Initialization()
        {
            DriversList = GetDriversList("Drivers", ',');
            DefaultWaitTimeout = GetIntValue("DefaultWaitTimeout");
            PageLocatorsDirectory = GetStringValue("PageLocatorsDirectory");
            CalcExpressionPath = GetStringValue("CalcExpressionPath");
            CalcExpressionsList = GetCalcExpressionsListFromFile(CalcExpressionPath);
        }

        protected string GetStringValue(string settingName) => TestContext.Parameters[settingName] ?? ConfigurationManager.AppSettings[settingName] ?? "";

        protected bool GetBoolValue(string settingName) => GetStringValue(settingName).ToLower().Equals("true") ? true : false;

        protected int GetIntValue(string settingName)
        {
            try { return Convert.ToInt32(string.Join("", GetStringValue(settingName).Where(c => char.IsDigit(c)))); }
            catch (FormatException) { return 0; }
        }

        protected List<DriverType> GetDriversList(string settingName, char delimiter)
        {
            List<DriverType> driversList = new List<DriverType>();
            foreach (string driverName in GetStringValue(settingName).Split(delimiter).ToList().Select(d => d.Trim().ToLower()).Distinct())
            {
                switch (driverName)
                {
                    case "chrome":
                        driversList.Add(DriverType.ChromeDriver);
                        break;
                    case "gecko":
                        driversList.Add(DriverType.GeckoDriver);
                        break;
                    case "ie":
                        driversList.Add(DriverType.IEDriver);
                        break;
                }
            }
            return driversList;
        }

        protected List<CalcExpression> GetCalcExpressionsListFromFile(string filePath)
        {
            return new TestExpressionsParser(filePath).ParseXml();
        }
    }
}
