using System;
using System.Threading;

namespace RaceCondition
{
    internal class Program
    {
        public int Count { get; set; }
        private Object obj1 = new Object();
        private Object obj2 = new Object();
        static void Main(string[] args)
        {
            Program p=new Program();//cagirmaq ucun instance almaq
            p.Increase();
            p.Decrease();
            Console.WriteLine(p.Count);//eyni anda hem artib hem azaldigina gore count 0 olur.  
            Thread thread1 = new Thread(p.Increase);
            Thread thread2 = new Thread(p.Decrease);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            
        }
        void Increase()
        {
            for (int i = 0; i < 10000; i++)
            {
                //Count++;
                {
                    lock (obj1)
                    {
                        //Count++;
                        lock (obj2)
                        {
                            Count++;
                        }
                    }
                }
            }
        }
        void Decrease()
        {
            for (int i = 0; i < 10000; i++)
            {
                //Count--;
                lock (obj2) //xeberdarliq edir ki, orda obyekt var
                {
                    // Count--;
                    lock (obj1) //deadlockda ise objectleri ters yaziriq. ve proqram cokur. ikiside birbirini gozleyir, ve proqram icra olmadigina gore cokur.
                    {
                        Count--;
                    }
                }
            }
        }
    }
}
