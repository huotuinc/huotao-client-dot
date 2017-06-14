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

        private static DBSqliteHelper DBHelper;
        public HotTaoDAL(int userid)
        {
            DBHelper = new DBSqliteHelper(userid);
        }


        public void CloseConnection()
        {
            DBHelper.CloseConnection();
        }



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
            return DBHelper.ExecQueryEntity<weChatGroupModel>(strSql, param);
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
            return DBHelper.ExecQueryList<weChatGroupModel>(strSql, param);
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
            return DBHelper.ExecuteSql(strSql, param);
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
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }
        /// <summary>
        /// 修改微信pid
        /// </summary>
        /// <param name="groupid">The groupid.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool UpdateUserWeChatGroup(int groupid, string pid)
        {
            string strSql = @"UPDATE user_wechat_group SET  pid =@pid WHERE id = @id;";
            var param = new[] {
                    new SQLiteParameter("@pid",pid),
                    new SQLiteParameter("@id",groupid)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }





        /// <summary>
        /// 删除微信群
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserWeChatGroup(List<int> ids)
        {
            string strSql = string.Format("DELETE FROM user_wechat_group WHERE id in ({0});", string.Join(",", ids));
            return DBHelper.ExecuteSql(strSql) > 0;
        }
        /// <summary>
        /// 根据微信群删除微信群分享内容
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteWeChatShareText(string title)
        {
            string strSql = "delete from user_wechat_sharetext where title=@title;";
            var param = new[] {
                    new SQLiteParameter("@title",title)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }

        /// <summary>
        /// 删除分享文本
        /// </summary>
        /// <param name="taskid">The taskid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteShareText(int taskid)
        {
            string strSql = "delete from user_wechat_sharetext where taskid=@taskid;";
            var param = new[] {
                    new SQLiteParameter("@taskid",taskid)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
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
            return DBHelper.ExecQueryList<weChatGroupModel>(strSql, param);
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
            return DBHelper.ExecQueryEntity<GoodsModel>(strSql, param);
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
            return DBHelper.ExecQueryEntity<GoodsModel>(strSql, param);
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<GoodsModel> FindByUserGoodsList(int userid)
        {
            string strSql = @"select id,userid,goodsId,goodsName,goodsMainImgUrl,goodsIntro,goodslocatImgPath,goodsDetailUrl,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,couponPrice,endTime,couponUrl,couponId,updateTime from user_goods_list where userid=@userid order by updatetime desc;";
            var param = new[] {
                new SQLiteParameter("@userid",userid),
            };
            return DBHelper.ExecQueryList<GoodsModel>(strSql, param);
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<GoodsModel> FindByUserGoodsList(int userid, List<int> ids)
        {
            string strSql = string.Format(@"select id,userid,goodsId,goodsName,goodsMainImgUrl,goodsIntro,goodslocatImgPath,goodsDetailUrl,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,couponPrice,endTime,couponUrl,couponId,updateTime from user_goods_list where userid=@userid and id in ({0})  order by updatetime desc;", string.Join(",", ids));
            var param = new[] {
                new SQLiteParameter("@userid",userid),
            };
            return DBHelper.ExecQueryList<GoodsModel>(strSql, param);
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
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public bool DeleteGoodsByGoodsid(string goodsId)
        {
            string strSql = @"delete from user_goods_list WHERE goodsId = @goodsId;";
            var param = new[] {
                    new SQLiteParameter("@goodsId",goodsId)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }


        /// <summary>
        /// 删除所有本地商品
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteAllGoods(int userid)
        {
            string strSql = "delete from user_goods_list where userid=@userid;";
            var param = new[] {
                    new SQLiteParameter("@userid",userid)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }
        /// <summary>
        /// 删除选中的本地商品
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="ids">The ids.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteAllGoods(int userid, List<int> ids)
        {
            string strSql = string.Format(@"delete from user_goods_list where userid=@userid and id in ({0});", string.Join(",", ids));
            var param = new[] {
                    new SQLiteParameter("@userid",userid)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }


        /// <summary>
        /// 添加本地商品
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserGoods(GoodsModel model, out bool isUpdate)
        {
            isUpdate = false;
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
                return DBHelper.ExecuteSql(strSql, param);
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
                isUpdate = true;
                if (DBHelper.ExecuteSql(strSql, param) > 0)
                    return Convert.ToInt32(data.id);
                return 0;
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
            var item = DBHelper.ExecQueryEntity<TaskPlanModel>(strSql, param);
            if (item != null)
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
                else if (item.endTime.CompareTo(DateTime.Now) < 0)
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
            return DBHelper.ExecuteSql(strSql, param);
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
            return DBHelper.ExecuteSql(strSql, param);
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
            return DBHelper.ExecuteSql(strSql, param) > 0;
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
            return DBHelper.ExecuteSql(strSql, param) > 0;
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
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }

        /// <summary>
        /// 删除所有计划列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteAllTaskPlan(int userid)
        {
            string strSql = "delete from user_task_plan where userid=@userid;";
            var param = new[] {
                    new SQLiteParameter("@userid",userid)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }


        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>List&lt;GoodsModel&gt;.</returns>
        public List<TaskPlanModel> FindUserTaskPlanListByUserId(int userid, bool isFilterFinish)
        {
            string strSql = @"select id,userid,title,startTime,endTime,goodsText,pidsText,isTpwd,status from user_task_plan where userid=@userid ";
            if (isFilterFinish)
                strSql += " and status<>2 ";

            strSql += "  order by status asc,startTime asc;";

            var param = new[] {
                new SQLiteParameter("@userid",userid),
            };
            var data = DBHelper.ExecQueryList<TaskPlanModel>(strSql, param);

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
                    else if (item.endTime.CompareTo(DateTime.Now) < 0)
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
            return DBHelper.ExecuteSql(strSql, param);
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
            return DBHelper.ExecuteSql(strSql, param) > 0;
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
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }

        /// <summary>
        /// 修改发送状态
        /// </summary>
        /// <param name="shareid">The shareid.</param>
        /// <param name="text">The text.</param>
        /// <param name="tpwd">The TPWD.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool UpdateUserShareTextStatus(long shareid, string text, string tpwd)
        {
            string strSql = @"UPDATE user_wechat_sharetext SET status=0,text=@text,tpwd=@tpwd WHERE id = @id ;";
            var param = new[] {
                    new SQLiteParameter("@id",shareid),
                    new SQLiteParameter("@text",text),
                    new SQLiteParameter("@tpwd",tpwd)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shareid"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool UpdateUserShareText(long shareid, string text)
        {
            string strSql = @"UPDATE user_wechat_sharetext SET text=@text  WHERE id = @id ;";
            var param = new[] {
                    new SQLiteParameter("@id",shareid),
                    new SQLiteParameter("@text",text)
                };
            return DBHelper.ExecuteSql(strSql, param) > 0;
        }





        /// <summary>
        /// 添加微信发送失败数据
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserWeChatError(weChatUserWechatErrorModel model)
        {
            string strSql = "INSERT INTO user_wechat_error(userid,title,shareText,createtime,errorType) values(@userid,@title,@shareText,@createtime,@errorType);select last_insert_rowid();";
            var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@title",model.title),
                    new SQLiteParameter("@shareText",model.shareText),
                    new SQLiteParameter("@createtime",model.createtime),
                    new SQLiteParameter("@errorType",model.errorType)
                };
            return DBHelper.ExecuteSql(strSql, param);

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
            var data = DBHelper.ExecQueryList<weChatShareTextModel>(strSql, param);
            return data;
        }
        /// <summary>
        /// 获取发送内容列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="taskid">The taskid.</param>
        /// <param name="goodsid">The goodsid.</param>
        /// <returns>List&lt;weChatShareTextModel&gt;.</returns>
        public List<weChatShareTextModel> FindByUserWechatShareTextList(int userid, int taskid, int goodsid)
        {
            string strSql = @"select id,userid,title,text,taskid,goodsid,status,tpwd from user_wechat_sharetext where userid=@userid and taskid=@taskid and goodsid=@goodsid and status=0 ;";
            var param = new[] {
                    new SQLiteParameter("@taskid",taskid),
                    new SQLiteParameter("@userid",userid),
                    new SQLiteParameter("@goodsid",goodsid)
            };
            var data = DBHelper.ExecQueryList<weChatShareTextModel>(strSql, param);
            return data;
        }
        /// <summary>
        /// 获取发送内容列表
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>List&lt;weChatShareTextModel&gt;.</returns>
        public List<weChatShareTextModel> FindByUserWechatShareTextList(int userid)
        {
            string strSql = @"select id,userid,title,text,taskid,goodsid,status,tpwd from user_wechat_sharetext where userid=@userid  and status in (0,-1);";
            var param = new[] {
                    new SQLiteParameter("@userid",userid)
            };
            var data = DBHelper.ExecQueryList<weChatShareTextModel>(strSql, param);
            return data;
        }


        #endregion



        #region 记住账号密码
        /// <summary>
        /// 获取账号列表
        /// </summary>
        /// <returns>List&lt;LoginNameModel&gt;.</returns>
        public List<LoginNameModel> GetLoginNameList()
        {
            string strSql = "select userid,login_name,login_password,is_save_pwd from user_list;";
            return DBSqliteHelper.GetLoginNameList<LoginNameModel>(strSql);
        }

        /// <summary>
        /// 清空登录登录
        /// </summary>
        /// <returns></returns>
        public bool ClearLoginNameData()
        {
            string strSql = "delete from user_list;";

            return DBSqliteHelper.ExecuteSqlLoginName(strSql) > 0;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns>LoginNameModel.</returns>
        public LoginNameModel GetLoginName(string loginName)
        {
            string strSql = "select userid,login_name,login_password,is_save_pwd from user_list where login_name=@loginName;";
            var param = new[] {
                new SQLiteParameter("@loginName",loginName)
            };
            var data = DBSqliteHelper.GetLoginNameList<LoginNameModel>(strSql, param);
            if (data != null && data.Count() > 0)
                return data[0];
            return null;
        }
        /// <summary>
        /// 添加记住用户
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddLoginName(LoginNameModel model)
        {
            var data = GetLoginName(model.login_name);
            string strSql = string.Empty;
            if (data == null)
            {
                strSql = "INSERT INTO user_list(userid,login_name,login_password,is_save_pwd) values(@userid,@login_name,@login_password,@is_save_pwd);select last_insert_rowid();";
                var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@login_name",model.login_name),
                    new SQLiteParameter("@login_password",model.login_password),
                    new SQLiteParameter("@is_save_pwd",model.is_save_pwd)
                };
                return DBSqliteHelper.ExecuteSqlLoginName(strSql, param);
            }
            else
            {
                strSql = "update user_list set is_save_pwd=@is_save_pwd where userid=@userid";
                var param = new[] {
                    new SQLiteParameter("@userid",model.userid),
                    new SQLiteParameter("@is_save_pwd",model.is_save_pwd)
                };
                return DBSqliteHelper.ExecuteSqlLoginName(strSql, param);
            }
        }
        #endregion





    }
}
