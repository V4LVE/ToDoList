using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTests
{
    public class WebUITest
    {
        [Fact]
        public void OpenWebBrowserSelenium()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:5269/");

                Assert.Equal("Tasks - ToDoList", driver.Title);
            }
        }

        [Fact]
        public void CreateTaskSelenium()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:5269/");
                // Find the input field for the task name
                //driver.FindElement(By.Id("createNewTask")).Click();

                var descriptionElement = driver.FindElement(By.Id("description1"));
                // Enter a description for the task
                descriptionElement.SendKeys("Test Task Description");

                var priorityElement = driver.FindElement(By.Id("priority1"));
                // Select a priority for the task
                var select = new SelectElement(priorityElement);
                select.SelectByText("Normal");

                // Find and click the button to create the task
                var createButton = driver.FindElement(By.Id("newTaskSubmit1"));
                createButton.Click();

                // Assert that the task was created successfully
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var table = driver.FindElement(By.Id("taskTable"));
                var rows = table.FindElements(By.TagName("tr"));
                int rowCount = rows.Count;

                Assert.True(rowCount > 0);
            }
        }
    }
}
