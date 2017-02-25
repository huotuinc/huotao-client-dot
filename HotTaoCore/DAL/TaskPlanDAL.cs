using HotTaoCore.Models;
using HotCoreUtils.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HotCoreUtils.Helper;

namespace HotTaoCore.DAL
{
    public class TaskPlanDAL
    {
        /// <summary>
        /// 获取任务计划
        /// </summary>
        /// <returns></returns>
        public List<TaskPlanModel> getTaskPlanList(int userId)
        {
            string strSql = "select id,userid,title,startTime,status,goodsText,pidsText,createTime,remark,taskContent,endTime,finishTime,isTpwd from task_plan where isDel=0 and userid=@userid  order by status,startTime";
            var param = new[]
            {
                new SqlParameter("@userid",userId)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                var data = DbHelperSQL.GetEntityList<TaskPlanModel>(dr);
                if (data != null && data.Count() >= 0)
                {
                    data.ForEach(item =>
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

                            if (item.startTime.CompareTo(DateTime.Now) >= 0)
                            {
                                item.statusText = "进行中";
                                item.ExecStatus = 1;
                            }

                        }
                        item.startTimeText = item.startTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                    });
                }

                return data;
            }
        }

        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public bool deleteTaskPlan(int userid, int taskid)
        {
            string strSql = "update task_plan set isdel=1 where userid=@userid and id=@id";
            var param = new[]
            {
                new SqlParameter("@userid",userid),
                new SqlParameter("@id",taskid)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }

        /// <summary>
        /// 添加任务计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addTaskPlan(TaskPlanModel model)
        {
            string strSql = "insert into task_plan(userid,title,startTime,goodsText,pidsText,endTime) values(@userid,@title,@startTime,@goodsText,@pidsText,@endTime);select @@IDENTITY";
            var param = new[]
            {
                new SqlParameter("@userid",model.userid),
                new SqlParameter("@title",model.title),
                new SqlParameter("@startTime",model.startTime),
                new SqlParameter("@endTime",model.endTime),
                new SqlParameter("@goodsText",model.goodsText),
                new SqlParameter("@pidsText",model.pidsText)
            };
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param));
        }

        /// <summary>
        /// 修改任务计划
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int updateTaskPlan(TaskPlanModel model)
        {
            string strSql = "update task_plan set title=@title,startTime=@startTime ,endTime=@endTime where id=@id and userid=@userid";
            var param = new[]
            {
                new SqlParameter("@userid",model.userid),
                new SqlParameter("@title",model.title),
                new SqlParameter("@startTime",model.startTime),
                new SqlParameter("@endTime",model.endTime),
                new SqlParameter("@id",model.id),
            };
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param));
        }





        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addTaskGoodsPidLog(TaskGoodsPidLogModel model)
        {
            string strSql = "insert into task_goods_pid_log(userid,taskid,goodsid,pid,shareText) values(@userid,@taskid,@goodsid,@pid,@shareText) ";
            var param = new[]
            {
                new SqlParameter("@userid",model.userid),
                new SqlParameter("@taskid",model.taskid),
                new SqlParameter("@goodsid",model.goodsid),
                new SqlParameter("@pid",model.pid),
                new SqlParameter("@shareText",model.shareText)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param);
        }


        /// <summary>
        /// 删除任务计划对应的商品关联数据
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public bool deleteTaskGoodsPidLog(int userid, int taskid)
        {
            string strSql = "update task_goods_pid_log set statusCode=1 where userid=@userid and taskid=@taskid";
            var param = new[]
            {
                new SqlParameter("@userid",userid),
                new SqlParameter("@taskid",taskid)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }


        /// <summary>
        /// 获取需要执行的任务计划数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ReplyResponeModel> GetSoonExecuteTaskplan(int userid)
        {
            string strSql = @"select A.id,A.userid,A.taskid,a.shareText as [text],B.wechattitle as title,A.goodsid from task_goods_pid_log A with(nolock)
                                left join user_wechat_list B with(nolock) on B.id=A.pid
                                left join task_plan C with(nolock) on C.id=A.taskid
                                where A.userid=@userid and C.status=0 and A.statusCode=0 and C.startTime<GETDATE() and C.endTime>GETDATE()
                                and (A.shareText is not null or A.shareText<>'')
                                ";
            var param = new[]
            {
                new SqlParameter("@userid",userid)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                var data = DbHelperSQL.GetEntityList<ReplyResponeModel>(dr);
                return data;
            }
        }

        /// <summary>
        /// 获取需要执行的任务计划数据（完整，生成淘口令时调用）
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public List<ReplyResponeDetailModel> GetTaskplanGoodsList(int userid, int taskid)
        {
            string strSql = @"select A.id, A.userid,A.taskid,a.shareText as [text],E.pid,A.goodsid,D.goodsMainImgUrl,D.goodsName,D.shareLink,D.goodsPrice,D.couponPrice,D.goodsSupplier,D.couponUrl,D.goodsId  as ItemId,D.goodsSalesAmount from task_goods_pid_log A with(nolock)
                                left join user_wechat_list B with(nolock) on B.id=A.pid
                                left join userpid_list E with(nolock) on E.id=B.pidid
                                left join task_plan C with(nolock) on C.id=A.taskid
                                left join goods_list D with(nolock) on D.id=A.goodsid
                                where A.userid=@userid and A.taskid=@taskid and C.status=0 and A.statusCode=0 and  C.endTime>GETDATE() and (A.shareText is null or A.shareText='')";
            var param = new[]
            {
                new SqlParameter("@userid",userid),
                new SqlParameter("@taskid",taskid)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                var data = DbHelperSQL.GetEntityList<ReplyResponeDetailModel>(dr);
                if (data != null)
                {
                    Regex regs = new Regex("&activityId=[^&]*", RegexOptions.IgnoreCase);
                    string url = "https://uland.taobao.com/coupon/edetail";
                    data.ForEach(item =>
                    {
                        Match m = regs.Match(item.couponUrl);
                        if (m.Success)
                            url += "?src=ht_hot" + m.Value;
                        url += "&itemId=" + item.ItemId;
                        url += "&pid=" + item.pid;
                        item.shareLink = url;
                    });
                }

                return data;
            }
        }


        /// <summary>
        /// 修改已执行的任务状态
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool UpdateTaskFinished(int clientUid, List<int> lst)
        {
            string strSql = string.Format("update task_goods_pid_log set statusCode=1 where userid={1} and id in ({0})", string.Join(",", lst), clientUid);
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql) > 0;
        }
        /// <summary>
        /// 修改已执行的商品状态
        /// </summary>
        /// <param name="clientUid"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public bool UpdateTaskFinished(int clientUid, int itemid)
        {
            string strSql ="update task_goods_pid_log set statusCode=1 where userid=@userid and id=@id";
            var param = new[]
           {
                new SqlParameter("@userid",clientUid),
                new SqlParameter("@id",itemid),
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }


        /// <summary>
        /// 修改任务转链状态
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="lst">任务id</param>
        /// <returns></returns>
        public bool UpdateTaskIsTpwd(int userid, List<int> lst)
        {
            string strSql = string.Format("update task_plan set isTpwd=1 where userid={1} and id in ({0})", string.Join(",", lst), userid);
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql) > 0;
        }


        /// <summary>
        /// 批量修改用户转发的商品淘口令
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public int BatchUpdateUserGoodsTpwd(Dictionary<int, string> data, int userid, int taskid)
        {
            using (SqlConnection conn = new SqlConnection(GlobalConfig.getConnectionString()))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter sd = new SqlDataAdapter();
                    string strSql = string.Format("select id,shareText from task_goods_pid_log with(nolock) where statusCode=0 and userid={0} and taskid={1} and statusCode=0 and (shareText is null or shareText='')", userid, taskid);
                    sd.SelectCommand = new SqlCommand(strSql, conn);
                    DataSet dataset = new DataSet();
                    sd.Fill(dataset);
                    sd.SelectCommand.CommandTimeout = 100000;
                    sd.UpdateCommand = new SqlCommand(@"update task_goods_pid_log set shareText=@shareText where id=@id", conn);
                    sd.UpdateCommand.Parameters.Add("@shareText", SqlDbType.NVarChar, 0, "shareText");
                    sd.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                    sd.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
                    sd.UpdateCommand.CommandTimeout = 100000;
                    sd.UpdateBatchSize = 1000;

                    DataTable dt = dataset.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        int key = Convert.ToInt32(dr["id"]);
                        string tpwd = dr["shareText"].ToString();
                        if (data.ContainsKey(key))
                            tpwd = data[key];
                        dr["shareText"] = tpwd;
                    }

                    int effect = sd.Update(dataset.Tables[0]);
                    sd.Dispose();
                    dataset.Dispose();
                    return effect;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

        }


    }
}
