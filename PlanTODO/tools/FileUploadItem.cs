using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanTODO.tools
{
    public class FileUploadItem
    {
        /// <summary>
        /// 上传地址
        /// </summary>
        private string address;
        /// <summary>
        /// 文件地址
        /// </summary>
        private string fileNamePath;

        /// <summary>
        /// 文件名
        /// </summary>
        private string saveName;

        public string Address { get => address; set => address = value; }
        public string FileNamePath { get => fileNamePath; set => fileNamePath = value; }
        public string SaveName { get => saveName; set => saveName = value; }
    }    
}
