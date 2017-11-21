using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestWeb
{
    public class Singleton2
    {
        private static readonly Singleton2 instance=new Singleton2();

        private Singleton2()
        {
        }

        public static Singleton2 GetInstance()
        {
               return instance;
        }
    }
}
