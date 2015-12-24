using System;
using System.IO;
using System.Threading;
namespace EnglishLearningSoftware
{

    class MainClass
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";
            Console.WriteLine("欢迎使用HE的英语学习软件");
            //Thread exam = new Thread(Exam E1 = new Exam()).Start
            Umessage L1 = new Umessage();
            //Timer T1 = new Timer();
            Examlog EL1 = new Examlog(L1.uName);
            Exam E1 = new Exam(EL1);
            //Guess G1 = new Guess();
            //Console.WriteLine(T1.ToString());
        }
    }

}
