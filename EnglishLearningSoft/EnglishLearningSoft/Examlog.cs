/**
除了既有功能之外，然後把哪一個使用者哪一天甚麼時候作答的資訊、使用者是否答對、錯誤的地方，記錄在檔案當中(也就是所謂的log file)，
供日後進行大數據分析。此外另產生一個名為學習單的錯誤單字檔，供學習者能印出來加強學習。
*/
using System;
using System.IO;
namespace EnglishLearningSoftware
{
    internal class Examlog
    {
        string uName;
        FileStream usf;
        FileStream esf;
        StreamWriter usw;
        StreamWriter esw;
        public Examlog(string uname)
        {
            uName = uname;
            usf = new FileStream(uName + ".log", FileMode.OpenOrCreate);
            esf = new FileStream(uName + "Error.log", FileMode.OpenOrCreate);
            startExamLog();
            startExamErrorLog();
        }
//打开用户用于记录答题的日志文件。
        public void startExamLog()
        {
            usf.Position = usf.Length;
            usw = new StreamWriter(usf);
            usw.WriteLine(uName + "于" + DateTime.Now.ToString()+" 开始答题");
            usw.Flush();
        }
        //添加用户错误信息。
        public void startExamErrorLog()
        {
            esf.Position = esf.Length;
            esw = new StreamWriter(esf);
            esw.WriteLine(uName + "于" + DateTime.Now.ToString() + " 开始答题");
            esw.Flush();
        }
        //添加答题正确记录。
        public void addTExamLog(string input)
        {
            usf.Position = usf.Length;
            usw = new StreamWriter(usf);
            usw.WriteLine("T   "+input);
            usw.Flush();
        }
        public void addFExamLog(string input0, string input1)
        {
            usf.Position = usf.Length;
            usw = new StreamWriter(usf);
            usw.WriteLine("F   " + "输入记录为" + input0 + "    正确答案为" + input1);
            usw.Flush();
        }
        public void addExamErrorLog(string input0, string input1)
        {
            usf.Position = usf.Length;
            esw = new StreamWriter(esf);
            esw.WriteLine("输入记录为" + input0 + "    正确答案为" + input1);
            esw.Flush();
        }
        public void endExamLog(string time)
        {
            usf.Position = usf.Length;
            usw = new StreamWriter(usf);
            usw.WriteLine(uName + "于" + DateTime.Now.ToString() + " 结束答题。花费时间为" + time);
            usw.WriteLine();
            usw.Close();
            usf.Close();
        }
        public void endExamErrorLog(string time)
        {
            esf.Position = esf.Length;
            esw = new StreamWriter(esf);
            esw.WriteLine(uName + "于" + DateTime.Now.ToString() + " 结束答题。花费时间为" + time);
            esw.WriteLine();
            esw.Close();
            esf.Close();
        }

    }
}