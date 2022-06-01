using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VersaoChromedriver;

namespace BLL
{
    public class RoboExecucao
    {

        public void Executar(string usuario, string senha)
        {



            //Instalar o Selenium no nuget
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            //options.AddArgument("headless");

            //Adcionar referência ao versaodriver \\srvirtual\ROBOS\ChromeDriver\AppChrome
            versionador v = new versionador();

            var chromeDriverService = ChromeDriverService.CreateDefaultService(v.versaoChromeDriver());
            chromeDriverService.HideCommandPromptWindow = true;
            using (ChromeDriver driver = new ChromeDriver(chromeDriverService, options: options))
            {


                driver.Navigate().GoToUrl("https://s4.wintub.com/?r=7332482");

                WaitForLoad(driver);
                driver.FindElement(By.XPath("//*[@id='header']/div/nav/ul/li[3]/a")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='main']/div/div/div/form/div[1]/div[1]/div/input")).SendKeys(usuario);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='main']/div/div/div/form/div[1]/div[2]/div/input")).SendKeys(senha);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='main']/div/div/div/form/div[2]/button")).Click();


                WaitForLoad(driver);


                driver.FindElement(By.XPath("//*[@id='about']/div/div[2]/div/div/div[1]/div/a[1]")).Click();
                if (verificaSite(driver))
                {
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }
                else
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }

                driver.FindElement(By.XPath("//*[@id='about']/div/div[2]/div/div/div[1]/div/a[2]")).Click();
                if (verificaSite(driver))
                {
                    Assistir(driver);
                    Thread.Sleep(36000);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }
                else
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }

                driver.FindElement(By.XPath("//*[@id='about']/div/div[2]/div/div/div[1]/div/a[3]")).Click();
                if (verificaSite(driver))
                {
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }
                else
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }

                driver.FindElement(By.XPath("//*[@id='about']/div/div[2]/div/div/div[1]/div/a[4]")).Click();
                if (verificaSite(driver))
                {
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }
                else
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }

                driver.FindElement(By.XPath("//*[@id='about']/div/div[2]/div/div/div[1]/div/a[5]")).Click();
                if (verificaSite(driver))
                {
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }
                else
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    Assistir(driver);
                    driver.FindElement(By.XPath("//*[@id='proceed']")).Click();
                }


            }


        }

        public static void WaitForLoad(IWebDriver driver)
        {
            Thread.Sleep(500);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int timeoutSec = 60;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }



        public bool verificaSite(ChromeDriver driver)
        {
            try
            {
                if (driver.FindElement(By.XPath("//*[@id='header']/div/div/a/img")).Displayed)
                {
                    WaitForLoad(driver);
                    return true;
                }

            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public void Assistir(ChromeDriver driver)
        {
            try
            {
                driver.SwitchTo().Frame("player");
                driver.ExecuteScript($"document.getElementsByClassName('ytp-large-play-button ytp-button')[0].click()");
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(36000);
            }
            catch (Exception)
            {

                driver.SwitchTo().Frame("player");
                driver.ExecuteScript($"document.getElementsByClassName('ytp-large-play-button ytp-button')[0].click()");
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(50000);

            }


        }


    }
}
