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
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        readonly IWebDriver driver = new InternetExplorerDriver();

        public Worker()
        {
            log.Info("start up");
            Console.WriteLine("Console Start up");
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
            try
            {
                if (!IsLoggedIn())
                    login();
                chooseContact(to);

                IWebElement editArea = driver.FindElement(By.Id("editArea"));

                IWebElement sendButton = driver.FindElement(By.CssSelector("div.action")).FindElement(By.TagName("a"));

                editArea.Clear();
                editArea.SendKeys(message);
                sendButton.Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                SendTextMessage(to, message);
            }catch(WebDriverException ex)
            {
                //timed out
                if (ex.Message.Contains("timed out"))
                {
                    SendTextMessage(to, message);
                }
                else
                    throw;
            }

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

            // 如果超时表示找不到此人
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(input
                    =>input != null && FindSearchResult(input,name)!=null);

            FindSearchResult(driver, name).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                    .Until(input
                            =>input != null && CurrentTitle(name, input));
        }

        private IWebElement FindSearchResult(IWebDriver driver,String name)
        {
            IWebElement list = FindSearchResult(driver);
            if (list == null) return null;
            return FindCorrectResult(list, name);
        }

        /// <summary>
        /// 从结果列表中定位唯一的准确结果
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private IWebElement FindCorrectResult(IWebElement list,String name)
        {
            return list.FindElements(By.ClassName("ng-scope"))
                    .Where(element =>
                    {
                        try
                        {
                            return element.FindElement(By.TagName("h4")).Text.Equals(name);
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    })
                    .FirstOrDefault();
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
