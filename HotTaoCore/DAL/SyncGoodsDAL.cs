/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.DAL
{
    public class SyncGoodsDAL
    {
        private static DBSqliteHelper DBHelper;
        public SyncGoodsDAL(int userid)
        {
            DBHelper = new DBSqliteHelper(userid, "syncgoods");
        }
        public void CloseConnection()
        {
            DBHelper.CloseConnection();
        }





        /// <summary>
        /// 添加同步商品到本地数据库
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserSyncGoods(SyncGoodsList model)
        {
            //查找用户当前淘宝账号是否存在指定的商品未同步
            //存在则更新，否则添加
            var data = FindByUserSyncGoodsInfo(model.goodsId, model.userid, model.taobaousername);
            string strSql = "";
            if (data == null)
            {
                strSql = @"insert into sync_goods_list(userid,taobaousername,goodsId,url) values(@userid,@taobaousername,@goodsId,@url);select last_insert_rowid();";
                var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@taobaousername",model.taobaousername),
                    new SQLiteParameter("@goodsId",model.goodsId),
                    new SQLiteParameter("@url",model.url)
                };
                return DBHelper.ExecuteSql(strSql, param);
            }
            else
            {
                strSql = @"UPDATE sync_goods_list SET url=@url WHERE id = @id;";
                var param = new[] {
                    new SQLiteParameter("@id",data.id),
                    new SQLiteParameter("@url",model.url)
                };
                return DBHelper.ExecuteSql(strSql, param);
            }
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
            string strSql = @"select id,userid,taobaousername,goodsId,url from sync_goods_list where userid=@userid and goodsId=@goodsId and taobaousername=@taobaousername limit 1;";
            var param = new[] {
                new SQLiteParameter("@goodsId",goodsId),
                new SQLiteParameter("@userid",userid),
                new SQLiteParameter("@taobaousername",taobaoname)
            };
            return DBHelper.ExecQueryEntity<GoodsModel>(strSql, param);
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
            string strSql = @"delete from sync_goods_list WHERE userid=@userid and goodsId=@goodsId and taobaousername=@taobaousername";
            var param = new[] {
                    new SQLiteParameter("@goodsId",goodsId),
                    new SQLiteParameter("@userid",userid),
                    new SQLiteParameter("@taobaousername",taobaoname)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }


        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="taobaoname">The taobaoname.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<GoodsModel> FindByUserSyncGoodsList(int userid, string taobaoname)
        {
            string strSql = @"select id,userid,taobaousername,goodsId,url from sync_goods_list where userid=@userid and taobaousername=@taobaousername";
            var param = new[] {
                new SQLiteParameter("@userid",userid),
                new SQLiteParameter("@taobaousername",taobaoname)
            };
            return DBHelper.ExecQueryList<GoodsModel>(strSql, param);
        }


    }
}
