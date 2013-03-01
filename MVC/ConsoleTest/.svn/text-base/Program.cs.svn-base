using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleTest
{
    public static class Extesion
    {


        public static string ConToString(this object str)
        {
            return Convert.ToString("1");
        }



    }




    class ATM
    {
        private static object mutexObject = new object();
        static int remain = 5000;//可用金额

        public static void GiveOutMoney(int money, string boyi)
        {
            lock (mutexObject)//核心代码！注释掉这句，会得到红色警报
            {
                if (remain >= money)
                {
                    //  Thread.Sleep(100);//模拟时间延迟
                    remain -= money;
                }
            }
            if (remain >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}$ /t in ATM. boy {1}", remain, boyi);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}$ /t remained.boy {1}", remain, boyi);
            }
        }
    }

    class Boy
    {
        string boyi;
        public Boy(string i)
        {
            this.boyi = i;
        }

        int money;
        Random want = new Random();
        public void TakeMoney()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}$ /t in ATM.", "boy " + boyi + "start take money");
            money = want.Next(50, 200);


            ATM.GiveOutMoney(money, boyi);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string aa = "aa";
            Console.WriteLine(aa.ConToString());




            Boy[] Boys = new Boy[100];
            Thread[] Threads = new Thread[100];
            for (int i = 0; i < 100; i++)
            {
                Boys[i] = new Boy(i.ToString());
                Threads[i] = new Thread(new ThreadStart(Boys[i].TakeMoney));
                Threads[i].Name = "Boy" + i.ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}$ /t waitring for taking money", "boy " + i);
                Threads[i].Start();

            }

            Console.WriteLine("test extension :" + aa.ConToString());
        }
    }

}
