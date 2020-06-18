using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Printer.tools
{
    public static class SqlServerHelper
    {
        public static string constr = LocalConfig.GetConfigValue("sqlserver");
        //private static string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();

            /// <summary>
            /// 用于提交Insert Update Delete 返回受影响的行数
            /// </summary>
            /// <param name="cmdType">操作类型StoreProcdeure 或者是 sql语句</param>
            /// <param name="sql">sql语句或者存储过程的名称</param>
            /// <param name="parameters">参数的数组，没有参数传递为Null值</param>
            /// <returns></returns>
            public static int ExecuteNonQuery(CommandType cmdType, string sql, params SqlParameter[] parameters)
            {
                try
                {
                    using (var con = new SqlConnection(constr))
                    {
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = cmdType;
                            if (parameters != null)
                            {
                                foreach (var parameter in parameters)
                                {
                                    cmd.Parameters.Add(parameter);
                                }
                            }
                            con.Open();
                            int count = cmd.ExecuteNonQuery();
                            con.Close();
                            return count;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// 用于提交select 返回 SqlDataReader ,读取完成后需要关闭SqlDataReader
            /// </summary>
            /// <param name="cmdType">操作类型StoreProcdeure 或者是 sql语句</param>
            /// <param name="sql">sql语句或者存储过程的名称</param>
            /// <param name="parameters">参数的数组，没有参数传递为Null值</param>
            /// <returns></returns>
            public static SqlDataReader ExecuteReader(CommandType cmdType, string sql, params SqlParameter[] parameters)
            {
                try
                {
                    var con = new SqlConnection(constr);
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                cmd.Parameters.Add(parameter);
                            }
                        }
                        con.Open();
                        //关闭读取器,将自动关闭连接对象
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        return dr;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            /// <summary>
            /// 用于提交select中的聚合函数,返回第一行,第一列的值
            /// </summary>
            /// <param name="cmdType">操作类型StoreProcdeure 或者是 sql语句</param>
            /// <param name="sql">sql语句或者存储过程的名称</param>
            /// <param name="parameters">参数的数组，没有参数传递为Null值</param>
            /// <returns></returns>
            public static object ExecuteScalar(CommandType cmdType, string sql, params SqlParameter[] parameters)
            {
                try
                {
                    using (var con = new SqlConnection(constr))
                    {
                        using (var cmd = new SqlCommand(sql, con))
                        {
                            cmd.CommandType = cmdType;
                            if (parameters != null)
                            {
                                foreach (var parameter in parameters)
                                {
                                    cmd.Parameters.Add(parameter);
                                }
                            }
                            con.Open();
                            object o = cmd.ExecuteScalar();
                            con.Close();
                            return o;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// 用于提交select 返回 DataSet ,数据集中默认只有一张表格
            /// </summary>
            /// <param name="cmdType">操作类型StoreProcdeure 或者是 sql语句</param>
            /// <param name="sql">sql语句或者存储过程的名称</param>
            /// <param name="parameters">参数的数组，没有参数传递为Null值</param>
            /// <returns></returns>
            public static DataSet ExecuteDataSet(CommandType cmdType, string sql, params SqlParameter[] parameters)
            {
                try
                {
                    using (var con = new SqlConnection(constr))
                    {
                        using (var da = new SqlDataAdapter())
                        {
                            var cmd = new SqlCommand(sql, con);
                            cmd.CommandType = cmdType;
                            if (parameters != null)
                            {
                                foreach (var parameter in parameters)
                                {
                                    cmd.Parameters.Add(parameter);
                                }
                            }
                            da.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #region  List<T> ToList<T>(string cmdText, List<DbParameter> listpar, string connString,IDbHelp db) where T : class, new()
            /// <summary>
            /// 返回一个list
            /// </summary>
            /// <typeparam name="T">实体模型</typeparam>
            /// <param name="cmdType">操作类型StoreProcdeure 或者是 sql语句</param>
            /// /// <param name="sql">sql语句</param>
            /// <param name="parameters">参数列表</param>
            /// <returns></returns>
            public static List<T> ToList<T>(CommandType cmdType, string sql, params SqlParameter[] parameters) where T : class, new()
            {
                using (var read = ExecuteReader(cmdType, sql, parameters))
                {
                    List<T> list = null;
                    var type = typeof(T);
                    if (read.HasRows)
                    {
                        list = new List<T>();
                    }
                    while (read.Read())
                    {
                        T t = new T();
                        foreach (PropertyInfo item in type.GetProperties())
                        {
                            for (int i = 0; i < read.FieldCount; i++)
                            {
                                //属性名与查询出来的列名比较
                                if (item.Name.ToLower() != read.GetName(i).ToLower()) continue;
                                object value = read[i];
                                if (value != DBNull.Value)
                                {
                                    item.SetValue(t, value, null);
                                }
                                break;
                            }
                        }
                        //将创建的对象添加到集合中
                        list.Add(t);
                    }
                    return list;
                }
            }
            #endregion

         
    }
}
