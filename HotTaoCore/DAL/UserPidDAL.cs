using HotTaoCore.Models;
using HotCoreUtils.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.DAL
{
    public class UserPidDAL
    {
        /// <summary>
        /// 获取用户推广位
        /// </summary>
        /// <returns></returns>
        public List<UserPidModel> getUserPidList(int userId)
        {
            string strSql = "select id,userid,title,pid,createTime from userpid_list where userid=@userid";
            var param = new[]
            {
                new SqlParameter("@userid",userId)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                return DbHelperSQL.GetEntityList<UserPidModel>(dr);
            }
        }

        /// <summary>
        /// 添加用户PID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addUserPID(UserPidModel model)
        {
            string strSql = "insert into userpid_list(userid,title,pid) values(@userid,@title,@pid);select @@IDENTITY";
            var param = new[]
            {
                new SqlParameter("@userid",model.userid),
                new SqlParameter("@title",model.title),
                new SqlParameter("@pid",model.pid)
            };
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param));
        }

        /// <summary>
        /// 删除用户PID数据
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteUserPID(int userid, int id)
        {
            string strSql = "delete from userpid_list where userid=@userid and id=@id";
            var param = new[]
            {
                new SqlParameter("@userid",userid),
                new SqlParameter("@id",id)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }

        public bool deleteUserPID(int userid, List<int> ids)
        {
            string strSql = string.Format("delete from userpid_list where userid=@userid and id in ({0})", string.Join(",", ids));
            string strSql2 = string.Format("update task_goods_pid_log set statusCode=1 where  userid=@userid and pid in ({0})", string.Join(",", ids));
            var param = new[]
            {
                new SqlParameter("@userid",userid)
            };
            DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param);
            DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql2, param);
            return true;
        }


        /// <summary>
        /// 修改用户PID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateUserPID(UserPidModel model)
        {
            string strSql = "update userpid_list set title=@title,pid=@pid  where userid=@userid and id=@id";
            var param = new[]
            {
                new SqlParameter("@userid",model.userid),
                new SqlParameter("@id",model.id),
                new SqlParameter("@title",model.title),
                new SqlParameter("@pid",model.pid)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }
    }
}
