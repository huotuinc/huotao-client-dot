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
using static HotTaoCore.Models.SQLiteEntitysModel;

namespace HotTaoCore.DAL
{
    public class HotTaoDAL
    {

        #region 微信群相关操作
        /// <summary>
        /// 获取微信群信息
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>weChatGroupModel.</returns>
        public weChatGroupModel FindByUserWeChatGroup(string title, int userid)
        {
            string strSql = @"select id,userid,title,pid from user_wechat_group where title=@title and userid=@userid limit 1;";
            var param = new[] {
                new SQLiteParameter("@title",title),
                new SQLiteParameter("@userid",userid)
            };
            return DBSqliteHelper.ExecQueryEntity<weChatGroupModel>(strSql, param);
        }


        /// <summary>
        /// 根据群id，获取群数据
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="ids">The ids.</param>
        /// <returns>weChatGroupModel.</returns>
        public List<weChatGroupModel> FindByUserWeChatGroup(int userid, List<int> ids)
        {
            string strSql = string.Format(@"select id,userid,title,pid from user_wechat_group where userid=@userid and id in ({0});", string.Join(",", ids));
            var param = new[] {
                new SQLiteParameter("@userid",userid)
            };
            return DBSqliteHelper.ExecQueryList<weChatGroupModel>(strSql, param);
        }






        /// <summary>
        /// 添加用户微信群
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserWeChatGroup(weChatGroupModel model)
        {
            var data = FindByUserWeChatGroup(model.title, model.userid);
            string strSql = "";
            long id = 0;
            if (data == null)
                strSql = @"INSERT INTO user_wechat_group (userid,title,pid) VALUES(@userid,@title,@pid);select last_insert_rowid(); ";
            else
            {
                id = data.id;
                strSql = @"UPDATE user_wechat_group SET title=@title, pid =@pid WHERE id = @id and userid=@userid;";
            }

            var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@title",model.title),
                    new SQLiteParameter("@pid",model.pid),
                    new SQLiteParameter("@id",id)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param);
        }

