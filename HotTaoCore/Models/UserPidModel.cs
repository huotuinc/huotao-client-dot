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



    public class UserTaoPidModel
    {
        /// <summary>
        /// 推广位ID
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }

        /// <summary>
        /// 推广位名称
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// 推广位
        /// </summary>
        /// <value>The pid.</value>
        public string pid { get; set; }

        /// <summary>
        /// 类型  自助、主题活动
        /// </summary>
        /// <value>The type of the extension.</value>
        public string extensionType { get; set; }
        /// <summary>
        /// 淘宝账号
        /// </summary>
        /// <value>The taobao username.</value>
        public string taobaoUsername { get; set; }

        /// <summary>
        /// 所属导购
        /// </summary>
        /// <value>The name of the shop guide.</value>
        public string shopGuideName { get; set; }
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
