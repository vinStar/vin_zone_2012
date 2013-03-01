using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;

public partial class Lock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Boy[] Boys = new Boy[100];
        Thread[] Threads = new Thread[100];
        for (int i = 0; i < 100; i++)
        {
            Boys[i] = new Boy();
            Threads[i] = new Thread(new ThreadStart(Boys[i].TakeMoney));
            Threads[i].Name = "Boy" + i.ToString();
            Threads[i].Start();
        }

    }
    class ATM
    {
        static int remain = 5000;//可用金额

        public static void GiveOutMoney(int money)
        {
            lock (typeof(ATM))//核心代码！注释掉这句，会得到红色警报
            {
                if (remain >= money)
                {
                    Thread.Sleep(100);//模拟时间延迟
                    remain -= money;
                }
            }
            if (remain >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}$ /t in ATM.", remain);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}$ /t remained.", remain);
            }
        }
    }

    class Boy
    {
        Random want = new Random();
        int money;

        public void TakeMoney()
        {
            money = want.Next(50, 200);
            ATM.GiveOutMoney(money);
        }
    }




}
