using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            C1 c1 = new C1();
            //在t1线程中调用LockMe，并将deadlock设为true（将出现死锁）
            Thread t1 = new Thread(c1.LockMe);
            t1.Start(true);
            Thread.Sleep(100);         
            //在主线程中lock c1
            lock (c1)
            {
                //调用没有被lock的方法
                c1.DoNotLockMe();
                //调用被lock的方法，并试图将deadlock解除
                c1.LockMe(false);
            }
            Console.Read();
        }
       
    }
    class C1
    {
        private bool deadlocked = true;
        private object locker = new object();
        //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
        public void LockMe(object o)
        {
            //lock (this) 其它进程要lock(这个对象)的时候,就要等待
            lock (locker)//其它进程可以继续访问其它方法
            {
                int i = 0;
                while (deadlocked)
                {
                    deadlocked = (bool)o;
                    if (deadlocked)
                    {
                        Console.WriteLine("Foo: I am locked :(");
                    }
                    else
                    {
                        Console.WriteLine("Foo: I am locked :( false");
                    }
                     
                    Thread.Sleep(500);
                }
            }
        }
        //所有线程都可以同时访问的方法
        public void DoNotLockMe()
        {
            Console.WriteLine("I am not locked :)");
        }
    }

}
