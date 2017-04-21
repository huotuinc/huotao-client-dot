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
        /// <param name="loginName">Name of the login.</param>
        /// <param name="loginPwd">The login password.</param>
        /// <param name="error">The error.</param>
        /// <param name="keepToken">可选参数，如果传入值并且值为true;则不会更新该用户的Token</param>
        /// <returns>UserModel.</returns>
        public UserModel login(string loginName, string loginPwd, Action<ResultModel> error = null, bool keepToken = false)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["username"] = loginName;
            data["password"] = loginPwd;
            if (keepToken)
                data["keepToken"] = keepToken.ToString();
            var userData = BaseRequestService.Post<UserModel>(ApiConst.login, data, (err) =>
            {
                error?.Invoke(err);
            });
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

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <param name="loginPwd">The login password.</param>
        /// <param name="verifyCode">The verify code.</param>
        /// <param name="error">The error.</param>
        /// <param name="code">The code.</param>
        /// <returns>UserModel.</returns>
        public UserModel Register(string loginName, string loginPwd, string verifyCode, Action<ResultModel> error = null, string code = "")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["username"] = loginName;
            data["password"] = loginPwd;
            data["verifyCode"] = verifyCode;
            if (!string.IsNullOrEmpty(code))
                data["code"] = code;
            var userData = BaseRequestService.Post<UserModel>(ApiConst.register, data, (err) =>
            {
                error?.Invoke(err);
            });
            if (userData != null)
            {
                return userData;
            }
            return null;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">The mobile.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool sendCodeForRegister(string mobile)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["mobile"] = mobile;
            return BaseRequestService.Post(ApiConst.sendCodeForRegister, data);
        }

        /// <summary>
        /// 使用软件激活码
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="code">The code.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool activeAccount(string token,string code)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = token;
            data["code"] = code;
            return BaseRequestService.Post(ApiConst.activeAccount, data);
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
            bool result = false;
            int errorCode = 0;
            result = BaseRequestService.Post(ApiConst.checkToken, data, (error =>
            {
                errorCode = error.resultCode;
            }));
            if (errorCode == 500)
                result = true;
            return result;
        }

        /// <summary>
        ///获取用户发送模板
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>System.String.</returns>
        public string GetUserSendTemplate(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return BaseRequestService.PostToString(ApiConst.getUserGoodsTempList, data);
        }

        /// <summary>
        /// 添加发送模板
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="tempText">The temporary text.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool AddUserSendTemplate(string loginToken, string tempText)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["customdocument"] = tempText;
            return BaseRequestService.Post(ApiConst.saveUserGoodsTempList, data);
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
        /// <param name="type">-1全部，0回复，1踢人</param>
        /// <returns>List&lt;WxAutoReplyModel&gt;.</returns>
        public List<WxAutoReplyModel> GetUserReplyWeChatList(string loginToken, int type)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;//
            data["type"] = type.ToString();//
            return BaseRequestService.Post<List<WxAutoReplyModel>>(ApiConst.getAutoReplyWeChatGroupList, data);
        }
        /// <summary>
        /// 删除回复微信群
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="wechatid">The wechatid.</param>        
        /// <returns>System.Int32.</returns>
        public bool DeleteReplyWeChat(string loginToken, int wechatid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["id"] = wechatid.ToString();
            return BaseRequestService.Post(ApiConst.delAutoReplyWeChatGroup, data);
        }


        /// <summary>
        /// 添加回复关键字
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="replyContent">Content of the reply.</param>
        /// <param name="msgType">Type of the MSG.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool AddReplyKeyword(string loginToken, string keyword, string replyContent, int msgType, int goodsid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["keyword"] = keyword;
            data["replycontent"] = replyContent;
            data["replytype"] = msgType.ToString();
            if (goodsid > 0)
                data["replygoodsid"] = goodsid.ToString();
            return BaseRequestService.Post(ApiConst.saveReplyConfig, data);
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
            return BaseRequestService.Post<List<WxAutoReplyKeywordModel>>(ApiConst.getKeywordReplyConfigList, data);
        }
        /// <summary>
        /// 删除关键字
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserKeyword(string loginToken, int keywordid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["id"] = keywordid.ToString();
            return BaseRequestService.Post(ApiConst.delReplyConfig, data);
        }

        /// <summary>
        /// 编辑微信群信息
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <param name="wechattitle">The wechattitle.</param>
        /// <returns>System.Int32.</returns>
        public UserWechatListModel UpdateUserWeChatTitle(string loginToken, int wechatid, string wechattitle)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["groupname"] = wechattitle;
            if (wechatid > 0)
                data["id"] = wechatid.ToString();
            return BaseRequestService.Post<UserWechatListModel>(ApiConst.saveWeChatGroup, data);
        }

        /// <summary>
        /// 添加自动回复微信群
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="wechattitle">微信群标题</param>
        /// <param name="type">0,自动回复，1自动踢人</param>
        /// <returns>System.Int32.</returns>
        public int UpdateUserWeChatTitle(string loginToken, string wechattitle, int type)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["wechattitle"] = wechattitle;
            data["handleType"] = type.ToString();
            return BaseRequestService.Post(ApiConst.saveAutoWeChatGroup, data) ? 1 : 0;
        }



        /// <summary>
        /// 设置微信群对应的pid
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="wechatid">The wechatid.</param>
        /// <param name="pidid">The pidid.</param>
        /// <returns>System.Int32.</returns>
        public bool UpdateUserWeChatPid(string loginToken, int wechatid, int pidid)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["pidid"] = pidid.ToString();
            data["groupid"] = wechatid.ToString();
            return BaseRequestService.Post(ApiConst.setPid, data);
        }


        /// <summary>
        /// 删除微信群
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="groupids">The groupids.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public bool DeleteUserWeChat(string loginToken, string groupids)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["groupids"] = groupids;
            return BaseRequestService.Post(ApiConst.delWeChatGroup, data);
        }

        /// <summary>
        /// 设置配置保存
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Int32.</returns>
        public int AddUserConfigModel(string loginToken, ConfigModel model)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["where_config"] = model.where_config;
            data["send_time_config"] = model.send_time_config;
            data["enable_autoreply"] = model.enable_autoreply.ToString();
            data["enable_autoremove"] = model.enable_autoremove.ToString();
            var myConfig = BaseRequestService.Post<ConfigModel>(ApiConst.saveHotUserConfig, data);
            if (myConfig != null)
                return 1;

            return 0;

        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>ConfigModel.</returns>
        public ConfigModel GetConfigModel(string loginToken)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            return BaseRequestService.Post<ConfigModel>(ApiConst.getHotUserConfig, data);
        }


        /// <summary>
        /// 拉取阿里妈妈PID数据
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="cookies">The cookies.</param>
        /// <returns>true if XXXX, false otherwise.</returns>
        public List<UserTaoPidModel> GetPids(string loginToken, string cookies)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["cookies"] = cookies;
            return BaseRequestService.Post<List<UserTaoPidModel>>(ApiConst.getPids, data);
        }
        /// <summary>
        /// 获取淘宝账号
        /// </summary>
        /// <param name="loginToken">The login token.</param>
        /// <param name="cookies">The cookies.</param>
        /// <returns>System.String.</returns>
        public string GetTaobaoUsername(string loginToken, string cookies)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["token"] = loginToken;
            data["cookies"] = cookies;
            return BaseRequestService.PostToString(ApiConst.getTaobaoUsername, data);
        }

    }
}
