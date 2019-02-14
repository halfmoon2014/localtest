using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
 
    public class localLog
    {
        public static string Apppath = System.Windows.Forms.Application.StartupPath;
        public static string logDirectory = Apppath + "\\Log";
        
        /// <summary>
        /// ��鲢������־Ŀ¼
        /// </summary>
        public static void CheckAndCreatelog()
        {
            if (System.IO.Directory.Exists(logDirectory) == false)
            {
                System.IO.Directory.CreateDirectory(logDirectory);
            }
        }

        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="strInfo"></param>
        private static void LogText(string strInfo)
        {               
            string fileName = string.Concat(logDirectory, "\\", DateTime.Now.ToString("yyyyMMdd"), ".txt");
            if (!File.Exists(fileName))
            {                
                File.Create(fileName).Close();
            }            

            StringBuilder strBuilderErrorMessage = new StringBuilder();
            strBuilderErrorMessage.Append("����:" + System.DateTime.Now.ToString() + "\r\n");
            strBuilderErrorMessage.Append("��������:" + strInfo + "\r\n");
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="strInfo"></param>
        private static void LogError(Exception ex)
        {                      
            string fileName = string.Concat(logDirectory, "\\", DateTime.Now.ToString("yyyyMMdd"), ".txt");
            if (!File.Exists(fileName))
            {
                // Create a file to write to.
                File.Create(fileName).Close();
            }
            //System.IO.File.AppendText(fileName, strInfo, System.Text.Encoding.Default);

            StringBuilder strBuilderErrorMessage = new StringBuilder();

            strBuilderErrorMessage.Append("-----------------------------------------------------------\r\n");
            strBuilderErrorMessage.Append("����:" + System.DateTime.Now.ToString() + "\r\n");            
            strBuilderErrorMessage.Append("������Ϣ:" + ex.Message + "\r\n");
            strBuilderErrorMessage.Append("��������:" + ex.StackTrace + "\r\n");
            strBuilderErrorMessage.Append("-----------------------------------------------------------\r\n");
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
        }


        /// <summary>
        /// �����Ϣ��־
        /// </summary>
        /// <param name="strInfo"></param>
        public static void WriteInfo(string strInfo)
        {
            CheckAndCreatelog();
            LogText(strInfo);
        }
        /// <summary>
        /// ���������־
        /// </summary>
        /// <param name="strInfo"></param>
        public static void WriteError(string strInfo)
        {
            CheckAndCreatelog();
            LogText(strInfo);
        }

        public static void WriteException(Exception ex) {
            CheckAndCreatelog();
            LogError(ex);
        }
    }
 
