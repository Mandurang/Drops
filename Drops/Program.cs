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

        //var checkbox = webDriver.FindElement(By.XPath("//html/body/div[1]/div/div[2]/div/div/div/ul/li[1]]"));
        //string newClass = "check-box onboarding__terms-checkbox fa fa-check-square check-box__checked";

        //// Изменение класса элемента с помощью JavaScript
        //IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
        //js.ExecuteScript("arguments[0].className = arguments[1];", checkbox, newClass);

        //// Проверка изменения класса (можно удалить после проверки)
        //string updatedClass = (string)js.ExecuteScript("return arguments[0].className;", checkbox);
        //Console.WriteLine(updatedClass);

        /*WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#onboarding__terms-checkbox")));*/

        //Actions action = new Actions(webDriver);
        /*action.MoveToElement(webDriver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[2]/div/div/div/ul/li[1]/div")), 2, 2).Click().Perform();*/


        //var checkbox = webDriver.FindElement(By.XPath("//*[@id=\"onboarding__terms-checkbox\"]"));
        //action.MoveByOffset(573, 714).Perform();
        //Thread.Sleep(10);
        //action.Click();
        //action.Click(checkbox).Perform();
        //Thread.Sleep(3000);
        //checkbox.Click();


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

    /*private static void ButtonClickMetaMask(WebDriver webDriver)
    {
        webDriver.FindElement(By.XPath("//*[@id=\"app-content\"]/div/div[2]/div/div/div/ul/li[3]/button")).Click();
        Thread.Sleep(1000);
    }*/
}
