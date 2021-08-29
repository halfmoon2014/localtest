using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanGo.Tools
{
    class FileUploadUtilChange
    {
        /// <summary>
        /// 用时
        /// </summary>
        private double second;

        /// <summary>
        /// 已上传字节
        /// </summary>
        private long offset;

        /// <summary>
        /// 文件大小
        /// </summary>
        private long fileLength;

        private long length;


        public double Second { get => second; set => second = value; }
        public long Offset { get => offset; set => offset = value; }
        public long FileLength { get => fileLength; set => fileLength = value; }
        public long Length { get => length; set => length = value; }
    }
}
