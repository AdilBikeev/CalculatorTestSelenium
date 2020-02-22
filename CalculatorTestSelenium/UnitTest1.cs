using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CalculatorTestSelenium
{
    /// <summary>
    /// Класс для расшифровки навзаний методов доступных на сайте
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Устанавливает значение в поле для ввода
        /// </summary>
        public const string SetValue = "iillllllii";

        /// <summary>
        /// Возвращает словарь из объектов знака операций
        /// </summary>
        public const string GetDictOperations = "return llliilllll";

        /// <summary>
        /// Возвращает содержимое поля для ввода
        /// </summary>
        public const string GetInputValue = "return llllll1lll";
    }

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
            var obj = firefox.ExecuteScript(Methods.GetDictOperations);
            Assert.IsTrue(obj is Dictionary<string, object>);

            var dictKeysOperation = (Dictionary<string,object>)obj;

            Assert.IsTrue(dictKeysOperation.TryGetValue(key, out object expected));
            Assert.IsTrue(expected is ReadOnlyCollection<object>);
            var collection = (ReadOnlyCollection<object>)expected;
            Assert.AreEqual(value, collection[0]);
        }

        [TestMethod]
        [Description("Проверяет устанавливаются ли значения в поле для ввода")]
        [DataRow("1")]
        [DataRow("12")]
        [DataRow("-1")]
        [DataRow("-12")]
        public void SetValue(string value)
        {
            firefox.ExecuteScript($"{Methods.SetValue}({value})");

            Assert.AreEqual(value, firefox.ExecuteScript(Methods.GetInputValue));
        }
    }
}
