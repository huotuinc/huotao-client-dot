/*
 * 版权所有:杭州火图科技有限公司
 * 地址:浙江省杭州市滨江区西兴街道阡陌路智慧E谷B幢4楼在地图中查看
 * (c) Copyright Hangzhou Hot Technology Co., Ltd.
 * Floor 4,Block B,Wisdom E Valley,Qianmo Road,Binjiang District
 * 2013-2017. All rights reserved.
 * author guomw
**/


using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace QQLogin
{
    /// <summary>
    /// 群配置
    /// </summary>
    public class GroupConfig
    {
        public int load_completed { get; set; }

        public string login_qq { get; set; }

        public string login_name { get; set; }

    }
    /// <summary>
    /// 群信息
    /// </summary>
    public class GroupInfo
    {
        public long id { get; set; }

        public string from_qq { get; set; }

        public string group_number { get; set; }

        public string group_name { get; set; }
    }

    /// <summary>
    /// 群消息
    /// </summary>
    public class GroupMsg
    {
        public long id { get; set; }

        public long time { get; set; }

        public string from_qq { get; set; }

        public string group_number { get; set; }

        public string detail { get; set; }

        public string imagePath { get; set; }
    }



    public class KQDAL
    {
        private static QQLoginDBSqliteHelper DBHelper;
        public KQDAL()
        {
            DBHelper = new QQLoginDBSqliteHelper();
        }





        /// <summary>
        /// 修改加载状态
        /// </summary>
        /// <param name="completed"></param>
        /// <returns></returns>
        public void UpdateLoadCompleted(bool completed)
        {
            string strSql = "update group_config set load_completed=" + (completed ? 1 : 0);
            DBHelper.ExecuteSql(strSql);
        }


        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public GroupConfig GetGroupCofing()
        {
            string strSql = "select * from group_config;";
            return DBHelper.ExecQueryEntity<GroupConfig>(strSql);
        }

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <returns></returns>
        public List<GroupInfo> GetGroupList()
        {
            string strSql = "select * from group_list;";
            return DBHelper.ExecQueryList<GroupInfo>(strSql);
        }
        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="groupNumber"></param>
        /// <returns></returns>
        public GroupInfo GetGroupInfo(string groupNumber)
        {
            string strSql = string.Format("select * from group_list where group_number='{0}';", groupNumber);
            return DBHelper.ExecQueryEntity<GroupInfo>(strSql);
        }

        /// <summary>
        /// 获取监控群的消息
        /// </summary>
        /// <returns></returns>
        public List<GroupMsg> GetGroupMsgList(List<long> ids)
        {
            string strSql = string.Format("select * from msg_log where group_number in({0});", string.Join(",", ids));
            return DBHelper.ExecQueryList<GroupMsg>(strSql);
        }


        /// <summary>
        /// 删除指定目标以外的数据
        /// </summary>
        public void DeleteQQGroupMsg(List<long> ids)
        {
            string strSql = string.Format("delete from msg_log where group_number not in({0});", string.Join(",", ids));
            DBHelper.ExecuteSql(strSql);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        public void DeleteQQGroupMsg(long logid)
        {
            string strSql = string.Format("delete from msg_log where id={0};", logid);
            DBHelper.ExecuteSql(strSql);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        public void DeleteQQGroupMsg()
        {
            string strSql = "delete from msg_log;";
            DBHelper.ExecuteSql(strSql);
        }


        /// <summary>
        /// 清空所有数据
        /// </summary>
        public void ClearQQGroupData()
        {
            DeleteQQGroup();
            DeleteQQGroupMsg();
            UpdateLoadCompleted(false);
        }

        /// <summary>
        /// 删除表中群数据
        /// </summary>
        /// <returns></returns>
        public void DeleteQQGroup()
        {
            string strSql = "delete from group_list;";
            DBHelper.ExecuteSql(strSql);
        }


    }
}
