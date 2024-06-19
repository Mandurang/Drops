// See https://aka.ms/new-console-template for more information

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddExtension("C:\\Ulern\\Drops\\MetaMaskExtension\\11.16.3_0.crx");

        WebDriver webDriver = new ChromeDriver(chromeOptions);
        webDriver.Navigate().GoToUrl("https://syncswap.xyz/swap");
        Thread.Sleep(8000);

        WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        IWebElement option = wait.Until<IWebElement>((d) =>
        {
            try
            {
                IWebElement element = d.FindElement(By.XPath("//*[@id=\"onboarding__terms-checkbox\"]"));
                if (element.Displayed)
                {
                    return element;
                }
            }
            catch (NoSuchElementException) { }
            catch (StaleElementReferenceException) { }

            return null;
        });

        option.Click();


    }
}
