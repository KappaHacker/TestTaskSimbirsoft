using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestTaskSimbirsoft
{
    class SearchGoogle
    {
        IWebDriver _driver;
        By searchTextBox = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input");
        By searchButton = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]");
        public SearchGoogle(IWebDriver driver)
        {
            _driver = driver;
        }
        public void OpenCalc()
        {
            _driver.Navigate().GoToUrl(@"http://google.com");
            _driver.FindElement(searchTextBox).SendKeys("калькулятор");
            _driver.FindElement(searchButton).Click();
        }
    }
    class Calculator
    {
        IWebDriver _driver;
        By one = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(1) > div > div");
        By mult = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(3) > td:nth-child(4) > div > div");
        By two = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(2) > div > div");
        By minuse = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(4) > div > div");
        By three = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(3) > div > div");
        By plus = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(5) > td:nth-child(4) > div > div");
        By button = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(5) > td:nth-child(3) > div");
        By history = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.BRpYC > div.TIGsTb > div.xwgN1d.XSNERd > div > span");
        By result = By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.BRpYC > div.TIGsTb > div.fB3vD > div > div");
        public Calculator(IWebDriver driver)
        {
            _driver = driver;
        }
        public void EnterTask()
        {
            _driver.FindElement(one).Click();
            _driver.FindElement(mult).Click();
            _driver.FindElement(two).Click();
            _driver.FindElement(minuse).Click();
            _driver.FindElement(three).Click();
            _driver.FindElement(plus).Click();
            _driver.FindElement(one).Click();
            _driver.FindElement(button).Click();
        }
        public void CheckResukt()
        {
            if (_driver.FindElement(history).Text == "1 × 2 - 3 + 1 =" && _driver.FindElement(result).Text == "0")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("TEST PASSED");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("TEST FAILLED");
            }
            Console.ResetColor();
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(@"D://Image.png",
            ScreenshotImageFormat.Png);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            SearchGoogle page = new SearchGoogle(driver);
            page.OpenCalc();
            Calculator calc = new Calculator(driver);
            calc.EnterTask();
            calc.CheckResukt();

            driver.Quit();
        }
    }
}
