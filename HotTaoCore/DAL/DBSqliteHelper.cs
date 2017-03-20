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
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.DAL
{
    /// <summary>
    /// Sqlite 数据操作助手
    /// </summary>
    public class DBSqliteHelper
    {

        private string connStr = "";

        private static string _connStrLogin= "Data Source=" + System.Environment.CurrentDirectory + "\\data\\0\\hottao.db;Version=3;Pooling=true";

        private static SQLiteConnection conn;

        public DBSqliteHelper(int userid)
        {
            connStr = "Data Source=" + System.Environment.CurrentDirectory + "\\data\\" + userid.ToString() + "\\hottao.db;Version=3;Pooling=true";
            conn = new SQLiteConnection(connStr);
            conn.Open();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseConnection()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Clone();
                conn.Dispose();
            }
        }


        /// <summary>
        /// 检查数据库连接状态
        /// </summary>
        private void CheckConnectionState()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            else if (conn.State == ConnectionState.Broken)
            {
                conn.Clone();
                conn.Open();
            }
        }

        //执行Sql语句
        public int ExecuteSql(string sqlStr, params SQLiteParameter[] parameters)
        {
            CheckConnectionState();
            int affectedRows = 0;
            DbCommand comm = conn.CreateCommand();
            comm.CommandText = sqlStr;
            comm.CommandType = CommandType.Text;
            if (parameters != null)
            {
                comm.Parameters.AddRange(parameters);
            }
            if (sqlStr.IndexOf("insert") != -1)
                affectedRows = Convert.ToInt32(comm.ExecuteScalar());
            else
                affectedRows = comm.ExecuteNonQuery();
            comm.Dispose();
            return affectedRows;
        }
        /// <summary>
        /// 执行查询数据，返回list 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr">The SQL string.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> ExecQueryList<T>(string sqlStr, params SQLiteParameter[] parameters) where T : new()
        {
            CheckConnectionState();
            List<T> data = null;
            DbCommand comm = conn.CreateCommand();
            comm.CommandText = sqlStr;
            comm.CommandType = CommandType.Text;
            if (parameters != null)
            {
                comm.Parameters.AddRange(parameters);
            }

            using (IDataReader reader = comm.ExecuteReader())
            {
                data = GetEntityList<T>(reader);
                comm.Dispose();
            }
            comm.Dispose();
            return data;
        }





        /// <summary>
        /// 执行查询数据，返回list 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr">The SQL string.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> GetLoginNameList<T>(string sqlStr, params SQLiteParameter[] parameters) where T : new()
        {
            using (SQLiteConnection _conn = new SQLiteConnection(_connStrLogin))
            {                
                List<T> data = null;
                DbCommand comm = _conn.CreateCommand();
                comm.CommandText = sqlStr;
                comm.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }

                using (IDataReader reader = comm.ExecuteReader())
                {
                    data = GetEntityList<T>(reader);
                    comm.Dispose();
                }
                comm.Dispose();
                return data;
            }
        }


        public static int ExecuteSqlLoginName(string sqlStr, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection _conn = new SQLiteConnection(_connStrLogin))
            {
                int affectedRows = 0;
                DbCommand comm = _conn.CreateCommand();
                comm.CommandText = sqlStr;
                comm.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }
                if (sqlStr.IndexOf("insert") != -1)
                    affectedRows = Convert.ToInt32(comm.ExecuteScalar());
                else
                    affectedRows = comm.ExecuteNonQuery();
                comm.Dispose();
                return affectedRows;
            }
        }





        /// <summary>
        ///  执行查询数据，返回Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr">The SQL string.</param>
        /// <returns>T.</returns>
        public T ExecQueryEntity<T>(string sqlStr, SQLiteParameter[] parameters) where T : new()
        {
            CheckConnectionState();
            T data = default(T);
            DbCommand comm = conn.CreateCommand();
            comm.CommandText = sqlStr;
            comm.CommandType = CommandType.Text;
            if (parameters != null)
            {
                comm.Parameters.AddRange(parameters);
            }
            using (IDataReader reader = comm.ExecuteReader())
            {
                data = GetEntity<T>(reader);
                comm.Dispose();
            }
            comm.Dispose();
            return data;
        }


        /// 根据需要得实体类信息   
        /// </summary>   
        /// <typeparam name="T">需要一个对象有一个无参数的实例化方法</typeparam>   
        /// <param name="dr">table数据源</param>   
        /// <returns>返回整理好了集合</returns>           
        private static List<T> GetEntityList<T>(IDataReader dr) where T : new()
        {
            List<T> entityList = new List<T>();

            int fieldCount = -1;

            while (dr.Read())
            {
                if (-1 == fieldCount)
                    fieldCount = dr.FieldCount;

                // 得到实体类对象   
                T t = (T)Activator.CreateInstance(typeof(T));

                for (int i = 0; i < fieldCount; i++)
                {
                    PropertyInfo prop = t.GetType().GetProperty(dr.GetName(i),
                        BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

                    if (null != prop)
                    {
                        // 为了能用在默认为null的值上   
                        // 如 DateTime? tt = null;
                        if (null == dr[i] || Convert.IsDBNull(dr[i]))
                        {
                            if (prop.PropertyType.Name == "DateTime" || prop.PropertyType.Name == "Date")
                                prop.SetValue(t, DateTime.Parse("1975-1-1"), null);
                            else if (prop.PropertyType.Name == "String")
                                prop.SetValue(t, "", null);
                            else
                                prop.SetValue(t, null, null);
                        }
                        else
                            prop.SetValue(t, dr[i], null);
                    }
                }

                entityList.Add(t);
            }
            dr.Close();
            return entityList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static T GetEntity<T>(IDataReader dr) where T : new()
        {
            T entity = default(T);

            int fieldCount = -1;

            if (dr.Read())
            {
                if (-1 == fieldCount)
                    fieldCount = dr.FieldCount;

                // 得到实体类对象   
                T t = (T)Activator.CreateInstance(typeof(T));

                for (int i = 0; i < fieldCount; i++)
                {
                    PropertyInfo prop = t.GetType().GetProperty(dr.GetName(i),
                        BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

                    if (null != prop)
                    {
                        // 为了能用在默认为null的值上   
                        // 如 DateTime? tt = null;   
                        if (null == dr[i] || Convert.IsDBNull(dr[i]))
                            if (prop.PropertyType.Name == "DateTime" || prop.PropertyType.Name == "Date")
                                prop.SetValue(t, DateTime.Parse("1975-1-1"), null);
                            else if (prop.PropertyType.Name == "String")
                                prop.SetValue(t, "", null);
                            else
                                prop.SetValue(t, null, null);
                        else
                            prop.SetValue(t, dr[i], null);
                    }
                }
                entity = t;
            }
            dr.Close();
            return entity;
        }

    }
}
