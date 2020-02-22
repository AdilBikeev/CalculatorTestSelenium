using System;
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
    }
}
