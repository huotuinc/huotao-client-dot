using HotCoreUtils.Helper;
using HotTaoCore.DAL;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Logic
{
    public class LogicTaskPlan
    {
        private static TaskPlanDAL dal = new TaskPlanDAL();

        private static LogicTaskPlan _instance = new LogicTaskPlan();

        public static LogicTaskPlan Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 获取任务计划
        /// </summary>
        /// <returns></returns>
        public List<TaskPlanModel> getTaskPlanList(int userId)
        {
            return dal.getTaskPlanList(userId);
        }
        /// <summary>
        /// 获取任务计划
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <returns>List&lt;TaskPlanModel&gt;.</returns>
        public List<TaskPlanModel> getTaskPlanList(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            var taskData = BaseRequestService.Post<List<TaskPlanModel>>(ApiConst.getTaskList, data);
            if (taskData != null)
            {
                taskData.ForEach(item =>
                {
                    item.statusText = "待执行";
                    if (item.status == 1)
                        item.statusText = "已完成";
                    else if (item.status == 2)
                        item.statusText = "进行中";
                    else if (item.status == 3)
                        item.statusText = "已过期";
                    item.startTimeText = item.startTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                });
            }
            return taskData;

        }

        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public bool deleteTaskPlan(string loginToken, string taskids)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["taskids"] = taskids;
            return BaseRequestService.Post(ApiConst.delTask, data);
        }

        /// <summary>
        /// 添加/修改任务计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TaskPlanModel addTaskPlan(string loginToken, TaskPlanModel model)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            if (model.id > 0)
                data["id"] = model.id.ToString();
            else
            {
                data["groupids"] = model.pidsText;
                data["goodsids"] = model.goodsText;
            }
            data["title"] = model.title;
            data["executetime"] = model.startTime.ToString("yyyy-MM-dd HH:mm:ss");
            data["endtime"] = model.endTime.ToString("yyyy-MM-dd HH:mm:ss");
            var item = BaseRequestService.Post<TaskPlanModel>(ApiConst.saveTask, data);
            if (item == null) return item;
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
            item.startTimeText = item.startTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            return item;
        }
        /// <summary>
        /// 修改任务计划
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int updateTaskPlan(TaskPlanModel model)
        {
            return dal.updateTaskPlan(model);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addTaskGoodsPidLog(TaskGoodsPidLogModel model)
        {
            return dal.addTaskGoodsPidLog(model);
        }

        /// <summary>
        /// 删除任务计划对应的商品关联数据
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public bool deleteTaskGoodsPidLog(int userid, int taskid)
        {
            return dal.deleteTaskGoodsPidLog(userid, taskid);
        }


        /// <summary>
        /// 获取需要执行的任务计划数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<ReplyResponeModel> GetSoonExecuteTaskplan(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return BaseRequestService.Post<List<ReplyResponeModel>>(ApiConst.getTaskExecuteList, data);
        }

        /// <summary>
        /// 修改已执行的任务状态
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool UpdateTaskFinished(string loginToken, int taskid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["id"] = taskid.ToString();
            return BaseRequestService.Post(ApiConst.modifyTaskStatus, data);
        }
        /// <summary>
        /// 修改执行数据的状态
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="taskid">The taskid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool UpdateExecuteTaskFinished(string loginToken, int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["id"] = id.ToString();
            return BaseRequestService.Post(ApiConst.modifyTaskExecuteStatus, data);

        }
        /// <summary>
        /// 修改已执行的商品状态
        /// </summary>
        /// <param name="clientUid"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public bool UpdateTaskFinished(int clientUid, int itemid)
        {
            return dal.UpdateTaskFinished(clientUid, itemid);
        }

        /// <summary>
        /// 开始任务转链
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public bool StartTaskTpwd(string loginToken, int taskid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["taskid"] = taskid.ToString();
            return BaseRequestService.Post(ApiConst.turnChain, data);
        }
        /// <summary>
        /// 修改任务转链状态
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="lst">任务id</param>
        /// <returns></returns>
        public bool UpdateTaskIsTpwd(int userid, List<int> lst)
        {
            if (lst != null && lst.Count() > 0 && userid > 0)
                return dal.UpdateTaskIsTpwd(userid, lst);

            return false;
        }
        /// <summary>
        /// 生成淘口令
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        private bool bacthBuildTpwd(int userid, int taskid)
        {
            try
            {
                List<ReplyResponeDetailModel> lst = dal.GetTaskplanGoodsList(userid, taskid);
                if (lst == null) return false;
                Dictionary<int, string> root = new Dictionary<int, string>();
                string tempText = LogicUser.Instance.GetUserSendTemplate("");
                bool isBuildError = false;
                lst.ForEach(item =>
                {
                    if (!string.IsNullOrEmpty(item.goodsName) && !string.IsNullOrEmpty(item.ItemId))
                    {
                        string shortUrl = HotTaoApiService.Instance.taobao_tbk_spread_get(item.shareLink);
                        string tpwd = HotTaoApiService.Instance.taobao_wireless_share_tpwd_create(item.goodsMainImgUrl, item.shareLink, item.goodsName);
                        string text = tempText;
                        if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(tpwd))
                        {
                            while (text.Contains("[商品标题]"))
                                text = text.Replace("[商品标题]", item.goodsName);
                            while (text.Contains("[商品价格]"))
                                text = text.Replace("[商品价格]", item.goodsPrice.ToString());
                            while (text.Contains("[券后价格]"))
                                text = text.Replace("[券后价格]", (item.goodsPrice - item.couponPrice).ToString());
                            while (text.Contains("[二合一淘口令]"))
                                text = text.Replace("[二合一淘口令]", tpwd);
                            while (text.Contains("[短链接]"))
                                text = text.Replace("[短链接]", shortUrl);
                            while (text.Contains("[来源]"))
                                text = text.Replace("[来源]", item.goodsSupplier);
                            while (text.Contains("[销量]"))
                                text = text.Replace("[销量]", item.goodsSalesAmount.ToString());
                            while (text.Contains("[优惠券价格]"))
                                text = text.Replace("[优惠券价格]", item.couponPrice.ToString());
                            while (text.Contains("[分隔符]"))
                                text = text.Replace("[分隔符]", "-----------------");
                            root.Add(item.id, text);
                        }
                        if (string.IsNullOrEmpty(tpwd))
                            isBuildError = true;
                    }
                });

                if (root.Count() > 0)
                {
                    //批量处理数据
                    int result = dal.BatchUpdateUserGoodsTpwd(root, userid, taskid);
                    if (!isBuildError)
                        isBuildError = result == root.Count() ? false : true;
                }

                return !isBuildError;
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex.ToString());
                return false;
            }

        }
    }
}
