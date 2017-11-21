using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestWeb
{
    public class SingletonMultiThread
    {
        private static SingletonMultiThread instance;
       private static object _lock=new object();

       private SingletonMultiThread()
       {

       }

       public static SingletonMultiThread GetInstance()
       {
               if(instance==null)
               {
                      lock(_lock)
                      {
                             if(instance==null)
                             {
                                 instance = new SingletonMultiThread();
                             }
                      }
               }
               return instance;
       }
    }
}
