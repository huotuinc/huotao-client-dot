using HotJoinImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DemoLib
{
    public class DemoTest
    {


        static List<JoinGoodsInfo> list = new List<JoinGoodsInfo>();

        /// <summary>
        /// 三合一
        /// </summary>
        public static void Test3()
        {
            list.Clear();
            list.Add(new JoinGoodsInfo()
            {
                GoodsName = "组合装短袖T恤女夏装韩版V领宽松竹节棉白色，半袖体恤简约百搭上衣恤简约百搭上衣速抢，均码加厚高质量手套10速抢均码加厚高质量手套10速抢均码加厚高质量手套10",
                CouponPrice = 5,
                GoodsPrice = 39,
                imagePath = "images/1.jpg",
                GoodsIntro = "全网销量最吊！没有之一 史上最逆天的价格 错速抢均码加厚高，质量手套10速抢均码加厚高质量手套10！"
            });

            list.Add(new JoinGoodsInfo()
            {
                GoodsName = "笑巴喜儿童餐椅多功能实木宝宝吃饭饭桌餐椅婴幼婴儿座椅木质座椅恤简约百搭上衣",
                CouponPrice = 65,
                GoodsPrice = 176,
                imagePath = "images/2.jpg",
                GoodsIntro = "双一国企品质，专注家用手套60年，均码加厚高质量手套10双+纤维麻布10块，居家必备，速抢均码加厚高质量手，套10速抢均码加厚高质量手套10速抢均码加厚高质量，手套10速抢均码加厚，高质量手套10速抢均码加厚高质量手套10速抢均码加厚高质量手套10"
            });
            list.Add(new JoinGoodsInfo()
            {
                GoodsName = "温碧泉【透芯润】水乳套装50ml",
                CouponPrice = 120,
                GoodsPrice = 219,
                imagePath = "images/3.jpg",
                GoodsIntro = "线下专柜售129元，源自，温碧泉旗舰店源自温碧泉旗舰店源自温碧泉旗舰店源自温碧泉旗舰店源自温碧，泉旗舰店源自温碧泉旗舰店源自温碧泉旗舰店，温和清洁，深润滋养，补水明星，女神必备【赠运费险费险】"
            });
            var result = JoinImage.GetGoodsJoinImage(list, "http://c.b1yt.com/h.N5aQTO?cv=563r00qWWZn");
            result.Save("3.jpg");
            System.Diagnostics.Process.Start(@"3.jpg");
        }



        public static void Test2()
        {

            list.Add(new JoinGoodsInfo()
            {
                GoodsName = "组合装短袖T恤女夏装韩版V领宽松竹节棉白色，半袖体恤简约百搭上衣恤简约百搭上衣速抢，均码加厚高质量手套10速抢均码加厚高质量手套10速抢均码加厚高质量手套10",
                CouponPrice = 5,
                GoodsPrice = 39,
                imagePath = "images/1.jpg",
                GoodsIntro = "全网销量最吊！没有之一 史上最逆天的价格 错速抢均码加厚高，质量手套10速抢均码加厚高质量手套10！"
            });

            list.Add(new JoinGoodsInfo()
            {
                GoodsName = "笑巴喜儿童餐椅多功能实木宝宝吃饭饭桌餐椅婴幼婴儿座椅木质座椅恤简约百搭上衣",
                CouponPrice = 65,
                GoodsPrice = 176,
                imagePath = "images/2.jpg",
                GoodsIntro = "双一国企品质，专注家用手套60年，均码加厚高质量手套10双+纤维麻布10块，居家必备，速抢均码加厚高质量手，套10速抢均码加厚高质量手套10速抢均码加厚高质量，手套10速抢均码加厚，高质量手套10速抢均码加厚高质量手套10速抢均码加厚高质量手套10"
            });
            var result = JoinImage.GetGoodsJoinImage(list, "http://c.b1yt.com/h.N5aQTO?cv=563r00qWWZn");
            result.Save("2.jpg");
            System.Diagnostics.Process.Start(@"2.jpg");
        }


        public static void Test1()
        {
            list.Clear();
            var data = new JoinGoodsInfo()
            {
                GoodsName = "笑巴喜儿童餐椅多功能实木宝宝吃饭饭桌餐椅婴幼婴儿座椅木质座椅恤简约百搭上衣",
                CouponPrice = 5,
                GoodsPrice = 176,
                imagePath = "images/1.jpg",
                GoodsIntro = "双一国企品质，专注家用手套60年，均码加厚高质量手套10双+纤维麻布10块，居家必备，速抢均码加厚高质量手套10"
            };
            list.Add(data);
            var result = JoinImage.GetGoodsJoinImage(list, "http://c.b1yt.com/h.N5aQTO?cv=563r00qWWZn");
            result.Save("1.jpg");
            System.Diagnostics.Process.Start(@"1.jpg");
        }

        public static void Test4()
        {
            list.Clear();
            var data = new JoinGoodsInfo()
            {
                GoodsName = "笑巴喜儿童餐椅多功能实木宝宝吃饭饭桌餐椅婴幼婴儿座椅木质座椅恤简约百搭上衣",
                CouponPrice = 5,
                GoodsPrice = 176,
                imagePath = "images/6.jpg",
                GoodsIntro = "双一国企品质，专注家用手套60年，均码加厚高质量手套10双+纤维麻布10块，居家必备，速抢均码加厚高质量手套10"
            };
            list.Add(data);
            var result = JoinImage.GetGoodsJoinImage(list, "http://c.b1yt.com/h.N5aQTO?cv=563r00qWWZn");
            result.Save("4.jpg");
            System.Diagnostics.Process.Start(@"4.jpg");
        }
    }
}
