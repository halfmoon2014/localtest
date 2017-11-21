using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;  

namespace TestWeb
{
    public class SearchImageAsync : IHttpAsyncHandler 
    {
        private string imgPath = "img/img1.jpg";
        private const int BUFFER_SIZE = 1024;
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {

            FileStream fs = new FileStream(context.Server.MapPath(imgPath), FileMode.Open, FileAccess.Read, FileShare.Read, BUFFER_SIZE, FileOptions.Asynchronous);
            byte[] buffer = new byte[BUFFER_SIZE];
            MemoryStream result = new MemoryStream();
            return fs.BeginRead(buffer, 0, BUFFER_SIZE, new AsyncCallback(ReadFileCB), new ReadFileStateInfo(context, cb, extraData, fs, buffer, result));
        }

        private void ReadFileCB(IAsyncResult ar)
        {
            ReadFileStateInfo state = ar.AsyncState as ReadFileStateInfo;
            if (state == null) return;
            FileStream fs = state.ReadFileStream;
            int count = fs.EndRead(ar);

            if (count > 0)
            {
                state.ResultStream.Write(state.ReadBuffer, 0, count);
                fs.BeginRead(state.ReadBuffer, 0, BUFFER_SIZE, new AsyncCallback(ReadFileCB), state);
            }
            else
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }

                state.EndProcessCB(ar);
            }
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            ReadFileStateInfo state = result.AsyncState as ReadFileStateInfo;
            if (state == null) return;
            state.Context.Response.ContentType = "image/*";
            state.Context.Response.BinaryWrite(state.ResultStream.ToArray());
            state.ResultStream.Close();
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }  
    }
    public class ReadFileStateInfo
    {
        private AsyncCallback mEndProcessCB;
        public AsyncCallback EndProcessCB
        {
            get { return this.mEndProcessCB; }
            set { this.mEndProcessCB = value; }
        }

        private object mAsyncExtraData;
        public object AsyncExtraData
        {
            get { return this.mAsyncExtraData; }
            set { this.mAsyncExtraData = value; }
        }

        private FileStream mReadFileStream;
        public FileStream ReadFileStream
        {
            get { return this.mReadFileStream; }
            set { this.mReadFileStream = value; }
        }

        private byte[] mReadBuffer;
        /// <summary>  
        /// 读取文件的Buffer  
        /// </summary>  
        public byte[] ReadBuffer
        {
            get { return this.mReadBuffer; }
            set { this.mReadBuffer = value; }
        }

        private MemoryStream mResultStream;
        /// <summary>  
        /// 保存结果的内存流  
        /// </summary>  
        public MemoryStream ResultStream
        {
            get { return this.mResultStream; }
            set { this.mResultStream = value; }
        }
        private HttpContext mContext;
        public HttpContext Context
        {
            get { return this.mContext; }
            set { this.mContext = value; }
        }

        public ReadFileStateInfo(HttpContext context, AsyncCallback cb, object extraData, FileStream readFileStream, byte[] readBuffer, MemoryStream result)
        {
            this.mContext = context;
            this.mEndProcessCB = cb;
            this.mAsyncExtraData = extraData;
            this.mReadFileStream = readFileStream;
            this.mReadBuffer = readBuffer;
            this.mResultStream = result;
        }
    }  
}
