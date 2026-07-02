using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests;

 public class SauceDemoLoginTests
{
    private IWebDriver driver;
 
    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");        // no window on a CI agent
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--window-size=1920,1080");
        driver = new ChromeDriver(options);
    }
 
    [Test]
    public void ValidLogin_LandsOnProductsPage()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.CssSelector("#login-button")).Click();
 
        var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
        var title = wait.Until(d => d.FindElement(By.ClassName("title")));
        Assert.That(title.Text, Is.EqualTo("Products"));
    }
 
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
