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

        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddWxAuthConfig(WxAuthConfigModel model)
        {
            string strSql = @"if exists (select userid from user_wx_auth_config where userid=@userid)
                                begin
                                 update user_wx_auth_config set [uid]=@uid,[sid]=@sid,skey=@skey,webwxDataTicket=@webwxDataTicket,passTicket=@passTicket where userid=@userid
                                end
                                else
                                begin
                                insert into user_wx_auth_config([uid],[sid],skey,webwxDataTicket,passTicket,userid) values(@uid,@sid,@skey,@webwxDataTicket,@passTicket,@userid)
                                end";
            var param = new[] {
                new SqlParameter("@userid",model.userid),
                new SqlParameter("@uid",model.uid),
                new SqlParameter("@sid",model.sid),
                new SqlParameter("@skey",model.skey),
                new SqlParameter("@webwxDataTicket",model.webwxDataTicket),
                new SqlParameter("@passTicket",model.passTicket)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }


        /******************new *************************************/




        /// <summary>
        /// 获取微信群聊列表
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>List&lt;UserWechatListModel&gt;.</returns>
        public List<UserWechatListModel> GetUserWeChatList(int userId)
        {
            string strSql = @"select a.id,a.userid,a.wechattitle,a.pidid,b.pid,a.createTime from user_wechat_list a
                              left join userpid_list b on a.pidid=b.id
                              where a.userid=@userid";
            var param = new[]
            {
                new SqlParameter("@userid",userId)
            };
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param))
            {
                return DbHelperSQL.GetEntityList<UserWechatListModel>(dr);
            }
        }


        /// <summary>
        /// 添加用户微信群
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUserWeChat(UserWechatListModel model)
        {

            string strSql = @"
                            if not exists (select * from user_wechat_list where userid=@userid and wechattitle=@wechattitle)
                            begin
                                insert into user_wechat_list(userid,wechattitle) values(@userid,@wechattitle);select @@IDENTITY;
                            end
                            else
                            begin
                                select 0
                            end
                            ";

            var param = new[]
            {
                new SqlParameter("@userid",model.userid),
                new SqlParameter("@wechattitle",model.wechattitle)
            };
            object obj = DbHelperSQL.ExecuteScalar(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param);
            return obj != null ? Convert.ToInt32(obj) : 0;
        }

        /// <summary>
        /// 设置微信群关联PID
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <param name="pidid">The pidid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool SetUserWeChatPid(int userid, int wechatid, int pidid)
        {
            string strSql = "update user_wechat_list set pidid=@pidid where userid=@userid and id=@id";
            var param = new[]
            {
                new SqlParameter("@userid",userid),
                new SqlParameter("@pidid",pidid),
                new SqlParameter("@id",wechatid)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }
        /// <summary>
        /// 修改微信群聊标题
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <param name="wechattitle">The wechattitle.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public int UpdateUserWeChatTitle(int userid, int wechatid, string wechattitle)
        {
            string strSql = "update user_wechat_list set wechattitle=@wechattitle where userid=@userid and id=@id";
            var param = new[]
            {
                new SqlParameter("@userid",userid),
                new SqlParameter("@wechattitle",wechattitle),
                new SqlParameter("@id",wechatid)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param);
        }


        /// <summary>
        /// 设置微信群对应的pid
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <param name="pidid">The pidid.</param>
        /// <returns>System.Int32.</returns>
        public bool UpdateUserWeChatPid(int userid, int wechatid, int pidid)
        {
            string strSql = "update user_wechat_list set pidid=@pidid where userid=@userid and id=@id";
            var param = new[]
            {
                new SqlParameter("@userid",userid),
                new SqlParameter("@pidid",pidid),
                new SqlParameter("@id",wechatid)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param)>0;
        }


        /// <summary>
        /// 删除微信群
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserWeChat(int userid, List<int> wechatid)
        {
            string strSql = string.Format("delete from user_wechat_list where userid=@userid and id in ({0})", string.Join(",", wechatid));
            var param = new[]
            {
                new SqlParameter("@userid",userid)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param) > 0;
        }
    }
}
