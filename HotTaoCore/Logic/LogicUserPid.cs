using HotTaoCore.DAL;
using HotTaoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Logic
{
    public class LogicUserPid
    {
        private static UserPidDAL dal = new UserPidDAL();

        private static LogicUserPid _instance = new LogicUserPid();

        public static LogicUserPid Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 获取用户登录的淘宝账号pid推广位
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="taobaoNo">当前淘宝账号</param>
        /// <returns>List&lt;UserPidModel&gt;.</returns>
        public List<UserPidModel> getUserPidList(string loginToken, string taobaoNo)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["taobaousername"] = taobaoNo.ToString();
            return BaseRequestService.Post<List<UserPidModel>>(ApiConst.getExtensions, data);            
        }


        /// <summary>
        /// 删除用户PID数据
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteUserPID(int userid, int id)
        {
            return dal.deleteUserPID(userid, id);
        }
        public bool deleteUserPID(int userid, List<int> ids)
        {
            return dal.deleteUserPID(userid, ids);
        }

    }
}
