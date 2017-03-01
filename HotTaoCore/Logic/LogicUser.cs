using HotTaoCore.DAL;
using HotTaoCore.Models;
using HotCoreUtils.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.Logic
{
    public class LogicUser
    {
        private static UserDAL dal = new UserDAL();

        private static LogicUser _instance = new LogicUser();

        public static LogicUser Instance
        {
            get
            {
                return _instance;
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

            Dictionary<string, string> data = new Dictionary<string, string>();
            data["username"] = loginName;
            data["password"] = loginPwd;
            var userData = BaseRequestService.Post<UserModel>(ApiConst.login, data);
            //var userData = dal.login(loginName, loginPwd);
            if (userData != null)
            {
                userData.activate = 1;
                if (userData.activate == 1)
                {
                    return userData;
                }
            }
            return null;
        }


        public UserModel Register(string loginName, string loginPwd, string verifyCode)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["username"] = loginName;
            data["password"] = loginPwd;
            data["verifycode"] = verifyCode;
            var userData = BaseRequestService.Post<UserModel>(ApiConst.register, data);
            if (userData != null)
            {
                return userData;
            }
            return null;
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UserModel getUserInfoById(int userid)
        {
            return dal.getUserInfoById(userid);
        }
        /// <summary>
        /// 根据登录token获取用户信息
        /// </summary>
        /// <param name="loginToken"></param>
        /// <returns></returns>
        public bool getUserInfoByToken(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return true;// BaseRequestService.Post(ApiConst.checkToken, data);
            //return dal.getUserInfoByToken(loginToken);
        }
        /// <summary>
        /// 刷新用户登陆token
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool RefreshLoginToken(int userid, string token)
        {
            return dal.RefreshLoginToken(userid, token);
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
            return dal.ChanagePassword(userid, oldpwd, newpwd);
        }



        /// <summary>
        ///获取用户发送模板
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>System.String.</returns>
        public string GetUserSendTemplate(int userid)
        {
            return dal.GetUserSendTemplate(userid);
        }

        /// <summary>
        /// 添加发送模板
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="tempText">The temporary text.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool AddUserSendTemplate(int userid, string tempText)
        {
            return dal.AddUserSendTemplate(userid, tempText);
        }


        public string GetUserSendTemplate(int userid, bool cache)
        {
            string key = "temptext_" + userid;
            string templateText = WebCacheHelper<string>.Get(key);
            if (string.IsNullOrEmpty(templateText))
            {
                templateText = GetUserSendTemplate(userid);
                //将数据插入缓存中
                if (!string.IsNullOrEmpty(templateText))
                    WebCacheHelper.Insert(key, templateText);


            }

            return templateText;
        }

        /// <summary>
        /// 获取用户微信授权配置
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>WxAuthConfigModel.</returns>
        public WxAuthConfigModel GetWxAuthConfig(int userid)
        {
            return dal.GetWxAuthConfig(userid);
        }

        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddWxAuthConfig(WxAuthConfigModel model)
        {
            return dal.AddWxAuthConfig(model);
        }










        /// <summary>
        /// 获取微信群聊列表
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>List&lt;UserWechatListModel&gt;.</returns>
        public List<UserWechatListModel> GetUserWeChatList(int userId)
        {
            return dal.GetUserWeChatList(userId);
        }

        /// <summary>
        /// 获取微信群聊列表
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <returns>List&lt;UserWechatListModel&gt;.</returns>
        public List<UserWechatListModel> GetUserWeChatList(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return BaseRequestService.Post<List<UserWechatListModel>>(ApiConst.getWeChatGroups, data);
        }


        /// <summary>
        /// 获取自动回复的微信群聊
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <returns>List&lt;WxAutoReplyModel&gt;.</returns>
        public List<WxAutoReplyModel> GetUserReplyWeChatList(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return dal.GetUserReplyWeChatList();
            //return BaseRequestService.Post<List<WxAutoReplyModel>>(ApiConst.getWeChatGroups, data);
        }

        public int UpdateReplyWeChat(string loginToken, int wechatid, string wechattitle)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return 0;
        }


        /// <summary>
        /// 添加回复关键字
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="replyContent">Content of the reply.</param>
        /// <param name="msgType">Type of the MSG.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public int AddReplyKeyword(string loginToken,string keyword,string replyContent,int msgType)
        {

            return 0;
        }

        /// <summary>
        /// 获取关键字回复列表
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <returns>List&lt;WxAutoReplyKeywordModel&gt;.</returns>
        public List<WxAutoReplyKeywordModel> GetUserReplyKeywordList(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return dal.GetUserReplyKeywordList();
            //return BaseRequestService.Post<List<WxAutoReplyModel>>(ApiConst.getWeChatGroups, data);
        }


        /// <summary>
        /// 添加用户微信群
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUserWeChat(UserWechatListModel model)
        {
            return dal.AddUserWeChat(model);
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
            return dal.UpdateUserWeChatTitle(userid, wechatid, wechattitle);
        }

        /// <summary>
        /// 编辑微信群信息
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <param name="wechattitle">The wechattitle.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateUserWeChatTitle(string loginToken, int wechatid, string wechattitle)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["groupname"] = wechattitle;
            if (wechatid > 0)
                data["id"] = wechatid.ToString();
            return BaseRequestService.Post(ApiConst.saveWeChatGroup, data) ? 1 : 0;
        }

        /// <summary>
        /// Updates the user we chat title.
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="wechattitle">微信群标题</param>
        /// <param name="type">0,自动回复，1自动踢人</param>
        /// <returns>System.Int32.</returns>
        public int UpdateUserWeChatTitle(string loginToken, string wechattitle, int type)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["groupname"] = wechattitle;
            data["type"] = type.ToString();
            return 0;// BaseRequestService.Post(ApiConst.saveAutoWeChatGroup, data) ? 1 : 0;
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
            return dal.UpdateUserWeChatPid(userid, wechatid, pidid);
        }


        /// <summary>
        /// 删除微信群
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserWeChat(int userid, List<int> wechatid)
        {
            return dal.DeleteUserWeChat(userid, wechatid);
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
            return dal.SetUserWeChatPid(userid, wechatid, pidid);
        }



        /// <summary>
        /// 设置配置保存
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserConfigModel(ConfigModel model)
        {
            return dal.AddUserConfigModel(model);
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>ConfigModel.</returns>
        public ConfigModel GetConfigModel(int userid)
        {
            return dal.GetConfigModel(userid);
        }
    }
}
