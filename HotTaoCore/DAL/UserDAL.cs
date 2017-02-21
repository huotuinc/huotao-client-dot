using HotTaoCore.Models;
using HotCoreUtils.DB;
using HotCoreUtils.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UserModel getUserInfoById(int userid)
        {
            string strSql = "select userid,nickName,loginName,loginPwd,loginToken,activate,lastLoginTime,createTime from user_list  with(nolock) where userid=@userid";
            var param = new[] {
                new SqlParameter("@userid",userid)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                return DbHelperSQL.GetEntity<UserModel>(dr);
            }
        }
        /// <summary>
        /// 根据登录token获取用户信息
        /// </summary>
        /// <param name="loginToken"></param>
        /// <returns></returns>
        public UserModel getUserInfoByToken(string loginToken)
        {
            string strSql = "select userid,nickName,loginName,loginPwd,loginToken,activate,lastLoginTime,createTime from user_list  with(nolock) where loginToken=@loginToken";
            var param = new[] {
                new SqlParameter("@loginToken",loginToken)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                return DbHelperSQL.GetEntity<UserModel>(dr);
            }
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public UserModel login(string loginName, string loginPwd)
        {
            string strSql = "select userid,nickName,loginName,loginPwd,loginToken,activate,lastLoginTime,createTime from user_list  with(nolock) where loginName=@loginName and loginPwd=@loginPwd";
            var param = new[] {
                new SqlParameter("@loginName",loginName),
                new SqlParameter("@loginPwd",loginPwd)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                return DbHelperSQL.GetEntity<UserModel>(dr);
            }
        }

        /// <summary>
        /// 刷新用户登陆token
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool RefreshLoginToken(int userid, string token)
        {
            string strSql = "update user_list set loginToken=@loginToken,lastLoginTime=@lastLoginTime where userid=@userid";
            var param = new[] {
                new SqlParameter("@userid",userid),
                new SqlParameter("@loginToken",token),
                new SqlParameter("@lastLoginTime",DateTime.Now)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="oldpwd">The oldpwd.</param>
        /// <param name="newpwd">The newpwd.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool ChanagePassword(int userid, string oldpwd, string newpwd)
        {
            string strSql = "update user_list set loginPwd=@newpwd where userid=@userid and loginPwd=@oldpwd";
            var param = new[] {
                new SqlParameter("@userid",userid),
                new SqlParameter("@oldpwd",oldpwd),
                new SqlParameter("@newpwd",newpwd)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }


        /// <summary>
        /// 添加发送模板
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="tempText">The temporary text.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool AddUserSendTemplate(int userid, string tempText)
        {
            string strSql = @"if not exists (select * from user_goods_templist where userid=@userid)
                                begin
	                                insert into user_goods_templist(userid,tempText) values(@userid,@tempText)
                                end
                                else
                                begin
	                                update user_goods_templist set tempText=@tempText where userid=@userid
                                end";
            var param = new[] {
                new SqlParameter("@userid",userid),
                new SqlParameter("@tempText",tempText)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;

        }

        /// <summary>
        ///获取用户发送模板
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>System.String.</returns>
        public string GetUserSendTemplate(int userid)
        {
            string strSql = "select top 1 tempText from user_goods_templist where userid=@userid or userid=0  order by userid desc";
            var param = new[] {
                new SqlParameter("@userid",userid)
            };
            object obj = DbHelperSQL.ExecuteScalar(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param);
            if (obj != null)
                return obj.ToString();
            return "";

        }
        /// <summary>
        /// Gets the wx authentication configuration.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>WxAuthConfigModel.</returns>
        public WxAuthConfigModel GetWxAuthConfig(int userid)
        {
            string strSql = "select [uid],[sid],skey,webwxDataTicket,passTicket from user_wx_auth_config where userid=@userid";
            var param = new[] {
                new SqlParameter("@userid",userid)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                return DbHelperSQL.GetEntity<WxAuthConfigModel>(dr);
            }
        }

    }
}
