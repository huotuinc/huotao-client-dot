using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Weixin
{

    /// <summary>
    /// 负责执行微信的相关操作
    /// </summary>
    public class Worker
    {
        IWebDriver driver = new InternetExplorerDriver();

        public Worker()
        {
            driver.Navigate().GoToUrl("https://wx.qq.com");
        }

        ~Worker()
        {
            driver.Quit();
        }
        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="to">收消息的群名称或者好友昵称</param>
        /// <param name="message">消息内容</param>
        public void SendTextMessage(String to,String message)
        {
            if (!IsLoggedIn())
                login();
            chooseContact(to);
        }

        private bool CurrentTitle(String title, IWebDriver input)
        {
            return input.FindElement(By.CssSelector("div.title")).Text.Equals(title);
        }

        /// <summary>
        /// 选择兑换名称
        /// </summary>
        /// <param name="name">要求的名称</param>
        private void chooseContact(String name)
        {
            if (CurrentTitle(name, driver))
                return;
            IWebElement bar = driver.FindElement(By.Id("search_bar"));

            IWebElement searchInput = bar.FindElement(By.TagName("input"));
            //        contacts scrollbar-dynamic scroll-content scroll-scrolly_visible
            searchInput.Clear();
            searchInput.SendKeys(name);
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(input
                    =>input != null && FindSearchResult(input)!=null);

            IWebElement listDiv = FindSearchResult(driver);
                   // .orElseThrow(()-> new IllegalStateException("找不到搜索结果列表"));

            listDiv.FindElements(By.ClassName("ng-scope"))
                    .Where(element => element.FindElements(By.TagName("h4")).Count>0)
                    .Where(element =>element.FindElement(By.TagName("h4")).Text.Equals(name))
                    .FirstOrDefault()
                    //.orElseThrow(()-> new IllegalStateException("找不到好友" + name))
                    .Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                    .Until(input
                            =>input != null && CurrentTitle(name, input));
        }

        private IWebElement FindSearchResult(IWebDriver driver)
        {
            return driver.FindElements(By.ClassName("contacts"))
                    //                .peek(System.out::println)
                    .Where(element=>element.GetAttribute("class").Contains("scroll-content"))
                    .FirstOrDefault();
        }

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns>true表示已登录</returns>
        private bool IsLoggedIn()
        {
            return IsLoggedIn(driver);
        }

        private void login()
        {
            new WebDriverWait(driver, TimeSpan.FromMinutes(5)).Until(input => IsLoggedIn(input));
            System.Console.WriteLine("Login Success");
        }

        private bool IsLoggedIn(IWebDriver input)
        {
            return input.FindElement(By.ClassName("main")).Displayed;
        }

    }
}
