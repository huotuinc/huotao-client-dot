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
        public string  loginName { get; set; }

        public string  loginPwd { get; set; }

        /// <summary>
        /// 登陆token（用于单设备登录用）
        /// </summary>
        public string  loginToken { get; set; }

        public DateTime lastLoginTime { get; set; }
        /// <summary>
        /// 激活状态1激活
        /// </summary>
        public int activate { get; set; }

        public DateTime createTime { get; set; }
    }
}
