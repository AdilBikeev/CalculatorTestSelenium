using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CalculatorTestSelenium
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Адрес сайта с калькулятором
        /// </summary>
        const string url = "https://calculator888.ru/";

        /// <summary>
        /// Объект для работы с браузером Firefox
        /// </summary>
        FirefoxDriver firefox;

        [TestInitialize]
        [Description("Вызывается при запуске каждого теста")]
        public void Setup()
        {
            firefox = new FirefoxDriver();
            firefox.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        [Description("Вызывается при завершении каждого теста")]
        public void TearDown()
        {
            firefox.Quit();
        }

        [TestMethod]
        [Description("Проверяет есть ли на сайте калькулятор")]
        public void CalculatorFind()
        {
            Assert.IsNotNull(firefox.FindElementById("korpus_calulator"));
        }

        [TestMethod]
        [Description("Проверяет наличие всех нужных кнопок операций")]
        [DataRow("PLS", "+")]
        [DataRow("MIN", "-")]
        [DataRow("UMN", "\u00d7")]
        [DataRow("DLT", "\u00f7")]
        [DataRow("RAV", "=")]
        [DataRow("PII", "\u03c0")]
        [DataRow("EEE", "e")]
        [DataRow("SSL", "(")]
        [DataRow("SSP", ")")]
        [DataRow("KKV", "\u221a")]
        [DataRow("XKV", "^")]
        [DataRow("LGN", "ln")]
        [DataRow("LGG", "lg")]
        [DataRow("ABC", "Abc")]
        [DataRow("SIN", "Sin")]
        [DataRow("ASN", "aSin")]
        [DataRow("COS", "Cos")]
        [DataRow("ACS", "aCos")]
        [DataRow("TGG", "Tg")]
        [DataRow("ATG", "atg")]
        [DataRow("CTG", "cTg")]
        [DataRow("XSY", "^")]
        [DataRow("XZY", "\u221a")]
        [DataRow("LGY", "log")]
        [DataRow("ZPT", ",")]
        public void CheckKeysOperation(string key, object value)
        {
            var obj = firefox.ExecuteScript("return llliilllll");
            Assert.IsInstanceOfType(obj.GetType(), new Dictionary<string, object>().GetType());

            var dictKeysOperation = (Dictionary<string,object>)obj;

            Assert.IsTrue(dictKeysOperation.ContainsKey(key));
            Assert.IsTrue(dictKeysOperation[key] == value);
        }
    }
}
