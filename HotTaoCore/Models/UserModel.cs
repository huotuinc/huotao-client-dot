using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Models
{
    public class UserModel
    {
        public int userid { get; set; }

        public string nickName { get; set; }
        public string loginName { get; set; }

        public string loginPwd { get; set; }

        /// <summary>
        /// 登陆token（用于单设备登录用）
        /// </summary>
        public string loginToken { get; set; }

        public DateTime lastLoginTime { get; set; }
        /// <summary>
        /// 激活状态1激活
        /// </summary>
        public int activate { get; set; }

        public DateTime createTime { get; set; }

        /// <summary>
        /// 是否允许使用发单高手,如果不允许，则弹出对话框
        /// </summary>
        /// <value>true if [software permit]; otherwise, false.</value>
        public bool softwarePermit { get; set; }

        /// <summary>
        ///营销描述；通常由软件呈现给用户
        /// </summary>
        /// <value>The software text.</value>
        public string softwareText { get; set; }

        /// <summary>
        /// 用户身份：1表示淘客，2表示群主；后期如有其它身份，再加入
        /// </summary>
        /// <value>The user identity.</value>
        public int userIdentity { get; set; }
    }
}
