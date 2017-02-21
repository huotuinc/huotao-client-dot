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
            new Worker().SendTextMessage("Guo Childe", "haha");
        }
    }
}
