using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    /// <summary>
    /// 用户福利推广位实体
    /// </summary>
    public class UserPidModel
    {
        public int id { get; set; }

        public int userid { get; set; }

        public string title { get; set; }

        public string pid { get; set; }

        public DateTime createTime { get; set; }

    }

    /// <summary>
    /// 用户PID计划任务石头
    /// </summary>
    public class UserPidTaskModel
    {
        public int id { get; set; }
    }
}
