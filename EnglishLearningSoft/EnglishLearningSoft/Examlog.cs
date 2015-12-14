/**
代码待优化不应频繁的打开关闭文件
*/
using System.IO;
namespace EnglishLearningSoftware
{
    internal class Examlog
    {
        string uName;

        public Examlog()
        {
        }
        private void getuName()
        {

        }
        private void addExamLog()
        {
            FileStream sf = File.OpenWrite(uName+".log");
            sf.Position = sf.Length;
            StreamWriter sw = new StreamWriter(sf);
        }
        private void addExamErrorLog()
        {
            FileStream sf = File.OpenWrite(uName + "Error.log");
            sf.Position = sf.Length;
            StreamWriter sw = new StreamWriter(sf);
        }
    }
}