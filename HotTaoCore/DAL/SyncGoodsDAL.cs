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
        public List<SyncGoodsList> FindByUserSyncGoodsList(int userid, string taobaoname)
        {
            string strSql = @"select id,userid,taobaousername,goodsId,url from sync_goods_list where userid=@userid and taobaousername=@taobaousername";
            var param = new[] {
                new SQLiteParameter("@userid",userid),
                new SQLiteParameter("@taobaousername",taobaoname)
            };
            return DBHelper.ExecQueryList<SyncGoodsList>(strSql, param);
        }


        /// <summary>
        /// 获取用户绑定的淘宝淘宝账号
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>GoodsModel.</returns>
        public SyncAccountModel FindByUserSyncAccount(int userid)
        {
            string strSql = @"select id,userid,loginname,loginpwd from sync_account where userid=@userid limit 1;";
            var param = new[] {
                new SQLiteParameter("@userid",userid)
            };
            return DBHelper.ExecQueryEntity<SyncAccountModel>(strSql, param);
        }


        /// <summary>
        /// 添加账号到本地
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserSyncAccount(SyncAccountModel model)
        {
            //查找用户当前淘宝账号是否存在指定的商品未同步
            //存在则更新，否则添加
            var data = FindByUserSyncAccount(model.userid);
            string strSql = "";
            if (data == null)
            {
                strSql = @"insert into sync_account(userid,loginname,loginpwd) values(@userid,@loginname,@loginpwd);select last_insert_rowid();";
                var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@loginname",model.loginname),
                    new SQLiteParameter("@loginpwd",model.loginpwd)
                };
                return DBHelper.ExecuteSql(strSql, param);
            }
            else
            {
                strSql = @"UPDATE sync_account SET loginname=@loginname,loginpwd=@loginpwd WHERE id = @id;";
                var param = new[] {
                    new SQLiteParameter("@id",data.id),
                    new SQLiteParameter("@loginname",model.loginname),
                    new SQLiteParameter("@loginpwd",model.loginpwd)
                };
                return DBHelper.ExecuteSql(strSql, param);
            }
        }

        /// <summary>
        /// Finds the by user last synchronize time.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="taobaousername">The taobaousername.</param>
        /// <returns>LastSyncTimeModel.</returns>
        public LastSyncTimeModel FindByUserLastSyncTime(int userid, string taobaousername)
        {
            string strSql = @"select taobaousername,userid,datetime from sync_datetime where userid=@userid and taobaousername=@taobaousername limit 1;";
            var param = new[] {
                new SQLiteParameter("@userid",userid),
                new SQLiteParameter("@taobaousername",taobaousername)
            };
            return DBHelper.ExecQueryEntity<LastSyncTimeModel>(strSql, param);
        }

        /// <summary>
        /// 修改同步时间
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserLastSyncTime(LastSyncTimeModel model)
        {
            //查找用户当前淘宝账号是否存在指定的商品未同步
            //存在则更新，否则添加
            var data = FindByUserLastSyncTime(model.userid, model.taobaousername);
            string strSql = "";
            if (data == null)
                strSql = @"insert into sync_datetime(taobaousername,userid,datetime) values(@taobaousername,@userid,@datetime);select last_insert_rowid();";
            else
                strSql = @"UPDATE sync_datetime SET datetime=@datetime WHERE  userid=@userid and taobaousername=@taobaousername;";

            var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@taobaousername",model.taobaousername),
                    new SQLiteParameter("@datetime",model.datetime)
                };
            return DBHelper.ExecuteSql(strSql, param);
        }
    }
}
