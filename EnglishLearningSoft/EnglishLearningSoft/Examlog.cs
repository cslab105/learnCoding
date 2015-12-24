/**
除了既有功能之外，然後把哪一個使用者哪一天甚麼時候作答的資訊、使用者是否答對、錯誤的地方，記錄在檔案當中(也就是所謂的log file)，
供日後進行大數據分析。此外另產生一個名為學習單的錯誤單字檔，供學習者能印出來加強學習。
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