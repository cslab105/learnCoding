using System;
using System.IO;
using System.Threading;
namespace EnglishLearningSoftware
{

    class MainClass
    {
        static void Main(string[] args)
        {
            //调用insetDataToDB将文档中的单词导入到数据库
            //insetDataToDB iDTDB = new insetDataToDB();
            //将线程命名为main
            Thread.CurrentThread.Name = "main";
            Console.WriteLine("欢迎使用HE的英语学习软件");
            //本来打算写多线程
            //Thread exam = new Thread(Exam E1 = new Exam()).Start
            //启用用户信息管理类
            UmessageHASH L1 = new UmessageHASH();
            //现在将计时器放在Exam类中调用了
            //Timer T1 = new Timer();
            //启动考试记录功能
            Examlog EL1 = new Examlog(L1.uName);
            //启动考试功能
            Exam E1 = new Exam(EL1);
            //原猜单词功能
            //Guess G1 = new Guess();
            //原打印花费总时间，现在放在Exam中调用
            //Console.WriteLine(T1.ToString());
        }
    }

}
