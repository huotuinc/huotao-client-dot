using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weixin;

namespace WeixinTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Worker worker = new Worker();
            worker.SendTextMessage("Guo Childe", "haha "+ new DateTime());
            worker = null;
        }
    }
}
