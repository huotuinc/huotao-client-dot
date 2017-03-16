using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    /// <summary>
    /// 任务计划实体
    /// </summary>
    public class TaskPlanModel
    {
        public long id { get; set; }

        public int userid { get; set; }

        public string title { get; set; }

        /// <summary>
        /// 0 待执行  1进行中， 2已完成 3已过期
        /// </summary>
        /// <value>The status.</value>
        public int status { get; set; }

        /// <summary>
        /// 当前执行状态0,待执行，1执行中，2已执行，3已过期
        /// </summary>
        /// <value>The execute statu.</value>
        public int ExecStatus { get; set; }

        public string statusText { get; set; }
        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }


        public string startTimeText { get; set; }

        /// <summary>
        /// 任务执行完成时间
        /// </summary>
        /// <value>The finish time.</value>
        //public DateTime finishTime { get; set; }


        public string remark { get; set; }

        public string taskContent { get; set; }

        public string goodsText { get; set; }

        public string pidsText { get; set; }

        //public DateTime createTime { get; set; }

        /// <summary>
        /// 是否已转链 1是
        /// </summary>
        public int isTpwd { get; set; }
    }


    /// <summary>
    /// 任务计划推广位实体
    /// </summary>
    public class TaskPidModel
    {
        public int pid { get; set; }
    }


    /// <summary>
    /// 任务计划商品和推广位日志
    /// </summary>
    public class TaskGoodsPidLogModel
    {
        public int id { get; set; }

        public int userid { get; set; }

        public int taskid { get; set; }

        public int goodsid { get; set; }


        public int pid { get; set; }

        public DateTime createtime { get; set; }

        /// <summary>
        /// 生成淘口令分享文本
        /// </summary>
        public string shareText { get; set; }

    }

}
