using System;
using System.Threading;

namespace Task_Await
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Loop1); //looplarin her ikisinin eyni anda islemesi ucun thread-den ist.olunur.
            Thread thread2 = new Thread(Loop2);
            thread1.Start();
            thread2.Start();    //bir kod setri digerini bloklamir
            Console.WriteLine("lorem"); //bu kod setirinide ortalara istenilen yere ataraq ishleyecek.cunki thread novbeti setri bloklamir 

            thread1.Join();//novbeti setir islemiyecek, gozledecek, oz setirini oxutduqdan sonra
            thread2.Join();
            //Loop1();      //1ci loop isini bitirmemis 2e kecmiyecek consoleda
            //Loop2();
        }
        static void Loop1()
        {
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Loop1-{i}");
            }
        }
        static void Loop2()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine($"Loop2-{i}");
            }
        }
    }
}
