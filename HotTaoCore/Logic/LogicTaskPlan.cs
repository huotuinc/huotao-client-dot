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
        /// 删除计划
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public bool deleteTaskPlan(int userid, int taskid)
        {
            if (dal.deleteTaskPlan(userid, taskid))
                dal.deleteTaskGoodsPidLog(userid, taskid);

            return true;
        }

        /// <summary>
        /// 添加任务计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addTaskPlan(TaskPlanModel model)
        {
            return dal.addTaskPlan(model);
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
        public List<ReplyResponeDetailModel> GetSoonExecuteTaskplan(int userid)
        {
            return dal.GetSoonExecuteTaskplan(userid);
        }

        /// <summary>
        /// 修改已执行的任务状态
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool UpdateTaskFinished(int clientUid, List<int> lst)
        {
            return dal.UpdateTaskFinished(clientUid, lst);
        }
    }
}
