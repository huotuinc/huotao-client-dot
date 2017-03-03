using HotCoreUtils.Helper;
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

            item.statusText = "待执行";
            if (item.status == 1)
                item.statusText = "已完成";
            else if (item.status == 2)
                item.statusText = "进行中";
            else if (item.status == 3)
                item.statusText = "已过期";
            item.startTimeText = item.startTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            return item;
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
    }
}
