using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorFramework.Test.Web.TestPropertiesItems
{
    public class TestPropertiesStorage
    {
        protected Dictionary<string, TestProperties> propertiesStorage;
        protected static TestPropertiesStorage instance = null;

        public static TestPropertiesStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestPropertiesStorage();
                    instance.propertiesStorage = new Dictionary<string, TestProperties>();
                }
                return instance;
            }
        }

        public TestPropertiesStorage()
        { }

        public TestProperties Get(string key)
        {
            return propertiesStorage[key];
        }

        public void Add(string key, TestProperties properties)
        {
            propertiesStorage.Add(key, properties);
        }

        public void Remove(string key)
        {
            propertiesStorage.Remove(key);
        }
    }
}