using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestTaskSimbirsoft
{
    class Program
    {
        static void Main(string[] args)
        {
            //Открытие вкладки с калькулятором Chrome
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://google.com");
            IWebElement searchTextBox = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
            IWebElement searchButton = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"));
            searchTextBox.SendKeys("калькулятор");
            searchButton.Click();
            //Получение кнопок 1*2-3+1=
            IWebElement one = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(1) > div > div"));
            IWebElement mult = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(3) > td:nth-child(4) > div > div"));
            IWebElement two = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(2) > div > div"));
            IWebElement minuse = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(4) > div > div"));
            IWebElement three = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(4) > td:nth-child(3) > div > div"));
            IWebElement plus = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(5) > td:nth-child(4) > div > div"));           
            IWebElement button = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.SKWP2e > div > table.ElumCf > tbody > tr:nth-child(5) > td:nth-child(3) > div"));
            //Нажатие кнопок
            one.Click();
            mult.Click();
            two.Click();
            minuse.Click();
            three.Click();
            plus.Click();
            one.Click();
            button.Click();
            //Проверка результата
            IWebElement history = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.BRpYC > div.TIGsTb > div.xwgN1d.XSNERd > div > span"));
            IWebElement result = driver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div > div.card-section > div > div > div.BRpYC > div.TIGsTb > div.fB3vD > div > div"));
            if(history.Text == "1 × 2 - 3 + 1 =" && result.Text == "0")
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
            //Скриншот результата
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"D://Image.png",
            ScreenshotImageFormat.Png);
            //Закрытие вкладки
            driver.Quit();
        }
    }
}
