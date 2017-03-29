using NUnit.Framework;
using TBSync;
/*
* 版权所有:杭州火图科技有限公司
* 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
* (c) Copyright Hangzhou Hot Technology Co., Ltd.
* Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
* 2013-2017. All rights reserved.
* author guomw
**/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using HotTaoCore.Logic;
using HotCoreUtils.Helper;

namespace TBSync.Tests
{
    [TestFixture()]
    public class TBSyncControlPanelTests
    {
        [Test()]
        public void TBSyncControlPanelTest()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var data = LogicUser.Instance.login("demo", EncryptHelper.MD5("123456"));
            if (data != null)
            {
                //string[] args = { data.loginToken, data.userid.ToString() };
               // TBSyncControlPanel web = new TBSyncControlPanel(args);
               // Application.Run(web);
            }


            //Assert.Fail();


        }
    }
}