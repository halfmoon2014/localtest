using System;

using System.Data;

using System.IO;


namespace PlanGo.Tools
{
    /// <summary>
    /// 读取支持热部署的系统配置文件
    /// </summary>
    public class LocalConfig
    {
        /// <summary>
        /// 设置配置文件的路径
        /// </summary>
        public static string ConfigFile = "";

        private static DateTime LastWriteTime = DateTime.Now;
        private static DataTable _dtConfig = new DataTable();
        private static DataTable dtConfig()
        {
            if (ConfigFile == "")
            {
                //string Apppath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                //string path = new FileInfo(Apppath).DirectoryName;
                LocalConfig.ConfigFile = string.Concat(System.Windows.Forms.Application.StartupPath, "\\LocalConfig.xml");
            }

            if (ConfigFile != "")
            {
                FileInfo cfgFI = new FileInfo(ConfigFile);
                if (cfgFI.Exists == true)
                {
                    if (Math.Abs(cfgFI.LastWriteTime.Subtract(LastWriteTime).TotalSeconds) > 0)
                    {
                        LastWriteTime = cfgFI.LastWriteTime;

                        _dtConfig.Rows.Clear();
                        _dtConfig.ReadXml(ConfigFile);
                    }
                }
            }

            return _dtConfig;
        }

        /// <summary>
        /// 根据属性名获得属性值
        /// </summary>
        /// <param name="ConfigName">属性名</param>
        /// <returns></returns>
        public static string GetConfigValue(string ConfigName)
        {
            DataRow dr = dtConfig().Rows.Find(ConfigName);
            if (dr == null)
            {
                throw new Exception("找不到配置属性：" + ConfigName);
            }
            else
            {
                return dr["ConfigValue"].ToString();
            }
        }


        public static void SetConfigValue(string ConfigName, string ConfigValue)
        {
            DataRow dr = dtConfig().Rows.Find(ConfigName);
            if (dr == null)
            {
                throw new Exception("找不到配置属性：" + ConfigName);
            }
            else
            {
                int index = dtConfig().Rows.IndexOf(dr);
                dtConfig().Rows[index]["ConfigValue"] = ConfigValue;
                dtConfig().WriteXml(LocalConfig.ConfigFile, XmlWriteMode.WriteSchema, false);
            }
        }
    }

}