/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using HotTaoCore.DAL;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Logic
{
    /// <summary>
    /// 同步商品
    /// </summary>
    public class LogicSyncGoods
    {
        private static LogicSyncGoods _instance = null;
        private static LogicSyncGoods _ins = null;
        private static SyncGoodsDAL dal;

        private LogicSyncGoods()
        {

        }
        private LogicSyncGoods(int userid)
        {
            dal = new SyncGoodsDAL(userid);
        }
        public static LogicSyncGoods Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LogicSyncGoods();
                return _instance;
            }
        }
        public static LogicSyncGoods In(int userid)
        {
            if (_ins == null)
                _ins = new LogicSyncGoods(userid);
            return _ins;
        }

        /// <summary>
        /// 获取需要同步的商品数量
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <returns>System.String.</returns>
        public int GetCountForApplyGoods(string loginToken, string taobaono)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["taobaoUsername"] = taobaono;
            return BaseRequestService.PostToInt32(ApiConst.countForApplyGoods, data);
        }

        /// <summary>
        /// 获取需要同步的商品地址列表
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="taobaono">The taobaono.</param>
        /// <returns>System.Int32.</returns>
        public SyncGoodsModel GetListForApplyGoods(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return BaseRequestService.Post<SyncGoodsModel>(ApiConst.listForApplyGoods, data);
        }

        /// <summary>
        /// 确认最后商品同步时间
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <returns>SyncGoodsModel.</returns>
        public void GetConfirmForApplyGoods(string loginToken, string datetime)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["dateTime"] = datetime;
            BaseRequestService.Post(ApiConst.confirmForApplyGoods, data);
        }


        /// <summary>
        /// 绑定淘宝帐号
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="taobaoUsername">The taobao username.</param>
        /// <param name="taobaoPassword">可选参数；只有传入该值，并且设置为true的时候 才会更改绑定（而非初次绑定） 也就是意味着 直接绑定可能会给出错误，表示当前已绑定</param>
        /// <param name="confirm">if set to true [confirm].</param>
        public void BindTaobao(string loginToken, string taobaoUsername, string taobaoPassword, bool confirm)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["taobaoUsername"] = taobaoUsername;
            data["taobaoPassword"] = taobaoPassword;
            data["confirm"] = confirm.ToString();
            BaseRequestService.Post(ApiConst.bindTaobao, data);
        }



        /// <summary>
        /// 删除同步商品
        /// </summary>
        /// <param name="goodsId">The goods identifier.</param>
        /// <param name="userid">The userid.</param>
        /// <param name="taobaoname">The taobaoname.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserSyncGoods(string goodsId, int userid, string taobaoname)
        {
            return dal.DeleteUserSyncGoods(goodsId, userid, taobaoname);
        }

        /// <summary>
        /// 添加同步商品到本地数据库
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserSyncGoods(SyncGoodsList model)
        {
            return dal.AddUserSyncGoods(model);
        }


        /// <summary>
        /// 查找用户当前淘宝账号是否存在指定的商品未同步
        /// </summary>
        /// <param name="goodsId">The goods identifier.</param>
        /// <param name="userid">The userid.</param>
        /// <param name="taobaoname">The taobaoname.</param>
        /// <returns>GoodsModel.</returns>
        public GoodsModel FindByUserSyncGoodsInfo(string goodsId, int userid, string taobaoname)
        {
            return dal.FindByUserSyncGoodsInfo(goodsId, userid, taobaoname);
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="taobaoname">The taobaoname.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<GoodsModel> FindByUserSyncGoodsList(int userid, string taobaoname)
        {
            return dal.FindByUserSyncGoodsList(userid, taobaoname);
        }
    }
}
