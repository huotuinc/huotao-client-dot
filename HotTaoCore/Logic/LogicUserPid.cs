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
        /// 获取用户推广位
        /// </summary>
        /// <returns></returns>
        public List<UserPidModel> getUserPidList(int userId)
        {
            return dal.getUserPidList(userId);
        }

        /// <summary>
        /// 编辑用户PID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditUserPID(UserPidModel model)
        {
            if (model.id <= 0)
                return dal.addUserPID(model) > 0;
            else
                return dal.UpdateUserPID(model);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool BatchAddUserPID(List<UserPidModel> data)
        {
            foreach (var item in data)
            {
                dal.addUserPID(item);
            }
            return true;
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

        /// <summary>
        /// 修改用户PID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateUserPID(UserPidModel model)
        {
            return dal.UpdateUserPID(model);
        }
        /// <summary>
        /// 添加用户PID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUserPID(UserPidModel model)
        {
            return dal.addUserPID(model);
        }
    }
}
