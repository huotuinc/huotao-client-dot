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



        public string title { get; set; }

        public string pid { get; set; }
        

    }

    /// <summary>
    /// 用户PID计划任务石头
    /// </summary>
    public class UserPidTaskModel
    {
        public int id { get; set; }
    }



    /// <summary>
    /// 微信群聊对象
    /// </summary>
    public class UserWechatListModel
    {

        public int id { get; set; }

        public int userid { get; set; }


        public string wechattitle { get; set; }

        /// <summary>
        /// 关联id
        /// </summary>
        /// <value>The pidid.</value>
        public int pidid { get; set; }
        /// <summary>
        /// 推广位
        /// </summary>
        /// <value>The pid.</value>
        public string pid { get; set; }

        public DateTime createtime { get; set; }
    }

}