        /// <summary>
        /// 修改微信群
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool UpdateUserWeChatGroup(weChatGroupModel model)
        {
            string strSql = @"UPDATE user_wechat_group SET title=@title, pid =@pid WHERE id = @id and userid=@userid;";
            var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@title",model.title),
                    new SQLiteParameter("@pid",model.pid),
                    new SQLiteParameter("@id",model.id)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param) > 0;
        }

        /// <summary>
        /// 删除微信群
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserWeChatGroup(List<int> ids)
        {
            string strSql = string.Format("DELETE FROM user_wechat_group WHERE id in ({0});", string.Join(",", ids));
            return DBSqliteHelper.ExecuteSql(strSql) > 0;
        }


        /// <summary>
        /// 根据用户id，获取微信群
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>List&lt;weChatGroupModel&gt;.</returns>
        public List<weChatGroupModel> GetUserWeChatGroupListByUserId(int userid)
        {
            string strSql = @"select id,userid,title,pid from user_wechat_group where userid=@userid;";
            var param = new[] {
                new SQLiteParameter("@userid",userid),
            };
            return DBSqliteHelper.ExecQueryList<weChatGroupModel>(strSql, param);
        }

        #endregion





        #region 商品相关操作

        /// <summary>
        /// 根据商品id获取商品信息
        /// </summary>
        /// <param name="goodsId">The goods identifier.</param>
        /// <returns>GoodsModel.</returns>
        public GoodsModel FindByUserGoodsInfo(string goodsId, int userid)
        {
            string strSql = @"select id,userid,goodsId,goodsName,goodsMainImgUrl,goodsIntro,goodslocatImgPath,goodsDetailUrl,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,couponPrice,endTime,couponUrl,couponId,updateTime from user_goods_list where userid=@userid and goodsId=@goodsId;";
            var param = new[] {
                new SQLiteParameter("@goodsId",goodsId),
                new SQLiteParameter("@userid",userid)
            };
            return DBSqliteHelper.ExecQueryEntity<GoodsModel>(strSql, param);
        }

        /// <summary>
        /// 根据商品自增ID，获取商品信息
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns>GoodsModel.</returns>
        public GoodsModel FindByUserGoodsInfo(int gid)
        {
            string strSql = @"select id,userid,goodsId,goodsName,goodsMainImgUrl,goodsIntro,goodslocatImgPath,goodsDetailUrl,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,couponPrice,endTime,couponUrl,couponId,updateTime from user_goods_list where id=@id;";
            var param = new[] {
                new SQLiteParameter("@id",gid),
            };
            return DBSqliteHelper.ExecQueryEntity<GoodsModel>(strSql, param);
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<GoodsModel> FindByUserGoodsList(int userid)
        {
            string strSql = @"select id,userid,goodsId,goodsName,goodsMainImgUrl,goodsIntro,goodslocatImgPath,goodsDetailUrl,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,couponPrice,endTime,couponUrl,couponId,updateTime from user_goods_list where userid=@userid;";
            var param = new[] {
                new SQLiteParameter("@userid",userid),
            };
            return DBSqliteHelper.ExecQueryList<GoodsModel>(strSql, param);
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<GoodsModel> FindByUserGoodsList(int userid, List<int> ids)
        {
            string strSql = string.Format(@"select id,userid,goodsId,goodsName,goodsMainImgUrl,goodsIntro,goodslocatImgPath,goodsDetailUrl,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,couponPrice,endTime,couponUrl,couponId,updateTime from user_goods_list where userid=@userid and id in ({0});", string.Join(",", ids));
            var param = new[] {
                new SQLiteParameter("@userid",userid),
            };
            return DBSqliteHelper.ExecQueryList<GoodsModel>(strSql, param);
        }


        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteGoods(int gid)
        {
            string strSql = @"delete from user_goods_list WHERE id = @id;";
            var param = new[] {
                    new SQLiteParameter("@id",gid)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param) > 0;
        }


        /// <summary>
        /// 添加本地商品
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserGoods(GoodsModel model)
        {
            var data = FindByUserGoodsInfo(model.goodsId, model.userid);
            string strSql = "";
            if (data == null)
            {
                strSql = @"insert into user_goods_list(userid,goodsId,goodsName,goodslocatImgPath,goodsMainImgUrl,goodsDetailUrl,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,couponPrice,endTime,couponUrl,couponId,updateTime,goodsIntro) values(@userid,@goodsId,@goodsName,@goodslocatImgPath,@goodsMainImgUrl,@goodsDetailUrl,@goodsSupplier,@goodsSalesAmount,@goodsComsRate,@goodsPrice,@couponPrice,@endTime,@couponUrl,@couponId,@updateTime,@goodsIntro);select last_insert_rowid();";
                var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@goodsId",model.goodsId),
                    new SQLiteParameter("@goodsName",model.goodsName),
                    new SQLiteParameter("@goodslocatImgPath",model.goodslocatImgPath),
                    new SQLiteParameter("@goodsMainImgUrl",model.goodsMainImgUrl),
                    new SQLiteParameter("@goodsDetailUrl",model.goodsDetailUrl),
                    new SQLiteParameter("@goodsSupplier",model.goodsSupplier),
                    new SQLiteParameter("@goodsSalesAmount",model.goodsSalesAmount),
                    new SQLiteParameter("@goodsComsRate",model.goodsComsRate),
                    new SQLiteParameter("@goodsPrice",model.goodsPrice),
                    new SQLiteParameter("@couponPrice",model.couponPrice),
                    new SQLiteParameter("@endTime",model.endTime),
                    new SQLiteParameter("@couponUrl",model.couponUrl),
                    new SQLiteParameter("@couponId",model.couponId),
                    new SQLiteParameter("@goodsIntro",model.goodsIntro),
                    new SQLiteParameter("@updateTime",DateTime.Now)
                };
                return DBSqliteHelper.ExecuteSql(strSql, param);
            }
            else
            {
                strSql = @"UPDATE user_goods_list SET goodsSalesAmount=@goodsSalesAmount,goodsIntro=@goodsIntro, goodsPrice =@goodsPrice,endTime=@endTime,couponUrl=@couponUrl,couponId=@couponId,updateTime=@updateTime WHERE id = @id;";
                var param = new[] {
                    new SQLiteParameter("@id",data.id),
                    new SQLiteParameter("@goodsSalesAmount",model.goodsSalesAmount),
                    new SQLiteParameter("@goodsComsRate",model.goodsComsRate),
                    new SQLiteParameter("@goodsPrice",model.goodsPrice),
                    new SQLiteParameter("@couponPrice",model.couponPrice),
                    new SQLiteParameter("@endTime",model.endTime),
                    new SQLiteParameter("@couponUrl",model.couponUrl),
                    new SQLiteParameter("@couponId",model.couponId),
                    new SQLiteParameter("@goodsIntro",model.goodsIntro),
                    new SQLiteParameter("@updateTime",DateTime.Now)
                };
                return DBSqliteHelper.ExecuteSql(strSql, param);
            }


        }


        #endregion



        #region 任务计划相关操作



        /// <summary>
        /// 获取任务信息
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <returns>TaskPlanModel.</returns>
        public TaskPlanModel FindByUserTaskPlanInfo(int userid, int taskid)
        {
            string strSql = @"select id,userid,title,startTime,endTime,goodsText,pidsText,isTpwd,status from user_task_plan where id=@id and userid=@userid;";
            var param = new[] {
                new SQLiteParameter("@id",taskid),
                new SQLiteParameter("@userid",userid)
            };
            var item = DBSqliteHelper.ExecQueryEntity<TaskPlanModel>(strSql, param);
            if (item != null)
            {
                item.statusText = "待执行";
                if (item.status == 1)
                {
                    item.statusText = "已完成";
                    item.ExecStatus = 2;
                }
                else
                {
                    if (item.endTime.CompareTo(DateTime.Now) < 0)
                    {
                        item.statusText = "已过期";
                        item.ExecStatus = 3;
                    }

                    if (item.startTime.CompareTo(DateTime.Now) < 0)
                    {
                        item.statusText = "进行中";
                        item.ExecStatus = 1;
                    }
                }
                if (item.isTpwd == 0)
                {
                    item.statusText = "待转链,双击进行转链";
                    item.ExecStatus = 0;
                }
                item.startTimeText = item.startTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            }

            return item;
        }



        /// <summary>
        /// 添加用户计划任务
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserTaskPlan(TaskPlanModel model)
        {
            string strSql = @"INSERT INTO user_task_plan (userid,title,startTime,endTime,goodsText,pidsText,isTpwd,status) VALUES(@userid,@title,@startTime,@endTime,@goodsText,@pidsText,0,0);select last_insert_rowid(); ";

            var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@title",model.title),
                    new SQLiteParameter("@startTime",model.startTime),
                    new SQLiteParameter("@endTime",model.endTime),
                    new SQLiteParameter("@goodsText",model.goodsText),
                    new SQLiteParameter("@pidsText",model.pidsText)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param);
        }

        /// <summary>
        /// 修改用户计划任务
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateUserTaskPlan(TaskPlanModel model)
        {
            string strSql = @"UPDATE user_task_plan SET title=@title,startTime=@startTime,endTime=@endTime WHERE id = @id ";

            var param = new[] {
                    new SQLiteParameter("@id",model.id),
                    new SQLiteParameter("@title",model.title),
                    new SQLiteParameter("@startTime",model.startTime),
                    new SQLiteParameter("@endTime",model.endTime)
                    //new SQLiteParameter("@goodsText",model.goodsText),
                    //new SQLiteParameter("@pidsText",model.pidsText)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param);
        }


        /// <summary>
        /// 修改用户计划任务执行状态
        /// </summary>
        /// <param name="taskid">The taskid.</param>
        /// <param name="status">The status.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool UpdateUserTaskPlanExecStatus(int taskid, int status)
        {
            string strSql = @"UPDATE user_task_plan SET status=@status WHERE id = @id ;";
            var param = new[] {
                    new SQLiteParameter("@status",status),
                    new SQLiteParameter("@id",taskid)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param) > 0;
        }

        /// <summary>
        /// 修改用户计划任务转链状态,转链成功后调用
        /// </summary>
        /// <param name="taskid">The taskid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool UpdateUserTaskPlanIsTpwd(int taskid)
        {
            string strSql = @"UPDATE user_task_plan SET isTpwd=1 WHERE id = @id ;";
            var param = new[] {
                    new SQLiteParameter("@id",taskid)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param) > 0;
        }


        /// <summary>
        /// 删除用户任务
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserTaskPlan(int taskid)
        {
            string strSql = "DELETE FROM user_task_plan WHERE id =@id;DELETE from user_wechat_sharetext where taskid=@id;";
            var param = new[] {
                    new SQLiteParameter("@id",taskid)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param) > 0;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<TaskPlanModel> FindByUserTaskPlanList(int userid)
        {
            string strSql = @"select id,userid,title,startTime,endTime,goodsText,pidsText,isTpwd,status from user_task_plan where userid=@userid;";
            var param = new[] {
                new SQLiteParameter("@userid",userid),
            };
            var data = DBSqliteHelper.ExecQueryList<TaskPlanModel>(strSql, param);

            if (data != null)
            {
                data.ForEach(item =>
                {
                    item.statusText = "待执行";
                    if (item.status == 1)
                    {
                        item.statusText = "进行中";
                        item.ExecStatus = 1;
                    }
                    else if (item.status == 2)
                    {
                        item.statusText = "已完成";
                        item.ExecStatus = 2;
                    }

                    if (item.endTime.CompareTo(DateTime.Now) < 0)
                    {
                        item.statusText = "已过期";
                        item.ExecStatus = 3;
                        item.status = 3;
                    }

                    if (item.isTpwd == 0)
                    {
                        item.statusText = "待转链,双击进行转链";
                        item.ExecStatus = 0;
                        item.status = 0;
                    }

                    item.startTimeText = item.startTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                });
            }

            return data;
        }

        /// <summary>
        /// 添加微信分享数据
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserWechatSharetext(weChatShareTextModel model)
        {
            string strSql = @"INSERT INTO user_wechat_sharetext (userid,title,text,taskid,goodsid,status,tpwd) VALUES(@userid,@title,@text,@taskid,@goodsid,@status,@tpwd);select last_insert_rowid(); ";

            var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@title",model.title),
                    new SQLiteParameter("@text",model.text),
                    new SQLiteParameter("@taskid",model.taskid),
                    new SQLiteParameter("@goodsid",model.goodsid),
                    new SQLiteParameter("@status",model.status),
                    new SQLiteParameter("@tpwd",model.tpwd)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param);
        }

        /// <summary>
        /// 删除分享数据
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="taskid">The taskid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserWechatShareText(int userid, int taskid)
        {
            string strSql = "DELETE FROM user_wechat_sharetext WHERE userid =@userid and taskid=@taskid;";
            var param = new[] {
                    new SQLiteParameter("@taskid",taskid),
                    new SQLiteParameter("@userid",userid)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param) > 0;
        }

        /// <summary>
        /// 修改发送状态
        /// </summary>
        /// <param name="shareid">The shareid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool UpdateUserShareTextStatus(long shareid)
        {
            string strSql = @"UPDATE user_wechat_sharetext SET status=1 WHERE id = @id ;";
            var param = new[] {
                    new SQLiteParameter("@id",shareid)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param) > 0;
        }


        /// <summary>
        /// 添加微信发送失败数据
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserWeChatError(weChatUserWechatErrorModel model)
        {
            string strSql = "INSERT INTO user_wechat_error(userid,title,shareText,createtime) values(@userid,@title,@shareText,@createtime);select last_insert_rowid();";
            var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@title",model.title),
                    new SQLiteParameter("@goodsName",model.shareText),
                    new SQLiteParameter("@createtime",model.createtime)
                };
            return DBSqliteHelper.ExecuteSql(strSql, param);

        }




        /// <summary>
        /// 获取发送内容列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="taskid">The taskid.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<weChatShareTextModel> FindByUserWechatShareTextList(int userid, int taskid)
        {
            string strSql = @"select id,userid,title,text,taskid,goodsid,status,tpwd from user_wechat_sharetext where userid=@userid and taskid=@taskid;";
            var param = new[] {
                    new SQLiteParameter("@taskid",taskid),
                    new SQLiteParameter("@userid",userid)
            };
            var data = DBSqliteHelper.ExecQueryList<weChatShareTextModel>(strSql, param);
            return data;
        }
        /// <summary>
        /// 获取发送内容列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="taskid">The taskid.</param>
        /// <param name="goodsid">The goodsid.</param>
        /// <returns>List&lt;weChatShareTextModel&gt;.</returns>
        public List<weChatShareTextModel> FindByUserWechatShareTextList(int userid, int taskid,int goodsid)
        {
            string strSql = @"select id,userid,title,text,taskid,goodsid,status,tpwd from user_wechat_sharetext where userid=@userid and taskid=@taskid and goodsid=@goodsid and status=0 ;";
            var param = new[] {
                    new SQLiteParameter("@taskid",taskid),
                    new SQLiteParameter("@userid",userid),
                    new SQLiteParameter("@goodsid",goodsid)
            };
            var data = DBSqliteHelper.ExecQueryList<weChatShareTextModel>(strSql, param);
            return data;
        }


        #endregion
    }
}
